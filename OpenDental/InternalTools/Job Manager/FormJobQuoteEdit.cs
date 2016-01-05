using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormJobQuoteEdit:Form {
		private JobQuote _jobQuote;

		///<summary>Used for existing Reviews. Pass in the jobNum and the jobReviewNum.</summary>
		public FormJobQuoteEdit(JobQuote jobQuote) {
			_jobQuote=jobQuote.Copy();
			InitializeComponent();
			Lan.F(this);
		}

		public JobQuote JobQuoteCur {
			get {
				return _jobQuote;
			}
		}

		private void FormJobQuoteEdit_Load(object sender,EventArgs e) {
			if(!JobPermissions.IsAuthorized(JobPerm.Quote,true)) {
				textNote.ReadOnly=true;
				butOK.Enabled=false;
				butDelete.Enabled=false;
			}
			if(_jobQuote.PatNum>0) {
				Patient pat=Patients.GetPat(_jobQuote.PatNum);
				if(pat!=null) {
					textPatient.Text=pat.GetNameFL();
				}
				else {
					textPatient.Text="Missing Patient - "+_jobQuote.PatNum;
				}
			}
			textNote.Text=_jobQuote.Note;
			textAmount.Text=_jobQuote.Amount;
		}

		private void butPatPicker_Click(object sender,EventArgs e) {
			FormPatientSelect FormPS=new FormPatientSelect();
			if(_jobQuote.PatNum!=0) {
				FormPS.ExplicitPatNums=new List<long> {_jobQuote.PatNum};
			}
			FormPS.ShowDialog();
			if(FormPS.DialogResult!=DialogResult.OK) {
				return;
			}
			Patient pat=Patients.GetPat(FormPS.SelectedPatNum);
			if(pat!=null) {
				_jobQuote.PatNum=pat.PatNum;
				textPatient.Text=pat.GetNameFL();
			}
			else {
				_jobQuote.PatNum=0;
				textPatient.Text="Missing Patient - "+_jobQuote.PatNum;
			}
		}

		private void butDelete_Click(object sender,EventArgs e) {
			if(_jobQuote.IsNew) {
				DialogResult=DialogResult.Cancel;
				return;
			}
			if(MsgBox.Show(this,MsgBoxButtons.YesNo,"Delete the current job quote, delete will not be permanent until changes are saved?")) {
				_jobQuote=null;
				DialogResult=DialogResult.OK;
			}
		}

		private void butOK_Click(object sender,EventArgs e) {
			_jobQuote.Note=textNote.Text;
			_jobQuote.Amount=PIn.Double(textAmount.Text).ToString("F");//I personally think if they enter nothing it'll put in 0.00 for them. Good?
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel; //removing new jobs from the DB is taken care of in FormClosing
		}

	}
}