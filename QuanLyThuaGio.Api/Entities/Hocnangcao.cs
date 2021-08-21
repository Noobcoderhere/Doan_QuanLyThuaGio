#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Hocnangcao
    {
        public int Mahocnangcao { get; set; }
        public string Magv { get; set; }
        public string Namhoc { get; set; }
        public string Ghichu { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
    }
}