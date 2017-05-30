namespace QLXayDungWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ChamCongs = new HashSet<ChamCong>();
        }

        [Key]
        public int IdNV { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "ntext")]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string CMT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string QueQuan { get; set; }

        [Column(TypeName = "ntext")]
        public string AnhNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Column(TypeName = "ntext")]
        public string TrinhDo { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBatDauHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThucHD { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public int IdPB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }

        public virtual PhongBan PhongBan { get; set; }
    }
}
