using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OpenDental.UI{ 

	///<summary></summary>
	//[DesignTimeVisible(false)]
	//[TypeConverter(typeof(GridColumnTypeConverter))]
	public class ODGridColumn{		
		private string heading;
		private int colWidth;
		private HorizontalAlignment textAlign;
		private bool isEditable;
		//private System.ComponentModel.Container components = null;
		private ImageList imageList;
		private GridSortingStrategy sortingStrategy;
		///<summary>When set, all cells in this column will display a combo box with these strings as options which the user can pick from.</summary>
		public List<string> ListDisplayStrings;

		///<summary>Creates a new ODGridcolumn.</summary>
		public ODGridColumn(){
			heading="";
			colWidth=80;
			textAlign=HorizontalAlignment.Left;
			isEditable=false;
			imageList=null;
			sortingStrategy=GridSortingStrategy.StringCompare;
		}

		///<summary>Creates a new ODGridcolumn with the given heading and width. Alignment left</summary>
		public ODGridColumn(string heading,int colWidth,HorizontalAlignment textAlign,bool isEditable) {
			this.heading=heading;
			this.colWidth=colWidth;
			this.textAlign=textAlign;
			this.isEditable=isEditable;
			imageList=null;
			sortingStrategy=GridSortingStrategy.StringCompare;
		}

		///<summary>Creates a new ODGridcolumn with the given heading and width. Alignment left</summary>
		public ODGridColumn(string heading,int colWidth,bool isEditable) {
			this.heading=heading;
			this.colWidth=colWidth;
			this.isEditable=isEditable;
			imageList=null;
			sortingStrategy=GridSortingStrategy.StringCompare;
		}

		///<summary>Creates a new ODGridcolumn with the given heading and width.</summary>
		public ODGridColumn(string heading,int colWidth,HorizontalAlignment textAlign){
			this.heading=heading;
			this.colWidth=colWidth;
			this.textAlign=textAlign;
			imageList=null;
			sortingStrategy=GridSortingStrategy.StringCompare;
		}

		///<summary>Creates a new ODGridcolumn with the given heading and width. Alignment left</summary>
		public ODGridColumn(string heading,int colWidth){
			this.heading=heading;
			this.colWidth=colWidth;
			this.textAlign=HorizontalAlignment.Left;
			imageList=null;
			sortingStrategy=GridSortingStrategy.StringCompare;
		}
		
		///<summary>Creates a new ODGridcolumn with the given heading, width, and as a combo box type column with the options in listDisplayStrings.</summary>
		public ODGridColumn(string heading,int colWidth,List<string> listDisplayStrings) {
			this.heading=heading;
			this.colWidth=colWidth;
			this.sortingStrategy=GridSortingStrategy.StringCompare;
			this.ListDisplayStrings=listDisplayStrings;
		}

		///<summary></summary>
		public string Heading{
			get{
				return heading;
			}
			set{
				heading=value;
			}
		}

		///<summary></summary>
		public int ColWidth{
			get{
				return colWidth;
			}
			set{
				colWidth=value;
			}
		}

	  ///<summary></summary>
		public HorizontalAlignment TextAlign{
			get{
				return textAlign;
			}
			set{
				textAlign=value;
			}
		}   
		
		///<summary></summary>
		public bool IsEditable{
			get {
				return isEditable;
			}
			set {
				isEditable=value;
			}
		}
	    
    ///<summary></summary>
		public ImageList ImageList{
			get {
				return imageList;
			}
			set {
				imageList=value;
			}
		}

		///<summary></summary>
		public GridSortingStrategy SortingStrategy{
			get {
				return sortingStrategy;
			}
			set {
				sortingStrategy=value;
			}
		}

	}

	public class ODGridColumnGroupHeader {
		private string heading;
		private int colSpan;
		
	}







	public enum GridSortingStrategy {
		///<summary>0- Default</summary>
		StringCompare,
		DateParse,
		ToothNumberParse,
		AmountParse
	}
}






