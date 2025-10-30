using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSPa_DAL;
using QLSPa_DTO;

namespace QLSPa_BLL
{
    public class DichVu_BLL
    {
        private DataAccess_DAL dal = new DataAccess_DAL();
        private List<DichVu> dsDichVu;
        private string filePath = "Data/DanhSachDichVu.xml"; // thư mục bin/Debug

        public DichVu_BLL()
        {
            // Tải danh sách DV ngay khi khởi tạo BLL
            dsDichVu = dal.DocDanhSachDichVu(filePath);
        }

        // 1. Lấy toàn bộ danh sách
        public List<DichVu> GetDanhSachDichVu()
        {
            return dsDichVu;
        }

        // 2. Thêm dịch vụ
        public void ThemDichVu(string loai, string tenDV, string dvDiKem, double giaThanh)
        {
            DichVu dv;
            if (loai.Equals("ChamSocSacDep"))
                dv = new ChamSocSacDep(tenDV, dvDiKem, giaThanh);
            else if (loai.Equals("ChamSocBody"))
                dv = new ChamSocBody(tenDV, dvDiKem, giaThanh);
            else if (loai.Equals("DuongSinhTriLieu"))
                dv = new DuongSinhTriLieu(tenDV, dvDiKem, giaThanh);
            else
                throw new Exception("Loại dịch vụ không hợp lệ");

            dsDichVu.Add(dv);
            // Lưu ngay sau khi thêm
            dal.LuuDanhSachDichVu(filePath, dsDichVu);
        }

        // 3. Cập nhật giá dịch vụ CSSD
        public void CapNhatGiaCSSD()
        {
            bool daCapNhat = false;
            foreach (DichVu dv in dsDichVu)
            {
                if (dv is ChamSocSacDep)
                {
                    // Ép kiểu và gọi hàm
                    ((ICapNhatKinhPhi)dv).CapNhatKP();
                    daCapNhat = true;
                }
            }

            // Nếu có cập nhật, lưu lại file
            if (daCapNhat)
                dal.LuuDanhSachDichVu(filePath, dsDichVu);
        }

        // 4. Tìm kiếm dịch vụ (theo tên, dịch vụ đi kèm hoặc giá)
        public List<DichVu> TimDichVu(string tuKhoa)
        {
            string searchLower = tuKhoa.ToLower();
            double giaSearch;
            bool laSo = double.TryParse(tuKhoa, out giaSearch);

            return dsDichVu.Where(dv =>
                dv.TenDichVu.ToLower().Contains(searchLower) ||
                dv.DichVuDiKem.ToLower().Contains(searchLower) ||
                (laSo && dv.GiaThanh == giaSearch)
            ).ToList();
        }

        // 5. Lấy DV có giá trên 500.000
        public List<DichVu> GetDichVuGiaTren(double gia)
        {
            return dsDichVu.Where(dv => dv.GiaThanh > gia).ToList();
        }

        // 6. Lấy DV theo loại
        public List<DichVu> GetDichVuTheoLoai(string loai) // "ChamSocSacDep", "ChamSocBody", "DuongSinhTriLieu"
        {
            if (loai.Equals("ChamSocSacDep"))
                return dsDichVu.Where(dv => dv is ChamSocSacDep).ToList();
            if (loai.Equals("ChamSocBody"))
                return dsDichVu.Where(dv => dv is ChamSocBody).ToList();
            if (loai.Equals("DuongSinhTriLieu"))
                return dsDichVu.Where(dv => dv is DuongSinhTriLieu).ToList();

            return new List<DichVu>(); // Trả về list rỗng nếu loại sai
        }
    }
}