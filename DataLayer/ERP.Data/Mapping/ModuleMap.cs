using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class ModuleMap : EntityTypeConfiguration<Module>
    {
        public ModuleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ModuleKeyCode)
                .HasMaxLength(50);

            this.Property(t => t.ModuleName)
                .HasMaxLength(50);

            //this.Property(t => t.ImageIndexNo)
            //    .HasMaxLength(50);

            //this.Property(t => t.BackgroundColor)
            //    .HasMaxLength(50);

            //this.Property(t => t.FontColor)
            //    .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Modules");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ModuleKeyCode).HasColumnName("ModuleKeyCode");
            this.Property(t => t.ModuleName).HasColumnName("ModuleName");
            this.Property(t => t.Orderby).HasColumnName("Orderby"); 
           
            
        }
    }
}
