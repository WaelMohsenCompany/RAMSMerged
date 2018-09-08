// ***********************************************************************
// Assembly         : RAMS.InfrastructureService
// Author           : WaelMohsen
// Created          : 06-03-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 05-28-2018
// ***********************************************************************
// <copyright file="GetSystemMessages.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using ESBPublic.Business.Concretes;
using RAMS.CrossCutting;
using System.ServiceModel.Activation;

namespace RAMS.InfrastructureService.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetSystemMessages.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GetSystemMessages : BaseDisposeClass
    {
        #region Private Members 

        /// <summary>
        /// The _messages service
        /// </summary>
        /// <value>The messages database service.</value>
        private Table_WebMessagesService MessagesDBService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSystemMessages" /> class.
        /// </summary>
        public GetSystemMessages()
        {
            MessagesDBService = new Table_WebMessagesService();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the message body by passing  message key .
        /// </summary>
        /// <param name="messageKey">The message key.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetMessageBody(string messageKey)
        {
            if (string.IsNullOrEmpty(messageKey))
                return string.Empty;

            var item = MessagesDBService.SelectOne(x => x.MessageCode == messageKey && x.IsActive);
            return item != null ? item.Body : string.Empty;
        }

        /// <summary>
        /// Gets the message body by passing  message key and parameters.
        /// </summary>
        /// <param name="messageKey">The message key.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns>GetMessageBodyWithParameters</returns>
        public string GetMessageBody(string messageKey, params dynamic[] parametersValue)
        {
            if (string.IsNullOrEmpty(messageKey))
                return string.Empty;

            var item = MessagesDBService.SelectOne(x => x.MessageCode == messageKey && x.IsActive);
            return item != null ? string.Format(item.Body, parametersValue) : string.Empty;
        }

        /// <summary>
        /// Gets the message body by pass messageKey and language id .
        /// </summary>
        /// <param name="messageKey">The message key.</param>
        /// <param name="languageId">The language identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetMessageBody(string messageKey, int languageId)
        {
            if (string.IsNullOrEmpty(messageKey) || languageId <= 0)
                return string.Empty;

            var item = MessagesDBService.SelectOne(x => x.MessageCode == messageKey && x.FK_LanguageId == languageId && x.IsActive);
            return item != null ? item.Body : string.Empty;
        }

        /// <summary>
        /// Gets the message body by pass message Key ,  language id  and project id  .
        /// </summary>
        /// <param name="messageKey">The message key.</param>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetMessageBody(string messageKey, int languageId, int projectId)
        {
            if (string.IsNullOrEmpty(messageKey) || languageId <= 0 || projectId <= 0) return string.Empty;
            var item =
                MessagesDBService.SelectOne(
                    x => x.MessageCode == messageKey && x.FK_LanguageId == languageId &&
                    x.FK_ProjectId == projectId && x.IsActive);

            return item != null ? item.Body : string.Empty;
        }

        #endregion
    }
}
