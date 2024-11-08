
using PhanMenBanThucPhamNongNghiep.Controller;
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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void helprToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangHoaView Hanghoa = new HangHoaView();
            PanelTrangChu.Controls.Clear();
            Hanghoa.Dock = DockStyle.Fill;
            PanelTrangChu.Controls.Add(Hanghoa);
            Hanghoa.Show();
            groupBoxstatus.Text = "Quản lý hàng hóa";
        }

        private void PanelTrangChu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHangView khachHangView = new KhachHangView();
            PanelTrangChu.Controls.Clear();
            khachHangView.Dock = DockStyle.Fill;
            PanelTrangChu.Controls.Add(khachHangView);
            khachHangView.Show();
            groupBoxstatus.Text = "Quản lý khách hàng";

        }

        private void slipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuXuatView phieuXuatView = new PhieuXuatView();
            PanelTrangChu.Controls.Clear();
            phieuXuatView.Dock = DockStyle.Fill;
            PanelTrangChu.Controls.Add(phieuXuatView);
            phieuXuatView.Show();
            groupBoxstatus.Text = "Quản lý phiếu xuất";
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietPhieuXuatView chiTietPhieuXuatView = new ChiTietPhieuXuatView();
            PanelTrangChu.Controls.Clear();
            chiTietPhieuXuatView.Dock = DockStyle.Fill;
            PanelTrangChu.Controls.Add(chiTietPhieuXuatView);
            chiTietPhieuXuatView.Show();
            groupBoxstatus.Text = "Bán hàng hóa";
        }
    }
}
