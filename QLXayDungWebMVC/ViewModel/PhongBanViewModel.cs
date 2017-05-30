using QLXayDungWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLXayDungWebMVC.ViewModel
{
    public class PhongBanViewModel
    {
        public int SelectedPhongBan { get; set; }

        public List<PhongBan> ListPhongBan { get; set; }
    }
}