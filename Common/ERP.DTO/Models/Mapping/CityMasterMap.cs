using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.DTO.Models.Mapping
{
    public class CityMasterMap : EntityTypeConfiguration<CityMaster>
    {
        public CityMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CityName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CityMaster");
            this.Property(t => t.ID).HasColumnName("CityId");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
