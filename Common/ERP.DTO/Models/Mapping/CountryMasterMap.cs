using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.DTO.Models.Mapping
{
    public class CountryMasterMap : EntityTypeConfiguration<CountryMaster>
    {
        public CountryMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.CountryId);

            // Properties
            this.Property(t => t.CountryName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CountryMaster");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
