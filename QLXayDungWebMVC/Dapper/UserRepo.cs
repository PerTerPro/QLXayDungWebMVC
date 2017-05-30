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
    public class UserRepo
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCTXayDungConText"].ConnectionString);


        public IEnumerable<User> GetUser()
        {
            IEnumerable<User> User = this.db.Query<User>("SELECT * FROM Users").ToList();
            return User;
        }

        public bool CreateUser(User User)
        {
            bool status = false;
            string query = "INSERT INTO Users VALUES(@Username, @Password, @Name, @Active, @Image, @NgayTao)";
            db.Execute(query, User);
            return status = true;
        }

        public bool UpdateUser(User User)
        {
            bool status = false;
            string query = "UPDATE Users " +
                            "SET Username = @Username, " +
                                "Password = @Password, " +
                                "Name = @Name, " +
                                "Active = @Active, " +
                                "Image = @NgayTao, " +
                            "WHERE ID = @ID";
            db.Execute(query, User);
            return status = true;
        }

        public bool DeleteUser(int ID)
        {
            bool status = false;
            try
            {
                string query = "DELETE FROM Users WHERE ID = " + ID;
                db.Execute(query);
            }
            catch (Exception ex)
            {
                throw;
            }
            return status = true;
        }

        public bool XetDuyetUser(int ID)
        {
            bool status = false;
            string query = "UPDATE Users " +
                            "SET Active = 0 WHERE ID = " + ID;
            db.Execute(query);
            return status = true;
        }

        public User GetUserByID(int? ID)
        {
            string query = "SELECT * FROM Users WHERE ID = " + ID;
            User User = db.Query<User>(query).SingleOrDefault();
            return User;
        }

        public IEnumerable<User> GetUserByUsername(string Username)
        {
            string query = "SELECT * FROM Users WHERE Username = '" + Username + "'";
            IEnumerable<User> User = db.Query<User>(query).ToList();
            return User;
        }

        public IEnumerable<User> GetUserByActive(int Active)
        {
            string query = "SELECT * FROM Users WHERE Active = " + Active;
            IEnumerable<User> User = db.Query<User>(query).ToList();
            return User;
        }

        public User Login(string Username , string Password)
        {
            string query = "SELECT * FROM Users WHERE Username = '" + Username + "' AND Password = '" + Password + "'";
            User User = db.Query<User>(query).SingleOrDefault();
            return User;
        }

    }
}