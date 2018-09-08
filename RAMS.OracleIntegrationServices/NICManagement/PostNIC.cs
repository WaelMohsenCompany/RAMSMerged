// ***********************************************************************
// Assembly         : RAMS.OracleIntegrationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 03-07-2018
// ***********************************************************************
// <copyright file="PostNIC.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Oracle.ManagedDataAccess.Client;
using RAMS.CrossCutting;
using System;
using System.Configuration;
using System.Data;

namespace RAMS.OracleIntegrationServices.NICManagement
{
    /// <summary>
    /// Class PostNIC.
    /// </summary>
    /// <seealso cref="RAMS.CrossCutting.BaseDisposeClass" />
    /// <seealso cref="RAMS.OracleIntegrationServices.NICManagement.Post.INICOperations" />
    public class PostNIC : BaseDisposeClass
    {
        #region "Member Variables"

        /// <summary>
        /// The oracle connection string
        /// </summary>
        private static readonly string oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;

        /// <summary>
        /// Read Schema name from Configuration File
        /// </summary>
        private static readonly string oracleSchema = ConfigurationManager.AppSettings["OracleSchema"];

        /// <summary>
        /// The runner waiting sponsor transfer command
        /// </summary>
        private static readonly string runnerWaitingSponsorTransferCommand = oracleSchema + ".wfr11$web_upd_Status";

        /// <summary>
        /// The working waiting sponsor transfer command
        /// </summary>
        private static readonly string workingWaitingSponsorTransferCommand = oracleSchema + ".wfr11$web_upd_runaway";

        #endregion

        /// <summary>
        /// Function changes Laborer Status in NIC
        /// </summary>
        /// <param name="laborerOfficeId">Laborer Office Id</param>
        /// <param name="saudiFlagId">Is Saudi Laborer</param>
        /// <param name="laborerSequenceNumber">Laborer Sequence Number</param>
        /// <param name="targetStatus">New Laborer status</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg ChangeLaborerStatus(int laborerOfficeId, int saudiFlagId, int laborerSequenceNumber,
            TypedObjects.LaborerStatus targetStatus)
        {
            //Check input parameters is valid
            if (laborerOfficeId <= 0 && laborerOfficeId == int.MinValue ||
                saudiFlagId <= 0 && saudiFlagId == int.MinValue ||
                 laborerSequenceNumber <= 0 && laborerSequenceNumber == int.MinValue)
            {
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            //Call Oracle Functions to Change Status
            switch (targetStatus)
            {
                case TypedObjects.LaborerStatus.WorkingWaitingSponsorTransfer:
                    return ChangeLaborerStatusToWorkingWaitingSponsorTransfer(laborerOfficeId, saudiFlagId, laborerSequenceNumber);

                case TypedObjects.LaborerStatus.RunnerWaitingSponsorTransfer:
                    return ChangeLaborerStatusToRunnerWaitingSponsorTransfer(laborerOfficeId, saudiFlagId, laborerSequenceNumber);
            }

            return new ResponseMsg
            {
                IsSuccess = false,
                RuleTypeId = "ChangeLaborerStatus.TypedObjects.LaborerStatus is Invalid"
            };
        }

        #region " Private Functions "

        /// <summary>
        /// Function prepares Oracle Parameters for Oracle Command
        /// </summary>
        /// <param name="paramName">Parameter Name</param>
        /// <param name="oracleDbType">Parameter Oracle Type</param>
        /// <param name="paramDirection">Parameter Direction</param>
        /// <param name="paramValue">Parameter Value</param>
        /// <returns>OracleParameter.</returns>
        private OracleParameter GetOracleParameter(string paramName, OracleDbType oracleDbType,
            ParameterDirection paramDirection, object paramValue)
        {
            var oracleParameter = new OracleParameter
            {
                ParameterName = paramName,
                OracleDbType = oracleDbType,
                Direction = paramDirection,
                Value = paramValue
            };
            return oracleParameter;
        }

        /// <summary>
        /// Function changes laborer status in MIT to Working
        /// </summary>
        /// <param name="laborerOfficeId">Laborer Office Id</param>
        /// <param name="saudiFlagId">Is Saudi Laborer</param>
        /// <param name="laborerSequenceNumber">Laborer Sequence Number</param>
        /// <returns>ResponseMsg.</returns>
        private ResponseMsg ChangeLaborerStatusToRunnerWaitingSponsorTransfer(int laborerOfficeId, int saudiFlagId, int laborerSequenceNumber)
        {
            //====================================================================================
            //Initiate Oracle Connection and Oracle Command objects
            using (var oracleConnection = new OracleConnection(oracleConnectionString))
            using (var oracleCommand = new OracleCommand(runnerWaitingSponsorTransferCommand))
            {
                try
                {
                    //====================================================================================
                    //Fill Oracle Command with Values
                    oracleCommand.CommandType = CommandType.StoredProcedure;

                    var laborerOfficeIdParam =
                        GetOracleParameter("P_LAB_OFF", OracleDbType.Double, ParameterDirection.Input, laborerOfficeId);

                    var saudiFlagIdParam =
                       GetOracleParameter("P_NAT_FLG", OracleDbType.Double, ParameterDirection.Input, saudiFlagId);

                    var sequenceNumberParam =
                       GetOracleParameter("P_LAB_SER", OracleDbType.Double, ParameterDirection.Input, laborerSequenceNumber);

                    var resultsParam =
                        GetOracleParameter("ReturnValue", OracleDbType.Double, ParameterDirection.ReturnValue, 100);

                    oracleCommand.Parameters.Add(laborerOfficeIdParam);
                    oracleCommand.Parameters.Add(saudiFlagIdParam);
                    oracleCommand.Parameters.Add(sequenceNumberParam);
                    oracleCommand.Parameters.Add(resultsParam);

                    //====================================================================================
                    //Open connection to Oracle
                    oracleConnection.Open();
                    oracleCommand.Connection = oracleConnection;

                    //====================================================================================
                    //Execute the command and Check results
                    var result = oracleCommand.ExecuteNonQuery();
                    oracleConnection.Close();

                    ////if (result == 0)
                    {
                        return new ResponseMsg
                        {
                            IsSuccess = true,
                            RuleTypeId = "wfr11$web_upd_Status"
                        };
                    }
                    ////else
                    ////{
                    ////    return new ResponseMsg()
                    ////    {
                    ////        IsSuccess = false,
                    ////        RuleTypeId = "wfr11$web_upd_Status. No Records Affected"
                    ////    };
                    ////}
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        RuleTypeId = string.Format("wfr11$web_upd_Status. {0}", ex.Message)
                    };
                }
            }
        }

