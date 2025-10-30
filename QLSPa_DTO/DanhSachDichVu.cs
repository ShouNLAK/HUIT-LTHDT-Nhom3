//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Xml;
//using QLSPa_DTO;

//namespace QLSPa_DTO
//{
//    public class DanhSachDichVu
//    {
//        List<DichVu> listDichVu;

//        public List<DichVu> ListDichVu
//        {
//            get { return listDichVu; }
//            set { listDichVu = value; }
//        }

//        public DanhSachDichVu()
//        {
//            ListDichVu = new List<DichVu>();
//        }

//        public void DocListDichVu(string tenFile)
//        {
//            XmlDocument doc = new XmlDocument();
//            doc.Load(tenFile);
//            XmlNodeList nodeList = doc.SelectNodes("/DanhSach/DichVu");
//            foreach (XmlNode node in nodeList)
//            {
//                string tenDichVu = node["TenDichVu"].InnerText;
//                string dichVuDiKem = node["DichVuDiKem"].InnerText;
//                double giaThanh = double.Parse(node["GiaThanh"].InnerText);
//                if (node.Attributes["Loai"].Value.Equals("ChamSocSacDep")) // Cái này dùng để kiểm tra chính xác string của thuộc tính
//                    ListDichVu.Add(new ChamSocSacDep(tenDichVu, dichVuDiKem, giaThanh));
//                else if (node.Attributes["Loai"].Value.Equals("ChamSocBody"))
//                    ListDichVu.Add(new ChamSocBody(tenDichVu, dichVuDiKem, giaThanh));
//                else if (node.Attributes["Loai"].Value.Equals("DuongSinhTriLieu"))
//                    ListDichVu.Add(new DuongSinhTriLieu(tenDichVu, dichVuDiKem, giaThanh));
//                else
//                    throw new Exception("Loai dich vu khong hop le");
//            }
//        }

//        public void ThemDV(int loaiDV,string tenDichVu ,string dichVuDiKem, double giaThanh) // Loại DV : 1 - Chăm sóc sắc đẹp | 2 - Chăm sóc body | 3 - Dưỡng sinh trị liệu
//        {
//            if (loaiDV == 1)
//                ListDichVu.Add(new ChamSocSacDep(tenDichVu,dichVuDiKem, giaThanh));
//            else if (loaiDV == 2)
//                ListDichVu.Add(new ChamSocBody(tenDichVu, dichVuDiKem, giaThanh));
//            else if (loaiDV == 3)
//                ListDichVu.Add(new DuongSinhTriLieu(tenDichVu, dichVuDiKem, giaThanh));
//            else
//                Console.WriteLine("Loai dich vu khong hop le");
//        }
//        public void Xuat_DV(string loaiDV, string dvDiKem, double gia) // Xuất cụ thể 1 dịch vụ
//        {
//            Console.WriteLine("{0,-20} | {1,-20} | {2,-20}", loaiDV, dvDiKem, gia);
//        }
//        public void Xuat_List() //  Xuất theo list
//        {
//            Console.WriteLine("{0,-20} + {1,-20} + {2,-20}", "Loai dich vu", "Dich vu di kem", "Gia thanh");
//            foreach (DichVu dv in ListDichVu)
//            {
//                string loaiDV;
//                if (dv is ChamSocSacDep)
//                { loaiDV = "Cham soc sac dep"; }
//                else if (dv is ChamSocBody)
//                { loaiDV = "Cham soc body"; }
//                else
//                { loaiDV = "Duong sinh tri lieu"; }
//                Xuat_DV(loaiDV, dv.DichVuDiKem, dv.GiaThanh);
//            }
//        }

//        public DichVu TimKiemDV(string Search) // Tìm kiếm theo tên dịch vụ đi kèm hoặc giá thành
//        {
//            if (Search.All(char.IsDigit)) // Theo giá thành
//            {
//                double SearchGia = double.Parse(Search);
//                foreach (DichVu dv in ListDichVu)
//                    if (dv.GiaThanh == SearchGia)
//                        return dv;
//            }
//            else // Theo tên dịch vụ đi kèm
//                foreach (DichVu dv in ListDichVu)
//                    if (dv.DichVuDiKem.ToLower().Contains(Search.ToLower()))
//                        return dv;
//            return null;
//        }

//        public List<DichVu> XuatListDVTheoTenKH(string tenKH, List<KhachHang> dskh) // Danh sách dịch vụ hổng access vô cái list khách hàng đâu nên mới gán ấy
//        {
//            foreach (KhachHang kh in dskh)
//                if (kh.TenKH.ToLower().Contains(tenKH.ToLower()))
//                    return kh.listDichVu;
//            return null;
//        }

//        public List<DichVu> XuatListDVHon500()
//        {
//            List<DichVu> KQ = new List<DichVu>();
//            foreach (DichVu dv in ListDichVu)
//                if (dv.GiaThanh > 500)
//                    KQ.Add(dv);
//            return KQ;
//        }

//        // Dưới đây là xuất theo loại dịch vụ
//        public List<DichVu> XuatListDVChamSocBody()
//        {
//            List<DichVu> KQ = new List<DichVu>();
//            foreach (DichVu dv in ListDichVu)
//                if (dv is ChamSocBody)
//                    KQ.Add(dv);
//            return KQ;
//        }

//        public List<DichVu> XuatListDVCSSacDep()
//        {
//            List<DichVu> KQ = new List<DichVu>();
//            foreach (DichVu dv in ListDichVu)
//                if (dv is ChamSocSacDep)
//                    KQ.Add(dv);
//            return KQ;
//        }

//        public List<DichVu> XuatListDVDuongSinhTriLieu()
//        {
//            List<DichVu> KQ = new List<DichVu>();
//            foreach (DichVu dv in ListDichVu)
//                if (dv is DuongSinhTriLieu)
//                    KQ.Add(dv);
//            return KQ;
//        }
//    }
//}