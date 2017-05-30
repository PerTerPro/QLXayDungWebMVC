namespace QLXayDungWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongTrinh")]
    public partial class CongTrinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongTrinh()
        {
            ChamCongs = new HashSet<ChamCong>();
        }

        [Key]
        public int IdCT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string TenCT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string MoTaCT { get; set; }

        [Column(TypeName = "ntext")]
        public string Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayCapPhep { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
    }
}
