using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_2021_API.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int QuyenId { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; }
        public int SoLanDangNhapFail { get; set; }
        public string? SDT { get; set; }
        public string? Email { get; set; }
        public string Status { get; set; }
        public string? Path_img { get; set; }
        public ICollection<BaiViet>  BaiViet { get; set; }
        public virtual Quyen Quyen { get; set; }
    }
}
