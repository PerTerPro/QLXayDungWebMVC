using QLXayDungWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXayDungWebMVC.ViewModel
{
    public class NhanVienViewModel
    {
        public int SelectedNhanVien { get; set; }

        public List<NhanVien> ListNhanVien { get; set; }
    }
}