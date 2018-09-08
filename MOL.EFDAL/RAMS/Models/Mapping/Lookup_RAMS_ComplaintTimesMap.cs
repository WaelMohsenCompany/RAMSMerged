// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="Lookup_RAMS_ComplaintTimesMap.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MOL.EFDAL.Models.Mapping
{
    /// <summary>
    /// Class Lookup_RAMS_ComplaintTimesMap.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{MOL.EFDAL.Models.Lookup_RAMS_ComplaintTimes}" />
    public class Lookup_RAMS_ComplaintTimesMap : EntityTypeConfiguration<Lookup_RAMS_ComplaintTimes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lookup_RAMS_ComplaintTimesMap"/> class.
        /// </summary>
        public Lookup_RAMS_ComplaintTimesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ComplaintTime)
                .IsRequired()
                .HasMaxLength(50)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ComplaintOrder)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .HasMaxLength(150)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Lookup_RAMS_ComplaintTimes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ComplaintTime).HasColumnName("ComplaintTime");
            this.Property(t => t.ComplaintOrder).HasColumnName("ComplaintOrder");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
