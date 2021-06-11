using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_2021_API.Entities
{
    public class Quyen
    {
        [Key]    
        public int QuyenId { get; set; }
        public string Ten_Quyen { get; set; }
        public string Txt_Quyen { get; set; }
        public ICollection<BaiViet> BaiViet { get; set; }
    }
}
