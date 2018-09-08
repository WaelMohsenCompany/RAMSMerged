using MOL.EFDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    //::Todo Remove code under unit of work

    public class EstablishmentRep
    {
        MOLEFEntities MOLRep = new MOLEFEntities();


        public List<Enum_Service> GetGosiPaymentBlockedServices()
        {
            var blockedServices = MOLRep.Enum_Service.Where(x => x.IsGosiStoppedService == true).Select(s => s).ToList();
            return blockedServices?.Any() == true ? blockedServices : null;
        }

        public bool IsGosiPaymentBlockedServices(int serviceID)
        {
            var blockedServices = MOLRep.Enum_Service.FirstOrDefault(x => x.IsGosiStoppedService == true && x.Id == serviceID);
            return blockedServices != null;
        }

        public bool HasEstablishmentWp200Violations(long unifiedNumberId, out long wp200ViolationsUnits)
        {
            var unpaidWP200ViolatedUN = MOLRep.MOL_VwUnpaidWP200Violations.Where(x => x.FK_UnifiedNumberId == unifiedNumberId);
            if (unpaidWP200ViolatedUN.Any())
            {
                wp200ViolationsUnits = unpaidWP200ViolatedUN.First().TotalDueUnits;
                return true;
            }
            else
            {
                wp200ViolationsUnits = 0;
                return false;
            }
        }

        public void LogWP200ViolationCorrection(long transactionId, long wp200ViolatedUNId)
        {
            MOL_WP200ViolationsCorrections correction = MOLRep.MOL_WP200ViolationsCorrections.Create();
            correction.FK_Service_TransactionId = transactionId;
            correction.FK_Service_LastServiceStatusId = 4;
            correction.FK_WP200ViolatedUNId = wp200ViolatedUNId;

            MOLRep.MOL_WP200ViolationsCorrections.Add(correction);
            MOLRep.SaveChanges();
        }

        public static bool ValidateEstablishmentStatus(long establishmentID)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from e in context.MOL_Establishment
                             where e.PK_EstablishmentId == establishmentID && e.FK_EstablishmentStatusId == 1
                             select e;
                return result.Any();
            }
        }

        public static bool HasIstikdamVISACredit(long establishmentID)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from c in context.MOL_EstablishmentVisaCredit
                             where c.EstablishmentID == establishmentID
                             select c;
                return result.Any();
            }
        }

        public static bool HasPendingIstikdamBalanceRequest(long establishmentID)
        {
            List<int> pendingStatusList = new List<int>();
            pendingStatusList.Add((int)VisaServicesRepository.IstikdamBalanceRequestStatusList.rsePendingWithResearcher);
            pendingStatusList.Add((int)VisaServicesRepository.IstikdamBalanceRequestStatusList.rseAssingedToEstablishment);
            pendingStatusList.Add((int)VisaServicesRepository.IstikdamBalanceRequestStatusList.rseRejectedAndBackToEstablishment);
            pendingStatusList.Add((int)VisaServicesRepository.IstikdamBalanceRequestStatusList.rseApprovedFromResearcher);
            pendingStatusList.Add((int)VisaServicesRepository.IstikdamBalanceRequestStatusList.rseApprovedFromLaborOffice);
            pendingStatusList.Add((int)VisaServicesRepository.IstikdamBalanceRequestStatusList.rseComplaintRequest);
            pendingStatusList.Add((int)VisaServicesRepository.IstikdamBalanceRequestStatusList.rseSentBackToLaborOffice);

            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from r in context.MOL_VisaRequests
                             where r.FK_EstablishmentID == establishmentID && pendingStatusList.Contains(r.LastStatus)
                             select r;
                if (result.Any())
                    return true;
                else
                    return false;
            }
        }

        public static bool HasPendingGovContractOrAssentRequest(long establishmentID)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var assentsResult = from a in context.MOL_GC_Assents
                                    where a.EstablishmentID == establishmentID && (a.StatusID == 2 || a.StatusID == 4)
                                    select a;

                var contractsResult = from c in context.MOL_GC_Contracts
                                      join e in context.MOL_GC_ContractEstablishments
   on c.ID equals e.ContractID
                                      where e.EstablishmentID == establishmentID && (c.StatusID == 2 || c.StatusID == 4)
                                      select e;

                return assentsResult.Any() || contractsResult.Any();
            }
        }

        public static bool HasForiegnLaborers(long establishmentID)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from l in context.MOL_Laborer
                             where l.FK_EstablishmentId == establishmentID && l.FK_SaudiFlagId == 2
                             select l;
                return result.Any();
            }
        }

        public static bool HasLaborerTransferRequest(string connectionString, string procedureName, int laborOfficeId, long sequenceNumber)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase database = new Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase(connectionString);
            System.Data.Common.DbCommand command = database.GetStoredProcCommand(procedureName);

            database.AddInParameter(command, "p_laboffcmpy", System.Data.DbType.Int32, laborOfficeId);
            database.AddInParameter(command, "p_cmpyno", System.Data.DbType.Int64, sequenceNumber);

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
                reader?.Close();
            }

            int result;
            if (dt != null && dt.Rows.Count > 0 && int.TryParse(dt.Rows[0][0].ToString(), out result))
                return (result > 0);
            else
                return false;
        }

        public static bool HasCLBRequest(int laborOfficeId, long sequenceNumber)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from clb in context.CLB_Online_Requests
                             where (clb.p_lab_off_cmpy == laborOfficeId && clb.p_cmpy_no == sequenceNumber) || (clb.o_lab_off_cmpy == laborOfficeId && clb.o_cmpy_no == sequenceNumber)
                             select clb;
                if (result.Any())
                    return true;
                else
                    return false;
            }
        }

        public static bool HasVISAIssueRequest(string connectionString, string procedureName, int laborOfficeId, long sequenceNumber)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase database = new Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase(connectionString);
            System.Data.Common.DbCommand command = database.GetStoredProcCommand(procedureName);

            database.AddInParameter(command, "p_laboffcmpy", System.Data.DbType.Int32, laborOfficeId);
            database.AddInParameter(command, "p_cmpyno", System.Data.DbType.Int64, sequenceNumber);

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
                reader?.Close();
            }

            int result;
            if (dt != null && dt.Rows.Count > 0 && int.TryParse(dt.Rows[0][0].ToString(), out result))
                return (result > 0);
            else
                return false;
        }
    }
}
