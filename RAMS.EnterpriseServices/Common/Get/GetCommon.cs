// ***********************************************************************
// Assembly         : RAMS.EnterpriseServices
// Author           : WaelMohsen
// Created          : 04-04-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="GetCommon.svc.cs" company="Tasleem IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.CrossCutting;
using RAMS.InfrastructureService.FileTransfer;
using System;

namespace RAMS.EnterpriseServices.Common.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetCommon.
    /// </summary>
    public class GetCommon : BaseDisposeClass
    {
        #region " Member Variables "

        /// <summary>
        /// Gets or sets the is get system messages.
        /// </summary>
        /// <value>The is get system messages.</value>
        private InfrastructureService.Get.GetSystemMessages GetSystemMessagesInstance { get; set; }

        /// <summary>
        /// Gets or sets the is get system messages.
        /// </summary>
        /// <value>The is get system messages.</value>
        private ApplicationServices.Common.GetCommon GetCommonInstance { get; set; }

        #endregion

        #region " Public ESB Functions "

        /// <summary>
        /// Functions returns standard System Message
        /// Code Review (Done)
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <returns>Message Info.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg GetSystemMessage(string messageCode)
        {
            //Check input parameters is valid
            if (messageCode.Trim().Equals(string.Empty))
            {
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            //Initialize Service Object(s)
            using (GetSystemMessagesInstance = new InfrastructureService.Get.GetSystemMessages())
            {

                //==================================================================================
                //Check if any parameter is missed
                if (messageCode.Trim().Length == 0)
                {
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        ResponseText = GetSystemMessagesInstance.GetMessageBody(TypedObjects.RAMSMSG00)
                    };
                }

                //==================================================================================
                //Call Application Service
                return new ResponseMsg
                {
                    RuleTypeId = messageCode,
                    IsSuccess = true,
                    ResponseText = GetSystemMessagesInstance.GetMessageBody(messageCode)
                };
            }
        }

        /// <summary>
        /// Function returns system setting value
        /// Code Review (Done)
        /// </summary>
        /// <param name="targetSetting">The target setting value.</param>
        /// <returns>System.Int32.</returns>
        public int GetSystemSettings(TypedObjects.SystemSettings targetSetting)
        {
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (GetCommonInstance = new ApplicationServices.Common.GetCommon())
            {
                //==================================================================================
                //Call Application Service
                return GetCommonInstance.GetSystemSettings(targetSetting, dbUnitOfWork);
            }
        }

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="requestFileName">Name of the request file.</param>
        /// <returns>RemoteFileInfo.</returns>
        public RemoteFileInfo DownloadFile(DownloadRequest requestFileName)
        {
            using (var fileTransfer = new FileTransferService())
            {
                return fileTransfer.DownloadFile(requestFileName);
            }
        }

        #endregion
    }
}
