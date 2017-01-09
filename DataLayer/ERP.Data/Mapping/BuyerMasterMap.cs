using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class BuyerMasterMap : EntityTypeConfiguration<Buyer>
    {
        public BuyerMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.BuyerId);

            // Properties
            this.Property(t => t.BuyerName)
                .HasMaxLength(50);

            this.Property(t => t.BuyerAddress)
                .HasMaxLength(500);

            this.Property(t => t.BuyerDeliveryAddress)
                .HasMaxLength(500);

            this.Property(t => t.BuyerBillingPinCode)
                .HasMaxLength(10);

            this.Property(t => t.BuyerDeliveryPinCode)
                .HasMaxLength(10);

            this.Property(t => t.BuyerMobileNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerPhoneNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerFaxNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerEmailId)
                .HasMaxLength(50);

            this.Property(t => t.BuyerWebSite)
                .HasMaxLength(100);

            this.Property(t => t.BuyerTINNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerPANNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerCSTNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerLSTNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerGSTNo)
                .HasMaxLength(50);

            this.Property(t => t.BuyerServiceTaxNo)
                .HasMaxLength(50);

            this.Property(t => t.ECCCode)
                .HasMaxLength(50);

            this.Property(t => t.Range)
                .HasMaxLength(50);

            this.Property(t => t.Division)
                .HasMaxLength(50);

            this.Property(t => t.Commissionarate)
                .HasMaxLength(50);

            this.Property(t => t.ContactPersonName)
                .HasMaxLength(50);

            this.Property(t => t.ContactPersonMobileNo)
                .HasMaxLength(50);

            this.Property(t => t.ContactPersonEmailId)
                .HasMaxLength(50);

            this.Property(t => t.SuperUserLoginId)
                .HasMaxLength(50);

            this.Property(t => t.SuperUserLoginPassword)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("BuyerMaster");
            this.Property(t => t.BuyerId).HasColumnName("BuyerId");
            this.Property(t => t.SalesExecId).HasColumnName("SalesExecId");
            this.Property(t => t.BuyerCode).HasColumnName("BuyerCode");
            this.Property(t => t.BuyerName).HasColumnName("BuyerName");
            this.Property(t => t.BuyerAddress).HasColumnName("BuyerAddress");
            this.Property(t => t.BuyerBillingCityId).HasColumnName("BuyerBillingCityId");
            this.Property(t => t.BuyerDeliveryAddress).HasColumnName("BuyerDeliveryAddress");
            this.Property(t => t.BuyerDeliveryCityId).HasColumnName("BuyerDeliveryCityId");
            this.Property(t => t.BuyerBillingPinCode).HasColumnName("BuyerBillingPinCode");
            this.Property(t => t.BuyerDeliveryPinCode).HasColumnName("BuyerDeliveryPinCode");
            this.Property(t => t.BuyerMobileNo).HasColumnName("BuyerMobileNo");
            this.Property(t => t.BuyerPhoneNo).HasColumnName("BuyerPhoneNo");
            this.Property(t => t.BuyerFaxNo).HasColumnName("BuyerFaxNo");
            this.Property(t => t.BuyerEmailId).HasColumnName("BuyerEmailId");
            this.Property(t => t.BuyerWebSite).HasColumnName("BuyerWebSite");
            this.Property(t => t.BuyerTINNo).HasColumnName("BuyerTINNo");
            this.Property(t => t.BuyerPANNo).HasColumnName("BuyerPANNo");
            this.Property(t => t.BuyerCSTNo).HasColumnName("BuyerCSTNo");
            this.Property(t => t.BuyerLSTNo).HasColumnName("BuyerLSTNo");
            this.Property(t => t.BuyerGSTNo).HasColumnName("BuyerGSTNo");
            this.Property(t => t.BuyerServiceTaxNo).HasColumnName("BuyerServiceTaxNo");
            this.Property(t => t.ECCCode).HasColumnName("ECCCode");
            this.Property(t => t.Range).HasColumnName("Range");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.Commissionarate).HasColumnName("Commissionarate");
            this.Property(t => t.ContactPersonName).HasColumnName("ContactPersonName");
            this.Property(t => t.ContactPersonMobileNo).HasColumnName("ContactPersonMobileNo");
            this.Property(t => t.ContactPersonEmailId).HasColumnName("ContactPersonEmailId");
            this.Property(t => t.SuperUserLoginId).HasColumnName("SuperUserLoginId");
            this.Property(t => t.SuperUserLoginPassword).HasColumnName("SuperUserLoginPassword");
            this.Property(t => t.SalesTaxFormId).HasColumnName("SalesTaxFormId");
            this.Property(t => t.RoadPermitNoReq).HasColumnName("RoadPermitNoReq");
            this.Property(t => t.TaxType).HasColumnName("TaxType");
            this.Property(t => t.TaxPerc).HasColumnName("TaxPerc");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
