using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Controller
{
    internal class HangHoaController:IController
    {
        private readonly string _connectionString = "Data Source=DESKTOP-HGI7VB9\\SQLEXPRESS;Initial Catalog=QuanLyBanHangNet;User ID=thai;Password=thai;";
        

        public List<IModel> Items { get; private set; }

        public HangHoaController()
        {
           
            Items = new List<IModel>();
            Load();
        }

        public bool Create(IModel model)
        {
            var hangHoa = (HangHoaModel)model;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO HANGHOA (tenHangHoa, nguonGoc, giaBan, hinhAnh) VALUES (@tenHangHoa, @nguonGoc, @giaBan, @hinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenHangHoa", hangHoa.TenHangHoa);
                cmd.Parameters.AddWithValue("@nguonGoc", hangHoa.NguonGoc);
                cmd.Parameters.AddWithValue("@giaBan", hangHoa.GiaBan);
                cmd.Parameters.AddWithValue("@hinhAnh", hangHoa.HinhAnh);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(IModel model)
        {
            var hangHoa = (HangHoaModel)model;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE HANGHOA SET tenHangHoa = @tenHangHoa, nguonGoc = @nguonGoc, giaBan = @giaBan, hinhAnh = @hinhAnh WHERE maHangHoa = @maHangHoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHangHoa", hangHoa.MaHangHoa);
                cmd.Parameters.AddWithValue("@tenHangHoa", hangHoa.TenHangHoa);
                cmd.Parameters.AddWithValue("@nguonGoc", hangHoa.NguonGoc);
                cmd.Parameters.AddWithValue("@giaBan", hangHoa.GiaBan);
                cmd.Parameters.AddWithValue("@hinhAnh", hangHoa.HinhAnh);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(object id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM HANGHOA WHERE maHangHoa = @maHangHoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHangHoa", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public IModel Read(object id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM HANGHOA WHERE maHangHoa = @maHangHoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHangHoa", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HangHoaModel
                        {
                            MaHangHoa = Convert.ToInt32(reader["maHangHoa"]),
                            TenHangHoa = reader["tenHangHoa"].ToString(),
                            NguonGoc = reader["nguonGoc"].ToString(),
                            GiaBan = (decimal)reader["giaBan"],
                            HinhAnh = reader["hinhAnh"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool Load()
        {
            Items.Clear();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM HANGHOA";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Items.Add(new HangHoaModel
                        {
                            MaHangHoa = Convert.ToInt32( reader["maHangHoa"]),
                            TenHangHoa = reader["tenHangHoa"].ToString(),
                            NguonGoc = reader["nguonGoc"].ToString(),
                            GiaBan = (decimal)reader["giaBan"],
                            HinhAnh = reader["hinhAnh"].ToString()
                        });
                    }
                }
            }
            return Items.Count > 0;
        }

        public bool Load(object id) => Read(id) != null;

        public bool IsExist(object id) => Read(id) != null;

        public bool IsExist(IModel model)
        {
            var hangHoa = (HangHoaModel)model;
            return Items.Exists(item => ((HangHoaModel)item).MaHangHoa == hangHoa.MaHangHoa);
        }
        public bool IsValue(string columnName, object value)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = $"SELECT COUNT(1) FROM HANGHOA WHERE {columnName} = @value";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@value", value);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool IsValid(IModel model)
        {
            var hangHoa = (HangHoaModel)model;

            // Kiểm tra các điều kiện hợp lệ
            if (string.IsNullOrWhiteSpace(hangHoa.TenHangHoa))
            {
                MessageBox.Show("Tên hàng hóa không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(hangHoa.NguonGoc))
            {
                MessageBox.Show("Nguồn gốc không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (hangHoa.GiaBan <= 0)
            {
                MessageBox.Show("Giá bán phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(hangHoa.HinhAnh))
            {
                MessageBox.Show("Hình ảnh không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

           
            return true;
        }
        public void UpdateImageInDatabase(string maHangHoa, string newFileName)
        {
            // Kết nối tới cơ sở dữ liệu và cập nhật tên file ảnh
            string connectionString = _connectionString; // Thay bằng chuỗi kết nối của bạn

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE HANGHOA SET hinhAnh = @HinhAnh WHERE maHangHoa = @MaHangHoa";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HinhAnh", newFileName);
                    command.Parameters.AddWithValue("@MaHangHoa", maHangHoa);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
