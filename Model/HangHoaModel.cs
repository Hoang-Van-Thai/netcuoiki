using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.Model
{
    public class HangHoaModel:IModel
    {
        // Properties for the HangHoa model
        public int MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public string NguonGoc { get; set; }
        public decimal GiaBan { get; set; }
        public string HinhAnh { get; set; }

        // Constructor with no arguments
        public HangHoaModel() { }

        // Constructor with parameters to initialize all properties
        public HangHoaModel(int maHangHoa, string tenHangHoa, string nguonGoc, decimal giaBan, string hinhAnh)
        {
            MaHangHoa = maHangHoa;
            TenHangHoa = tenHangHoa;
            NguonGoc = nguonGoc;
            GiaBan = giaBan;
            HinhAnh = hinhAnh;
        }

        // ToString method for easier representation of a HangHoa object
        public override string ToString()
        {
            return $"Mã: {MaHangHoa}, Tên: {TenHangHoa}, Nguồn gốc: {NguonGoc}, Giá: {GiaBan:C}, Hình ảnh: {HinhAnh}";
        }
    }
}
