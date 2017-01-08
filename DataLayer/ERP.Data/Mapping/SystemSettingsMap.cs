using ERP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data.Mapping
{

    public class SystemSettingsMap : EntityTypeConfiguration<SystemSetting>
    {
        public SystemSettingsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Key)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SystemSettingMaster");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
        }
    }
}
