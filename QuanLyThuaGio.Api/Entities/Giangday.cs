#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Giangday
    {
        public string Magv { get; set; }
        public string Malop { get; set; }
        public string Mamon { get; set; }
        public int Sosv { get; set; }
        public string Namhoc { get; set; }
        public string Ghichu { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
        public virtual Lop MalopNavigation { get; set; }
        public virtual Monhoc MamonNavigation { get; set; }
    }
}