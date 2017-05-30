using QLXayDungWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Web.Mvc;

namespace QLXayDungWebMVC.Dapper
{
    public class CongTrinhRepo
    {

        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCTXayDungConText"].ConnectionString);


        public IEnumerable<CongTrinh> GetCongTrinh()
        {
            IEnumerable<CongTrinh> CongTrinh = this.db.Query<CongTrinh>("SELECT * FROM CongTrinh").ToList();
            return CongTrinh;
        }

        public bool CreateCongTrinh(CongTrinh CongTrinh)
        {
            bool status = false;
            string query = "INSERT INTO CongTrinh VALUES(@TenCT, @MoTaCT, @Image, @NgayCapPhep, @NgayBatDau, @NgayKetThuc)";
            db.Execute(query, CongTrinh);
            return status = false;
        }

        public bool UpdateCongTrinh(CongTrinh CongTrinh)
        {
            bool status = false;
            string query = "UPDATE CongTrinh " +
                            "SET TenCT = @TenCT, " +
                                "MoTaCT = @MoTaCT, " +
                                "Image = @Image, " +
                                "NgayCapPhep = @NgayCapPhep, " +
                                "NgayBatDau = @NgayBatDau, " +
                                "NgayKetThuc = @NgayKetThuc " +
                            "WHERE IdCT = @IdCT";
            db.Execute(query, CongTrinh);
            return status = true;
        }

        public bool DeleteCongTrinh(int IdCT)
        {
            bool status = false;
            string query = "DELETE FROM CongTrinh WHERE IdCT = " + IdCT;
            db.Execute(query);
            return status = true;
        }

        public CongTrinh GetCongTrinhByID(int IdCT)
        {
            string query = "SELECT * FROM CongTrinh WHERE IdCT = " + IdCT;
            CongTrinh CongTrinh = db.Query<CongTrinh>(query).SingleOrDefault();
            return CongTrinh;
        }

        public IEnumerable<CongTrinh> GetCongTrinhDangThiCong(string DateNow)
        {
            string query = "SELECT * FROM CongTrinh WHERE '" + DateNow + "' BETWEEN NgayBatDau AND NgayKetThuc";
            IEnumerable<CongTrinh> CongTrinh = db.Query<CongTrinh>(query).ToList();
            return CongTrinh;

        }

        public IEnumerable<CongTrinh> GetCongTrinhChuaThiCong(string DateNow)
        {
            string query = "SELECT * FROM CongTrinh WHERE NgayBatDau > '" + DateNow + "'";
            IEnumerable<CongTrinh> CongTrinh = db.Query<CongTrinh>(query).ToList();
            return CongTrinh;
        }

        public IEnumerable<CongTrinh> GetCongTrinhDaKetThuc(string DateNow)
        {
            string query = "SELECT * FROM CongTrinh WHERE NgayKetThuc < '" + DateNow + "'";
            IEnumerable<CongTrinh> CongTrinh = db.Query<CongTrinh>(query).ToList();
            return CongTrinh;
        }

    }
}