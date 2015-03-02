/*=============================================================================================================
Open Dental GPL license Copyright (C) 2003  Jordan Sparks, DMD.  http://www.open-dent.com,  www.docsparks.com
See header in FormOpenDental.cs for complete text.  Redistributions must retain this text.
===============================================================================================================*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OpenDental.UI;
using CodeBase;
using OpenDental.Eclaims;
using OpenDentBusiness;

namespace OpenDental{
///<summary></summary>
	public class FormClaimEdit : System.Windows.Forms.Form{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label labelNote;
		private System.Windows.Forms.GroupBox groupProsth;
		private System.Windows.Forms.Label labelMissingTeeth;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox textPredeterm;
		private OpenDental.ValidDate textDateRec;
		private OpenDental.ValidDate textDateSent;
		private System.ComponentModel.Container components = null;// Required designer variable.
		private OpenDental.UI.Button butOK;
		///<summary></summary>
		public bool IsNew;
		private System.Windows.Forms.RadioButton radioProsthN;
		private System.Windows.Forms.RadioButton radioProsthR;
		private System.Windows.Forms.RadioButton radioProsthI;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textPlan;
		private System.Windows.Forms.TextBox textClaimFee;
		private OpenDental.ValidDouble textDedApplied;
		private OpenDental.ValidDouble textInsPayAmt;
		private OpenDental.ValidDate textPriorDate;
		//private double ClaimFee;
		//private double PriInsPayEstSubtotal;
		//private double SecInsPayEstSubtotal;
		//private double PriInsPayEst;
		//private double SecInsPayEst;
		private OpenDental.UI.Button butCancel;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupOrtho;
		private System.Windows.Forms.Label labelOrthoRemainM;
		private System.Windows.Forms.CheckBox checkIsOrtho;
		private OpenDental.ValidNum textOrthoRemainM;
		private OpenDental.ValidDate textOrthoDate;
		private System.Windows.Forms.Label labelOrthoDate;
		//private FormClaimSupplemental FormCS=new FormClaimSupplemental();
		private System.Windows.Forms.Label labelPredeterm;
		private System.Windows.Forms.Label labelDateService;
		private System.Windows.Forms.ComboBox comboProvBill;
		private System.Windows.Forms.ComboBox comboProvTreat;
		private System.Windows.Forms.Label label2;
		private OpenDental.UI.Button butDelete;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboPatRelat;
		private System.Windows.Forms.ComboBox comboPatRelat2;
		private System.Windows.Forms.TextBox textPlan2;
		private OpenDental.UI.Button butRecalc;
		private System.Windows.Forms.TextBox textInsPayEst;
		private OpenDental.ValidDouble textWriteOff;
		private OpenDental.UI.Button butPreview;
		private OpenDental.UI.Button butPrint;
		private OpenDental.UI.Button butOtherNone;
		private System.Windows.Forms.Label labelRadiographs;
		private OpenDental.ValidNum textRadiographs;
		private OpenDental.UI.Button butOtherCovChange;
		//private double DedAdjPerc;
		private List<ClaimProc> ClaimProcsForClaim;
		///<summary>All claimprocs for the patient. Used to calculate remaining benefits, etc.</summary>
		private List<ClaimProc> ClaimProcList;
		private OpenDental.ODtextBox textNote;
		/// <summary>List of all procedures for this patient.  Used to get descriptions, etc.</summary>
		private List<Procedure> ProcList;
		private Patient PatCur;
		private Family FamCur;
		private List <InsPlan> PlanList;
		private OpenDental.ValidDate textDateService;
		private DataTable tablePayments;
			//ClaimPayment[] ClaimPaymentList;
		private System.Windows.Forms.ComboBox comboClinic;
		private System.Windows.Forms.Label labelClinic;
		private OpenDental.UI.Button butLabel;
		private OpenDental.UI.Button butSplit;
		//private User user;
		///<summary>When user first opens form, if the claim is S or R, and the user does not have permission, the user is informed, and this is set to true.</summary>
		private bool notAuthorized;
		private List <PatPlan> PatPlanList;
		private OpenDental.UI.ODGrid gridProc;
		private OpenDental.UI.Button butSend;
		private Claim ClaimCur;
		private GroupBox groupValueCodes;
		private Label label15;
		private Label label14;
		private Label label13;
		private Label label12;
		private Label label11;
		private Label label22;
		private Label label25;
		private TextBox textVC9Amount;
		private TextBox textVC6Amount;
		private TextBox textVC3Amount;
		private TextBox textVC0Amount;
		private TextBox textVC9Code;
		private TextBox textVC6Code;
		private TextBox textVC3Code;
		private TextBox textVC0Code;
		private Label label26;
		private Label label30;
		private Label label31;
		private Label label32;
		private Label label33;
		private Label label34;
		private Label label35;
		private TextBox textVC10Amount;
		private TextBox textVC7Amount;
		private TextBox textVC4Amount;
		private TextBox textVC1Amount;
		private TextBox textVC10Code;
		private TextBox textVC7Code;
		private TextBox textVC4Code;
		private TextBox textVC1Code;
		private Label label17;
		private Label label19;
		private Label label23;
		private Label label24;
		private Label label28;
		private Label label29;
		private Label label27;
		private TextBox textVC11Amount;
		private TextBox textVC8Amount;
		private TextBox textVC5Amount;
		private TextBox textVC2Amount;
		private TextBox textVC11Code;
		private TextBox textVC8Code;
		private TextBox textVC5Code;
		private TextBox textVC2Code;
		private Label label36;
		private Label label37;
		private Label label38;
		private Label label39;
		private Label label40;
		private Label label41;
		//private ClaimForm ClaimFormCur;
		private Label label20;
		private Panel panelBottomEdge;
		private Panel panelRightEdge;
		private TabControl tabMain;
		private TabPage tabUB04;
		private TabPage tabGeneral;
		private ODGrid gridPay;
		private GroupBox groupEnterPayment;
		private OpenDental.UI.Button butPaySupp;
		private OpenDental.UI.Button butPayTotal;
		private OpenDental.UI.Button butPayProc;
		private TextBox textReasonUnder;
		private Label label4;
		private Label label42;
		private ComboBox comboAccident;
		private Label labelAccidentST;
		private ComboBox comboEmployRelated;
		private TextBox textAccidentST;
		private ComboBox comboPlaceService;
		private ValidDate textAccidentDate;
		private TextBox textRefProv;
		private Label label44;
		private OpenDental.UI.Button butReferralSelect;
		private OpenDental.UI.Button butReferralNone;
		private Label label45;
		private Label label46;
		private TextBox textRefNum;
		private Label label47;
		private Label label48;
		private Label label49;
		private OpenDental.UI.Button butReferralEdit;
		private GroupBox groupBox1;
		private TextBox textCode10;
		private TextBox textCode9;
		private TextBox textCode8;
		private TextBox textCode7;
		private TextBox textCode6;
		private TextBox textCode5;
		private TextBox textCode4;
		private TextBox textCode3;
		private TextBox textCode2;
		private TextBox textCode1;
		private TextBox textCode0;
		private Label label60;
		private Label label59;
		private Label label58;
		private Label label57;
		private Label label56;
		private Label label55;
		private Label label54;
		private Label label53;
		private Label label52;
		private Label label51;
		private Label label50;
		private List<ClaimValCodeLog> ListClaimValCodes;
		private GroupBox groupReferral;
		private GroupBox groupAttachedImages;
		private OpenDental.UI.Button butAttachAdd;
		private OpenDental.UI.Button butAttachPerio;
		private ListBox listAttachments;
		private ContextMenu contextMenuAttachments;
		private MenuItem menuItemOpen;
		private MenuItem menuItemRename;
		private MenuItem menuItemRemove;
		///<summary>can be null</summary>
		private ClaimCondCodeLog ClaimCondCodeLogCur;
		private OpenDental.UI.Button butExport;
		private Label label61;
		private GroupBox groupAttachments;
		private Label label62;
		private ValidNum textAttachImages;
		private CheckBox checkAttachMisc;
		private CheckBox checkAttachPerio;
		private CheckBox checkAttachNarrative;
		private CheckBox checkAttachEoB;
		private Label label63;
		private ValidNum textAttachModels;
		private RadioButton radioAttachMail;
		private TextBox textAttachID;
		private Label label64;
		private RadioButton radioAttachElect;
		private Label label65;
		private List<Claim> ClaimList;
		private TabPage tabCanadian;
		private GroupBox groupBox7;
		private Label label69;
		private ValidDate textDateInitialUpper;
		private Label label70;
		private ComboBox comboMaxProsthMaterial;
		private Label label71;
		private GroupBox groupBox8;
		private CheckBox checkImages;
		private CheckBox checkXrays;
		private CheckBox checkModels;
		private CheckBox checkCorrespondence;
		private CheckBox checkEmail;
		private GroupBox groupBox9;
		private Label label72;
		private ComboBox comboReferralReason;
		private Label label73;
		private TextBox textReferralProvider;
		private ComboBox comboMaxProsth;
		private GroupBox groupBox6;
		private ComboBox comboMandProsth;
		private Label label66;
		private ValidDate textDateInitialLower;
		private Label label67;
		private ComboBox comboMandProsthMaterial;
		private Label label68;
		private OpenDental.UI.Button butMissingTeethHelp;
		private ValidDate textCanadianAccidentDate;
		private Label label43;
		private GroupBox groupAccident;
		private CheckBox checkCanadianIsOrtho;
		private TextBox textMissingTeeth;
		private Label label75;
		private Label label74;
		private ListBox listExtractedTeeth;
		private OpenDental.UI.Button butHistory;
		private bool doubleClickWarningAlreadyDisplayed=false;
		private UI.Button butReverse;
		private Label label76;
		private GroupBox groupCanadaOrthoPredeterm;
		private Label label77;
		private ValidDate textDateCanadaEstTreatStartDate;
		private TextBox textCanadaTransRefNum;
		private Label label78;
		private TextBox textCanadaInitialPayment;
		private Label label79;
		private TextBox textCanadaTreatDuration;
		private Label label80;
		private TextBox textCanadaNumPaymentsAnticipated;
		private Label label81;
		private TextBox textCanadaAnticipatedPayAmount;
		private Label label82;
		private TextBox textCanadaExpectedPayCycle;
		private ValidDouble textLabFees;
		private ComboBox comboClaimStatus;
		private ComboBox comboClaimType;
		private TextBox textPriorAuth;
		private Label labelPriorAuth;
		private ComboBox comboSpecialProgram;
		private Label labelSpecialProgram;
		private TextBox textBillType;
		private Label label7;
		private TextBox textPatientStatus;
		private Label label85;
		private TextBox textAdmissionSource;
		private Label label84;
		private TextBox textAdmissionType;
		private Label label83;
		private ComboBox comboMedType;
		private Label label86;
		private ComboBox comboClaimForm;
		private Label label87;
		private UI.Button butBatch;
		private Label labelBatch;
		private List<InsSub> SubList;
		private ComboBox comboCustomTracking;
		private Label labelCustomTracking;
		private ValidDate textDateResent;
		private Label label89;
		private TextBox textOrigRefNum;
		private Label label92;
		private TextBox textClaimIdentifier;
		private Label label91;
		private ComboBox comboCorrectionType;
		private Label label90;
		private UI.Button butResend;
		private TabPage tabMisc;
		private Label label94;
		private Label label93;
		private Label label88;
		private UI.Button butNoneProvOrdering;
		private ComboBox comboProvNumOrdering;
		private UI.Button butPickProvOrdering;
		private Label label95;
		private GroupBox groupUb04;
		///<summary>If this claim edit window is accessed from the batch ins window, then set this to true to hide the batch button in this window and prevent loop.</summary>
		public bool IsFromBatchWindow;
		private UI.Button butPickProvBill;
		private UI.Button butPickProvTreat;
		private long _provNumOrderingSelected;
		private long _provNumBillSelected;
		private long _provNumTreatSelected;

		///<summary></summary>
		public FormClaimEdit(Claim claimCur, Patient patCur,Family famCur){
			PatCur=patCur;
			FamCur=famCur;
			ClaimCur=claimCur;
			InitializeComponent();// Required for Windows Form Designer support
			//tbPay.CellDoubleClicked += new OpenDental.ContrTable.CellEventHandler(tbPay_CellDoubleClicked);
			//tbProc.CellClicked += new OpenDental.ContrTable.CellEventHandler(tbProc_CellClicked);
			//tbPay.CellClicked += new OpenDental.ContrTable.CellEventHandler(tbPay_CellClicked);
			Lan.F(this);
			listAttachments.ContextMenu=contextMenuAttachments;
    }

		///<summary></summary>
		protected override void Dispose( bool disposing ){
			if( disposing ){
				if(components != null){
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClaimEdit));
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.labelDateService = new System.Windows.Forms.Label();
			this.labelPredeterm = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.labelNote = new System.Windows.Forms.Label();
			this.groupProsth = new System.Windows.Forms.GroupBox();
			this.labelMissingTeeth = new System.Windows.Forms.Label();
			this.textPriorDate = new OpenDental.ValidDate();
			this.label18 = new System.Windows.Forms.Label();
			this.radioProsthN = new System.Windows.Forms.RadioButton();
			this.radioProsthR = new System.Windows.Forms.RadioButton();
			this.radioProsthI = new System.Windows.Forms.RadioButton();
			this.textInsPayEst = new System.Windows.Forms.TextBox();
			this.textPredeterm = new System.Windows.Forms.TextBox();
			this.textClaimFee = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textPlan = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.groupOrtho = new System.Windows.Forms.GroupBox();
			this.textOrthoDate = new OpenDental.ValidDate();
			this.labelOrthoDate = new System.Windows.Forms.Label();
			this.textOrthoRemainM = new OpenDental.ValidNum();
			this.checkIsOrtho = new System.Windows.Forms.CheckBox();
			this.labelOrthoRemainM = new System.Windows.Forms.Label();
			this.comboProvBill = new System.Windows.Forms.ComboBox();
			this.comboProvTreat = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboPatRelat = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.butOtherNone = new OpenDental.UI.Button();
			this.butOtherCovChange = new OpenDental.UI.Button();
			this.comboPatRelat2 = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textPlan2 = new System.Windows.Forms.TextBox();
			this.labelRadiographs = new System.Windows.Forms.Label();
			this.comboClinic = new System.Windows.Forms.ComboBox();
			this.labelClinic = new System.Windows.Forms.Label();
			this.groupValueCodes = new System.Windows.Forms.GroupBox();
			this.textVC11Amount = new System.Windows.Forms.TextBox();
			this.textVC8Amount = new System.Windows.Forms.TextBox();
			this.textVC5Amount = new System.Windows.Forms.TextBox();
			this.textVC2Amount = new System.Windows.Forms.TextBox();
			this.textVC11Code = new System.Windows.Forms.TextBox();
			this.textVC8Code = new System.Windows.Forms.TextBox();
			this.textVC5Code = new System.Windows.Forms.TextBox();
			this.textVC2Code = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.textVC10Amount = new System.Windows.Forms.TextBox();
			this.textVC7Amount = new System.Windows.Forms.TextBox();
			this.textVC4Amount = new System.Windows.Forms.TextBox();
			this.textVC1Amount = new System.Windows.Forms.TextBox();
			this.textVC10Code = new System.Windows.Forms.TextBox();
			this.textVC7Code = new System.Windows.Forms.TextBox();
			this.textVC4Code = new System.Windows.Forms.TextBox();
			this.textVC1Code = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.textVC9Amount = new System.Windows.Forms.TextBox();
			this.textVC6Amount = new System.Windows.Forms.TextBox();
			this.textVC3Amount = new System.Windows.Forms.TextBox();
			this.textVC0Amount = new System.Windows.Forms.TextBox();
			this.textVC9Code = new System.Windows.Forms.TextBox();
			this.textVC6Code = new System.Windows.Forms.TextBox();
			this.textVC3Code = new System.Windows.Forms.TextBox();
			this.textVC0Code = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.panelBottomEdge = new System.Windows.Forms.Panel();
			this.panelRightEdge = new System.Windows.Forms.Panel();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.groupAccident = new System.Windows.Forms.GroupBox();
			this.comboAccident = new System.Windows.Forms.ComboBox();
			this.label44 = new System.Windows.Forms.Label();
			this.textAccidentDate = new OpenDental.ValidDate();
			this.label42 = new System.Windows.Forms.Label();
			this.textAccidentST = new System.Windows.Forms.TextBox();
			this.labelAccidentST = new System.Windows.Forms.Label();
			this.groupAttachments = new System.Windows.Forms.GroupBox();
			this.label65 = new System.Windows.Forms.Label();
			this.textAttachID = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.radioAttachElect = new System.Windows.Forms.RadioButton();
			this.radioAttachMail = new System.Windows.Forms.RadioButton();
			this.checkAttachMisc = new System.Windows.Forms.CheckBox();
			this.checkAttachPerio = new System.Windows.Forms.CheckBox();
			this.checkAttachNarrative = new System.Windows.Forms.CheckBox();
			this.checkAttachEoB = new System.Windows.Forms.CheckBox();
			this.label63 = new System.Windows.Forms.Label();
			this.textAttachModels = new OpenDental.ValidNum();
			this.label62 = new System.Windows.Forms.Label();
			this.textAttachImages = new OpenDental.ValidNum();
			this.textRadiographs = new OpenDental.ValidNum();
			this.groupAttachedImages = new System.Windows.Forms.GroupBox();
			this.butExport = new OpenDental.UI.Button();
			this.butAttachAdd = new OpenDental.UI.Button();
			this.butAttachPerio = new OpenDental.UI.Button();
			this.label61 = new System.Windows.Forms.Label();
			this.listAttachments = new System.Windows.Forms.ListBox();
			this.groupReferral = new System.Windows.Forms.GroupBox();
			this.label45 = new System.Windows.Forms.Label();
			this.textRefProv = new System.Windows.Forms.TextBox();
			this.butReferralEdit = new OpenDental.UI.Button();
			this.label47 = new System.Windows.Forms.Label();
			this.butReferralNone = new OpenDental.UI.Button();
			this.butReferralSelect = new OpenDental.UI.Button();
			this.textRefNum = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.comboEmployRelated = new System.Windows.Forms.ComboBox();
			this.textNote = new OpenDental.ODtextBox();
			this.comboPlaceService = new System.Windows.Forms.ComboBox();
			this.label48 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.tabMisc = new System.Windows.Forms.TabPage();
			this.label94 = new System.Windows.Forms.Label();
			this.label93 = new System.Windows.Forms.Label();
			this.label88 = new System.Windows.Forms.Label();
			this.textOrigRefNum = new System.Windows.Forms.TextBox();
			this.label90 = new System.Windows.Forms.Label();
			this.labelPriorAuth = new System.Windows.Forms.Label();
			this.label92 = new System.Windows.Forms.Label();
			this.textPriorAuth = new System.Windows.Forms.TextBox();
			this.labelSpecialProgram = new System.Windows.Forms.Label();
			this.textClaimIdentifier = new System.Windows.Forms.TextBox();
			this.comboSpecialProgram = new System.Windows.Forms.ComboBox();
			this.labelCustomTracking = new System.Windows.Forms.Label();
			this.label91 = new System.Windows.Forms.Label();
			this.comboCustomTracking = new System.Windows.Forms.ComboBox();
			this.comboCorrectionType = new System.Windows.Forms.ComboBox();
			this.tabUB04 = new System.Windows.Forms.TabPage();
			this.groupUb04 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label60 = new System.Windows.Forms.Label();
			this.label59 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.textCode10 = new System.Windows.Forms.TextBox();
			this.textCode9 = new System.Windows.Forms.TextBox();
			this.textCode8 = new System.Windows.Forms.TextBox();
			this.textCode7 = new System.Windows.Forms.TextBox();
			this.textCode6 = new System.Windows.Forms.TextBox();
			this.textCode5 = new System.Windows.Forms.TextBox();
			this.textCode4 = new System.Windows.Forms.TextBox();
			this.textCode3 = new System.Windows.Forms.TextBox();
			this.textCode2 = new System.Windows.Forms.TextBox();
			this.textCode1 = new System.Windows.Forms.TextBox();
			this.textCode0 = new System.Windows.Forms.TextBox();
			this.textBillType = new System.Windows.Forms.TextBox();
			this.label83 = new System.Windows.Forms.Label();
			this.textPatientStatus = new System.Windows.Forms.TextBox();
			this.textAdmissionType = new System.Windows.Forms.TextBox();
			this.label85 = new System.Windows.Forms.Label();
			this.label84 = new System.Windows.Forms.Label();
			this.textAdmissionSource = new System.Windows.Forms.TextBox();
			this.butNoneProvOrdering = new OpenDental.UI.Button();
			this.comboProvNumOrdering = new System.Windows.Forms.ComboBox();
			this.butPickProvOrdering = new OpenDental.UI.Button();
			this.label95 = new System.Windows.Forms.Label();
			this.tabCanadian = new System.Windows.Forms.TabPage();
			this.textCanadaTransRefNum = new System.Windows.Forms.TextBox();
			this.groupCanadaOrthoPredeterm = new System.Windows.Forms.GroupBox();
			this.textCanadaExpectedPayCycle = new System.Windows.Forms.TextBox();
			this.textCanadaAnticipatedPayAmount = new System.Windows.Forms.TextBox();
			this.label82 = new System.Windows.Forms.Label();
			this.textCanadaNumPaymentsAnticipated = new System.Windows.Forms.TextBox();
			this.label81 = new System.Windows.Forms.Label();
			this.textCanadaTreatDuration = new System.Windows.Forms.TextBox();
			this.label80 = new System.Windows.Forms.Label();
			this.label79 = new System.Windows.Forms.Label();
			this.textCanadaInitialPayment = new System.Windows.Forms.TextBox();
			this.label78 = new System.Windows.Forms.Label();
			this.label77 = new System.Windows.Forms.Label();
			this.textDateCanadaEstTreatStartDate = new OpenDental.ValidDate();
			this.label76 = new System.Windows.Forms.Label();
			this.butReverse = new OpenDental.UI.Button();
			this.textMissingTeeth = new System.Windows.Forms.TextBox();
			this.label75 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.listExtractedTeeth = new System.Windows.Forms.ListBox();
			this.checkCanadianIsOrtho = new System.Windows.Forms.CheckBox();
			this.label43 = new System.Windows.Forms.Label();
			this.butMissingTeethHelp = new OpenDental.UI.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.comboMandProsth = new System.Windows.Forms.ComboBox();
			this.label66 = new System.Windows.Forms.Label();
			this.textDateInitialLower = new OpenDental.ValidDate();
			this.label67 = new System.Windows.Forms.Label();
			this.comboMandProsthMaterial = new System.Windows.Forms.ComboBox();
			this.label68 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.comboMaxProsth = new System.Windows.Forms.ComboBox();
			this.label69 = new System.Windows.Forms.Label();
			this.textDateInitialUpper = new OpenDental.ValidDate();
			this.label70 = new System.Windows.Forms.Label();
			this.comboMaxProsthMaterial = new System.Windows.Forms.ComboBox();
			this.label71 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.checkImages = new System.Windows.Forms.CheckBox();
			this.checkXrays = new System.Windows.Forms.CheckBox();
			this.checkModels = new System.Windows.Forms.CheckBox();
			this.checkCorrespondence = new System.Windows.Forms.CheckBox();
			this.checkEmail = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.label73 = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.comboReferralReason = new System.Windows.Forms.ComboBox();
			this.textReferralProvider = new System.Windows.Forms.TextBox();
			this.textCanadianAccidentDate = new OpenDental.ValidDate();
			this.groupEnterPayment = new System.Windows.Forms.GroupBox();
			this.butPaySupp = new OpenDental.UI.Button();
			this.butPayTotal = new OpenDental.UI.Button();
			this.butPayProc = new OpenDental.UI.Button();
			this.textReasonUnder = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.contextMenuAttachments = new System.Windows.Forms.ContextMenu();
			this.menuItemOpen = new System.Windows.Forms.MenuItem();
			this.menuItemRename = new System.Windows.Forms.MenuItem();
			this.menuItemRemove = new System.Windows.Forms.MenuItem();
			this.comboClaimStatus = new System.Windows.Forms.ComboBox();
			this.comboClaimType = new System.Windows.Forms.ComboBox();
			this.comboMedType = new System.Windows.Forms.ComboBox();
			this.label86 = new System.Windows.Forms.Label();
			this.comboClaimForm = new System.Windows.Forms.ComboBox();
			this.label87 = new System.Windows.Forms.Label();
			this.labelBatch = new System.Windows.Forms.Label();
			this.label89 = new System.Windows.Forms.Label();
			this.butResend = new OpenDental.UI.Button();
			this.textDateResent = new OpenDental.ValidDate();
			this.butBatch = new OpenDental.UI.Button();
			this.textLabFees = new OpenDental.ValidDouble();
			this.butHistory = new OpenDental.UI.Button();
			this.gridPay = new OpenDental.UI.ODGrid();
			this.butSend = new OpenDental.UI.Button();
			this.gridProc = new OpenDental.UI.ODGrid();
			this.butSplit = new OpenDental.UI.Button();
			this.butLabel = new OpenDental.UI.Button();
			this.textDateService = new OpenDental.ValidDate();
			this.textWriteOff = new OpenDental.ValidDouble();
			this.textInsPayAmt = new OpenDental.ValidDouble();
			this.textDedApplied = new OpenDental.ValidDouble();
			this.textDateSent = new OpenDental.ValidDate();
			this.textDateRec = new OpenDental.ValidDate();
			this.butPreview = new OpenDental.UI.Button();
			this.butPrint = new OpenDental.UI.Button();
			this.butRecalc = new OpenDental.UI.Button();
			this.butDelete = new OpenDental.UI.Button();
			this.butCancel = new OpenDental.UI.Button();
			this.butOK = new OpenDental.UI.Button();
			this.butPickProvBill = new OpenDental.UI.Button();
			this.butPickProvTreat = new OpenDental.UI.Button();
			this.groupProsth.SuspendLayout();
			this.groupOrtho.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupValueCodes.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.groupAccident.SuspendLayout();
			this.groupAttachments.SuspendLayout();
			this.groupAttachedImages.SuspendLayout();
			this.groupReferral.SuspendLayout();
			this.tabMisc.SuspendLayout();
			this.tabUB04.SuspendLayout();
			this.groupUb04.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabCanadian.SuspendLayout();
			this.groupCanadaOrthoPredeterm.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupEnterPayment.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(256, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Billing Dentist";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(2, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(108, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Date Received";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(5, 80);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 16);
			this.label8.TabIndex = 7;
			this.label8.Text = "Date Sent";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelDateService
			// 
			this.labelDateService.Location = new System.Drawing.Point(3, 61);
			this.labelDateService.Name = "labelDateService";
			this.labelDateService.Size = new System.Drawing.Size(107, 16);
			this.labelDateService.TabIndex = 8;
			this.labelDateService.Text = "Date of Service";
			this.labelDateService.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelPredeterm
			// 
			this.labelPredeterm.Location = new System.Drawing.Point(214, 120);
			this.labelPredeterm.Name = "labelPredeterm";
			this.labelPredeterm.Size = new System.Drawing.Size(138, 16);
			this.labelPredeterm.TabIndex = 11;
			this.labelPredeterm.Text = "Predeterm Benefits";
			this.labelPredeterm.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(6, 40);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(157, 16);
			this.label16.TabIndex = 16;
			this.label16.Text = "Prior Date of Placement";
			this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelNote
			// 
			this.labelNote.Location = new System.Drawing.Point(626, 3);
			this.labelNote.Name = "labelNote";
			this.labelNote.Size = new System.Drawing.Size(299, 16);
			this.labelNote.TabIndex = 19;
			this.labelNote.Text = "Claim Note (this will show on the claim when submitted)";
			// 
			// groupProsth
			// 
			this.groupProsth.BackColor = System.Drawing.SystemColors.Window;
			this.groupProsth.Controls.Add(this.labelMissingTeeth);
			this.groupProsth.Controls.Add(this.textPriorDate);
			this.groupProsth.Controls.Add(this.label18);
			this.groupProsth.Controls.Add(this.radioProsthN);
			this.groupProsth.Controls.Add(this.radioProsthR);
			this.groupProsth.Controls.Add(this.radioProsthI);
			this.groupProsth.Controls.Add(this.label16);
			this.groupProsth.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupProsth.Location = new System.Drawing.Point(3, 3);
			this.groupProsth.Name = "groupProsth";
			this.groupProsth.Size = new System.Drawing.Size(286, 114);
			this.groupProsth.TabIndex = 9;
			this.groupProsth.TabStop = false;
			this.groupProsth.Text = "Crown, Bridge, or Denture";
			// 
			// labelMissingTeeth
			// 
			this.labelMissingTeeth.Location = new System.Drawing.Point(3, 77);
			this.labelMissingTeeth.Name = "labelMissingTeeth";
			this.labelMissingTeeth.Size = new System.Drawing.Size(280, 32);
			this.labelMissingTeeth.TabIndex = 28;
			this.labelMissingTeeth.Text = "For bridges, dentures, and partials, missing teeth must have been correctly enter" +
    "ed in the Chart module. ";
			// 
			// textPriorDate
			// 
			this.textPriorDate.Location = new System.Drawing.Point(168, 36);
			this.textPriorDate.Name = "textPriorDate";
			this.textPriorDate.Size = new System.Drawing.Size(66, 20);
			this.textPriorDate.TabIndex = 3;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(6, 60);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(246, 18);
			this.label18.TabIndex = 29;
			this.label18.Text = "(Might need a note. Might need to attach x-ray)";
			// 
			// radioProsthN
			// 
			this.radioProsthN.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioProsthN.Location = new System.Drawing.Point(12, 18);
			this.radioProsthN.Name = "radioProsthN";
			this.radioProsthN.Size = new System.Drawing.Size(46, 16);
			this.radioProsthN.TabIndex = 0;
			this.radioProsthN.Text = "No";
			this.radioProsthN.Click += new System.EventHandler(this.radioProsthN_Click);
			// 
			// radioProsthR
			// 
			this.radioProsthR.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioProsthR.Location = new System.Drawing.Point(132, 18);
			this.radioProsthR.Name = "radioProsthR";
			this.radioProsthR.Size = new System.Drawing.Size(104, 16);
			this.radioProsthR.TabIndex = 2;
			this.radioProsthR.Text = "Replacement";
			this.radioProsthR.Click += new System.EventHandler(this.radioProsthR_Click);
			// 
			// radioProsthI
			// 
			this.radioProsthI.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioProsthI.Location = new System.Drawing.Point(64, 18);
			this.radioProsthI.Name = "radioProsthI";
			this.radioProsthI.Size = new System.Drawing.Size(64, 16);
			this.radioProsthI.TabIndex = 1;
			this.radioProsthI.Text = "Initial";
			this.radioProsthI.Click += new System.EventHandler(this.radioProsthI_Click);
			// 
			// textInsPayEst
			// 
			this.textInsPayEst.Location = new System.Drawing.Point(535, 363);
			this.textInsPayEst.Name = "textInsPayEst";
			this.textInsPayEst.ReadOnly = true;
			this.textInsPayEst.Size = new System.Drawing.Size(63, 20);
			this.textInsPayEst.TabIndex = 40;
			this.textInsPayEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textPredeterm
			// 
			this.textPredeterm.Location = new System.Drawing.Point(351, 116);
			this.textPredeterm.Name = "textPredeterm";
			this.textPredeterm.Size = new System.Drawing.Size(170, 20);
			this.textPredeterm.TabIndex = 1;
			// 
			// textClaimFee
			// 
			this.textClaimFee.Location = new System.Drawing.Point(349, 363);
			this.textClaimFee.Name = "textClaimFee";
			this.textClaimFee.ReadOnly = true;
			this.textClaimFee.Size = new System.Drawing.Size(63, 20);
			this.textClaimFee.TabIndex = 51;
			this.textClaimFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(229, 366);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 15);
			this.label1.TabIndex = 50;
			this.label1.Text = "Totals";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textPlan
			// 
			this.textPlan.Location = new System.Drawing.Point(8, 20);
			this.textPlan.Name = "textPlan";
			this.textPlan.ReadOnly = true;
			this.textPlan.Size = new System.Drawing.Size(253, 20);
			this.textPlan.TabIndex = 1;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(249, 98);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(102, 15);
			this.label21.TabIndex = 93;
			this.label21.Text = "Treating Dentist";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupOrtho
			// 
			this.groupOrtho.BackColor = System.Drawing.SystemColors.Window;
			this.groupOrtho.Controls.Add(this.textOrthoDate);
			this.groupOrtho.Controls.Add(this.labelOrthoDate);
			this.groupOrtho.Controls.Add(this.textOrthoRemainM);
			this.groupOrtho.Controls.Add(this.checkIsOrtho);
			this.groupOrtho.Controls.Add(this.labelOrthoRemainM);
			this.groupOrtho.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupOrtho.Location = new System.Drawing.Point(308, 3);
			this.groupOrtho.Name = "groupOrtho";
			this.groupOrtho.Size = new System.Drawing.Size(192, 114);
			this.groupOrtho.TabIndex = 11;
			this.groupOrtho.TabStop = false;
			this.groupOrtho.Text = "Ortho";
			// 
			// textOrthoDate
			// 
			this.textOrthoDate.Location = new System.Drawing.Point(115, 36);
			this.textOrthoDate.Name = "textOrthoDate";
			this.textOrthoDate.Size = new System.Drawing.Size(66, 20);
			this.textOrthoDate.TabIndex = 1;
			// 
			// labelOrthoDate
			// 
			this.labelOrthoDate.Location = new System.Drawing.Point(5, 40);
			this.labelOrthoDate.Name = "labelOrthoDate";
			this.labelOrthoDate.Size = new System.Drawing.Size(109, 16);
			this.labelOrthoDate.TabIndex = 104;
			this.labelOrthoDate.Text = "Date of Placement";
			this.labelOrthoDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textOrthoRemainM
			// 
			this.textOrthoRemainM.Location = new System.Drawing.Point(115, 60);
			this.textOrthoRemainM.MaxVal = 255;
			this.textOrthoRemainM.MinVal = 0;
			this.textOrthoRemainM.Name = "textOrthoRemainM";
			this.textOrthoRemainM.Size = new System.Drawing.Size(39, 20);
			this.textOrthoRemainM.TabIndex = 2;
			// 
			// checkIsOrtho
			// 
			this.checkIsOrtho.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkIsOrtho.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkIsOrtho.Location = new System.Drawing.Point(38, 15);
			this.checkIsOrtho.Name = "checkIsOrtho";
			this.checkIsOrtho.Size = new System.Drawing.Size(90, 18);
			this.checkIsOrtho.TabIndex = 0;
			this.checkIsOrtho.Text = "Is For Ortho";
			this.checkIsOrtho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelOrthoRemainM
			// 
			this.labelOrthoRemainM.Location = new System.Drawing.Point(2, 61);
			this.labelOrthoRemainM.Name = "labelOrthoRemainM";
			this.labelOrthoRemainM.Size = new System.Drawing.Size(112, 18);
			this.labelOrthoRemainM.TabIndex = 102;
			this.labelOrthoRemainM.Text = "Months Remaining";
			this.labelOrthoRemainM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboProvBill
			// 
			this.comboProvBill.Location = new System.Drawing.Point(351, 74);
			this.comboProvBill.MaxDropDownItems = 30;
			this.comboProvBill.Name = "comboProvBill";
			this.comboProvBill.Size = new System.Drawing.Size(150, 21);
			this.comboProvBill.TabIndex = 97;
			this.comboProvBill.SelectionChangeCommitted += new System.EventHandler(this.comboProvBill_SelectionChangeCommitted);
			// 
			// comboProvTreat
			// 
			this.comboProvTreat.Location = new System.Drawing.Point(351, 95);
			this.comboProvTreat.MaxDropDownItems = 30;
			this.comboProvTreat.Name = "comboProvTreat";
			this.comboProvTreat.Size = new System.Drawing.Size(150, 21);
			this.comboProvTreat.TabIndex = 99;
			this.comboProvTreat.SelectionChangeCommitted += new System.EventHandler(this.comboProvTreat_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 14);
			this.label2.TabIndex = 104;
			this.label2.Text = "Claim Status";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(14, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(95, 17);
			this.label9.TabIndex = 109;
			this.label9.Text = "Claim Type";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboPatRelat);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.textPlan);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(531, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(269, 70);
			this.groupBox2.TabIndex = 110;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Insurance Plan";
			// 
			// comboPatRelat
			// 
			this.comboPatRelat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboPatRelat.Location = new System.Drawing.Point(90, 43);
			this.comboPatRelat.Name = "comboPatRelat";
			this.comboPatRelat.Size = new System.Drawing.Size(151, 21);
			this.comboPatRelat.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 17);
			this.label5.TabIndex = 2;
			this.label5.Text = "Relationship";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.butOtherNone);
			this.groupBox3.Controls.Add(this.butOtherCovChange);
			this.groupBox3.Controls.Add(this.comboPatRelat2);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.textPlan2);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(531, 73);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(269, 85);
			this.groupBox3.TabIndex = 111;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Other Coverage";
			// 
			// butOtherNone
			// 
			this.butOtherNone.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOtherNone.Autosize = true;
			this.butOtherNone.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOtherNone.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOtherNone.CornerRadius = 4F;
			this.butOtherNone.Location = new System.Drawing.Point(196, 9);
			this.butOtherNone.Name = "butOtherNone";
			this.butOtherNone.Size = new System.Drawing.Size(65, 22);
			this.butOtherNone.TabIndex = 5;
			this.butOtherNone.Text = "None";
			this.butOtherNone.Click += new System.EventHandler(this.butOtherNone_Click);
			// 
			// butOtherCovChange
			// 
			this.butOtherCovChange.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOtherCovChange.Autosize = true;
			this.butOtherCovChange.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOtherCovChange.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOtherCovChange.CornerRadius = 4F;
			this.butOtherCovChange.Location = new System.Drawing.Point(129, 9);
			this.butOtherCovChange.Name = "butOtherCovChange";
			this.butOtherCovChange.Size = new System.Drawing.Size(65, 22);
			this.butOtherCovChange.TabIndex = 4;
			this.butOtherCovChange.Text = "Change";
			this.butOtherCovChange.Click += new System.EventHandler(this.butOtherCovChange_Click);
			// 
			// comboPatRelat2
			// 
			this.comboPatRelat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboPatRelat2.Location = new System.Drawing.Point(90, 57);
			this.comboPatRelat2.Name = "comboPatRelat2";
			this.comboPatRelat2.Size = new System.Drawing.Size(151, 21);
			this.comboPatRelat2.TabIndex = 3;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 60);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(84, 17);
			this.label10.TabIndex = 2;
			this.label10.Text = "Relationship";
			// 
			// textPlan2
			// 
			this.textPlan2.Location = new System.Drawing.Point(8, 34);
			this.textPlan2.Name = "textPlan2";
			this.textPlan2.ReadOnly = true;
			this.textPlan2.Size = new System.Drawing.Size(253, 20);
			this.textPlan2.TabIndex = 1;
			// 
			// labelRadiographs
			// 
			this.labelRadiographs.Location = new System.Drawing.Point(28, 39);
			this.labelRadiographs.Name = "labelRadiographs";
			this.labelRadiographs.Size = new System.Drawing.Size(79, 18);
			this.labelRadiographs.TabIndex = 117;
			this.labelRadiographs.Text = "Radiographs";
			this.labelRadiographs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboClinic
			// 
			this.comboClinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClinic.Enabled = false;
			this.comboClinic.Location = new System.Drawing.Point(351, 11);
			this.comboClinic.MaxDropDownItems = 100;
			this.comboClinic.Name = "comboClinic";
			this.comboClinic.Size = new System.Drawing.Size(126, 21);
			this.comboClinic.TabIndex = 121;
			// 
			// labelClinic
			// 
			this.labelClinic.Location = new System.Drawing.Point(250, 15);
			this.labelClinic.Name = "labelClinic";
			this.labelClinic.Size = new System.Drawing.Size(98, 16);
			this.labelClinic.TabIndex = 120;
			this.labelClinic.Text = "Clinic";
			this.labelClinic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupValueCodes
			// 
			this.groupValueCodes.Controls.Add(this.textVC11Amount);
			this.groupValueCodes.Controls.Add(this.textVC8Amount);
			this.groupValueCodes.Controls.Add(this.textVC5Amount);
			this.groupValueCodes.Controls.Add(this.textVC2Amount);
			this.groupValueCodes.Controls.Add(this.textVC11Code);
			this.groupValueCodes.Controls.Add(this.textVC8Code);
			this.groupValueCodes.Controls.Add(this.textVC5Code);
			this.groupValueCodes.Controls.Add(this.textVC2Code);
			this.groupValueCodes.Controls.Add(this.label36);
			this.groupValueCodes.Controls.Add(this.label37);
			this.groupValueCodes.Controls.Add(this.label38);
			this.groupValueCodes.Controls.Add(this.label39);
			this.groupValueCodes.Controls.Add(this.label40);
			this.groupValueCodes.Controls.Add(this.label41);
			this.groupValueCodes.Controls.Add(this.textVC10Amount);
			this.groupValueCodes.Controls.Add(this.textVC7Amount);
			this.groupValueCodes.Controls.Add(this.textVC4Amount);
			this.groupValueCodes.Controls.Add(this.textVC1Amount);
			this.groupValueCodes.Controls.Add(this.textVC10Code);
			this.groupValueCodes.Controls.Add(this.textVC7Code);
			this.groupValueCodes.Controls.Add(this.textVC4Code);
			this.groupValueCodes.Controls.Add(this.textVC1Code);
			this.groupValueCodes.Controls.Add(this.label17);
			this.groupValueCodes.Controls.Add(this.label19);
			this.groupValueCodes.Controls.Add(this.label23);
			this.groupValueCodes.Controls.Add(this.label24);
			this.groupValueCodes.Controls.Add(this.label28);
			this.groupValueCodes.Controls.Add(this.label29);
			this.groupValueCodes.Controls.Add(this.label27);
			this.groupValueCodes.Controls.Add(this.label26);
			this.groupValueCodes.Controls.Add(this.label25);
			this.groupValueCodes.Controls.Add(this.textVC9Amount);
			this.groupValueCodes.Controls.Add(this.textVC6Amount);
			this.groupValueCodes.Controls.Add(this.textVC3Amount);
			this.groupValueCodes.Controls.Add(this.textVC0Amount);
			this.groupValueCodes.Controls.Add(this.textVC9Code);
			this.groupValueCodes.Controls.Add(this.textVC6Code);
			this.groupValueCodes.Controls.Add(this.textVC3Code);
			this.groupValueCodes.Controls.Add(this.textVC0Code);
			this.groupValueCodes.Controls.Add(this.label22);
			this.groupValueCodes.Controls.Add(this.label15);
			this.groupValueCodes.Controls.Add(this.label14);
			this.groupValueCodes.Controls.Add(this.label13);
			this.groupValueCodes.Controls.Add(this.label12);
			this.groupValueCodes.Controls.Add(this.label11);
			this.groupValueCodes.Location = new System.Drawing.Point(213, 82);
			this.groupValueCodes.Name = "groupValueCodes";
			this.groupValueCodes.Size = new System.Drawing.Size(434, 114);
			this.groupValueCodes.TabIndex = 130;
			this.groupValueCodes.TabStop = false;
			this.groupValueCodes.Text = "Value Codes";
			// 
			// textVC11Amount
			// 
			this.textVC11Amount.Location = new System.Drawing.Point(343, 90);
			this.textVC11Amount.Name = "textVC11Amount";
			this.textVC11Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC11Amount.TabIndex = 56;
			this.textVC11Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC8Amount
			// 
			this.textVC8Amount.Location = new System.Drawing.Point(343, 71);
			this.textVC8Amount.Name = "textVC8Amount";
			this.textVC8Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC8Amount.TabIndex = 55;
			this.textVC8Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC5Amount
			// 
			this.textVC5Amount.Location = new System.Drawing.Point(343, 52);
			this.textVC5Amount.Name = "textVC5Amount";
			this.textVC5Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC5Amount.TabIndex = 54;
			this.textVC5Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC2Amount
			// 
			this.textVC2Amount.Location = new System.Drawing.Point(343, 33);
			this.textVC2Amount.Name = "textVC2Amount";
			this.textVC2Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC2Amount.TabIndex = 53;
			this.textVC2Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC11Code
			// 
			this.textVC11Code.Location = new System.Drawing.Point(313, 90);
			this.textVC11Code.MaxLength = 2;
			this.textVC11Code.Name = "textVC11Code";
			this.textVC11Code.Size = new System.Drawing.Size(26, 20);
			this.textVC11Code.TabIndex = 52;
			this.textVC11Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC8Code
			// 
			this.textVC8Code.Location = new System.Drawing.Point(313, 71);
			this.textVC8Code.MaxLength = 2;
			this.textVC8Code.Name = "textVC8Code";
			this.textVC8Code.Size = new System.Drawing.Size(26, 20);
			this.textVC8Code.TabIndex = 51;
			this.textVC8Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC5Code
			// 
			this.textVC5Code.Location = new System.Drawing.Point(313, 52);
			this.textVC5Code.MaxLength = 2;
			this.textVC5Code.Name = "textVC5Code";
			this.textVC5Code.Size = new System.Drawing.Size(26, 20);
			this.textVC5Code.TabIndex = 50;
			this.textVC5Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC2Code
			// 
			this.textVC2Code.Location = new System.Drawing.Point(313, 33);
			this.textVC2Code.MaxLength = 2;
			this.textVC2Code.Name = "textVC2Code";
			this.textVC2Code.Size = new System.Drawing.Size(26, 20);
			this.textVC2Code.TabIndex = 49;
			this.textVC2Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(355, 18);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(42, 13);
			this.label36.TabIndex = 48;
			this.label36.Text = "amount";
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(311, 18);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(31, 13);
			this.label37.TabIndex = 47;
			this.label37.Text = "code";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(292, 94);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(13, 13);
			this.label38.TabIndex = 46;
			this.label38.Text = "d";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(292, 75);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(13, 13);
			this.label39.TabIndex = 45;
			this.label39.Text = "c";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(292, 56);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(13, 13);
			this.label40.TabIndex = 44;
			this.label40.Text = "b";
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(292, 37);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(13, 13);
			this.label41.TabIndex = 43;
			this.label41.Text = "a";
			// 
			// textVC10Amount
			// 
			this.textVC10Amount.Location = new System.Drawing.Point(203, 89);
			this.textVC10Amount.Name = "textVC10Amount";
			this.textVC10Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC10Amount.TabIndex = 42;
			this.textVC10Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC7Amount
			// 
			this.textVC7Amount.Location = new System.Drawing.Point(203, 70);
			this.textVC7Amount.Name = "textVC7Amount";
			this.textVC7Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC7Amount.TabIndex = 41;
			this.textVC7Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC4Amount
			// 
			this.textVC4Amount.Location = new System.Drawing.Point(203, 51);
			this.textVC4Amount.Name = "textVC4Amount";
			this.textVC4Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC4Amount.TabIndex = 40;
			this.textVC4Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC1Amount
			// 
			this.textVC1Amount.Location = new System.Drawing.Point(203, 32);
			this.textVC1Amount.Name = "textVC1Amount";
			this.textVC1Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC1Amount.TabIndex = 39;
			this.textVC1Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC10Code
			// 
			this.textVC10Code.Location = new System.Drawing.Point(173, 89);
			this.textVC10Code.MaxLength = 2;
			this.textVC10Code.Name = "textVC10Code";
			this.textVC10Code.Size = new System.Drawing.Size(26, 20);
			this.textVC10Code.TabIndex = 38;
			this.textVC10Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC7Code
			// 
			this.textVC7Code.Location = new System.Drawing.Point(173, 70);
			this.textVC7Code.MaxLength = 2;
			this.textVC7Code.Name = "textVC7Code";
			this.textVC7Code.Size = new System.Drawing.Size(26, 20);
			this.textVC7Code.TabIndex = 37;
			this.textVC7Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC4Code
			// 
			this.textVC4Code.Location = new System.Drawing.Point(173, 51);
			this.textVC4Code.MaxLength = 2;
			this.textVC4Code.Name = "textVC4Code";
			this.textVC4Code.Size = new System.Drawing.Size(26, 20);
			this.textVC4Code.TabIndex = 36;
			this.textVC4Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC1Code
			// 
			this.textVC1Code.Location = new System.Drawing.Point(173, 32);
			this.textVC1Code.MaxLength = 2;
			this.textVC1Code.Name = "textVC1Code";
			this.textVC1Code.Size = new System.Drawing.Size(26, 20);
			this.textVC1Code.TabIndex = 35;
			this.textVC1Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(215, 17);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(42, 13);
			this.label17.TabIndex = 34;
			this.label17.Text = "amount";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(171, 17);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(31, 13);
			this.label19.TabIndex = 33;
			this.label19.Text = "code";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(152, 93);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(13, 13);
			this.label23.TabIndex = 32;
			this.label23.Text = "d";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(152, 74);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(13, 13);
			this.label24.TabIndex = 31;
			this.label24.Text = "c";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(152, 55);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(13, 13);
			this.label28.TabIndex = 30;
			this.label28.Text = "b";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(152, 36);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(13, 13);
			this.label29.TabIndex = 29;
			this.label29.Text = "a";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(292, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(19, 13);
			this.label27.TabIndex = 28;
			this.label27.Text = "41";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(149, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(19, 13);
			this.label26.TabIndex = 27;
			this.label26.Text = "40";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(12, 16);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(19, 13);
			this.label25.TabIndex = 18;
			this.label25.Text = "39";
			// 
			// textVC9Amount
			// 
			this.textVC9Amount.Location = new System.Drawing.Point(66, 88);
			this.textVC9Amount.Name = "textVC9Amount";
			this.textVC9Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC9Amount.TabIndex = 17;
			this.textVC9Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC6Amount
			// 
			this.textVC6Amount.Location = new System.Drawing.Point(66, 69);
			this.textVC6Amount.Name = "textVC6Amount";
			this.textVC6Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC6Amount.TabIndex = 16;
			this.textVC6Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC3Amount
			// 
			this.textVC3Amount.Location = new System.Drawing.Point(66, 50);
			this.textVC3Amount.Name = "textVC3Amount";
			this.textVC3Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC3Amount.TabIndex = 15;
			this.textVC3Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC0Amount
			// 
			this.textVC0Amount.Location = new System.Drawing.Point(66, 31);
			this.textVC0Amount.Name = "textVC0Amount";
			this.textVC0Amount.Size = new System.Drawing.Size(66, 20);
			this.textVC0Amount.TabIndex = 14;
			this.textVC0Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textVC9Code
			// 
			this.textVC9Code.Location = new System.Drawing.Point(36, 88);
			this.textVC9Code.MaxLength = 2;
			this.textVC9Code.Name = "textVC9Code";
			this.textVC9Code.Size = new System.Drawing.Size(26, 20);
			this.textVC9Code.TabIndex = 13;
			this.textVC9Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC6Code
			// 
			this.textVC6Code.Location = new System.Drawing.Point(36, 69);
			this.textVC6Code.MaxLength = 2;
			this.textVC6Code.Name = "textVC6Code";
			this.textVC6Code.Size = new System.Drawing.Size(26, 20);
			this.textVC6Code.TabIndex = 12;
			this.textVC6Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC3Code
			// 
			this.textVC3Code.Location = new System.Drawing.Point(36, 50);
			this.textVC3Code.MaxLength = 2;
			this.textVC3Code.Name = "textVC3Code";
			this.textVC3Code.Size = new System.Drawing.Size(26, 20);
			this.textVC3Code.TabIndex = 11;
			this.textVC3Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textVC0Code
			// 
			this.textVC0Code.Location = new System.Drawing.Point(36, 31);
			this.textVC0Code.MaxLength = 2;
			this.textVC0Code.Name = "textVC0Code";
			this.textVC0Code.Size = new System.Drawing.Size(26, 20);
			this.textVC0Code.TabIndex = 10;
			this.textVC0Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(78, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(42, 13);
			this.label22.TabIndex = 7;
			this.label22.Text = "amount";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(34, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(31, 13);
			this.label15.TabIndex = 4;
			this.label15.Text = "code";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 92);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(13, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "d";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(15, 73);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(13, 13);
			this.label13.TabIndex = 2;
			this.label13.Text = "c";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(15, 54);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(13, 13);
			this.label12.TabIndex = 1;
			this.label12.Text = "b";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(15, 35);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(13, 13);
			this.label11.TabIndex = 0;
			this.label11.Text = "a";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(358, 16);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(42, 13);
			this.label30.TabIndex = 48;
			this.label30.Text = "amount";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(314, 16);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(31, 13);
			this.label31.TabIndex = 47;
			this.label31.Text = "code";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(295, 92);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(13, 13);
			this.label32.TabIndex = 46;
			this.label32.Text = "d";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(295, 73);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(13, 13);
			this.label33.TabIndex = 45;
			this.label33.Text = "c";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(295, 54);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(13, 13);
			this.label34.TabIndex = 44;
			this.label34.Text = "b";
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(295, 35);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(13, 13);
			this.label35.TabIndex = 43;
			this.label35.Text = "a";
			// 
			// label20
			// 
			this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label20.Location = new System.Drawing.Point(717, 847);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(215, 30);
			this.label20.TabIndex = 92;
			this.label20.Text = "(does not cancel payment edits)";
			this.label20.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panelBottomEdge
			// 
			this.panelBottomEdge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelBottomEdge.Location = new System.Drawing.Point(300, 700);
			this.panelBottomEdge.Name = "panelBottomEdge";
			this.panelBottomEdge.Size = new System.Drawing.Size(682, 1);
			this.panelBottomEdge.TabIndex = 131;
			this.panelBottomEdge.Visible = false;
			// 
			// panelRightEdge
			// 
			this.panelRightEdge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelRightEdge.Location = new System.Drawing.Point(982, 200);
			this.panelRightEdge.Name = "panelRightEdge";
			this.panelRightEdge.Size = new System.Drawing.Size(1, 500);
			this.panelRightEdge.TabIndex = 132;
			this.panelRightEdge.Visible = false;
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tabMain.Controls.Add(this.tabGeneral);
			this.tabMain.Controls.Add(this.tabMisc);
			this.tabMain.Controls.Add(this.tabUB04);
			this.tabMain.Controls.Add(this.tabCanadian);
			this.tabMain.Location = new System.Drawing.Point(2, 478);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(976, 378);
			this.tabMain.TabIndex = 133;
			// 
			// tabGeneral
			// 
			this.tabGeneral.AutoScroll = true;
			this.tabGeneral.BackColor = System.Drawing.Color.Transparent;
			this.tabGeneral.Controls.Add(this.groupAccident);
			this.tabGeneral.Controls.Add(this.groupAttachments);
			this.tabGeneral.Controls.Add(this.groupAttachedImages);
			this.tabGeneral.Controls.Add(this.groupReferral);
			this.tabGeneral.Controls.Add(this.groupProsth);
			this.tabGeneral.Controls.Add(this.comboEmployRelated);
			this.tabGeneral.Controls.Add(this.groupOrtho);
			this.tabGeneral.Controls.Add(this.labelNote);
			this.tabGeneral.Controls.Add(this.textNote);
			this.tabGeneral.Controls.Add(this.comboPlaceService);
			this.tabGeneral.Controls.Add(this.label48);
			this.tabGeneral.Controls.Add(this.label49);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Size = new System.Drawing.Size(968, 352);
			this.tabGeneral.TabIndex = 2;
			this.tabGeneral.Text = "General";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// groupAccident
			// 
			this.groupAccident.Controls.Add(this.comboAccident);
			this.groupAccident.Controls.Add(this.label44);
			this.groupAccident.Controls.Add(this.textAccidentDate);
			this.groupAccident.Controls.Add(this.label42);
			this.groupAccident.Controls.Add(this.textAccidentST);
			this.groupAccident.Controls.Add(this.labelAccidentST);
			this.groupAccident.Location = new System.Drawing.Point(3, 165);
			this.groupAccident.Name = "groupAccident";
			this.groupAccident.Size = new System.Drawing.Size(286, 79);
			this.groupAccident.TabIndex = 149;
			this.groupAccident.TabStop = false;
			this.groupAccident.Text = "Accident";
			// 
			// comboAccident
			// 
			this.comboAccident.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboAccident.FormattingEnabled = true;
			this.comboAccident.Location = new System.Drawing.Point(136, 14);
			this.comboAccident.Name = "comboAccident";
			this.comboAccident.Size = new System.Drawing.Size(101, 21);
			this.comboAccident.TabIndex = 142;
			// 
			// label44
			// 
			this.label44.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label44.Location = new System.Drawing.Point(17, 36);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(117, 17);
			this.label44.TabIndex = 130;
			this.label44.Text = "Accident Date";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textAccidentDate
			// 
			this.textAccidentDate.Location = new System.Drawing.Point(136, 35);
			this.textAccidentDate.Name = "textAccidentDate";
			this.textAccidentDate.Size = new System.Drawing.Size(75, 20);
			this.textAccidentDate.TabIndex = 128;
			// 
			// label42
			// 
			this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label42.Location = new System.Drawing.Point(17, 15);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(117, 17);
			this.label42.TabIndex = 143;
			this.label42.Text = "Accident Related";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textAccidentST
			// 
			this.textAccidentST.Location = new System.Drawing.Point(136, 55);
			this.textAccidentST.Name = "textAccidentST";
			this.textAccidentST.Size = new System.Drawing.Size(30, 20);
			this.textAccidentST.TabIndex = 129;
			// 
			// labelAccidentST
			// 
			this.labelAccidentST.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelAccidentST.Location = new System.Drawing.Point(17, 56);
			this.labelAccidentST.Name = "labelAccidentST";
			this.labelAccidentST.Size = new System.Drawing.Size(117, 17);
			this.labelAccidentST.TabIndex = 134;
			this.labelAccidentST.Text = "Accident State";
			this.labelAccidentST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupAttachments
			// 
			this.groupAttachments.Controls.Add(this.label65);
			this.groupAttachments.Controls.Add(this.textAttachID);
			this.groupAttachments.Controls.Add(this.label64);
			this.groupAttachments.Controls.Add(this.radioAttachElect);
			this.groupAttachments.Controls.Add(this.radioAttachMail);
			this.groupAttachments.Controls.Add(this.checkAttachMisc);
			this.groupAttachments.Controls.Add(this.checkAttachPerio);
			this.groupAttachments.Controls.Add(this.checkAttachNarrative);
			this.groupAttachments.Controls.Add(this.checkAttachEoB);
			this.groupAttachments.Controls.Add(this.label63);
			this.groupAttachments.Controls.Add(this.textAttachModels);
			this.groupAttachments.Controls.Add(this.label62);
			this.groupAttachments.Controls.Add(this.textAttachImages);
			this.groupAttachments.Controls.Add(this.labelRadiographs);
			this.groupAttachments.Controls.Add(this.textRadiographs);
			this.groupAttachments.Location = new System.Drawing.Point(629, 96);
			this.groupAttachments.Name = "groupAttachments";
			this.groupAttachments.Size = new System.Drawing.Size(319, 178);
			this.groupAttachments.TabIndex = 148;
			this.groupAttachments.TabStop = false;
			this.groupAttachments.Text = "Attachments";
			// 
			// label65
			// 
			this.label65.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label65.Location = new System.Drawing.Point(4, 16);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(313, 18);
			this.label65.TabIndex = 152;
			this.label65.Text = "The attachments indicated here must be sent separately.";
			// 
			// textAttachID
			// 
			this.textAttachID.Location = new System.Drawing.Point(171, 152);
			this.textAttachID.Name = "textAttachID";
			this.textAttachID.Size = new System.Drawing.Size(142, 20);
			this.textAttachID.TabIndex = 133;
			// 
			// label64
			// 
			this.label64.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label64.Location = new System.Drawing.Point(170, 120);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(141, 29);
			this.label64.TabIndex = 134;
			this.label64.Text = "Attachment ID Number\r\n(example: NEA#1234567)";
			this.label64.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// radioAttachElect
			// 
			this.radioAttachElect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioAttachElect.Location = new System.Drawing.Point(171, 59);
			this.radioAttachElect.Name = "radioAttachElect";
			this.radioAttachElect.Size = new System.Drawing.Size(104, 16);
			this.radioAttachElect.TabIndex = 129;
			this.radioAttachElect.Text = "Electronically";
			// 
			// radioAttachMail
			// 
			this.radioAttachMail.Checked = true;
			this.radioAttachMail.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radioAttachMail.Location = new System.Drawing.Point(171, 39);
			this.radioAttachMail.Name = "radioAttachMail";
			this.radioAttachMail.Size = new System.Drawing.Size(104, 16);
			this.radioAttachMail.TabIndex = 128;
			this.radioAttachMail.TabStop = true;
			this.radioAttachMail.Text = "By Mail";
			// 
			// checkAttachMisc
			// 
			this.checkAttachMisc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkAttachMisc.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkAttachMisc.Location = new System.Drawing.Point(9, 154);
			this.checkAttachMisc.Name = "checkAttachMisc";
			this.checkAttachMisc.Size = new System.Drawing.Size(112, 18);
			this.checkAttachMisc.TabIndex = 125;
			this.checkAttachMisc.Text = "Misc Support Data";
			this.checkAttachMisc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkAttachPerio
			// 
			this.checkAttachPerio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkAttachPerio.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkAttachPerio.Location = new System.Drawing.Point(31, 137);
			this.checkAttachPerio.Name = "checkAttachPerio";
			this.checkAttachPerio.Size = new System.Drawing.Size(90, 18);
			this.checkAttachPerio.TabIndex = 124;
			this.checkAttachPerio.Text = "Perio Chart";
			this.checkAttachPerio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkAttachNarrative
			// 
			this.checkAttachNarrative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkAttachNarrative.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkAttachNarrative.Location = new System.Drawing.Point(31, 120);
			this.checkAttachNarrative.Name = "checkAttachNarrative";
			this.checkAttachNarrative.Size = new System.Drawing.Size(90, 18);
			this.checkAttachNarrative.TabIndex = 123;
			this.checkAttachNarrative.Text = "Narrative";
			this.checkAttachNarrative.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkAttachEoB
			// 
			this.checkAttachEoB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkAttachEoB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkAttachEoB.Location = new System.Drawing.Point(31, 103);
			this.checkAttachEoB.Name = "checkAttachEoB";
			this.checkAttachEoB.Size = new System.Drawing.Size(90, 18);
			this.checkAttachEoB.TabIndex = 122;
			this.checkAttachEoB.Text = "EoB";
			this.checkAttachEoB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label63
			// 
			this.label63.Location = new System.Drawing.Point(28, 81);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(79, 18);
			this.label63.TabIndex = 121;
			this.label63.Text = "Models";
			this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textAttachModels
			// 
			this.textAttachModels.ForeColor = System.Drawing.SystemColors.WindowText;
			this.textAttachModels.Location = new System.Drawing.Point(108, 81);
			this.textAttachModels.MaxVal = 255;
			this.textAttachModels.MinVal = 0;
			this.textAttachModels.Name = "textAttachModels";
			this.textAttachModels.Size = new System.Drawing.Size(39, 20);
			this.textAttachModels.TabIndex = 120;
			this.textAttachModels.Text = "0";
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(28, 60);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(79, 18);
			this.label62.TabIndex = 119;
			this.label62.Text = "Oral Images";
			this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textAttachImages
			// 
			this.textAttachImages.ForeColor = System.Drawing.SystemColors.WindowText;
			this.textAttachImages.Location = new System.Drawing.Point(108, 60);
			this.textAttachImages.MaxVal = 255;
			this.textAttachImages.MinVal = 0;
			this.textAttachImages.Name = "textAttachImages";
			this.textAttachImages.Size = new System.Drawing.Size(39, 20);
			this.textAttachImages.TabIndex = 118;
			this.textAttachImages.Text = "0";
			// 
			// textRadiographs
			// 
			this.textRadiographs.ForeColor = System.Drawing.SystemColors.WindowText;
			this.textRadiographs.Location = new System.Drawing.Point(108, 39);
			this.textRadiographs.MaxVal = 255;
			this.textRadiographs.MinVal = 0;
			this.textRadiographs.Name = "textRadiographs";
			this.textRadiographs.Size = new System.Drawing.Size(39, 20);
			this.textRadiographs.TabIndex = 116;
			this.textRadiographs.Text = "0";
			// 
			// groupAttachedImages
			// 
			this.groupAttachedImages.Controls.Add(this.butExport);
			this.groupAttachedImages.Controls.Add(this.butAttachAdd);
			this.groupAttachedImages.Controls.Add(this.butAttachPerio);
			this.groupAttachedImages.Controls.Add(this.label61);
			this.groupAttachedImages.Controls.Add(this.listAttachments);
			this.groupAttachedImages.Location = new System.Drawing.Point(629, 283);
			this.groupAttachedImages.Name = "groupAttachedImages";
			this.groupAttachedImages.Size = new System.Drawing.Size(319, 143);
			this.groupAttachedImages.TabIndex = 147;
			this.groupAttachedImages.TabStop = false;
			this.groupAttachedImages.Text = "Attached Images";
			// 
			// butExport
			// 
			this.butExport.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butExport.Autosize = true;
			this.butExport.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butExport.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butExport.CornerRadius = 4F;
			this.butExport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.butExport.Location = new System.Drawing.Point(252, 42);
			this.butExport.Name = "butExport";
			this.butExport.Size = new System.Drawing.Size(62, 24);
			this.butExport.TabIndex = 150;
			this.butExport.Text = "Export";
			this.butExport.Click += new System.EventHandler(this.butExport_Click);
			// 
			// butAttachAdd
			// 
			this.butAttachAdd.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAttachAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butAttachAdd.Autosize = true;
			this.butAttachAdd.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAttachAdd.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAttachAdd.CornerRadius = 4F;
			this.butAttachAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.butAttachAdd.Location = new System.Drawing.Point(122, 42);
			this.butAttachAdd.Name = "butAttachAdd";
			this.butAttachAdd.Size = new System.Drawing.Size(62, 24);
			this.butAttachAdd.TabIndex = 147;
			this.butAttachAdd.Text = "Add";
			this.butAttachAdd.Click += new System.EventHandler(this.butAttachAdd_Click);
			// 
			// butAttachPerio
			// 
			this.butAttachPerio.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butAttachPerio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butAttachPerio.Autosize = true;
			this.butAttachPerio.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butAttachPerio.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butAttachPerio.CornerRadius = 4F;
			this.butAttachPerio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.butAttachPerio.Location = new System.Drawing.Point(187, 42);
			this.butAttachPerio.Name = "butAttachPerio";
			this.butAttachPerio.Size = new System.Drawing.Size(62, 24);
			this.butAttachPerio.TabIndex = 146;
			this.butAttachPerio.Text = "Perio";
			this.butAttachPerio.Click += new System.EventHandler(this.butAttachPerio_Click);
			// 
			// label61
			// 
			this.label61.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label61.Location = new System.Drawing.Point(7, 16);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(282, 30);
			this.label61.TabIndex = 151;
			this.label61.Text = "These images will NOT be automatically sent with an electronic claim.";
			// 
			// listAttachments
			// 
			this.listAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listAttachments.FormattingEnabled = true;
			this.listAttachments.Location = new System.Drawing.Point(10, 68);
			this.listAttachments.Name = "listAttachments";
			this.listAttachments.Size = new System.Drawing.Size(304, 69);
			this.listAttachments.TabIndex = 149;
			this.listAttachments.DoubleClick += new System.EventHandler(this.listAttachments_DoubleClick);
			this.listAttachments.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listAttachments_MouseDown);
			// 
			// groupReferral
			// 
			this.groupReferral.Controls.Add(this.label45);
			this.groupReferral.Controls.Add(this.textRefProv);
			this.groupReferral.Controls.Add(this.butReferralEdit);
			this.groupReferral.Controls.Add(this.label47);
			this.groupReferral.Controls.Add(this.butReferralNone);
			this.groupReferral.Controls.Add(this.butReferralSelect);
			this.groupReferral.Controls.Add(this.textRefNum);
			this.groupReferral.Controls.Add(this.label46);
			this.groupReferral.Location = new System.Drawing.Point(308, 118);
			this.groupReferral.Name = "groupReferral";
			this.groupReferral.Size = new System.Drawing.Size(297, 118);
			this.groupReferral.TabIndex = 118;
			this.groupReferral.TabStop = false;
			this.groupReferral.Text = "Claim Referral";
			// 
			// label45
			// 
			this.label45.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label45.Location = new System.Drawing.Point(10, 16);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(282, 30);
			this.label45.TabIndex = 133;
			this.label45.Text = "Only enter referring provider and referral number if required by your insurance c" +
    "arrier.";
			// 
			// textRefProv
			// 
			this.textRefProv.BackColor = System.Drawing.SystemColors.Window;
			this.textRefProv.Location = new System.Drawing.Point(109, 49);
			this.textRefProv.Name = "textRefProv";
			this.textRefProv.ReadOnly = true;
			this.textRefProv.Size = new System.Drawing.Size(175, 20);
			this.textRefProv.TabIndex = 139;
			// 
			// butReferralEdit
			// 
			this.butReferralEdit.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butReferralEdit.Autosize = true;
			this.butReferralEdit.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butReferralEdit.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butReferralEdit.CornerRadius = 4F;
			this.butReferralEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.butReferralEdit.Location = new System.Drawing.Point(227, 70);
			this.butReferralEdit.Name = "butReferralEdit";
			this.butReferralEdit.Size = new System.Drawing.Size(57, 24);
			this.butReferralEdit.TabIndex = 144;
			this.butReferralEdit.Text = "Edit";
			this.butReferralEdit.Click += new System.EventHandler(this.butReferralEdit_Click);
			// 
			// label47
			// 
			this.label47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label47.Location = new System.Drawing.Point(9, 51);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(99, 14);
			this.label47.TabIndex = 131;
			this.label47.Text = "Referring Provider";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butReferralNone
			// 
			this.butReferralNone.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butReferralNone.Autosize = true;
			this.butReferralNone.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butReferralNone.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butReferralNone.CornerRadius = 4F;
			this.butReferralNone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.butReferralNone.Location = new System.Drawing.Point(109, 70);
			this.butReferralNone.Name = "butReferralNone";
			this.butReferralNone.Size = new System.Drawing.Size(57, 24);
			this.butReferralNone.TabIndex = 135;
			this.butReferralNone.Text = "&None";
			this.butReferralNone.Click += new System.EventHandler(this.butReferralNone_Click);
			// 
			// butReferralSelect
			// 
			this.butReferralSelect.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butReferralSelect.Autosize = true;
			this.butReferralSelect.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butReferralSelect.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butReferralSelect.CornerRadius = 4F;
			this.butReferralSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.butReferralSelect.Location = new System.Drawing.Point(168, 70);
			this.butReferralSelect.Name = "butReferralSelect";
			this.butReferralSelect.Size = new System.Drawing.Size(57, 24);
			this.butReferralSelect.TabIndex = 138;
			this.butReferralSelect.Text = "Select";
			this.butReferralSelect.Click += new System.EventHandler(this.butReferralSelect_Click);
			// 
			// textRefNum
			// 
			this.textRefNum.Location = new System.Drawing.Point(109, 95);
			this.textRefNum.Name = "textRefNum";
			this.textRefNum.Size = new System.Drawing.Size(175, 20);
			this.textRefNum.TabIndex = 127;
			// 
			// label46
			// 
			this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label46.Location = new System.Drawing.Point(18, 97);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(90, 18);
			this.label46.TabIndex = 132;
			this.label46.Text = "Referral Number";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboEmployRelated
			// 
			this.comboEmployRelated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboEmployRelated.FormattingEnabled = true;
			this.comboEmployRelated.Location = new System.Drawing.Point(139, 143);
			this.comboEmployRelated.Name = "comboEmployRelated";
			this.comboEmployRelated.Size = new System.Drawing.Size(150, 21);
			this.comboEmployRelated.TabIndex = 141;
			// 
			// textNote
			// 
			this.textNote.AcceptsTab = true;
			this.textNote.DetectUrls = false;
			this.textNote.Location = new System.Drawing.Point(629, 22);
			this.textNote.MaxLength = 255;
			this.textNote.Name = "textNote";
			this.textNote.QuickPasteType = OpenDentBusiness.QuickPasteType.Claim;
			this.textNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.textNote.Size = new System.Drawing.Size(319, 68);
			this.textNote.TabIndex = 118;
			this.textNote.Text = "";
			// 
			// comboPlaceService
			// 
			this.comboPlaceService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboPlaceService.FormattingEnabled = true;
			this.comboPlaceService.Location = new System.Drawing.Point(139, 122);
			this.comboPlaceService.Name = "comboPlaceService";
			this.comboPlaceService.Size = new System.Drawing.Size(150, 21);
			this.comboPlaceService.TabIndex = 140;
			// 
			// label48
			// 
			this.label48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label48.Location = new System.Drawing.Point(20, 123);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(117, 17);
			this.label48.TabIndex = 136;
			this.label48.Text = "Place of Service";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label49
			// 
			this.label49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label49.Location = new System.Drawing.Point(20, 144);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(117, 17);
			this.label49.TabIndex = 137;
			this.label49.Text = "Employment Related";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabMisc
			// 
			this.tabMisc.Controls.Add(this.label94);
			this.tabMisc.Controls.Add(this.label93);
			this.tabMisc.Controls.Add(this.label88);
			this.tabMisc.Controls.Add(this.textOrigRefNum);
			this.tabMisc.Controls.Add(this.label90);
			this.tabMisc.Controls.Add(this.labelPriorAuth);
			this.tabMisc.Controls.Add(this.label92);
			this.tabMisc.Controls.Add(this.textPriorAuth);
			this.tabMisc.Controls.Add(this.labelSpecialProgram);
			this.tabMisc.Controls.Add(this.textClaimIdentifier);
			this.tabMisc.Controls.Add(this.comboSpecialProgram);
			this.tabMisc.Controls.Add(this.labelCustomTracking);
			this.tabMisc.Controls.Add(this.label91);
			this.tabMisc.Controls.Add(this.comboCustomTracking);
			this.tabMisc.Controls.Add(this.comboCorrectionType);
			this.tabMisc.Location = new System.Drawing.Point(4, 22);
			this.tabMisc.Name = "tabMisc";
			this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
			this.tabMisc.Size = new System.Drawing.Size(968, 352);
			this.tabMisc.TabIndex = 4;
			this.tabMisc.Text = "Misc";
			this.tabMisc.UseVisualStyleBackColor = true;
			// 
			// label94
			// 
			this.label94.Location = new System.Drawing.Point(291, 69);
			this.label94.Name = "label94";
			this.label94.Size = new System.Drawing.Size(165, 16);
			this.label94.TabIndex = 162;
			this.label94.Text = "Denti-Cal PDCN";
			// 
			// label93
			// 
			this.label93.Location = new System.Drawing.Point(291, 89);
			this.label93.Name = "label93";
			this.label93.Size = new System.Drawing.Size(165, 16);
			this.label93.TabIndex = 161;
			this.label93.Text = "Denti-Cal Replacement DCN";
			// 
			// label88
			// 
			this.label88.Location = new System.Drawing.Point(291, 28);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(165, 16);
			this.label88.TabIndex = 160;
			this.label88.Text = "Denti-Cal NOA DCN";
			// 
			// textOrigRefNum
			// 
			this.textOrigRefNum.Location = new System.Drawing.Point(139, 85);
			this.textOrigRefNum.Name = "textOrigRefNum";
			this.textOrigRefNum.Size = new System.Drawing.Size(150, 20);
			this.textOrigRefNum.TabIndex = 158;
			// 
			// label90
			// 
			this.label90.Location = new System.Drawing.Point(40, 6);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(97, 17);
			this.label90.TabIndex = 154;
			this.label90.Text = "Correction Type";
			this.label90.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelPriorAuth
			// 
			this.labelPriorAuth.Location = new System.Drawing.Point(3, 28);
			this.labelPriorAuth.Name = "labelPriorAuth";
			this.labelPriorAuth.Size = new System.Drawing.Size(134, 16);
			this.labelPriorAuth.TabIndex = 142;
			this.labelPriorAuth.Text = "Prior Authorization (rare)";
			this.labelPriorAuth.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label92
			// 
			this.label92.Location = new System.Drawing.Point(3, 89);
			this.label92.Name = "label92";
			this.label92.Size = new System.Drawing.Size(137, 16);
			this.label92.TabIndex = 159;
			this.label92.Text = "Original Refrerence Num";
			this.label92.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textPriorAuth
			// 
			this.textPriorAuth.Location = new System.Drawing.Point(139, 24);
			this.textPriorAuth.Name = "textPriorAuth";
			this.textPriorAuth.Size = new System.Drawing.Size(150, 20);
			this.textPriorAuth.TabIndex = 141;
			// 
			// labelSpecialProgram
			// 
			this.labelSpecialProgram.Location = new System.Drawing.Point(40, 47);
			this.labelSpecialProgram.Name = "labelSpecialProgram";
			this.labelSpecialProgram.Size = new System.Drawing.Size(97, 17);
			this.labelSpecialProgram.TabIndex = 143;
			this.labelSpecialProgram.Text = "Special Program";
			this.labelSpecialProgram.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textClaimIdentifier
			// 
			this.textClaimIdentifier.Location = new System.Drawing.Point(139, 65);
			this.textClaimIdentifier.Name = "textClaimIdentifier";
			this.textClaimIdentifier.Size = new System.Drawing.Size(150, 20);
			this.textClaimIdentifier.TabIndex = 156;
			// 
			// comboSpecialProgram
			// 
			this.comboSpecialProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSpecialProgram.Location = new System.Drawing.Point(139, 44);
			this.comboSpecialProgram.MaxDropDownItems = 100;
			this.comboSpecialProgram.Name = "comboSpecialProgram";
			this.comboSpecialProgram.Size = new System.Drawing.Size(150, 21);
			this.comboSpecialProgram.TabIndex = 144;
			// 
			// labelCustomTracking
			// 
			this.labelCustomTracking.Location = new System.Drawing.Point(40, 108);
			this.labelCustomTracking.Name = "labelCustomTracking";
			this.labelCustomTracking.Size = new System.Drawing.Size(97, 17);
			this.labelCustomTracking.TabIndex = 152;
			this.labelCustomTracking.Text = "Custom Tracking";
			this.labelCustomTracking.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label91
			// 
			this.label91.Location = new System.Drawing.Point(3, 69);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(137, 16);
			this.label91.TabIndex = 157;
			this.label91.Text = "Claim Identifier (CLM01)";
			this.label91.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboCustomTracking
			// 
			this.comboCustomTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCustomTracking.Location = new System.Drawing.Point(139, 105);
			this.comboCustomTracking.MaxDropDownItems = 100;
			this.comboCustomTracking.Name = "comboCustomTracking";
			this.comboCustomTracking.Size = new System.Drawing.Size(150, 21);
			this.comboCustomTracking.TabIndex = 153;
			// 
			// comboCorrectionType
			// 
			this.comboCorrectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboCorrectionType.Location = new System.Drawing.Point(139, 3);
			this.comboCorrectionType.MaxDropDownItems = 100;
			this.comboCorrectionType.Name = "comboCorrectionType";
			this.comboCorrectionType.Size = new System.Drawing.Size(150, 21);
			this.comboCorrectionType.TabIndex = 155;
			// 
			// tabUB04
			// 
			this.tabUB04.AutoScroll = true;
			this.tabUB04.BackColor = System.Drawing.Color.Transparent;
			this.tabUB04.Controls.Add(this.groupUb04);
			this.tabUB04.Controls.Add(this.butNoneProvOrdering);
			this.tabUB04.Controls.Add(this.comboProvNumOrdering);
			this.tabUB04.Controls.Add(this.butPickProvOrdering);
			this.tabUB04.Controls.Add(this.label95);
			this.tabUB04.Location = new System.Drawing.Point(4, 22);
			this.tabUB04.Name = "tabUB04";
			this.tabUB04.Padding = new System.Windows.Forms.Padding(3);
			this.tabUB04.Size = new System.Drawing.Size(968, 352);
			this.tabUB04.TabIndex = 0;
			this.tabUB04.Text = "Medical";
			this.tabUB04.UseVisualStyleBackColor = true;
			// 
			// groupUb04
			// 
			this.groupUb04.Controls.Add(this.label7);
			this.groupUb04.Controls.Add(this.groupValueCodes);
			this.groupUb04.Controls.Add(this.groupBox1);
			this.groupUb04.Controls.Add(this.textBillType);
			this.groupUb04.Controls.Add(this.label83);
			this.groupUb04.Controls.Add(this.textPatientStatus);
			this.groupUb04.Controls.Add(this.textAdmissionType);
			this.groupUb04.Controls.Add(this.label85);
			this.groupUb04.Controls.Add(this.label84);
			this.groupUb04.Controls.Add(this.textAdmissionSource);
			this.groupUb04.Location = new System.Drawing.Point(11, 33);
			this.groupUb04.Name = "groupUb04";
			this.groupUb04.Size = new System.Drawing.Size(664, 203);
			this.groupUb04.TabIndex = 283;
			this.groupUb04.TabStop = false;
			this.groupUb04.Text = "UB04";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(5, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(156, 16);
			this.label7.TabIndex = 144;
			this.label7.Text = "Type of Bill (3 digit)";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label60);
			this.groupBox1.Controls.Add(this.label59);
			this.groupBox1.Controls.Add(this.label58);
			this.groupBox1.Controls.Add(this.label57);
			this.groupBox1.Controls.Add(this.label56);
			this.groupBox1.Controls.Add(this.label55);
			this.groupBox1.Controls.Add(this.label54);
			this.groupBox1.Controls.Add(this.label53);
			this.groupBox1.Controls.Add(this.label52);
			this.groupBox1.Controls.Add(this.label51);
			this.groupBox1.Controls.Add(this.label50);
			this.groupBox1.Controls.Add(this.textCode10);
			this.groupBox1.Controls.Add(this.textCode9);
			this.groupBox1.Controls.Add(this.textCode8);
			this.groupBox1.Controls.Add(this.textCode7);
			this.groupBox1.Controls.Add(this.textCode6);
			this.groupBox1.Controls.Add(this.textCode5);
			this.groupBox1.Controls.Add(this.textCode4);
			this.groupBox1.Controls.Add(this.textCode3);
			this.groupBox1.Controls.Add(this.textCode2);
			this.groupBox1.Controls.Add(this.textCode1);
			this.groupBox1.Controls.Add(this.textCode0);
			this.groupBox1.Location = new System.Drawing.Point(213, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(433, 67);
			this.groupBox1.TabIndex = 131;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Condition Codes";
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.Location = new System.Drawing.Point(398, 19);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(19, 13);
			this.label60.TabIndex = 78;
			this.label60.Text = "28";
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(360, 19);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(19, 13);
			this.label59.TabIndex = 77;
			this.label59.Text = "27";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(322, 19);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(19, 13);
			this.label58.TabIndex = 76;
			this.label58.Text = "26";
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(284, 19);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(19, 13);
			this.label57.TabIndex = 75;
			this.label57.Text = "25";
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(246, 19);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(19, 13);
			this.label56.TabIndex = 74;
			this.label56.Text = "24";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(209, 19);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(19, 13);
			this.label55.TabIndex = 73;
			this.label55.Text = "23";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(170, 19);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(19, 13);
			this.label54.TabIndex = 72;
			this.label54.Text = "22";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(132, 19);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(19, 13);
			this.label53.TabIndex = 71;
			this.label53.Text = "21";
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(94, 19);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(19, 13);
			this.label52.TabIndex = 70;
			this.label52.Text = "20";
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(56, 19);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(19, 13);
			this.label51.TabIndex = 69;
			this.label51.Text = "19";
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.Location = new System.Drawing.Point(18, 19);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(19, 13);
			this.label50.TabIndex = 68;
			this.label50.Text = "18";
			// 
			// textCode10
			// 
			this.textCode10.Location = new System.Drawing.Point(394, 37);
			this.textCode10.MaxLength = 2;
			this.textCode10.Name = "textCode10";
			this.textCode10.Size = new System.Drawing.Size(26, 20);
			this.textCode10.TabIndex = 67;
			this.textCode10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode9
			// 
			this.textCode9.Location = new System.Drawing.Point(356, 37);
			this.textCode9.MaxLength = 2;
			this.textCode9.Name = "textCode9";
			this.textCode9.Size = new System.Drawing.Size(26, 20);
			this.textCode9.TabIndex = 66;
			this.textCode9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode8
			// 
			this.textCode8.Location = new System.Drawing.Point(318, 37);
			this.textCode8.MaxLength = 2;
			this.textCode8.Name = "textCode8";
			this.textCode8.Size = new System.Drawing.Size(26, 20);
			this.textCode8.TabIndex = 65;
			this.textCode8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode7
			// 
			this.textCode7.Location = new System.Drawing.Point(280, 37);
			this.textCode7.MaxLength = 2;
			this.textCode7.Name = "textCode7";
			this.textCode7.Size = new System.Drawing.Size(26, 20);
			this.textCode7.TabIndex = 64;
			this.textCode7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode6
			// 
			this.textCode6.Location = new System.Drawing.Point(242, 37);
			this.textCode6.MaxLength = 2;
			this.textCode6.Name = "textCode6";
			this.textCode6.Size = new System.Drawing.Size(26, 20);
			this.textCode6.TabIndex = 63;
			this.textCode6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode5
			// 
			this.textCode5.Location = new System.Drawing.Point(205, 37);
			this.textCode5.MaxLength = 2;
			this.textCode5.Name = "textCode5";
			this.textCode5.Size = new System.Drawing.Size(26, 20);
			this.textCode5.TabIndex = 62;
			this.textCode5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode4
			// 
			this.textCode4.Location = new System.Drawing.Point(166, 37);
			this.textCode4.MaxLength = 2;
			this.textCode4.Name = "textCode4";
			this.textCode4.Size = new System.Drawing.Size(26, 20);
			this.textCode4.TabIndex = 61;
			this.textCode4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode3
			// 
			this.textCode3.Location = new System.Drawing.Point(128, 37);
			this.textCode3.MaxLength = 2;
			this.textCode3.Name = "textCode3";
			this.textCode3.Size = new System.Drawing.Size(26, 20);
			this.textCode3.TabIndex = 60;
			this.textCode3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode2
			// 
			this.textCode2.Location = new System.Drawing.Point(90, 37);
			this.textCode2.MaxLength = 2;
			this.textCode2.Name = "textCode2";
			this.textCode2.Size = new System.Drawing.Size(26, 20);
			this.textCode2.TabIndex = 59;
			this.textCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode1
			// 
			this.textCode1.Location = new System.Drawing.Point(52, 37);
			this.textCode1.MaxLength = 2;
			this.textCode1.Name = "textCode1";
			this.textCode1.Size = new System.Drawing.Size(26, 20);
			this.textCode1.TabIndex = 58;
			this.textCode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textCode0
			// 
			this.textCode0.Location = new System.Drawing.Point(14, 37);
			this.textCode0.MaxLength = 2;
			this.textCode0.Name = "textCode0";
			this.textCode0.Size = new System.Drawing.Size(26, 20);
			this.textCode0.TabIndex = 57;
			this.textCode0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBillType
			// 
			this.textBillType.Location = new System.Drawing.Point(162, 12);
			this.textBillType.Name = "textBillType";
			this.textBillType.Size = new System.Drawing.Size(47, 20);
			this.textBillType.TabIndex = 143;
			// 
			// label83
			// 
			this.label83.Location = new System.Drawing.Point(5, 39);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(156, 16);
			this.label83.TabIndex = 146;
			this.label83.Text = "Admission Type (1 digit)";
			this.label83.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textPatientStatus
			// 
			this.textPatientStatus.Location = new System.Drawing.Point(162, 81);
			this.textPatientStatus.Name = "textPatientStatus";
			this.textPatientStatus.Size = new System.Drawing.Size(47, 20);
			this.textPatientStatus.TabIndex = 149;
			// 
			// textAdmissionType
			// 
			this.textAdmissionType.Location = new System.Drawing.Point(162, 35);
			this.textAdmissionType.Name = "textAdmissionType";
			this.textAdmissionType.Size = new System.Drawing.Size(47, 20);
			this.textAdmissionType.TabIndex = 145;
			// 
			// label85
			// 
			this.label85.Location = new System.Drawing.Point(5, 85);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(156, 16);
			this.label85.TabIndex = 150;
			this.label85.Text = "Patient Status (2 digit)";
			this.label85.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label84
			// 
			this.label84.Location = new System.Drawing.Point(5, 62);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(156, 16);
			this.label84.TabIndex = 148;
			this.label84.Text = "Admission Source (1 char)";
			this.label84.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textAdmissionSource
			// 
			this.textAdmissionSource.Location = new System.Drawing.Point(162, 58);
			this.textAdmissionSource.Name = "textAdmissionSource";
			this.textAdmissionSource.Size = new System.Drawing.Size(47, 20);
			this.textAdmissionSource.TabIndex = 147;
			// 
			// butNoneProvOrdering
			// 
			this.butNoneProvOrdering.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butNoneProvOrdering.Autosize = false;
			this.butNoneProvOrdering.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butNoneProvOrdering.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butNoneProvOrdering.CornerRadius = 2F;
			this.butNoneProvOrdering.Location = new System.Drawing.Point(451, 8);
			this.butNoneProvOrdering.Name = "butNoneProvOrdering";
			this.butNoneProvOrdering.Size = new System.Drawing.Size(44, 21);
			this.butNoneProvOrdering.TabIndex = 282;
			this.butNoneProvOrdering.Text = "None";
			this.butNoneProvOrdering.Click += new System.EventHandler(this.butNoneProvOrdering_Click);
			// 
			// comboProvNumOrdering
			// 
			this.comboProvNumOrdering.Location = new System.Drawing.Point(173, 8);
			this.comboProvNumOrdering.MaxDropDownItems = 30;
			this.comboProvNumOrdering.Name = "comboProvNumOrdering";
			this.comboProvNumOrdering.Size = new System.Drawing.Size(254, 21);
			this.comboProvNumOrdering.TabIndex = 280;
			this.comboProvNumOrdering.SelectionChangeCommitted += new System.EventHandler(this.comboProvNumOrdering_SelectionChangeCommitted);
			// 
			// butPickProvOrdering
			// 
			this.butPickProvOrdering.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPickProvOrdering.Autosize = false;
			this.butPickProvOrdering.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPickProvOrdering.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPickProvOrdering.CornerRadius = 2F;
			this.butPickProvOrdering.Location = new System.Drawing.Point(430, 8);
			this.butPickProvOrdering.Name = "butPickProvOrdering";
			this.butPickProvOrdering.Size = new System.Drawing.Size(18, 21);
			this.butPickProvOrdering.TabIndex = 281;
			this.butPickProvOrdering.Text = "...";
			this.butPickProvOrdering.Click += new System.EventHandler(this.butPickProvOrdering_Click);
			// 
			// label95
			// 
			this.label95.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label95.Location = new System.Drawing.Point(6, 8);
			this.label95.Name = "label95";
			this.label95.Size = new System.Drawing.Size(167, 17);
			this.label95.TabIndex = 279;
			this.label95.Text = "Ordering Provider Override";
			this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabCanadian
			// 
			this.tabCanadian.AutoScroll = true;
			this.tabCanadian.Controls.Add(this.textCanadaTransRefNum);
			this.tabCanadian.Controls.Add(this.groupCanadaOrthoPredeterm);
			this.tabCanadian.Controls.Add(this.label76);
			this.tabCanadian.Controls.Add(this.butReverse);
			this.tabCanadian.Controls.Add(this.textMissingTeeth);
			this.tabCanadian.Controls.Add(this.label75);
			this.tabCanadian.Controls.Add(this.label74);
			this.tabCanadian.Controls.Add(this.listExtractedTeeth);
			this.tabCanadian.Controls.Add(this.checkCanadianIsOrtho);
			this.tabCanadian.Controls.Add(this.label43);
			this.tabCanadian.Controls.Add(this.butMissingTeethHelp);
			this.tabCanadian.Controls.Add(this.groupBox6);
			this.tabCanadian.Controls.Add(this.groupBox7);
			this.tabCanadian.Controls.Add(this.groupBox8);
			this.tabCanadian.Controls.Add(this.groupBox9);
			this.tabCanadian.Controls.Add(this.textCanadianAccidentDate);
			this.tabCanadian.Location = new System.Drawing.Point(4, 22);
			this.tabCanadian.Name = "tabCanadian";
			this.tabCanadian.Size = new System.Drawing.Size(968, 352);
			this.tabCanadian.TabIndex = 3;
			this.tabCanadian.Text = "Canadian";
			this.tabCanadian.UseVisualStyleBackColor = true;
			// 
			// textCanadaTransRefNum
			// 
			this.textCanadaTransRefNum.Location = new System.Drawing.Point(96, 122);
			this.textCanadaTransRefNum.Name = "textCanadaTransRefNum";
			this.textCanadaTransRefNum.ReadOnly = true;
			this.textCanadaTransRefNum.Size = new System.Drawing.Size(100, 20);
			this.textCanadaTransRefNum.TabIndex = 148;
			// 
			// groupCanadaOrthoPredeterm
			// 
			this.groupCanadaOrthoPredeterm.Controls.Add(this.textCanadaExpectedPayCycle);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.textCanadaAnticipatedPayAmount);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.label82);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.textCanadaNumPaymentsAnticipated);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.label81);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.textCanadaTreatDuration);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.label80);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.label79);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.textCanadaInitialPayment);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.label78);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.label77);
			this.groupCanadaOrthoPredeterm.Controls.Add(this.textDateCanadaEstTreatStartDate);
			this.groupCanadaOrthoPredeterm.Enabled = false;
			this.groupCanadaOrthoPredeterm.Location = new System.Drawing.Point(7, 187);
			this.groupCanadaOrthoPredeterm.Name = "groupCanadaOrthoPredeterm";
			this.groupCanadaOrthoPredeterm.Size = new System.Drawing.Size(550, 104);
			this.groupCanadaOrthoPredeterm.TabIndex = 147;
			this.groupCanadaOrthoPredeterm.TabStop = false;
			this.groupCanadaOrthoPredeterm.Text = "Ortho Treatment (Predetermination Only)";
			// 
			// textCanadaExpectedPayCycle
			// 
			this.textCanadaExpectedPayCycle.Location = new System.Drawing.Point(196, 75);
			this.textCanadaExpectedPayCycle.Name = "textCanadaExpectedPayCycle";
			this.textCanadaExpectedPayCycle.Size = new System.Drawing.Size(75, 20);
			this.textCanadaExpectedPayCycle.TabIndex = 158;
			// 
			// textCanadaAnticipatedPayAmount
			// 
			this.textCanadaAnticipatedPayAmount.Location = new System.Drawing.Point(466, 75);
			this.textCanadaAnticipatedPayAmount.Name = "textCanadaAnticipatedPayAmount";
			this.textCanadaAnticipatedPayAmount.Size = new System.Drawing.Size(75, 20);
			this.textCanadaAnticipatedPayAmount.TabIndex = 157;
			// 
			// label82
			// 
			this.label82.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label82.Location = new System.Drawing.Point(280, 74);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(180, 20);
			this.label82.TabIndex = 156;
			this.label82.Text = "Anticipated Pay Amount";
			this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textCanadaNumPaymentsAnticipated
			// 
			this.textCanadaNumPaymentsAnticipated.Location = new System.Drawing.Point(466, 45);
			this.textCanadaNumPaymentsAnticipated.Name = "textCanadaNumPaymentsAnticipated";
			this.textCanadaNumPaymentsAnticipated.Size = new System.Drawing.Size(75, 20);
			this.textCanadaNumPaymentsAnticipated.TabIndex = 155;
			// 
			// label81
			// 
			this.label81.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label81.Location = new System.Drawing.Point(277, 46);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(183, 20);
			this.label81.TabIndex = 154;
			this.label81.Text = "Number of Payments Anticipated";
			this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textCanadaTreatDuration
			// 
			this.textCanadaTreatDuration.Location = new System.Drawing.Point(466, 19);
			this.textCanadaTreatDuration.Name = "textCanadaTreatDuration";
			this.textCanadaTreatDuration.Size = new System.Drawing.Size(75, 20);
			this.textCanadaTreatDuration.TabIndex = 153;
			// 
			// label80
			// 
			this.label80.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label80.Location = new System.Drawing.Point(280, 19);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(180, 20);
			this.label80.TabIndex = 152;
			this.label80.Text = "Treatment Duration (Months)";
			this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label79
			// 
			this.label79.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label79.Location = new System.Drawing.Point(8, 74);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(182, 20);
			this.label79.TabIndex = 150;
			this.label79.Text = "Expected Payment Cycle (Months)";
			this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textCanadaInitialPayment
			// 
			this.textCanadaInitialPayment.Location = new System.Drawing.Point(196, 46);
			this.textCanadaInitialPayment.Name = "textCanadaInitialPayment";
			this.textCanadaInitialPayment.Size = new System.Drawing.Size(75, 20);
			this.textCanadaInitialPayment.TabIndex = 149;
			// 
			// label78
			// 
			this.label78.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label78.Location = new System.Drawing.Point(8, 45);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(174, 20);
			this.label78.TabIndex = 141;
			this.label78.Text = "Initial Payment";
			this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label77
			// 
			this.label77.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label77.Location = new System.Drawing.Point(5, 20);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(177, 20);
			this.label77.TabIndex = 140;
			this.label77.Text = "Estimated Treatment Start Date";
			this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDateCanadaEstTreatStartDate
			// 
			this.textDateCanadaEstTreatStartDate.Location = new System.Drawing.Point(196, 20);
			this.textDateCanadaEstTreatStartDate.Name = "textDateCanadaEstTreatStartDate";
			this.textDateCanadaEstTreatStartDate.Size = new System.Drawing.Size(75, 20);
			this.textDateCanadaEstTreatStartDate.TabIndex = 139;
			// 
			// label76
			// 
			this.label76.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label76.Location = new System.Drawing.Point(9, 122);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(82, 16);
			this.label76.TabIndex = 146;
			this.label76.Text = "Trans Ref Num";
			this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butReverse
			// 
			this.butReverse.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butReverse.Autosize = true;
			this.butReverse.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butReverse.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butReverse.CornerRadius = 4F;
			this.butReverse.Enabled = false;
			this.butReverse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butReverse.Location = new System.Drawing.Point(202, 120);
			this.butReverse.Name = "butReverse";
			this.butReverse.Size = new System.Drawing.Size(59, 24);
			this.butReverse.TabIndex = 138;
			this.butReverse.Text = "Reverse";
			this.butReverse.Click += new System.EventHandler(this.butReverse_Click);
			// 
			// textMissingTeeth
			// 
			this.textMissingTeeth.Location = new System.Drawing.Point(764, 142);
			this.textMissingTeeth.Multiline = true;
			this.textMissingTeeth.Name = "textMissingTeeth";
			this.textMissingTeeth.Size = new System.Drawing.Size(172, 44);
			this.textMissingTeeth.TabIndex = 144;
			// 
			// label75
			// 
			this.label75.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label75.Location = new System.Drawing.Point(762, 122);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(83, 17);
			this.label75.TabIndex = 143;
			this.label75.Text = "Missing Teeth";
			this.label75.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label74
			// 
			this.label74.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label74.Location = new System.Drawing.Point(762, 5);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(143, 17);
			this.label74.TabIndex = 142;
			this.label74.Text = "Extracted Teeth";
			this.label74.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// listExtractedTeeth
			// 
			this.listExtractedTeeth.FormattingEnabled = true;
			this.listExtractedTeeth.Location = new System.Drawing.Point(764, 24);
			this.listExtractedTeeth.Name = "listExtractedTeeth";
			this.listExtractedTeeth.Size = new System.Drawing.Size(172, 95);
			this.listExtractedTeeth.TabIndex = 141;
			// 
			// checkCanadianIsOrtho
			// 
			this.checkCanadianIsOrtho.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkCanadianIsOrtho.Location = new System.Drawing.Point(36, 158);
			this.checkCanadianIsOrtho.Name = "checkCanadianIsOrtho";
			this.checkCanadianIsOrtho.Size = new System.Drawing.Size(216, 17);
			this.checkCanadianIsOrtho.TabIndex = 140;
			this.checkCanadianIsOrtho.Text = "Treatment Required for Ortho";
			// 
			// label43
			// 
			this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label43.Location = new System.Drawing.Point(25, 85);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(117, 17);
			this.label43.TabIndex = 139;
			this.label43.Text = "Accident Date";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butMissingTeethHelp
			// 
			this.butMissingTeethHelp.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butMissingTeethHelp.Autosize = true;
			this.butMissingTeethHelp.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butMissingTeethHelp.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butMissingTeethHelp.CornerRadius = 4F;
			this.butMissingTeethHelp.Location = new System.Drawing.Point(911, 0);
			this.butMissingTeethHelp.Name = "butMissingTeethHelp";
			this.butMissingTeethHelp.Size = new System.Drawing.Size(25, 24);
			this.butMissingTeethHelp.TabIndex = 137;
			this.butMissingTeethHelp.Text = "?";
			this.butMissingTeethHelp.Click += new System.EventHandler(this.butMissingTeethHelp_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.comboMandProsth);
			this.groupBox6.Controls.Add(this.label66);
			this.groupBox6.Controls.Add(this.textDateInitialLower);
			this.groupBox6.Controls.Add(this.label67);
			this.groupBox6.Controls.Add(this.comboMandProsthMaterial);
			this.groupBox6.Controls.Add(this.label68);
			this.groupBox6.Location = new System.Drawing.Point(402, 98);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(355, 88);
			this.groupBox6.TabIndex = 13;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Mandibular Prosthesis";
			// 
			// comboMandProsth
			// 
			this.comboMandProsth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboMandProsth.FormattingEnabled = true;
			this.comboMandProsth.Location = new System.Drawing.Point(136, 11);
			this.comboMandProsth.Name = "comboMandProsth";
			this.comboMandProsth.Size = new System.Drawing.Size(213, 21);
			this.comboMandProsth.TabIndex = 14;
			this.comboMandProsth.SelectionChangeCommitted += new System.EventHandler(this.comboMandProsth_SelectionChangeCommitted);
			// 
			// label66
			// 
			this.label66.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label66.Location = new System.Drawing.Point(7, 14);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(128, 17);
			this.label66.TabIndex = 1;
			this.label66.Text = "Initial placement lower?";
			this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDateInitialLower
			// 
			this.textDateInitialLower.Location = new System.Drawing.Point(136, 36);
			this.textDateInitialLower.Name = "textDateInitialLower";
			this.textDateInitialLower.Size = new System.Drawing.Size(83, 20);
			this.textDateInitialLower.TabIndex = 2;
			// 
			// label67
			// 
			this.label67.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label67.Location = new System.Drawing.Point(72, 38);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(61, 17);
			this.label67.TabIndex = 3;
			this.label67.Text = "Initial Date";
			this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboMandProsthMaterial
			// 
			this.comboMandProsthMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboMandProsthMaterial.FormattingEnabled = true;
			this.comboMandProsthMaterial.Location = new System.Drawing.Point(136, 60);
			this.comboMandProsthMaterial.Name = "comboMandProsthMaterial";
			this.comboMandProsthMaterial.Size = new System.Drawing.Size(213, 21);
			this.comboMandProsthMaterial.TabIndex = 4;
			// 
			// label68
			// 
			this.label68.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label68.Location = new System.Drawing.Point(10, 61);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(125, 18);
			this.label68.TabIndex = 7;
			this.label68.Text = "Prosthesis Material";
			this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.comboMaxProsth);
			this.groupBox7.Controls.Add(this.label69);
			this.groupBox7.Controls.Add(this.textDateInitialUpper);
			this.groupBox7.Controls.Add(this.label70);
			this.groupBox7.Controls.Add(this.comboMaxProsthMaterial);
			this.groupBox7.Controls.Add(this.label71);
			this.groupBox7.Location = new System.Drawing.Point(402, 5);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(355, 88);
			this.groupBox7.TabIndex = 12;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Maxillary Prosthesis";
			// 
			// comboMaxProsth
			// 
			this.comboMaxProsth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboMaxProsth.FormattingEnabled = true;
			this.comboMaxProsth.Location = new System.Drawing.Point(136, 11);
			this.comboMaxProsth.Name = "comboMaxProsth";
			this.comboMaxProsth.Size = new System.Drawing.Size(213, 21);
			this.comboMaxProsth.TabIndex = 14;
			this.comboMaxProsth.SelectionChangeCommitted += new System.EventHandler(this.comboMaxProsth_SelectionChangeCommitted);
			// 
			// label69
			// 
			this.label69.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label69.Location = new System.Drawing.Point(7, 14);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(128, 17);
			this.label69.TabIndex = 1;
			this.label69.Text = "Initial placement upper?";
			this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textDateInitialUpper
			// 
			this.textDateInitialUpper.Location = new System.Drawing.Point(136, 36);
			this.textDateInitialUpper.Name = "textDateInitialUpper";
			this.textDateInitialUpper.Size = new System.Drawing.Size(83, 20);
			this.textDateInitialUpper.TabIndex = 2;
			// 
			// label70
			// 
			this.label70.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label70.Location = new System.Drawing.Point(72, 38);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(61, 17);
			this.label70.TabIndex = 3;
			this.label70.Text = "Initial Date";
			this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboMaxProsthMaterial
			// 
			this.comboMaxProsthMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboMaxProsthMaterial.FormattingEnabled = true;
			this.comboMaxProsthMaterial.Location = new System.Drawing.Point(136, 60);
			this.comboMaxProsthMaterial.Name = "comboMaxProsthMaterial";
			this.comboMaxProsthMaterial.Size = new System.Drawing.Size(213, 21);
			this.comboMaxProsthMaterial.TabIndex = 4;
			// 
			// label71
			// 
			this.label71.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label71.Location = new System.Drawing.Point(10, 61);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(125, 18);
			this.label71.TabIndex = 7;
			this.label71.Text = "Prosthesis Material";
			this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.checkImages);
			this.groupBox8.Controls.Add(this.checkXrays);
			this.groupBox8.Controls.Add(this.checkModels);
			this.groupBox8.Controls.Add(this.checkCorrespondence);
			this.groupBox8.Controls.Add(this.checkEmail);
			this.groupBox8.Location = new System.Drawing.Point(265, 80);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(128, 106);
			this.groupBox8.TabIndex = 10;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Materials Forwarded";
			// 
			// checkImages
			// 
			this.checkImages.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.checkImages.Location = new System.Drawing.Point(11, 84);
			this.checkImages.Name = "checkImages";
			this.checkImages.Size = new System.Drawing.Size(110, 17);
			this.checkImages.TabIndex = 4;
			this.checkImages.Text = "Images";
			this.checkImages.UseVisualStyleBackColor = true;
			// 
			// checkXrays
			// 
			this.checkXrays.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.checkXrays.Location = new System.Drawing.Point(11, 67);
			this.checkXrays.Name = "checkXrays";
			this.checkXrays.Size = new System.Drawing.Size(110, 17);
			this.checkXrays.TabIndex = 3;
			this.checkXrays.Text = "X-rays";
			this.checkXrays.UseVisualStyleBackColor = true;
			// 
			// checkModels
			// 
			this.checkModels.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.checkModels.Location = new System.Drawing.Point(11, 50);
			this.checkModels.Name = "checkModels";
			this.checkModels.Size = new System.Drawing.Size(110, 17);
			this.checkModels.TabIndex = 2;
			this.checkModels.Text = "Models";
			this.checkModels.UseVisualStyleBackColor = true;
			// 
			// checkCorrespondence
			// 
			this.checkCorrespondence.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.checkCorrespondence.Location = new System.Drawing.Point(11, 33);
			this.checkCorrespondence.Name = "checkCorrespondence";
			this.checkCorrespondence.Size = new System.Drawing.Size(110, 17);
			this.checkCorrespondence.TabIndex = 1;
			this.checkCorrespondence.Text = "Correspondence";
			this.checkCorrespondence.UseVisualStyleBackColor = true;
			// 
			// checkEmail
			// 
			this.checkEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.checkEmail.Location = new System.Drawing.Point(11, 16);
			this.checkEmail.Name = "checkEmail";
			this.checkEmail.Size = new System.Drawing.Size(110, 17);
			this.checkEmail.TabIndex = 0;
			this.checkEmail.Text = "E-Mail";
			this.checkEmail.UseVisualStyleBackColor = true;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.label73);
			this.groupBox9.Controls.Add(this.label72);
			this.groupBox9.Controls.Add(this.comboReferralReason);
			this.groupBox9.Controls.Add(this.textReferralProvider);
			this.groupBox9.Location = new System.Drawing.Point(7, 5);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(386, 71);
			this.groupBox9.TabIndex = 11;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Referring Provider";
			// 
			// label73
			// 
			this.label73.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label73.Location = new System.Drawing.Point(17, 14);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(87, 30);
			this.label73.TabIndex = 2;
			this.label73.Text = "CDA Number\r\nor Identifier";
			this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label72
			// 
			this.label72.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label72.Location = new System.Drawing.Point(14, 45);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(90, 18);
			this.label72.TabIndex = 4;
			this.label72.Text = "Reason";
			this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboReferralReason
			// 
			this.comboReferralReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboReferralReason.FormattingEnabled = true;
			this.comboReferralReason.Location = new System.Drawing.Point(105, 45);
			this.comboReferralReason.Name = "comboReferralReason";
			this.comboReferralReason.Size = new System.Drawing.Size(273, 21);
			this.comboReferralReason.TabIndex = 1;
			// 
			// textReferralProvider
			// 
			this.textReferralProvider.Location = new System.Drawing.Point(105, 20);
			this.textReferralProvider.Name = "textReferralProvider";
			this.textReferralProvider.Size = new System.Drawing.Size(100, 20);
			this.textReferralProvider.TabIndex = 0;
			// 
			// textCanadianAccidentDate
			// 
			this.textCanadianAccidentDate.Location = new System.Drawing.Point(144, 84);
			this.textCanadianAccidentDate.Name = "textCanadianAccidentDate";
			this.textCanadianAccidentDate.Size = new System.Drawing.Size(75, 20);
			this.textCanadianAccidentDate.TabIndex = 138;
			// 
			// groupEnterPayment
			// 
			this.groupEnterPayment.BackColor = System.Drawing.SystemColors.Control;
			this.groupEnterPayment.Controls.Add(this.butPaySupp);
			this.groupEnterPayment.Controls.Add(this.butPayTotal);
			this.groupEnterPayment.Controls.Add(this.butPayProc);
			this.groupEnterPayment.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupEnterPayment.Location = new System.Drawing.Point(809, 12);
			this.groupEnterPayment.Name = "groupEnterPayment";
			this.groupEnterPayment.Size = new System.Drawing.Size(133, 107);
			this.groupEnterPayment.TabIndex = 132;
			this.groupEnterPayment.TabStop = false;
			this.groupEnterPayment.Text = "Enter Payment";
			// 
			// butPaySupp
			// 
			this.butPaySupp.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPaySupp.Autosize = true;
			this.butPaySupp.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPaySupp.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPaySupp.CornerRadius = 4F;
			this.butPaySupp.Location = new System.Drawing.Point(17, 78);
			this.butPaySupp.Name = "butPaySupp";
			this.butPaySupp.Size = new System.Drawing.Size(99, 24);
			this.butPaySupp.TabIndex = 102;
			this.butPaySupp.Text = "S&upplemental";
			this.butPaySupp.Click += new System.EventHandler(this.butPaySupp_Click);
			// 
			// butPayTotal
			// 
			this.butPayTotal.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPayTotal.Autosize = true;
			this.butPayTotal.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPayTotal.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPayTotal.CornerRadius = 4F;
			this.butPayTotal.Location = new System.Drawing.Point(17, 16);
			this.butPayTotal.Name = "butPayTotal";
			this.butPayTotal.Size = new System.Drawing.Size(99, 24);
			this.butPayTotal.TabIndex = 100;
			this.butPayTotal.Text = "As &Total";
			this.butPayTotal.Click += new System.EventHandler(this.butPayTotal_Click);
			// 
			// butPayProc
			// 
			this.butPayProc.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPayProc.Autosize = true;
			this.butPayProc.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPayProc.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPayProc.CornerRadius = 4F;
			this.butPayProc.Location = new System.Drawing.Point(17, 42);
			this.butPayProc.Name = "butPayProc";
			this.butPayProc.Size = new System.Drawing.Size(99, 24);
			this.butPayProc.TabIndex = 101;
			this.butPayProc.Text = "&By Procedure";
			this.butPayProc.Click += new System.EventHandler(this.butPayProc_Click);
			// 
			// textReasonUnder
			// 
			this.textReasonUnder.Location = new System.Drawing.Point(763, 418);
			this.textReasonUnder.MaxLength = 255;
			this.textReasonUnder.Multiline = true;
			this.textReasonUnder.Name = "textReasonUnder";
			this.textReasonUnder.Size = new System.Drawing.Size(215, 57);
			this.textReasonUnder.TabIndex = 130;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(762, 389);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(213, 26);
			this.label4.TabIndex = 131;
			this.label4.Text = "Reasons underpaid:  (shows on patient bill)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// contextMenuAttachments
			// 
			this.contextMenuAttachments.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemRename,
            this.menuItemRemove});
			this.contextMenuAttachments.Popup += new System.EventHandler(this.contextMenuAttachments_Popup);
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Index = 0;
			this.menuItemOpen.Text = "Open";
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// menuItemRename
			// 
			this.menuItemRename.Index = 1;
			this.menuItemRename.Text = "Rename";
			this.menuItemRename.Click += new System.EventHandler(this.menuItemRename_Click);
			// 
			// menuItemRemove
			// 
			this.menuItemRemove.Index = 2;
			this.menuItemRemove.Text = "Remove";
			this.menuItemRemove.Click += new System.EventHandler(this.menuItemRemove_Click);
			// 
			// comboClaimStatus
			// 
			this.comboClaimStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClaimStatus.Location = new System.Drawing.Point(111, 15);
			this.comboClaimStatus.MaxDropDownItems = 100;
			this.comboClaimStatus.Name = "comboClaimStatus";
			this.comboClaimStatus.Size = new System.Drawing.Size(126, 21);
			this.comboClaimStatus.TabIndex = 139;
			// 
			// comboClaimType
			// 
			this.comboClaimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClaimType.Enabled = false;
			this.comboClaimType.Location = new System.Drawing.Point(111, 36);
			this.comboClaimType.MaxDropDownItems = 100;
			this.comboClaimType.Name = "comboClaimType";
			this.comboClaimType.Size = new System.Drawing.Size(126, 21);
			this.comboClaimType.TabIndex = 140;
			// 
			// comboMedType
			// 
			this.comboMedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboMedType.Location = new System.Drawing.Point(351, 32);
			this.comboMedType.MaxDropDownItems = 100;
			this.comboMedType.Name = "comboMedType";
			this.comboMedType.Size = new System.Drawing.Size(126, 21);
			this.comboMedType.TabIndex = 146;
			// 
			// label86
			// 
			this.label86.Location = new System.Drawing.Point(254, 35);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(95, 17);
			this.label86.TabIndex = 145;
			this.label86.Text = "Med/Dent";
			this.label86.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// comboClaimForm
			// 
			this.comboClaimForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboClaimForm.Location = new System.Drawing.Point(351, 53);
			this.comboClaimForm.MaxDropDownItems = 100;
			this.comboClaimForm.Name = "comboClaimForm";
			this.comboClaimForm.Size = new System.Drawing.Size(126, 21);
			this.comboClaimForm.TabIndex = 148;
			// 
			// label87
			// 
			this.label87.Location = new System.Drawing.Point(254, 56);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(95, 17);
			this.label87.TabIndex = 147;
			this.label87.Text = "ClaimForm";
			this.label87.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelBatch
			// 
			this.labelBatch.Location = new System.Drawing.Point(574, 421);
			this.labelBatch.Name = "labelBatch";
			this.labelBatch.Size = new System.Drawing.Size(168, 53);
			this.labelBatch.TabIndex = 151;
			this.labelBatch.Text = "After all insurance payments on your EOB have been entered, click \"Finalize Payme" +
    "nt\" to finish this batch for daily reporting.";
			// 
			// label89
			// 
			this.label89.Location = new System.Drawing.Point(5, 100);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(104, 16);
			this.label89.TabIndex = 153;
			this.label89.Text = "Date Resent";
			this.label89.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// butResend
			// 
			this.butResend.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butResend.Autosize = true;
			this.butResend.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butResend.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butResend.CornerRadius = 4F;
			this.butResend.Location = new System.Drawing.Point(195, 97);
			this.butResend.Name = "butResend";
			this.butResend.Size = new System.Drawing.Size(51, 20);
			this.butResend.TabIndex = 154;
			this.butResend.Text = "Resend";
			this.butResend.Click += new System.EventHandler(this.butResend_Click);
			// 
			// textDateResent
			// 
			this.textDateResent.Location = new System.Drawing.Point(111, 97);
			this.textDateResent.Name = "textDateResent";
			this.textDateResent.Size = new System.Drawing.Size(82, 20);
			this.textDateResent.TabIndex = 152;
			// 
			// butBatch
			// 
			this.butBatch.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butBatch.Autosize = true;
			this.butBatch.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butBatch.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butBatch.CornerRadius = 4F;
			this.butBatch.Image = global::OpenDental.Properties.Resources.Add;
			this.butBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBatch.Location = new System.Drawing.Point(577, 389);
			this.butBatch.Name = "butBatch";
			this.butBatch.Size = new System.Drawing.Size(145, 24);
			this.butBatch.TabIndex = 150;
			this.butBatch.Text = "Finalize Payment";
			this.butBatch.Click += new System.EventHandler(this.butBatch_Click);
			// 
			// textLabFees
			// 
			this.textLabFees.Location = new System.Drawing.Point(411, 363);
			this.textLabFees.MaxVal = 100000000D;
			this.textLabFees.MinVal = -100000000D;
			this.textLabFees.Name = "textLabFees";
			this.textLabFees.ReadOnly = true;
			this.textLabFees.Size = new System.Drawing.Size(63, 20);
			this.textLabFees.TabIndex = 138;
			this.textLabFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// butHistory
			// 
			this.butHistory.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butHistory.Autosize = true;
			this.butHistory.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butHistory.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butHistory.CornerRadius = 4F;
			this.butHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHistory.Location = new System.Drawing.Point(595, 882);
			this.butHistory.Name = "butHistory";
			this.butHistory.Size = new System.Drawing.Size(86, 24);
			this.butHistory.TabIndex = 136;
			this.butHistory.Text = "History";
			this.butHistory.Click += new System.EventHandler(this.butHistory_Click);
			// 
			// gridPay
			// 
			this.gridPay.HScrollVisible = false;
			this.gridPay.Location = new System.Drawing.Point(2, 389);
			this.gridPay.Name = "gridPay";
			this.gridPay.ScrollValue = 0;
			this.gridPay.Size = new System.Drawing.Size(569, 86);
			this.gridPay.TabIndex = 135;
			this.gridPay.Title = "Insurance Payments";
			this.gridPay.TranslationName = "TableClaimPay";
			this.gridPay.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridPay_CellDoubleClick);
			this.gridPay.CellClick += new OpenDental.UI.ODGridClickEventHandler(this.gridPay_CellClick);
			// 
			// butSend
			// 
			this.butSend.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butSend.Autosize = true;
			this.butSend.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butSend.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butSend.CornerRadius = 4F;
			this.butSend.Image = ((System.Drawing.Image)(resources.GetObject("butSend.Image")));
			this.butSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSend.Location = new System.Drawing.Point(503, 882);
			this.butSend.Name = "butSend";
			this.butSend.Size = new System.Drawing.Size(86, 24);
			this.butSend.TabIndex = 130;
			this.butSend.Text = "Send";
			this.butSend.Click += new System.EventHandler(this.butSend_Click);
			// 
			// gridProc
			// 
			this.gridProc.HScrollVisible = false;
			this.gridProc.Location = new System.Drawing.Point(2, 159);
			this.gridProc.Name = "gridProc";
			this.gridProc.ScrollValue = 0;
			this.gridProc.SelectionMode = OpenDental.UI.GridSelectionMode.MultiExtended;
			this.gridProc.Size = new System.Drawing.Size(977, 200);
			this.gridProc.TabIndex = 128;
			this.gridProc.Title = "Procedures";
			this.gridProc.TranslationName = "TableClaimProc";
			this.gridProc.CellDoubleClick += new OpenDental.UI.ODGridClickEventHandler(this.gridProc_CellDoubleClick);
			this.gridProc.CellClick += new OpenDental.UI.ODGridClickEventHandler(this.gridProc_CellClick);
			// 
			// butSplit
			// 
			this.butSplit.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butSplit.Autosize = true;
			this.butSplit.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butSplit.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butSplit.CornerRadius = 4F;
			this.butSplit.Location = new System.Drawing.Point(826, 134);
			this.butSplit.Name = "butSplit";
			this.butSplit.Size = new System.Drawing.Size(99, 24);
			this.butSplit.TabIndex = 127;
			this.butSplit.Text = "Split Claim";
			this.butSplit.Click += new System.EventHandler(this.butSplit_Click);
			// 
			// butLabel
			// 
			this.butLabel.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butLabel.Autosize = true;
			this.butLabel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butLabel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butLabel.CornerRadius = 4F;
			this.butLabel.Image = global::OpenDental.Properties.Resources.butLabel;
			this.butLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLabel.Location = new System.Drawing.Point(163, 882);
			this.butLabel.Name = "butLabel";
			this.butLabel.Size = new System.Drawing.Size(81, 24);
			this.butLabel.TabIndex = 126;
			this.butLabel.Text = "Label";
			this.butLabel.Click += new System.EventHandler(this.butLabel_Click);
			// 
			// textDateService
			// 
			this.textDateService.Location = new System.Drawing.Point(111, 57);
			this.textDateService.Name = "textDateService";
			this.textDateService.Size = new System.Drawing.Size(82, 20);
			this.textDateService.TabIndex = 119;
			// 
			// textWriteOff
			// 
			this.textWriteOff.Location = new System.Drawing.Point(659, 363);
			this.textWriteOff.MaxVal = 100000000D;
			this.textWriteOff.MinVal = -100000000D;
			this.textWriteOff.Name = "textWriteOff";
			this.textWriteOff.ReadOnly = true;
			this.textWriteOff.Size = new System.Drawing.Size(63, 20);
			this.textWriteOff.TabIndex = 113;
			this.textWriteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textInsPayAmt
			// 
			this.textInsPayAmt.Location = new System.Drawing.Point(597, 363);
			this.textInsPayAmt.MaxVal = 100000000D;
			this.textInsPayAmt.MinVal = -100000000D;
			this.textInsPayAmt.Name = "textInsPayAmt";
			this.textInsPayAmt.ReadOnly = true;
			this.textInsPayAmt.Size = new System.Drawing.Size(63, 20);
			this.textInsPayAmt.TabIndex = 6;
			this.textInsPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textDedApplied
			// 
			this.textDedApplied.Location = new System.Drawing.Point(473, 363);
			this.textDedApplied.MaxVal = 100000000D;
			this.textDedApplied.MinVal = -100000000D;
			this.textDedApplied.Name = "textDedApplied";
			this.textDedApplied.ReadOnly = true;
			this.textDedApplied.Size = new System.Drawing.Size(63, 20);
			this.textDedApplied.TabIndex = 4;
			this.textDedApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textDateSent
			// 
			this.textDateSent.Location = new System.Drawing.Point(111, 77);
			this.textDateSent.Name = "textDateSent";
			this.textDateSent.Size = new System.Drawing.Size(82, 20);
			this.textDateSent.TabIndex = 6;
			// 
			// textDateRec
			// 
			this.textDateRec.Location = new System.Drawing.Point(111, 117);
			this.textDateRec.Name = "textDateRec";
			this.textDateRec.Size = new System.Drawing.Size(82, 20);
			this.textDateRec.TabIndex = 7;
			// 
			// butPreview
			// 
			this.butPreview.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butPreview.Autosize = true;
			this.butPreview.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPreview.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPreview.CornerRadius = 4F;
			this.butPreview.Image = global::OpenDental.Properties.Resources.butPreview;
			this.butPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPreview.Location = new System.Drawing.Point(250, 882);
			this.butPreview.Name = "butPreview";
			this.butPreview.Size = new System.Drawing.Size(92, 24);
			this.butPreview.TabIndex = 115;
			this.butPreview.Text = "P&review";
			this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
			// 
			// butPrint
			// 
			this.butPrint.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butPrint.Autosize = true;
			this.butPrint.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPrint.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPrint.CornerRadius = 4F;
			this.butPrint.Image = global::OpenDental.Properties.Resources.butPrintSmall;
			this.butPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butPrint.Location = new System.Drawing.Point(347, 882);
			this.butPrint.Name = "butPrint";
			this.butPrint.Size = new System.Drawing.Size(86, 24);
			this.butPrint.TabIndex = 114;
			this.butPrint.Text = "&Print";
			this.butPrint.Click += new System.EventHandler(this.ButPrint_Click);
			// 
			// butRecalc
			// 
			this.butRecalc.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butRecalc.Autosize = true;
			this.butRecalc.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butRecalc.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butRecalc.CornerRadius = 4F;
			this.butRecalc.Location = new System.Drawing.Point(762, 361);
			this.butRecalc.Name = "butRecalc";
			this.butRecalc.Size = new System.Drawing.Size(148, 24);
			this.butRecalc.TabIndex = 112;
			this.butRecalc.Text = "Recalculate &Estimates";
			this.butRecalc.Click += new System.EventHandler(this.butRecalc_Click);
			// 
			// butDelete
			// 
			this.butDelete.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.butDelete.Autosize = true;
			this.butDelete.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butDelete.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butDelete.CornerRadius = 4F;
			this.butDelete.Image = global::OpenDental.Properties.Resources.deleteX;
			this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDelete.Location = new System.Drawing.Point(5, 882);
			this.butDelete.Name = "butDelete";
			this.butDelete.Size = new System.Drawing.Size(91, 24);
			this.butDelete.TabIndex = 106;
			this.butDelete.Text = "&Delete";
			this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
			// 
			// butCancel
			// 
			this.butCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butCancel.Autosize = true;
			this.butCancel.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butCancel.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butCancel.CornerRadius = 4F;
			this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.butCancel.Location = new System.Drawing.Point(866, 882);
			this.butCancel.Name = "butCancel";
			this.butCancel.Size = new System.Drawing.Size(75, 24);
			this.butCancel.TabIndex = 15;
			this.butCancel.Text = "&Cancel";
			this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
			// 
			// butOK
			// 
			this.butOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.butOK.Autosize = true;
			this.butOK.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butOK.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butOK.CornerRadius = 4F;
			this.butOK.Location = new System.Drawing.Point(779, 882);
			this.butOK.Name = "butOK";
			this.butOK.Size = new System.Drawing.Size(75, 24);
			this.butOK.TabIndex = 14;
			this.butOK.Text = "&OK";
			this.butOK.Click += new System.EventHandler(this.butOK_Click);
			// 
			// butPickProvBill
			// 
			this.butPickProvBill.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPickProvBill.Autosize = false;
			this.butPickProvBill.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPickProvBill.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPickProvBill.CornerRadius = 2F;
			this.butPickProvBill.Location = new System.Drawing.Point(503, 74);
			this.butPickProvBill.Name = "butPickProvBill";
			this.butPickProvBill.Size = new System.Drawing.Size(18, 21);
			this.butPickProvBill.TabIndex = 261;
			this.butPickProvBill.Text = "...";
			this.butPickProvBill.Click += new System.EventHandler(this.butPickProvBill_Click);
			// 
			// butPickProvTreat
			// 
			this.butPickProvTreat.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.butPickProvTreat.Autosize = false;
			this.butPickProvTreat.BtnShape = OpenDental.UI.enumType.BtnShape.Rectangle;
			this.butPickProvTreat.BtnStyle = OpenDental.UI.enumType.XPStyle.Silver;
			this.butPickProvTreat.CornerRadius = 2F;
			this.butPickProvTreat.Location = new System.Drawing.Point(503, 95);
			this.butPickProvTreat.Name = "butPickProvTreat";
			this.butPickProvTreat.Size = new System.Drawing.Size(18, 21);
			this.butPickProvTreat.TabIndex = 262;
			this.butPickProvTreat.Text = "...";
			this.butPickProvTreat.Click += new System.EventHandler(this.butPickProvTreat_Click);
			// 
			// FormClaimEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(984, 913);
			this.ControlBox = false;
			this.Controls.Add(this.butPickProvTreat);
			this.Controls.Add(this.butPickProvBill);
			this.Controls.Add(this.butResend);
			this.Controls.Add(this.textDateResent);
			this.Controls.Add(this.label89);
			this.Controls.Add(this.labelBatch);
			this.Controls.Add(this.butBatch);
			this.Controls.Add(this.comboClaimForm);
			this.Controls.Add(this.label87);
			this.Controls.Add(this.comboMedType);
			this.Controls.Add(this.label86);
			this.Controls.Add(this.comboClaimType);
			this.Controls.Add(this.comboClaimStatus);
			this.Controls.Add(this.textLabFees);
			this.Controls.Add(this.butHistory);
			this.Controls.Add(this.textReasonUnder);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gridPay);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.panelRightEdge);
			this.Controls.Add(this.panelBottomEdge);
			this.Controls.Add(this.groupEnterPayment);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.butSend);
			this.Controls.Add(this.gridProc);
			this.Controls.Add(this.butSplit);
			this.Controls.Add(this.butLabel);
			this.Controls.Add(this.comboClinic);
			this.Controls.Add(this.labelClinic);
			this.Controls.Add(this.textDateService);
			this.Controls.Add(this.textWriteOff);
			this.Controls.Add(this.textInsPayEst);
			this.Controls.Add(this.textInsPayAmt);
			this.Controls.Add(this.textClaimFee);
			this.Controls.Add(this.textDedApplied);
			this.Controls.Add(this.textPredeterm);
			this.Controls.Add(this.textDateSent);
			this.Controls.Add(this.textDateRec);
			this.Controls.Add(this.butPreview);
			this.Controls.Add(this.butPrint);
			this.Controls.Add(this.butRecalc);
			this.Controls.Add(this.butDelete);
			this.Controls.Add(this.butCancel);
			this.Controls.Add(this.butOK);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboProvTreat);
			this.Controls.Add(this.comboProvBill);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.labelPredeterm);
			this.Controls.Add(this.labelDateService);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label8);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormClaimEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Claim";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClaimEdit_Closing);
			this.Load += new System.EventHandler(this.FormClaimEdit_Load);
			this.Shown += new System.EventHandler(this.FormClaimEdit_Shown);
			this.groupProsth.ResumeLayout(false);
			this.groupProsth.PerformLayout();
			this.groupOrtho.ResumeLayout(false);
			this.groupOrtho.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupValueCodes.ResumeLayout(false);
			this.groupValueCodes.PerformLayout();
			this.tabMain.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.groupAccident.ResumeLayout(false);
			this.groupAccident.PerformLayout();
			this.groupAttachments.ResumeLayout(false);
			this.groupAttachments.PerformLayout();
			this.groupAttachedImages.ResumeLayout(false);
			this.groupReferral.ResumeLayout(false);
			this.groupReferral.PerformLayout();
			this.tabMisc.ResumeLayout(false);
			this.tabMisc.PerformLayout();
			this.tabUB04.ResumeLayout(false);
			this.groupUb04.ResumeLayout(false);
			this.groupUb04.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabCanadian.ResumeLayout(false);
			this.tabCanadian.PerformLayout();
			this.groupCanadaOrthoPredeterm.ResumeLayout(false);
			this.groupCanadaOrthoPredeterm.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupEnterPayment.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void FormClaimEdit_Shown(object sender,EventArgs e) {
			//this needs to be removed.
		}
		
		private void FormClaimEdit_Load(object sender, System.EventArgs e) {
			//the control box (x to close window) is not shown in this form because new users are temped to use it as an OK button, causing errors.
			if(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height<this.Height){
				this.Height=System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;//make this window as tall as possible.
			}
			if(IsFromBatchWindow) {
				butBatch.Visible=false;
				labelBatch.Visible=false;
			}
			if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//Canadian. en-CA or fr-CA
				labelPredeterm.Text=Lan.g(this,"Predeterm Num");
				labelPriorAuth.Visible=false;
				textPriorAuth.Visible=false;
				labelSpecialProgram.Visible=false;
				comboSpecialProgram.Visible=false;
				groupProsth.Visible=false;
				groupReferral.Visible=false;
				groupOrtho.Visible=false;
				groupAttachments.Visible=false;
				groupAttachedImages.Visible=false;
				groupAccident.Visible=false;
				labelNote.Text="Claim Note (will only show on printed claims)";
				tabMain.SelectedTab=tabCanadian;
				if(ClaimCur.DateSent.Date==MiscData.GetNowDateTime().Date) { //Reversal can only happen on the same day that the claim was originally sent.
					butReverse.Enabled=(ClaimCur.CanadaTransRefNum!=null && ClaimCur.CanadaTransRefNum!="");
				}
				butSend.Enabled=(ClaimCur.CanadaTransRefNum==null || ClaimCur.CanadaTransRefNum=="");
				if(ClaimCur.ClaimType=="PreAuth") {
					List <PatPlan> patPlansForPat=PatPlans.Refresh(ClaimCur.PatNum);
					for(int i=0;i<patPlansForPat.Count;i++) {
						if(patPlansForPat[i].InsSubNum==ClaimCur.InsSubNum && patPlansForPat[i].Ordinal!=1) {
							butSend.Enabled=false;//Do not allow the user to send secondary predeterminations because there is no format that supports such a transaction in ITRANS.
						}
					}
				}
			}
			else {
				textLabFees.Visible=false;
				textDedApplied.Location=textLabFees.Location;
				textInsPayEst.Location=new Point(textDedApplied.Right-1,textInsPayEst.Location.Y);
				textInsPayAmt.Location=new Point(textInsPayEst.Right-1,textInsPayEst.Location.Y);
				textWriteOff.Location=new Point(textInsPayAmt.Right-1,textInsPayEst.Location.Y);
				tabMain.TabPages.Remove(tabCanadian);
			}
			if(IsNew){
				//butCheckAdd.Enabled=false; //button was removed.
				groupEnterPayment.Enabled=false;
			}
			else if(ClaimCur.ClaimStatus=="S" || ClaimCur.ClaimStatus=="R"){//sent or received
				if(!Security.IsAuthorized(Permissions.ClaimSentEdit,ClaimCur.DateSent)){
					butOK.Enabled=false;
					butDelete.Enabled=false;
					//butPrint.Enabled=false;//allowed to print, but just won't save changes.
					notAuthorized=true;
					groupEnterPayment.Enabled=false;
					gridPay.Enabled=false;
					gridProc.Enabled=false;
					comboClaimStatus.Enabled=false;
					//butCheckAdd.Enabled=false; //button was removed.
				}
			}
			if(ClaimCur.ClaimType=="PreAuth"){
				labelPredeterm.Visible=false;
				textPredeterm.Visible=false;
				textDateService.Visible=false;
				labelDateService.Visible=false;
				label20.Visible=false;//warning when delete
				textReasonUnder.Visible=false;
				label4.Visible=false;//reason under
				butPayTotal.Visible=false;
				butPaySupp.Visible=false;
				butSplit.Visible=false;
      }
			if(PrefC.GetBool(PrefName.EasyNoClinics)){
				labelClinic.Visible=false;
				comboClinic.Visible=false;
			}
			comboClaimType.Items.Add(Lan.g(this,"Primary"));
			comboClaimType.Items.Add(Lan.g(this,"Secondary"));
			comboClaimType.Items.Add(Lan.g(this,"PreAuth"));
			comboClaimType.Items.Add(Lan.g(this,"Other"));
			comboClaimType.Items.Add(Lan.g(this,"Capitation"));
			comboClaimStatus.Items.Add(Lan.g(this,"Unsent"));
			comboClaimStatus.Items.Add(Lan.g(this,"Hold until Pri received"));
			comboClaimStatus.Items.Add(Lan.g(this,"Waiting to Send"));//2
			comboClaimStatus.Items.Add(Lan.g(this,"Probably Sent"));
			comboClaimStatus.Items.Add(Lan.g(this,"Sent - Verified"));
			comboClaimStatus.Items.Add(Lan.g(this,"Received"));
			comboSpecialProgram.Items.Clear();
			for(int i=0;i<Enum.GetNames(typeof(EnumClaimSpecialProgram)).Length;i++) {
				comboSpecialProgram.Items.Add(Enum.GetNames(typeof(EnumClaimSpecialProgram))[i]);
			}
			string[] enumRelat=Enum.GetNames(typeof(Relat));
			for(int i=0;i<enumRelat.Length;i++){;
				comboPatRelat.Items.Add(Lan.g("enumRelat",enumRelat[i]));
				comboPatRelat2.Items.Add(Lan.g("enumRelat",enumRelat[i]));
			}
      ClaimList=Claims.Refresh(PatCur.PatNum); 
      ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			ProcList=Procedures.Refresh(PatCur.PatNum);
			SubList=InsSubs.RefreshForFam(FamCur);
			PlanList=InsPlans.RefreshForSubList(SubList);
			PatPlanList=PatPlans.Refresh(PatCur.PatNum);
			if(InsPlans.GetPlan(ClaimCur.PlanNum,PlanList).PlanType=="p"){//ppo
				butPayTotal.Enabled=false;	
			}
			//this section used to be "supplemental"---------------------------------------------------------------------------------
			textRefNum.Text=ClaimCur.RefNumString;
			string[] enumPlaceOfService=Enum.GetNames(typeof(PlaceOfService));
			for(int i=0;i<enumPlaceOfService.Length;i++) {
				comboPlaceService.Items.Add(Lan.g("enumPlaceOfService",enumPlaceOfService[i]));
			}
			comboPlaceService.SelectedIndex=(int)ClaimCur.PlaceService;
			string[] enumYN=Enum.GetNames(typeof(YN));
			for(int i=0;i<enumYN.Length;i++) {
				comboEmployRelated.Items.Add(Lan.g("enumYN",enumYN[i]));
			}
			comboEmployRelated.SelectedIndex=(int)ClaimCur.EmployRelated;
			comboAccident.Items.Add(Lan.g(this,"No"));
			comboAccident.Items.Add(Lan.g(this,"Auto"));
			comboAccident.Items.Add(Lan.g(this,"Employment"));
			comboAccident.Items.Add(Lan.g(this,"Other"));
			switch(ClaimCur.AccidentRelated) {
				case "":
					comboAccident.SelectedIndex=0;
					break;
				case "A":
					comboAccident.SelectedIndex=1;
					break;
				case "E":
					comboAccident.SelectedIndex=2;
					break;
				case "O":
					comboAccident.SelectedIndex=3;
					break;
			}
			//accident date is further down
			textAccidentST.Text=ClaimCur.AccidentST;
			textRefProv.Text=Referrals.GetNameLF(ClaimCur.ReferringProv);
			if(ClaimCur.ReferringProv==0){
				butReferralEdit.Enabled=false;
			}
			else{
				butReferralEdit.Enabled=true;
			}
			//medical data
			ListClaimValCodes=ClaimValCodeLogs.GetForClaim(ClaimCur.ClaimNum);
			ClaimCondCodeLogCur=ClaimCondCodeLogs.GetByClaimNum(ClaimCur.ClaimNum);
			_provNumOrderingSelected=ClaimCur.ProvOrderOverride;
			comboProvNumOrdering.Items.Clear();
			for(int i=0;i<ProviderC.ListShort.Count;i++) {
				comboProvNumOrdering.Items.Add(ProviderC.ListShort[i].GetLongDesc());//Only visible provs added to combobox.
				if(ProviderC.ListShort[i].ProvNum==ClaimCur.ProvOrderOverride) {
					comboProvNumOrdering.SelectedIndex=i;//Sets combo text too.
				}
			}
			//ComboProvBill
			_provNumBillSelected=ClaimCur.ProvBill;
			comboProvBill.Items.Clear();
			for(int i=0;i<ProviderC.ListShort.Count;i++) {
				comboProvBill.Items.Add(ProviderC.ListShort[i].Abbr);//Only visible provs added to combobox.
				if(ProviderC.ListShort[i].ProvNum==ClaimCur.ProvBill) {
					comboProvBill.SelectedIndex=i;//Sets combo text too.
				}
			}
			if(_provNumBillSelected==0) {//Is new (exclude this block of code if provider selection is optional)
				comboProvBill.SelectedIndex=0;
				_provNumBillSelected=ProviderC.ListShort[0].ProvNum;
			}
			if(comboProvBill.SelectedIndex==-1) {//The provider exists but is hidden (exclude this block of code if provider selection is optional)
				comboProvBill.Text=Providers.GetProv(_provNumBillSelected).GetAbbr();//Appends "(hidden)" to the end of the abbr.
			}
			//ComboProvTreat
			_provNumTreatSelected=ClaimCur.ProvTreat;
			comboProvTreat.Items.Clear();
			for(int i=0;i<ProviderC.ListShort.Count;i++) {
				comboProvTreat.Items.Add(ProviderC.ListShort[i].Abbr);//Only visible provs added to combobox.
				if(ProviderC.ListShort[i].ProvNum==ClaimCur.ProvTreat) {
					comboProvTreat.SelectedIndex=i;//Sets combo text too.
				}
			}
			if(_provNumTreatSelected==0) {//Is new (exclude this block of code if provider selection is optional)
				comboProvTreat.SelectedIndex=0;
				_provNumTreatSelected=ProviderC.ListShort[0].ProvNum;
			}
			if(comboProvTreat.SelectedIndex==-1) {//The provider exists but is hidden (exclude this block of code if provider selection is optional)
				comboProvTreat.Text=Providers.GetProv(_provNumTreatSelected).GetAbbr();//Appends "(hidden)" to the end of the abbr.
			}
			FillForm();
			FillCanadian();
		}

		///<summary></summary>
		public void FillForm(){
			this.Text=Lan.g(this,"Edit Claim")+" - "+PatCur.GetNameLF();
			if(ClaimCur.DateService.Year<1880) {
				textDateService.Text="";
			}
			else {
				textDateService.Text=ClaimCur.DateService.ToShortDateString();
			}
			if(ClaimCur.DateSent.Year<1880) {
				textDateSent.Text="";
			}
			else {
				textDateSent.Text=ClaimCur.DateSent.ToShortDateString();
			}
			if(ClaimCur.DateReceived.Year<1880) {
				textDateRec.Text="";
			}
			else {
				textDateRec.Text=ClaimCur.DateReceived.ToShortDateString();
			}
			switch(ClaimCur.ClaimStatus){
				case "U"://unsent
					comboClaimStatus.SelectedIndex=0;
					break;
				case "H"://hold until pri received
					comboClaimStatus.SelectedIndex=1;
					break;
				case "W"://waiting to be sent
					comboClaimStatus.SelectedIndex=2;
					break;
				case "P"://probably sent
					comboClaimStatus.SelectedIndex=3;
					break;
				case "S"://sent-verified
					comboClaimStatus.SelectedIndex=4;
					break;
				case "R"://received
					comboClaimStatus.SelectedIndex=5;
					break;
			}
			switch(ClaimCur.ClaimType){
				case "P":
					comboClaimType.SelectedIndex=0;
					break;
				case "S":
					comboClaimType.SelectedIndex=1;
					break;
				case "PreAuth":
					comboClaimType.SelectedIndex=2;
					break;
				case "Other":
					comboClaimType.SelectedIndex=3;
					break;
				case "Cap":
					comboClaimType.SelectedIndex=4;
					break;
			}
			comboMedType.Items.Clear();
			for(int i=0;i<Enum.GetNames(typeof(EnumClaimMedType)).Length;i++){
				comboMedType.Items.Add(Enum.GetNames(typeof(EnumClaimMedType))[i]);
			}
			comboMedType.SelectedIndex=(int)ClaimCur.MedType;
			comboClaimForm.Items.Clear();
			comboClaimForm.Items.Add(Lan.g(this,"none"));
			comboClaimForm.SelectedIndex=0;
			for(int i=0;i<ClaimForms.ListShort.Length;i++){
				comboClaimForm.Items.Add(ClaimForms.ListShort[i].Description);
				if(ClaimCur.ClaimForm==ClaimForms.ListShort[i].ClaimFormNum){
					comboClaimForm.SelectedIndex=i+1;
				}
			}
			comboClinic.Items.Clear();
			comboClinic.Items.Add(Lan.g(this,"none"));
			comboClinic.SelectedIndex=0;
			for(int i=0;i<Clinics.List.Length;i++){
				comboClinic.Items.Add(Clinics.List[i].Description);
				if(Clinics.List[i].ClinicNum==ClaimCur.ClinicNum)
					comboClinic.SelectedIndex=i+1;
			}
			if(DefC.Long[(int)DefCat.ClaimCustomTracking].Length==0){
				labelCustomTracking.Visible=false;
				comboCustomTracking.Visible=false;
			}
			else{
				comboCustomTracking.Items.Clear();
				comboCustomTracking.Items.Add(Lan.g(this,"none"));
				comboCustomTracking.SelectedIndex=0;
				for(int i=0;i<DefC.Long[(int)DefCat.ClaimCustomTracking].Length;i++) {
					comboCustomTracking.Items.Add(DefC.Long[(int)DefCat.ClaimCustomTracking][i].ItemName);
					if(ClaimCur.CustomTracking==DefC.Long[(int)DefCat.ClaimCustomTracking][i].DefNum) {	
						comboCustomTracking.SelectedIndex=i+1;
					}
				}
			}
			textPriorAuth.Text=ClaimCur.PriorAuthorizationNumber;
			textPredeterm.Text=ClaimCur.PreAuthString;
			comboSpecialProgram.SelectedIndex=(int)ClaimCur.SpecialProgramCode;
			textPlan.Text=InsPlans.GetDescript(ClaimCur.PlanNum,FamCur,PlanList,ClaimCur.InsSubNum,SubList);
			comboPatRelat.SelectedIndex=(int)ClaimCur.PatRelat;
			textPlan2.Text=InsPlans.GetDescript(ClaimCur.PlanNum2,FamCur,PlanList,ClaimCur.InsSubNum2,SubList);
			comboPatRelat2.SelectedIndex=(int)ClaimCur.PatRelat2;
			if(textPlan2.Text==""){
				comboPatRelat2.Visible=false;
				label10.Visible=false;
			}
			else{
				comboPatRelat2.Visible=true;
				label10.Visible=true;
			}
			switch(ClaimCur.IsProsthesis){
				case "N"://no
					radioProsthN.Checked=true;
					break;
				case "I"://initial
					radioProsthI.Checked=true;
					break;
				case "R"://replacement
					radioProsthR.Checked=true;
					break;
			}
			if(ClaimCur.PriorDate.Year < 1880){
				textPriorDate.Text="";
			}
			else{
				textPriorDate.Text=ClaimCur.PriorDate.ToShortDateString();
			}
			textReasonUnder.Text=ClaimCur.ReasonUnderPaid;
			textNote.Text=ClaimCur.ClaimNote;
			checkIsOrtho.Checked=ClaimCur.IsOrtho;
			textOrthoRemainM.Text=ClaimCur.OrthoRemainM.ToString();
			if(ClaimCur.OrthoDate.Year < 1860){
				textOrthoDate.Text="";
			}
			else{
				textOrthoDate.Text=ClaimCur.OrthoDate.ToShortDateString();
			}
			if(ClaimCur.DateResent.Year>1880) {
				textDateResent.Text=ClaimCur.DateResent.ToShortDateString();
			}
			string[] claimCorrectionTypeNames=Enum.GetNames(typeof(ClaimCorrectionType));
			Array claimCorrectionTypeValues=Enum.GetValues(typeof(ClaimCorrectionType));
			comboCorrectionType.Items.Clear();
			for(int i=0;i<claimCorrectionTypeNames.Length;i++) {
				comboCorrectionType.Items.Add(claimCorrectionTypeNames[i]);
				if((ClaimCorrectionType)claimCorrectionTypeValues.GetValue(i)==ClaimCur.CorrectionType) {
					comboCorrectionType.SelectedIndex=i;
				}
			}
			if(ClaimCur.ClaimIdentifier=="" || ClaimCur.ClaimIdentifier==null) {
				//There is always a claimnum and patnum associated with the claim before this window is called, even for new claims.
				textClaimIdentifier.Text=ClaimCur.PatNum.ToString()+"/"+ClaimCur.ClaimNum.ToString();
			}
			else {
				textClaimIdentifier.Text=ClaimCur.ClaimIdentifier;
			}
			textOrigRefNum.Text=ClaimCur.OrigRefNum;
			//Canadian------------------------------------------------------------------
			//(there's also a FillCanadian section for fields that do not collide with USA fields)
			if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//Canadian. en-CA or fr-CA
				if(ClaimCur.AccidentDate.Year<1880) {
					textCanadianAccidentDate.Text="";
				}
				else {
					textCanadianAccidentDate.Text=ClaimCur.AccidentDate.ToShortDateString();
				}
				checkCanadianIsOrtho.Checked=ClaimCur.IsOrtho;
			}
			else {
				if(ClaimCur.AccidentDate.Year<1880) {
					textAccidentDate.Text="";
				}
				else {
					textAccidentDate.Text=ClaimCur.AccidentDate.ToShortDateString();
				}
				checkIsOrtho.Checked=ClaimCur.IsOrtho;
			}
			textCanadaTransRefNum.Text=ClaimCur.CanadaTransRefNum;
			groupCanadaOrthoPredeterm.Enabled=(ClaimCur.ClaimType=="PreAuth");
			if(ClaimCur.CanadaEstTreatStartDate.Year<1880) {
				textDateCanadaEstTreatStartDate.Text="";
			}
			else {
				textDateCanadaEstTreatStartDate.Text=ClaimCur.CanadaEstTreatStartDate.ToShortDateString();
			}
			if(ClaimCur.CanadaInitialPayment==0) {
				textCanadaInitialPayment.Text="";
			}
			else {
				textCanadaInitialPayment.Text=ClaimCur.CanadaInitialPayment.ToString("F");
			}
			textCanadaExpectedPayCycle.Text=ClaimCur.CanadaPaymentMode.ToString("#");
			textCanadaTreatDuration.Text=ClaimCur.CanadaTreatDuration.ToString("##");
			textCanadaNumPaymentsAnticipated.Text=ClaimCur.CanadaNumAnticipatedPayments.ToString("##");
			if(ClaimCur.CanadaAnticipatedPayAmount==0) {
				textCanadaAnticipatedPayAmount.Text="";
			}
			else {
				textCanadaAnticipatedPayAmount.Text=ClaimCur.CanadaAnticipatedPayAmount.ToString("F");
			}
			//attachments------------------
			textRadiographs.Text=ClaimCur.Radiographs.ToString();
			textAttachImages.Text=ClaimCur.AttachedImages.ToString();
			textAttachModels.Text=ClaimCur.AttachedModels.ToString();
			checkAttachEoB.Checked=false;
			checkAttachNarrative.Checked=false;
			checkAttachPerio.Checked=false;
			checkAttachMisc.Checked=false;
			radioAttachMail.Checked=true;
			string[] flags=ClaimCur.AttachedFlags.Split(',');
			for(int i=0;i<flags.Length;i++){
				switch(flags[i]){
					case "EoB":
						checkAttachEoB.Checked=true;
						break;
					case "Note":
						checkAttachNarrative.Checked=true;
						break;
					case "Perio":
						checkAttachPerio.Checked=true;
						break;
					case "Misc":
						checkAttachMisc.Checked=true;
						break;
					case "Mail":
						radioAttachMail.Checked=true;
						break;
					case "Elect":
						radioAttachElect.Checked=true;
						break;
				}
			}
			textAttachID.Text=ClaimCur.AttachmentID;
			//medical/inst
			textBillType.Text=ClaimCur.UniformBillType;
			textAdmissionType.Text=ClaimCur.AdmissionTypeCode;
			textAdmissionSource.Text=ClaimCur.AdmissionSourceCode;
			textPatientStatus.Text=ClaimCur.PatientStatusCode;
			if(ClaimCondCodeLogCur!=null && ClaimCondCodeLogCur.ClaimNum!=0) {
				textCode0.Text=ClaimCondCodeLogCur.Code0.ToString();
				textCode1.Text=ClaimCondCodeLogCur.Code1.ToString();
				textCode2.Text=ClaimCondCodeLogCur.Code2.ToString();
				textCode3.Text=ClaimCondCodeLogCur.Code3.ToString();
				textCode4.Text=ClaimCondCodeLogCur.Code4.ToString();
				textCode5.Text=ClaimCondCodeLogCur.Code5.ToString();
				textCode6.Text=ClaimCondCodeLogCur.Code6.ToString();
				textCode7.Text=ClaimCondCodeLogCur.Code7.ToString();
				textCode8.Text=ClaimCondCodeLogCur.Code8.ToString();
				textCode9.Text=ClaimCondCodeLogCur.Code9.ToString();
				textCode10.Text=ClaimCondCodeLogCur.Code10.ToString();
			}
			if(ListClaimValCodes!=null) {
				for(int i=0;i<ListClaimValCodes.Count;i++) {
					ClaimValCodeLog vc = (ClaimValCodeLog)ListClaimValCodes[i];
					TextBox code = (TextBox)Controls.Find("textVC" + i + "Code",true)[0];
					code.Text=vc.ValCode.ToString();
					TextBox amount = (TextBox)Controls.Find("textVC" + i + "Amount",true)[0];
					amount.Text=vc.ValAmount.ToString();
				}
			}
			FillGrids();
			FillAttachments();
		}

		private void FillCanadian() {
			comboReferralReason.Items.Clear();
			comboReferralReason.Items.Add("none");//0. -1 never used
			comboReferralReason.Items.Add("Pathological Anomalies");//1
			comboReferralReason.Items.Add("Disabled (physical or mental)");
			comboReferralReason.Items.Add("Complexity of Treatment");
			comboReferralReason.Items.Add("Seizure Disorders");
			comboReferralReason.Items.Add("Extensive Surgery");
			comboReferralReason.Items.Add("Surgical Complexity");
			comboReferralReason.Items.Add("Rampant decay");
			comboReferralReason.Items.Add("Medical History (to provide details upon request)");
			comboReferralReason.Items.Add("Temporal Mandibular Joint Anomalies");
			comboReferralReason.Items.Add("Accidental Injury");
			comboReferralReason.Items.Add("Anaesthesia complications (local or general)");
			comboReferralReason.Items.Add("Developmental Anomalies");
			comboReferralReason.Items.Add("Behavioral Management");//13
			//max
			comboMaxProsth.Items.Clear();
			comboMaxProsth.Items.Add("Please Choose");
			comboMaxProsth.Items.Add("Yes");
			comboMaxProsth.Items.Add("No");
			comboMaxProsth.Items.Add("Not an upper denture, crown, or bridge");
			comboMaxProsthMaterial.Items.Clear();
			comboMaxProsthMaterial.Items.Add("not applicable");//this always starts out selected. -1 never used.
			comboMaxProsthMaterial.Items.Add("Fixed bridge");
			comboMaxProsthMaterial.Items.Add("Maryland bridge");
			comboMaxProsthMaterial.Items.Add("Denture (Acrylic)");
			comboMaxProsthMaterial.Items.Add("Denture (Chrome Cobalt)");
			comboMaxProsthMaterial.Items.Add("Implant (Fixed)");
			comboMaxProsthMaterial.Items.Add("Implant (Removable)");
			comboMaxProsthMaterial.Items.Add("Crown");//7.  not an official type
			//mand
			comboMandProsth.Items.Clear();
			comboMandProsth.Items.Add("Please Choose");
			comboMandProsth.Items.Add("Yes");
			comboMandProsth.Items.Add("No");
			comboMandProsth.Items.Add("Not a lower denture, crown, or bridge");
			comboMandProsthMaterial.Items.Clear();
			comboMandProsthMaterial.Items.Add("not applicable");//this always starts out selected. -1 never used.
			comboMandProsthMaterial.Items.Add("Fixed bridge");
			comboMandProsthMaterial.Items.Add("Maryland bridge");
			comboMandProsthMaterial.Items.Add("Denture (Acrylic)");
			comboMandProsthMaterial.Items.Add("Denture (Chrome Cobalt)");
			comboMandProsthMaterial.Items.Add("Implant (Fixed)");
			comboMandProsthMaterial.Items.Add("Implant (Removable)");
			comboMandProsthMaterial.Items.Add("Crown");
			//Load data for this claim---------------------------------------------------------------------------------------------
			if(ClaimCur.CanadianMaterialsForwarded.Contains("E")) {
				checkEmail.Checked=true;
			}
			if(ClaimCur.CanadianMaterialsForwarded.Contains("C")) {
				checkCorrespondence.Checked=true;
			}
			if(ClaimCur.CanadianMaterialsForwarded.Contains("M")) {
				checkModels.Checked=true;
			}
			if(ClaimCur.CanadianMaterialsForwarded.Contains("X")) {
				checkXrays.Checked=true;
			}
			if(ClaimCur.CanadianMaterialsForwarded.Contains("I")) {
				checkImages.Checked=true;
			}
			textReferralProvider.Text=ClaimCur.CanadianReferralProviderNum;
			comboReferralReason.SelectedIndex=ClaimCur.CanadianReferralReason;
			//max prosth-----------------------------------------------------------------------------------------------------
			switch(ClaimCur.CanadianIsInitialUpper){
				case "Y":
					comboMaxProsth.SelectedIndex=1;
					break;
				case "N":
					comboMaxProsth.SelectedIndex=2;
					break;
				default: //"X"
					comboMaxProsth.SelectedIndex=3;
					break;
			}
			if(ClaimCur.CanadianDateInitialUpper.Year<1880) {
				textDateInitialUpper.Text="";
			}
			else {
				textDateInitialUpper.Text=ClaimCur.CanadianDateInitialUpper.ToShortDateString();
			}
			comboMaxProsthMaterial.SelectedIndex=ClaimCur.CanadianMaxProsthMaterial;
			//mand prosth-----------------------------------------------------------------------------------------------------
			switch(ClaimCur.CanadianIsInitialLower) {
				case "Y":
					comboMandProsth.SelectedIndex=1;
					break;
				case "N":
					comboMandProsth.SelectedIndex=2;
					break;
				default: //"X"
					comboMandProsth.SelectedIndex=3;
					break;
			}
			if(ClaimCur.CanadianDateInitialLower.Year<1880) {
				textDateInitialLower.Text="";
			}
			else {
				textDateInitialLower.Text=ClaimCur.CanadianDateInitialLower.ToShortDateString();
			}
			comboMandProsthMaterial.SelectedIndex=ClaimCur.CanadianMandProsthMaterial;
			//Missing and Extracted Teeth--------------------------------------------------------------------------------------
			SetCanadianExtractedTeeth();
			List<ToothInitial> missingList=ToothInitials.Refresh(PatCur.PatNum);
			List<string> al=ToothInitials.GetMissingOrHiddenTeeth(missingList);
			string missingstr="";
			for(int i=0;i<al.Count;i++){
				if(i>0){
					missingstr+=", ";
				}
				missingstr+=Tooth.ToInternat(al[i]);
			}
			textMissingTeeth.Text=missingstr;
		}

		private void SetCanadianExtractedTeeth() {
			listExtractedTeeth.Items.Clear();
			if(comboMaxProsth.SelectedIndex==1 || comboMandProsth.SelectedIndex==1){
				List<Procedure> extractedList=Procedures.GetCanadianExtractedTeeth(ProcList);				
				for(int i=0;i<extractedList.Count;i++) {
					listExtractedTeeth.Items.Add(Tooth.ToInternat(extractedList[i].ToothNum)+"\t"+extractedList[i].ProcDate.ToShortDateString());
				}
			}
		}

		private void comboMaxProsth_SelectionChangeCommitted(object sender,EventArgs e) {
			SetCanadianExtractedTeeth();
		}

		private void comboMandProsth_SelectionChangeCommitted(object sender,EventArgs e) {
			SetCanadianExtractedTeeth();
		}

		private void butRecalc_Click(object sender, System.EventArgs e) {
			if(!ClaimIsValid()){
				return;
			}
			List <Benefit> benefitList=Benefits.Refresh(PatPlanList,SubList);
			ClaimL.CalculateAndUpdate(ProcList,PlanList,ClaimCur,PatPlanList,benefitList,PatCur.Age,SubList);
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}

		private void FillGrids(){
			//must run claimprocs.refresh separately beforehand
			//also recalculates totals because user might have changed certain items.
			double claimFee=0;
			double dedApplied=0;
			double insPayEst=0;
			double insPayAmt=0;
			double writeOff=0;
			decimal labFees=0;
			gridProc.BeginUpdate();
			gridProc.Columns.Clear();
			ODGridColumn col=new ODGridColumn(Lan.g("TableClaimProc","#"),25);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Date"),66);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Prov"),50);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Code"),50);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Tth"),25);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Description"),130);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Fee Billed"),62,HorizontalAlignment.Right);
			gridProc.Columns.Add(col);
			if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//Canadian. en-CA or fr-CA
				col=new ODGridColumn(Lan.g("TableClaimProc","Labs"),62,HorizontalAlignment.Right);
				gridProc.Columns.Add(col);
			}
			col=new ODGridColumn(Lan.g("TableClaimProc","Deduct"),62,HorizontalAlignment.Right);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Ins Est"),62,HorizontalAlignment.Right);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Ins Pay"),62,HorizontalAlignment.Right);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","WriteOff"),62,HorizontalAlignment.Right);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Status"),50,HorizontalAlignment.Center);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Pmt"),30,HorizontalAlignment.Center);
			gridProc.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimProc","Remarks"),0);
			gridProc.Columns.Add(col);
			gridProc.Rows.Clear();
			ODGridRow row;
			Procedure ProcCur;
			ClaimProcsForClaim=ClaimProcs.RefreshForClaim(ClaimCur.ClaimNum);
			for(int i=0;i<ClaimProcsForClaim.Count;i++){
				row=new ODGridRow();
				if(ClaimProcsForClaim[i].LineNumber==0){
					row.Cells.Add("");
				}
				else{
					row.Cells.Add(ClaimProcsForClaim[i].LineNumber.ToString());
				}
				row.Cells.Add(ClaimProcsForClaim[i].ProcDate.ToShortDateString());
				row.Cells.Add(Providers.GetAbbr(((ClaimProc)ClaimProcsForClaim[i]).ProvNum));
				if(ClaimProcsForClaim[i].ProcNum==0) {
					row.Cells.Add("");//code
					row.Cells.Add("");//tooth
					if(ClaimProcsForClaim[i].Status==ClaimProcStatus.NotReceived)
						row.Cells.Add(Lan.g(this,"Estimate"));
					else
						row.Cells.Add(Lan.g(this,"Total Payment"));
				}
				else {
					//claimProcsForClaim list already handles ProcNum=0 above
					ProcCur=Procedures.GetProcFromList(ProcList,ClaimProcsForClaim[i].ProcNum);
					row.Cells.Add(ClaimProcsForClaim[i].CodeSent);
					row.Cells.Add(Tooth.ToInternat(ProcCur.ToothNum));
					ProcedureCode procCodeSent=ProcedureCodes.GetProcCode(ClaimProcsForClaim[i].CodeSent);
					row.Cells.Add(procCodeSent.Descript);
				}
				row.Cells.Add(ClaimProcsForClaim[i].FeeBilled.ToString("F"));
				decimal claimProcInsEst=(decimal)ClaimProcsForClaim[i].InsPayEst;
				if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//Canadian. en-CA or fr-CA
					decimal labFeesForProc=0;
					List<Procedure> labFeeProcs=Procedures.GetCanadianLabFees(ClaimProcsForClaim[i].ProcNum,ProcList);
					for(int j=0;j<labFeeProcs.Count;j++) {
						labFeesForProc+=(decimal)labFeeProcs[j].ProcFee;
						List <ClaimProc> claimProcsForLab=ClaimProcs.GetForProc(ClaimProcList,labFeeProcs[j].ProcNum);
						for(int k=0;k<claimProcsForLab.Count;k++) { //We add the insurance estimate for the lab into the insurance estimate column of the procedure and the claim.
							if(claimProcsForLab[k].PlanNum==ClaimCur.PlanNum && claimProcsForLab[k].InsSubNum==ClaimCur.InsSubNum) { //only claimprocs for the current claim
								claimProcInsEst+=(decimal)ClaimProcs.GetInsEstTotal(claimProcsForLab[k]);
								insPayEst+=ClaimProcs.GetInsEstTotal(claimProcsForLab[k]);
							}
						}
					}
					row.Cells.Add(labFeesForProc.ToString("F"));
					labFees+=labFeesForProc;
				}
				row.Cells.Add(ClaimProcsForClaim[i].DedApplied.ToString("F"));
				row.Cells.Add(claimProcInsEst.ToString("F"));
				row.Cells.Add(ClaimProcsForClaim[i].InsPayAmt.ToString("F"));
				row.Cells.Add(ClaimProcsForClaim[i].WriteOff.ToString("F"));
				switch(ClaimProcsForClaim[i].Status){
					case ClaimProcStatus.Received:
						row.Cells.Add("Recd");
						break;
					case ClaimProcStatus.NotReceived:
						row.Cells.Add("");
						break;
					//adjustment would never show here
					case ClaimProcStatus.Preauth:
						row.Cells.Add("PreA");
						break;
					case ClaimProcStatus.Supplemental:
						row.Cells.Add("Supp");
						break;
					case ClaimProcStatus.CapClaim:
						row.Cells.Add("Cap");
						break;
					case ClaimProcStatus.Estimate:
						row.Cells.Add("");
						MessageBox.Show("error. Estimate loaded.");
						break;
					case ClaimProcStatus.CapEstimate:
						row.Cells.Add("");
						MessageBox.Show("error. CapEstimate loaded.");
						break;
					case ClaimProcStatus.CapComplete:
						row.Cells.Add("");
						MessageBox.Show("error. CapComplete loaded.");
						break;
					//Estimate would never show here
					//Cap would never show here
					default:
						row.Cells.Add("");
						break;
				}
				if(ClaimProcsForClaim[i].ClaimPaymentNum>0){
					row.Cells.Add("X");
				}
				else{
					row.Cells.Add("");
				}
				row.Cells.Add(ClaimProcsForClaim[i].Remarks);
				claimFee+=ClaimProcsForClaim[i].FeeBilled;
				dedApplied+=ClaimProcsForClaim[i].DedApplied;
				insPayEst+=ClaimProcsForClaim[i].InsPayEst;
				insPayAmt+=ClaimProcsForClaim[i].InsPayAmt;
				//if(ClaimProcsForClaim[i].Status==ClaimProcStatus.Received
				//	|| ClaimProcsForClaim[i].Status==ClaimProcStatus.Supplemental) {
					writeOff+=ClaimProcsForClaim[i].WriteOff;
				//}
				gridProc.Rows.Add(row);
			}
			gridProc.EndUpdate();
			if(ClaimCur.ClaimType=="Cap"){
				//zero out ins info if Cap.  This keeps it from affecting the balance.  It could be slightly improved later if there is enough demand to show the inspayamt in the Account module.
				insPayEst=0;
				insPayAmt=0;
			}
			ClaimCur.ClaimFee=claimFee;
			ClaimCur.DedApplied=dedApplied;
			ClaimCur.InsPayEst=insPayEst;
			ClaimCur.InsPayAmt=insPayAmt;
			ClaimCur.WriteOff=writeOff;
			textClaimFee.Text=ClaimCur.ClaimFee.ToString("F");
			textDedApplied.Text=ClaimCur.DedApplied.ToString("F");
			textInsPayEst.Text=ClaimCur.InsPayEst.ToString("F");
			textInsPayAmt.Text=ClaimCur.InsPayAmt.ToString("F");
			textWriteOff.Text=writeOff.ToString("F");
			textLabFees.Text=labFees.ToString("F");
			//payments
			gridPay.BeginUpdate();
			gridPay.Columns.Clear();
			col=new ODGridColumn(Lan.g("TableClaimPay","Date"),70);
			gridPay.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimPay","Type"),60);
			gridPay.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimPay","Amount"),80,HorizontalAlignment.Right);
			gridPay.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimPay","Check Num"),90);
			gridPay.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimPay","Bank/Branch"),100);
			gridPay.Columns.Add(col);
			col=new ODGridColumn(Lan.g("TableClaimPay","Note"),180);
			gridPay.Columns.Add(col);
			gridPay.Rows.Clear();
			tablePayments=ClaimPayments.GetForClaim(ClaimCur.ClaimNum);
			for(int i=0;i<tablePayments.Rows.Count;i++){
				row=new ODGridRow();
				row.Cells.Add(tablePayments.Rows[i]["checkDate"].ToString());
				row.Cells.Add(tablePayments.Rows[i]["payType"].ToString());
				row.Cells.Add(tablePayments.Rows[i]["amount"].ToString());
				row.Cells.Add(tablePayments.Rows[i]["CheckNum"].ToString());
				row.Cells.Add(tablePayments.Rows[i]["BankBranch"].ToString());
				row.Cells.Add(tablePayments.Rows[i]["Note"].ToString());
				gridPay.Rows.Add(row);
			}
			gridPay.EndUpdate();
		}

		private void gridProc_CellClick(object sender,ODGridClickEventArgs e) {
			if(gridPay.GetSelectedIndex()==-1){
				return;
			}
			gridPay.SetSelected(false);
		}
		
		private void gridProc_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			if(!doubleClickWarningAlreadyDisplayed){
				doubleClickWarningAlreadyDisplayed=true;
				if(!MsgBox.Show(this,true,"If you are trying to enter payment information, please use the payments buttons at the upper right.\r\nThen, don't forget to finish by creating the check using the button below this section.\r\nYou should probably click cancel unless you are just editing estimates.\r\nContinue anyway?")){
					return;
				}
			}
			List<ClaimProcHist> histList=null;
			List<ClaimProcHist> loopList=null;
			FormClaimProc FormCP=new FormClaimProc(ClaimProcsForClaim[e.Row],null,FamCur,PatCur,PlanList,histList,ref loopList,PatPlanList,true,SubList);
			FormCP.IsInClaim=true;
			FormCP.ShowDialog();
			if(FormCP.DialogResult!=DialogResult.OK){
				return;
			}
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}

		private void gridPay_CellClick(object sender,ODGridClickEventArgs e) {
			if(e.Row>tablePayments.Rows.Count-1){
				return;//prevents crash after deleting a check?
			}
			for(int i=0;i<ClaimProcsForClaim.Count;i++){
				if(ClaimProcsForClaim[i].ClaimPaymentNum.ToString()==tablePayments.Rows[e.Row]["ClaimPaymentNum"].ToString())
					gridProc.SetSelected(i,true);
				else
					gridProc.SetSelected(i,false);
			}
		}

		private void gridPay_CellDoubleClick(object sender,ODGridClickEventArgs e) {
			long tempClaimNum=ClaimCur.ClaimNum;
			ClaimPayment claimPaymentCur=ClaimPayments.GetOne(PIn.Long(tablePayments.Rows[e.Row]["ClaimPaymentNum"].ToString()));
			FormClaimPayBatch formCPB=new FormClaimPayBatch(claimPaymentCur);
			//FormClaimPayEditOld FormCPE=new FormClaimPayEditOld(claimPaymentCur);
			//Security handled in that form.  Anyone can view.
			formCPB.IsFromClaim=true;//but not IsNew.
			formCPB.ShowDialog();
			//FormCPE.OriginatingClaimNum=ClaimCur.ClaimNum;
			//FormCPE.ShowDialog();
			ClaimList=Claims.Refresh(PatCur.PatNum);
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}

		private void butOtherCovChange_Click(object sender, System.EventArgs e) {
			FormInsPlanSelect FormIPS=new FormInsPlanSelect(PatCur.PatNum);
			FormIPS.ShowDialog();
			if(FormIPS.DialogResult!=DialogResult.OK){
				return;
			}
			ClaimCur.PlanNum2=FormIPS.SelectedPlan.PlanNum;
			ClaimCur.InsSubNum2=FormIPS.SelectedSub.InsSubNum;
			textPlan2.Text=InsPlans.GetDescript(ClaimCur.PlanNum2,FamCur,PlanList,ClaimCur.InsSubNum2,SubList);
			if(textPlan2.Text==""){
				comboPatRelat2.Visible=false;
				label10.Visible=false;
			}
			else{
				comboPatRelat2.Visible=true;
				label10.Visible=true;
			}
		}

		private void butOtherNone_Click(object sender, System.EventArgs e) {
			ClaimCur.PlanNum2=0;
			ClaimCur.InsSubNum2=0;
			ClaimCur.PatRelat2=Relat.Self;
			textPlan2.Text="";
			comboPatRelat2.Visible=false;
			label10.Visible=false;
		}

		private void butPayTotal_Click(object sender, System.EventArgs e) {
			if(!Security.IsAuthorized(Permissions.InsPayCreate)){//date not checked here, but it will be checked when actually creating the check
				return;
			}
			//preauths are only allowed "payment" entry by procedure since a total would be meaningless
			if(ClaimCur.ClaimType=="PreAuth"){
				MessageBox.Show(Lan.g(this,"PreAuthorizations can only be entered by procedure."));
				return;
			}
			if(ClaimCur.ClaimType=="Cap"){
				if(MessageBox.Show(Lan.g(this,"If you enter by total, the insurance payment will affect the patient balance.  It is recommended to enter by procedure instead.  Continue anyway?"),"",MessageBoxButtons.OKCancel)!=DialogResult.OK)
				return;
			}
			Double dedEst=0;
			Double payEst=0;
			for(int i=0;i<ClaimProcsForClaim.Count;i++){
				if(ClaimProcsForClaim[i].Status!=ClaimProcStatus.NotReceived){
					continue;
				}
				if(ClaimProcsForClaim[i].ProcNum==0){
					continue;//also ignore non-procedures.
				}
				//ClaimProcs.Cur=ClaimProcs.ForClaim[i];
				dedEst+=ClaimProcsForClaim[i].DedApplied;
				payEst+=ClaimProcsForClaim[i].InsPayEst;
			}
			ClaimProc ClaimProcCur=new ClaimProc();
			//ClaimProcs.Cur.ProcNum 
			ClaimProcCur.ClaimNum=ClaimCur.ClaimNum;
			ClaimProcCur.PatNum=ClaimCur.PatNum;
			ClaimProcCur.ProvNum=ClaimCur.ProvTreat;
			//ClaimProcs.Cur.FeeBilled
			//ClaimProcs.Cur.InsPayEst
			ClaimProcCur.DedApplied=dedEst;
			ClaimProcCur.Status=ClaimProcStatus.Received;
			ClaimProcCur.InsPayAmt=payEst;
			//remarks
			//ClaimProcs.Cur.ClaimPaymentNum
			ClaimProcCur.PlanNum=ClaimCur.PlanNum;
			ClaimProcCur.InsSubNum=ClaimCur.InsSubNum;
			ClaimProcCur.DateCP=DateTimeOD.Today;
			ClaimProcCur.ProcDate=ClaimCur.DateService;
			ClaimProcCur.DateEntry=DateTime.Now;//will get set anyway
			ClaimProcCur.ClinicNum=ClaimCur.ClinicNum;
			//Automatically set PayPlanNum if there is a payplan with matching PatNum, PlanNum, and InsSubNum that has not been paid in full.
			//By sending in ClaimNum, we ensure that we only get the payplan a claimproc from this claim was already attached to or payplans with no claimprocs attached.
			List<PayPlan> payPlanList=PayPlans.GetValidInsPayPlans(ClaimProcCur.PatNum,ClaimProcCur.PlanNum,ClaimProcCur.InsSubNum,ClaimProcCur.ClaimNum);
			ClaimProcCur.PayPlanNum=0;
			if(payPlanList.Count==1) {
				ClaimProcCur.PayPlanNum=payPlanList[0].PayPlanNum;
			}
			else if(payPlanList.Count>1) {
				//more than one valid PayPlan
				List<PayPlanCharge> chargeList=PayPlanCharges.Refresh(ClaimProcCur.PatNum);
				FormPayPlanSelect FormPPS=new FormPayPlanSelect(payPlanList,chargeList);
				FormPPS.ShowDialog();
				if(FormPPS.DialogResult==DialogResult.OK) {
					ClaimProcCur.PayPlanNum=payPlanList[FormPPS.IndexSelected].PayPlanNum;
				}
			}
			ClaimProcs.Insert(ClaimProcCur);
			List<ClaimProcHist> loopList=null;
			FormClaimProc FormCP=new FormClaimProc(ClaimProcCur,null,FamCur,PatCur,PlanList,null,ref loopList,PatPlanList,true,SubList);
			FormCP.IsInClaim=true;
			FormCP.ShowDialog();
			if(FormCP.DialogResult!=DialogResult.OK){
				ClaimProcs.Delete(ClaimProcCur);
			}
			else{
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					if(ClaimProcsForClaim[i].Status!=ClaimProcStatus.NotReceived){
						continue;
					}
					//ClaimProcs.Cur=ClaimProcs.ForClaim[i];
					ClaimProcsForClaim[i].Status=ClaimProcStatus.Received;
					if(ClaimProcsForClaim[i].DedApplied>0){
						ClaimProcsForClaim[i].InsPayEst+=ClaimProcsForClaim[i].DedApplied;
						ClaimProcsForClaim[i].DedApplied=0;//because ded will show as part of payment now.
					}
					ClaimProcsForClaim[i].DateEntry=DateTime.Now;//the date is was switched to rec'd
					ClaimProcs.Update(ClaimProcsForClaim[i]);
				}
			}
			comboClaimStatus.SelectedIndex=5;//Received
			if(textDateRec.Text==""){
				textDateRec.Text=DateTime.Today.ToShortDateString();
			}
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}

		private void butPayProc_Click(object sender, System.EventArgs e) {
			if(!Security.IsAuthorized(Permissions.InsPayCreate)){//date not checked here, but it will be checked when actually creating the check
				return;
			}
			//this will work for regular claims and for preauths.
			//it will enter edit mode if it can only find received procs not attached to payments yet.
			if(gridProc.SelectedIndices.Length==0){
				//first, autoselect rows if not received:
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					if(ClaimProcsForClaim[i].Status==ClaimProcStatus.NotReceived
						&& ClaimProcsForClaim[i].ProcNum>0){//and is procedure
						gridProc.SetSelected(i,true);
					}
				}
			}
			if(gridProc.SelectedIndices.Length==0){
				//then, autoselect rows if not paid on:
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					if(ClaimProcsForClaim[i].ClaimPaymentNum==0
						&& ClaimProcsForClaim[i].ProcNum>0){//and is procedure
						gridProc.SetSelected(i,true);
					}
				}
			}
			if(gridProc.SelectedIndices.Length==0){
				//if still no rows selected
				MessageBox.Show(Lan.g(this,"All procedures in the list have already been paid."));
				return;
			}
			bool allAreProcs=true;
			for(int i=0;i<gridProc.SelectedIndices.Length;i++){
				if(ClaimProcsForClaim[gridProc.SelectedIndices[i]].ProcNum==0)
					allAreProcs=false;
			}
			if(!allAreProcs){
				MessageBox.Show(Lan.g(this,"You can only select procedures."));
				return;
			}
			for(int i=0;i<gridProc.SelectedIndices.Length;i++) {
				if(ClaimProcsForClaim[gridProc.SelectedIndices[i]].ClaimPaymentNum!=0) {//if attached to a check
					MessageBox.Show(Lan.g(this,"Procedures that are attached to checks cannot be included."));
					return;
				}
			}
			for(int i=0;i<gridProc.SelectedIndices.Length;i++) {
				if(ClaimProcsForClaim[gridProc.SelectedIndices[i]].Status==ClaimProcStatus.Received
					|| ClaimProcsForClaim[gridProc.SelectedIndices[i]].Status==ClaimProcStatus.Supplemental
					|| ClaimProcsForClaim[gridProc.SelectedIndices[i]].Status==ClaimProcStatus.CapComplete) 
				{
					MessageBox.Show(Lan.g(this,"Procedures that are already received cannot be included."));
					//This expanded security prevents making changes to historical entries of zero with a writeoff.
					return;
				}
			}
			List<ClaimProc> cpList=new List<ClaimProc>();
			for(int i=0;i<gridProc.SelectedIndices.Length;i++) {
				//copy selected claimprocs to temporary array for editing.
				//no changes to the database will be made within that form.
				cpList.Add(ClaimProcsForClaim[gridProc.SelectedIndices[i]].Copy());
				if(ClaimCur.ClaimType=="PreAuth"){
					cpList[i].Status=ClaimProcStatus.Preauth;
				}
				else if(ClaimCur.ClaimType=="Cap"){
					;//do nothing.  The claimprocstatus will remain Capitation.
				}
				else{
					cpList[i].Status=ClaimProcStatus.Received;
					cpList[i].DateEntry=DateTime.Now;//date is was set rec'd
					cpList[i].InsPayAmt=cpList[i].InsPayEst;
					cpList[i].PayPlanNum=0;
					if(i==0) {
						//Automatically set PayPlanNum if there is a payplan with matching PatNum, PlanNum, and InsSubNum that has not been paid in full.
						//By sending in ClaimNum, we ensure that we only get the payplan a claimproc from this claim was already attached to or payplans with no claimprocs attached.
						List<PayPlan> payPlanList=PayPlans.GetValidInsPayPlans(cpList[i].PatNum,cpList[i].PlanNum,cpList[i].InsSubNum,cpList[i].ClaimNum);
						if(payPlanList.Count==1) {
							cpList[i].PayPlanNum=payPlanList[0].PayPlanNum;
						}
						else if(payPlanList.Count>1) {
							//more than one valid PayPlan
							List<PayPlanCharge> chargeList=PayPlanCharges.Refresh(cpList[i].PatNum);
							FormPayPlanSelect FormPPS=new FormPayPlanSelect(payPlanList,chargeList);
							FormPPS.ShowDialog();
							if(FormPPS.DialogResult==DialogResult.OK) {
								cpList[i].PayPlanNum=payPlanList[FormPPS.IndexSelected].PayPlanNum;
							}
						}
					}
					else {
						cpList[i].PayPlanNum=cpList[0].PayPlanNum;//set all procs to the same payplan, they can change it later if not correct for each claimproc that is different
					}
				}
				cpList[i].DateCP=DateTimeOD.Today;
			}
			if(ClaimCur.ClaimType=="PreAuth") {
				FormClaimPayPreAuth FormCPP=new FormClaimPayPreAuth(PatCur,FamCur,PlanList,PatPlanList,SubList);
				FormCPP.ClaimProcsToEdit=cpList;
				FormCPP.ShowDialog();
				if(FormCPP.DialogResult!=DialogResult.OK) {
					return;
				}
				//save changes now
				for(int i=0;i<FormCPP.ClaimProcsToEdit.Count;i++) {
					ClaimProcs.Update(FormCPP.ClaimProcsToEdit[i]);
					ClaimProcs.SetInsEstTotalOverride(FormCPP.ClaimProcsToEdit[i].ProcNum,FormCPP.ClaimProcsToEdit[i].PlanNum,
						FormCPP.ClaimProcsToEdit[i].InsPayEst,ClaimProcList);
				}
			}
			else {
				FormClaimPayTotal FormCPT=new FormClaimPayTotal(PatCur,FamCur,PlanList,PatPlanList,SubList);
				FormCPT.ClaimProcsToEdit=cpList.ToArray();
				FormCPT.ShowDialog();
				if(FormCPT.DialogResult!=DialogResult.OK){
					return;
				}
				//save changes now
				for(int i=0;i<FormCPT.ClaimProcsToEdit.Length;i++){
					ClaimProcs.Update(FormCPT.ClaimProcsToEdit[i]);
				}
			}
			comboClaimStatus.SelectedIndex=5;//Received
			if(textDateRec.Text==""){
				textDateRec.Text=DateTime.Today.ToShortDateString();
			}
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}

		private void butPaySupp_Click(object sender, System.EventArgs e) {
			if(!Security.IsAuthorized(Permissions.InsPayCreate)){//date not checked here, but it will be checked when actually creating the check
				return;
			}
			if(gridProc.SelectedIndices.Length==0){
				MessageBox.Show(Lan.g(this,"This is only for additional payments on procedures already marked received.  Please highlight procedures first."));
				return;
			}
			bool allAreRecd=true;
			for(int i=0;i<gridProc.SelectedIndices.Length;i++){
				if(ClaimProcsForClaim[gridProc.SelectedIndices[i]].Status!=ClaimProcStatus.Received)
					allAreRecd=false;
			}
			if(!allAreRecd){
				MessageBox.Show(Lan.g(this,"All selected procedures must be status received."));
				return;
			} 
			List<ClaimProc> cpList=new List<ClaimProc>();
			for(int i=0;i<gridProc.SelectedIndices.Length;i++){
				ClaimProc ClaimProcCur=ClaimProcsForClaim[gridProc.SelectedIndices[i]];
				ClaimProcCur.FeeBilled=0;
				ClaimProcCur.ClaimPaymentNum=0;//no payment attached
				//claimprocnum will be overwritten
				ClaimProcCur.DedApplied=0;
				ClaimProcCur.InsPayAmt=0;
				ClaimProcCur.InsPayEst=0;
				ClaimProcCur.Remarks="";
				ClaimProcCur.Status=ClaimProcStatus.Supplemental;
				ClaimProcCur.WriteOff=0;
				ClaimProcCur.DateCP=DateTimeOD.Today;
				ClaimProcCur.DateEntry=DateTimeOD.Today;
				ClaimProcs.Insert(ClaimProcCur);//this inserts a copy of the original with the changes as above.
				cpList.Add(ClaimProcCur);
			}
			FormClaimPayTotal FormCPT=new FormClaimPayTotal(PatCur,FamCur,PlanList,PatPlanList,SubList);
			FormCPT.ClaimProcsToEdit=cpList.ToArray();
			FormCPT.ShowDialog();
			if(FormCPT.DialogResult!=DialogResult.OK) {
				//ClaimProcs were inserted already, refresh the list to reflect the new entries.
				ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
				FillGrids();
				return;
			}
			//save changes now
			for(int i=0;i<FormCPT.ClaimProcsToEdit.Length;i++) {
				ClaimProcs.Update(FormCPT.ClaimProcsToEdit[i]);
			}
//fix: need to debug the recalculation feature to take this status into account.
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}

		private void butSplit_Click(object sender, System.EventArgs e) {
			if(!ClaimIsValid()){
				return;
			}
			UpdateClaim();
			if(gridProc.SelectedIndices.Length==0){
				MessageBox.Show(Lan.g(this,"Please highlight procedures first."));
				return;
			}
			for(int i=0;i<gridProc.SelectedIndices.Length;i++){
				if(ClaimProcsForClaim[gridProc.SelectedIndices[i]].ProcNum==0){
					MessageBox.Show(Lan.g(this,"Only procedures can be selected."));
					return;
				}
				if(ClaimProcsForClaim[gridProc.SelectedIndices[i]].InsPayAmt!=0){
					MessageBox.Show(Lan.g(this,"All selected procedures must have zero insurance payment amounts."));
					return;
				}
			}
			Claim newClaim=ClaimCur.Copy();
			newClaim.ClaimFee=0;
			newClaim.DedApplied=0;
			newClaim.InsPayEst=0;
			newClaim.InsPayAmt=0;
			newClaim.WriteOff=0;
			Claims.Insert(newClaim);//We must insert here so that we have the primary key in the loop below.
			//Originally, we thought that giving the split claim a unique claim identifier was important, because we thought that the user would send the split claim similar to how the original claim was sent.
			//Now all split claims will share the same claim identifier for the following reasons:
			//1) In electronic remittance advice (X12 format 835), split claims all share the same claim identifier as the original claim.  Using the same claim identifier pattern as the ERAs makes claim matching easier when ERAs are received.
			//2) When sending an eclaim, OD will block the user if the claim identifier is the same as another claim, which is good because we do not want split claims to be sent, only the original claim must be sent.
			//newClaim.ClaimIdentifier=newClaim.PatNum.ToString()+"/"+newClaim.ClaimNum.ToString();
			//Now this claim has been duplicated, except it has a new ClaimNum and new totals.  There are no attached claimprocs yet.
			for(int i=0;i<gridProc.SelectedIndices.Length;i++){
				ClaimProc claimProc=ClaimProcsForClaim[gridProc.SelectedIndices[i]];
				claimProc.ClaimNum=newClaim.ClaimNum;
				claimProc.PayPlanNum=0;//detach from payplan if previously attached, claimprocs from two claims cannot be attached to the same payplan
				ClaimProcs.Update(claimProc);//moves it to the new claim
				newClaim.ClaimFee+=claimProc.FeeBilled;
				newClaim.DedApplied+=claimProc.DedApplied;
				newClaim.InsPayEst+=claimProc.InsPayEst;
				newClaim.InsPayAmt+=claimProc.InsPayAmt;
				newClaim.WriteOff+=claimProc.WriteOff;
			}
			Claims.Update(newClaim);
			ClaimCur.ClaimFee-=newClaim.ClaimFee;
			ClaimCur.DedApplied-=newClaim.DedApplied;
			ClaimCur.InsPayEst-=newClaim.InsPayEst;
			ClaimCur.InsPayAmt-=newClaim.InsPayAmt;
			ClaimCur.WriteOff-=newClaim.WriteOff;
			Claims.Update(ClaimCur);
			//now, set Claims.Cur back to the originalClaim.  The new claim will now show on the account.
			//ClaimCur=originalClaim;//.Clone()
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}

		/*
		///<summary>Creates insurance check</summary>
		private void butCheckAdd_Click(object sender, System.EventArgs e) {
			if(!Security.IsAuthorized(Permissions.InsPayCreate)){//date not checked here, but it will be checked when saving the check to prevent backdating
				return;
			}
			bool existsReceived=false;
			for(int i=0;i<ClaimProcsForClaim.Count;i++){
				if((ClaimProcsForClaim[i].Status==ClaimProcStatus.Received
					|| ClaimProcsForClaim[i].Status==ClaimProcStatus.Supplemental)
					&& ClaimProcsForClaim[i].InsPayAmt!=0)
				{
					existsReceived=true;
				}
			}
			if(!existsReceived){
				MessageBox.Show(Lan.g(this,"There are no valid received payments for this claim."));
				return;
			}
			long tempClaimNum=ClaimCur.ClaimNum;
			ClaimPayment ClaimPaymentCur=new ClaimPayment();
			ClaimPaymentCur.CheckDate=DateTime.Today;
			ClaimPaymentCur.ClinicNum=PatCur.ClinicNum;
			ClaimPaymentCur.CarrierName=Carriers.GetName(InsPlans.GetPlan(ClaimCur.PlanNum,PlanList).CarrierNum);
			ClaimPayments.Insert(ClaimPaymentCur);
			FormClaimPayEditOld FormCPE=new FormClaimPayEditOld(ClaimPaymentCur);
			FormCPE.OriginatingClaimNum=ClaimCur.ClaimNum;
			FormCPE.IsNew=true;
			FormCPE.ShowDialog();
			//ClaimPaymentCur gets deleted within that form if user clicks cancel.
			ClaimList=Claims.Refresh(PatCur.PatNum);
			ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillGrids();
		}*/

		private void butBatch_Click(object sender,EventArgs e) {
			if(!Security.IsAuthorized(Permissions.InsPayCreate)) {//date not checked here, but it will be checked when saving the check to prevent backdating
				return;
			}
			if(!ClaimIsValid()) {
				return;
			}
			UpdateClaim();
			bool existsReceived=false;
			bool isSupplemental=false;
			for(int i=0;i<ClaimProcsForClaim.Count;i++) {
				if((ClaimProcsForClaim[i].Status==ClaimProcStatus.Received
					|| ClaimProcsForClaim[i].Status==ClaimProcStatus.Supplemental)
					&& ClaimProcsForClaim[i].InsPayAmt!=0) 
				{
					existsReceived=true;
				}
				//Supplemental, has an insurance payment amount entered, and is not attached to a check yet, therefore it will be attached to the check below.
				if(ClaimProcsForClaim[i].Status==ClaimProcStatus.Supplemental && ClaimProcsForClaim[i].InsPayAmt!=0 && ClaimProcsForClaim[i].ClaimPaymentNum==0) {
					isSupplemental=true;
				}
			}
			if(!existsReceived) {
				MessageBox.Show(Lan.g(this,"There are no valid received payments for this claim."));
				return;
			}
			ClaimPayment claimPayment=new ClaimPayment();
			if(isSupplemental) {
				claimPayment.CheckDate=DateTimeOD.Today;//We cannot use the date the claim was received, because the claim received date corresponds to the first check.
			}
			else {
				claimPayment.CheckDate=ClaimCur.DateReceived;//This date is validated and parsed from the UI when UpdateClaim() is called above.
			}
			claimPayment.IsPartial=true;
			claimPayment.ClinicNum=PatCur.ClinicNum;
			claimPayment.CarrierName=Carriers.GetName(InsPlans.GetPlan(ClaimCur.PlanNum,PlanList).CarrierNum);
			ClaimPayments.Insert(claimPayment);
			double amt=ClaimProcs.AttachAllOutstandingToPayment(claimPayment.ClaimPaymentNum);
			claimPayment.CheckAmt=amt;
			ClaimPayments.Update(claimPayment);
			FormClaimPayEdit FormCPE=new FormClaimPayEdit(claimPayment);
			//FormCPE.IsNew=true;//not new.  Already added.
			FormCPE.ShowDialog();
			if(FormCPE.DialogResult!=DialogResult.OK) {
				ClaimPayments.Delete(claimPayment);
				return;
			}
			FormClaimPayBatch FormCPB=new FormClaimPayBatch(claimPayment);
			FormCPB.IsFromClaim=true;
			FormCPB.IsNew=true;
			FormCPB.ShowDialog();
			if(FormCPB.DialogResult!=DialogResult.OK) {
				//The user attached EOBs to the new claim payment and then clicked cancel. Then the user was asked if they wanted to delete the payment and they chose yes.
				//Since we are deleting the claim payment we must remove the attached EOBs or else ClaimPayments.Delete() will throw an exception.
				List<EobAttach> eobsAttached=EobAttaches.Refresh(claimPayment.ClaimPaymentNum);
				for(int i=0;i<eobsAttached.Count;i++) {
					EobAttaches.Delete(eobsAttached[i].EobAttachNum);
				}
				ClaimPayments.Delete(claimPayment);
				return;
			}
			//ClaimList=Claims.Refresh(PatCur.PatNum);
			//ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			//FillGrids();
			//At this point we know the user just added an insurance payment.  Check to see if they want the provider transfer window to show.
			ShowProviderTransferWindow();
			DialogResult=DialogResult.OK;
		}

		///<summary>Helper method that shows the payment window if the user has the "Show provider income transfer window after entering insurance payment" preference enabled.
		///This method should always be called after an insurance payment has been made.</summary>
		private void ShowProviderTransferWindow() {
			if(!PrefC.GetBool(PrefName.ProviderIncomeTransferShows)) {
				return;
			}
			Payment PaymentCur=new Payment();
			PaymentCur.PayDate=DateTimeOD.Today;
			PaymentCur.PatNum=PatCur.PatNum;
			PaymentCur.ClinicNum=PatCur.ClinicNum;
			PaymentCur.PayType=0;//txfr
			PaymentCur.DateEntry=DateTimeOD.Today;//So that it will show properly in the new window.
			Payments.Insert(PaymentCur);
			FormPayment Formp=new FormPayment(PatCur,FamCur,PaymentCur);
			Formp.IsNew=true;
			Formp.ShowDialog();
		}

		private void radioProsthN_Click(object sender, System.EventArgs e) {
			ClaimCur.IsProsthesis="N";
		}

		private void radioProsthI_Click(object sender, System.EventArgs e) {
			ClaimCur.IsProsthesis="I";
		}

		private void radioProsthR_Click(object sender, System.EventArgs e) {
			ClaimCur.IsProsthesis="R";
		}

		private void butReferralNone_Click(object sender,EventArgs e) {
			textRefProv.Text="";
			ClaimCur.ReferringProv=0;
			butReferralEdit.Enabled=false;
		}

		private void butReferralSelect_Click(object sender,EventArgs e) {
			FormReferralSelect FormR=new FormReferralSelect();
			FormR.IsSelectionMode=true;
			FormR.ShowDialog();
			if(FormR.DialogResult!=DialogResult.OK) {
				return;
			}
			ClaimCur.ReferringProv=FormR.SelectedReferral.ReferralNum;
			textRefProv.Text=Referrals.GetNameLF(FormR.SelectedReferral.ReferralNum);
			butReferralEdit.Enabled=true;
		}

		private void butReferralEdit_Click(object sender,EventArgs e) {
			//only enabled if ClaimCur.ReferringProv!=0
			Referral refer=null;
			try {
				refer=Referrals.GetReferral(ClaimCur.ReferringProv);
			}
			catch { }
			if(refer==null){
				MsgBox.Show(this,"Referral not found.");
				textRefProv.Text="";
				ClaimCur.ReferringProv=0;
				butReferralEdit.Enabled=false;
			}
			FormReferralEdit FormR=new FormReferralEdit(refer);
			FormR.ShowDialog();
			if(FormR.DialogResult==DialogResult.OK){
				//it's impossible to delete referral from that window.
				Referrals.RefreshCache();
				textRefProv.Text=Referrals.GetNameLF(refer.ReferralNum);
			}
		}

		private void FillAttachments(){
			listAttachments.Items.Clear();
			for(int i=0;i<ClaimCur.Attachments.Count;i++){
				listAttachments.Items.Add(ClaimCur.Attachments[i].DisplayedFileName);
			}
		}

		private void butAttachAdd_Click(object sender,EventArgs e) {
			FormImageSelectClaimAttach FormI=new FormImageSelectClaimAttach();
			FormI.PatNum=ClaimCur.PatNum;
			FormI.ShowDialog();
			if(FormI.DialogResult!=DialogResult.OK){
				return;
			}
			ClaimCur.Attachments.Add(FormI.ClaimAttachNew);
			FillAttachments();
			if(textRadiographs.errorProvider1.GetError(textRadiographs)==""){
				int radiographs=PIn.Int(textRadiographs.Text);
				radiographs++;
				textRadiographs.Text=radiographs.ToString();
			}
		}

		private void butAttachPerio_Click(object sender,EventArgs e) {
			//Patient PatCur=Patients.GetPat(PatNum);
			if(!PrefC.AtoZfolderUsed) {
				MsgBox.Show(this,"Error. Not using AtoZ images folder.");
				return;
			}
			ContrPerio gridP=new ContrPerio();
			gridP.BackColor = System.Drawing.SystemColors.Window;
			gridP.Size = new System.Drawing.Size(595,665);
			PerioExams.Refresh(PatCur.PatNum);
			PerioMeasures.Refresh(PatCur.PatNum,PerioExams.ListExams);
			gridP.SelectedExam=PerioExams.ListExams.Count-1;
			gridP.LoadData();
			Bitmap bitmap=new Bitmap(595,665);
			Graphics g=Graphics.FromImage(bitmap);
			gridP.DrawChart(g);
			g.Dispose();
			Bitmap bitmapBig=new Bitmap(595,715);
			g=Graphics.FromImage(bitmapBig);
			g.Clear(Color.White);
			string text=PatCur.GetNameFL();
			Font font=new Font("Microsoft Sans Serif",12,FontStyle.Bold);
			g.DrawString(text,font,Brushes.Black,595/2-g.MeasureString(text,font).Width/2,5);
			text=PrefC.GetString(PrefName.PracticeTitle);
			font=new Font("Microsoft Sans Serif",9,FontStyle.Bold);
			g.DrawString(text,font,Brushes.Black,595/2-g.MeasureString(text,font).Width/2,28);
			g.DrawImage(bitmap,0,50);
			g.Dispose();
			Random rnd=new Random();
			string newName=DateTime.Now.ToString("yyyyMMdd")+"_"+DateTime.Now.TimeOfDay.Ticks.ToString()+rnd.Next(1000).ToString()+".jpg";
			string attachPath=EmailMessages.GetEmailAttachPath();
			string newPath=ODFileUtils.CombinePaths(attachPath,newName);
			try {
				bitmapBig.Save(newPath);
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
				return;
			}
			ClaimAttach claimAttach=new ClaimAttach();
			claimAttach.DisplayedFileName=Lan.g(this,"PerioChart.jpg");
			claimAttach.ActualFileName=newName;
			ClaimCur.Attachments.Add(claimAttach);
			FillAttachments();
		}

		private void butExport_Click(object sender,EventArgs e) {
			string exportPath=PrefC.GetString(PrefName.ClaimAttachExportPath);
			if(!Directory.Exists(exportPath)){
				MessageBox.Show("The claim export path no longer exists at: "+exportPath);
				return;
			}
			for(int i=0;i<ClaimCur.Attachments.Count;i++){
				string curAttachPath=ODFileUtils.CombinePaths(new string[] {
					EmailMessages.GetEmailAttachPath(),ClaimCur.Attachments[i].ActualFileName});			
				if(!File.Exists(curAttachPath)){
					MessageBox.Show("The attachment file "+curAttachPath+" has been moved, deleted or is inaccessible.");
					return;
				}
				string newFilePath=ODFileUtils.CombinePaths(exportPath,
					PatCur.FName+PatCur.LName+PatCur.PatNum+"_"+i+Path.GetExtension(curAttachPath));
				try{
					File.Copy(curAttachPath,newFilePath);
				}
				catch{
					MessageBox.Show("The attachemnt "+curAttachPath+" could not be copied to the export folder, "+
						"probably because of an incorrect file permission. Aborting export operation.");
					return;
				}
			}
			MsgBox.Show(this,"Done");
		}

		private void contextMenuAttachments_Popup(object sender,EventArgs e) {
			if(listAttachments.SelectedIndex==-1) {
				menuItemOpen.Enabled=false;
				menuItemRename.Enabled=false;
				menuItemRemove.Enabled=false;
			}
			else {
				menuItemOpen.Enabled=true;
				menuItemRename.Enabled=true;
				menuItemRemove.Enabled=true;
			}
		}

		private void menuItemOpen_Click(object sender,EventArgs e) {
			OpenFile();
		}

		private void menuItemRename_Click(object sender,EventArgs e) {
			InputBox input=new InputBox(Lan.g(this,"Filename"));
			input.textResult.Text=ClaimCur.Attachments[listAttachments.SelectedIndex].DisplayedFileName;
			input.ShowDialog();
			if(input.DialogResult!=DialogResult.OK) {
				return;
			}
			ClaimCur.Attachments[listAttachments.SelectedIndex].DisplayedFileName=input.textResult.Text;
			FillAttachments();
		}

		private void menuItemRemove_Click(object sender,EventArgs e) {
			ClaimCur.Attachments.RemoveAt(listAttachments.SelectedIndex);
			FillAttachments();
		}

		private void listAttachments_DoubleClick(object sender,EventArgs e) {
			if(listAttachments.SelectedIndex==-1) {
				return;
			}
			OpenFile();
		}

		private void OpenFile() {
			//We have to create a copy of the file because the name is different.
			//There is also a high probability that the attachment no longer exists if
			//the A to Z folders are disabled, since the file will have originally been
			//placed in the temporary directory.
			string attachPath=EmailMessages.GetEmailAttachPath();
			try {
				string tempFile
					=ODFileUtils.CombinePaths(PrefL.GetTempFolderPath(),ClaimCur.Attachments[listAttachments.SelectedIndex].DisplayedFileName);
				File.Copy(
					ODFileUtils.CombinePaths(attachPath,ClaimCur.Attachments[listAttachments.SelectedIndex].ActualFileName),
					tempFile,
					true);
				Process.Start(tempFile);
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void listAttachments_MouseDown(object sender,MouseEventArgs e) {
			//A right click also needs to select an items so that the context menu will work properly.
			if(e.Button==MouseButtons.Right) {
				int clickedIndex=listAttachments.IndexFromPoint(e.X,e.Y);
				if(clickedIndex!=-1) {
					listAttachments.SelectedIndex=clickedIndex;
				}
			}
		}

		private void comboProvNumOrdering_SelectionChangeCommitted(object sender,EventArgs e) {
			_provNumOrderingSelected=ProviderC.ListShort[comboProvNumOrdering.SelectedIndex].ProvNum;
		}

		private void butPickProvOrdering_Click(object sender,EventArgs e) {
			FormProviderPick formP=new FormProviderPick();
			if(comboProvNumOrdering.SelectedIndex > -1) {//Initial formP selection if selected prov is not hidden.
				formP.SelectedProvNum=_provNumOrderingSelected;
			}
			formP.ShowDialog();
			if(formP.DialogResult!=DialogResult.OK) {
				return;
			}
			comboProvNumOrdering.SelectedIndex=Providers.GetIndex(formP.SelectedProvNum);
			_provNumOrderingSelected=formP.SelectedProvNum;
		}

		private void butNoneProvOrdering_Click(object sender,EventArgs e) {
			_provNumOrderingSelected=0;
			comboProvNumOrdering.SelectedIndex=-1;
		}

		private void butMissingTeethHelp_Click(object sender,EventArgs e) {
			MessageBox.Show("As explained in the manual, extracted teeth are pulled from the procedure history.  Any extraction with a status of Complete, Existing Current, or Existing Other will be included.  But the extraction must also have a valid date.  So to add an extracted tooth to this list, go to the Chart module, and add an extraction with a status of EO and a date that is as accurate as possible.  Furthermore, extracted teeth will only show here if at least one of the fields for initial placement upper or lower is marked Yes.\r\n\r\nMissing teeth are not pulled from procedure history, but from the missing teeth tab of the Chart module.  Teeth can be marked missing without having an extraction date.");
		}

		private void butLabel_Click(object sender, System.EventArgs e) {
			//LabelSingle label=new LabelSingle();
			//PrintDocument pd=new PrintDocument();//only used to pass printerName
			//if(!PrinterL.SetPrinter(pd,PrintSituation.LabelSingle)){
			//  return;
			//}
			//ask if print secondary?
			InsPlan planCur=InsPlans.GetPlan(ClaimCur.PlanNum,PlanList);
			Carrier carrierCur=Carriers.GetCarrier(planCur.CarrierNum);
			LabelSingle.PrintCarrier(carrierCur.CarrierNum);//pd.PrinterSettings.PrinterName);
		}

		private void butPreview_Click(object sender, System.EventArgs e) {
			if(!ClaimIsValid()) {
				return;
			}
			UpdateClaim();
			FormClaimPrint FormCP=new FormClaimPrint();
			FormCP.PatNumCur=ClaimCur.PatNum;
			FormCP.ClaimNumCur=ClaimCur.ClaimNum;
			FormCP.PrintImmediately=false;
			FormCP.ShowDialog();
			if(FormCP.DialogResult==DialogResult.OK) {
				//status will have changed to sent.
				ClaimCur=Claims.GetClaim(ClaimCur.ClaimNum);
			}
			ClaimList=Claims.Refresh(PatCur.PatNum); 
      ClaimProcList=ClaimProcs.Refresh(PatCur.PatNum);
			FillForm();
			//no need to FillCanadian.  Nothing has changed.
		}

		private void ButPrint_Click(object sender,System.EventArgs e) {
			if(!ClaimIsValid()){
				return;
			}
			if(textDateSent.Text=="") {
				textDateSent.Text=DateTime.Today.ToShortDateString();
			}
			UpdateClaim();
			PrintDocument pd=new PrintDocument();
			if(!PrinterL.SetPrinter(pd,PrintSituation.Claim,PatCur.PatNum,"Claim from "+ClaimCur.DateService.ToShortDateString()+" printed")) {
				return;
			}
			FormClaimPrint FormCP=new FormClaimPrint();
			FormCP.PatNumCur=ClaimCur.PatNum;
			FormCP.ClaimNumCur=ClaimCur.ClaimNum;
			if(!FormCP.PrintImmediate(pd.PrinterSettings)) {
				return;
			}
			if(!notAuthorized) {//if already sent, we want to block users from changing sent date without permission.
				//also changes claimstatus to sent, and date:
				Etranss.SetClaimSentOrPrinted(ClaimCur.ClaimNum,ClaimCur.PatNum,0,EtransType.ClaimPrinted,0);
			}
			//ClaimCur.ClaimStatus="S";
			//ClaimCur.DateSent=DateTime.Today;
			//Claims.Update(ClaimCur);
			DialogResult=DialogResult.OK;
		}

		private void butSend_Click(object sender,EventArgs e) {
			SendClaim();
		}

		private void SendClaim() {
			if(!ClaimIsValid()) {
				return;
			}
			if(comboCorrectionType.SelectedIndex!=0) { //not original (replacement or void)
				textDateResent.Text=DateTime.Now.ToShortDateString();
			}
			UpdateClaim();
			ClaimSendQueueItem[] listQueue=Claims.GetQueueList(ClaimCur.ClaimNum,ClaimCur.ClinicNum,0);
			if(listQueue[0].NoSendElect) {
				MsgBox.Show(this,"This carrier is marked to not receive e-claims.");
				//Later: we need to let user send anyway, using all 0's for electronic id.
				return;
			}
			//string warnings;
			//string missingData=
			Eclaims.Eclaims.GetMissingData(listQueue[0]);//,out warnings);
			if(listQueue[0].MissingData!=""){
				MessageBox.Show(Lan.g(this,"Cannot send claim until missing data is fixed:")+"\r\n"+listQueue[0].MissingData);
				return;
			}
			Cursor=Cursors.WaitCursor;
			Clearinghouse clearhouse=ClearinghouseL.GetClearinghouse(listQueue[0].ClearinghouseNum);
			if(clearhouse.Eformat==ElectronicClaimFormat.Canadian) {
				try {
					Eclaims.Canadian.SendClaim(listQueue[0],true);//Ignore the etransNum result. Physically print the form.
				}
				catch(ApplicationException ex){
					//Custom error messages are thrown as ApplicationExceptions in SendClaim().
					//There are probably no other scenarios where an ApplicationException thrown.  If there are, then the user will still get the message, but not the details.  Not a big deal.
					Cursor=Cursors.Default;
					//The message is translated before thrown, so we do not need to translate here.
					//We show the message in a copy/paste window so that our techs and users can quickly copy the message and search for a solution.
					MsgBoxCopyPaste form=new MsgBoxCopyPaste(ex.Message);
					form.ShowDialog();
					return;
				}
				catch(Exception ex) {
					Cursor=Cursors.Default;
					//The message is translated before thrown, so we do not need to translate here.
					//We show the message in a copy/paste window so that our techs and users can quickly copy the message and search for a solution.
					MsgBoxCopyPaste form=new MsgBoxCopyPaste(ex.ToString());
					form.ShowDialog();
					return;
				}
			}
			else {
				List<ClaimSendQueueItem> queueItems=new List<ClaimSendQueueItem>();
				queueItems.Add(listQueue[0]);
				EnumClaimMedType medType=listQueue[0].MedType;
				Eclaims.Eclaims.SendBatch(queueItems,clearhouse,medType);//this also calls SetClaimSentOrPrinted which creates the etrans entry.
			}
			Cursor=Cursors.Default;
			DialogResult=DialogResult.OK;
		}

		private void butResend_Click(object sender,EventArgs e) {
			FormClaimResend fcr=new FormClaimResend();
			if(fcr.ShowDialog()==DialogResult.OK) {
				if(fcr.IsClaimReplacement) {
					comboCorrectionType.SelectedIndex=1;//replacement
				}
				else {
					comboCorrectionType.SelectedIndex=0;//original
					textDateResent.Text=DateTime.Now.ToShortDateString();
				}
				SendClaim();
			}
		}

		private void butHistory_Click(object sender,EventArgs e) {
			List<Etrans> etransList=Etranss.GetHistoryOneClaim(ClaimCur.ClaimNum);
			if(etransList.Count==0) {
				MsgBox.Show(this,"No history found of sent e-claim.");
				return;
			}
			FormEtransEdit FormE=new FormEtransEdit();
			FormE.EtransCur=etransList[0];
			FormE.ShowDialog();
		}

		///<summary>Canada only.</summary>
		private void butReverse_Click(object sender,EventArgs e) {
			Cursor=Cursors.WaitCursor;
			InsPlan insPlan=InsPlans.GetPlan(ClaimCur.PlanNum,null);
			InsSub insSub=InsSubs.GetOne(ClaimCur.InsSubNum);
			try {
				long etransNumAck=CanadianOutput.SendClaimReversal(ClaimCur,insPlan,insSub);
				Etrans etransAck=Etranss.GetEtrans(etransNumAck);
				if(etransAck.AckCode!="R") {
					//If the claim was successfully reversed, clear the claim transaction reference number so the user can resend the claim if desired.
					//Will make the claim look like it was not ever sent, except in send claims window there will be extra history.
					ClaimCur.CanadaTransRefNum="";
					Claims.Update(ClaimCur);
				}
			}
			catch(Exception ex) {
				MessageBox.Show(Lan.g(this,"Failed to reverse claim")+": "+ex.Message);
			}
			Cursor=Cursors.Default;
		}

		private void comboProvBill_SelectionChangeCommitted(object sender,EventArgs e) {
			_provNumBillSelected=ProviderC.ListShort[comboProvBill.SelectedIndex].ProvNum;
		}

		private void butPickProvBill_Click(object sender,EventArgs e) {
			FormProviderPick formP=new FormProviderPick();
			if(comboProvBill.SelectedIndex > -1) {//Initial formP selection if selected prov is not hidden.
				formP.SelectedProvNum=_provNumBillSelected;
			}
			formP.ShowDialog();
			if(formP.DialogResult!=DialogResult.OK) {
				return;
			}
			comboProvBill.SelectedIndex=Providers.GetIndex(formP.SelectedProvNum);
			_provNumBillSelected=formP.SelectedProvNum;
		}

		private void comboProvTreat_SelectionChangeCommitted(object sender,EventArgs e) {
			_provNumTreatSelected=ProviderC.ListShort[comboProvTreat.SelectedIndex].ProvNum;
		}

		private void butPickProvTreat_Click(object sender,EventArgs e) {
			FormProviderPick formP=new FormProviderPick();
			if(comboProvTreat.SelectedIndex > -1) {//Initial formP selection if selected prov is not hidden.
				formP.SelectedProvNum=_provNumTreatSelected;
			}
			formP.ShowDialog();
			if(formP.DialogResult!=DialogResult.OK) {
				return;
			}
			comboProvTreat.SelectedIndex=Providers.GetIndex(formP.SelectedProvNum);
			_provNumTreatSelected=formP.SelectedProvNum;
		}

		private void butDelete_Click(object sender, System.EventArgs e) {
			if(IsNew){
				DialogResult=DialogResult.Cancel;//jump straight to Closing, where the claimprocs will be changed
				return;
			}
			if(!ClaimIsValid()){
				return;
			}
			UpdateClaim();
			bool paymentIsAttached=false;
			for(int i=0;i<ClaimProcsForClaim.Count;i++){
				if(ClaimProcsForClaim[i].ClaimPaymentNum>0){
					paymentIsAttached=true;
				}
			}
			if(paymentIsAttached){
				MessageBox.Show(Lan.g(this,"You cannot delete this claim while any insurance checks are attached.  You will have to detach all insurance checks first."));
				return;
			}
			if(ClaimCur.ClaimStatus=="R"){
				MessageBox.Show(Lan.g(this,"You cannot delete this claim while status is Received.  You will have to change the status first."));
				return;
			}
      if(ClaimCur.ClaimType=="PreAuth"){
				if(MessageBox.Show(Lan.g(this,"Delete PreAuthorization?"),"",MessageBoxButtons.OKCancel)!=DialogResult.OK){
					return;
				}
			}
			else{
				if(MessageBox.Show(Lan.g(this,"Delete Claim?"),"",MessageBoxButtons.OKCancel)!=DialogResult.OK){
					return;
				}
			}
			Procedure proc;
			if(ClaimCur.ClaimType=="PreAuth"//all preauth claimprocs are just duplicates
				|| ClaimCur.ClaimType=="Cap"){//all cap claimprocs are just duplicates
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					//ClaimProcs.Cur=ClaimProcs.ForClaim[i];
					ClaimProcs.Delete(ClaimProcsForClaim[i]);
				}
			}
			else{//all other claim types use original estimate claimproc.
				List<Benefit> benList=Benefits.Refresh(PatPlanList,SubList);
				InsPlan plan=InsPlans.GetPlan(ClaimCur.PlanNum,PlanList);
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					//ClaimProcs.Cur=ClaimProcs.ForClaim[i];
					if(ClaimProcsForClaim[i].Status==ClaimProcStatus.Supplemental//supplementals are duplicate
						|| ClaimProcsForClaim[i].ProcNum==0)//total payments get deleted
					{
						ClaimProcs.Delete(ClaimProcsForClaim[i]);
						continue;
					}
					//so only changed back to estimate if attached to a proc
					ClaimProcsForClaim[i].Status=ClaimProcStatus.Estimate;
					ClaimProcsForClaim[i].ClaimNum=0;
					//already handled the case where claimproc.ProcNum=0 for payments etc. above
					proc=Procedures.GetProcFromList(ProcList,ClaimProcsForClaim[i].ProcNum);
					//We're not going to bother to also get paidOtherInsBaseEst:
					double paidOtherInsTotal=ClaimProcs.GetPaidOtherInsTotal(ClaimProcsForClaim[i],PatPlanList);
					double writeOffOtherIns=ClaimProcs.GetWriteOffOtherIns(ClaimProcsForClaim[i],PatPlanList);
					if(ClaimCur.ClaimType=="P" && PatPlanList.Count>0){
						ClaimProcs.ComputeBaseEst(ClaimProcsForClaim[i],proc,plan,PatPlanList[0].PatPlanNum,benList,null,null,PatPlanList,0,0,PatCur.Age,0);
					}
					else if(ClaimCur.ClaimType=="S" && PatPlanList.Count>1){
						ClaimProcs.ComputeBaseEst(ClaimProcsForClaim[i],proc,plan,PatPlanList[1].PatPlanNum,benList,null,null,PatPlanList,paidOtherInsTotal,paidOtherInsTotal,PatCur.Age,writeOffOtherIns);
					}
					ClaimProcsForClaim[i].InsPayEst=0;
					ClaimProcs.Update(ClaimProcsForClaim[i]);
				}
			}
      Claims.Delete(ClaimCur);
			SecurityLogs.MakeLogEntry(Permissions.ClaimSentEdit,ClaimCur.PatNum,
				Lan.g(this,"Delete Claim")+", "+PatCur.GetNameLF()+""
				+Lan.g(this,"Date of service: ")+ClaimCur.DateService.ToShortDateString());
      DialogResult=DialogResult.OK;
		}

		private void butOK_Click(object sender, System.EventArgs e) {
			if(!ClaimIsValid()){
				return;
			}
			//if status is received, all claimprocs must also be received.
			if(comboClaimStatus.SelectedIndex==5){
				bool allReceived=true;
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					if(((ClaimProc)ClaimProcsForClaim[i]).Status==ClaimProcStatus.NotReceived){
						allReceived=false;
					}
				}
				if(!allReceived){
					if(!MsgBox.Show(this,true,"All items will be marked received.  Continue?")){
						return;
					}
					for(int i=0;i<ClaimProcsForClaim.Count;i++){
						if(ClaimProcsForClaim[i].Status==ClaimProcStatus.NotReceived){
							//ClaimProcs.Cur=(ClaimProc)ClaimProcs.ForClaim[i];
							ClaimProcsForClaim[i].Status=ClaimProcStatus.Received;
							//We set the DateCP to Today's date when the user presses the buttons By Total, By Proc or Supplemental.
							//When there is a no payment claim, the user might simply change the claim status to received and press OK instead of entering payments the normal way, since there is no check.
							//Logically, we are changing claimproc status to received, and the claimproc will now be treated as a payment in the reports.
							//If we did not update DateCP, then DateCP for a zero payment claim would still be the procedure treatment planned date as much as a year ago, so the claimproc writeoffs (if present) would be accidentally back dated.
							ClaimProcsForClaim[i].DateCP=DateTimeOD.Today;
							ClaimProcsForClaim[i].DateEntry=DateTime.Now;//date it was set rec'd
							ClaimProcs.Update(ClaimProcsForClaim[i]);
						}
					}
				}
			}
			else{//claim is any status except received
				bool anyReceived=false;
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					if(((ClaimProc)ClaimProcsForClaim[i]).Status==ClaimProcStatus.Received){
						anyReceived=true;
					}
				}
				if(anyReceived){
					//Too dangerous to automatically set items not received because I would have to check for attachments to checks, etc.
					//Also too annoying to block user.
					//So just warn user.
					if(!MsgBox.Show(this,true,"Some of the items are marked received.  This is not a good idea since it will cause them to show in the Account as a 'payment'.  Continue anyway?")){
						return;
					}
				}
			}
			//if status is received and there is no received date
			if(comboClaimStatus.SelectedIndex==5 && textDateRec.Text==""){
				textDateRec.Text=DateTime.Today.ToShortDateString();
			}
			UpdateClaim();
			if(comboClaimStatus.SelectedIndex==2){//waiting to send
				ClaimSendQueueItem[] listQueue=Claims.GetQueueList(ClaimCur.ClaimNum,ClaimCur.ClinicNum,0);
				if(listQueue[0].NoSendElect) {
					DialogResult=DialogResult.OK;
					return;
				}
				//string warnings;
				//string missingData=
				Eclaims.Eclaims.GetMissingData(listQueue[0]);//,out warnings);
				if(listQueue[0].MissingData!="") {
					if(MessageBox.Show(Lan.g(this,"Cannot send claim until missing data is fixed:")+"\r\n"+listQueue[0].MissingData+"\r\n\r\nContinue anyway?",
						"",MessageBoxButtons.OKCancel)==DialogResult.OK)
					{
						DialogResult=DialogResult.OK;
					}
					return;
				}
				//if(MsgBox.Show(this,true,"Send electronic claim immediately?")){
				//	List<ClaimSendQueueItem> queueItems=new List<ClaimSendQueueItem>();
				//	queueItems.Add(listQueue[0]);
				//	Eclaims.Eclaims.SendBatches(queueItems);//this also calls SetClaimSentOrPrinted which creates the etrans entry.
				//}
			}
			if(comboClaimStatus.SelectedIndex==5) {//Received
				ShowProviderTransferWindow();
			}
			DialogResult=DialogResult.OK;
		}
		
		/// <summary>Also handles Canadian warnings.</summary>
		private bool ClaimIsValid(){
			if(  textDateService.errorProvider1.GetError(textDateSent)!=""
				|| textDateSent.errorProvider1.GetError(textDateSent)!=""
				|| textDateResent.errorProvider1.GetError(textDateResent)!=""
				|| textDateRec.errorProvider1.GetError(textDateRec)!=""
				|| textPriorDate.errorProvider1.GetError(textPriorDate)!=""
				|| textDedApplied.errorProvider1.GetError(textDedApplied)!=""
				|| textInsPayAmt.errorProvider1.GetError(textInsPayAmt)!=""
				|| textOrthoDate.errorProvider1.GetError(textOrthoDate)!=""
				|| textRadiographs.errorProvider1.GetError(textRadiographs)!=""
				|| textAccidentDate.errorProvider1.GetError(textAccidentDate)!=""
				|| textAttachImages.errorProvider1.GetError(textAttachImages)!=""
				|| textAttachModels.errorProvider1.GetError(textAttachModels)!=""
				|| textDateInitialUpper.errorProvider1.GetError(textDateInitialUpper)!=""
				|| textDateInitialLower.errorProvider1.GetError(textDateInitialLower)!=""
				){
				MsgBox.Show(this,"Please fix data entry errors first.");
				return false;
			}
			if(textDateService.Text=="" && ClaimCur.ClaimType!="PreAuth"){
				MsgBox.Show(this,"Please enter a date of service");
				return false;
			}
			if((comboClaimStatus.SelectedIndex==5//received
				|| comboClaimStatus.SelectedIndex==4)//sent
				&& textDateSent.Text=="")
			{
				MsgBox.Show(this,"Please enter date sent.");
				return false;
			}
			if(ClaimCur.ClaimType=="PreAuth"){
				bool preauthChanged=false;
				for(int i=0;i<ClaimProcsForClaim.Count;i++){
					if(ClaimProcsForClaim[i].Status!=ClaimProcStatus.Preauth){
						ClaimProcsForClaim[i].Status=ClaimProcStatus.Preauth;
						ClaimProcs.Update(ClaimProcsForClaim[i]);
						preauthChanged=true;
					}
				}
				if(preauthChanged){
					//don't bother to refresh
					FillGrids();
					MsgBox.Show(this,"Status of procedures was changed back to preauth to match status of claim.");
					return false;
				}
			}
			if(PrefC.GetBool(PrefName.ClaimsValidateACN)) {
				InsPlan plan=InsPlans.GetPlan(ClaimCur.PlanNum,PlanList);
				if(plan!=null && plan.GroupName.Contains("ADDP")) {
					if(!Regex.IsMatch(textNote.Text,"ACN[0-9]{5,}")) {//ACN with at least 5 digits following
						MsgBox.Show(this,"For an ADDP claim, there must be an ACN number in the note.  Example format: ACN12345");
						return false;
					}
				}
			}
			if(textBillType.Text!="" && comboCorrectionType.SelectedIndex!=0) {
				MsgBox.Show(this,"Correction type must be original when type of bill is not blank.");
				return false;
			}
			if(!CanadianWarnings()) {
				return false;
			}
			return true;
		}

		///<summary>Only called from one location above.  In its own method for readability.</summary>
		private bool CanadianWarnings(){
			if(!CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//if not Canadian
				return true;//skip this entire method
			}
			if(textCanadianAccidentDate.errorProvider1.GetError(textCanadianAccidentDate)!="") {
				MsgBox.Show(this,"Please fix data entry errors first.");
				return false;
			}
			if(textCanadianAccidentDate.Text!="" && DateTime.Parse(textCanadianAccidentDate.Text).Date>DateTime.Today) {
				MsgBox.Show(this,"Accident date cannot be a date in the future.");
				return false;
			}
			string warning="";
			if(textReferralProvider.Text!="" && comboReferralReason.SelectedIndex==0){
				if(warning!=""){
					warning+="\r\n";
				}
				warning+="Referral reason is required if provider indicated.";
			}
			if(textReferralProvider.Text=="" && comboReferralReason.SelectedIndex!=0){
				if(warning!=""){
					warning+="\r\n";
				}
				warning+="Referring provider required if referring reason is indicated.";
			}
			//Max prosth----------------------------------------------------------------------------------
			if(comboMaxProsth.SelectedIndex==0){
				if(warning!=""){
					warning+="\r\n";
				}
				warning+="Max prosth not indicated.";
			}
			if(textDateInitialUpper.Text!="") {
				if(PIn.Date(textDateInitialUpper.Text)>DateTime.Today) {
					if(warning!="") {
						warning+="\r\n";
					}
					warning+="Initial max date must be in the past.";
				}
				if(PIn.Date(textDateInitialUpper.Text).Year<1900) {
					if(warning!="") {
						warning+="\r\n";
					}
					warning+="Initial max date is not reasonable.";
				}
			}
			if(comboMaxProsth.SelectedIndex==2){//no
				if(textDateInitialUpper.Text==""){
					if(warning!=""){
						warning+="\r\n";
					}
					warning+="Max initial date is required if 'no' is selected.";
				}
				if(comboMaxProsthMaterial.SelectedIndex==0){
					if(warning!=""){
						warning+="\r\n";
					}
					warning+="Max prosth material must be indicated";
				}
			}
			if(comboMaxProsthMaterial.SelectedIndex!=0 && comboMaxProsth.SelectedIndex==3){//not an upper prosth
				if(warning!="") {
					warning+="\r\n";
				}
				warning+="Max prosth should not have a material selected.";
			}
			//Mand prosth----------------------------------------------------------------------------------------------------------
			if(comboMandProsth.SelectedIndex==0){
				if(warning!=""){
					warning+="\r\n";
				}
				warning+="Mand prosth not indicated.";
			}
			if(textDateInitialLower.Text!=""){
				if(PIn.Date(textDateInitialLower.Text)>DateTime.Today){
					if(warning!=""){
						warning+="\r\n";
					}
					warning+="Initial mand date must be in the past.";
				}
				if(PIn.Date(textDateInitialLower.Text).Year<1900){
					if(warning!=""){
						warning+="\r\n";
					}
					warning+="Initial mand date is not reasonable.";
				}
			}
			if(comboMandProsth.SelectedIndex==2) {//no
				if(textDateInitialLower.Text==""){
					if(warning!=""){
						warning+="\r\n";
					}
					warning+="Mand initial date is required if 'no' is checked.";
				}
				if(comboMandProsthMaterial.SelectedIndex==0){
					if(warning!=""){
						warning+="\r\n";
					}
					warning+="Mand prosth material must be indicated";// (unless for a crown).";
				}
			}
			if(comboMandProsthMaterial.SelectedIndex!=0 && comboMandProsth.SelectedIndex==3) {//not a lower prosth
				if(warning!="") {
					warning+="\r\n";
				}
				warning+="Mand prosth should not have a material selected.";
			}
			if(warning!=""){
				DialogResult result=MessageBox.Show("Warnings:\r\n"+warning+"\r\nDo you wish to continue anyway?","",
					MessageBoxButtons.OKCancel);
				if(result!=DialogResult.OK){
					return false;
				}
			}
			//Ortho Treatment------------------------------------------------------------------------------------------------------
			if(groupCanadaOrthoPredeterm.Enabled && textDateCanadaEstTreatStartDate.Text!="" && 
				textCanadaInitialPayment.Text!="" && textCanadaExpectedPayCycle.Text!="" &&
				textCanadaTreatDuration.Text!="" && textCanadaNumPaymentsAnticipated.Text!="" && 
				textCanadaAnticipatedPayAmount.Text!="") {
				if(textDateCanadaEstTreatStartDate.errorProvider1.GetError(textDateCanadaEstTreatStartDate)!="") {
					MsgBox.Show(this,"Please fix data entry errors first.");
					return false;
				}
				try {
					Double.Parse(textCanadaInitialPayment.Text);
				}
				catch {
					MsgBox.Show(this,"Invalid initial payment amount.");
					return false;
				}
				byte payCycle=0;
				try {
					payCycle=byte.Parse(textCanadaExpectedPayCycle.Text);
				}
				catch {
					MsgBox.Show(this,"Invalid expected payment cycle.");
					return false;
				}
				if(payCycle<1 || payCycle>4) {
					MsgBox.Show(this,"Expected payment cycle must be a value between 1 and 4.");
					return false;
				}
				try {
					byte.Parse(textCanadaTreatDuration.Text);
				}
				catch {
					MsgBox.Show(this,"Invalid treatment duration.");
					return false;
				}
				try {
					byte.Parse(textCanadaNumPaymentsAnticipated.Text);
				}
				catch {
					MsgBox.Show(this,"Invalid number of payments anticipated.");
					return false;
				}
				try {
					Double.Parse(textCanadaAnticipatedPayAmount.Text);
				}
				catch {
					MsgBox.Show(this,"Invalid anticipated pay amount.");
					return false;
				}
			}
			return true;
		}

		///<summary>Updates this claim to the database.</summary>
		private void UpdateClaim(){
			if(notAuthorized){
				return;
			}
			//patnum
			ClaimCur.DateService=PIn.Date(textDateService.Text);
			if(textDateSent.Text==""){
				ClaimCur.DateSent=DateTime.MinValue;
			}
			else{
				ClaimCur.DateSent=PIn.Date(textDateSent.Text);
			}
			bool wasSentOrReceived=false;
			switch(comboClaimStatus.SelectedIndex){
				case 0:
					ClaimCur.ClaimStatus="U";
					break;
				case 1:
					ClaimCur.ClaimStatus="H";
					break;
				case 2:
					ClaimCur.ClaimStatus="W";
					break;
				case 3:
					ClaimCur.ClaimStatus="P";
					break;
				case 4:
					ClaimCur.ClaimStatus="S";
					wasSentOrReceived=true;
					break;
				case 5:
					ClaimCur.ClaimStatus="R";
					wasSentOrReceived=true;
					break;
			}
			//claimType can't be changed here.
			ClaimCur.MedType=(EnumClaimMedType)comboMedType.SelectedIndex;
			if(comboClaimForm.SelectedIndex==0){
				ClaimCur.ClaimForm=0;
			}
			else{
				ClaimCur.ClaimForm=ClaimForms.ListShort[comboClaimForm.SelectedIndex-1].ClaimFormNum;
			}
			if(textDateRec.Text==""){
				ClaimCur.DateReceived=DateTime.MinValue;
			}
			else{
				ClaimCur.DateReceived=PIn.Date(textDateRec.Text);
			}
			//planNum
			ClaimCur.SpecialProgramCode=(EnumClaimSpecialProgram)comboSpecialProgram.SelectedIndex;
			ClaimCur.CustomTracking=0;
			if(comboCustomTracking.Visible && comboCustomTracking.SelectedIndex!=0) {
				ClaimCur.CustomTracking=DefC.Long[(int)DefCat.ClaimCustomTracking][comboCustomTracking.SelectedIndex-1].DefNum;
			}
			//patRelats will always be selected
			ClaimCur.PatRelat=(Relat)comboPatRelat.SelectedIndex;
			ClaimCur.PatRelat2=(Relat)comboPatRelat2.SelectedIndex;
			ClaimCur.ProvTreat=_provNumTreatSelected;
			ClaimCur.PriorAuthorizationNumber=textPriorAuth.Text;
			ClaimCur.PreAuthString=textPredeterm.Text;
			//isprosthesis handled earlier
			ClaimCur.PriorDate=PIn.Date(textPriorDate.Text);
			ClaimCur.ReasonUnderPaid=textReasonUnder.Text;
			ClaimCur.ClaimNote=textNote.Text;
			//ispreauth
			ClaimCur.ProvBill=_provNumBillSelected;
			ClaimCur.IsOrtho=checkIsOrtho.Checked;
			ClaimCur.OrthoRemainM=PIn.Byte(textOrthoRemainM.Text);
			ClaimCur.OrthoDate=PIn.Date(textOrthoDate.Text);
			ClaimCur.RefNumString=textRefNum.Text;
			ClaimCur.PlaceService=(PlaceOfService)comboPlaceService.SelectedIndex;
			ClaimCur.EmployRelated=(YN)comboEmployRelated.SelectedIndex;
			switch(comboAccident.SelectedIndex){
				case 0:
					ClaimCur.AccidentRelated="";
					break;
				case 1:
					ClaimCur.AccidentRelated="A";
					break;
				case 2:
					ClaimCur.AccidentRelated="E";
					break;
				case 3:
					ClaimCur.AccidentRelated="O";
					break;
			}
			//AccidentDate is further down
			ClaimCur.AccidentST=textAccidentST.Text;
			if(comboClinic.SelectedIndex==0){//none
				ClaimCur.ClinicNum=0;
			}
			else{
				ClaimCur.ClinicNum=Clinics.List[comboClinic.SelectedIndex-1].ClinicNum;
			}
			ClaimCur.DateResent=PIn.Date(textDateResent.Text);
			ClaimCur.CorrectionType=(ClaimCorrectionType)Enum.GetValues(typeof(ClaimCorrectionType)).GetValue(comboCorrectionType.SelectedIndex);
			ClaimCur.ClaimIdentifier=textClaimIdentifier.Text;
			ClaimCur.OrigRefNum=textOrigRefNum.Text;
			//attachments
			ClaimCur.Radiographs=PIn.Byte(textRadiographs.Text);
			ClaimCur.AttachedImages=PIn.Int(textAttachImages.Text);
			ClaimCur.AttachedModels=PIn.Int(textAttachModels.Text);
			List<string> flags=new List<string>();
			if(checkAttachEoB.Checked){
				flags.Add("EoB");
			}
			if(checkAttachNarrative.Checked){
				flags.Add("Note");
			}
			if(checkAttachPerio.Checked){
				flags.Add("Perio");
			}
			if(checkAttachMisc.Checked){
				flags.Add("Misc");
			}
			if(radioAttachMail.Checked){
				flags.Add("Mail");
			}
			if(radioAttachElect.Checked){
				flags.Add("Elect");
			}
			ClaimCur.AttachedFlags="";
			for(int i=0;i<flags.Count;i++){
				if(i>0){
					ClaimCur.AttachedFlags+=",";
				}
				ClaimCur.AttachedFlags+=flags[i];
			}
			ClaimCur.AttachmentID=textAttachID.Text;
			//Canadian---------------------------------------------------------------------------------
			if(CultureInfo.CurrentCulture.Name.EndsWith("CA")) {//Canadian. en-CA or fr-CA
				ClaimCur.CanadianMaterialsForwarded="";
				if(checkEmail.Checked) {
					ClaimCur.CanadianMaterialsForwarded+="E";
				}
				if(checkCorrespondence.Checked) {
					ClaimCur.CanadianMaterialsForwarded+="C";
				}
				if(checkModels.Checked) {
					ClaimCur.CanadianMaterialsForwarded+="M";
				}
				if(checkXrays.Checked) {
					ClaimCur.CanadianMaterialsForwarded+="X";
				}
				if(checkImages.Checked) {
					ClaimCur.CanadianMaterialsForwarded+="I";
				}
				ClaimCur.CanadianReferralProviderNum=textReferralProvider.Text;
				ClaimCur.CanadianReferralReason=(byte)comboReferralReason.SelectedIndex;
				ClaimCur.AccidentDate=PIn.Date(textCanadianAccidentDate.Text);
				ClaimCur.IsOrtho=checkCanadianIsOrtho.Checked;
				//max prosth-----------------------------------------------------------------------------------------------------
				switch(comboMaxProsth.SelectedIndex) {
					case 0:
						ClaimCur.CanadianIsInitialUpper="";
						break;
					case 1:
						ClaimCur.CanadianIsInitialUpper="Y";
						break;
					case 2:
						ClaimCur.CanadianIsInitialUpper="N";
						break;
					case 3:
						ClaimCur.CanadianIsInitialUpper="X";
						break;
				}
				ClaimCur.CanadianDateInitialUpper=PIn.Date(textDateInitialUpper.Text);
				ClaimCur.CanadianMaxProsthMaterial=(byte)comboMaxProsthMaterial.SelectedIndex;
				//mand prosth-----------------------------------------------------------------------------------------------------
				switch(comboMandProsth.SelectedIndex) {
					case 0:
						ClaimCur.CanadianIsInitialLower="";
						break;
					case 1:
						ClaimCur.CanadianIsInitialLower="Y";
						break;
					case 2:
						ClaimCur.CanadianIsInitialLower="N";
						break;
					case 3:
						ClaimCur.CanadianIsInitialLower="X";
						break;
				}
				ClaimCur.CanadianDateInitialLower=PIn.Date(textDateInitialLower.Text);
				ClaimCur.CanadianMandProsthMaterial=(byte)comboMandProsthMaterial.SelectedIndex;
				//ortho treatment
				if(groupCanadaOrthoPredeterm.Enabled && textDateCanadaEstTreatStartDate.Text!="" && 
					textCanadaInitialPayment.Text!="" && textCanadaExpectedPayCycle.Text!="" &&
					textCanadaTreatDuration.Text!="" && textCanadaNumPaymentsAnticipated.Text!="" && 
					textCanadaAnticipatedPayAmount.Text!="") {
					ClaimCur.CanadaEstTreatStartDate=DateTime.Parse(textDateCanadaEstTreatStartDate.Text);
					ClaimCur.CanadaInitialPayment=Double.Parse(textCanadaInitialPayment.Text);
					ClaimCur.CanadaPaymentMode=byte.Parse(textCanadaExpectedPayCycle.Text);
					ClaimCur.CanadaTreatDuration=byte.Parse(textCanadaTreatDuration.Text);
					ClaimCur.CanadaNumAnticipatedPayments=byte.Parse(textCanadaNumPaymentsAnticipated.Text);
					ClaimCur.CanadaAnticipatedPayAmount=Double.Parse(textCanadaAnticipatedPayAmount.Text);
				}
				else {
					ClaimCur.CanadaEstTreatStartDate=DateTime.MinValue;
					ClaimCur.CanadaInitialPayment=0;
					ClaimCur.CanadaPaymentMode=0;
					ClaimCur.CanadaTreatDuration=0;
					ClaimCur.CanadaNumAnticipatedPayments=0;
					ClaimCur.CanadaAnticipatedPayAmount=0;
				}
			}//End Canadian-----------------------------------------------------------------------------
			else {
				ClaimCur.AccidentDate=PIn.Date(textAccidentDate.Text);
				ClaimCur.IsOrtho=checkIsOrtho.Checked;
			}
			ClaimCur.UniformBillType=textBillType.Text;
			ClaimCur.AdmissionTypeCode=textAdmissionType.Text;
			ClaimCur.AdmissionSourceCode=textAdmissionSource.Text;
			ClaimCur.PatientStatusCode=textPatientStatus.Text;
			ClaimCur.ProvOrderOverride=_provNumOrderingSelected;
			Claims.Update(ClaimCur);
			if(ListClaimValCodes!=null){
				for(int i=0;i<ListClaimValCodes.Count;i++){ //update existing Value Code pairs
					ClaimValCodeLog vc = (ClaimValCodeLog)ListClaimValCodes[i];
					TextBox code = (TextBox)Controls.Find("textVC" + i + "Code", true)[0];
					vc.ValCode=code.Text.ToString();
					TextBox amount = (TextBox)Controls.Find("textVC" + i + "Amount", true)[0];
					string amt = amount.Text;
					if(amt=="") {
						amt = "0";
					}
					vc.ValAmount=Double.Parse(amt);
				}
				for(int i=(ListClaimValCodes.Count);i<12;i++){ //add new Value Code pairs
					ClaimValCodeLog vc = new ClaimValCodeLog();
					TextBox code = (TextBox)Controls.Find("textVC" + i + "Code", true)[0];
					vc.ValCode=code.Text.ToString();
					TextBox amount = (TextBox)Controls.Find("textVC" + i + "Amount", true)[0];
					string amt = amount.Text;
					if(amt=="") {
						amt = "0";
					}
					vc.ValAmount=Double.Parse(amt);
					vc.ClaimNum=ClaimCur.ClaimNum;
					vc.ClaimValCodeLogNum=0;
					if(vc.ValCode!="" || vc.ValAmount!=0){
						ListClaimValCodes.Add(vc);
					}
				}
				ClaimValCodeLogs.UpdateList(ListClaimValCodes);
			}
			if(ClaimCondCodeLogCur!=null || textCode0.Text!="" || textCode1.Text!="" || textCode2.Text!="" || textCode3.Text!="" || 
				textCode4.Text!="" || textCode5.Text!="" || textCode6.Text!="" || textCode7.Text!="" || textCode8.Text!="" || 
				textCode9.Text!="" || textCode10.Text!="") {
				if(ClaimCondCodeLogCur==null) {
					ClaimCondCodeLogCur=new ClaimCondCodeLog();
					ClaimCondCodeLogCur.ClaimNum=ClaimCur.ClaimNum;
					ClaimCondCodeLogCur.IsNew=true;
				}
				ClaimCondCodeLogCur.Code0=textCode0.Text;
				ClaimCondCodeLogCur.Code1=textCode1.Text;
				ClaimCondCodeLogCur.Code2=textCode2.Text;
				ClaimCondCodeLogCur.Code3=textCode3.Text;
				ClaimCondCodeLogCur.Code4=textCode4.Text;
				ClaimCondCodeLogCur.Code5=textCode5.Text;
				ClaimCondCodeLogCur.Code6=textCode6.Text;
				ClaimCondCodeLogCur.Code7=textCode7.Text;
				ClaimCondCodeLogCur.Code8=textCode8.Text;
				ClaimCondCodeLogCur.Code9=textCode9.Text;
				ClaimCondCodeLogCur.Code10=textCode10.Text;
				if(ClaimCondCodeLogCur.IsNew) {
					ClaimCondCodeLogs.Insert(ClaimCondCodeLogCur);
				}
				else {
					ClaimCondCodeLogs.Update(ClaimCondCodeLogCur);
				}
			}
			for(int i=0;i<ClaimProcsForClaim.Count;i++) {
				Procedure proc=Procedures.GetProcFromList(ProcList,ClaimProcsForClaim[i].ProcNum);
				if(proc.ProcNum==0) {
					continue;//ignores payments, etc
				}
				if(proc.PlaceService!=ClaimCur.PlaceService) {
					Procedure oldProc=proc.Copy();
					proc.PlaceService=ClaimCur.PlaceService;
					Procedures.Update(proc,oldProc);
				}
			}
			if(wasSentOrReceived){
				SecurityLogs.MakeLogEntry(Permissions.ClaimSentEdit,ClaimCur.PatNum,
					PatCur.GetNameLF()+", "
					+Lan.g(this,"Date of service: ")+ClaimCur.DateService.ToShortDateString());
			}
		}

		//cancel does not cancel in some circumstances because cur gets updated in some areas.
		private void butCancel_Click(object sender, System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}

		private void FormClaimEdit_Closing(object sender,System.ComponentModel.CancelEventArgs e) {
			if(DialogResult==DialogResult.OK) {
				return;
			}
			if(!IsNew) {
				return;
			}
			if(ClaimCur.InsPayAmt>0) {
				MsgBox.Show(this,"Not allowed to cancel because an insurance payment was entered.  Either click OK, or zero out the insurance payments.");
				e.Cancel=true;
				return;
			}
			//The following claimproc statuses are not probable at this point.  One possible way to have these claimproc statuses is if the user manually edits the claimproc and forces a status change.
			//Adjustment - Never attached to a claim (not even available to manual switch to).
			//Supplemental - Supplemental button is grayed out for new claims.
			//Total payment - By Total button is grayed out for new claims.
			//Estimate - When the claimprocs are attached to a claim, their status is changed from Estimate to NotReceived or to PreAuth.
			//CapComplete - Never attached to a claim, because the status is changed to CapClaim when attached to a claim.
			//CapEstimate - Never attached to a claim, because the status is changed to CapComplete, then to CapClaim when attached to the claim.
			for(int i=0;i<ClaimProcsForClaim.Count;i++) {
				if(ClaimProcsForClaim[i].Status==ClaimProcStatus.CapClaim 
					|| ClaimProcsForClaim[i].Status==ClaimProcStatus.Preauth) 
				{
					ClaimProcs.Delete(ClaimProcsForClaim[i]);
				}
				else {//All other claimprocs need to be detached from the claim.
					if(ClaimProcsForClaim[i].Status==ClaimProcStatus.NotReceived
						|| ClaimProcsForClaim[i].Status==ClaimProcStatus.Received)//Can only happen if a user manually changed the claimproc status.
					{
						ClaimProcsForClaim[i].Status=ClaimProcStatus.Estimate;//Force it back to estimate so that it can be attached to a new claim.
						ClaimProcsForClaim[i].InsPayEst=0;
					}
					ClaimProcsForClaim[i].ClaimNum=0;
					ClaimProcs.Update(ClaimProcsForClaim[i]);
				}
			}
			Claims.Delete(ClaimCur);//does not do any validation.  Also deletes the claimcanadian.
		}

	

	

		
	

		

	

		

		

		

		

		

		

		

		

		

		

		

		

		

		

		

		

		

		

		

		

		

	}
}
