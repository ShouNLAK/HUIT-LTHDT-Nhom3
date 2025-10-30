using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSPa_BLL; 
using QLSPa_DTO; 

namespace QLSPa_GUI
{
	public partial class Form1 : Form
	{
		// Khai báo 2 đối tượng BLL
		private DichVu_BLL dichVuBLL;
		private KhachHang_BLL khachHangBLL;

		// Định nghĩa 2 chuỗi gợi ý để dễ quản lý
		private const string goiY_Tim = "Nhập tên, chi tiết hoặc giá để tìm...";
		private const string GoiY_Them = "Mẫu: 1/Tên DV Mới/DV Kèm/Giá (Phân cách bằng /)";

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				// Khởi tạo các BLL
				dichVuBLL = new DichVu_BLL();
				// Khởi tạo KH_BLL, cần truyền dsDichVu đầy đủ vào
				khachHangBLL = new KhachHang_BLL(dichVuBLL.GetDanhSachDichVu());

				// Tải dữ liệu lên ComboBoxes
				LoadComboBoxes();

				// Cập nhật trạng thái TextBox lần đầu
				CapNhatTrangThaiControlsQL();
				CapNhatTrangThaiControlsKH();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
		}

		private void LoadComboBoxes()
		{
			// Tải ComboBox Quản lý
			cboQuanLy.Items.Add("Xuất tất cả dịch vụ");
			cboQuanLy.Items.Add("Cập nhật giá CSSD 3%");
			cboQuanLy.Items.Add("Tìm dịch vụ (theo tên/giá)");
			cboQuanLy.Items.Add("Lọc DV giá > 500000");
			cboQuanLy.Items.Add("Lọc DV Chăm sóc sắc đẹp");
			cboQuanLy.Items.Add("Lọc DV Chăm sóc body");
			cboQuanLy.Items.Add("Lọc DV Dưỡng sinh");
            cboQuanLy.Items.Add("In toàn bộ danh sách KH");
			cboQuanLy.Items.Add("In KH dùng > 3 dịch vụ");
            cboQuanLy.Items.Add("Thêm dịch vụ mới");
            cboQuanLy.SelectedIndex = 0; // Chọn mục đầu tiên

			// Tải ComboBox Khách hàng
			cboKhachHang.Items.Add("Xuất DV theo tên khách hàng");
			// "In KH dùng > 3 dịch vụ" đã bị xóa khỏi đây
			cboKhachHang.SelectedIndex = 0; // Chọn mục đầu tiên
		}

