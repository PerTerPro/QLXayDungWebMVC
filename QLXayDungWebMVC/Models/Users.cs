using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace QLXayDungWebMVC.Models
{
    [Table("Users")]
    public partial class Users
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Username không được để trống!")]
        //[Remote("CheckUserName", "Users")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password không được để trống!")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng điền tên!")]
        [StringLength(50)]
        public string Name { get; set; }

        //[Remote("CheckActive", "Users")]
        public int Active { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng chọn ngày tạo!")]
        public System.DateTime NgayTao { get; set; }
    }
}
