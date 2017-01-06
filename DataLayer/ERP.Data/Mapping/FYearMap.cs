using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class FYearMap : EntityTypeConfiguration<FYear>
    {
        public FYearMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CompId, t.FinYear });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CompId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FinYear)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("FYear");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompId).HasColumnName("CompId");
            this.Property(t => t.FinYear).HasColumnName("FinYear");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
