using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormProgramLinkOutputFile:Form {

		private Program _curProg;

		public FormProgramLinkOutputFile(Program program) {
			InitializeComponent();
			Lan.F(this);
			_curProg=program;
		}

		private void FormProgramLinkOutputFile_Load(object sender,EventArgs e) {
			textTemplate.Text=_curProg.FileTemplate;
			textPath.Text=_curProg.FilePath;
			listFields.Items.Add("[PatNum]");
			listFields.Items.Add("[ChartNumber]");
			listFields.Items.Add("[FName]");
			listFields.Items.Add("[LName]");
			listFields.Items.Add("[Birthdate]");
			listFields.Items.Add("[SSN]");
			listFields.Items.Add("[Gender]");
			listFields.Items.Add("[Address]");
			listFields.Items.Add("[City]");
			listFields.Items.Add("[State]");
			listFields.Items.Add("[Zip]");
			listFields.Items.Add("[HmPhone]");
			listFields.Items.Add("[WkPhone]");
			listFields.Items.Add("[WirelessPhone]");
		}

		private void butImport_Click(object sender,EventArgs e) {
			OpenFileDialog openFileDialog=new OpenFileDialog();
			if(openFileDialog.ShowDialog()!=DialogResult.OK) {
				return;
			}
			string[] fileNames=openFileDialog.FileNames;
			if(fileNames.Length<1) {
				return;
			}
			textPath.Text=fileNames[0];
		}

		private void listBoxFields_Click(object sender,EventArgs e) {
			textTemplate.Focus();
			string clickedFieldStr=listFields.GetItemText(listFields.SelectedItem);
			int cursorIndex=textTemplate.SelectionStart;
			textTemplate.Text=textTemplate.Text.Insert(cursorIndex,clickedFieldStr);
			textTemplate.SelectionStart=cursorIndex+clickedFieldStr.Length;
		}

		private void butOK_Click(object sender,EventArgs e) {
			_curProg.FilePath=textPath.Text;
			_curProg.FileTemplate=textTemplate.Text;
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

	}
}