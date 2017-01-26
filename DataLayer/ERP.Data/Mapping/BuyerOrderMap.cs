using ERP.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class BuyerOrderMap : EntityTypeConfiguration<BuyerOrder>
    {
        public BuyerOrderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.BuyerID, t.FinYearId, t.BuyerOrderNo });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.BuyerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FinYearId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BuyerOrderNo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BuyerOrders");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BuyerID).HasColumnName("BuyerID");
            this.Property(t => t.FinYearId).HasColumnName("FinYearId");
            this.Property(t => t.BuyerOrderNo).HasColumnName("BuyerOrderNo");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            //this.Property(t => t.BuyerOrderTrackerStatusId).HasColumnName("BuyerOrderTrackerStatusId");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.CreatedById).HasColumnName("CreatedById");
            this.Property(t => t.LastmodifiedDate).HasColumnName("LastmodifiedDate");
            this.Property(t => t.LastModifiedById).HasColumnName("LastModifiedById");
            this.Property(t => t.OrderStatusId).HasColumnName("OrderStatusId");

            // Relationships
            this.HasRequired(t => t.Buyer)
                .WithMany(t => t.BuyerOrders)
                .HasForeignKey(d => d.BuyerID);
            this.HasRequired(t => t.FinYear)
                .WithMany(t => t.BuyerOrders)
                .HasForeignKey(d => d.FinYearId);
            this.HasOptional(t => t.OrderStatus)
                .WithMany(t => t.BuyerOrders)
                .HasForeignKey(d => d.OrderStatusId);

        }
    }
}
