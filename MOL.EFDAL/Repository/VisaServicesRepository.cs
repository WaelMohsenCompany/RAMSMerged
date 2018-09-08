using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    using System;
    using System.Linq;

    public class VisaServicesRepository
    {
        public enum IstikdamBalanceRequestStatusList
        {
            rseNone = -1,
            rseAssingedToEstablishment = 1,
            rsePendingWithResearcher = 2,
            rseRejectedFromResearcher = 4,
            rseApprovedFromResearcher = 8,
            rseRejectedFromLaborOffice = 16,
            rseApprovedFromLaborOffice = 32,
            rseSentBackToLaborOffice = 64,
            rseRejectedFromMinistry = 128,
            rseApprovedFromMinistry = 256,
            rseComplaintRequest = 512,
            rseComplaintRejected = 1024,
            rseCComplaintApproved = 2048,
            rseCComplaintCanceled = 4096,
            rseCanceled = 8192,
            rseAutomaticRejection = 16384,
            rseRejectedAndBackToEstablishment = 32768,
            rsePendingOnLaborOffice = (int)IstikdamBalanceRequestStatusList.rseApprovedFromResearcher + (int)IstikdamBalanceRequestStatusList.rseSentBackToLaborOffice

        }

        public static int GetEstablishmentRunawayRequests(long establishmentID, DateTime runawayRequestPeriod)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                return context.SP_CUST_GetEstablishmentRunawayRequests(establishmentID, runawayRequestPeriod);
            }
        }

        public static int GetEstablishmentNewComersCount(string connectionString, string procedureName, int laborofficeId, long sequenceNumber, int newComerFrom)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase database = new Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase(connectionString);
            System.Data.Common.DbCommand command = database.GetStoredProcCommand(procedureName);

            database.AddInParameter(command, "p_laboffcmpy", System.Data.DbType.Int32, laborofficeId);
            database.AddInParameter(command, "p_cmpyno", System.Data.DbType.Int64, sequenceNumber);
            database.AddInParameter(command, "p_fromdate", System.Data.DbType.Int32, newComerFrom);

            System.Data.IDataReader reader = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                reader = Mol.DataAccessLayer.Utility.ExecuteReader(database, command);
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            int newComerCount;
            if (dt != null && dt.Rows.Count > 0 && int.TryParse(dt.Rows[0][0].ToString(), out newComerCount))
                return newComerCount;
            else
                return 0;
        }

        public static int GetEstablishmentTransferedNewComersCount(string connectionString, string procedureName, int laborofficeId, long sequenceNumber, int transferNewComerFrom)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase database = new Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase(connectionString);
            System.Data.Common.DbCommand command = database.GetStoredProcCommand(procedureName);

            database.AddInParameter(command, "p_laboffcmpy", System.Data.DbType.Int32, laborofficeId);
            database.AddInParameter(command, "p_cmpyno", System.Data.DbType.Int64, sequenceNumber);
            database.AddInParameter(command, "p_fromdate", System.Data.DbType.Int32, transferNewComerFrom);

            System.Data.IDataReader reader = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                reader = Mol.DataAccessLayer.Utility.ExecuteReader(database, command);
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            int TransferedNewComerCount;
            if (dt != null && dt.Rows.Count > 0 && int.TryParse(dt.Rows[0][0].ToString(), out TransferedNewComerCount))
                return TransferedNewComerCount;
            else
                return 0;
        }

        public static void LogRequestImmediateApproveDetails(MOL_VisaRequestImmediateApproveDetails VisaRequestImmediateApproveDetails)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                context.MOL_VisaRequestImmediateApproveDetails.Add(VisaRequestImmediateApproveDetails);
                context.SaveChanges();
            }
        }
        public static bool IsValidFarmingJob(int jobId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
                return context.Lookup_Job.Where(x => x.Id == jobId).Single().IsValid1_5ForIstiqdam;
        }

        public static void SaveEstablishmentModifiedJobHistory(MOL_EstablishmentModifiedJobsHistory modifiedJob)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                context.MOL_EstablishmentModifiedJobsHistory.Add(modifiedJob);
                context.SaveChanges();
            }
        }

        public static bool ModifyVISACreditJob(long visaRequestId, long userId, int requestTypeId, int genderId, int newGenderId, int oldJobId, int newJobId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {

                var newJobVISACreditQuery = from x in context.MOL_EstablishmentVisaCredit
                                            from a in context.MOL_EstablishmentVisaCreditJobs
                                            where x.ID == a.VisaCreditID
                                            where x.TypeID == requestTypeId && x.RequestID == visaRequestId && a.JobID == newJobId && a.GenderID == newGenderId
                                            select a;

                int usedCredit = 0;
                int approvedCredit = 0;
                int creditId = 0;

                if (newJobVISACreditQuery.Any())
                {
                    var newJobVISACredit = newJobVISACreditQuery.First();

                    var q = from h in context.MOL_EstablishmentVisaCreditJobsHistory
                            where h.VisaCreditJobID == newJobVISACredit.ID
                            select h;

                    if (q.Any())
                        context.MOL_EstablishmentVisaCreditJobsHistory.RemoveRange(q);

                    approvedCredit = newJobVISACredit.ApprovedCredit;
                    usedCredit = newJobVISACredit.UsedCredit;
                    context.MOL_EstablishmentVisaCreditJobs.Remove(newJobVISACredit);
                }

                var query = from x in context.MOL_EstablishmentVisaCredit
                            from a in context.MOL_EstablishmentVisaCreditJobs
                            where x.ID == a.VisaCreditID
                            where x.TypeID == requestTypeId && x.RequestID == visaRequestId && a.JobID == oldJobId && a.GenderID == genderId
                            select a;

                if (query.Any())
                {
                    foreach (var j in query)
                    {
                        j.JobID = newJobId;
                        j.GenderID = newGenderId;
                        j.ApprovedCredit += approvedCredit;
                        j.UsedCredit = usedCredit;
                        creditId = j.VisaCreditID;
                    }

                    context.MOL_EstablishmentModifiedJobsHistory.Add(new MOL_EstablishmentModifiedJobsHistory
                    {
                        UserId = userId,
                        CreditId = creditId,
                        NewJobId = newJobId,
                        OldJobId = oldJobId,
                        OldGenderId = genderId,
                        NewGenderId = newGenderId,
                        CreatedDate = DateTime.Now
                    });

                    context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }
    }
}
