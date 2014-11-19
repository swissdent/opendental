using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OpenDentBusiness;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenDental.ReportingComplex {
	/// <summary>This class is loosely modeled after CrystalReports.ReportDocument, but with less inheritence and heirarchy.</summary>
	public class ReportComplex {
		private SectionCollection _sections=new SectionCollection();
		private ReportObjectCollection _reportObjects=new ReportObjectCollection();
		private ParameterFieldCollection _parameterFields=new ParameterFieldCollection();
		private bool _isLandscape;
		private bool _hasGridLines;
		private bool _hasReportSummary;
		private string _reportName;
		private string _description;
		private string _authorID;
		private int _letterOrder;
		///<summary>This is simply used to measure strings for alignment purposes.</summary>
		private Graphics _grfx;

		#region Properties

		///<summary>Collection of Sections.</summary>
		public SectionCollection Sections{
			get{
				return _sections;
			}
			set{
				_sections=value;
			}
		}
		///<summary>A collection of ReportObjects</summary>
		public ReportObjectCollection ReportObjects{
			get{
				return _reportObjects;
			}
			set{
				_reportObjects=value;
			}
		}
		///<summary>Collection of ParameterFields that are available for the query.</summary>
		public ParameterFieldCollection ParameterFields{
			get{
				return _parameterFields;
			}
			set{
				_parameterFields=value;
			}
		}
		///<summary>Margins will be null unless set by user.  When printing, if margins are null, the defaults will depend on the page orientation.</summary>
		public Margins ReportMargins{
			get{
				//return reportMargins; //reportMargins is always null!
				return null;
			}
		}
		///<summary></summary>
		public bool IsLandscape{
			get{
				return _isLandscape;
			}
			set{
				_isLandscape=value;
			}
		}

		///<summary></summary>
		public bool HasReportSummary {
			get {
				return _hasReportSummary;
			}
			set {
				_hasReportSummary=value;
			}
		}
		///<summary>The name to display in the menu.</summary>
		public string ReportName{
			get{
				return _reportName;
			}
			set{
				_reportName=value;
			}
		}
		///<summary>Gives the user a description and some guidelines about what they can expect from this report.</summary>
		public string Description{
			get{
				return _description;
			}
			set{
				_description=value;
			}
		}
		///<summary>For instance OD12 or JoeDeveloper9.  If you are a developer releasing reports, then this should be your name or company followed by a unique number.  This will later make it easier to maintain your reports for your customers.  All reports that we release will be of the form OD##.  Reports that the user creates will have this field blank.</summary>
		public string AuthorID{
			get{
				return _authorID;
			}
			set{
				_authorID=value;
			}
		}
		///<summary>The 1-based order to show in the Letter menu, or 0 to not show in that menu.</summary>
		public int LetterOrder{
			get{
				return _letterOrder;
			}
			set{
				_letterOrder=value;
			}
		}
		
		#endregion

		///<summary>This can add a title, subtitle, grid lines, and page nums to the report using defaults.  If the parameters are blank or false the object will not be added.</summary>
		public ReportComplex(string title,string subTitle,bool hasGridLines,bool hasPageNums,bool isLandscape) {
			_grfx=Graphics.FromImage(new Bitmap(1,1));
			_isLandscape=isLandscape;
			if(!String.IsNullOrWhiteSpace(title)) {
				AddTitle(title);
			}
			if(!String.IsNullOrWhiteSpace(subTitle)) {
				AddSubTitle("Default",subTitle);
			}
			if(hasGridLines) {
				AddGridLines();
			}
			if(hasPageNums) {
				AddPageNum();
			}
			if(_sections["Report Header"]==null) {
				_sections.Add(new Section(AreaSectionKind.ReportHeader,0));
			}
			if(_sections["Page Header"]==null) {
				_sections.Add(new Section(AreaSectionKind.PageHeader,0));
			}
			if(_sections["Page Footer"]==null) {
				_sections.Add(new Section(AreaSectionKind.PageFooter,0));
			}
			if(_sections["Report Footer"]==null) {
				_sections.Add(new Section(AreaSectionKind.ReportFooter,0));
			}
		}

		///<summary>Adds a ReportObject large, centered, and bold, to the top of the Report Header Section.  Should only be done once, and done before any subTitles.</summary>
		private void AddTitle(string title){
			Font font=new Font("Tahoma",17,FontStyle.Bold);
			Size size=new Size((int)(_grfx.MeasureString(title,font).Width/_grfx.DpiX*100+2)
				,(int)(_grfx.MeasureString(title,font).Height/_grfx.DpiY*100+2));
			int xPos;
			if(_isLandscape) {
				xPos=1100/2;
				xPos-=50;
			}
			else {
				xPos=850/2;
				xPos-=30;
			}
			xPos-=(int)(size.Width/2);
			if(_sections["Report Header"]==null) {
				_sections.Add(new Section(AreaSectionKind.ReportHeader,0));
			}
			_reportObjects.Add(
				new ReportObject("Title","Report Header",new Point(xPos,0),size,title,font,ContentAlignment.MiddleCenter));
			//this it the only place a white buffer is added to a header.
			_sections["Report Header"].Height=(int)size.Height+20;
			//grfx.Dispose();
			//FormR.Dispose();
		}

		///<summary>Adds a ReportObject, centered and bold, at the bottom of the Report Header Section.  Should only be done after AddTitle.  You can add as many subtitles as you want.</summary>
		public void AddSubTitle(string name,string subTitle){
			Font font=new Font("Tahoma",10,FontStyle.Bold);
			Size size=new Size((int)(_grfx.MeasureString(subTitle,font).Width/_grfx.DpiX*100+2)
				,(int)(_grfx.MeasureString(subTitle,font).Height/_grfx.DpiY*100+2));
			int xPos;
			if(_isLandscape) {
				xPos=1100/2;
				xPos-=50;
			}
			else {
				xPos=850/2;
			xPos-=30;
			}
			xPos-=(int)(size.Width/2);
			if(_sections["Report Header"]==null){
				_sections.Add(new Section(AreaSectionKind.ReportHeader,0));	
			}
			//find the yPos+Height of the last reportObject in the Report Header section
			int yPos=0;
			foreach(ReportObject reportObject in _reportObjects){
				if(reportObject.SectionName!="Report Header") continue;
				if(reportObject.Location.Y+reportObject.Size.Height > yPos){
					yPos=reportObject.Location.Y+reportObject.Size.Height;
				}
			}
			_reportObjects.Add(
				new ReportObject(name,"Report Header",new Point(xPos,yPos+5),size,subTitle,font,ContentAlignment.MiddleCenter));
			_sections["Report Header"].Height+=(int)size.Height+5;
		}

		public QueryObject AddQuery(string query,string title,string tableFromColumn,SplitByKind splitByKind) {
			QueryObject queryObj=new QueryObject(query,title,tableFromColumn,splitByKind);
			_reportObjects.Add(queryObj);
			return queryObj;
		}

		public QueryObject AddQuery(string query,string title,string tableFromColumn,SplitByKind splitByKind,List<string> enumNames) {
			QueryObject queryObj=new QueryObject(query,title,tableFromColumn,splitByKind,enumNames,null);
			_reportObjects.Add(queryObj);
			return queryObj;
		}

		public QueryObject AddQuery(DataTable query,string title,string tableFromColumn,SplitByKind splitByKind) {
			QueryObject queryObj=new QueryObject(query,title,tableFromColumn,splitByKind);
			_reportObjects.Add(queryObj);
			return queryObj;
		}

		public QueryObject AddQuery(DataTable query,string title,string tableFromColumn,SplitByKind splitByKind,List<string> enumNames) {
			QueryObject queryObj=new QueryObject(query,title,tableFromColumn,splitByKind,enumNames,null);
			_reportObjects.Add(queryObj);
			return queryObj;
		}

		public QueryObject AddQuery(string query,string title,string tableFromColumn,SplitByKind splitByKind,Dictionary<long,string> dictDefNames) {
			QueryObject queryObj=new QueryObject(query,title,tableFromColumn,splitByKind,null,dictDefNames);
			_reportObjects.Add(queryObj);
			return queryObj;
		}

		public QueryObject AddQuery(DataTable query,string title,string tableFromColumn,SplitByKind splitByKind,Dictionary<long,string> dictDefNames) {
			QueryObject queryObj=new QueryObject(query,title,tableFromColumn,splitByKind,null,dictDefNames);
			_reportObjects.Add(queryObj);
			return queryObj;
		}

		/// <summary></summary>
		public void AddLine(string name,string sectionName,Color color,float lineThickness,LineOrientation lineOrientation,LinePosition linePosition,int linePercent,int offSetX,int offSetY) {
			_reportObjects.Add(new ReportObject(name,sectionName,color,lineThickness,lineOrientation,linePosition,linePercent,offSetX,offSetY));
		}

		/// <summary></summary>
		public void AddBox(string name,string sectionName,Color color,float lineThickness,int offSetX,int offSetY) {
			_reportObjects.Add(new ReportObject(name,sectionName,color,lineThickness,offSetX,offSetY));
		}

		public void AddReportSummaryField(Color color,string staticText,string dataFieldName,SummaryOperation operation,int offSetX,int offSetY) {
			_hasReportSummary=true;
			_reportObjects.Add(new ReportObject("ReportSummaryLabel","Report Footer",new Point(0,0),new Size((int)(_grfx.MeasureString(staticText,new Font("Tahoma",9)).Width/_grfx.DpiX*100+2)
				,(int)(_grfx.MeasureString(staticText,new Font("Tahoma",9)).Height/_grfx.DpiY*100+2)),staticText,new Font("Tahoma",9),ContentAlignment.MiddleLeft,offSetX,offSetY));
			_sections["Report Footer"].Height+=(int)((_grfx.MeasureString(staticText,new Font("Tahoma",9))).Height/_grfx.DpiY*100+2)+offSetY;
			_reportObjects.Add(new ReportObject("ReportSummaryText","Report Footer",color,dataFieldName,operation,offSetX,offSetY));
		}

		public ReportObject GetObjectByName(string name){
			for(int i=_reportObjects.Count-1;i>=0;i--){//search from the end backwards
				if(_reportObjects[i].Name==name) {
					return ReportObjects[i];
				}
			}
			MessageBox.Show("end of loop");
			return null;
		}

		public ReportObject GetTitle() {
			//ReportObject ro=null;
			for(int i=_reportObjects.Count-1;i>=0;i--) {//search from the end backwards
				if(_reportObjects[i].Name=="Title") {
					return ReportObjects[i];
				}
			}
			MessageBox.Show("end of loop");
			return null;
		}

		public ReportObject GetSubTitle(string subName) {
			//ReportObject ro=null;
			for(int i=_reportObjects.Count-1;i>=0;i--) {//search from the end backwards
				if(_reportObjects[i].Name==subName) {
					return ReportObjects[i];
				}
			}
			MessageBox.Show("end of loop");
			return null;
		}

		/// <summary>Put a pagenumber object on lower left of page footer section. Object is named PageNum.</summary>
		public void AddPageNum(){
			//add page number
			Font font=new Font("Tahoma",9);
			Size size=new Size(150,(int)(_grfx.MeasureString("anytext",font).Height/_grfx.DpiY*100+2));
			if(_sections["Page Footer"]==null){
				_sections.Add(new Section(AreaSectionKind.PageFooter,0));	
			}
			if(_sections["Page Footer"].Height==0){
				_sections["Page Footer"].Height=size.Height;
			}
			_reportObjects.Add(new ReportObject("PageNum","Page Footer"
				,new Point(0,0),size
				,FieldValueType.String,SpecialFieldType.PageNumber
				,font,ContentAlignment.MiddleLeft,""));
		}

		public void AddGridLines() {
			_hasGridLines=true;
		}

		///<summary>Adds a parameterField which will be used in the query to represent user-entered data.</summary>
		///<param name="myName">The unique formula name of the parameter.</param>
		///<param name="myValueType">The data type that this parameter stores.</param>
		///<param name="myDefaultValue">The default value of the parameter</param>
		///<param name="myPromptingText">The text to prompt the user with.</param>
		///<param name="mySnippet">The SQL snippet that this parameter represents.</param>
		public void AddParameter(string myName,FieldValueType myValueType
			,object myDefaultValue,string myPromptingText,string mySnippet){
			_parameterFields.Add(new ParameterField(myName,myValueType,myDefaultValue,myPromptingText,mySnippet));
		}

		/// <summary>Overload for ValueKind enum.</summary>
		public void AddParameter(string myName,FieldValueType myValueType
			,ArrayList myDefaultValues,string myPromptingText,string mySnippet,EnumType myEnumerationType){
			_parameterFields.Add(new ParameterField(myName,myValueType,myDefaultValues,myPromptingText,mySnippet,myEnumerationType));
		}

		/// <summary>Overload for ValueKind defCat.</summary>
		public void AddParameter(string myName,FieldValueType myValueType
			,ArrayList myDefaultValues,string myPromptingText,string mySnippet,DefCat myDefCategory){
			_parameterFields.Add(new ParameterField(myName,myValueType,myDefaultValues,myPromptingText,mySnippet,myDefCategory));
		}

		/// <summary>Overload for ValueKind defCat.</summary>
		public void AddParameter(string myName,FieldValueType myValueType
			,ArrayList myDefaultValues,string myPromptingText,string mySnippet,ReportFKType myReportFKType){
			_parameterFields.Add(new ParameterField(myName,myValueType,myDefaultValues,myPromptingText,mySnippet,myReportFKType));
		}

		///<summary>Submits the queries to the database and makes query objects for each query with the results.  Returns false if one of the queries failed.</summary>
		public bool SubmitQueries(){
			Graphics grfx=Graphics.FromImage(new Bitmap(1,1));
			string displayText;
			ReportObjectCollection newReportObjects=new ReportObjectCollection();
			_sections.Add(new Section(AreaSectionKind.Query,0));
			for(int i=0;i<_reportObjects.Count;i++) {
				if(_reportObjects[i].ObjectKind==ReportObjectKind.QueryObject) {
					QueryObject query=(QueryObject)_reportObjects[i];
					if(!query.SubmitQuery()) {
						if(query.ReportTable.Rows.Count==0) {
							MsgBox.Show(this,"The report has no results to show.");
						}
						return false;
					}
					if(query.ReportTable.Rows.Count==0) {
						continue;
					}
					//Check if the query needs to be split up into sub queries.  E.g. one payment report query split up via payment type.
					if(!String.IsNullOrWhiteSpace(query.ColumnNameToSplitOn)) {
						//The query needs to be split up into sub queries every time the ColumnNameToSplitOn cell changes.  
						//Therefore, we need to create a separate QueryObject for every time the cell value changes.
						string lastCellValue="";
						QueryObject newQuery=null;
						for(int j=0;j<query.ReportTable.Rows.Count;j++) {
							if(query.ReportTable.Rows[j][query.ColumnNameToSplitOn].ToString()!=lastCellValue) {
								//Must happen the first time through
								if(newQuery!=null) {
									switch(newQuery.SplitKind) {
										case SplitByKind.None:
											return false;
										case SplitByKind.Enum:
											if(newQuery.EnumNames==null) {
												return false;
											}
											displayText=newQuery.EnumNames[PIn.Int(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString())];
											newQuery.GetGroupTitle().Size=new Size((int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Width/grfx.DpiX*100+2),(int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Height/grfx.DpiY*100+2));
											newQuery.GetGroupTitle().StaticText=displayText;
											break;
										case SplitByKind.Definition:
											if(newQuery.DefNames==null) {
												return false;
											}
											if(newQuery.DefNames.ContainsKey(PIn.Int(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString()))) {
												displayText=newQuery.DefNames[PIn.Int(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString())];
												newQuery.GetGroupTitle().Size=new Size((int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Width/grfx.DpiX*100+2),(int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Height/grfx.DpiY*100+2));
												newQuery.GetGroupTitle().StaticText=displayText;
											}
											else {
												newQuery.GetGroupTitle().StaticText="Undefined";
											}
											break;
										case SplitByKind.Date:
											newQuery.GetGroupTitle().StaticText=PIn.Date(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString()).ToShortDateString();
											break;
									}
									newQuery.SubmitQuery();
									newReportObjects.Add(newQuery);
								}
								if(newQuery==null && query.GetGroupTitle().StaticText!="") {
									newQuery=query.DeepCopyQueryObject();
									newQuery.ReportTable.ImportRow(query.ReportTable.Rows[j]);
									newQuery.AddInitialHeader(newQuery.GetGroupTitle().StaticText,newQuery.GetGroupTitle().Font);
								}
								else {
									newQuery=query.DeepCopyQueryObject();
									newQuery.ReportTable.ImportRow(query.ReportTable.Rows[j]);
								}
							}
							else {
								newQuery.ReportTable.ImportRow(query.ReportTable.Rows[j]);
							}
							lastCellValue=query.ReportTable.Rows[j][query.ColumnNameToSplitOn].ToString();
						}
						switch(newQuery.SplitKind) {
							case SplitByKind.None:
								return false;
							case SplitByKind.Enum:
								if(newQuery.EnumNames==null) {
									return false;
								}
								displayText=newQuery.EnumNames[PIn.Int(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString())];
								newQuery.GetGroupTitle().Size=new Size((int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Width/grfx.DpiX*100+2),(int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Height/grfx.DpiY*100+2));
								newQuery.GetGroupTitle().StaticText=displayText;
								break;
							case SplitByKind.Definition:
								if(newQuery.DefNames==null) {
									return false;
								}
								if(newQuery.DefNames.ContainsKey(PIn.Int(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString()))) {
									displayText=newQuery.DefNames[PIn.Int(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString())];
									newQuery.GetGroupTitle().Size=new Size((int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Width/grfx.DpiX*100+2),(int)(grfx.MeasureString(displayText,newQuery.GetGroupTitle().Font).Height/grfx.DpiY*100+2));
									newQuery.GetGroupTitle().StaticText=displayText;
								}
								else {
									newQuery.GetGroupTitle().StaticText=Lans.g(this,"Undefined");
								}
								break;
							case SplitByKind.Date:
								newQuery.GetGroupTitle().StaticText=PIn.Date(newQuery.ReportTable.Rows[0][query.ColumnNameToSplitOn].ToString()).ToShortDateString();
								break;
						}
						newQuery.SubmitQuery();
						newReportObjects.Add(newQuery);
					}
					else {
						newReportObjects.Add(_reportObjects[i]);
					}
				}
				else {
					newReportObjects.Add(_reportObjects[i]);
				}
			}
			_reportObjects=newReportObjects;
			if(_hasReportSummary) {
				for(int i=0;i<_reportObjects.Count;i++) {
					if(_reportObjects[i].SectionName=="Report Footer" && _reportObjects[i].FieldKind==FieldDefKind.SummaryField) {
						_reportObjects[i].StaticText=GetReportSummaryValue(_reportObjects[i].SummarizedField,_reportObjects[i].Operation).ToString("c");
					}
				}
			}
			return true;
		}

		///<summary>If the specified section exists, then this returns its height. Otherwise it returns 0.</summary>
		public int GetSectionHeight(string sectionName) {
			if(!_sections.Contains(sectionName)) {
				return 0;
			}
			return _sections[sectionName].Height;
		}

		public bool HasGridLines() {
			return _hasGridLines;
		}

		private double GetReportSummaryValue(string columnName,SummaryOperation operation) {
			double retVal=0;
			for(int i=0;i<_reportObjects.Count;i++) {
				if(_reportObjects[i].ObjectKind!=ReportObjectKind.QueryObject) {
					continue;
				}
				QueryObject queryObj=(QueryObject)_reportObjects[i];
				for(int j=0;j<queryObj.ReportTable.Rows.Count;j++) {
					if(operation==SummaryOperation.Sum) {
						//This could be enhanced in the future to only sum up the cells that match the column name within the current query group.
						//Right now, if multiple query groups share the same column name that is being summed, the total will include both sets.
						retVal+=PIn.Double(queryObj.ReportTable.Rows[j][queryObj.ReportTable.Columns.IndexOf(columnName)].ToString());
					}
					else if(operation==SummaryOperation.Count) {
						retVal++;
					}
				}
			}
			return retVal;
		}

		

	}
}










