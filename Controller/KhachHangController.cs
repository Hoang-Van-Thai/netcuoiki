using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Controller
{
    internal class KhachHangController:IController
    {
        private List<IModel> _items;
        private readonly string _connectionString = "Data Source=DESKTOP-HGI7VB9\\SQLEXPRESS;Initial Catalog=QuanLyBanHangNet;User ID=thai;Password=thai;";

        public KhachHangController()
        {
            _items = new List<IModel>();
        }

        public List<IModel> Items => _items;

        public bool Create(IModel model)
        {
            try
            {
                if (model is KhachHangModel khachHang)
                {
                    if (!IsValid(khachHang)) return false;

                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO KhachHang (TenKhachHang, DiaChi, DienThoai) VALUES (@TenKhachHang, @DiaChi, @DienThoai)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                            command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                            command.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai);

                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Update(IModel model)
        {
            try
            {
                if (model is KhachHangModel khachHang)
                {
                    if (!IsValid(khachHang)) return false;

                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKhachHang = @MaKhachHang";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
                            command.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                            command.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                            command.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai);

                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Delete(object id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM KHACHHANG WHERE maKhachHang = @maKhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maKhachHang", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public IModel Read(object id)
        {
            try
            {
                if (id is int maKhachHang)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "SELECT MaKhachHang, TenKhachHang, DiaChi, DienThoai FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new KhachHangModel
                                    {
                                        MaKhachHang = reader.GetInt32(0),
                                        TenKhachHang = reader.GetString(1),
                                        DiaChi = reader.GetString(2),
                                        DienThoai = reader.GetString(3)
                                    };
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool Load()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaKhachHang, TenKhachHang, DiaChi, DienThoai FROM KhachHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            _items.Clear();
                            while (reader.Read())
                            {
                                _items.Add(new KhachHangModel
                                {
                                    MaKhachHang = reader.GetInt32(0),
                                    TenKhachHang = reader.GetString(1),
                                    DiaChi = reader.GetString(2),
                                    DienThoai = reader.GetString(3)
                                });
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Load(object id)
        {
            return Read(id) != null;
        }

        public bool IsExist(object id)
        {
            try
            {
                if (id is int maKhachHang)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "SELECT COUNT(1) FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                            return (int)command.ExecuteScalar() > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra khách hàng tồn tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool IsExist(IModel model)
        {
            if (model is KhachHangModel khachHang)
            {
                return IsExist(khachHang.MaKhachHang);
            }
            return false;
        }
        public bool IsValid(KhachHangModel khachHang)
        {
            if (khachHang == null)
            {
                MessageBox.Show("Đối tượng khách hàng không được null.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(khachHang.TenKhachHang))
            {
                MessageBox.Show("Tên khách hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(khachHang.DiaChi))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(khachHang.DienThoai))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!long.TryParse(khachHang.DienThoai, out _))
            {
                MessageBox.Show("Số điện thoại phải là một chuỗi số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public bool IsValue(string columnName, object value)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = $"SELECT COUNT(1) FROM KhachHang WHERE {columnName} = @value";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@value", value);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

