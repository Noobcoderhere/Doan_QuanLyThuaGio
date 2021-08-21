#nullable disable

namespace QuanLyThuaGio.Api.Entities
{
    public partial class Doantotnghiep
    {
        public string Magv { get; set; }
        public int Ma { get; set; }
        public string Malop { get; set; }
        public int? Sodetai { get; set; }
        public int? Sodoanpbien { get; set; }
        public string Namhoc { get; set; }
        public string Ghichu { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
        public virtual Lop MalopNavigation { get; set; }
    }
}