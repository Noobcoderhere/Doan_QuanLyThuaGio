#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Qlphongmay
    {
        public string Maql { get; set; }
        public string Magv { get; set; }
        public int Soluongpm { get; set; }
        public string Ghichu { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
    }
}