        /// <summary>
        /// Function changes laborer status in MIT to Runner
        /// </summary>
        /// <param name="laborerOfficeId">Laborer Office Id</param>
        /// <param name="saudiFlagId">Is Saudi Laborer</param>
        /// <param name="laborerSequenceNumber">Laborer Sequence Number</param>
        /// <returns>ResponseMsg.</returns>
        private ResponseMsg ChangeLaborerStatusToWorkingWaitingSponsorTransfer(int laborerOfficeId, int saudiFlagId, int laborerSequenceNumber)
        {
            //====================================================================================
            //Initiate Oracle Connection and Oracle Command objects
            using (var oracleConnection = new OracleConnection(oracleConnectionString))
            using (var oracleCommand = new OracleCommand(workingWaitingSponsorTransferCommand))
            {
                try
                {
                    //====================================================================================
                    //Fill Oracle Command with Values                   
                    oracleCommand.CommandType = CommandType.StoredProcedure;

                    var laborerOfficeIdParam =
                        GetOracleParameter("P_LAB_OFF", OracleDbType.Double, ParameterDirection.Input, laborerOfficeId);

                    var saudiFlagIdParam =
                       GetOracleParameter("P_NAT_FLG", OracleDbType.Double, ParameterDirection.Input, saudiFlagId);

                    var sequenceNumberParam =
                       GetOracleParameter("P_LAB_SER", OracleDbType.Double, ParameterDirection.Input, laborerSequenceNumber);

                    var resultsParam =
                        GetOracleParameter("ReturnValue", OracleDbType.Double, ParameterDirection.ReturnValue, 100);

                    oracleCommand.Parameters.Add(laborerOfficeIdParam);
                    oracleCommand.Parameters.Add(saudiFlagIdParam);
                    oracleCommand.Parameters.Add(sequenceNumberParam);
                    oracleCommand.Parameters.Add(resultsParam);

                    //====================================================================================
                    //Open connection to Oracle
                    oracleConnection.Open();
                    oracleCommand.Connection = oracleConnection;

                    //====================================================================================
                    //Execute the command and Check results
                    var result = oracleCommand.ExecuteNonQuery();
                    oracleConnection.Close();

                    ////if (result == 0)
                    {
                        return new ResponseMsg
                        {
                            IsSuccess = true,
                            RuleTypeId = "wfr11$web_upd_runaway"
                        };
                    }
                    ////else
                    ////{
                    ////    return new ResponseMsg()
                    ////    {
                    ////        IsSuccess = false,
                    ////        RuleTypeId = "wfr11$web_upd_runaway. No Records Affected"
                    ////    };
                    ////}
                }
                catch (Exception ex)
                {
                    oracleConnection.Close();
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        RuleTypeId = string.Format("wfr11$web_upd_runaway. {0}", ex.Message)
                    };
                }
            }
        }

        #endregion
    }
}
