using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Giaovien
    {
        public Giaovien()
        {
            Doantotnghieps = new HashSet<Doantotnghiep>();
            Giangdays = new HashSet<Giangday>();
            Giaoviennckhs = new HashSet<Giaoviennckh>();
            Hocnangcaos = new HashSet<Hocnangcao>();
            Huongdannckhs = new HashSet<Huongdannckh>();
            Qlphongmays = new HashSet<Qlphongmay>();
            Taikhoans = new HashSet<Taikhoan>();
        }

        public string Magv { get; set; }
        public string Tengv { get; set; }
        public string Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Socmtnd { get; set; }
        public string Anh { get; set; }
        public string Trinhdohocvan { get; set; }
        public string Machucdanh { get; set; }
        public string Machucvu { get; set; }
        public string Mabomon { get; set; }
        public string Namvaolam { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public string Ghichu { get; set; }

        public virtual Bomon MabomonNavigation { get; set; }
        public virtual Giochuan MachucdanhNavigation { get; set; }
        public virtual Chucvu MachucvuNavigation { get; set; }
        public virtual ICollection<Doantotnghiep> Doantotnghieps { get; set; }
        public virtual ICollection<Giangday> Giangdays { get; set; }
        public virtual ICollection<Giaoviennckh> Giaoviennckhs { get; set; }
        public virtual ICollection<Hocnangcao> Hocnangcaos { get; set; }
        public virtual ICollection<Huongdannckh> Huongdannckhs { get; set; }
        public virtual ICollection<Qlphongmay> Qlphongmays { get; set; }
        public virtual ICollection<Taikhoan> Taikhoans { get; set; }
    }
}