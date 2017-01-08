using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            //this.HasKey(t => new { t.UserID, t.CompId });
            this.HasKey(t =>t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CompId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //this.Property(t => t.UserLoginId)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //this.Property(t => t.UserLoginPassword)
            //    .IsRequired()
            //    .HasMaxLength(50);

            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.CompId).HasColumnName("CompId");
            //this.Property(t => t.UserLoginId).HasColumnName("UserLoginId");
            //this.Property(t => t.UserLoginPassword).HasColumnName("UserLoginPassword");
            this.Property(t => t.Username).HasColumnName("UserName");
            this.Property(t => t.HashedPassword).HasColumnName("HashedPassword");
            this.Property(t => t.IsLocked).HasColumnName("IsLocked");
            //this.Property(t => t.IsActive).HasColumnName("IsActive");

            this.HasOptional(t => t.Manager)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.ManagerID);
        }
    }
}
