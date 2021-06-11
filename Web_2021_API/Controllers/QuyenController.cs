using Microsoft.AspNetCore.Mvc;
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
    public class QuyenController
    {
        private readonly AppDbContext _appDbContext;
        public QuyenController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [Route("get_quyen")]
        [HttpPost]
        public async Task<Lst_quyen> Get_quyen()
        {
            try
            {
                Lst_quyen lq = new Lst_quyen();
                Quyen q = new Quyen();
                lq.quyens = _appDbContext.quyens.AsQueryable().ToList();
                return lq;
            }
            catch (Exception ex)
            {

                throw ex;
            }  
            
        }


    }
}
