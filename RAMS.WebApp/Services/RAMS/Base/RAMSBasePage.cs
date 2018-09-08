// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 09-04-2018
// ***********************************************************************
// <copyright file="RAMSBasePage.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.SessionState;
using Mol.Common;
using Mol.Integration.Authintication;
using Mol.Integration.Framework.Business;
using Mol.Web.Common.UI;
using RAMS.BusinessServices.Get;
using RAMS.InfrastructureService.FileTransfer;
using RAMS.Web.CrossCutting;

namespace RAMS.WebApp.Services.RAMS.Base
{
    /// <summary>
    /// Class RamsBasePage.
    /// </summary>
    /// <seealso cref="Mol.Web.Common.UI.BasePage" />
    /// <seealso cref="System.Web.SessionState.IRequiresSessionState" />
    public class RamsBasePage : BasePage, IRequiresSessionState
    {
        #region Base

        /// <summary>
        /// get business service
        /// </summary>
        private readonly GetBusinessService _getBusinessService = new GetBusinessService();

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns>MolMembershipUser.</returns>
        protected MolMembershipUser GetCurrentUser()
        {
            var user = new MolMembershipUser();
            try
            {
                user = (MolMembershipUser)Session["MembershipUser"];
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionHandler(ex);
            }
            return user;
        }

        /// <summary>
        /// Gets the page query string.
        /// </summary>
        /// <param name="parametersEnumeration">The parameters enumeration.</param>
        /// <returns>System.String.</returns>
        protected string GetPageQueryString(ParametersEnumeration parametersEnumeration)
        {
            return GetQueryStringParameter(parametersEnumeration.ToString());
            //return "";
        }

        /// <summary>
        /// Determines whether [is current user has privilege] [the specified privilege identifier].
        /// </summary>
        /// <param name="privilegeId">The privilege identifier.</param>
        /// <returns><c>true</c> if [is current user has privilege] [the specified privilege identifier]; otherwise, <c>false</c>.</returns>
        protected bool IsCurrentUserHasPrivilege(long privilegeId)
        {
            if (!HasPrivilege(privilegeId))
                return false;
            return true;
        }

        /// <summary>
        /// Get Establishment Info .
        /// </summary>
        /// <returns>EstablishmentInfo.</returns>
        protected EstablishmentInfo GetEstablishment()
        {
            try
            {
                return new EstablishmentInfo
                {
                    SequenceNumber = GetQueryStringParameter(ParametersEnumeration.SequenceNumber.ToString())
                    ,
                    LaborOfficeId = GetQueryStringParameter(ParametersEnumeration.LaborOfficeId.ToString())
                    ,
                    PkEstablishmentId =
                        long.Parse(GetQueryStringParameter(ParametersEnumeration.EstablishmentId.ToString()))
                    ,
                    EstablishmentName =
                        EstablishmentManager.GetEstablishmentById(
                            long.Parse(GetQueryStringParameter(ParametersEnumeration.EstablishmentId.ToString())))
                            .Name
                };
            }
            catch
            {
                return new EstablishmentInfo();
            }
        }

        /// <summary>
        /// Gets the service identifier from query string.
        /// </summary>
        /// <param name="querystring">The query string.</param>
        /// <returns>System.String.</returns>
        protected string GetServiceIdFromQueryString(string querystring)
        {
            return GetQueryStringParameter("querystring");
        }

        /// <summary>
        /// used in pages have not security control to get laborer office and sequence number .
        /// </summary>
        /// <returns>EstablishmentInfo.</returns>
        protected EstablishmentInfo GetLaborOfficeInfo()
        {
            try
            {
                return new EstablishmentInfo
                {
                    SequenceNumber = GetQueryStringParameter(ParametersEnumeration.SequenceNumber.ToString())
                    ,
                    LaborOfficeId = GetQueryStringParameter(ParametersEnumeration.LaborOfficeId.ToString())
                };
            }
            catch
            {
                return new EstablishmentInfo();
            }
        }


        #endregion

        #region Download file 

        /// <summary>
        /// download file
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="requestNumber">The request number.</param>
        protected void DownloadFile(string fileName, string requestNumber)
        {
            try
            {
                var requestData = new DownloadRequest
                {
                    FileName = fileName,
                    RequestNumber = requestNumber
                };
                var user = GetCurrentUser();
                if (user?.IdNumber == null) return;
                var fileInfo = _getBusinessService.DownloadFile(requestData, user.IdNumber.Value);
                Response.BufferOutput = false;
                var buffer = new byte[6500];
                var bytesRead = 0;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition",
                    "attachment; filename=" + requestData.FileName);
                bytesRead = fileInfo.FileByteStream.Read(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        Response.OutputStream.Write(buffer, 0, bytesRead);
                        // Flush the data to the HTML output.
                        Response.Flush();
                        buffer = new byte[6500];
                        bytesRead = fileInfo.FileByteStream.Read(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        bytesRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                Response.Flush();
                Response.Close();
                Response.End();
                HttpContext.Current.Response.Close();
            }
        }

        #endregion

        #region Client Ip Address

        /// <summary>
        /// HttpRequest request
        /// </summary>
        /// <returns>System.String.</returns>
        protected string GetClientIpAddress()
        {
            var host = Dns.GetHostEntry(GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// return host name
        /// </summary>
        /// <returns>System.String.</returns>
        private static string GetHostName()
        {
            var strHostName = Dns.GetHostName();
            return strHostName;
        }

        #endregion
    }
}