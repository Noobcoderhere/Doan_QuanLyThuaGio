using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            Giangdays = new HashSet<Giangday>();
        }

        public string Mahdt { get; set; }
        public string Maloai { get; set; }
        public string Mamon { get; set; }
        public string Tenmon { get; set; }
        public int Sotiet { get; set; }
        public string Ghichu { get; set; }

        public virtual Hedaotao MahdtNavigation { get; set; }
        public virtual Loaimon MaloaiNavigation { get; set; }
        public virtual ICollection<Giangday> Giangdays { get; set; }
    }
}