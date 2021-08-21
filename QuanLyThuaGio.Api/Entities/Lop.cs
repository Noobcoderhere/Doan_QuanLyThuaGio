using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Lop
    {
        public Lop()
        {
            Doantotnghieps = new HashSet<Doantotnghiep>();
            Giangdays = new HashSet<Giangday>();
        }

        public string Mahedt { get; set; }
        public string Malop { get; set; }
        public string Tenlop { get; set; }
        public int Siso { get; set; }
        public string Hinhthucdt { get; set; }
        public string Ghichu { get; set; }

        public virtual Hedaotao MahedtNavigation { get; set; }
        public virtual ICollection<Doantotnghiep> Doantotnghieps { get; set; }
        public virtual ICollection<Giangday> Giangdays { get; set; }
    }
}