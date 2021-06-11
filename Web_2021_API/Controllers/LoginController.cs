using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using web_2021_API;
using Web_2021_API.Entities;
using Web_2021_API.Model;


namespace Web_2021_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController 
    {
        private readonly AppDbContext _dbContext;
        public LoginController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("login")]
        [HttpPost]
        public async Task<User_List> Login([FromBody] JsonElement input)
        {
            User_List md = new User_List();
            try
            {
                User us = new User();
                us = JsonConvert.DeserializeObject<User>(input.ToString());

                var result_id = _dbContext.users.FirstOrDefault(x => x.TenDangNhap == us.TenDangNhap);
                
               var result_pass = _dbContext.users.FirstOrDefault(x => x.TenDangNhap == us.TenDangNhap && x.MatKhau != us.MatKhau);               
              var  result_fail = _dbContext.users.FirstOrDefault(x => x.TenDangNhap == us.TenDangNhap && x.MatKhau == us.MatKhau && x.SoLanDangNhapFail > 5);
               

                var  result_stt = _dbContext.users.FirstOrDefault(x => x.TenDangNhap == us.TenDangNhap && x.MatKhau == us.MatKhau && x.SoLanDangNhapFail <=5 && x.Status == "C");
                if (result_id == null)
                {
                    md.res_code = "001";//tk khồng tồn tại
                }
                else if (result_pass != null)
                {
                    md.res_code = "002";//k đúng mk
                }
                else if (result_fail != null)
                {
                    md.res_code = "003";//đăng nhập quá số lần
                }
                else if (result_stt != null)
                {
                    md.res_code = "004";//tk  bị đóng
                }
                else
                {
                    md.res_code = "000";// thanh cong
                    var result = _dbContext.users.Include(x => x.Quyen).AsQueryable().Where(x => x.TenDangNhap == us.TenDangNhap);
                    md.users = result.ToList();
                    
                }
            }
            catch (Exception)
            {

               

                throw;
            }
            return md;
        }
    }
}
