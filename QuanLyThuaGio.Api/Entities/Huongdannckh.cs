#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Huongdannckh
    {
        public string Magv { get; set; }
        public string Manckh { get; set; }
        public int Soluong { get; set; }
        public string Svnam { get; set; }
        public string Namhoc { get; set; }
        public string Ghichu { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
    }
}