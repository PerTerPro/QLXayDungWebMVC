namespace QLXayDungWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Username không được để trống !")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password không được để trống !")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "FullName không được để trống !")]
        [StringLength(50)]
        public string Name { get; set; }

        public int Active { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTao { get; set; }
    }
}
