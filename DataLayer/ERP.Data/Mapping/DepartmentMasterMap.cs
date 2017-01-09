using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class DepartmentMasterMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.DepartId);

            // Properties
            this.Property(t => t.DepartmentName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DepartmentMaster");
            this.Property(t => t.DepartId).HasColumnName("DepartId");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
