using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Loaimon
    {
        public Loaimon()
        {
            Monhocs = new HashSet<Monhoc>();
        }

        public string Maloai { get; set; }
        public string Tenloai { get; set; }
        public string Ghichu { get; set; }

        public virtual ICollection<Monhoc> Monhocs { get; set; }
    }
}