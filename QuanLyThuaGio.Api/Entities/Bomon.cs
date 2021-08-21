using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Bomon
    {
        public Bomon()
        {
            Giaoviens = new HashSet<Giaovien>();
        }

        public string Mabomon { get; set; }
        public string Tenbomon { get; set; }
        public string Ghichu { get; set; }

        public virtual ICollection<Giaovien> Giaoviens { get; set; }
    }
}