using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenDentBusiness {
	///<summary></summary>
	public class Jobs {

		///<summary>Gets one Job from the db.</summary>
		public static Job GetOne(long jobNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<Job>(MethodBase.GetCurrentMethod(),jobNum);
			}
			return Crud.JobCrud.SelectOne(jobNum);
		}

		///<summary>Gets one Job from the db. Fills all respective object lists from the DB too.</summary>
		public static Job GetOneFilled(long jobNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<Job>(MethodBase.GetCurrentMethod(),jobNum);
			}
			Job job=Crud.JobCrud.SelectOne(jobNum);
			FillInMemoryLists(new List<Job>() { job });
			return job;
		}

		///<summary></summary>
		public static long Insert(Job job) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				job.JobNum=Meth.GetLong(MethodBase.GetCurrentMethod(),job);
				return job.JobNum;
			}
			return Crud.JobCrud.Insert(job);
		}

		///<summary></summary>
		public static void Update(Job job) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),job);
				return;
			}
			Crud.JobCrud.Update(job);
		}

		///<summary>You must surround with a try-catch when calling this method.  Deletes one job from the database.  
		///Also deletes all JobLinks, Job Events, and Job Notes associated with the job.  Jobs that have reviews or quotes on them may not be deleted and will throw an exception.</summary>
		public static void Delete(long jobNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				Meth.GetVoid(MethodBase.GetCurrentMethod(),jobNum);
				return;
			}
			if(JobReviews.GetForJob(jobNum).Count>0 || JobQuotes.GetForJob(jobNum).Count>0) {
				throw new Exception(Lans.g("Jobs","Not allowed to delete a job that has attached reviews or quotes.  Set the status to deleted instead."));//The exception is caught in FormJobEdit.
			}
			//JobReviews.DeleteForJob(jobNum);//do not delete, blocked above
			//JobQuotes.DeleteForJob(jobNum);//do not delete, blocked above
			JobLinks.DeleteForJob(jobNum);
			JobEvents.DeleteForJob(jobNum);
			JobNotes.DeleteForJob(jobNum);
			Crud.JobCrud.Delete(jobNum); //Finally, delete the job itself.
		}

		public static List<Job> GetAll() {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Job>>(MethodBase.GetCurrentMethod());
			}
			string command="SELECT * FROM job";
			return Crud.JobCrud.SelectMany(command);
		}

		public static List<Job> GetMany(List<long> jobNums) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetObject<List<Job>>(MethodBase.GetCurrentMethod(),jobNums);
			}
			if(jobNums==null||jobNums.Count==0) {
				return new List<Job>();
			}
			string command = "SELECT * FROM job WHERE JobNum IN ("+string.Join(",",jobNums)+")";
			return Crud.JobCrud.SelectMany(command);
		}

		public static bool ValidateJobNum(long jobNum) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				return Meth.GetBool(MethodBase.GetCurrentMethod(),jobNum);
			}
			string command="SELECT COUNT(*) FROM job WHERE JobNum="+POut.Long(jobNum);
			return Db.GetScalar(command)!="0";
		}

		///<summary>Efficiently queries DB to fill all in memory lists for all jobs passed in.</summary>
		public static void FillInMemoryLists(List<Job> listJobsAll) {
			//No need for remoting call here.
			List<long> jobNums=listJobsAll.Select(x=>x.JobNum).ToList();
			Dictionary<long,List<JobLink>> listJobLinksAll=JobLinks.GetJobLinksForJobs(jobNums).GroupBy(x=>x.JobNum).ToDictionary(x=>x.Key,x=>x.ToList());
			Dictionary<long,List<JobNote>> listJobNotesAll=JobNotes.GetJobNotesForJobs(jobNums).GroupBy(x => x.JobNum).ToDictionary(x => x.Key,x => x.ToList());
			Dictionary<long,List<JobReview>> listJobReviewsAll=JobReviews.GetJobReviewsForJobs(jobNums).GroupBy(x => x.JobNum).ToDictionary(x => x.Key,x => x.ToList());
			Dictionary<long,List<JobQuote>> listJobQuotesAll=JobQuotes.GetJobQuotesForJobs(jobNums).GroupBy(x => x.JobNum).ToDictionary(x => x.Key,x => x.ToList());
			Dictionary<long,List<JobEvent>> listJobEventsAll=JobEvents.GetJobEventsForJobs(jobNums).GroupBy(x => x.JobNum).ToDictionary(x => x.Key,x => x.ToList());
			for(int i=0;i<listJobsAll.Count;i++) {
				Job job=listJobsAll[i];
				if(!listJobLinksAll.TryGetValue(job.JobNum,out job.ListJobLinks)) {
					job.ListJobLinks=new List<JobLink>();//empty list if not found
				}
				if(!listJobNotesAll.TryGetValue(job.JobNum,out job.ListJobNotes)) {
					job.ListJobNotes=new List<JobNote>();//empty list if not found
				}
				if(!listJobReviewsAll.TryGetValue(job.JobNum,out job.ListJobReviews)) {
					job.ListJobReviews=new List<JobReview>();//empty list if not found
				}
				if(!listJobQuotesAll.TryGetValue(job.JobNum,out job.ListJobQuotes)) {
					job.ListJobQuotes=new List<JobQuote>();//empty list if not found
				}
				if(!listJobEventsAll.TryGetValue(job.JobNum,out job.ListJobEvents)) {
					job.ListJobEvents=new List<JobEvent>();//empty list if not found
				}
			}
		}

		///<summary>Must be called after job is filled using Jobs.FillInMemoryLists(). Returns list of user nums associated with this job.
		/// Currently that is Expert, Owner, and Watchers.</summary>
		public static List<long> GetUserNums(Job job,bool HasApprover=false) {
			List<long> retVal = new List<long> {
				job.UserNumConcept,
				job.UserNumExpert,
				job.UserNumEngineer,
				job.UserNumDocumenter,
				job.UserNumCustContact,
				job.UserNumCheckout,
				job.UserNumInfo
			};
			if(HasApprover) {
				retVal.AddRange(new[]{
					job.UserNumApproverConcept,
					job.UserNumApproverJob,
					job.UserNumApproverChange,
				});
			}
			job.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Watcher).ForEach(x => retVal.Add(x.FKey));
			job.ListJobReviews.ForEach(x => retVal.Add(x.ReviewerNum));
			return retVal;
		}

		///<summary>Attempts to find infinite loop when changing job parent. Can be optimized to reduce trips to DB since we have all jobs in memory in the job manager.</summary>
		public static bool CheckForLoop(long jobNum,long jobNumParent) {
			List<long> lineage=new List<long>(){jobNum};
			long parentNumNext=jobNumParent;
			while(parentNumNext!=0){
				if(lineage.Contains(parentNumNext)) {
					return true;//loop found
				}
				Job jobNext=Jobs.GetOne(parentNumNext);
				lineage.Add(parentNumNext);
				parentNumNext=jobNext.ParentNum;
			} 
			return false;//no loop detected
		}

		public static List<JobEmail> GetCustomerEmails(Job job) {
			Dictionary<long,JobEmail> retVal = new Dictionary<long,JobEmail>();
			foreach(JobQuote jobQuote in job.ListJobQuotes) {
				long patNum = jobQuote.PatNum;
				if(!retVal.ContainsKey(patNum)) {
					Patient pat = Patients.GetPat(patNum);
					if(pat==null) {
						continue;
					}
					string phones = "Hm:"+pat.HmPhone+"\r\nMo:"+pat.WirelessPhone+"\r\nWk:"+pat.WkPhone;
					retVal[patNum]=new JobEmail() { Pat=pat,EmailAddress=pat.Email,PhoneNums=phones,IsSend=false };
				}
				retVal[patNum].IsQuote=true;
			}
			foreach(JobLink jobLink in job.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Task)) {
				Task task = Tasks.GetOne(jobLink.FKey);
				if(task==null || task.KeyNum==0 || task.ObjectType!=TaskObjectType.Patient) {
					continue;
				}
				long patNum = task.KeyNum;
				if(!retVal.ContainsKey(patNum)) {
					Patient pat = Patients.GetPat(patNum);
					if(pat==null) {
						continue;
					}
					string phones = "Hm:"+pat.HmPhone+"\r\nMo:"+pat.WirelessPhone+"\r\nWk:"+pat.WkPhone;
					retVal[patNum]=new JobEmail() { Pat=pat,EmailAddress=pat.Email,PhoneNums=phones,IsSend=true };
				}
				retVal[patNum].IsTask=true;
			}
			foreach(JobLink jobLink in job.ListJobLinks.FindAll(x => x.LinkType==JobLinkType.Request)) {
				DataTable tableFR = GetFeatureRequestContact(jobLink.FKey);
				foreach(DataRow row in tableFR.Rows) {
					long patNum = PIn.Long(row["ODPatNum"].ToString());
					Patient pat = Patients.GetPat(patNum);
					if(!retVal.ContainsKey(patNum)) {
						string phones = "Hm:"+row["HmPhone"].ToString()+"\r\nMo:"+row["WirelessPhone"].ToString()+"\r\nWk:"+row["WkPhone"].ToString();
						retVal[patNum]=new JobEmail() { Pat=pat,EmailAddress=row["Email"].ToString(),PhoneNums=phones,IsSend=true };
					}
					retVal[patNum].IsFeatureReq=true;
					retVal[patNum].Votes+=PIn.Int(row["Votes"].ToString());
					retVal[patNum].PledgeAmount+=PIn.Double(row["AmountPledged_"].ToString());
				}
			}
			return retVal.Select(x=>x.Value).ToList();
		}

		///<summary>This is the query that wasused prior to the job manager to lookup customer votes, pledges, and contact information for feature requests.</summary>
		private static DataTable GetFeatureRequestContact(long featureRequestNum) {
			string command = "SELECT A.RequestID, A.LName, A.FName, A.ODPatNum, A.BillingType, A.Email, A.HmPhone, "
				+"A.WkPhone, A.WirelessPhone, A.Votes, A.AmountPledged AS AmountPledged_, A.DateVote "
				+"FROM "
				+"(SELECT 1 AS ItemOrder,	request.RequestId, p.LName,	p.FName,	p.PatNum AS 'ODPatNum',	'' AS BillingType, "
				+"  p.Email,	p.HmPhone,	p.WkPhone,	p.WirelessPhone,	'' AS Votes,	'' AS AmountPledged,	request.DateTimeEntry AS 'DateVote' "
				+"FROM bugs.request	INNER JOIN customers.Patient p ON p.PatNum = request.PatNum "
				+"WHERE bugs.request.RequestId ="+POut.Long(featureRequestNum)+" "
				+" UNION ALL "
				+"SELECT 2 AS ItemOrder, vote.RequestID AS RequestID,	p.LName,	p.FName,	p.PatNum AS 'ODPatNum',	def.ItemName AS BillingType, "
				+"  p.Email,	p.HmPhone,	p.WkPhone,	p.WirelessPhone,	vote.Points AS Votes,	vote.AmountPledged,	vote.DateTStamp AS 'DateVote' "
				+"FROM bugs.vote INNER JOIN customers.Patient p ON p.PatNum = vote.PatNum INNER JOIN customers.definition def ON def.DefNum = p.BillingType "
				+" WHERE vote.RequestId ="+POut.Long(featureRequestNum)+" "
				+") A "
				+"ORDER BY CAST(A.RequestID AS UNSIGNED INTEGER), A.ItemOrder";
			return Db.GetTable(command);
		}


		public class JobEmail {
			public Patient Pat;
			public string EmailAddress;
			public double PledgeAmount;
			public string PhoneNums;
			public int Votes;
			public bool IsQuote;
			public bool IsTask;
			public bool IsFeatureReq;
			public bool IsSend;
			///<summary>UI field to display send, errors.</summary>
			public string StatusMsg;
		}


	}
}

