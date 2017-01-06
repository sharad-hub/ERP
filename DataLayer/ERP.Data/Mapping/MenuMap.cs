using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MenuCode)
                .HasMaxLength(30);

            this.Property(t => t.MenuName)
                .HasMaxLength(50);

            this.Property(t => t.ImageIndexNo)
                .HasMaxLength(50);

            this.Property(t => t.NavigationPath)
                .HasMaxLength(100);

            this.Property(t => t.ItemImageURL)
                .HasMaxLength(500);

            this.Property(t => t.backgroundColor)
                .HasMaxLength(50);

            this.Property(t => t.FontColor)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Menus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ModuleId).HasColumnName("ModuleId");
            this.Property(t => t.MenuCode).HasColumnName("MenuCode");
            this.Property(t => t.MenuName).HasColumnName("MenuName");
            this.Property(t => t.ImageIndexNo).HasColumnName("ImageIndexNo");
            this.Property(t => t.NavigationPath).HasColumnName("FormName");
            this.Property(t => t.Orderby).HasColumnName("Orderby");
            this.Property(t => t.ItemImageURL).HasColumnName("ItemImageURL");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.IconID).HasColumnName("IconID");
            this.Property(t => t.backgroundColor).HasColumnName("backgroundColor");
            this.Property(t => t.FontColor).HasColumnName("FontColor");
        }
    }
}
