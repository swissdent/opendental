﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental.InternalTools.Job_Manager {
	
	public partial class UserControlJobEdit:UserControl {
		//FIELDS
		public bool IsNew;
		private Job _jobOld;
		private Job _jobCur;
		///<summary>Private member for IsChanged Property. Private setter, public getter.</summary>
		private bool _isChanged;
		private bool _isOverride;
		private bool _isLoading;

		///<summary>Occurs whenever this control saves changes to DB, after the control has redrawn itself. 
		/// Usually connected to either a form close or refresh.</summary>
		[Category("Action"),Description("Whenever this control saves changes to DB, after the control has redrawn itself. Usually connected to either a form close or refresh.")]
		public event EventHandler SaveClick=null;

		public delegate void UpdateTitleEvent(object sender,string title);
		public event UpdateTitleEvent TitleChanged=null;

		public delegate void JobOverrideEvent(object sender,bool isOverride);
		public event JobOverrideEvent JobOverride=null;

		//PROPERTIES
		public bool IsChanged {
			get { return _isChanged; }
			private set {
				if(_isLoading) {
					_isChanged=false;
					butSave.Enabled=false;
					return;
				}
				_isChanged=value;
				butSave.Enabled=_isChanged;
			}
		}

		private bool IsChangeRequest { get; set; }

		public bool IsOverride {
			get {return _isOverride;}
			set {
				_isOverride=value;
				CheckPermissions();
			}
		}

		//FUNCTIONS
		public UserControlJobEdit() {
			InitializeComponent();
			Enum.GetNames(typeof(JobPriority)).ToList().ForEach(x=>comboPriority.Items.Add(x));		
			Enum.GetNames(typeof(JobPhase)).ToList().ForEach(x=>comboStatus.Items.Add(x));
			Enum.GetNames(typeof(JobCategory)).ToList().ForEach(x=>comboCategory.Items.Add(x));
		}

		///<summary>Not a property so that this is compatible with the VS designer.</summary>
		public Job GetJob() {
			if(_jobCur==null) {
				return null;
			}
			Job job = _jobCur.Copy();
			job.Description=textEditorMain.MainRtf;
			job.HoursActual=PIn.Int(textActualHours.Text);
			job.HoursEstimate=PIn.Int(textEstHours.Text);
			job.Priority=(JobPriority)comboPriority.SelectedIndex;
			job.PhaseCur=(JobPhase)comboStatus.SelectedIndex;
			job.Category=(JobCategory)comboCategory.SelectedIndex;
			return job;
		}

		///<summary>Should only be called once when new job should be loaded into control. If called again, changes will be lost.</summary>
		public void LoadJob(Job job) {
			_isLoading=true;
			this.Enabled=false;//disable control while it is filled.
			_isOverride=false;
			IsChangeRequest=false;
			IsChanged=false;
			if(job==null) {
				_jobCur=new Job();
			}
			else {
				_jobCur=job.Copy();
				IsNew=job.IsNew;
			}
			_jobOld=_jobCur.Copy();//cannot be null
			textTitle.Text=_jobCur.Title;
			textJobNum.Text=_jobCur.JobNum>0?_jobCur.JobNum.ToString():Lan.g("Jobs","New Job");
			comboPriority.SelectedIndex=(int)_jobCur.Priority;
			comboStatus.SelectedIndex=(int)_jobCur.PhaseCur;
			if(_jobCur.IsApprovalNeeded) {
				textApprove.Text="Waiting";
			}
			else if(_jobCur.UserNumApproverConcept>0 ||_jobCur.UserNumApproverJob>0||_jobCur.UserNumApproverChange>0) {
				textApprove.Text="Yes";
			}
			else {
				textApprove.Text="No";
			}
			comboCategory.SelectedIndex=(int)_jobCur.Category;
			textDateEntry.Text=_jobCur.DateTimeEntry.Year>1880?_jobCur.DateTimeEntry.ToShortDateString():"";
			textVersion.Text=_jobCur.JobVersion;
			try {
				textEditorMain.MainRtf=_jobCur.Description;//This is here to convert our old job descriptions to the new RTF descriptions.
			}
			catch {
				textEditorMain.MainText=_jobCur.Description;
			}
			textEstHours.Text=_jobCur.HoursEstimate.ToString();
			textActualHours.Text=_jobCur.HoursActual.ToString();
			Job parent=Jobs.GetOne(_jobCur.ParentNum);
			textParent.Text=parent!=null?parent.ToString():"";
			try {
				textEditorDocumentation.MainRtf=_jobCur.Documentation;//This is here to convert our old job descriptions to the new RTF descriptions.
			}
			catch {
				textEditorDocumentation.MainText=_jobCur.Documentation;
			}
			FillAllGrids();
			IsChanged=false;
			CheckPermissions();
			if(job!=null) {//re-enable control after we have loaded the job.
				this.Enabled=true;
			}
			_isLoading=false;
		}

		private void FillAllGrids() {
			FillGridRoles();
			FillGridWatchers();
			FillGridCustQuote();
			FillGridTasks();
			FillGridFeatuerReq();
			FillGridBugs();
			FillGridNote();
			FillGridReviews();
			FillGridHistory();
		}

		private void FillGridRoles() {
			gridRoles.BeginUpdate();
			gridRoles.Columns.Clear();
			gridRoles.Columns.Add(new ODGridColumn("Role",90));
			gridRoles.Columns.Add(new ODGridColumn("User",50));
			gridRoles.NoteSpanStart=0;
			gridRoles.NoteSpanStop=1;
			gridRoles.Rows.Clear();
			//These columns are ordered by convenience, If some other ordering would be more convenient then they should just be re-ordered.
			gridRoles.AddRow("Expert",Userods.GetName(_jobCur.UserNumExpert));
			gridRoles.AddRow("Engineer",Userods.GetName(_jobCur.UserNumEngineer));
			gridRoles.AddRow("Documenter",Userods.GetName(_jobCur.UserNumDocumenter));
			gridRoles.AddRow("Submitter",Userods.GetName(_jobCur.UserNumConcept));
			gridRoles.AddRow("Apprv Con",Userods.GetName(_jobCur.UserNumApproverConcept));
			gridRoles.AddRow("Apprv Job",Userods.GetName(_jobCur.UserNumApproverJob));
			gridRoles.AddRow("Apprv Chg",Userods.GetName(_jobCur.UserNumApproverChange));
			foreach(JobReview jobReview in _jobCur.ListJobReviews.Where(x=>x.ReviewStatus==JobReviewStatus.Done)) {
				gridRoles.AddRow("Reviewer",Userods.GetName(jobReview.ReviewerNum));
			}
			if(_jobCur.ListJobReviews.Count(x => x.ReviewStatus==JobReviewStatus.Done)==0) {
				gridRoles.AddRow("Reviewer","");
			}
			gridRoles.Rows.Add(new ODGridRow("Cust. Contact",Userods.GetName(_jobCur.UserNumCustContact)) { Note=_jobCur.DateTimeCustContact.Year<1880?"":_jobCur.DateTimeCustContact.ToShortDateString() });
			ODGridRow row =new ODGridRow("Checked Out",Userods.GetName(_jobCur.UserNumCheckout));
			if(_jobCur.UserNumCheckout==0) {
				//Do nothing.
			}
			else if(_jobCur.UserNumCheckout!=Security.CurUser.UserNum) {
				row.ColorBackG=Color.FromArgb(254,235,233);//light red
			}
			else {
				row.ColorBackG=Color.FromArgb(235,254,233);//light green
			}
			gridRoles.Rows.Add(row);
			gridRoles.EndUpdate();
		}

		private void FillGridWatchers() {
			gridWatchers.BeginUpdate();
			gridWatchers.Columns.Clear();
			gridWatchers.Columns.Add(new ODGridColumn("",50));
			gridWatchers.Rows.Clear();
			List<Userod> listWatchers=_jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Watcher).Select(x => UserodC.Listt.FirstOrDefault(y => y.UserNum==x.FKey)).ToList();
			foreach(Userod user in listWatchers.FindAll(x => x!=null)){
				ODGridRow row=new ODGridRow() { Tag =user };
				row.Cells.Add(user.UserName);
				gridWatchers.Rows.Add(row);
			}
			gridWatchers.EndUpdate();
		}

		private void FillGridCustQuote() {
			gridCustomerQuotes.BeginUpdate();
			gridCustomerQuotes.Columns.Clear();
			gridCustomerQuotes.Columns.Add(new ODGridColumn("PatNum",75));
			gridCustomerQuotes.Columns.Add(new ODGridColumn("Quote",50));
			gridCustomerQuotes.NoteSpanStart=0;
			gridCustomerQuotes.NoteSpanStop=1;
			gridCustomerQuotes.Rows.Clear();
			foreach(JobQuote jobQuote in _jobCur.ListJobQuotes){
				ODGridRow row=new ODGridRow() { Tag=jobQuote };//JobQuote
				row.Cells.Add(jobQuote.PatNum.ToString());
				row.Cells.Add(jobQuote.Amount);
				row.Note=jobQuote.Note;
				gridCustomerQuotes.Rows.Add(row);
			}
			gridCustomerQuotes.EndUpdate();
		}

		private void FillGridTasks() {
			gridTasks.BeginUpdate();
			gridTasks.Columns.Clear();
			gridTasks.Columns.Add(new ODGridColumn("Date",70));
			gridTasks.Columns.Add(new ODGridColumn("TaskList",100));
			gridTasks.Columns.Add(new ODGridColumn("Done",40) { TextAlign=HorizontalAlignment.Center });
			gridTasks.NoteSpanStart=0;
			gridTasks.NoteSpanStop=2;
			gridTasks.Rows.Clear();
			List<Task> listTasks=_jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Task).Select(x => Tasks.GetOne(x.FKey)).ToList();
			foreach(Task task in listTasks.FindAll(x => x!=null)){
				ODGridRow row=new ODGridRow() { Tag=task.TaskNum };//taskNum
				row.Cells.Add(task.DateTimeEntry.ToShortDateString());
				row.Cells.Add(TaskLists.GetOne(task.TaskListNum).Descript);
				row.Cells.Add(task.DateTimeFinished.Year>1880?"X":"");
				row.Note=task.Descript.Left(100,true).Trim();
				gridTasks.Rows.Add(row);
			}
			gridTasks.EndUpdate();
		}

		private void FillGridFeatuerReq() {
			gridFeatureReq.BeginUpdate();
			gridFeatureReq.Columns.Clear();
			gridFeatureReq.Columns.Add(new ODGridColumn("Feat Req Num",150));
			//todo: add status of FR. Difficult because FR dataset comes from webservice.
			//gridFeatureReq.Columns.Add(new ODGridColumn("Status",50){TextAlign=HorizontalAlignment.Center});
			gridFeatureReq.Rows.Clear();
			List<long> listReqNums=_jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Request).Select(x => x.FKey).ToList();
			foreach(long reqNum in listReqNums){
				ODGridRow row=new ODGridRow() { Tag=reqNum };//FR Num
				row.Cells.Add(reqNum.ToString());
				//todo: add status of FR. Difficult because FR dataset comes from webservice.
				gridFeatureReq.Rows.Add(row);
			}
			gridFeatureReq.EndUpdate();
		}

		private void FillGridBugs() {
			gridBugs.BeginUpdate();
			gridBugs.Columns.Clear();
			gridBugs.Columns.Add(new ODGridColumn("Bug Num (From JRMT)",50));
			gridBugs.Rows.Clear();
			List<long> listBugNums=_jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Bug).Select(x => x.FKey).ToList();
			foreach(Bug bug in listBugNums.Select(Bugs.GetOne).Where(x=>x!=null)){
				ODGridRow row=new ODGridRow() { Tag=bug.BugId };//bugNum
				row.Cells.Add(bug.Description);
				gridBugs.Rows.Add(row);
			}
			gridBugs.EndUpdate();
		}

		public void FillGridNote() {
			gridNotes.BeginUpdate();
			gridNotes.Columns.Clear();
			gridNotes.Columns.Add(new ODGridColumn(Lan.g(this,"Date Time"),120));
			gridNotes.Columns.Add(new ODGridColumn(Lan.g(this,"User"),80));
			gridNotes.Columns.Add(new ODGridColumn(Lan.g(this,"Note"),400));
			gridNotes.Rows.Clear();
			ODGridRow row;
			foreach(JobNote jobNote in _jobCur.ListJobNotes) {
				row=new ODGridRow();
				row.Cells.Add(jobNote.DateTimeNote.ToShortDateString()+" "+jobNote.DateTimeNote.ToShortTimeString());
				row.Cells.Add(Userods.GetName(jobNote.UserNum));
				row.Cells.Add(jobNote.Note);
				row.Tag=jobNote;
				gridNotes.Rows.Add(row);
			}
			gridNotes.EndUpdate();
			gridNotes.ScrollToEnd();
		}

		private void FillGridReviews() {
			long selectedReviewNum=0;
			if(gridReview.GetSelectedIndex()!=-1 && (gridReview.Rows[gridReview.GetSelectedIndex()].Tag is JobReview)) {
				selectedReviewNum=((JobReview)gridReview.Rows[gridReview.GetSelectedIndex()].Tag).JobNum;
			}
			gridReview.BeginUpdate();
			gridReview.Columns.Clear();
			gridReview.Columns.Add(new ODGridColumn("Date Last Edited",100));
			gridReview.Columns.Add(new ODGridColumn("Reviewer",80));
			gridReview.Columns.Add(new ODGridColumn("Status",80));
			gridReview.Columns.Add(new ODGridColumn("Description",200));
			gridReview.Rows.Clear();
			ODGridRow row;
			foreach(JobReview jobReview in _jobCur.ListJobReviews) {
				row=new ODGridRow();
				row.Cells.Add(jobReview.DateTStamp.ToShortDateString());
				row.Cells.Add(Userods.GetName(jobReview.ReviewerNum));
				row.Cells.Add(Enum.GetName(typeof(JobReviewStatus),(int)jobReview.ReviewStatus));
				row.Cells.Add(jobReview.Description.Left(500,true));
				row.Tag=jobReview;
				gridReview.Rows.Add(row);
			}
			gridReview.EndUpdate();
			for(int i=0;i<gridReview.Rows.Count;i++) {
				if(gridReview.Rows[i].Tag is JobReview && ((JobReview)gridReview.Rows[i].Tag).JobReviewNum==selectedReviewNum) {
					gridReview.SetSelected(i,true);
					break;
				}
			}
		}

		private void FillGridHistory() {
			long selectedEventNum=0;
			if(gridHistory.GetSelectedIndex()!=-1) {
				selectedEventNum=(long)gridHistory.Rows[gridHistory.GetSelectedIndex()].Tag;
			}
			gridHistory.BeginUpdate();
			gridHistory.Columns.Clear();
			gridHistory.Columns.Add(new ODGridColumn("Date",140));
			gridHistory.Columns.Add(new ODGridColumn("Owner",100));
			gridHistory.Columns.Add(new ODGridColumn("Status",100));
			gridHistory.Rows.Clear();
			ODGridRow row;
			foreach(JobEvent jobEvent in _jobCur.ListJobEvents) {
				row=new ODGridRow();
				row.Cells.Add(jobEvent.DateTimeEntry.ToShortDateString()+" "+jobEvent.DateTimeEntry.ToShortTimeString());
				row.Cells.Add(Userods.GetName(jobEvent.UserNumEvent));
				row.Cells.Add(Enum.GetName(typeof(JobPhase),(int)jobEvent.JobStatus));
				row.Tag=jobEvent.JobEventNum;
				gridHistory.Rows.Add(row);
			}
			gridHistory.EndUpdate();
			for(int i=0;i<gridHistory.Rows.Count;i++) {
				if((long)gridHistory.Rows[i].Tag==selectedEventNum) {
					gridHistory.SetSelected(i,true);
					break;
				}
			}
		}

		///<summary>Based on job status, category, and user role, this will enable or disable various controls.</summary>
		private void CheckPermissions() {
			//disable various controls and re-enable them below depending on permissions.
			textTitle.ReadOnly=true;
			comboPriority.Enabled=false;
			comboStatus.Enabled=false;
			comboCategory.Enabled=false;
			textVersion.ReadOnly=true;
			textEstHours.Enabled=false;
			textActualHours.Enabled=false;
			butParentPick.Visible=false;
			butParentRemove.Visible=false;
			gridCustomerQuotes.HasAddButton=false;//Quote permission only
			textEditorMain.ReadOnly=true;
			if(_jobCur==null) {
				return;
			}
			if(JobPermissions.IsAuthorized(JobPerm.Quote,true) && _jobOld.PhaseCur!=JobPhase.Complete && _jobOld.PhaseCur!=JobPhase.Cancelled) {
				gridCustomerQuotes.HasAddButton=true;
			}
			switch(_jobCur.PhaseCur) {
				case JobPhase.Concept:
					if(!JobPermissions.IsAuthorized(JobPerm.Concept,true) || (_jobCur.IsApprovalNeeded && !JobPermissions.IsAuthorized(JobPerm.Approval,true))) {
						break;
					}
					//Can only edit concept job if you meet one of the following
					//1) You have concept permission.
					//2) Concept needs approval and you have approval permission
					textTitle.ReadOnly=false;
					comboPriority.Enabled=true;
					//comboStatus.Enabled=true;
					comboCategory.Enabled=true;
					textVersion.ReadOnly=false;
					textEstHours.Enabled=true;
					textActualHours.Enabled=true;
					butParentPick.Visible=true;
					butParentRemove.Visible=true;
					//gridCustomerQuotes.HasAddButton=true;//Quote permission only
					textEditorMain.ReadOnly=false;
					break;
				case JobPhase.Definiton:
					if(!_jobCur.IsApprovalNeeded
						&& (!JobPermissions.IsAuthorized(JobPerm.Writeup,true)
							|| (JobPermissions.IsAuthorized(JobPerm.Writeup,true) && _jobCur.UserNumExpert!=Security.CurUser.UserNum && _jobCur.UserNumExpert!=0))) 
					{
						break;
					}
					if(_jobCur.IsApprovalNeeded && !JobPermissions.IsAuthorized(JobPerm.Approval,true)) {//job needs approval and you are not authorized.
						break;
					}
					//Can only edit writeup job if you meet one of the following
					//1) You have writeup permission and the job is unnasigned or assinged to you
					//2) Job needs approval and you have approval permission
					textTitle.ReadOnly=false;
					comboPriority.Enabled=true;
					//comboStatus.Enabled=true;
					comboCategory.Enabled=true;
					textVersion.ReadOnly=false;
					textEstHours.Enabled=true;
					textActualHours.Enabled=true;
					butParentPick.Visible=true;
					butParentRemove.Visible=true;
					//gridCustomerQuotes.HasAddButton=true;//Quote permission only
					textEditorMain.ReadOnly=false;
					break;
				case JobPhase.Development:
					if(!_jobCur.IsApprovalNeeded
						&& (!JobPermissions.IsAuthorized(JobPerm.Writeup,true)
							|| (JobPermissions.IsAuthorized(JobPerm.Writeup,true) && _jobCur.UserNumExpert!=Security.CurUser.UserNum && _jobCur.UserNumExpert!=0))
						&& (!JobPermissions.IsAuthorized(JobPerm.Engineer,true)
							|| (JobPermissions.IsAuthorized(JobPerm.Engineer,true) && _jobCur.UserNumEngineer!=Security.CurUser.UserNum && _jobCur.UserNumEngineer!=0))) {
						break;
					}
					if(_jobCur.IsApprovalNeeded && !JobPermissions.IsAuthorized(JobPerm.Approval,true)) {//job needs approval and you are not authorized.
						break;
					}
					//Can only edit concept job if you meet one of the following
					//1) You have concept permission.
					//2) Concept needs approval and you have approval permission
					//textTitle.ReadOnly=false;
					comboPriority.Enabled=true;
					//comboStatus.Enabled=true;
					comboCategory.Enabled=true;
					textVersion.ReadOnly=false;
					textEstHours.Enabled=true;
					textActualHours.Enabled=true;
					butParentPick.Visible=true;
					butParentRemove.Visible=true;
					//gridCustomerQuotes.HasAddButton=true;//Quote permission only
					//textEditorMain.ReadOnly=false; //Using Change Request action allows editing of jobs in development.
					break;
				case JobPhase.Documentation:
					if(!JobPermissions.IsAuthorized(JobPerm.Documentation,true)) {
						break;
					}
					//Can only edit concept job if you meet one of the following
					//1) You have concept permission.
					//2) Concept needs approval and you have approval permission
					//textTitle.ReadOnly=false;
					comboPriority.Enabled=true;
					//comboStatus.Enabled=true;
					comboCategory.Enabled=true;
					textVersion.ReadOnly=false;
					textEstHours.Enabled=true;
					textActualHours.Enabled=true;
					butParentPick.Visible=true;
					butParentRemove.Visible=true;
					//gridCustomerQuotes.HasAddButton=true;//Quote permission only
					//textEditorMain.ReadOnly=false;
					break;
				case JobPhase.Complete:
					//Can only edit concept job if you meet one of the following
					//1) You have concept permission.
					//2) Concept needs approval and you have approval permission
					//textTitle.ReadOnly=false;
					//comboPriority.Enabled=true;
					//comboStatus.Enabled=true;
					//comboCategory.Enabled=true;
					//textVersion.ReadOnly=false;
					//textEstHours.Enabled=true;
					//textActualHours.Enabled=true;
					//butParentPick.Visible=true;
					//butParentRemove.Visible=true;
					//gridCustomerQuotes.HasAddButton=true;//Quote permission only
					//textEditorMain.ReadOnly=false;
					break;
				case JobPhase.Cancelled:
					//if(!JobPermissions.IsAuthorized(JobPerm.Concept,true)) {
					//	break;
					//}
					//Can only edit concept job if you meet one of the following
					//1) You have concept permission.
					//2) Concept needs approval and you have approval permission
					//textTitle.ReadOnly=false;
					//comboPriority.Enabled=true;
					//comboStatus.Enabled=true;
					//comboCategory.Enabled=true;
					//textVersion.ReadOnly=false;
					//textEstHours.Enabled=true;
					//textActualHours.Enabled=true;
					//butParentPick.Visible=true;
					//butParentRemove.Visible=true;
					//gridCustomerQuotes.HasAddButton=true;//Quote permission only
					//textEditorMain.ReadOnly=false;
					break;
				default:
					MessageBox.Show("Unsupported job status. Add to UserControlJobEdit.CheckPermissions()");
					break;
			}
			//Disable description and title if "Checked out"
			textEditorMain.Enabled=true;//might still be read only.
			if(_jobCur.UserNumCheckout!=0 && _jobCur.UserNumCheckout!=Security.CurUser.UserNum) {
				textTitle.ReadOnly=true;
				textEditorMain.ReadOnly=true;
				textEditorMain.Enabled=false;
			}
			if(IsChangeRequest) {
				textEditorMain.ReadOnly=false;
			}
			if(_isOverride) {//Enable everything and make everything visible
				textTitle.ReadOnly=false;
				comboPriority.Enabled=true;
				comboStatus.Enabled=true;
				comboCategory.Enabled=true;
				textVersion.ReadOnly=false;
				textEstHours.Enabled=true;
				textActualHours.Enabled=true;
				butParentPick.Visible=true;
				butParentRemove.Visible=true;
				gridCustomerQuotes.HasAddButton=true;
				textEditorMain.ReadOnly=false;
				textEditorMain.Enabled=true;
			}
		}

		///<summary>Resizes Link Grids in group box.</summary>
		private void groupLinks_Resize(object sender,EventArgs e) {
			List<ODGrid> grids=groupLinks.Controls.OfType<ODGrid>().OrderBy(x => x.Top).ToList();
			int padding=4;
			int topMost=grids.Min(x=>x.Top);
			int sizeEach=(groupLinks.Height-topMost-(padding*grids.Count))/grids.Count;
			for(int i=0;i<grids.Count;i++) {
				grids[i].Top=topMost+(i*(sizeEach+padding));
				grids[i].Height=sizeEach;
			}
		}

		private void butActions_Click(object sender,EventArgs e) {
			bool perm=false;
			ContextMenu actionMenu=new System.Windows.Forms.ContextMenu();
			switch(_jobCur.PhaseCur) {
				case JobPhase.Concept:
					perm=JobPermissions.IsAuthorized(JobPerm.Approval,true)||JobPermissions.IsAuthorized(JobPerm.Concept,true);//x
					if(IsNew) {
						actionMenu.MenuItems.Add(new MenuItem("Save Concept",(o,arg)=> {
							if(!ValidateJob(_jobCur)) {
								return;
							};
							SaveJob(_jobCur); }) { Enabled=true });
					}
					actionMenu.MenuItems.Add(new MenuItem((_jobCur.UserNumConcept==0 ? "A" : "Rea")+"ssign Submitter",actionMenu_AssignSubmitterClick) { Enabled=perm });//x
					if(!_jobCur.IsApprovalNeeded) {//x
						perm=JobPermissions.IsAuthorized(JobPerm.Concept,true);//x
						actionMenu.MenuItems.Add(new MenuItem("Send for Approval",actionMenu_RequestConceptApprovalClick) { Enabled=perm });//x
						if(_jobCur.Category==JobCategory.Bug) {//x
							actionMenu.MenuItems.Add(new MenuItem("Send to Writeup",actionMenu_SendWriteupClick) { Enabled=perm });//x
							actionMenu.MenuItems.Add(new MenuItem("Send to In Development",actionMenu_SendInDevelopmentClick) { Enabled=perm });//x
						}
					}
					else {
						perm=JobPermissions.IsAuthorized(JobPerm.Approval,true);//x
						actionMenu.MenuItems.Add(new MenuItem("Approve Concept",actionMenu_ApproveConceptClick) { Enabled=perm });//x
						actionMenu.MenuItems.Add(new MenuItem("Approve Job",actionMenu_ApproveJobClick) { Enabled=perm });//x
						actionMenu.MenuItems.Add(new MenuItem("Request Clarification",actionMenu_RequestClarificationClick) { Enabled=perm });//x
						actionMenu.MenuItems.Add(new MenuItem("Cancel Concept",actionMenu_CancelJobClick) { Enabled=perm });//x
					}
					break;
				case JobPhase.Definiton:
					if(!_jobCur.IsApprovalNeeded) {
						if(JobPermissions.IsAuthorized(JobPerm.Approval,true) || JobPermissions.IsAuthorized(JobPerm.Writeup,true)) {
							actionMenu.MenuItems.Add(new MenuItem((_jobCur.UserNumExpert==0 ? "A" : "Rea")+"ssign Expert",actionMenu_AssignExpertClick) { Enabled=true });//x
						}
						perm=JobPermissions.IsAuthorized(JobPerm.Writeup,true) && (_jobCur.UserNumExpert==0 || _jobCur.UserNumExpert==Security.CurUser.UserNum);
						actionMenu.MenuItems.Add(new MenuItem("Send for Approval",actionMenu_RequestJobApprovalClick) { Enabled=perm });//x
						if(_jobCur.Category==JobCategory.Bug) {
							actionMenu.MenuItems.Add(new MenuItem("Send to In Development",actionMenu_SendInDevelopmentClick) { Enabled=perm });//x
						}
					}
					else {
						perm=JobPermissions.IsAuthorized(JobPerm.Approval,true);
						actionMenu.MenuItems.Add(new MenuItem("Approve Job",actionMenu_ApproveJobClick) { Enabled=perm });
						actionMenu.MenuItems.Add(new MenuItem("Request Clarification",actionMenu_RequestClarificationClick) { Enabled=perm });
						actionMenu.MenuItems.Add(new MenuItem("Cancel Job",actionMenu_CancelJobClick) { Enabled=perm });
					}
					break;
				case JobPhase.Development:
					if(!_jobCur.IsApprovalNeeded) {
						if(JobPermissions.IsAuthorized(JobPerm.Approval,true) || JobPermissions.IsAuthorized(JobPerm.Writeup,true)) {
							actionMenu.MenuItems.Add(new MenuItem((_jobCur.UserNumExpert==0 ? "A" : "Rea")+"ssign Expert",actionMenu_AssignExpertClick) { Enabled=true });//x
						}
						if(_jobCur.UserNumExpert==Security.CurUser.UserNum ) {//only expert may re-assign
							actionMenu.MenuItems.Add(new MenuItem((_jobCur.UserNumEngineer==0?"A":"Rea")+"ssign Engineer",actionMenu_AssignEngineerClick) { Enabled=true });//x
						}
						else if(_jobCur.UserNumEngineer==0 && JobPermissions.IsAuthorized(JobPerm.Engineer,true)) {
							actionMenu.MenuItems.Add(new MenuItem("Take Job",actionMenu_TakeJobClick) { Enabled=true });//x
						}
						if(_jobCur.UserNumEngineer==Security.CurUser.UserNum) {
							actionMenu.MenuItems.Add(new MenuItem("Request Review",actionMenu_RequestReviewClick) { Enabled=true });
						}
						bool isExpert =JobPermissions.IsAuthorized(JobPerm.Writeup,true) && (_jobCur.UserNumExpert==0 || _jobCur.UserNumExpert==Security.CurUser.UserNum);
						actionMenu.MenuItems.Add(new MenuItem("Change Request",actionMenu_RequestChangeApprovalClick) { Enabled=isExpert });//delayed save, after user can make edits.
						bool isEngineer = JobPermissions.IsAuthorized(JobPerm.Engineer,true) && (_jobCur.UserNumEngineer==Security.CurUser.UserNum);
						perm=(isExpert || isEngineer) && _jobCur.UserNumEngineer>0 && _jobCur.ListJobReviews.Count>0 && _jobCur.ListJobReviews.All(x => x.ReviewStatus==JobReviewStatus.Done);
						actionMenu.MenuItems.Add(new MenuItem("Mark as Implemented",actionMenu_ImplementedClick) { Enabled=perm });//not until the engineer set, and reviews completed
					}
					else {
						perm=JobPermissions.IsAuthorized(JobPerm.Approval,true);
						actionMenu.MenuItems.Add(new MenuItem("Approve Changes",actionMenu_ApproveChangeClick) { Enabled=perm });
						actionMenu.MenuItems.Add(new MenuItem("Request Clarification",actionMenu_RequestClarificationClick) { Enabled=perm });
						actionMenu.MenuItems.Add(new MenuItem("Cancel Job",actionMenu_CancelJobClick) { Enabled=perm });
					}
					break;
				case JobPhase.Documentation:
					if(JobPermissions.IsAuthorized(JobPerm.NotifyCustomer,true) && _jobCur.DateTimeCustContact.Year<1880) {
						actionMenu.MenuItems.Add(new MenuItem("Email Attached Customers",actionMenu_EmailAttachedClick) { Enabled=true });//x
					}
					if(JobPermissions.IsAuthorized(JobPerm.Documentation,true)) {
						actionMenu.MenuItems.Add(new MenuItem((_jobCur.UserNumDocumenter==0 ? "A" : "Rea")+"ssign Documenter",actionMenu_AssignDocumenterClick) { Enabled=true });//x
					}
					perm=JobPermissions.IsAuthorized(JobPerm.Documentation,true) && (_jobCur.UserNumDocumenter==0 || _jobCur.UserNumDocumenter==Security.CurUser.UserNum);
					actionMenu.MenuItems.Add(new MenuItem("Mark as Documented",actionMenu_DocumentedClick) { Enabled=perm });
					break;
				case JobPhase.Complete:
					if(_jobCur.DateTimeCustContact.Year>1880) {
						break;//no menu items if already contacted.
					}
					perm=JobPermissions.IsAuthorized(JobPerm.NotifyCustomer,true) && (_jobCur.UserNumCustContact==0 || _jobCur.UserNumCustContact==Security.CurUser.UserNum);
					if(JobPermissions.IsAuthorized(JobPerm.NotifyCustomer,true)) {
						actionMenu.MenuItems.Add(new MenuItem((_jobCur.UserNumCustContact==0 ? "A" : "Rea")+"ssign Contacter",actionMenu_AssignContacterClick) { Enabled=true });//x
					}
					actionMenu.MenuItems.Add(new MenuItem("Email Attached Customers",actionMenu_EmailAttachedClick) { Enabled=perm });//x
					actionMenu.MenuItems.Add(new MenuItem("Mark as Contacted",actionMenu_ContactClick) { Enabled=perm });
					//Nothing to do really, except override to change something.
					break;
				case JobPhase.Cancelled:
					perm=JobPermissions.IsAuthorized(JobPerm.Approval,true);
					actionMenu.MenuItems.Add(new MenuItem("Reopen as Concept",actionMenu_ApproveConceptClick) { Enabled=perm });//x
					actionMenu.MenuItems.Add(new MenuItem("Reopen as Job",actionMenu_ApproveJobClick) { Enabled=perm });//x
					break;
				default:
					actionMenu.MenuItems.Add(new MenuItem("Unhandled status "+_jobCur.PhaseCur.ToString(),(o,ea)=> { }) { Enabled=false });
					break;
			}
			if(JobPermissions.IsAuthorized(JobPerm.Override,true)) {
				actionMenu.MenuItems.Add("-");
				actionMenu.MenuItems.Add("Override",actionMenu_OverrideClick);
			}
			if(actionMenu.MenuItems.Count>0 && actionMenu.MenuItems[0].Text=="-") {
				actionMenu.MenuItems.RemoveAt(0);
			}
			if(actionMenu.MenuItems.Count==0) {
				actionMenu.MenuItems.Add(new MenuItem("No Actions Available"){Enabled=false});
			}
			butActions.ContextMenu=actionMenu;
			butActions.ContextMenu.Show(butActions,new Point(0,butActions.Height));
		}

		///<summary>This should not implement any permissions, this should only check that the fields of the job are valid.</summary>
		/// <param name="_jobCur"></param>
		/// <returns></returns>
		private bool ValidateJob(Job _jobCur) {
			if(string.IsNullOrWhiteSpace(_jobCur.Title)) {
				MessageBox.Show("Invalid Title.");
				return false;
			}
			return true;
		}

		#region ACTION BUTTON MENU ITEMS //====================================================
		#region Bug Actions
		private void actionMenu_SendWriteupClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumExpert = _jobCur.UserNumExpert;
			if(_jobCur.UserNumExpert==0 && !PickUserByJobPermission("Pick Expert",JobPerm.Writeup,out userNumExpert,_jobCur.UserNumExpert,true,false)) {
				return;
			}
			_jobCur.UserNumExpert=userNumExpert;
			_jobCur.PhaseCur=JobPhase.Definiton;
			SaveJob(_jobCur);
		}

		private void actionMenu_SendInDevelopmentClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumExpert = _jobCur.UserNumExpert;
			long userNumEngineer = _jobCur.UserNumEngineer;
			if(_jobCur.UserNumExpert==0 && !PickUserByJobPermission("Pick Expert",JobPerm.Writeup,out userNumExpert,_jobCur.UserNumExpert>0 ? _jobCur.UserNumExpert : _jobCur.UserNumConcept,true,false)) {
				return;
			}
			if(_jobCur.UserNumEngineer==0 && !PickUserByJobPermission("Pick Engineer",JobPerm.Engineer,out userNumEngineer,_jobCur.UserNumEngineer,true,false)) {
				return;
			}
			_jobCur.UserNumExpert=userNumExpert;
			_jobCur.UserNumEngineer=userNumEngineer;
			_jobCur.PhaseCur=JobPhase.Development;
			SaveJob(_jobCur);
		}
		#endregion
		#region Assign Users
		private void actionMenu_AssignDocumenterClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumDocumenter;
			if(!PickUserByJobPermission("Pick Documenter",JobPerm.Documentation,out userNumDocumenter,_jobCur.UserNumDocumenter,true,false)) {
				return;
			}
			if(userNumDocumenter==_jobOld.UserNumDocumenter) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumDocumenter=userNumDocumenter;
			SaveJob(_jobCur);
		}

		private void actionMenu_AssignSubmitterClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumConcept;
			if(!PickUserByJobPermission("Pick Submitter",JobPerm.Concept,out userNumConcept,_jobCur.UserNumConcept,true,false)) {
				return;
			}
			if(userNumConcept==_jobOld.UserNumConcept) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumConcept=userNumConcept;
			SaveJob(_jobCur);
		}

		private void actionMenu_AssignExpertClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumExpert;
			if(!PickUserByJobPermission("Pick Expert",JobPerm.Writeup,out userNumExpert,_jobCur.UserNumExpert,true,false)) {
				return;
			}
			if(userNumExpert==_jobOld.UserNumExpert) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumExpert=userNumExpert;
			SaveJob(_jobCur);
		}

		private void actionMenu_AssignEngineerClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumEngineer;
			if(!PickUserByJobPermission("Pick Engineer",JobPerm.Engineer,out userNumEngineer,_jobCur.UserNumEngineer,true,false)) {
				return;
			}
			if(userNumEngineer==_jobOld.UserNumEngineer) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumEngineer=userNumEngineer;
			SaveJob(_jobCur);
		}

		private void actionMenu_TakeJobClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			_jobCur.UserNumEngineer=Security.CurUser.UserNum;
			SaveJob(_jobCur);
		}

		private void actionMenu_RequestReviewClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumExpert;
			if(!PickUserByJobPermission("Pick Reviewer",JobPerm.Writeup,out userNumExpert,_jobCur.UserNumExpert,true,false)) {
				return;
			}
			IsChanged=true;
			JobReview jobReview = new JobReview();
			jobReview.JobNum=_jobCur.JobNum;
			jobReview.ReviewerNum=userNumExpert;//can be zero
			jobReview.ReviewStatus=JobReviewStatus.Sent;
			_jobCur.ListJobReviews.Add(jobReview);
			SaveJob(_jobCur);
		}

		private void actionMenu_AssignContacterClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			long userNumContact;
			if(!PickUserByJobPermission("Pick Contacter",JobPerm.NotifyCustomer,out userNumContact,_jobCur.UserNumCustContact,true,false)) {
				return;
			}
			if(userNumContact==_jobOld.UserNumCustContact) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumCustContact=userNumContact;
			SaveJob(_jobCur);
		}
		#endregion
		#region Request Approval/Reviews
		private void actionMenu_RequestConceptApprovalClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			if(_jobCur.Category==JobCategory.Feature && _jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Request).Count==0) {
				MessageBox.Show("All feature requests jobs must have feature requests attached.");
				return;
			}
			IsChanged=true;
			_jobCur.UserNumConcept=Security.CurUser.UserNum;
			_jobCur.IsApprovalNeeded=true;
			SaveJob(_jobCur);
		}

		private void actionMenu_RequestJobApprovalClick(object sender,EventArgs e) {
			if(_jobCur.Category==JobCategory.Feature && _jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Request).Count==0) {
				MessageBox.Show("All feature requests jobs must have feature requests attached.");
				return;
			}
			if(!ValidateJob(_jobCur)) {
				return;
			}
			IsChanged=true;
			_jobCur.IsApprovalNeeded=true;
			SaveJob(_jobCur);
		}

		private void actionMenu_RequestChangeApprovalClick(object sender,EventArgs e) {
			IsChanged=true;
			IsChangeRequest=true;
			_jobOld.UserNumApproverChange=0;//in case it was previously set.
			_jobOld.IsApprovalNeeded=true;
			textEditorMain.ReadOnly=false;
			//Do not save here, allow edits.
		}
		#endregion
		#region Approval Options
		private void actionMenu_RequestClarificationClick(object sender,EventArgs e) {
			IsChanged=true;
			_jobCur.IsApprovalNeeded=false;
			if(_jobCur.PhaseCur==JobPhase.Development) {
				//This happens only when a change request is made. This process should be enhanced so that when an approver denies a change request, 
				//the job is reverted to its previous version, instead of requiring the Expert to manually undo the changes and get the job re-approved.
				_jobCur.PhaseCur=JobPhase.Definiton;
			}
			SaveJob(_jobCur);
		}

		private void actionMenu_ApproveConceptClick(object sender,EventArgs e) {
			long userNumExpert = _jobCur.UserNumExpert;
			if(_jobCur.UserNumExpert==0 && !PickUserByJobPermission("Pick Expert",JobPerm.Writeup,out userNumExpert,_jobCur.UserNumConcept,true,false)) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumExpert=userNumExpert;
			_jobCur.IsApprovalNeeded=false;
			_jobCur.UserNumApproverConcept=Security.CurUser.UserNum;
			_jobCur.UserNumApproverJob=0;//in case it was previously set.
			_jobCur.UserNumApproverChange=0;//in case it was previously set.
			_jobCur.PhaseCur=JobPhase.Definiton;
			SaveJob(_jobCur);
		}

		private void actionMenu_ApproveJobClick(object sender,EventArgs e) {
			long userNumExpert = _jobCur.UserNumExpert;
			long userNumEngineer = _jobCur.UserNumEngineer;
			if(_jobCur.UserNumExpert==0 && !PickUserByJobPermission("Pick Expert",JobPerm.Writeup,out userNumExpert,_jobCur.UserNumConcept,true,false)) {
				return;
			}
			if(_jobCur.UserNumEngineer==0 && !PickUserByJobPermission("Pick Engineer",JobPerm.Engineer,out userNumEngineer,userNumExpert,true,false)) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumExpert=userNumExpert;
			_jobCur.UserNumEngineer=userNumEngineer;
			_jobCur.IsApprovalNeeded=false;
			_jobCur.UserNumApproverJob=Security.CurUser.UserNum;
			_jobCur.UserNumApproverChange=0;//in case it was previously set.
			_jobCur.PhaseCur=JobPhase.Development;
			SaveJob(_jobCur);
		}

		private void actionMenu_ApproveChangeClick(object sender,EventArgs e) {
			long userNumExpert = _jobCur.UserNumExpert;
			long userNumEngineer = _jobCur.UserNumEngineer;
			if(_jobCur.UserNumExpert==0 && !PickUserByJobPermission("Pick Expert",JobPerm.Writeup,out userNumExpert,_jobCur.UserNumConcept,true,false)) {
				return;
			}
			if(_jobCur.UserNumEngineer==0 && !PickUserByJobPermission("Pick Engineer",JobPerm.Engineer,out userNumEngineer,userNumExpert,true,false)) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumExpert=userNumExpert;
			_jobCur.UserNumEngineer=userNumEngineer;
			_jobCur.IsApprovalNeeded=false;
			_jobCur.UserNumApproverChange=Security.CurUser.UserNum;
			_jobCur.PhaseCur=JobPhase.Development;
			SaveJob(_jobCur);
		}

		private void actionMenu_CancelJobClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			IsChanged=true;
			_jobCur.UserNumInfo=0;
			_jobCur.IsApprovalNeeded=false;
			_jobCur.PhaseCur=JobPhase.Cancelled;
			SaveJob(_jobCur);
		}
		#endregion

		private void actionMenu_EmailAttachedClick(object sender,EventArgs e) {
			FormEmailJobs FormEJ = new FormEmailJobs();
			FormEJ.JobCur=_jobCur.Copy();
			FormEJ.ShowDialog();
			if(FormEJ.DialogResult!=DialogResult.OK) {
				return;
			}
			_jobCur.DateTimeCustContact=MiscData.GetNowDateTime();
			_jobCur.UserNumCustContact=Security.CurUser.UserNum;
			_jobOld.DateTimeCustContact=MiscData.GetNowDateTime();
			_jobOld.UserNumCustContact=Security.CurUser.UserNum;
			if(!IsNew) {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.DateTimeCustContact=MiscData.GetNowDateTime();
				job.UserNumCustContact=Security.CurUser.UserNum;
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			SaveJob(_jobCur);
		}

		private void actionMenu_ImplementedClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			if(string.IsNullOrEmpty(_jobCur.JobVersion)) {
				InputBox inBox = new InputBox("Version cannot be left blank.\r\ne.g. \"N/A\" or 16.1.4;15.4.30");
				inBox.ShowDialog();
				if(inBox.DialogResult!=DialogResult.OK || string.IsNullOrEmpty(inBox.textResult.Text)) {
					return;
				}
				_jobCur.JobVersion=inBox.textResult.Text;
			}
			IsChanged=true;
			_jobCur.PhaseCur=JobPhase.Documentation;
			SaveJob(_jobCur);
		}

		private void actionMenu_DocumentedClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			IsChanged=true;
			_jobCur.PhaseCur=JobPhase.Complete;
			if(_jobCur.UserNumDocumenter==0) {
				_jobCur.UserNumDocumenter=Security.CurUser.UserNum;
			}
			SaveJob(_jobCur);
		}

		private void actionMenu_ContactClick(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			IsChanged=true;
			if(_jobCur.UserNumCustContact==0) {
				_jobCur.UserNumCustContact=Security.CurUser.UserNum;
			}
			_jobCur.DateTimeCustContact=MiscData.GetNowDateTime();
			SaveJob(_jobCur);
		}

		private void actionMenu_OverrideClick(object sender,EventArgs e) {
			IsOverride=true;
		}

		#endregion ACTION BUTTON MENU ITEMS //=================================================

		///<summary>If returns false if selection is cancelled. DefaultUserNum is usually the currently set usernum for a given role.</summary>
		private bool PickUserByJobPermission(string prompt, JobPerm jobPerm,out long selectedNum, long suggestedUserNum = 0,bool AllowNone = true,bool AllowAll = true) {
			selectedNum=0;
			List<Userod> listUsersForPicker = Userods.GetUsersByJobRole(jobPerm,false);
			FormUserPick FormUP = new FormUserPick();
			FormUP.Text=prompt;
			FormUP.IsSelectionmode=true;
			FormUP.ListUserodsFiltered=listUsersForPicker;
			FormUP.SuggestedUserNum=suggestedUserNum;
			FormUP.IsPickNoneAllowed=AllowNone;
			FormUP.IsShowAllAllowed=AllowAll;
			if(FormUP.ShowDialog()!=DialogResult.OK) {
				return false;
			}
			selectedNum=FormUP.SelectedUserNum;
			return true;
		}

		///<summary>When editing a job, and the job has been changed, this loads changes into the current control.</summary>
		public void LoadMergeJob(Job newJob) {
			_isLoading=true;
			Job jobMerge = newJob.Copy();//otherwise changes would be made to the tree view.
			//Set _jobCur lists to the new lists made above.
			_jobCur.ListJobLinks  =jobMerge.ListJobLinks;
			_jobCur.ListJobNotes  =jobMerge.ListJobNotes;
			_jobCur.ListJobQuotes =jobMerge.ListJobQuotes;
			_jobCur.ListJobReviews=jobMerge.ListJobReviews;
			_jobCur.ListJobEvents =jobMerge.ListJobEvents;
			//Update Old lists too
			_jobOld.ListJobLinks  =jobMerge.ListJobLinks.Select(x=>x.Copy()).ToList();
			_jobOld.ListJobNotes  =jobMerge.ListJobNotes.Select(x => x.Copy()).ToList();
			_jobOld.ListJobQuotes =jobMerge.ListJobQuotes.Select(x => x.Copy()).ToList();
			_jobOld.ListJobReviews=jobMerge.ListJobReviews.Select(x => x.Copy()).ToList();
			_jobOld.ListJobEvents =jobMerge.ListJobEvents.Select(x => x.Copy()).ToList();
			//JOB ROLE USER NUMS
			_jobCur.UserNumApproverChange=jobMerge.UserNumApproverChange;
			_jobCur.UserNumApproverConcept=jobMerge.UserNumApproverConcept;
			_jobCur.UserNumApproverJob=jobMerge.UserNumApproverJob;
			_jobCur.UserNumCheckout=jobMerge.UserNumCheckout;
			_jobCur.UserNumConcept=jobMerge.UserNumConcept;
			_jobCur.UserNumDocumenter=jobMerge.UserNumDocumenter;
			_jobCur.UserNumCustContact=jobMerge.UserNumCustContact;
			_jobCur.UserNumEngineer=jobMerge.UserNumEngineer;
			_jobCur.UserNumExpert=jobMerge.UserNumExpert;
			_jobCur.UserNumInfo=jobMerge.UserNumInfo;
			//old
			_jobOld.UserNumApproverChange=jobMerge.UserNumApproverChange;
			_jobOld.UserNumApproverConcept=jobMerge.UserNumApproverConcept;
			_jobOld.UserNumApproverJob=jobMerge.UserNumApproverJob;
			_jobOld.UserNumCheckout=jobMerge.UserNumCheckout;
			_jobOld.UserNumConcept=jobMerge.UserNumConcept;
			_jobOld.UserNumDocumenter=jobMerge.UserNumDocumenter;
			_jobOld.UserNumCustContact=jobMerge.UserNumCustContact;
			_jobOld.UserNumEngineer=jobMerge.UserNumEngineer;
			_jobOld.UserNumExpert=jobMerge.UserNumExpert;
			_jobOld.UserNumInfo=jobMerge.UserNumInfo;
			FillAllGrids();
			//All changes below this point will be lost if there is a conflicting chage detected.
			//TITLE
			if(_jobCur.Title!=jobMerge.Title) {
				if(_jobCur.Title==_jobOld.Title) {//Was edited, AND user has not already edited it themselves.
					_jobCur.Title=jobMerge.Title;
					_jobOld.Title=jobMerge.Title;
					textTitle.Text=_jobCur.Title;
				}
				else {
					MessageBox.Show("Job Title has been changed to:\r\n"+jobMerge.Title);
				}
			}
			//DESCRIPTION
			if(_jobCur.Description!=jobMerge.Description) {
				if(textEditorMain.MainRtf==_jobOld.Description) {//Was edited, AND user has not already edited it themselves.
					_jobCur.Description=jobMerge.Description;
					_jobOld.Description=jobMerge.Description;
					try {
						textEditorMain.MainRtf=_jobCur.Description;
					}
					catch {
						textEditorMain.MainText=_jobCur.Description;
					}
				}
				else {
					MessageBox.Show("Job Description has been changed.");
				}
			}
			//DOCUMENTATION
			if(_jobCur.Documentation!=jobMerge.Documentation) {
				if(textEditorDocumentation.MainRtf==_jobOld.Documentation || string.IsNullOrWhiteSpace(_jobOld.Documentation)) {//Was edited, AND user has not already edited it themselves.
					_jobCur.Documentation=jobMerge.Documentation;
					_jobOld.Documentation=jobMerge.Documentation;
					try {
						textEditorDocumentation.MainRtf=_jobCur.Documentation;
					}
					catch {
						textEditorDocumentation.MainText=_jobCur.Documentation;
					}
				}
				else {
					MessageBox.Show("Job Documentation has been changed.");//possibly implement locking the documentation pane.
				}
			}
			//PRIORITY
			if(_jobCur.Priority!=jobMerge.Priority) {
				_jobCur.Priority=jobMerge.Priority;
				_jobOld.Priority=jobMerge.Priority;
				comboPriority.SelectedIndex=(int)_jobCur.Priority;
			}
			//STATUS
			if(_jobCur.PhaseCur!=jobMerge.PhaseCur) {
				_jobCur.PhaseCur=jobMerge.PhaseCur;
				_jobOld.PhaseCur=jobMerge.PhaseCur;
				comboStatus.SelectedIndex=(int)_jobCur.Priority;
			}
			//APPROVAL STATUS
			if(_jobCur.IsApprovalNeeded!=jobMerge.IsApprovalNeeded) {
				_jobCur.IsApprovalNeeded=jobMerge.IsApprovalNeeded;
				_jobOld.IsApprovalNeeded=jobMerge.IsApprovalNeeded;
				if(_jobCur.IsApprovalNeeded) {
					textApprove.Text="Waiting";
				}
				else if(_jobCur.UserNumApproverConcept>0 ||_jobCur.UserNumApproverJob>0||_jobCur.UserNumApproverChange>0) {
					textApprove.Text="Yes";
				}
				else {
					textApprove.Text="No";
				}
			}
			//CATEGORY
			if(_jobCur.Category!=jobMerge.Category) {//Was edited, AND user has not already edited it themselves.
				_jobCur.Category=jobMerge.Category;
				_jobOld.Category=jobMerge.Category;
				comboCategory.SelectedIndex=(int)_jobCur.Category;
			}
			//DATEENTRY - Cannot change
			//VERSION
			if(_jobCur.JobVersion!=jobMerge.JobVersion && _jobCur.JobVersion==_jobOld.JobVersion) {//Was edited, AND user has not already edited it themselves.
				_jobCur.JobVersion=jobMerge.JobVersion;
				_jobOld.JobVersion=jobMerge.JobVersion;
				textVersion.Text=_jobCur.JobVersion;
			}
			//HOURS EST
			if(_jobCur.HoursEstimate!=jobMerge.HoursEstimate && _jobCur.HoursEstimate==_jobOld.HoursEstimate) {//Was edited, AND user has not already edited it themselves.
				_jobCur.HoursEstimate=jobMerge.HoursEstimate;
				_jobOld.HoursEstimate=jobMerge.HoursEstimate;
				textEstHours.Text=_jobCur.HoursEstimate.ToString();
			}
			//HOURS ACT
			if(_jobCur.HoursActual!=jobMerge.HoursActual && _jobCur.HoursActual==_jobOld.HoursActual) {//Was edited, AND user has not already edited it themselves.
				_jobCur.HoursActual=jobMerge.HoursActual;
				_jobOld.HoursActual=jobMerge.HoursActual;
				textActualHours.Text=_jobCur.HoursActual.ToString();
			}
			//PARENT
			if(_jobCur.ParentNum!=jobMerge.ParentNum && _jobCur.JobNum==_jobOld.JobNum) {//Parent was edited, AND user has not already edited the parent themselves.
				_jobCur.JobNum=jobMerge.JobNum;
				_jobOld.JobNum=jobMerge.JobNum;
				if(jobMerge.ParentNum==0) {
					textParent.Text="";
				}
				else {
					textParent.Text=Jobs.GetOne(jobMerge.ParentNum).ToString();
				}
			}
			_isLoading=false;
			CheckPermissions();
		}

		private void butParentRemove_Click(object sender,EventArgs e) {
			IsChanged=true;
			_jobCur.ParentNum=0;
			textParent.Text="";
			//todoSave
		}

		private void butParentPick_Click(object sender,EventArgs e) {
			InputBox inBox=new InputBox("Input parent job number.");
			inBox.ShowDialog();
			if(inBox.DialogResult!=DialogResult.OK) {
				return;
			}
			long jobNum=0;
			long.TryParse(new string(inBox.textResult.Text.Where(char.IsDigit).ToArray()),out jobNum);
			Job job=Jobs.GetOne(jobNum);
			if(job==null) {
				return;
			}
			if(Jobs.CheckForLoop(_jobCur.JobNum,jobNum)) {
				MsgBox.Show(this,"Invalid parent job, would create an infinite loop.");
				return;
			}
			IsChanged=true;
			_jobCur.ParentNum=job.JobNum;
			textParent.Text=job.ToString();
			//TOdo: save
		}

		private void butSave_Click(object sender,EventArgs e) {
			if(!ValidateJob(_jobCur)) {
				return;
			}
			if(_jobCur.PhaseCur==JobPhase.Concept && _jobCur.UserNumConcept==0 && !_jobCur.IsApprovalNeeded && JobPermissions.IsAuthorized(JobPerm.Concept,true)) {
				_jobCur.UserNumConcept=Security.CurUser.UserNum;
			}
			SaveJob(_jobCur);
		}

		///<summary>Job must have all in memory fields filled. Eg. Job.ListJobLinks, Job.ListJobNotes, etc.</summary>
		private void SaveJob(Job job) {
			_isLoading=true;
			//Validation must happen before this is called.
			job.Description=textEditorMain.MainRtf;
			job.HoursActual=PIn.Int(textActualHours.Text);
			job.HoursEstimate=PIn.Int(textEstHours.Text);
			if(IsChangeRequest) {
				job.IsApprovalNeeded=true;
			}
			//job.Priority=(JobPriority)comboPriority.SelectedIndex;
			//job.JobStatus=(JobStat)comboStatus.SelectedIndex;
			//job.Category=(JobCategory)comboCategory.SelectedIndex;
			//All other fields should have been maintained while editing the job in the form.
			job.UserNumCheckout=0;
			if(job.JobNum==0 || IsNew) {
				if(job.UserNumConcept==0 && JobPermissions.IsAuthorized(JobPerm.Concept,true)) {
					job.UserNumConcept=Security.CurUser.UserNum;
				}
				Jobs.Insert(job);
				job.ListJobLinks.ForEach(x=>x.JobNum=job.JobNum);
				job.ListJobNotes.ForEach(x=>x.JobNum=job.JobNum);
				job.ListJobReviews.ForEach(x=>x.JobNum=job.JobNum);
				job.ListJobQuotes.ForEach(x=>x.JobNum=job.JobNum);
				//job.ListJobEvents.ForEach(x=>x.JobNum=job.JobNum);//do not sync
			}
			else {
				Jobs.Update(job);
			}
			JobLinks.Sync(job.ListJobLinks,job.JobNum);
			JobNotes.Sync(job.ListJobNotes,job.JobNum);
			JobReviews.Sync(job.ListJobReviews,job.JobNum);
			JobQuotes.Sync(job.ListJobQuotes,job.JobNum);
			//JobEvents.Sync();//do not sync
			if(job.UserNumEngineer!=_jobOld.UserNumEngineer || job.PhaseCur!=_jobOld.PhaseCur || job.Description!=_jobOld.Description) {
				JobEvent jobEventCur=new JobEvent();
				//Must do text manipulation inside the RichTextbox to preserve RTF Formatting.
				try {
					textEditorMain.MainRtf=_jobOld.Description;
				}
				catch {
					textEditorMain.MainText=_jobOld.Description;
				}
				if(_isOverride) {
					textEditorMain.MainText=textEditorMain.MainText.Insert(0,"THIS JOB WAS MANUALLY OVERRIDDEN BY "+Security.CurUser.UserName+":\r\n");
				}
				jobEventCur.Description=textEditorMain.MainRtf;
				jobEventCur.JobNum=_jobOld.JobNum;
				jobEventCur.JobStatus=_jobOld.PhaseCur;
				jobEventCur.UserNumEvent=Security.CurUser.UserNum;
				JobEvents.Insert(jobEventCur);
				job.ListJobEvents.Add(JobEvents.GetOne(jobEventCur.JobEventNum));//to get correct time stamp
			}
			Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,job.JobNum);
			LoadJob(job);
			if(SaveClick!=null) {
				SaveClick(this,new EventArgs());
			}
			_isLoading=false;
		}

		//Allows save to be called from outside this control.
		public void ForceSave() {
			if(_jobCur==null || IsChanged==false) {
				return;
			}
			if(!ValidateJob(_jobCur)) {
				return;
			}
			SaveJob(_jobCur);
		}

		private void comboPriority_SelectionChangeCommitted(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			_jobCur.Priority=(JobPriority)comboPriority.SelectedIndex;
			_jobOld.Priority=(JobPriority)comboPriority.SelectedIndex;
			if(!IsNew) {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.Priority=(JobPriority)comboPriority.SelectedIndex;
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
		}

		private void comboStatus_SelectionChangeCommitted(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			//This should normally never get hit. Status changes should almost exclusively happen due to Job Actions.
			_jobCur.PhaseCur=(JobPhase)comboStatus.SelectedIndex;
			_jobOld.PhaseCur=(JobPhase)comboStatus.SelectedIndex;
			if(!IsNew) {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.PhaseCur=(JobPhase)comboStatus.SelectedIndex;
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
		}

		private void comboCategory_SelectionChangeCommitted(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			_jobCur.Category=(JobCategory)comboCategory.SelectedIndex;
			_jobOld.Category=(JobCategory)comboCategory.SelectedIndex;
			if(!IsNew) {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.Category=(JobCategory)comboCategory.SelectedIndex;
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
		}

		private void gridWatchers_TitleAddClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(_jobCur==null) {
				return;//should never happen
			}
			FormUserPick FormUP = new FormUserPick();
			//Suggest current user if not already watching.
			if(_jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Watcher).All(x => x.FKey!=Security.CurUser.UserNum)) {
				FormUP.SuggestedUserNum=Security.CurUser.UserNum;
			}
			FormUP.IsSelectionmode=true;
			FormUP.ShowDialog();
			if(FormUP.DialogResult!=DialogResult.OK) {
				return;
			}
			JobLink jobLink = new JobLink() {
				FKey=FormUP.SelectedUserNum,
				JobNum=_jobCur.JobNum,
				LinkType=JobLinkType.Watcher
			};
			if(!IsNew) {
				JobLinks.Insert(jobLink);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobLinks.Add(jobLink);
			FillGridWatchers();
		}

		private void gridCustomerQuotes_TitleAddClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(_jobCur==null) {
				return;//should never happen
			}
			FormJobQuoteEdit FormJQE=new FormJobQuoteEdit(new JobQuote() {JobNum=_jobCur.JobNum,IsNew=true});
			FormJQE.ShowDialog();
			if(FormJQE.DialogResult!=DialogResult.OK || FormJQE.JobQuoteCur==null) {
				return;
			}
			if(!IsNew) {
				JobQuotes.Insert(FormJQE.JobQuoteCur);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobQuotes.Add(FormJQE.JobQuoteCur);
			FillGridCustQuote();
		}

		private void gridTasks_TitleAddClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(_jobCur==null) {
				return;//should never happen
			}
			FormTaskSearch FormTS=new FormTaskSearch() {IsSelectionMode=true};
			FormTS.ShowDialog();
			if(FormTS.DialogResult!=DialogResult.OK) {
				return;
			}
			JobLink jobLink=new JobLink();
			jobLink.JobNum=_jobCur.JobNum;
			jobLink.FKey=FormTS.SelectedTaskNum;
			jobLink.LinkType=JobLinkType.Task;
			if(!IsNew) {
				JobLinks.Insert(jobLink);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobLinks.Add(jobLink);
			FillGridTasks();
		}

		private void gridFeatureReq_TitleAddClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(_jobCur==null) {
				return;//should never happen
			}
			FormFeatureRequest FormFR=new FormFeatureRequest() {IsSelectionMode=true};
			FormFR.ShowDialog();
			if(FormFR.DialogResult!=DialogResult.OK) {
				return;
			}
			JobLink jobLink=new JobLink();
			jobLink.JobNum=_jobCur.JobNum;
			jobLink.FKey=FormFR.SelectedFeatureNum;
			jobLink.LinkType=JobLinkType.Request;
			if(!IsNew) {
				JobLinks.Insert(jobLink);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobLinks.Add(jobLink);
			FillGridFeatuerReq();
		}

		private void gridBugs_TitleAddClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(_jobCur==null) {
				return;//should never happen
			}
			FormBugSearch FormBS=new FormBugSearch();
			FormBS.ShowDialog();
			if(FormBS.DialogResult!=DialogResult.OK || FormBS.BugCur==null) {
				return;
			}
			JobLink jobLink=new JobLink();
			jobLink.JobNum=_jobCur.JobNum;
			jobLink.FKey=FormBS.BugCur.BugId;
			jobLink.LinkType=JobLinkType.Bug;
			if(!IsNew) {
				JobLinks.Insert(jobLink);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobLinks.Add(jobLink);
			FillGridBugs();
		}

		private void gridReview_TitleAddClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(_jobCur==null) {
				return;//should never happen
			}
			long userNumReviewer=0;
			if(!PickUserByJobPermission("Pick Reviewer",JobPerm.Writeup,out userNumReviewer,_jobCur.UserNumExpert,true,false)) {
				return;
			}
			FormJobReviewEdit FormJRE=new FormJobReviewEdit(new JobReview { ReviewerNum=userNumReviewer,JobNum=_jobCur.JobNum,IsNew=true });
			FormJRE.ShowDialog();
			if(FormJRE.DialogResult!=DialogResult.OK || FormJRE.JobReviewCur==null) {
				return;
			}
			if(!IsNew) {
				JobReviews.Insert(FormJRE.JobReviewCur);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobReviews.Add(FormJRE.JobReviewCur);
			FillGridReviews();
		}

		private void gridNotes_TitleAddClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(_jobCur==null) {
				return;//should never happen
			}
			JobNote jobNote=new JobNote() {
				DateTimeNote=MiscData.GetNowDateTime(),
				IsNew=true,
				JobNum=_jobCur.JobNum,
				UserNum=Security.CurUser.UserNum
			};
			FormJobNoteEdit FormJNE=new FormJobNoteEdit(jobNote);
			FormJNE.ShowDialog();
			if(FormJNE.DialogResult!=DialogResult.OK || FormJNE.JobNoteCur==null) {
				return;
			}
			if(!IsNew) {
				JobNotes.Insert(FormJNE.JobNoteCur);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobNotes.Add(FormJNE.JobNoteCur);
			FillGridNote();
		}

		private void gridCustomerQuotes_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			if(!(gridCustomerQuotes.Rows[e.Row].Tag is JobQuote)) {
				return;//should never happen
			}
			JobQuote jq = (JobQuote)gridCustomerQuotes.Rows[e.Row].Tag;
			FormJobQuoteEdit FormJQE = new FormJobQuoteEdit(jq);
			FormJQE.ShowDialog();
			if(FormJQE.DialogResult!=DialogResult.OK) {
				return;
			}
			if(!IsNew) {
				if(FormJQE.JobQuoteCur==null) {
					JobQuotes.Delete(jq.JobQuoteNum);
				}
				else {
					JobQuotes.Update(FormJQE.JobQuoteCur);
				}
			}
			else {
				IsChanged=true;
			}
			_jobCur.ListJobQuotes.RemoveAll(x=>x.JobQuoteNum==jq.JobQuoteNum);//should remove only one
			if(FormJQE.JobQuoteCur!=null) {//re-add altered version, iff the jobquote was modified.
				_jobCur.ListJobQuotes.Add(FormJQE.JobQuoteCur);
			}
			FillGridCustQuote();
		}

		private void gridTasks_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			if(!(gridTasks.Rows[e.Row].Tag is long)) {
				return;//should never happen
			}
			//GoTo patietn will not work from this form. It would require a delegate to be passed in all the way from FormOpenDental.
			Task task=Tasks.GetOne((long)gridTasks.Rows[e.Row].Tag);
			FormTaskEdit FormTE=new FormTaskEdit(task,task.Copy());
			FormTE.ShowDialog();
			if(FormTE.DialogResult!=DialogResult.OK) {
				return;
			}
			FillGridTasks();
		}
		
		private void textTitle_TextChanged(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(IsNew) {
				_jobCur.Title=textTitle.Text;
				_jobOld.Title=textTitle.Text;
				return;
			}
			textTitle.BackColor=Color.FromArgb(255,255,230);//light yellow
			timerTitle.Stop();
			timerTitle.Start();
		}

		private void timerTitle_Tick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			timerTitle.Stop();
			if(string.IsNullOrWhiteSpace(textTitle.Text)) {
				textTitle.BackColor=Color.FromArgb(254,235,233);//light red
				return;
			}
			textTitle.BackColor=Color.White;
			_jobCur.Title=textTitle.Text;
			_jobOld.Title=textTitle.Text;
			if(IsNew) {
				IsChanged=true;
			}
			else {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.Title=textTitle.Text;
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,job.JobNum);
			}
		}

		private void textVersion_TextChanged(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			if(IsNew) {
				_jobCur.JobVersion=textVersion.Text;
				_jobOld.JobVersion=textVersion.Text;
				return;
			}
			textVersion.BackColor=Color.FromArgb(255,255,230);//light yellow
			timerVersion.Stop();
			timerVersion.Start();
		}

		private void timerVersion_Tick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			timerVersion.Stop();
			textVersion.BackColor=Color.White;
			_jobCur.Title=textVersion.Text;
			_jobOld.Title=textVersion.Text;
			if(IsNew) {
				IsChanged=true;
			}
			else {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.JobVersion=textVersion.Text;
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,job.JobNum);
			}
		}

		private void textEditorMain_SaveClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			_jobCur.Description=textEditorMain.MainRtf;
			_jobOld.Description=textEditorMain.MainRtf;
			_jobCur.UserNumCheckout=0;
			_jobOld.UserNumCheckout=0;
			if(IsNew) {
				IsChanged=true;
			}
			else {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.Description=textEditorMain.MainRtf;
				if(IsChangeRequest) {
					job.IsApprovalNeeded=true;
				}
				job.UserNumCheckout=0;
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,job.JobNum);
			}
		}

		private void textEditorDocumentation_SaveClick(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			_jobCur.Documentation=textEditorDocumentation.MainRtf;
			_jobOld.Documentation=textEditorDocumentation.MainRtf;
			if(IsNew) {
				IsChanged=true;
			}
			else {
				Job job = Jobs.GetOne(_jobCur.JobNum);
				job.Documentation=textEditorDocumentation.MainRtf;
				job.IsApprovalNeeded=_jobCur.IsApprovalNeeded;//needed for change requests.
				Jobs.Update(job);
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,job.JobNum);
			}
		}

		private void textEditorMain_OnTextEdited() {
			if(_isLoading) {
				return;
			}
			IsChanged=true;
			if(IsNew) {
				//do nothing
			}
			else {
				if(!_isLoading && _jobCur.UserNumCheckout==0) {
					_jobCur.UserNumCheckout=Security.CurUser.UserNum;
					Job jobFromDB = Jobs.GetOne(_jobCur.JobNum);//Get from DB to ensure freshest copy (Lists not filled)
					jobFromDB.UserNumCheckout=Security.CurUser.UserNum;//change only the userNumCheckout.
					Jobs.Update(jobFromDB);//update the checkout num.
					Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);//send signal that the job has been checked out.
				}
			}
		}

		private void textEstHours_TextChanged(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			int.TryParse(textEstHours.Text,out _jobCur.HoursEstimate);
			int.TryParse(textEstHours.Text,out _jobOld.HoursEstimate);
			if(IsNew) {
				IsChanged=true;
			}
			else {
				Job jobFromDB = Jobs.GetOne(_jobCur.JobNum);//Get from DB to ensure freshest copy (Lists not filled)
				int.TryParse(textEstHours.Text,out jobFromDB.HoursEstimate);
				Jobs.Update(jobFromDB);//update the checkout num.
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);//send signal that the job has been checked out.
			}
		}

		private void textActualHours_TextChanged(object sender,EventArgs e) {
			if(_isLoading) {
				return;
			}
			int.TryParse(textActualHours.Text,out _jobCur.HoursActual);
			int.TryParse(textActualHours.Text,out _jobOld.HoursActual);
			if(IsNew) {
				IsChanged=true;
			}
			else {
				Job jobFromDB = Jobs.GetOne(_jobCur.JobNum);//Get from DB to ensure freshest copy (Lists not filled)
				int.TryParse(textActualHours.Text,out jobFromDB.HoursActual);
				Jobs.Update(jobFromDB);//update the checkout num.
				Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);//send signal that the job has been checked out.
			}
		}

		private void gridFeatureReq_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			if(!(gridFeatureReq.Rows[e.Row].Tag is long)) {
				return;//should never happen.
			}
			FormRequestEdit FormFR=new FormRequestEdit();
			FormFR.RequestId=(long)gridFeatureReq.Rows[e.Row].Tag;
			FormFR.IsAdminMode=PrefC.IsODHQ;
			FormFR.ShowDialog();
		}

		private void gridHistory_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			FormJobHistoryView FormJHV=new FormJobHistoryView((long)gridHistory.Rows[e.Row].Tag);
			FormJHV.ShowDialog();
		}

		private void gridNotes_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			if(_isLoading) {
				return;
			}
			if(!(gridNotes.Rows[e.Row].Tag is JobNote)) {
				return;//should never happen.
			}
			JobNote jobNote = (JobNote)gridNotes.Rows[e.Row].Tag;
			FormJobNoteEdit FormJNE = new FormJobNoteEdit(jobNote);
			FormJNE.ShowDialog();
			if(FormJNE.DialogResult!=DialogResult.OK) {
				return;
			}
			if(IsNew) {
				IsChanged=true;
			}
			else {
				if(FormJNE.JobNoteCur==null) {
					JobNotes.Delete(jobNote.JobNoteNum);
				}
				else {
					JobNotes.Update(FormJNE.JobNoteCur);
				}
			}
			_jobCur.ListJobNotes.RemoveAt(e.Row);// (x => x.JobNoteNum==jobNote.JobNoteNum);//should remove only one
			if(FormJNE.JobNoteCur!=null) {
				_jobCur.ListJobNotes.Add(FormJNE.JobNoteCur);
			}
			FillGridNote();
		}

		private void gridReview_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			if(_isLoading) {
				return;
			}
			if(!(gridReview.Rows[e.Row].Tag is JobReview)) {
				return;//should never happen.
			}
			JobReview jobReview=(JobReview)gridReview.Rows[e.Row].Tag;
			FormJobReviewEdit FormJRE=new FormJobReviewEdit(jobReview);
			FormJRE.ShowDialog();
			if(FormJRE.DialogResult!=DialogResult.OK) {
				return;
			}
			if(IsNew) {
				IsChanged=true;
			}
			else {
				if(FormJRE.JobReviewCur==null) {
					JobReviews.Delete(jobReview.JobReviewNum);
				}
				else {
					JobReviews.Update(FormJRE.JobReviewCur);
				}
			}
			_jobCur.ListJobReviews.RemoveAt(e.Row);
			_jobOld.ListJobReviews.RemoveAt(e.Row);
			if(FormJRE.JobReviewCur!=null) {
				_jobCur.ListJobReviews.Add(FormJRE.JobReviewCur);
				_jobOld.ListJobReviews.Add(FormJRE.JobReviewCur);
			}
			FillGridReviews();
			Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
		}

		private void gridWatchers_CellClick(object sender,ODGridClickEventArgs e) {
			if(_isLoading) {
				return;
			}
			if(e.Button==MouseButtons.Right && (gridWatchers.Rows[e.Row].Tag is Userod)) {
				ContextMenu menu=new ContextMenu();
				long FKey = ((Userod)gridWatchers.Rows[e.Row].Tag).UserNum;
				menu.MenuItems.Add("Remove "+((Userod)gridWatchers.Rows[e.Row].Tag).UserName,(o,arg) => {
					List<JobLink> listLinks=_jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Watcher&&x.FKey==FKey);//almost always only 1
					_jobCur.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Watcher&&x.FKey==FKey);
					_jobOld.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Watcher&&x.FKey==FKey);
					listLinks.Select(x=>x.JobLinkNum).ToList().ForEach(JobLinks.Delete);
					FillGridWatchers();
					Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
				});
				menu.Show(gridWatchers,gridWatchers.PointToClient(Cursor.Position));
			}
		}

		private void gridTasks_CellClick(object sender,ODGridClickEventArgs e) {
			if(_isLoading) {
				return;
			}
			if(e.Button==MouseButtons.Right && (gridTasks.Rows[e.Row].Tag is long)) {
				ContextMenu menu = new ContextMenu();
				long FKey = (long)gridTasks.Rows[e.Row].Tag;
				menu.MenuItems.Add("Unlink Task",(o,arg) => {
					List<JobLink> listLinks = _jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Task&&x.FKey==FKey);
					_jobCur.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Task&&x.FKey==FKey);
					_jobOld.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Task&&x.FKey==FKey);
					listLinks.Select(x => x.JobLinkNum).ToList().ForEach(JobLinks.Delete);
					FillGridTasks();
					Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
				});
				menu.MenuItems.Add(new MenuItem(Tasks.GetOne(FKey).Descript.Left(50)){ Enabled=false });
				menu.Show(gridTasks,gridTasks.PointToClient(Cursor.Position));
			}
		}

		private void gridFeatureReq_CellClick(object sender,ODGridClickEventArgs e) {
			if(_isLoading) {
				return;
			}
			if(e.Button==MouseButtons.Right && (gridFeatureReq.Rows[e.Row].Tag is long)) {
				ContextMenu menu = new ContextMenu();
				long FKey = (long)gridFeatureReq.Rows[e.Row].Tag;
				menu.MenuItems.Add("Unlink Feature : "+FKey.ToString(),(o,arg) => {
					List<JobLink> listLinks = _jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Request&&x.FKey==FKey);
					_jobCur.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Request&&x.FKey==FKey);
					_jobOld.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Request&&x.FKey==FKey);
					listLinks.Select(x => x.JobLinkNum).ToList().ForEach(JobLinks.Delete);
					FillGridFeatuerReq();
					Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
				});
				menu.Show(gridFeatureReq,gridFeatureReq.PointToClient(Cursor.Position));
			}
		}

		private void gridBugs_CellClick(object sender,ODGridClickEventArgs e) {
			if(_isLoading) {
				return;
			}
			if(e.Button==MouseButtons.Right && (gridBugs.Rows[e.Row].Tag is long)) {
				ContextMenu menu = new ContextMenu();
				long FKey = (long)gridBugs.Rows[e.Row].Tag;
				menu.MenuItems.Add("Unlink Bug",(o,arg) => {
					List<JobLink> listLinks = _jobCur.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Bug&&x.FKey==FKey);
					_jobCur.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Bug&&x.FKey==FKey);
					_jobOld.ListJobLinks.RemoveAll(x => x.LinkType==JobLinkType.Bug&&x.FKey==FKey);
					listLinks.Select(x => x.JobLinkNum).ToList().ForEach(JobLinks.Delete);
					FillGridBugs();
					Signalods.SetInvalid(InvalidType.Jobs,KeyType.Job,_jobCur.JobNum);
				});
				menu.MenuItems.Add(new MenuItem(Bugs.GetOne(FKey).Description.Left(50)) { Enabled=false });
				menu.Show(gridFeatureReq,gridFeatureReq.PointToClient(Cursor.Position));
			}
		}
	}//end class

}//end namespace
	

