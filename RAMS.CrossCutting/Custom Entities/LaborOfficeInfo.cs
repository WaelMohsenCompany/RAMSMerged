// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 04-16-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-16-2018
// ***********************************************************************
// <copyright file="LaborerOfficeInfo.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.Serialization;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class LaborerOfficeInfo.
    /// </summary>
    [DataContract]
    [Serializable]
    public class LaborOfficeInfo
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; set; }
    }
}
