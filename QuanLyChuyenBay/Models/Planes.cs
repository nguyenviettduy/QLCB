using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace QuanLyChuyenBay.Models
{
    public class Planes
    {
        [Required]
        [Display(Name = "Number Plane")]
        public string SoHieu { get; set; }

        [Required]
        [Display(Name = "ID Planes Type")]
        public string MaloaiMB { get; set; }

    }

    public class ManagerPlanes
    {
        DBConnection db;
        public ManagerPlanes()
        {
            db = new DBConnection();
        }

        public List<Planes> GetPlanes(string soHieu)
        {
            string query;
            if (string.IsNullOrEmpty(soHieu))
                query = string.Format("SELECT * FROM maybay");
            else
                query = string.Format("SELECT mb.*, lmb.hangSX FROM maybay mb INNER JOIN loaiMB lmb ON mb.maLoaiMB = lmb.maLoaiMB WHERE soHieu = '{0}'", soHieu);

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

            List<Planes> listPlanes = new List<Planes>();
            Planes planes;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                planes = new Planes();
                planes.SoHieu = dt.Rows[i]["soHieu"].ToString();
                planes.MaloaiMB = dt.Rows[i]["maLoaiMB"].ToString();
                listPlanes.Add(planes);
            }
            return listPlanes;
        }

        public void AddPlanes(Planes planes)
        {
            string query = string.Format("INSERT INTO maybay(soHieu, maLoaiMB) " +
                "VALUES('{0}', '{1}')", planes.SoHieu, planes.MaloaiMB);

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

        public void DeletePlanes(Planes planes)
        {
            string query = string.Format("DELETE FROM maybay WHERE soHieu = '{0}'", planes.SoHieu);

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


    }
}