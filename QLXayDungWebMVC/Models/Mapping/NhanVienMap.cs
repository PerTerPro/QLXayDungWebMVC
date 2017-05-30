using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QLXayDungWebMVC.Models.Mapping
{
    public class NhanVienMap : EntityTypeConfiguration<NhanVien>
    {
        public NhanVienMap()
        {
            // Primary Key
            this.HasKey(t => t.IdNV);

            // Properties
            this.Property(t => t.HoTen)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DienThoai)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CMT)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.QueQuan)
                .IsRequired();

            this.Property(t => t.AnhNV)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("NhanVien");
            this.Property(t => t.IdNV).HasColumnName("IdNV");
            this.Property(t => t.HoTen).HasColumnName("HoTen");
            this.Property(t => t.DiaChi).HasColumnName("DiaChi");
            this.Property(t => t.DienThoai).HasColumnName("DienThoai");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.CMT).HasColumnName("CMT");
            this.Property(t => t.QueQuan).HasColumnName("QueQuan");
            this.Property(t => t.AnhNV).HasColumnName("AnhNV");
            this.Property(t => t.NgaySinh).HasColumnName("NgaySinh");
            this.Property(t => t.NgayBatDauHD).HasColumnName("NgayBatDauHD");
            this.Property(t => t.NgayKetThucHD).HasColumnName("NgayKetThucHD");
            this.Property(t => t.MoTa).HasColumnName("MoTa");
            this.Property(t => t.IdPB).HasColumnName("IdPB");

            // Relationships
            this.HasRequired(t => t.PhongBan)
                .WithMany(t => t.NhanViens)
                .HasForeignKey(d => d.IdPB);

        }
    }
}
