// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_Srv_ServiceConfiguration.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Class MOL_Srv_ServiceConfiguration.
    /// </summary>
    [DataContract]
    public partial class MOL_Srv_ServiceConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_Srv_ServiceConfiguration"/> class.
        /// </summary>
        public MOL_Srv_ServiceConfiguration()
        { }

        /// <summary>
        /// Gets or sets the pk service configuration identifier.
        /// </summary>
        /// <value>The pk service configuration identifier.</value>
        [DataMember]
        public int PK_ServiceConfigurationId { get; set; }
        /// <summary>
        /// Gets or sets the fk service identifier.
        /// </summary>
        /// <value>The fk service identifier.</value>
        [DataMember]
        public string FK_ServiceId { get; set; }
        /// <summary>
        /// Gets or sets the configuration key.
        /// </summary>
        /// <value>The configuration key.</value>
        [DataMember]
        public string ConfigKey { get; set; }
        /// <summary>
        /// Gets or sets the configuration value.
        /// </summary>
        /// <value>The configuration value.</value>
        [DataMember]
        public string ConfigValue { get; set; }
    }
}
