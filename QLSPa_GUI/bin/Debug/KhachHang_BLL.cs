using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSPa_DAL;
using QLSPa_DTO;

namespace QLSPa_BLL
{
    public class KhachHang_BLL
    {
        private DataAccess_DAL dal = new DataAccess_DAL();
        private List<KhachHang> dsKhachHang;
        private string filePath = "Data/DanhSachKhachHang.xml";

        public KhachHang_BLL(List<DichVu> dsDichVuFull)
        {
            dsKhachHang = dal.DocDanhSachKhachHang(filePath, dsDichVuFull);
        }

        // 1. Lấy toàn bộ khách hàng
        public List<KhachHang> GetDanhSachKhachHang()
        {
            return dsKhachHang;
        }

        // 2. Xuất DV theo tên KH
        public List<DichVu> GetDichVuTheoTenKH(string tenKH)
        {
            KhachHang kh = GetDanhSachKhachHang().FirstOrDefault(k => k.TenKH.ToLower().Contains(tenKH.ToLower()));

            if (kh != null)
                return kh.ListDichVu;

            return null;
        }

        // 3. In KH dùng > 3 dịch vụ
        public List<KhachHang> GetKhachHangDungNhieuHon(int soLuong)
        {
            return dsKhachHang.Where(kh => kh.ListDichVu.Count > soLuong).ToList();
        }
    }
}