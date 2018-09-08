// ***********************************************************************
// Assembly         : RAMS.OracleIntegrationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="GetCase.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Oracle.ManagedDataAccess.Client;
using RAMS.CrossCutting;
using System;
using System.Configuration;
using System.Data;

namespace RAMS.OracleIntegrationServices.CaseManagement
{
    /// <summary>
    /// Class GetCase.
    /// </summary>
    /// <seealso cref="RAMS.CrossCutting.BaseDisposeClass" />
    /// <seealso cref="RAMS.OracleIntegrationServices.CaseManagement.IGetCase" />
    public class GetCase : BaseDisposeClass
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
        /// The command string
        /// </summary>
        private static readonly string commandString =
            $"SELECT COUNT(1) Legal FROM {oracleSchema}.IN1 WHERE INCRESNO IS NULL AND INC_TY = 1 and LAB_OFF_CMPY = :establishmentLaborerOfficeId and CMPY_NO = :establishmentSequenceNumber and  LAB_OFF =:laborerOfficeId and NAT_FLG=:saudiFlagId and LAB_SER =:laborerSequenceNumber";

        #endregion

        /// <summary>
        /// Function checks if Laborer has an Open case on Establishment or not
        /// </summary>
        /// <param name="establishmentLaborerOfficeId">The establishment laborer office identifier.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <param name="saudiFlagId">The Saudi flag identifier.</param>
        /// <param name="laborerOfficeId">The laborer office identifier.</param>
        /// <param name="laborerSequenceNumber">The laborer sequence number.</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg IsLaborerHasCase(int establishmentLaborerOfficeId, int establishmentSequenceNumber,
            int saudiFlagId, int laborerOfficeId, int laborerSequenceNumber)
        {
            //====================================================================================
            //Check input parameters is valid
            if (establishmentLaborerOfficeId <= 0 && establishmentLaborerOfficeId == int.MinValue ||
                establishmentSequenceNumber <= 0 && establishmentSequenceNumber == int.MinValue ||
                laborerOfficeId <= 0 && laborerOfficeId == int.MinValue ||
                saudiFlagId <= 0 && saudiFlagId == int.MinValue ||
                 laborerSequenceNumber <= 0 && laborerSequenceNumber == int.MinValue)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //====================================================================================
            //Initiate Oracle Connection and Oracle Command objects
            //Security Issue: SQL Injection
            //Security Issue Details: Constructing a dynamic SQL statement with input coming from an untrusted source might allow an attacker
            //to modify the statement's meaning or to execute arbitrary SQL commands.
            //====================================================================================
            using (var oracleConnection = new OracleConnection(oracleConnectionString))
            using (var oracleCommand = new OracleCommand(commandString, oracleConnection))
            {
                try
                {
                    oracleCommand.BindByName = true;
                    var establishmentLaborerOfficeIdParam = new OracleParameter
                    {
                        Value = establishmentLaborerOfficeId,
                        ParameterName = "establishmentLaborerOfficeId"
                    };

                    var establishmentSequenceNumberParam = new OracleParameter
                    {
                        Value = establishmentSequenceNumber,
                        ParameterName = "establishmentSequenceNumber"
                    };

                    var laborerOfficeIdParam = new OracleParameter
                    {
                        Value = laborerOfficeId,
                        ParameterName = "laborerOfficeId"
                    };

                    var saudiFlagIdParam = new OracleParameter
                    {
                        Value = saudiFlagId,
                        ParameterName = "saudiFlagId"
                    };

                    var laborerSequenceNumberParam = new OracleParameter
                    {
                        Value = laborerSequenceNumber,
                        ParameterName = "laborerSequenceNumber"
                    };

                    oracleCommand.Parameters.Add(establishmentLaborerOfficeIdParam);
                    oracleCommand.Parameters.Add(establishmentSequenceNumberParam);
                    oracleCommand.Parameters.Add(laborerOfficeIdParam);
                    oracleCommand.Parameters.Add(saudiFlagIdParam);
                    oracleCommand.Parameters.Add(laborerSequenceNumberParam);

                    oracleConnection.Open();

                    using (var oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (oracleDataReader.Read())
                        {
                            var result = 0;
                            int.TryParse(oracleDataReader["Legal"].ToString(), out result);

                            oracleDataReader.Close();

                            //Check return data
                            return new ResponseMsg
                            {
                                IsSuccess = result > 0,
                                RuleTypeId = "IN1 Cases"
                            };
                        }
                    }

                    //===============================================================================
                    //Error while reading data from Oracle
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        RuleTypeId = "IN1 Cases",
                        ResponseText = "Error Reading Data"
                    };
                }
                catch
                {
                    oracleConnection.Close();
                    throw;
                }
            }
        }
    }
}
