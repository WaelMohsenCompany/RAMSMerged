namespace MOL.EFDAL.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class Lookup_AdviceMessagesMap : EntityTypeConfiguration<Lookup_AdviceMessages>
    {
        public Lookup_AdviceMessagesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AdviceText)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Lookup_AdviceMessages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AdviceText).HasColumnName("AdviceText");
        }
    }
}
