using PhanMenBanThucPhamNongNghiep.Controller;
using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace PhanMenBanThucPhamNongNghiep.View
{
    public partial class ChiTietPhieuXuatView : UserControl, IView
    {
        KhachHangController KhachHangController = new KhachHangController();
        ChiTietPhieuXuatController ChiTietPhieuXuatController = new ChiTietPhieuXuatController();
        HangHoaController hangHoaController = new HangHoaController();
        PhieuXuatController PhieuXuatController = new PhieuXuatController();
        public ChiTietPhieuXuatView()
        {
            InitializeComponent();
            loadDataToComBoBox();
            LoadId();
            SetupDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void loadDataToComBoBox()
        {
            if (KhachHangController.Load())
            {
                comboBoxMaKhachHang.DataSource = KhachHangController.Items.Cast<KhachHangModel>().ToList();
                comboBoxMaKhachHang.DisplayMember = "TenKhachHang";
                comboBoxMaKhachHang.ValueMember = "MaKhachHang";
            }
            else
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu vào combobox ");
            }
        }
        public void LoadId()
        {
            int idMax = PhieuXuatController.GetNextId();
            txtMaPhieuXuat.Text = idMax.ToString();



        }
        private void SetupDataGridView()
        {
            // Tạo cột "Tên hàng hóa" dưới dạng ComboBoxColumn
            var tenHangHoaColumn = new DataGridViewComboBoxColumn();
            tenHangHoaColumn.HeaderText = "Tên hàng hóa";
            tenHangHoaColumn.Name = "tenHangHoa";
            hangHoaController.Load();
            tenHangHoaColumn.DataSource = hangHoaController.Items.Cast<HangHoaModel>().ToList();
            // Thiết lập DisplayMember và ValueMember
            tenHangHoaColumn.DisplayMember = "TenHangHoa"; // Hiển thị tên hàng hóa trong ComboBox
            tenHangHoaColumn.ValueMember = "MaHangHoa";    // Giá trị ẩn là mã hàng hóa

            dataGridViewBanHang.Columns.Add(tenHangHoaColumn);

            // Tạo cột "Số lượng" dưới dạng TextBoxColumn
            var soLuongColumn = new DataGridViewTextBoxColumn();
            soLuongColumn.HeaderText = "Số lượng";
            soLuongColumn.Name = "soLuong";
            dataGridViewBanHang.Columns.Add(soLuongColumn);

            // Tạo cột "Giá bán" dưới dạng TextBoxColumn, không cho phép chỉnh sửa
            var giaBanColumn = new DataGridViewTextBoxColumn();
            giaBanColumn.HeaderText = "Giá bán";
            giaBanColumn.Name = "giaBan";
            giaBanColumn.ReadOnly = true;
            dataGridViewBanHang.Columns.Add(giaBanColumn);

            dataGridViewBanHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewBanHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột thay đổi là "Tên hàng hóa"
            if (e.ColumnIndex == dataGridViewBanHang.Columns["tenHangHoa"].Index && e.RowIndex >= 0)
            {
                // Lấy giá trị "MaHangHoa" từ cột "Tên hàng hóa" (ComboBoxColumn)
                var selectedValue = dataGridViewBanHang.Rows[e.RowIndex].Cells["tenHangHoa"].Value;

                if (selectedValue != null)
                {
                    int maHangHoa = (int)selectedValue;

                    // Tìm giá bán của sản phẩm dựa trên mã hàng hóa (so sánh chuỗi)
                    var hangHoa = hangHoaController.Items.Cast<HangHoaModel>().FirstOrDefault(h => h.MaHangHoa == maHangHoa);
                    if (hangHoa != null)
                    {
                        // Cập nhật giá bán vào cột "Giá bán"
                        dataGridViewBanHang.Rows[e.RowIndex].Cells["giaBan"].Value = hangHoa.GiaBan;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm với mã hàng hóa đã chọn.");
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị mã hàng hóa không hợp lệ.");
                }
            }
            // Kiểm tra nếu cột thay đổi là "Số lượng" hoặc "Giá bán"
            if ((e.ColumnIndex == dataGridViewBanHang.Columns["soLuong"].Index ||
                 e.ColumnIndex == dataGridViewBanHang.Columns["giaBan"].Index) && e.RowIndex >= 0)
            {
                // Biến để lưu tổng tiền của tất cả các hàng
                decimal tongTienTatCaHang = 0;

                // Duyệt qua tất cả các hàng trong DataGridView để tính tổng tiền
                foreach (DataGridViewRow row in dataGridViewBanHang.Rows)
                {
                    if (row.Cells["soLuong"].Value != null && row.Cells["giaBan"].Value != null)
                    {
                        // Chuyển đổi giá trị từ ô "Số lượng" và "Giá bán"
                        if (int.TryParse(row.Cells["soLuong"].Value.ToString(), out int soLuong) &&
                            decimal.TryParse(row.Cells["giaBan"].Value.ToString(), out decimal giaBan))
                        {
                            // Tính tổng tiền cho hàng hiện tại
                            tongTienTatCaHang += soLuong * giaBan;
                        }
                    }
                }

                // Cập nhật Label hiển thị tổng tiền của tất cả các hàng
                lblTongTien.Text = $" {tongTienTatCaHang.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"))}";
            }
        }

        private void txtMaChiTietPhieuXuat_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Lấy đối tượng từ dữ liệu trên form
            PhieuXuatModel phieuXuat = (PhieuXuatModel)GetDataFromText();

            // Kiểm tra tính hợp lệ của đối tượng PhieuXuatModel
            PhieuXuatController phieuXuatController = new PhieuXuatController();
            if (!phieuXuatController.IsValid(phieuXuat))
            {
                return; // Dừng lại nếu dữ liệu không hợp lệ
            }

            // Gọi phương thức Create để thêm mới phiếu xuất
            if (!phieuXuatController.Create(phieuXuat))
            {
                MessageBox.Show("Không thể thêm phiếu xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Duyệt qua từng dòng trong DataGridView để thêm chi tiết phiếu xuất
            foreach (DataGridViewRow row in dataGridViewBanHang.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng mới chưa có dữ liệu

                // Lấy dữ liệu từ các cột
                var maHangHoaValue = row.Cells["tenHangHoa"].Value;
                var soLuongValue = row.Cells["soLuong"].Value;
                var giaBanValue = row.Cells["giaBan"].Value;

                // Kiểm tra dữ liệu có hợp lệ không
                if (maHangHoaValue == null || soLuongValue == null || giaBanValue == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho tất cả các hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                // Chuyển đổi dữ liệu
                if (int.TryParse(maHangHoaValue.ToString(), out int maHangHoa) &&
                    int.TryParse(soLuongValue.ToString(), out int soLuong) &&
                    decimal.TryParse(giaBanValue.ToString(), out decimal giaBan))
                {
                    // Tạo đối tượng ChiTietPhieuXuatModel
                    var chiTietPhieuXuat = new ChiTietPhieuXuatModel
                    {
                        MaPhieuXuat = phieuXuat.MaPhieuXuat,
                        MaHangHoa = maHangHoa,
                        SoLuongXuat = soLuong,
                        GiaXuat = giaBan
                    };

                    // Kiểm tra tính hợp lệ của đối tượng
                    var chiTietPhieuXuatController = new ChiTietPhieuXuatController();
                    if (!chiTietPhieuXuatController.IsValid(chiTietPhieuXuat))
                    {
                        continue; // Bỏ qua dòng này nếu dữ liệu không hợp lệ
                    }

                    // Thêm vào bảng chi tiết phiếu xuất
                    if (!chiTietPhieuXuatController.Create(chiTietPhieuXuat))
                    {
                        MessageBox.Show($"Không thể thêm chi tiết phiếu xuất cho hàng hóa {maHangHoa}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu trong hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Thông báo thành công và xóa dữ liệu trong các điều khiển
            MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void SetDataToText(object item)
        {
            if (item is PhieuXuatModel phieuXuat)
            {
                txtMaPhieuXuat.Text = phieuXuat.MaPhieuXuat.ToString();
                comboBoxMaKhachHang.SelectedValue = phieuXuat.MaKhachHang;
                dateTimePickerNgayXuat.Value = phieuXuat.NgayXuat ?? DateTime.Now;
            }
        }
        public IModel GetDataFromText()
        {
            int.TryParse(txtMaPhieuXuat.Text, out int maPhieuXuat);
            int.TryParse(comboBoxMaKhachHang.SelectedValue?.ToString(), out int maKhachHang);

            return new PhieuXuatModel
            {
                MaPhieuXuat = maPhieuXuat,
                MaKhachHang = maKhachHang,
                NgayXuat = dateTimePickerNgayXuat.Value
            };
        }
        public void clearDataFromText()
        {
            txtMaPhieuXuat.Clear();
            comboBoxMaKhachHang.SelectedIndex = -1;
            dateTimePickerNgayXuat.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo ứng dụng Excel mới
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Missing.Value);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Phiếu Xuất";

                // Xuất tên khách hàng và ngày xuất
                worksheet.Cells[1, 1] = "Tên Khách Hàng:";
                worksheet.Cells[1, 2] = comboBoxMaKhachHang.Text; // Tên khách hàng lấy từ ComboBox
                worksheet.Cells[2, 1] = "Ngày Xuất:";
                worksheet.Cells[2, 2] = dateTimePickerNgayXuat.Value.ToShortDateString();

                // Xuất tiêu đề cho các cột DataGridView
                worksheet.Cells[4, 1] = "Tên Hàng Hóa";
                worksheet.Cells[4, 2] = "Số Lượng";
                worksheet.Cells[4, 3] = "Giá Bán";
                worksheet.Cells[4, 4] = "Thành Tiền";

                // Thiết lập in đậm cho tiêu đề
                Excel.Range headerRange = worksheet.Range["A4", "D4"];
                headerRange.Font.Bold = true;

                // Duyệt qua từng hàng trong DataGridView và ghi dữ liệu vào Excel
                int rowExcel = 5;
                foreach (DataGridViewRow row in dataGridViewBanHang.Rows)
                {
                    if (row.IsNewRow) continue;

                    worksheet.Cells[rowExcel, 1] = row.Cells["tenHangHoa"].Value?.ToString();
                    worksheet.Cells[rowExcel, 2] = row.Cells["soLuong"].Value?.ToString();
                    worksheet.Cells[rowExcel, 3] = row.Cells["giaBan"].Value?.ToString();

                    // Tính thành tiền (Số lượng * Giá bán)
                    if (decimal.TryParse(row.Cells["soLuong"].Value?.ToString(), out decimal soLuong) &&
                        decimal.TryParse(row.Cells["giaBan"].Value?.ToString(), out decimal giaBan))
                    {
                        worksheet.Cells[rowExcel, 4] = (soLuong * giaBan).ToString();
                    }

                    rowExcel++;
                }

                // Tự động điều chỉnh kích thước cột
                worksheet.Columns.AutoFit();

                // Hiển thị hộp thoại lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Lưu file Excel",
                    FileName = "PhieuXuat_" + comboBoxMaKhachHang.Text + ".xlsx"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Đóng và giải phóng tài nguyên
                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
