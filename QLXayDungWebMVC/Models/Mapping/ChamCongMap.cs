using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QLXayDungWebMVC.Models.Mapping
{
    public class ChamCongMap : EntityTypeConfiguration<ChamCong>
    {
        public ChamCongMap()
        {
            // Primary Key
            this.HasKey(t => t.IdChamCong);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChamCong");
            this.Property(t => t.IdChamCong).HasColumnName("IdChamCong");
            this.Property(t => t.IdCT).HasColumnName("IdCT");
            this.Property(t => t.IdNV).HasColumnName("IdNV");
            this.Property(t => t.NgayCong).HasColumnName("NgayCong");
            this.Property(t => t.NgayBatDau).HasColumnName("NgayBatDau");
            this.Property(t => t.NgayKetThuc).HasColumnName("NgayKetThuc");

            // Relationships
            this.HasRequired(t => t.CongTrinh)
                .WithMany(t => t.ChamCongs)
                .HasForeignKey(d => d.IdCT);
            this.HasRequired(t => t.NhanVien)
                .WithMany(t => t.ChamCongs)
                .HasForeignKey(d => d.IdNV);

        }
    }
}
