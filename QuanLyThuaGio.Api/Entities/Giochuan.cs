using System.Collections.Generic;

#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Giochuan
    {
        public Giochuan()
        {
            Giaoviens = new HashSet<Giaovien>();
        }

        public string Machucdanh { get; set; }
        public string Tenchucdanh { get; set; }
        public int Sogiochuan { get; set; }
        public string Ghichu { get; set; }

        public virtual ICollection<Giaovien> Giaoviens { get; set; }
    }
}