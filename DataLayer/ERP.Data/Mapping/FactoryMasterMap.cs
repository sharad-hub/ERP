using ERP.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ERP.Data.Models.Mapping
{
    public class FactoryMasterMap : EntityTypeConfiguration<Factory>
    {
        public FactoryMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.FactoryId);

            // Properties
            this.Property(t => t.FactoryName)
                .HasMaxLength(50);

            this.Property(t => t.FactoryAddress)
                .HasMaxLength(500);

            this.Property(t => t.FactoryPinCode)
                .HasMaxLength(10);

            this.Property(t => t.FactoryMobileNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryPhoneNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryFaxNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryEmailId)
                .HasMaxLength(50);

            this.Property(t => t.FactoryWebSite)
                .HasMaxLength(100);

            this.Property(t => t.FactoryTINNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryPANNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryCSTNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryLSTNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryGSTNo)
                .HasMaxLength(50);

            this.Property(t => t.FactoryServiceTaxNo)
                .HasMaxLength(50);

            this.Property(t => t.ECCCode)
                .HasMaxLength(50);

            this.Property(t => t.Range)
                .HasMaxLength(50);

            this.Property(t => t.Division)
                .HasMaxLength(50);

            this.Property(t => t.Commissionarate)
                .HasMaxLength(50);

            this.Property(t => t.SuperUserLoginId)
                .HasMaxLength(50);

            this.Property(t => t.SuperUserLoginPassword)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FactoryMaster");
            this.Property(t => t.FactoryId).HasColumnName("FactoryId");
            this.Property(t => t.FactoryCode).HasColumnName("FactoryCode");
            this.Property(t => t.FactoryName).HasColumnName("FactoryName");
            this.Property(t => t.FactoryAddress).HasColumnName("FactoryAddress");
            this.Property(t => t.FactoryCityId).HasColumnName("FactoryCityId");
            this.Property(t => t.FactoryPinCode).HasColumnName("FactoryPinCode");
            this.Property(t => t.FactoryMobileNo).HasColumnName("FactoryMobileNo");
            this.Property(t => t.FactoryPhoneNo).HasColumnName("FactoryPhoneNo");
            this.Property(t => t.FactoryFaxNo).HasColumnName("FactoryFaxNo");
            this.Property(t => t.FactoryEmailId).HasColumnName("FactoryEmailId");
            this.Property(t => t.FactoryWebSite).HasColumnName("FactoryWebSite");
            this.Property(t => t.FactoryTINNo).HasColumnName("FactoryTINNo");
            this.Property(t => t.FactoryPANNo).HasColumnName("FactoryPANNo");
            this.Property(t => t.FactoryCSTNo).HasColumnName("FactoryCSTNo");
            this.Property(t => t.FactoryLSTNo).HasColumnName("FactoryLSTNo");
            this.Property(t => t.FactoryGSTNo).HasColumnName("FactoryGSTNo");
            this.Property(t => t.FactoryServiceTaxNo).HasColumnName("FactoryServiceTaxNo");
            this.Property(t => t.ECCCode).HasColumnName("ECCCode");
            this.Property(t => t.Range).HasColumnName("Range");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.Commissionarate).HasColumnName("Commissionarate");
            this.Property(t => t.SuperUserLoginId).HasColumnName("SuperUserLoginId");
            this.Property(t => t.SuperUserLoginPassword).HasColumnName("SuperUserLoginPassword");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
