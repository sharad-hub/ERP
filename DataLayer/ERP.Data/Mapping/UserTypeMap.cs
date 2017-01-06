using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class UserTypeMap : EntityTypeConfiguration<UserRole>
    {
        public UserTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.UserId);
                 

            //this.Property(t => t.TypeCode)
            //    .IsFixedLength()
            //    .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("UserType");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            //this.Property(t => t.TypeCode).HasColumnName("TypeCode");
            
        }
    }
}
