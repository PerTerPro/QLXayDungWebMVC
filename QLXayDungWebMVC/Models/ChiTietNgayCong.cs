namespace QLXayDungWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNgayCong")]
    public partial class ChiTietNgayCong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdChamCong { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NgayLam { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DiLam { get; set; }

        [Column(TypeName = "ntext")]
        public string LyDo { get; set; }

        public virtual ChamCong ChamCong { get; set; }
    }
}
