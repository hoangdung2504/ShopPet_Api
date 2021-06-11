using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_2021_API.Entities
{
    public class BaiViet
    {
        [Key]
        public int BaiVietId { get; set; }
        public int UserId { get; set; }
        public string TieuDe { get; set; }      
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public string Path_Img { get; set; }// ảnh tiêu đề
        public string path_mota { get; set; }// ảnh mô tả chi tiết
        public DateTime NgaySua { get; set; }
        public int Gia { get; set; }
        public string LoaiSanPham { get; set; }
        public string Ten { get; set; } //tên sp
        public string Giong { get; set; } // giống
        public string MauSac { get; set; } //màu sắc
        public string GioiTinh { get; set; }

        public string Tuoi { get; set; }
        public string DiaChi { get; set; }
       
        public string SDTLienHe { get; set; }

        public virtual User User { get; set; }
    }
}
