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
    public class ChamCongRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCTXayDungConText"].ConnectionString);
        
        public IEnumerable<ChamCong> GetChamCong()
        {
            IEnumerable<ChamCong> ChamCong = this.db.Query<ChamCong>("SELECT * FROM ChamCong").ToList();
            return ChamCong;
        }

        public ChamCong CreateChamCong(ChamCong ChamCong)
        {
            string query = "INSERT INTO ChamCong VALUES(@IdCT, @IdNV, @NgayCong, @NgayBatDau, @NgayKetThuc, @TinhTrang, @NgayXoa)";
            db.Execute(query, ChamCong);
            return ChamCong;
        }

        public ChamCong UpdateChamCong(ChamCong ChamCong)
        {
            string query = "UPDATE ChamCong " +
                            "SET IdCT = @IdCT, " +
                            "IdNV = @IdNV, " +
                                "NgayCong = @NgayCong, " +
                                "NgayBatDau = @NgayBatDau, " +
                                "NgayKetThuc = @NgayKetThuc " +
                                "TinhTrang = @TinhTrang " +
                                "NgayXoa = @NgayXoa " +
                            "WHERE IdChamCong = @IdChamCong";
            db.Execute(query, ChamCong);
            return ChamCong;
        }


        //Xóa hẳn
        public void DeleteChamCong(int IdCC)
        {
            string query = "DELETE FROM ChamCong WHERE IdChamCong = " + IdCC;
            db.Execute(query);
        }

        public ChamCong GetChamCongByID(int IdCC)
        {
            string query = "SELECT * FROM ChamCong WHERE IdChamCong = " + IdCC;
            ChamCong ChamCong = db.Query<ChamCong>(query).SingleOrDefault();
            return ChamCong;
        }

        public IEnumerable<ChamCong> GetChamCongByIdCT(int IdCT)
        {
            string query = "SELECT * FROM ChamCong WHERE ChamCong.IdCT = " + IdCT;
            IEnumerable<ChamCong> ChamCong = db.Query<ChamCong>(query).ToList();
            return ChamCong;
        }

        public IEnumerable<ChamCong> GetChamCongByIdNV(int IdNV)
        {
            string query = "SELECT * FROM ChamCong WHERE ChamCong.IdNV = " + IdNV;
            IEnumerable<ChamCong> ChamCong = db.Query<ChamCong>(query).ToList();
            return ChamCong;
        }
        public IEnumerable<ChamCong> GetChamCongBy2Id(int IdCT, int IdNV)
        {
            string query = "SELECT * FROM ChamCong WHERE ChamCong.IdCT = " + IdCT + " AND ChamCong.IdNV = " + IdNV;
            IEnumerable<ChamCong> ChamCong = db.Query<ChamCong>(query).ToList();
            return ChamCong;
        }


        //Change Tình Trạng Nhân sự
        public bool ChangeTinhTrang(int IdChamCong, int TinhTrang, string NgayXoa)
        {
            bool status = false;
            string query = "UPDATE ChamCong " +
                            "SET TinhTrang = " + TinhTrang +" ,NgayXoa = '" + NgayXoa + "'" + " WHERE IdChamCong = " + IdChamCong;
            db.Execute(query);
            return status = true;
        }


    }
}