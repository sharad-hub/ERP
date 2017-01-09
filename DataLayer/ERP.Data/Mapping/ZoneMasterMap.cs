using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class ZoneMasterMap : EntityTypeConfiguration<Zone>
    {
        public ZoneMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.ZoneId);

            // Properties
            this.Property(t => t.ZoneName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ZoneMaster");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.ZoneName).HasColumnName("ZoneName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
