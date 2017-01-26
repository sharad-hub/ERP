using ERP.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class BuyerOrderItemMap : EntityTypeConfiguration<BuyerOrderItem>
    {
        public BuyerOrderItemMap()
        {
            // Primary Key
            this.HasKey(t => new { t.BuyerOrderId, t.ProductId });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.BuyerOrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BuyerOrderItems");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BuyerOrderId).HasColumnName("BuyerOrderId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ProductSkuID).HasColumnName("ProductSkuID");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.MRP).HasColumnName("MRP");
            this.Property(t => t.Quintity).HasColumnName("Quintity");
            this.Property(t => t.SchemeId).HasColumnName("SchemeId");
            this.Property(t => t.SchemeFreeQty).HasColumnName("SchemeFreeQty");
            this.Property(t => t.TotalOrderQty).HasColumnName("TotalOrderQty");
            this.Property(t => t.TotalOrderAmt).HasColumnName("TotalOrderAmt");
            this.Property(t => t.TotalSchemeFreeAmt).HasColumnName("TotalSchemeFreeAmt");
            this.Property(t => t.DiscPercentage).HasColumnName("DiscPercentage");
            this.Property(t => t.DiscAmount).HasColumnName("DiscAmount");
            this.Property(t => t.TaxAmount).HasColumnName("TaxAmount");
            this.Property(t => t.TaxPercentage).HasColumnName("TaxPercentage");
            this.Property(t => t.TotalOrderCost).HasColumnName("TotalOrderCost");

            // Relationships
            //this.HasRequired(t => t.Product)
            //    .WithMany(t => t.BuyerOrderItems)
            //    .HasForeignKey(d => d.ProductId);

        }
    }
}
