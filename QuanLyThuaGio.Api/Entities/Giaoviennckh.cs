#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Giaoviennckh
    {
        public string Magv { get; set; }
        public string Madetai { get; set; }
        public string Cap { get; set; }
        public string Namthamgianc { get; set; }
        public string Gichu { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
    }
}