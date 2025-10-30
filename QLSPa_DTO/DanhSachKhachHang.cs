//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using QLSPa_DTO;

//namespace QLSPa_DTO
//{
//    public class DanhSachKhachHang
//    {
//        List<KhachHang> lstKhachHang;

//        public List<KhachHang> LstKhachHang { get => lstKhachHang; set => lstKhachHang = value; }

//        public DanhSachKhachHang()
//        {
//            LstKhachHang = new List<KhachHang>();
//        }

//        public void DocListKhachHang()
//        {
//            //....
//        }

//        public void Xuat()
//        {
//            int i = 1;
//            foreach (KhachHang kh in lstKhachHang)
//            {
//                Console.WriteLine($"-------THÔNG TIN KHÁCH HÀNG THỨ {i}-----");
//                i++;
//                Console.WriteLine($"\nMã KH: {kh.MaKH}");
//                Console.WriteLine($"Tên KH: {kh.TenKH}");
//                Console.WriteLine($"SĐT: {kh.SDT}");
//                Console.WriteLine("Các dịch vụ:");
//                foreach (DichVu dv in kh.listDichVu)
//                {
//                    //dv.Xuat();
//                }
//            }
//        }

//        public void XuatListKHHon3DV()
//        {
//            List<KhachHang> ds = lstKhachHang.Where(kh => kh.listDichVu.Count > 3).ToList();
//            if (ds.Count == 0)
//                Console.WriteLine("Không có khách hàng nào sử dụng hơn 3 dịch vụ.");
//            else
//            {
//                Console.WriteLine("\n--- Danh sách KH dùng hơn 3 DV ---");
//                foreach (KhachHang kh in ds)
//                {
//                    Console.WriteLine($"{kh.MaKH} - {kh.TenKH} ({kh.listDichVu.Count} dịch vụ)");
//                }
//            }
//        }
//    }
//}