using QuanLyThuaGio.Api.Enums;
using System;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Taikhoan
    {
        public string Tendangnhap { get; set; }
        public string Matkhau { get; set; }
        public string Magv { get; set; }
        public Quyen Quyen { get; set; }
        public DateTime? Ngaytaotk { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
    }
}