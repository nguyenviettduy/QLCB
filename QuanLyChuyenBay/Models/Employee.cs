using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace QuanLyChuyenBay.Models
{
    public class Employee
    {
        [Display(Name = "ID Employee")]
        public int MaNV { get; set; }
        [Display(Name = "Name Employee")]
        [Required]
        public string Ten { get; set; }

        [Display(Name = "Address Employee")]
        [Required]
        public string DiaChi { get; set; }

        [Display(Name = "Phone Employee")]
        [Required]
        public string DienThoai { get; set; }
        [Display(Name = "Salary Employee")]
        [Required]
        public float Luong { get; set; }
        [Display(Name = "Type Employee")]
        [Required]
        public string LoaiNV { get; set; }
    }

    public class InfoEmployee
    {
        DBConnection db;
        public InfoEmployee()
        {
            db = new DBConnection();
        }

        public List<Employee> GetEmployee(string maNV)
        {
            string query;
            if (string.IsNullOrEmpty(maNV))

                query = string.Format("SELECT * FROM nhanvien");
            else
                query = string.Format("SELECT * FROM nhanvien WHERE maNV = '{0}'", maNV);

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
            List<Employee> listEmp = new List<Employee>();
            Employee employee;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                employee = new Employee();
                employee.MaNV = Convert.ToInt32(dt.Rows[i]["maNV"].ToString());
                employee.Ten = dt.Rows[i]["ten"].ToString();
                employee.DiaChi = dt.Rows[i]["diaChi"].ToString();
                employee.DienThoai = dt.Rows[i]["dienThoai"].ToString();
                employee.Luong = (float)dt.Rows[i]["luong"];
                employee.LoaiNV = dt.Rows[i]["loaiNV"].ToString();
                listEmp.Add(employee);
            }

            return listEmp;
        }

        public void AddEmployee(Employee employee)
        {
            string query = string.Format("INSERT INTO nhanvien(ten, diaChi, dienThoai, luong, loaiNV)" +
                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", employee.Ten, employee.DiaChi, employee.DienThoai, employee.Luong, employee.LoaiNV);

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

        public void DeleteEmployee(Employee employee)
        {
            string query = string.Format("DELETE FROM nhanvien WHERE maNV = '{0}'", employee.MaNV);

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

        public void UpdateEmployee(Employee employee)
        {
            string query = string.Format("UPDATE nhanvien SET ten = '{0}', diaChi = '{1}', dienThoai = '{2}', luong = '{3}', loaiNV = '{4}' WHERE maNV = '{5}' ",
                employee.Ten, employee.DiaChi, employee.DienThoai, employee.Luong, employee.LoaiNV, employee.MaNV);
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