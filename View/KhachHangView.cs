using PhanMenBanThucPhamNongNghiep.Controller;
using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMenBanThucPhamNongNghiep.View
{

    public partial class KhachHangView : UserControl,IView
    {
        KhachHangController _controller = new KhachHangController();
        public KhachHangView()
        {
            InitializeComponent();
            LoadDataToDataGridView();
        }
        private void LoadDataToDataGridView()
        {
            if (_controller.Load())
            {
                dataGridViewKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewKhachHang.DataSource = null;
                dataGridViewKhachHang.DataSource = _controller.Items.Cast<KhachHangModel>().ToList();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // Method to set data from an object to the form's text fields
        public void SetDataToText(object item)
        {
            if (item is KhachHangModel khachHang)
            {
                textBoxMaKhachHang.Text = khachHang.MaKhachHang.ToString();

                textBoxTenKhachHang.Text = khachHang.TenKhachHang;
                textBoxDienThoai.Text = khachHang.DienThoai;
                textBoxDiaChi.Text = khachHang.DiaChi;
            }
        }

        // Method to get data from text fields and return a model object
        public IModel GetDataFromText()
        {
            try
            {
                int maKhachHang = int.TryParse(textBoxMaKhachHang.Text, out var maKH) ? maKH : 0;

                string tenKhachHang = textBoxTenKhachHang.Text;
                string diaChi = textBoxDiaChi.Text;
                string dienThoai = textBoxDienThoai.Text;

                return new KhachHangModel(maKhachHang, tenKhachHang, diaChi, dienThoai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ biểu mẫu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Method to clear the text fields
        public void clearDataFromText()
        {
            textBoxMaKhachHang.Clear();

            textBoxTenKhachHang.Clear();
            textBoxDienThoai.Clear();
            textBoxDiaChi.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewKhachHang.Rows[e.RowIndex];
                KhachHangModel khachHangModel = new KhachHangModel()
                {
                    MaKhachHang = Convert.ToInt32(selectedRow.Cells["MaKhachHang"].Value),
                    TenKhachHang = selectedRow.Cells["TenKhachHang"].Value.ToString(),
                    DiaChi = selectedRow.Cells["DiaChi"].Value.ToString(),
                    DienThoai = selectedRow.Cells["DienThoai"].Value.ToString()
                };
                SetDataToText(khachHangModel);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Lấy mã hàng hóa từ TextBox (hoặc từ DataGridView)
                string makhachhang = textBoxMaKhachHang.Text;

                if (!string.IsNullOrEmpty(makhachhang))
                {
                    // Gọi phương thức Delete từ HangHoaController
                    bool isDeleted = _controller.Delete(makhachhang);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView để hiển thị danh sách mới
                        LoadDataToDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để xóa hoặc có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var khachhang = (KhachHangModel)GetDataFromText();

            // Kiểm tra tính hợp lệ của dữ liệu đầu vào
            if (!_controller.IsValid(khachhang))
            {
                return; // Dừng lại nếu dữ liệu không hợp lệ
            }
            if (string.IsNullOrEmpty(textBoxMaKhachHang.Text))
            {
                // Kiểm tra xem tên hàng hóa có trùng lặp không
                if (_controller.IsValue("tenKhachHang", khachhang.TenKhachHang))
                {
                    MessageBox.Show("Tên hàng hóa đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại nếu tên hàng hóa bị trùng
                }

                // Thực hiện thêm mới dữ liệu vào cơ sở dữ liệu
                bool isCreated = _controller.Create(khachhang);

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
                if (_controller.IsValue("tenKhachHang", khachhang.TenKhachHang) &&
                    !khachhang.MaKhachHang.Equals(textBoxMaKhachHang.Text))
                {
                    MessageBox.Show("Tên hàng hóa đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại nếu tên hàng hóa bị trùng
                }

                // Thực hiện cập nhật dữ liệu vào cơ sở dữ liệu
                bool isUpdated = _controller.Update(khachhang);

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

        private void textBoxDienThoai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
