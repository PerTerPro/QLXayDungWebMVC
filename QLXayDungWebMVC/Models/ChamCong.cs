namespace QLXayDungWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChamCong()
        {
            ChiTietNgayCongs = new HashSet<ChiTietNgayCong>();
        }

        [Key]
        public int IdChamCong { get; set; }

        public int IdCT { get; set; }

        public int IdNV { get; set; }

        public int NgayCong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        public int TinhTrang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXoa { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNgayCong> ChiTietNgayCongs { get; set; }

        public virtual CongTrinh CongTrinh { get; set; }
    }
}
