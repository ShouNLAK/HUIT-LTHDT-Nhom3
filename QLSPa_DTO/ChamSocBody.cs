using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSPa_DTO;

namespace QLSPa_DTO
{
    public class ChamSocBody : DichVu, IGiamGia
    {
        public ChamSocBody() : base() { }

        public ChamSocBody(string tenDichVu, string dichVuDiKem, double giaThanh)
            : base(tenDichVu, dichVuDiKem, giaThanh) { }

        public double TinhGiamGia()
        {
            return this.GiaThanh * 0.07;
        }

        public override string ToString()
        {
            return $"[BODY] {TenDichVu} {(GiaThanh - TinhGiamGia()):N0}VND (Giá gốc:{(GiaThanh):N0}VND) (Chi tiết: {DichVuDiKem})";
 
        }
    }
}