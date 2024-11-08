using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Model
{
    internal class KhachHangModel:IModel
    {
        public int MaKhachHang { get; set; }

        

        public string TenKhachHang { get; set; }

        public string DiaChi { get; set; }

        public string DienThoai { get; set; }

        // Constructor
        public KhachHangModel()
        {

        }
        public KhachHangModel(int maKhachHang, string tenKhachHang, string diaChi, string dienThoai)
        {
            MaKhachHang = maKhachHang;
          
            TenKhachHang = tenKhachHang;
            DiaChi = diaChi;
            DienThoai = dienThoai;
        }
    }
}
