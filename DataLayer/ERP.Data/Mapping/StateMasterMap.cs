using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class StateMasterMap : EntityTypeConfiguration<State>
    {
        public StateMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.StateName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StateMaster");
            this.Property(t => t.ID).HasColumnName("Id");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
