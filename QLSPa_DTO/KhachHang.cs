using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLSPa_DTO
{
    public class KhachHang
    {
        private string maKH;
        private string tenKH;
        private string sDT;

        // Dùng property để đóng gói
        public List<DichVu> ListDichVu { get; private set; }

        public string MaKH
        {
            get => maKH;
            set
            {
                if (value.Length == 5 && value.StartsWith("KH") && value.Substring(2).All(char.IsDigit))
                {
                    maKH = value;
                }
                else throw new Exception("Mã KH phải có dạng KHxxx (ví dụ: KH001).");
            }
        }
        public string TenKH
        {
            get => tenKH;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Tên khách hàng không được để trống.");
                tenKH = value;
            }
        }
        public string SDT
        {
            get => sDT;
            set
            {
                if (value.Length >= 10 && value.Length <= 11 && value.All(char.IsDigit) && value.StartsWith("0"))
                    sDT = value;
                else throw new Exception("SĐT phải là 10-11 chữ số và bắt đầu bằng 0.");
            }
        }

        // Xóa hàm Console. Đã chuyển ListDichVu thành Property
        public KhachHang(string maKH, string tenKH, string sDT, List<DichVu> listDichVu)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SDT = sDT;
            this.ListDichVu = listDichVu;
        }

        public KhachHang()
        {
            this.ListDichVu = new List<DichVu>();
        }

        public KhachHang(KhachHang kh)
        {
            this.maKH = kh.maKH;
            this.tenKH = kh.tenKH;
            this.SDT = kh.SDT;
            this.ListDichVu = new List<DichVu>(kh.ListDichVu); // Tạo 1 list mới
        }



        public override string ToString()
        {
            return $"{MaKH} - {TenKH} - {SDT} - (Đã dùng {ListDichVu.Count} dịch vụ)";
        }
    }
}