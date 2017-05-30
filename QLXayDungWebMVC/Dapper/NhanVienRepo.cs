using QLXayDungWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace QLXayDungWebMVC.Dapper
{
    public class NhanVienRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCTXayDungConText"].ConnectionString);
        

        public IEnumerable<NhanVien> GetNhanVien()
        {
            IEnumerable<NhanVien> nhanvien = this.db.Query<NhanVien>("SELECT * FROM NhanVien").ToList();
            return nhanvien;
        }

        public bool CreateNhanVien(NhanVien nhanvien)
        {
            bool status = false;
            string query = "INSERT INTO NhanVien VALUES(@HoTen, @DiaChi, @DienThoai, @Email, @CMT, @QueQuan, @AnhNV, @NgaySinh, @TrinhDo, @NgayBatDauHD, @NgayKetThucHD, @Mota, @IdPB)";
            db.Execute(query, nhanvien);
            return status = true;
        }

        public bool UpdateNhanVien(NhanVien nhanvien)
        {
            bool status = false;
            string query = "UPDATE NhanVien " +
                            "SET HoTen = @HoTen, " +
                                "DiaChi = @DiaChi, " +
                                "DienThoai = @DienThoai, " +
                                "Email = @Email, " +
                                "CMT = @CMT, " +
                                "QueQuan = @QueQuan, " +
                                "AnhNV = @AnhNV, " +
                                "NgaySinh = @NgaySinh, " +
                                "TrinhDo = @TrinhDo, " +
                                "NgayBatDauHD = @NgayBatDauHD, " +
                                "NgayKetThucHD = @NgayKetThucHD, " +
                                "MoTa = @MoTa, " +
                                "IdPB = @IdPB " +
                            "WHERE IdNV = @IdNV";
            db.Execute(query, nhanvien);
            return status = true;
        }

        public bool DeleteNhanVien(int IdNV)
        {
            bool status = false;
            string query = "DELETE FROM NhanVien WHERE IdNV = " + IdNV;
            db.Execute(query);
            return status = true;
        }

        public NhanVien GetNhanVienByID(int IdNV)
        {
            string query = "SELECT * FROM NhanVien WHERE IdNV = " + IdNV;
            NhanVien nhanvien = db.Query<NhanVien>(query).SingleOrDefault();
            return nhanvien;
        }

        public IEnumerable<NhanVien> GetNhanVienByIdPB(int? IdPB)
        {
            IEnumerable<NhanVien> nhanvien = this.db.Query<NhanVien>("SELECT * FROM NhanVien WHERE IdPB = " + IdPB).ToList();
            return nhanvien;
        }

    }
}