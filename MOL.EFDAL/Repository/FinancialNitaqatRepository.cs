using MOL.EFDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public class FinancialNitaqatRepository
    {
        #region Enums

        public enum JoiningStatus
        {
            Pending = 1,
            Rejected = 2,
            Approved = 3
        }

        public enum ApprovalStatus
        {
            Approved = 1,
            Rejected = 2
        }

        public enum ProgramStatus
        {
            Active = 1,
            Inactive = 2,
            AutoStopped=3
        }

        public enum BillStatus
        {
            Pending = 1,
            Paid = 2,
            Expired = 3,
            Canceled = 4
        }

        public enum JoiningRule
        {
            MetAllBusinessRules = 1,
            EstablishmentStatusNotActive = 2,
            UNEstablishmentsHaveUnrejectedJoiningRequest = 3,
            UserNotAuthorized = 4,
            EstablishmentHasActiveNote = 5,
            FNDisabledForEstEconomicActivity = 6,
            HasIstikdamVISACredit = 7,
            HasPendingIstikdamBalanceRequest = 8,
            HasPendingGovContractOrAssentRequest = 9,
            HasVISAIssueRequest = 10,
            HasUnusedVISAs = 11,
            HasForiegnLaborers = 12,
            HasLaborerTransferRequest = 13,
            HasCLBRequest = 14,
            HasNotValidWasel = 15,
            HasExpiredLicense = 16,
            ViolateJobRules = 17,
            HasGeneralError = 18,
            JoinedFNBefore = 19,
            RequestedForeignersExceedMaxAllowed = 20
        }

        #endregion

        #region Functions
        
        public static bool IsEstablishmentJoinedFN(long EstablishmentID)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = context.Program_Establishment.Where(p => p.Establishment_Id == EstablishmentID);
                if (result.Any())
                    return true;
                else
                    return false;

            }
        }

        public static List<Lookup_Job> GetFNJoiningRequestJobs()
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                return context.Lookup_Job.Where(p => p.Id > 0 && p.IsForSaudiOnly == false && (p.isGovSupportEWV == true || p.IsHomeJob == true || p.IsIncludedForEWV != false)).OrderBy(p => p.Name).ToList();
            }
        }

        public static bool IsGenderRequired(int JobId, int economicActivityId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from e in context.MOL_EconomicActivity_Jobs_Gender
                             where e.FK_JobID == JobId && e.FK_EconomicActivityID == economicActivityId
                             select e;
                if (result.Any())
                    return result.First().IsGenderRequired;
                else
                    return true;
            }
        }

        public static void LogJoiningRulesValidation(long establishmentID, string requesterIdNo, JoiningRule joiningRule)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                Joining_Rules_Validation_Log validation = new Joining_Rules_Validation_Log();

                validation.Establishment_Id = establishmentID;
                validation.Requester_IdNo = requesterIdNo;
                validation.Rule_Id = (int)joiningRule;
                validation.Created_On = DateTime.Now;

                context.Joining_Rules_Validation_Log.Add(validation);
                context.SaveChanges();
            }
        }

        public static ProgramStatus GetEstablishmentProgramStatus(long establishmentId, out int saudiUnits)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = context.Program_Establishment.Where(p => p.Establishment_Id == establishmentId);
                if (result.Any())
                {
                    Program_Establishment programEstablishment = result.First();
                    saudiUnits = programEstablishment.Requested_Saudi_Units.Value;
                    return (ProgramStatus)programEstablishment.Program_Status_Id;
                }
                else
                    throw new Exception("UnsubscripedEstablishment");
            }
        }

        public static bool ActivateSubscription(long establishmentId, int saudiUnits, decimal calculatedFees, long userId, string userHostAddress, string userHostName, decimal billNumber, double billValidationDays)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                try
                {
                    var result = context.Program_Establishment.Where(p => p.Establishment_Id == establishmentId);
                    if (result.Any())
                    {
                        Program_Establishment programEstablishment = result.First();

                        programEstablishment.Requested_Saudi_Units = saudiUnits;
                        programEstablishment.Calculated_Fees = calculatedFees;

                        programEstablishment.Program_Status_Id = (int)ProgramStatus.Active;
                        programEstablishment.Deactivation_On = null;

                        programEstablishment.Created_On = DateTime.Now;
                        programEstablishment.Created_By = userId;
                        programEstablishment.User_IP_Address = userHostAddress;
                        programEstablishment.User_PC_Name = userHostName;
                        programEstablishment.Activation_Date = null;

                        Program_Establishment_History history = new Program_Establishment_History();
                        history.Requested_Saudi_Units = saudiUnits;
                        history.Calculated_Fees = calculatedFees;
                        history.Program_Status_Id = (int)ProgramStatus.Active;

                        history.Created_On = DateTime.Now;
                        history.Created_By = userId;
                        history.User_IP_Address = userHostAddress;
                        history.User_PC_Name = userHostName;
                        history.Activation_Date =null;

                        Periodic_Bill bill = new Periodic_Bill();
                        bill.Bill_Amount = calculatedFees;
                        bill.Requested_Saudi_Units = saudiUnits;
                        bill.Calculated_Fees = Convert.ToInt32(calculatedFees);
                        bill.Bill_Number = billNumber;
                        bill.Issued_On = DateTime.Now;
                        bill.Expiration_On = DateTime.Now.AddDays(billValidationDays);
                        bill.Bill_Status_Id = 1;


                        Periodic_Bill_History billHistory = new Periodic_Bill_History();
                        billHistory.Bill_Status_Id = 1;
                        billHistory.Status_Created_On = DateTime.Now;


                        
                        programEstablishment.Program_Establishment_History.Add(history);
                        programEstablishment.Periodic_Bill.Add(bill);
                       // context.Periodic_Bill.Add(bill);

                      
                       

                        context.SaveChanges();

                        return true;
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return false;
                }
                return false;
            }
        }

        public static bool ChangeSaudiUnits(long establishmentId, int saudiUnits, decimal calculatedFees, long userId, string userHostAddress, string userHostName)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                try
                {
                    var result = context.Program_Establishment.Where(p => p.Establishment_Id == establishmentId);
                    if (result.Any())
                    {
                        Program_Establishment programEstablishment = result.First();

                        programEstablishment.Requested_Saudi_Units = saudiUnits;
                        programEstablishment.Calculated_Fees = calculatedFees;

                        programEstablishment.Created_On = DateTime.Now;
                        programEstablishment.Created_By = userId;
                        programEstablishment.User_IP_Address = userHostAddress;
                        programEstablishment.User_PC_Name = userHostName;

                        Program_Establishment_History history = new Program_Establishment_History();
                        history.Requested_Saudi_Units = saudiUnits;
                        history.Calculated_Fees = calculatedFees;
                        history.Program_Status_Id = programEstablishment.Program_Status_Id;
                        history.Created_On = DateTime.Now;
                        history.Created_By = userId;
                        history.User_IP_Address = userHostAddress;
                        history.User_PC_Name = userHostName;               


                        //context.Program_Establishment.Add(programEstablishment);
                        programEstablishment.Program_Establishment_History.Add(history);
                      


                        context.SaveChanges();

                        return true;
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return false;
                }
                return false;
            }
        }

        public static bool DeactivateSubscription(long establishmentId, long userId, string userHostAddress, string userHostName)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                try
                {
                    var result = context.Program_Establishment.Where(p => p.Establishment_Id == establishmentId);
                    if (result.Any())
                    {
                        Program_Establishment programEstablishment = result.First();

                        programEstablishment.Program_Status_Id = (int)ProgramStatus.Inactive;
                        programEstablishment.Deactivation_On = DateTime.Now;

                        programEstablishment.Created_On = DateTime.Now;
                        programEstablishment.Created_By = userId;
                        programEstablishment.User_IP_Address = userHostAddress;
                        programEstablishment.User_PC_Name = userHostName;

                        Program_Establishment_History history = new Program_Establishment_History();
                        history.Requested_Saudi_Units = programEstablishment.Requested_Saudi_Units;
                        history.Calculated_Fees = programEstablishment.Calculated_Fees;
                        history.Program_Status_Id = (int)ProgramStatus.Inactive;
                        history.Created_On = DateTime.Now;
                        history.Created_By = userId;
                        history.User_IP_Address = userHostAddress;
                        history.User_PC_Name = userHostName;

                        programEstablishment.Program_Establishment_History.Add(history);

                        context.SaveChanges();

                        return true;
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return false;
                }
                return false;
            }
        }
        public static bool DeactivateSubscription(int programEstablishmentId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                try
                {
                    var result = context.Program_Establishment.Where(p => p.Id == programEstablishmentId);
                    if (result.Any())
                    {
                        Program_Establishment programEstablishment = result.FirstOrDefault();

                        programEstablishment.Program_Status_Id = (int)ProgramStatus.AutoStopped;
                        programEstablishment.Deactivation_On = DateTime.Now;
                        programEstablishment.Created_On = DateTime.Now;
                        programEstablishment.User_PC_Name = "Bill Generator Server";

                        Program_Establishment_History history = new Program_Establishment_History();
                        history.Requested_Saudi_Units = programEstablishment.Requested_Saudi_Units;
                        history.Calculated_Fees = programEstablishment.Calculated_Fees;
                        history.Program_Status_Id = (int)ProgramStatus.AutoStopped;
                        history.Created_On = DateTime.Now;
                        history.User_PC_Name = "Bill Generator Server";

                        programEstablishment.Program_Establishment_History.Add(history);

                        context.SaveChanges();

                        return true;
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    return false;
                }
                return false;
            }
        }
        public static string GetJoiningRuleDescription(int joiningRuleId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from r in context.Joining_Rule
                             where r.Id == joiningRuleId
                             select r.Description;
                if (result.Any())
                    return result.First();
                else
                    return string.Empty;
            }
        }



        public static bool IsActiveProgramEstablishment(long establishmentID)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                var result = from est in context.Program_Establishment
                             where est.Establishment_Id == establishmentID
                             select est;
                if (result.Any())
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="establishmentID"></param>
        /// <returns></returns>
        public static List<GetEstablishment_Bills_Result> Establishment_Bills(long establishmentID)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                List<GetEstablishment_Bills_Result> res = context.GetEstablishment_Bills(establishmentID);

                return res ?? null;
            }
        }

        public static List<Periodic_Bill> GetAllUnpaidBills()
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                List<Periodic_Bill> res = context.GetAllUnpaidBills();

                return res ?? null;
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="establishmentID"></param>
        /// <returns></returns>

        //public static List<GetEstablishment_RequestsDetails_Result> Establishment_RequestsDetails(long establishmentID)
        //{
        //    using (var context = new MOL.EFDAL.MOLEFEntities())
        //    {
        //        ObjectResult<GetEstablishment_RequestsDetails_Result> res = context.GetEstablishment_RequestsDetails(establishmentID);
        //        if (res != null)
        //            return res.ToList();
        //        else
        //            return null;
        //    }
        //}
        //public static List<Establishment_RequestsDetails_By_programId_Result> Establishment_RequestsDetailsByProgramId(int programId)
        //{
        //    using (var context = new MOL.EFDAL.MOLEFEntities())
        //    {
        //        ObjectResult<Establishment_RequestsDetails_By_programId_Result> res = context.Establishment_RequestsDetails_By_programId(programId);
        //        if (res != null)
        //            return res.ToList();
        //        else
        //            return null;
        //    }
        //}

        public static bool SubmitRequestAndGenerateVoucher(long establishmentId, int saudiUnits, decimal calculatedFees, long userId, string userHostAddress, string userHostName, long billNumber, double billValidationDays)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
             
                Program_Establishment programEstablishment = new Program_Establishment();
                programEstablishment.Establishment_Id = establishmentId;
                programEstablishment.Requested_Saudi_Units = saudiUnits;
                programEstablishment.Calculated_Fees = calculatedFees;
                programEstablishment.Joining_On = DateTime.Now;
                programEstablishment.Program_Status_Id = (int)ProgramStatus.Active;
                programEstablishment.Created_On = DateTime.Now;
                programEstablishment.Created_By = userId;
                programEstablishment.User_IP_Address = userHostAddress;
                programEstablishment.User_PC_Name = userHostName;


                Program_Establishment_History history = new Program_Establishment_History();
                history.Requested_Saudi_Units = saudiUnits;
                history.Calculated_Fees = calculatedFees;
                history.Program_Status_Id = (int)ProgramStatus.Active;
                history.Created_On = DateTime.Now;
                history.Created_By = userId;
                history.User_IP_Address = userHostAddress;
                history.User_PC_Name = userHostName;

                

                Periodic_Bill bill = new Periodic_Bill();
                bill.Bill_Amount = calculatedFees;             
                bill.Requested_Saudi_Units = saudiUnits;
                bill.Calculated_Fees = Convert.ToInt32(calculatedFees);
                bill.Bill_Number = billNumber;
                bill.Issued_On = DateTime.Now;
                bill.Expiration_On = DateTime.Now.AddDays(billValidationDays);
                bill.Bill_Status_Id = 1;
         

                Periodic_Bill_History billHistory = new Periodic_Bill_History();
                billHistory.Bill_Status_Id = 1;
                billHistory.Status_Created_On = DateTime.Now;
             

                context.Program_Establishment.Add(programEstablishment);
                programEstablishment.Program_Establishment_History.Add(history);
                programEstablishment.Periodic_Bill.Add(bill);
                context.Periodic_Bill.Add(bill);

                
                context.SaveChanges();

                return true;
           
            }
        }

        #endregion
    }

}
