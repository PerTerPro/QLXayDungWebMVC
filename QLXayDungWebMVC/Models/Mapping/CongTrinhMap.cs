using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QLXayDungWebMVC.Models.Mapping
{
    public class CongTrinhMap : EntityTypeConfiguration<CongTrinh>
    {
        public CongTrinhMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCT);

            // Properties
            this.Property(t => t.TenCT)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("CongTrinh");
            this.Property(t => t.IdCT).HasColumnName("IdCT");
            this.Property(t => t.TenCT).HasColumnName("TenCT");
            this.Property(t => t.NgayCapPhep).HasColumnName("NgayCapPhep");
            this.Property(t => t.NgayBatDau).HasColumnName("NgayBatDau");
            this.Property(t => t.NgayKetThuc).HasColumnName("NgayKetThuc");
        }
    }
}
