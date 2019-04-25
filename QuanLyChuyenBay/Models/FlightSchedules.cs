using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace QuanLyChuyenBay.Models
{
    public class FlightSchedules
    {
        [Required]
        [Display(Name = "Departure Date")]
        public DateTime NgayDi { get; set; }

        [Required]
        [Display(Name = "ID Airline")]
        public string MaChuyenBay { get; set; }

        [Required]
        [Display(Name = "Number")]
        public string SoHieu { get; set; }

        [Required]
        [Display(Name = "Code Type")]
        public string MaLoai { get; set; }

    }

    public class InfoFlightSchedules
    {
        DBConnection db;
        public InfoFlightSchedules()
        {
            db = new DBConnection();
        }

        public List<FlightSchedules> GetFlightSchedules(string maChuyenBay)
        {
            string query;
            if (string.IsNullOrEmpty(maChuyenBay))
                query = string.Format("SELECT * FROM lichbay");
            else
                query = string.Format("SELECT * FROM lichbay WHERE maChuyenBay = '{0}'", maChuyenBay);

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

            List<FlightSchedules> listFS = new List<FlightSchedules>();
            FlightSchedules flightSchedules;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                flightSchedules = new FlightSchedules();
                flightSchedules.NgayDi = (DateTime)dt.Rows[i]["ngayDi"];
                flightSchedules.MaChuyenBay = dt.Rows[i]["maChuyenBay"].ToString();
                flightSchedules.SoHieu = dt.Rows[i]["soHieu"].ToString();
                flightSchedules.MaLoai = dt.Rows[i]["maLoai"].ToString();
                listFS.Add(flightSchedules);
            }

            return listFS;
        }
    }
}