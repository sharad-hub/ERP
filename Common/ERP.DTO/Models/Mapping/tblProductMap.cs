using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.DTO.Models.Mapping
{
    public class tblProductMap : EntityTypeConfiguration<tblProduct>
    {
        public tblProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductID);

            // Properties
            this.Property(t => t.ProductID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductTitle)
                .HasMaxLength(256);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblProducts");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ProductTitle).HasColumnName("ProductTitle");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
