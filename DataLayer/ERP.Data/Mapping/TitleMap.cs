using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class TitleMap : EntityTypeConfiguration<Title>
    {
        public TitleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title1)
                .HasMaxLength(20);

            this.Property(t => t.Gender)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Titles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompId).HasColumnName("CompId");
            this.Property(t => t.Title1).HasColumnName("Title");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
