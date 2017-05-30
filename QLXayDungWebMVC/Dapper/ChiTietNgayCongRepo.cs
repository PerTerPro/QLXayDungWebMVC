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
    public class ChiTietNgayCongRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCTXayDungConText"].ConnectionString);


        public IEnumerable<ChiTietNgayCong> GetChiTietNgayCong()
        {
            IEnumerable<ChiTietNgayCong> ChiTietNgayCong = this.db.Query<ChiTietNgayCong>("SELECT * FROM ChiTietNgayCong").ToList();
            return ChiTietNgayCong;
        }

        public ChiTietNgayCong CreateChiTietNgayCong(ChiTietNgayCong ChiTietNgayCong)
        {
            string query = "INSERT INTO ChiTietNgayCong VALUES(@IdChamCong, @NgayLam, @DiLam, @LyDo)";
            db.Execute(query, ChiTietNgayCong);
            return ChiTietNgayCong;
        }

        public ChiTietNgayCong UpdateChiTietNgayCong(ChiTietNgayCong ChiTietNgayCong)
        {
            string query = "UPDATE ChiTietNgayCong " +
                            "SET NgayLam = @NgayLam, " +
                                "DiLam = @DiLam, " +
                                "LyDo = @LyDo " +
                            "WHERE IdChamCong = @IdChamCong";
            db.Execute(query, ChiTietNgayCong);
            return ChiTietNgayCong;
        }

        public void DeleteChiTietNgayCong(int IdCC)
        {
            string query = "DELETE FROM ChiTietNgayCong WHERE IdChamCong = " + IdCC;
            db.Execute(query);
        }

        public IEnumerable<ChiTietNgayCong> GetChiTietNgayCongByID(int IdCC)
        {
            string query = "SELECT * FROM ChiTietNgayCong WHERE IdChamCong = " + IdCC;
            IEnumerable<ChiTietNgayCong> ChiTietNgayCong = db.Query<ChiTietNgayCong>(query).ToList();
            return ChiTietNgayCong;
        }

        public IEnumerable<ChiTietNgayCong> GetChiTietNgayCongByID_Date(int IdCC, string NgayLam)
        {
            string query = "SELECT * FROM ChiTietNgayCong WHERE IdChamCong = " + IdCC + " AND NgayLam = '" + NgayLam + "'";
            IEnumerable<ChiTietNgayCong> ChiTietNgayCong = db.Query<ChiTietNgayCong>(query).ToList();
            return ChiTietNgayCong;
        }

        //public IEnumerable<ChiTietNgayCong> GetChiTietNgayCongBy2Id(int IdCT,int IdNV)
        //{
        //    Dapper.ChamCongRepo chamcong = new ChamCongRepo();
        //    int IdChamCong = chamcong.GetChamCongBy2Id(IdCT, IdNV).IdChamCong;
        //    //string query = "SELECT * FROM ChiTietNgayCong WHERE IdChamCong = " + IdChamCong;
        //    //IEnumerable<ChiTietNgayCong> chitietngaycong = db.Query<ChiTietNgayCong>(query).ToList();
        //    //return chitietngaycong;
        //    return GetChiTietNgayCongByID(IdChamCong);
        //}


    }
}