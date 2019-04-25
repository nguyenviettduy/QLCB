using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyChuyenBay.Models
{
    public class DBConnection
    {
        string connection;
        public DBConnection()
        {
            connection = System.Configuration.ConfigurationManager.ConnectionStrings["QLCB"].ConnectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connection);
        } 

    }
}