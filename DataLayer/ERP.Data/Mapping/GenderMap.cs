using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class GenderMap : EntityTypeConfiguration<Gender>
    {
        public GenderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Gender1)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Genders");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Gender1).HasColumnName("Gender");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
