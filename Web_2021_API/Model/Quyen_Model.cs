using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_2021_API.Entities;

namespace Web_2021_API.Model
{
    public class Lst_quyen
    {
        public string res_code { get; set; }
        public string desc { get; set; }
        public List<Quyen> quyens { get; set; }
    }

   
}