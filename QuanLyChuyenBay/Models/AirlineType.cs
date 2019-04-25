using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace QuanLyChuyenBay.Models
{
    public class AirlineType
    {
        [Required]
        [Display(Name = "ID Planes Type")]
        public string MaLoaiMB { get; set; }
        [Required]
        [Display(Name = "Maker")]
        public string HangSX { get; set; }
    }

    public class ManagerAirlineType
    {
        DBConnection db;
        public ManagerAirlineType()
        {
            db = new DBConnection();
        }

        public List<AirlineType> GetAirlineType(string maLoaiMB)
        {
            string query;
            if (string.IsNullOrEmpty(maLoaiMB))
                query = string.Format("SELECT * FROM loaiMB");
            else
                query = string.Format("SELECT * FROM loaiMB WHERE maLoaiMB = '{0}'", maLoaiMB);

            MySqlConnection conn = db.GetConnection();
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
                da.Dispose();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            List<AirlineType> listAT = new List<AirlineType>();
            AirlineType airlineType;

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                airlineType = new AirlineType();
                airlineType.MaLoaiMB = dt.Rows[i]["maLoaiMB"].ToString();
                airlineType.HangSX = dt.Rows[i]["hangSX"].ToString();
                listAT.Add(airlineType);
            }

            return listAT;
        }

        public void AddAirlineType(AirlineType airlineType)
        {
            string query = string.Format("INSERT INTO loaiMB(maLoaiMB, hangSX)" +
                "VALUES('{0}', '{1}')", airlineType.MaLoaiMB, airlineType.HangSX);

            MySqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public void DeleteAirlineType(AirlineType airlineType)
        {
            string query = string.Format("DELETE FROM loaiMb WHERE maLoaiMB = '{0}'", airlineType.MaLoaiMB);

            MySqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        //public void UpdateAirlineType(AirlineType airlineType)
        //{
        //    string query = string.Format("UPDATE loaiMB SET maLoaiMB = '{0}', hangSX = '{1}', WHERE maLoaiMB = '{2}'",
        //        airlineType.MaLoaiMB, airlineType.HangSX, airlineType.MaLoaiMB);
        //    MySqlConnection conn = db.GetConnection();
        //    try
        //    {
        //        conn.Open();

        //        MySqlCommand cmd = new MySqlCommand(query, conn);

        //        cmd.ExecuteNonQuery();

        //        cmd.Dispose();

        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
}