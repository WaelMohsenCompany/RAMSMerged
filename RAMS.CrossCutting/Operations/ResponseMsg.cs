// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="ResponseMsg.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;


namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class ResponseMsg.
    /// </summary>
    [DataContract]
    public class ResponseMsg
    {
        /// <summary>
        /// Gets or sets the rule type identifier.
        /// </summary>
        /// <value>The rule type identifier.</value>
        [DataMember]
        public string RuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the response text.
        /// </summary>
        /// <value>The response text.</value>
        [DataMember]
        public string ResponseText { get; set; }
    }
}
