using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.UserId);
                 

            //this.Property(t => t.TypeCode)
            //    .IsFixedLength()
            //    .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("UserRole");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            //this.Property(t => t.TypeCode).HasColumnName("TypeCode");
            
        }
    }
}
