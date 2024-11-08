using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Controller
{
    internal class PhieuXuatController:IController
    {
        private List<IModel> _items;
        private readonly string _connectionString = "Data Source=DESKTOP-HGI7VB9\\SQLEXPRESS;Initial Catalog=QuanLyBanHangNet;User ID=thai;Password=thai;";

        public PhieuXuatController()
        {
            _items = new List<IModel>();
        }

        public List<IModel> Items => _items;

        // Tạo mới phiếu xuất
        public bool Create(IModel model)
        {
            try
            {
                if (model is PhieuXuatModel phieuXuat)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO PHIEUXUAT (maKhachHang, ngayXuat) VALUES (@maKhachHang, @ngayXuat)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maKhachHang", phieuXuat.MaKhachHang);
                            command.Parameters.AddWithValue("@ngayXuat", phieuXuat.NgayXuat ?? (object)DBNull.Value);

                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật phiếu xuất
        public bool Update(IModel model)
        {
            try
            {
                if (model is PhieuXuatModel phieuXuat)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE PHIEUXUAT SET maKhachHang = @maKhachHang, ngayXuat = @ngayXuat WHERE maPhieuXuat = @maPhieuXuat";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maPhieuXuat", phieuXuat.MaPhieuXuat);
                            command.Parameters.AddWithValue("@maKhachHang", phieuXuat.MaKhachHang);
                            command.Parameters.AddWithValue("@ngayXuat", phieuXuat.NgayXuat ?? (object)DBNull.Value);

                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Xóa phiếu xuất
        public bool Delete(object id)
        {
            try
            {
                
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM PHIEUXUAT WHERE maPhieuXuat = @maPhieuXuat";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maPhieuXuat", id);
                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Đọc thông tin phiếu xuất theo mã
        public IModel Read(object id)
        {
            try
            {
                if (id is int maPhieuXuat)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "SELECT maPhieuXuat, maKhachHang, ngayXuat FROM PHIEUXUAT WHERE maPhieuXuat = @maPhieuXuat";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new PhieuXuatModel
                                    {
                                        MaPhieuXuat = reader.GetInt32(0),
                                        MaKhachHang = reader.GetInt32(1),
                                        NgayXuat = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2)
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
                MessageBox.Show("Lỗi khi đọc thông tin phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Tải tất cả phiếu xuất
        public bool Load()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT maPhieuXuat, maKhachHang, ngayXuat FROM PHIEUXUAT";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            _items.Clear();
                            while (reader.Read())
                            {
                                _items.Add(new PhieuXuatModel
                                {
                                    MaPhieuXuat = reader.GetInt32(0),
                                    MaKhachHang = reader.GetInt32(1),
                                    NgayXuat = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2)
                                });
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Load(object id)
        {
            return Read(id) != null;
        }

        // Kiểm tra phiếu xuất có tồn tại hay không dựa trên mã
        public bool IsExist(object id)
        {
            try
            {
                if (id is int maPhieuXuat)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "SELECT COUNT(1) FROM PHIEUXUAT WHERE maPhieuXuat = @maPhieuXuat";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                            return (int)command.ExecuteScalar() > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phiếu xuất tồn tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool IsExist(IModel model)
        {
            if (model is PhieuXuatModel phieuXuat)
            {
                return IsExist(phieuXuat.MaPhieuXuat);
            }
            return false;
        }
        // Hàm kiểm tra tính hợp lệ của đối tượng
        public bool IsValid(IModel model)
        {
            try
            {
                // Kiểm tra nếu model là PhieuXuatModel
                if (model is PhieuXuatModel phieuXuat)
                {
                    // Kiểm tra các điều kiện hợp lệ (Ví dụ)
                    // maKhachHang phải có giá trị dương
                    // ngayXuat không được để trống và phải là ngày hợp lệ
                    if (phieuXuat.MaKhachHang > 0 && phieuXuat.NgayXuat != null)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Phiếu xuất không hợp lệ: MaKhachHang phải lớn hơn 0 và ngayXuat không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Đối tượng không phải là Phiếu Xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tính hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public int GetNextId()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(maPhieuXuat), 0) + 1 FROM PHIEUXUAT";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy ID lớn nhất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
    }
}
