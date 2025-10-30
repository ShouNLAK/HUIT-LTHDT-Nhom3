using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QLSPa_DTO;

namespace QLSPa_DAL
{
    public class DataAccess_DAL
    {
        public List<DichVu> DocDanhSachDichVu(string filePath)
        {
            List<DichVu> dsDichVu = new List<DichVu>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodeList = doc.SelectNodes("/DanhSach/DichVu");

            foreach (XmlNode node in nodeList)
            {
                // Đọc các node từ XML
                string tenDichVu = node["TenDichVu"].InnerText;
                string dichVuDiKem = node["DichVuDiKem"].InnerText;
                double giaThanh = double.Parse(node["GiaThanh"].InnerText);
                string loai = node.Attributes["Loai"].Value;

                DichVu dv;
                if (loai.Equals("ChamSocSacDep"))
                {
                    dv = new ChamSocSacDep(tenDichVu, dichVuDiKem, giaThanh);
                }
                else if (loai.Equals("ChamSocBody"))
                {
                    dv = new ChamSocBody(tenDichVu, dichVuDiKem, giaThanh);
                }
                else if (loai.Equals("DuongSinhTriLieu"))
                {
                    dv = new DuongSinhTriLieu(tenDichVu, dichVuDiKem, giaThanh);
                }
                else
                {
                    throw new Exception("Loại dịch vụ không hợp lệ trong XML.");
                }
                dsDichVu.Add(dv);
            }
            return dsDichVu;
        }

        public List<KhachHang> DocDanhSachKhachHang(string filePath, List<DichVu> dsDichVuFull)
        {
            List<KhachHang> dsKhachHang = new List<KhachHang>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodeList = doc.SelectNodes("/DanhSach/KhachHang");

            foreach (XmlNode node in nodeList)
            {
                string maKH = node["MaKH"].InnerText;
                string tenKH = node["TenKH"].InnerText;
                string sdt = node["SDT"].InnerText;

                List<DichVu> dvCuaKhachHang = new List<DichVu>();
                XmlNodeList dvNodes = node.SelectNodes("ListDichvu/DichVu");

                foreach (XmlNode dvNode in dvNodes)
                {
                    string tenDV = dvNode.InnerText;
                    DichVu dvDaCo = dsDichVuFull.FirstOrDefault(dv => dv.TenDichVu.Equals(tenDV));
                    if (dvDaCo != null)
                    {
                        dvCuaKhachHang.Add(dvDaCo);
                    }
                }

                KhachHang kh = new KhachHang(maKH, tenKH, sdt, dvCuaKhachHang);
                dsKhachHang.Add(kh);
            }
            return dsKhachHang;
        }
        public void LuuDanhSachDichVu(string filePath, List<DichVu> dsDichVu)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("DanhSach");
            doc.AppendChild(root);

            foreach (DichVu dv in dsDichVu)
            {
                XmlElement dichVuElem = doc.CreateElement("DichVu");

                string loai = "";
                if (dv is ChamSocSacDep) loai = "ChamSocSacDep";
                else if (dv is ChamSocBody) loai = "ChamSocBody";
                else if (dv is DuongSinhTriLieu) loai = "DuongSinhTriLieu";
                dichVuElem.SetAttribute("Loai", loai);

                XmlElement tenDvElem = doc.CreateElement("TenDichVu");
                tenDvElem.InnerText = dv.TenDichVu;
                dichVuElem.AppendChild(tenDvElem);

                XmlElement dvdkElem = doc.CreateElement("DichVuDiKem");
                dvdkElem.InnerText = dv.DichVuDiKem;
                dichVuElem.AppendChild(dvdkElem);

                XmlElement giaElem = doc.CreateElement("GiaThanh");
                giaElem.InnerText = dv.GiaThanh.ToString();
                dichVuElem.AppendChild(giaElem);

                root.AppendChild(dichVuElem);
            }
            doc.Save(filePath);
        }
    }
}