		//--- SỰ KIỆN NÚT BẤM QUẢN LÝ ---
		private void btnBatDauQL_Click(object sender, EventArgs e)
		{
			string chucNang = cboQuanLy.SelectedItem.ToString();
			string input = txtInputQL.Text;

			try
			{
				switch (chucNang)
				{
					case "Xuất tất cả dịch vụ":
						HienThiDanhSach(dichVuBLL.GetDanhSachDichVu(), lstKQQL);
						break;

					case "Cập nhật giá CSSD 3%":
						dichVuBLL.CapNhatGiaCSSD();
						MessageBox.Show("Cập nhật giá 3% cho dịch vụ CSSD thành công!\nĐang tải lại danh sách.");
						HienThiDanhSach(dichVuBLL.GetDanhSachDichVu(), lstKQQL);
						break;

					case "Tìm dịch vụ (theo tên/giá)":
						if (string.IsNullOrWhiteSpace(input) || input == goiY_Tim)
						{
							MessageBox.Show("Vui lòng nhập từ khóa (tên, chi tiết hoặc giá) vào ô text bên cạnh.");
							return;
						}
						HienThiDanhSach(dichVuBLL.TimDichVu(input), lstKQQL);
						break;

					case "Lọc DV giá > 500000":
						HienThiDanhSach(dichVuBLL.GetDichVuGiaTren(500000), lstKQQL);
						break;

					case "Lọc DV Chăm sóc sắc đẹp":
						HienThiDanhSach(dichVuBLL.GetDichVuTheoLoai("ChamSocSacDep"), lstKQQL);
						break;

					case "Lọc DV Chăm sóc body":
						HienThiDanhSach(dichVuBLL.GetDichVuTheoLoai("ChamSocBody"), lstKQQL);
						break;

					case "Lọc DV Dưỡng sinh":
						HienThiDanhSach(dichVuBLL.GetDichVuTheoLoai("DuongSinhTriLieu"), lstKQQL);
						break;
                    case "In toàn bộ danh sách KH":
                        List<KhachHang> dsKH = khachHangBLL.GetDanhSachKhachHang();
                        // Hiển thị kết quả lên ListBox Quản lý (lstKQQL)
                        HienThiDanhSach(dsKH, lstKQQL);
                        break;
                    case "In KH dùng > 3 dịch vụ":
						List<KhachHang> dsKH3 = khachHangBLL.GetKhachHangDungNhieuHon(3);
						// Hiển thị kết quả lên ListBox Quản lý (lstKQQL)
						HienThiDanhSach(dsKH3, lstKQQL);
						break;

					case "Thêm dịch vụ mới":
						if (string.IsNullOrWhiteSpace(input) || input == GoiY_Them)
						{
							MessageBox.Show("Vui lòng nhập dữ liệu theo mẫu.");
							return;
						}
						try
						{
							string[] parts = input.Split('/');
							if (parts.Length != 4)
							{
								MessageBox.Show("Sai định dạng. Mẫu: Loại(1,2,3)/Tên DV/DV Kèm/Giá");
								return;
							}

							string loaiInput = parts[0].Trim();
							string tenDV = parts[1].Trim();
							string dvDiKem = parts[2].Trim();
							double giaThanh = double.Parse(parts[3].Trim()); // Có thể ném lỗi FormatException

							string loaiString;
							if (loaiInput == "1")
								loaiString = "ChamSocSacDep";
							else if (loaiInput == "2")
								loaiString = "ChamSocBody";
							else if (loaiInput == "3")
								loaiString = "DuongSinhTriLieu";
							else
							{
								MessageBox.Show("Loại dịch vụ (phần đầu tiên) phải là 1, 2, hoặc 3.");
								return;
							}

							// Gọi BLL để thêm (BLL/DTO sẽ tự kiểm tra validation)
							dichVuBLL.ThemDichVu(loaiString, tenDV, dvDiKem, giaThanh);

							MessageBox.Show("Thêm dịch vụ mới thành công!");
							HienThiDanhSach(dichVuBLL.GetDanhSachDichVu(), lstKQQL); // Tải lại danh sách
							txtInputQL.Text = GoiY_Them; // Reset lại ô nhập
						}
						catch (FormatException)
						{
							MessageBox.Show("Giá thành (phần cuối cùng) phải là một con số hợp lệ.");
						}
						catch (Exception ex)
						{
							// Bắt các lỗi validation từ DTO (vd: tên trống, giá âm)
							MessageBox.Show($"Lỗi khi thêm: {ex.Message}");
						}
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi xử lý: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		//--- SỰ KIỆN NÚT BẤM KHÁCH HÀNG ---
		private void btnBatDauKH_Click(object sender, EventArgs e)
		{
			string chucNang = cboKhachHang.SelectedItem.ToString();
			string input = txtInputKH.Text;
			lstKQKH.Items.Clear(); // Sửa lỗi: đảm bảo xóa đúng listbox

			try
			{
				switch (chucNang)
				{
					case "Xuất DV theo tên khách hàng":
						if (string.IsNullOrWhiteSpace(input))
						{
							MessageBox.Show("Vui lòng nhập tên khách hàng vào ô text bên cạnh.");
							return;
						}
						List<DichVu> dsDV = khachHangBLL.GetDichVuTheoTenKH(input);
						HienThiDanhSach(dsDV, lstKQKH);
						break;


				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi xử lý: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}


		//--- HÀM HỖ TRỢ HIỂN THỊ LÊN LISTBOX ---
		private void HienThiDanhSach<T>(List<T> danhSach, ListBox targetListBox)
		{
			targetListBox.Items.Clear(); // Xóa ListBox được chỉ định
			if (danhSach == null || danhSach.Count == 0)
			{
				targetListBox.Items.Add("--- Không tìm thấy kết quả nào ---");
				return;
			}

			foreach (T item in danhSach)
			{
				targetListBox.Items.Add(item.ToString());
			}
		}


		//---  CÁC SỰ KIỆN  ---
		private void cboQuanLy_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Tự động Bật/Tắt ô nhập liệu dựa trên lựa chọn
			CapNhatTrangThaiControlsQL();
		}

		private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Tự động Bật/Tắt ô nhập liệu dựa trên lựa chọn
			CapNhatTrangThaiControlsKH();
		}

		private void CapNhatTrangThaiControlsQL()
		{
			if (cboQuanLy.SelectedItem == null) return;
			string chucNang = cboQuanLy.SelectedItem.ToString();

			// Bật ô nhập liệu cho cả "Tìm" và "Thêm"
			if (chucNang == "Tìm dịch vụ (theo tên/giá)")
			{
				txtInputQL.Enabled = true;
				txtInputQL.Text = goiY_Tim; // Đặt gợi ý
			}
			else if (chucNang == "Thêm dịch vụ mới")
			{
				txtInputQL.Enabled = true;
				txtInputQL.Text = GoiY_Them; // Đặt gợi ý
			}
			else
			{
				txtInputQL.Enabled = false;
				txtInputQL.Text = "";
			}
		}

		private void CapNhatTrangThaiControlsKH()
		{
			if (cboKhachHang.SelectedItem == null) return;
			string chucNang = cboKhachHang.SelectedItem.ToString();

			// Chỉ bật ô nhập liệu khi chức năng là "Xuất DV theo tên khách hàng"
			if (chucNang == "Xuất DV theo tên khách hàng")
			{
				txtInputKH.Enabled = true;
			}
			else
			{
				txtInputKH.Enabled = false;
				txtInputKH.Text = "";
			}
		}

        private void pictureBoxKH_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxQL_Click(object sender, EventArgs e)
        {

        }

        private void lstKQQL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //--- CÁC SỰ KIỆN CÒN LẠI (Ccó thể để trống) ---





    }
}