/*Convert script to convert the customer DB 
#15.4... ot 16.1
ALTER TABLE job ADD UserNumConcept BIGINT NOT NULL;
ALTER TABLE job ADD UserNumExpert BIGINT NOT NULL;
ALTER TABLE job ADD UserNumEngineer BIGINT NOT NULL;
ALTER TABLE job ADD UserNumApproverConcept BIGINT NOT NULL;
ALTER TABLE job ADD UserNumApproverJob BIGINT NOT NULL;
ALTER TABLE job ADD UserNumApproverChange BIGINT NOT NULL;
ALTER TABLE job ADD UserNumDocumenter BIGINT NOT NULL;
ALTER TABLE job ADD UserNumCustContact BIGINT NOT NULL;
ALTER TABLE job ADD UserNumCheckout BIGINT NOT NULL;
ALTER TABLE job ADD UserNumInfo BIGINT NOT NULL;
ALTER TABLE job ADD DateTimeCustContact DATETIME NOT NULL DEFAULT '0001-01-01';

ALTER TABLE job ADD Documentation TEXT NOT NULL;
# ALTER TABLE job DROP COLUMN Documentaion;

ALTER TABLE job ADD IsApprovalNeeded TINYINT NOT NULL;
ALTER TABLE job ADD AckDateTime DATETIME NOT NULL DEFAULT '0001-01-01';


UPDATE job SET IsApprovalNeeded = 1 WHERE jobstatus IN('NeedsConceptApproval','NeedsJobApproval');

UPDATE job SET UserNumExpert = ExpertNum;
UPDATE job SET jobstatus = 'Concept', UserNumConcept = OwnerNum WHERE jobstatus = 'Concept';
UPDATE job SET jobstatus = 'Concept'                                WHERE jobstatus = 'NeedsConceptApproval';

UPDATE job SET jobstatus = 'Definiton', UserNumApproverConcept = 9 WHERE jobstatus = 'ConceptApproved';
UPDATE job SET jobstatus = 'Definiton', UserNumApproverConcept = 9 WHERE jobstatus = 'CurrentlyWriting';
UPDATE job SET jobstatus = 'Definiton', UserNumApproverConcept = 9 WHERE jobstatus = 'NeedsJobApproval';
UPDATE job SET jobstatus = 'Definiton', UserNumApproverConcept = 9 WHERE jobstatus = 'NeedsJobClarification';

UPDATE job SET jobstatus = 'Development', UserNumApproverConcept = 9, UserNumApproverJob = 9, UserNumEngineer = OwnerNum WHERE jobstatus = 'JobApproved';
UPDATE job SET jobstatus = 'Development', UserNumApproverConcept = 9, UserNumApproverJob = 9, UserNumEngineer = OwnerNum WHERE jobstatus = 'Assigned';
UPDATE job SET jobstatus = 'Development', UserNumApproverConcept = 9, UserNumApproverJob = 9, UserNumEngineer = OwnerNum WHERE jobstatus = 'CurrentlyWorkingOn';
UPDATE job SET jobstatus = 'Development', UserNumApproverConcept = 9, UserNumApproverJob = 9, UserNumEngineer = OwnerNum WHERE jobstatus = 'ReadyForReview';
UPDATE job SET jobstatus = 'Development', UserNumApproverConcept = 9, UserNumApproverJob = 9, UserNumEngineer = OwnerNum WHERE jobstatus = 'ReadyToAssign';
UPDATE job SET jobstatus = 'Development', UserNumApproverConcept = 9, UserNumApproverJob = 9, UserNumEngineer = OwnerNum, Priority = 'OnHold' WHERE jobstatus = 'OnHoldExpert';
UPDATE job SET jobstatus = 'Development', UserNumApproverConcept = 9, UserNumApproverJob = 9, UserNumEngineer = OwnerNum, Priority = 'OnHold' WHERE jobstatus = 'OnHoldEngineer';

UPDATE job SET jobstatus = 'Documentation', UserNumDocumenter = OwnerNum WHERE jobstatus = 'ReadyToBeDocumented';
UPDATE job SET jobstatus = 'Documentation', UserNumInfo = OwnerNum WHERE jobstatus = 'NeedsDocumentationClarification';

UPDATE job SET jobstatus = 'Complete'      WHERE jobstatus = 'Complete';
UPDATE job SET jobstatus = 'Complete'      WHERE jobstatus = 'NotifyCustomer';

UPDATE job SET jobstatus = 'Cancelled'     WHERE jobstatus = 'Rescinded';
UPDATE job SET jobstatus = 'Cancelled'     WHERE jobstatus = 'Deleted';

ALTER TABLE job CHANGE JobStatus PhaseCur varchar(255) NOT NULL;


ALTER TABLE job DROP COLUMN expertNum;
ALTER TABLE job DROP COLUMN ownerNum;

ALTER TABLE jobevent CHANGE OwnerNum UserNumEvent BIGINT NOT NULL;
ALTER TABLE jobevent ADD COLUMN MainRTF TEXT NOT NULL;

DELETE FROM joblink WHERE linktype IN(5,3); -- already converted to FKeys on Quote and Review tables.
UPDATE joblink SET LinkType = LinkType-1 WHERE LinkType>5; -- Deleted link type Quote = 5
UPDATE joblink SET LinkType = LinkType-1 WHERE LinkType>3; -- Deleted link type Review = 3

DROP TABLE IF EXISTS jobnotifycust;
CREATE TABLE jobnotifycust(
		JobNotifyCustNum BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
		JobNum BIGINT NOT NULL,
		PatNum BIGINT NOT NULL,
		UserNumNotifier BIGINT NOT NULL,
		Description VARCHAR(255) NOT NULL,
		SecDateTEntry     DATETIME NOT NULL DEFAULT '0001-01-01',
		DateTimeContacted DATETIME NOT NULL DEFAULT '0001-01-01'
	) DEFAULT CHARSET = utf8;






# TODO drop extra columns.
# SELECT * FROM job;




*/
