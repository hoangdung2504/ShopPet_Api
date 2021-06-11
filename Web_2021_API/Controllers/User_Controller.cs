using Microsoft.AspNetCore.Http;
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
    public class User_Controller
    {
        private readonly AppDbContext _dbContext;
        public User_Controller(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("GetById")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<User_List> Get_NguoiDung([FromBody] JsonElement input)
        {
            User us = new User();
            User_List ul = new User_List();
          
            us = JsonConvert.DeserializeObject<User>(input.ToString());
            try
            {
                if (us.TenDangNhap == "ALL")
                {
                    var _user = _dbContext.users.Include(x=>x.Quyen).ThenInclude(c=>c.BaiViet).AsQueryable();
                    ul.res_code = "000";
                    ul.users = _user.ToList();
                }
                else
                {
                    var _user = _dbContext.users.Include(x=>x.Quyen).ThenInclude(c => c.BaiViet).Where(x => x.TenDangNhap == us.TenDangNhap).AsQueryable();
                    ul.res_code = "000";
                    ul.users = _user.ToList();
                }
            }
            catch (Exception ex)
            {
                ul.res_code = "001";//lỗi
                throw ex;
            }
            return ul;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<User_List> Tao_Nguoi_Dung([FromBody] JsonElement input)
        {
            User us = new User();
            User_List md = new User_List();
            try
            {
              
                us = JsonConvert.DeserializeObject<User>(input.ToString());

                if (_dbContext.users.Any(x => x.TenDangNhap == us.TenDangNhap))
                {
                    md.res_code = "001";//tk đã tồn tại
                }
                else if (us.MatKhau.Length <=5)
                {
                    md.res_code = "002";//mk dài hơn 6 kí tự
                }
                else if (_dbContext.users.Any(x => x.Email == us.Email))
                {
                    md.res_code = "003";//email đã có
                }
                else if (_dbContext.users.Any(x => x.SDT == us.SDT))
                {
                    md.res_code = "004";//sdt đã đăng kí
                }
               

                else
                {
                    md.res_code = "000";// thanh cong
                    us.NgayTao = DateTime.Now;
                    us.Status = "A";
                    us.QuyenId = 3;
                    us.SoLanDangNhapFail = 0;                  
                     _dbContext.users.Add(us);
                    await _dbContext.SaveChangesAsync();
                    md.users = _dbContext.users.Where(x => x.TenDangNhap == us.TenDangNhap).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return md;
        }

        [Route("UpDate")]
        [HttpPost]
        public async Task<User_List> UpDate([FromBody] JsonElement input)
        {
            User us = new User();
            User_List md = new User_List();
            try
            {

                us = JsonConvert.DeserializeObject<User>(input.ToString());

                var user = _dbContext.users.FirstOrDefault(x => x.TenDangNhap == us.TenDangNhap);
                var quyen = _dbContext.quyens.FirstOrDefault(x => x.Txt_Quyen == us.Quyen.Txt_Quyen);
                if (user != null)
                {
                    user.TenDangNhap = us.TenDangNhap;
                    user.MatKhau = us.MatKhau;
                    user.HoTen = us.HoTen;
                    user.Email = us.Email;
                    user.SDT = us.SDT;
                    user.Path_img = us.Path_img;
                    if(quyen != null) {
                        user.QuyenId = quyen.QuyenId;
                    }
                    else
                    {
                        user.QuyenId = 3;
                    }
                  
                    user.SoLanDangNhapFail = us.SoLanDangNhapFail;
                    if (us.Status == "")
                    {
                       
                        user.Status = "A";
                    }
                    else
                    {
                        user.Status = us.Status;
                    }
                  
                     _dbContext.SaveChanges();
                    md.users = _dbContext.users.Where(x => x.TenDangNhap == us.TenDangNhap).ToList();
                    md.res_code = "000";// thanh cong
                }                                
            }
            catch (Exception ex)
            {
                throw ex;
                md.res_code = "001";// thất bại
            }
            return md;
        }

    }
}
