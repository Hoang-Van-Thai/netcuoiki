using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Model
{
    internal class ChiTietPhieuXuatModel:IModel
    {
        public int IDPX { get; set; } // Khóa chính
        public int MaPhieuXuat { get; set; } // Mã phiếu xuất, liên kết tới bảng PHIEUXUAT
        public int MaHangHoa { get; set; } // Mã hàng hóa
        public int SoLuongXuat { get; set; } // Số lượng xuất
        public decimal? GiaXuat { get; set; } // Giá xuất

        // Hàm tạo mặc định
        public ChiTietPhieuXuatModel() { }

        // Hàm tạo với các tham số
        public ChiTietPhieuXuatModel(int idPx, int maPhieuXuat, int maHangHoa, int soLuongXuat, decimal? giaXuat)
        {
            IDPX = idPx;
            MaPhieuXuat = maPhieuXuat;
            MaHangHoa = maHangHoa;
            SoLuongXuat = soLuongXuat;
            GiaXuat = giaXuat;
        }
    }
}
