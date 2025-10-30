using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSPa_DTO;

namespace QLSPa_DTO
{
    public class ChamSocSacDep : DichVu, ICapNhatKinhPhi
    {
        public ChamSocSacDep() : base() { }

        public ChamSocSacDep(string tenDichVu, string dichVuDiKem, double giaThanh)
            : base(tenDichVu, dichVuDiKem, giaThanh) { }

        public void CapNhatKP()
        {
            this.GiaThanh = this.GiaThanh * 1.03;
        }

        public override string ToString()
        {
            return $"[CSSD] {base.ToString()}";
        }
    }
}