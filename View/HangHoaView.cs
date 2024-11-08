using PhanMenBanThucPhamNongNghiep.Controller;
using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMenBanThucPhamNongNghiep.View
{
    public partial class HangHoaView : UserControl, IView
    {
        HangHoaController _controller = new HangHoaController();
        public HangHoaView()
        {
            InitializeComponent();
            LoadDataToDataGridView();
        }
        private void LoadDataToDataGridView()
        {
            // Gọi phương thức Load() để nạp dữ liệu vào Items
            if (_controller.Load())
            {
                // Đặt AutoGenerateColumns thành false để tùy chỉnh cột thủ công
                dataGridViewHangHoa.AutoGenerateColumns = false;

                // Xóa các cột cũ (nếu có)
                dataGridViewHangHoa.Columns.Clear();

                // Tạo cột tùy chỉnh cho mỗi thuộc tính
                dataGridViewHangHoa.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaHangHoa", // Tên thuộc tính trong model
                    Name = "MaHangHoa", // Tên thuộc tính trong model
                    HeaderText = "Mã Hàng Hóa", // Tiêu đề cột hiển thị
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
                });

                dataGridViewHangHoa.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenHangHoa",
                    Name = "TenHangHoa",
                    HeaderText = "Tên Hàng Hóa",
                    Width = 200,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
                });

                dataGridViewHangHoa.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NguonGoc",
                    Name = "NguonGoc",
                    HeaderText = "Nguồn Gốc",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
                });

                dataGridViewHangHoa.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "GiaBan",
                    Name = "GiaBan",
                    HeaderText = "Giá Bán",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "#,##0 ₫" // Định dạng kiểu tiền tệ
                    }
                });

                dataGridViewHangHoa.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "HinhAnh",
                    Name = "HinhAnh",
                    HeaderText = "Hình Ảnh",
                    Width = 200,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
                });
                dataGridViewHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Gán danh sách Items làm nguồn dữ liệu cho DataGridView
                dataGridViewHangHoa.DataSource = null; // Xóa nguồn dữ liệu cũ (nếu có)
                dataGridViewHangHoa.DataSource = _controller.Items.Cast<HangHoaModel>().ToList();



            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewHangHoa.Rows[e.RowIndex];

                // Tạo đối tượng HangHoaModel từ dữ liệu trong hàng
                HangHoaModel hangHoa = new HangHoaModel
                {
                    MaHangHoa = int.TryParse(selectedRow.Cells["MaHangHoa"].Value?.ToString(), out var maHangHoa) ? maHangHoa : 0, // Chuyển đổi thành int
                    TenHangHoa = selectedRow.Cells["TenHangHoa"].Value?.ToString(),
                    NguonGoc = selectedRow.Cells["NguonGoc"].Value?.ToString(),
                    GiaBan = decimal.TryParse(selectedRow.Cells["GiaBan"].Value?.ToString().Replace("₫", "").Replace(",", "").Trim(), out var giaBan) ? giaBan : 0,
                    HinhAnh = selectedRow.Cells["HinhAnh"].Value?.ToString()
                };

                // Gọi phương thức SetDataToText với đối tượng HangHoaModel
                SetDataToText(hangHoa);


                // Lấy tên file ảnh từ cột "hinhAnh"
                string fileName = selectedRow.Cells["HinhAnh"].Value?.ToString();

                // Đường dẫn tới thư mục chứa ảnh
                string imagePath = Path.Combine("D:\\1.DH_TMMT\\dotnet\\PhanMenBanThucPhamNongNghiep\\PhanMenBanThucPhamNongNghiep\\Image\\Product", fileName);


                // Kiểm tra nếu file tồn tại thì hiển thị lên PictureBox
                if (File.Exists(imagePath))
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Ảnh không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox.Image = null; // Xóa ảnh cũ nếu có
                }
            }
        }

        private void dataGridViewHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void SetDataToText(object item)
        {
            if (item is HangHoaModel hangHoa)
            {
                txtMaHangHoa.Text = hangHoa.MaHangHoa.ToString();
                txtTenHangHoa.Text = hangHoa.TenHangHoa;
                txtNguonGoc.Text = hangHoa.NguonGoc;
                txtGiaBan.Text = hangHoa.GiaBan.ToString("#,##0 ₫");
                txtHinhAnh.Text = hangHoa.HinhAnh;
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Triển khai phương thức GetDataFromText để lấy dữ liệu từ các TextBox và trả về một đối tượng HangHoaModel
        public IModel GetDataFromText()
        {
            // Tạo đối tượng hàng hóa mới với dữ liệu đã nhập và trả về kiểu IModel
            return new HangHoaModel
            {
                MaHangHoa = int.TryParse(txtMaHangHoa.Text, out var maHangHoa) ? maHangHoa : 0,
                TenHangHoa = txtTenHangHoa.Text,
                NguonGoc = txtNguonGoc.Text,
                GiaBan = decimal.TryParse(txtGiaBan.Text.Replace("₫", "").Replace(",", "").Trim(), out var giaBan) ? giaBan : 0,
                HinhAnh = Path.GetFileName(txtHinhAnh.Text)
            };
        }

        private void txtMaHangHoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file ảnh
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; // Bộ lọc các file ảnh
                openFileDialog.Title = "Chọn ảnh mới";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn ảnh người dùng đã chọn
                    string selectedImagePath = openFileDialog.FileName;
                    // Lấy tên file ảnh từ đường dẫn
                    string newFileName = Path.GetFileName(selectedImagePath);
                    // Đường dẫn đích để lưu ảnh trong thư mục dự án
                    string destinationPath = Path.Combine("D:\\1.DH_TMMT\\dotnet\\PhanMenBanThucPhamNongNghiep\\PhanMenBanThucPhamNongNghiep\\Image\\Product", newFileName);

                    try
                    {
                        // Giải phóng hình ảnh hiện tại để tránh lỗi khi sao chép file
                        if (pictureBox.Image != null)
                        {
                            pictureBox.Image.Dispose();
                            pictureBox.Image = null;
                        }
                        // Sao chép ảnh đã chọn vào thư mục đích
                        File.Copy(selectedImagePath, destinationPath, true); // Ghi đè nếu file đã tồn tại

                        // Hiển thị ảnh mới trong PictureBox (nếu có PictureBox trên form)
                        pictureBox.Image = Image.FromFile(destinationPath);
                        txtHinhAnh.Text = newFileName;
                        // Cập nhật tên file ảnh vào cơ sở dữ liệu
                        string maHangHoa = txtMaHangHoa.Text; // Giả sử mã hàng hóa được chọn để cập nhật

                        // Gọi hàm cập nhật ảnh vào cơ sở dữ liệu
                        _controller.UpdateImageInDatabase(maHangHoa, newFileName);

                        
                        LoadDataToDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Xác nhận xem người dùng có muốn xóa không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Lấy mã hàng hóa từ TextBox (hoặc từ DataGridView)
                string maHangHoa = txtMaHangHoa.Text;

                if (!string.IsNullOrEmpty(maHangHoa))
                {
                    // Gọi phương thức Delete từ HangHoaController
                    bool isDeleted = _controller.Delete(maHangHoa);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView để hiển thị danh sách mới
                        LoadDataToDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hàng hóa để xóa hoặc có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã hàng hóa không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox và tạo đối tượng HangHoaModel
            var hangHoa = (HangHoaModel)GetDataFromText();

            // Kiểm tra tính hợp lệ của dữ liệu đầu vào
            if (!_controller.IsValid(hangHoa))
            {
                return; // Dừng lại nếu dữ liệu không hợp lệ
            }
            if (string.IsNullOrEmpty(txtMaHangHoa.Text))
            {
                // Kiểm tra xem tên hàng hóa có trùng lặp không
                if (_controller.IsValue("tenHangHoa", hangHoa.TenHangHoa))
                {
                    MessageBox.Show("Tên hàng hóa đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại nếu tên hàng hóa bị trùng
                }

                // Thực hiện thêm mới dữ liệu vào cơ sở dữ liệu
                bool isCreated = _controller.Create(hangHoa);

                if (isCreated)
                {
                    MessageBox.Show("Thêm mới hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGridView(); // Cập nhật lại DataGridView
                    
                }
                else
                {
                    MessageBox.Show("Không thể thêm mới hàng hóa. Hãy kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Kiểm tra xem tên hàng hóa có trùng lặp không (nếu cần)
                if (_controller.IsValue("tenHangHoa", hangHoa.TenHangHoa) &&
                    !hangHoa.MaHangHoa.Equals(txtMaHangHoa.Text))
                {
                    MessageBox.Show("Tên hàng hóa đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại nếu tên hàng hóa bị trùng
                }

                // Thực hiện cập nhật dữ liệu vào cơ sở dữ liệu
                bool isUpdated = _controller.Update(hangHoa);

                if (isUpdated)
                {
                    MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGridView(); // Cập nhật lại DataGridView
                }
                else
                {
                    MessageBox.Show("Không thể lưu thay đổi. Hãy kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        public void clearDataFromText()
        {
            // Xóa dữ liệu trong các TextBox
            txtMaHangHoa.Text = string.Empty;
            txtTenHangHoa.Text = string.Empty;
            txtNguonGoc.Text = string.Empty;
            txtGiaBan.Text = string.Empty;
            txtHinhAnh.Text = string.Empty;

            // Xóa hình ảnh trong PictureBox
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            clearDataFromText();
        }
    }
}
