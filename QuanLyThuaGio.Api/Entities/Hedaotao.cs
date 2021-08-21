using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Hedaotao
    {
        public Hedaotao()
        {
            Lops = new HashSet<Lop>();
            Monhocs = new HashSet<Monhoc>();
        }

        public string Mahedt { get; set; }
        public string Tenhedt { get; set; }
        public int? Sobuoitren1dvht { get; set; }
        public string Ghichu { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }
        public virtual ICollection<Monhoc> Monhocs { get; set; }
    }
}