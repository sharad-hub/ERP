using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class CountryMasterMap : EntityTypeConfiguration<Country>
    {
        public CountryMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CountryName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CountryMaster");
            this.Property(t => t.ID).HasColumnName("Id");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
