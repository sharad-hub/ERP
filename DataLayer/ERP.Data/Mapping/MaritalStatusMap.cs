using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class MaritalStatusMap : EntityTypeConfiguration<MaritalStatus>
    {
        public MaritalStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MaritalStatus1)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("MaritalStatuses");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompId).HasColumnName("CompId");
            this.Property(t => t.MaritalStatus1).HasColumnName("MaritalStatus");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
