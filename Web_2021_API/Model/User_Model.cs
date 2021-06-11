using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_2021_API.Entities;

namespace Web_2021_API.Model
{
    public class User_List
    {
        public string res_code { get; set; }
        public string desc { get; set; }
        public List<User> users { get; set; }
    }

    public class User_Model {
    public string TenDangNhap { get; set; }
    public string HoTen { get; set; }
    public string MatKhau { get; set; }
    public string Quyen { get; set; }
    public DateTime NgayTao { get; set; }
    public int SoLanDangNhapFail { get; set; }
    public string Status { get; set; }
}
}
