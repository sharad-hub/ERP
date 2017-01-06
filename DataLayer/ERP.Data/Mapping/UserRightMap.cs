using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class UserRightMap : EntityTypeConfiguration<UserRight>
    {
        public UserRightMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AutoId, t.MenuId });

            // Properties
            this.Property(t => t.AutoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //this.Property(t => t.UserId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("UserRights");
            this.Property(t => t.AutoId).HasColumnName("AutoId");
            this.Property(t => t.MenuId).HasColumnName("MenuId");
            this.Property(t => t.AccessTypeID).HasColumnName("AccessTypeID");
        }
    }
}
