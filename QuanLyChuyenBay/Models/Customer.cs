using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace QuanLyChuyenBay.Models
{
    public class Customer
    {
        [Display(Name ="ID Customer")]
        public int MaKH { get; set; }

        [Required]
        [Display(Name = "Name Customer")]
        public string Ten { get; set; }

        [Required]
        [Display(Name = "Address Customer")]
        public string DiaChi { get; set; }

        [Required]
        [Display(Name = "Phone Customer")]
        public string DienThoai { get; set; }

    }

    public class InfoCustomer
    {
        DBConnection db;
        public InfoCustomer()
        {
            db = new DBConnection();
        }

        public List<Customer> GetCustomer(string maKH)
        {
            string query;
            if (string.IsNullOrEmpty(maKH))

                query = string.Format("SELECT * FROM khachhang");
            else
                query = string.Format("SELECT * FROM khachhang WHERE maKH = '{0}'", maKH);

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
            List<Customer> listCus = new List<Customer>();
            Customer customer;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                customer = new Customer();
                customer.MaKH = Convert.ToInt32(dt.Rows[i]["maKH"].ToString());
                customer.Ten = dt.Rows[i]["ten"].ToString();
                customer.DiaChi = dt.Rows[i]["diaChi"].ToString();
                customer.DienThoai = dt.Rows[i]["dienThoai"].ToString();
                listCus.Add(customer);
            }

            return listCus;
        }

        public void AddCustomer(Customer customer)
        {
            string query = string.Format("INSERT INTO khachhang(ten, diaChi, dienThoai)" +
                "VALUES('{0}', '{1}', '{2}')", customer.Ten, customer.DiaChi, customer.DienThoai);

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

        public void DeleteCustomer(Customer customer)
        {
            string query = string.Format("DELETE FROM khachhang WHERE maKH = '{0}'", customer.MaKH);

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
      
        public void UpdateCustomer(Customer customer)
        {
            string query = string.Format("UPDATE khachhang SET ten = '{0}', diaChi = '{1}', dienThoai = '{2}' WHERE maKH = '{3}' ",
                customer.Ten, customer.DiaChi, customer.DienThoai, customer.MaKH);
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