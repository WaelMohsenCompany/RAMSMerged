// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 04-08-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-11-2018
// ***********************************************************************
// <copyright file="ActionResults.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class ActionResults.
    /// </summary>
    /// <typeparam name="T">Results List Type</typeparam>
    [DataContract]
    public class ActionResults<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the results code.
        /// </summary>
        /// <value>The results code.</value>
        [DataMember]
        public ResultsCodes ResultsCode { get; set; }

        /// <summary>
        /// Gets or sets the description of the action.
        /// </summary>
        /// <value>The action code.</value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the results list.
        /// </summary>
        /// <value>The results list.</value>
        [DataMember]
        public T ResultsList { get; set; }
    }
}
