using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QLXayDungWebMVC.Models.Mapping
{
    public class PhongBanMap : EntityTypeConfiguration<PhongBan>
    {
        public PhongBanMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPB);

            // Properties
            this.Property(t => t.TenPB)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MoTa)
                .IsRequired();

            this.Property(t => t.DienThoai)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("PhongBan");
            this.Property(t => t.IdPB).HasColumnName("IdPB");
            this.Property(t => t.TenPB).HasColumnName("TenPB");
            this.Property(t => t.MoTa).HasColumnName("MoTa");
            this.Property(t => t.DienThoai).HasColumnName("DienThoai");
            this.Property(t => t.IdTP).HasColumnName("IdTP");
        }
    }
}
