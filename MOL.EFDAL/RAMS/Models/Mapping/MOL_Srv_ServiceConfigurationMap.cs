// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_Srv_ServiceConfigurationMap.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MOL.EFDAL.Models.Mapping
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    /// <summary>
    /// Class MOL_Srv_ServiceConfigurationMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{MOL.EFDAL.Models.MOL_Srv_ServiceConfiguration}" />
    public class MOL_Srv_ServiceConfigurationMap : EntityTypeConfiguration<MOL_Srv_ServiceConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_Srv_ServiceConfigurationMap"/> class.
        /// </summary>
        public MOL_Srv_ServiceConfigurationMap()
        {
            // Primary Key
            this.HasKey(t => t.PK_ServiceConfigurationId);

            // Properties
            this.Property(t => t.PK_ServiceConfigurationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FK_ServiceId)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ConfigKey)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ConfigValue)
                .HasMaxLength(1024);

            // Table & Column Mappings
            this.ToTable("MOL_Srv_ServiceConfiguration");
            this.Property(t => t.PK_ServiceConfigurationId).HasColumnName("PK_ServiceConfigurationId");
            this.Property(t => t.FK_ServiceId).HasColumnName("FK_ServiceId");
            this.Property(t => t.ConfigKey).HasColumnName("ConfigKey");
            this.Property(t => t.ConfigValue).HasColumnName("ConfigValue");
        }
    }
}
