using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Chucvu
    {
        public Chucvu()
        {
            Giaoviens = new HashSet<Giaovien>();
        }

        public string Machucvu { get; set; }
        public string Tenchucvu { get; set; }
        public int? Phantramduocgiam { get; set; }
        public string Ghichu { get; set; }

        public virtual ICollection<Giaovien> Giaoviens { get; set; }
    }
}