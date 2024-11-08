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
    public partial class PhieuXuatView : UserControl, IView
    {
        KhachHangController KhachHangController = new KhachHangController();
        PhieuXuatController PhieuXuatController = new PhieuXuatController();

        public PhieuXuatView()
        {
            InitializeComponent();
            loadDataToComBoBox();
            loadDataGridView();
        }
        public void loadDataGridView()
        {
            dataGridViewPhieuXuat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Gán danh sách Items làm nguồn dữ liệu cho DataGridView
            dataGridViewPhieuXuat.DataSource = null; // Xóa nguồn dữ liệu cũ (nếu có)
            if (PhieuXuatController.Load())
            {
                dataGridViewPhieuXuat.DataSource = PhieuXuatController.Items.Cast<PhieuXuatModel>().ToList();

            }
            else
            {
                MessageBox.Show("Không tải được dữ liệu lên datagirdview");
            }
        }
        public void loadDataToComBoBox()
        {
            if (KhachHangController.Load())
            {
                comboBoxMaKhachHang.DataSource = KhachHangController.Items.Cast<KhachHangModel>().ToList();
                comboBoxMaKhachHang.DisplayMember = "MaKhachHang";
                comboBoxMaKhachHang.ValueMember = "MaKhachHang";
            }
            else
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu vào combobox ");
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // Phương thức để thiết lập dữ liệu lên các trường trên form từ đối tượng truyền vào
        public void SetDataToText(object item)
        {
            if (item is PhieuXuatModel phieuXuat)
            {
                textBoxMaPhieuXuat.Text = phieuXuat.MaPhieuXuat.ToString();
                comboBoxMaKhachHang.SelectedItem = phieuXuat.MaKhachHang.ToString();
                dateTimePickerNgayXuat.Value = (DateTime)phieuXuat.NgayXuat;
            }
        }

        // Phương thức để lấy dữ liệu từ các trường trên form và trả về đối tượng
        public IModel GetDataFromText()
        {
            try
            {
                int maPhieuXuat = string.IsNullOrEmpty(textBoxMaPhieuXuat.Text) ? 0 : int.Parse(textBoxMaPhieuXuat.Text);
                // Lấy dữ liệu từ ComboBox và DateTimePicker để tạo đối tượng PhieuXuatModel
                int maKhachHang = (int)comboBoxMaKhachHang.SelectedValue;

                DateTime ngayXuat = dateTimePickerNgayXuat.Value;

                return new PhieuXuatModel
                {
                    MaPhieuXuat = maPhieuXuat,
                    MaKhachHang = maKhachHang,
                    NgayXuat = ngayXuat
                };
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Phương thức để xóa dữ liệu khỏi các trường trên form
        public void clearDataFromText()
        {
            textBoxMaPhieuXuat.Clear();
            comboBoxMaKhachHang.SelectedIndex = -1;
            dateTimePickerNgayXuat.Value = DateTime.Now;
        }

        private void comboBoxMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox và tạo đối tượng HangHoaModel
            var phieuXuat = (PhieuXuatModel)GetDataFromText();

            if (phieuXuat.MaPhieuXuat == 0)
            {
                bool isCreated = PhieuXuatController.Create(phieuXuat);
                if (isCreated)
                {
                    MessageBox.Show("Thêm phiếu xuất mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm phiếu xuất mới thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadDataGridView();
            }
            else
            {
                bool isUpdated = PhieuXuatController.Update(phieuXuat);
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật phiếu xuất thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadDataGridView();
            }

        }

        private void dataGridViewPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewPhieuXuat.Rows[e.RowIndex];

                // Tạo đối tượng PhieuXuatModel từ dữ liệu trong hàng
                PhieuXuatModel phieuXuat = new PhieuXuatModel
                {
                    MaPhieuXuat = Convert.ToInt32(selectedRow.Cells["MaPhieuXuat"].Value),
                    MaKhachHang = Convert.ToInt32(selectedRow.Cells["MaKhachHang"].Value),
                    NgayXuat = selectedRow.Cells["NgayXuat"].Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(selectedRow.Cells["NgayXuat"].Value)
                };

                // Gọi phương thức SetDataToText với đối tượng PhieuXuatModel
                SetDataToText(phieuXuat);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearDataFromText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Xác nhận xem người dùng có muốn xóa không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Lấy mã hàng hóa từ TextBox (hoặc từ DataGridView)
                string maPhieuXuat = textBoxMaPhieuXuat.Text;

                if (!string.IsNullOrEmpty(maPhieuXuat))
                {
                    // Gọi phương thức Delete từ HangHoaController
                    bool isDeleted = PhieuXuatController.Delete(maPhieuXuat);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView để hiển thị danh sách mới
                        loadDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu xuất để xóa hoặc có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã hàng hóa không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
