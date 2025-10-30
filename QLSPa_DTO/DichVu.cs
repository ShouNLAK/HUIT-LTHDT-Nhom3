using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSPa_DTO
{
    public abstract class DichVu
    {
        private string tenDichVu;
        private string dichVuDiKem;
        private double giaThanh;

        public string TenDichVu
        {
            get { return tenDichVu; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Tên dịch vụ không được để trống.");
                tenDichVu = value;
            }
        }

        public string DichVuDiKem
        {
            get { return dichVuDiKem; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Dịch vụ đi kèm không được để trống.");
                dichVuDiKem = value;
            }
        }

        public double GiaThanh
        {
            get { return giaThanh; }
            set
            {
                if (value < 0)
                    throw new Exception("Giá thành không được là số âm.");
                giaThanh = value;
            }
        }

        public DichVu() { }

        public DichVu(string tenDichVu, string dichVuDiKem, double giaThanh)
        {
            this.TenDichVu = tenDichVu;
            this.DichVuDiKem = dichVuDiKem;
            this.GiaThanh = giaThanh;
        }

        public override string ToString()
        {
            return $"{TenDichVu}  {GiaThanh:N0} VND  (Chi tiết: {DichVuDiKem})";
        }
    }
}