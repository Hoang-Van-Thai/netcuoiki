using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Controller
{
    internal class ChiTietPhieuXuatController:IController
    {
        private List<IModel> _items;
        private readonly string _connectionString = "Data Source=DESKTOP-HGI7VB9\\SQLEXPRESS;Initial Catalog=QuanLyBanHangNet;User ID=thai;Password=thai;";

        public ChiTietPhieuXuatController()
        {
            _items = new List<IModel>();
        }

        public List<IModel> Items => _items;

        // Tạo mới chi tiết phiếu xuất
        public bool Create(IModel model)
        {
            try
            {
                if (model is ChiTietPhieuXuatModel chiTietPhieuXuat)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO CHITIETPHIEUXUAT (maPhieuXuat, maHangHoa, soLuongXuat, giaXuat) VALUES (@maPhieuXuat, @maHangHoa, @soLuongXuat, @giaXuat)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maPhieuXuat", chiTietPhieuXuat.MaPhieuXuat);
                            command.Parameters.AddWithValue("@maHangHoa", chiTietPhieuXuat.MaHangHoa);
                            command.Parameters.AddWithValue("@soLuongXuat", chiTietPhieuXuat.SoLuongXuat);
                            command.Parameters.AddWithValue("@giaXuat", chiTietPhieuXuat.GiaXuat ?? (object)DBNull.Value);

                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo chi tiết phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật chi tiết phiếu xuất
        public bool Update(IModel model)
        {
            try
            {
                if (model is ChiTietPhieuXuatModel chiTietPhieuXuat)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE CHITIETPHIEUXUAT SET maPhieuXuat = @maPhieuXuat, maHangHoa = @maHangHoa, soLuongXuat = @soLuongXuat, giaXuat = @giaXuat WHERE IDPX = @IDPX";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDPX", chiTietPhieuXuat.IDPX);
                            command.Parameters.AddWithValue("@maPhieuXuat", chiTietPhieuXuat.MaPhieuXuat);
                            command.Parameters.AddWithValue("@maHangHoa", chiTietPhieuXuat.MaHangHoa);
                            command.Parameters.AddWithValue("@soLuongXuat", chiTietPhieuXuat.SoLuongXuat);
                            command.Parameters.AddWithValue("@giaXuat", chiTietPhieuXuat.GiaXuat ?? (object)DBNull.Value);

                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Xóa chi tiết phiếu xuất
        public bool Delete(object id)
        {
            try
            {
                if (id is int idPx)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM CHITIETPHIEUXUAT WHERE IDPX = @IDPX";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDPX", idPx);
                            int rowsAffected = command.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Đọc thông tin chi tiết phiếu xuất theo mã
        public IModel Read(object id)
        {
            try
            {
                if (id is int idPx)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "SELECT IDPX, maPhieuXuat, maHangHoa, soLuongXuat, giaXuat FROM CHITIETPHIEUXUAT WHERE IDPX = @IDPX";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDPX", idPx);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new ChiTietPhieuXuatModel
                                    {
                                        IDPX = reader.GetInt32(0),
                                        MaPhieuXuat = reader.GetInt32(1),
                                        MaHangHoa = reader.GetInt32(2),
                                        SoLuongXuat = reader.GetInt32(3),
                                        GiaXuat = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4)
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
                MessageBox.Show("Lỗi khi đọc thông tin chi tiết phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Tải tất cả chi tiết phiếu xuất
        public bool Load()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT IDPX, maPhieuXuat, maHangHoa, soLuongXuat, giaXuat FROM CHITIETPHIEUXUAT";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            _items.Clear();
                            while (reader.Read())
                            {
                                _items.Add(new ChiTietPhieuXuatModel
                                {
                                    IDPX = reader.GetInt32(0),
                                    MaPhieuXuat = reader.GetInt32(1),
                                    MaHangHoa = reader.GetInt32(2),
                                    SoLuongXuat = reader.GetInt32(3),
                                    GiaXuat = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4)
                                });
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chi tiết phiếu xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Load(object id)
        {
            return Read(id) != null;
        }

        // Kiểm tra chi tiết phiếu xuất có tồn tại hay không dựa trên mã
        public bool IsExist(object id)
        {
            try
            {
                if (id is int idPx)
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "SELECT COUNT(1) FROM CHITIETPHIEUXUAT WHERE IDPX = @IDPX";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@IDPX", idPx);
                            return (int)command.ExecuteScalar() > 0;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra chi tiết phiếu xuất tồn tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool IsExist(IModel model)
        {
            if (model is ChiTietPhieuXuatModel chiTietPhieuXuat)
            {
                return IsExist(chiTietPhieuXuat.IDPX);
            }
            return false;
        }
        public bool IsValid(IModel model)
        {
            try
            {
                // Kiểm tra nếu model là ChiTietPhieuXuatModel
                if (model is ChiTietPhieuXuatModel chiTietPhieuXuat)
                {
                   
                    if (chiTietPhieuXuat.MaPhieuXuat > 0 &&
                        chiTietPhieuXuat.MaHangHoa > 0 &&
                        chiTietPhieuXuat.SoLuongXuat > 0 &&
                        (chiTietPhieuXuat.GiaXuat == null || chiTietPhieuXuat.GiaXuat >= 0))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu chi tiết phiếu xuất không hợp lệ: MaPhieuXuat và MaHangHoa phải lớn hơn 0, SoLuongXuat phải lớn hơn 0, và GiaXuat phải không nhỏ hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Đối tượng không phải là ChiTietPhieuXuatModel.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "SELECT ISNULL(MAX(IDPX), 0) + 1 FROM CHITIETPHIEUXUAT";
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
