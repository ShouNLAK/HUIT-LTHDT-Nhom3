# 🎓 Đồ Án Lập Trình Hướng Đối Tượng - Nhóm 3

**Trường Đại học Công Thương Tp.HCM (HUIT)**  
*Ho Chi Minh City University of Industry and Trade*

---

## 📋 Thông Tin Đề Tài

**Đề tài 3:** Xây dựng ứng dụng Quản lý khách hàng tại Spa chăm sóc sắc đẹp

**Môn học:** Lập trình Hướng đối tượng  

---

## 👥 Thành Viên Nhóm

| STT | Họ và Tên | GitHub | Vai trò |
|-----|-----------|--------|---------|
| 1 | Hứa Trọng Nhân | [@DGao-006](https://github.com/DGao-006) | Nhóm trưởng |
| 2 | Nguyễn Lê Anh Khoa | [@ShouNLAK](https://github.com/ShouNLAK) | Thành viên |
| 3 | Đồng Thu Nhiên | [@dongthunhien](https://github.com/dongthunhien) | Thành viên |
| 4 | Hoàng Xuân Phi Long | [@YuluWusu](https://github.com/YuluWusu) | Thành viên |
| 5 | Điệp Bảo Phạm Trường | [@DiepTruong369](https://github.com/DiepTruong369) | Thành viên |

---

## 📖 Mô Tả Đề Tài

Ứng dụng **Quản lý khách hàng tại Spa chăm sóc sắc đẹp (QLSPa)** được xây dựng nhằm hỗ trợ việc quản lý thông tin khách hàng, dịch vụ, lịch hẹn và các hoạt động kinh doanh của spa một cách hiệu quả và chuyên nghiệp.

### Tính năng chính:
- ✅ Quản lý thông tin khách hàng
- ✅ Quản lý dịch vụ spa
- ✅ Giao diện thân thiện, dễ sử dụng

---

## 🏗️ Kiến Trúc Hệ Thống

Ứng dụng được thiết kế theo mô hình **3-Layer Architecture (Mô hình 3 lớp)** đảm bảo tính module hóa và dễ bảo trì:

**Ngôn ngữ**: C# (.NET Framework)

**Giao diện**: Windows Forms (WinForms)

### Kiến trúc 3 lớp (3-Layer Architecture):
- GUI (Graphical User Interface): Lớp giao diện người dùng, hiển thị thông tin và nhận tương tác.
- BLL (Business Logic Layer): Lớp xử lý logic nghiệp vụ. (VD: KhachHang_BLL kiểm tra tính hợp lệ của SĐT trước khi lưu).
- DAL (Data Access Layer): Lớp truy cập dữ liệu, chịu trách nhiệm đọc/ghi dữ liệu.
- DTO (Data Transfer Object): Các đối tượng (lớp) dùng để vận chuyển dữ liệu giữa các lớp.

### Lưu trữ dữ liệu:
- Sử dụng File XML (DanhSachKhachHang.xml, DanhSachDichVu.xml) làm cơ sở dữ liệu.
- Lớp DataAccess_DAL đóng vai trò trung gian, xử lý toàn bộ việc đọc và ghi dữ liệu từ các file XML, giúp các lớp BLL và GUI không cần quan tâm đến cách thức lưu trữ.
