using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Model
{
    internal class PhieuXuatModel:IModel
    {
        // Thuộc tính đại diện cho các cột trong bảng PHIEUXUAT
        public int MaPhieuXuat { get; set; }

        public int MaKhachHang { get; set; }

        public DateTime? NgayXuat { get; set; }

        // Constructor mặc định
        public PhieuXuatModel()
        {
        }

        // Constructor có tham số
        public PhieuXuatModel(int maPhieuXuat, int maKhachHang, DateTime? ngayXuat)
        {
            MaPhieuXuat = maPhieuXuat;
            MaKhachHang = maKhachHang;
            NgayXuat = ngayXuat;
        }

    }
}
