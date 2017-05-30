using Dapper;
using QLXayDungWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLXayDungWebMVC.Dapper
{
    public class PhongBanRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCTXayDungConText"].ConnectionString);


        public IEnumerable<PhongBan> GetPhongBan()
        {
            IEnumerable<PhongBan> PhongBan = this.db.Query<PhongBan>("SELECT * FROM PhongBan").ToList();
            return PhongBan;
        }

        public bool CreatePhongBan(PhongBan PhongBan)
        {
            bool status = false;
            string query = "INSERT INTO PhongBan VALUES(@TenPB, @MoTa, @DienThoai, @IdTP)";
            db.Execute(query, PhongBan);
            return status = true;
        }

        public bool UpdatePhongBan(PhongBan PhongBan)
        {
            bool status = false;
            string query = "UPDATE PhongBan " +
                            "SET TenPB = @TenPB, " +
                                "MoTa = @MoTa, " +
                                "DienThoai = @DienThoai, " +
                                "IdTP = @IdTP "+
                            "WHERE IdPB = @IdPB";
            db.Execute(query, PhongBan);
            return status = true;
        }

        public bool DeletePhongBan(int IdPB)
        {
            bool status = false;
            string query = "DELETE FROM PhongBan WHERE IdPB = " + IdPB;
            db.Execute(query);
            return status = true;
        }

        public PhongBan GetPhongBanByID(int IdPB)
        {
            string query = "SELECT * FROM PhongBan WHERE IdPB = " + IdPB;
            PhongBan PhongBan = db.Query<PhongBan>(query).SingleOrDefault();
            return PhongBan;
        }
    }
}