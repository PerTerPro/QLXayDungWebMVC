using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using QLXayDungWebMVC.Models;

namespace QLXayDungWebMVC.Dapper
{
    public class Repo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCTXayDungConText"].ConnectionString);

        public Dapper.PhongBanRepo phongbanRP;

        public Dapper.NhanVienRepo nhanvienRP;

        public Dapper.CongTrinhRepo congtrinhRP;

        public Dapper.ChamCongRepo chamcongRP;

        public Dapper.ChiTietNgayCongRepo chitietRP;

    }
}