using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.DTO.Models.Mapping
{
    public class StateMasterMap : EntityTypeConfiguration<StateMaster>
    {
        public StateMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.StateId);

            // Properties
            this.Property(t => t.StateName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StateMaster");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
