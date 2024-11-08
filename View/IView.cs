using PhanMenBanThucPhamNongNghiep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMenBanThucPhamNongNghiep.View
{
    internal interface IView
    {
        public void SetDataToText(Object item);
        IModel GetDataFromText();
        public void clearDataFromText();
    }
}
