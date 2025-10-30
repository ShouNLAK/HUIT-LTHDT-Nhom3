using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSPa_DTO
{
    // Sửa lại: interface nên ở trong namespace DTO
    public interface ICapNhatKinhPhi
    {
        void CapNhatKP(); // Sửa lại thành void, hàm này sẽ tự cập nhật giá trị
    }
}