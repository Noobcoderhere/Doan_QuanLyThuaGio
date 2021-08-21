using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuanLyThuaGio.Api.Entities;
#nullable disable

namespace QuanLyThuaGio.Api.Data
{
    public partial class QUANLYTHUAGIOContext : DbContext
    {
        public QUANLYTHUAGIOContext()
        {
        }

        public QUANLYTHUAGIOContext(DbContextOptions<QUANLYTHUAGIOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bomon> Bomons { get; set; }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Doantotnghiep> Doantotnghieps { get; set; }
        public virtual DbSet<Giangday> Giangdays { get; set; }
        public virtual DbSet<Giaovien> Giaoviens { get; set; }
        public virtual DbSet<Giaoviennckh> Giaoviennckhs { get; set; }
        public virtual DbSet<Giochuan> Giochuans { get; set; }
        public virtual DbSet<Hedaotao> Hedaotaos { get; set; }
        public virtual DbSet<Hocnangcao> Hocnangcaos { get; set; }
        public virtual DbSet<Huongdannckh> Huongdannckhs { get; set; }
        public virtual DbSet<Loaimon> Loaimons { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<Monhoc> Monhocs { get; set; }
        public virtual DbSet<Qlphongmay> Qlphongmays { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=QUANLYTHUAGIO;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bomon>(entity =>
            {
                entity.HasKey(e => e.Mabomon)
                    .HasName("PK__BOMON__DA56F7C96FF731F5");

                entity.ToTable("BOMON");

                entity.Property(e => e.Mabomon)
                    .HasMaxLength(50)
                    .HasColumnName("MABOMON");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(50)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Tenbomon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TENBOMON");
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.Machucvu)
                    .HasName("PK__CHUCVU__9FA9FD6A82D22DD5");

                entity.ToTable("CHUCVU");

                entity.Property(e => e.Machucvu)
                    .HasMaxLength(50)
                    .HasColumnName("MACHUCVU");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Phantramduocgiam).HasColumnName("PHANTRAMDUOCGIAM");

                entity.Property(e => e.Tenchucvu)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TENCHUCVU");
            });

            modelBuilder.Entity<Doantotnghiep>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__DOANTOTN__3214CCBF3873EF70");

                entity.ToTable("DOANTOTNGHIEP");

                entity.Property(e => e.Ma)
                    .ValueGeneratedNever()
                    .HasColumnName("MA");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Magv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Malop)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MALOP");

                entity.Property(e => e.Namhoc)
                    .HasMaxLength(30)
                    .HasColumnName("NAMHOC");

                entity.Property(e => e.Sodetai).HasColumnName("SODETAI");

                entity.Property(e => e.Sodoanpbien).HasColumnName("SODOANPBIEN");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Doantotnghieps)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIDATN");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Doantotnghieps)
                    .HasForeignKey(d => d.Malop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIDATN1");
            });

            modelBuilder.Entity<Giangday>(entity =>
            {
                entity.HasKey(e => new { e.Magv, e.Malop, e.Mamon })
                    .HasName("PK__GIANGDAY__E3E795790771864D");

                entity.ToTable("GIANGDAY");

                entity.Property(e => e.Magv)
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Malop)
                    .HasMaxLength(50)
                    .HasColumnName("MALOP");

                entity.Property(e => e.Mamon)
                    .HasMaxLength(50)
                    .HasColumnName("MAMON");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Namhoc)
                    .HasMaxLength(30)
                    .HasColumnName("NAMHOC");

                entity.Property(e => e.Sosv).HasColumnName("SOSV");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Giangdays)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIGIANGDAY1");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Giangdays)
                    .HasForeignKey(d => d.Malop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIGIANGDAY2");

                entity.HasOne(d => d.MamonNavigation)
                    .WithMany(p => p.Giangdays)
                    .HasForeignKey(d => d.Mamon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIGIANGDAY3");
            });

            modelBuilder.Entity<Giaovien>(entity =>
            {
                entity.HasKey(e => e.Magv)
                    .HasName("PK__GIAOVIEN__603F38B1184FF9AB");

                entity.ToTable("GIAOVIEN");

                entity.HasIndex(e => e.Dienthoai, "UQ__GIAOVIEN__9D6E2016C395A195")
                    .IsUnique();

                entity.Property(e => e.Magv)
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Anh)
                    .HasMaxLength(500)
                    .HasColumnName("ANH");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(200)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(15)
                    .HasColumnName("DIENTHOAI");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Gioitinh)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.Mabomon)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MABOMON");

                entity.Property(e => e.Machucdanh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MACHUCDANH");

                entity.Property(e => e.Machucvu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MACHUCVU");

                entity.Property(e => e.Namvaolam)
                    .HasMaxLength(50)
                    .HasColumnName("NAMVAOLAM");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Socmtnd)
                    .HasMaxLength(50)
                    .HasColumnName("SOCMTND");

                entity.Property(e => e.Tengv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TENGV");

                entity.Property(e => e.Trinhdohocvan)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TRINHDOHOCVAN");

                entity.HasOne(d => d.MabomonNavigation)
                    .WithMany(p => p.Giaoviens)
                    .HasForeignKey(d => d.Mabomon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KNGV");

                entity.HasOne(d => d.MachucdanhNavigation)
                    .WithMany(p => p.Giaoviens)
                    .HasForeignKey(d => d.Machucdanh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KNGV2");

                entity.HasOne(d => d.MachucvuNavigation)
                    .WithMany(p => p.Giaoviens)
                    .HasForeignKey(d => d.Machucvu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KNGV1");
            });

            modelBuilder.Entity<Giaoviennckh>(entity =>
            {
                entity.HasKey(e => e.Madetai)
                    .HasName("PK__GIAOVIEN__01E3920D77C9E0B0");

                entity.ToTable("GIAOVIENNCKH");

                entity.Property(e => e.Madetai)
                    .HasMaxLength(50)
                    .HasColumnName("MADETAI");

                entity.Property(e => e.Cap)
                    .HasMaxLength(100)
                    .HasColumnName("CAP");

                entity.Property(e => e.Gichu)
                    .HasMaxLength(100)
                    .HasColumnName("GICHU");

                entity.Property(e => e.Magv)
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Namthamgianc)
                    .HasMaxLength(30)
                    .HasColumnName("NAMTHAMGIANC");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Giaoviennckhs)
                    .HasForeignKey(d => d.Magv)
                    .HasConstraintName("KHOANGOAIGIAOVIENNCKH");
            });

            modelBuilder.Entity<Giochuan>(entity =>
            {
                entity.HasKey(e => e.Machucdanh)
                    .HasName("PK__GIOCHUAN__036463CEE29EB227");

                entity.ToTable("GIOCHUAN");

                entity.Property(e => e.Machucdanh)
                    .HasMaxLength(50)
                    .HasColumnName("MACHUCDANH");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Sogiochuan).HasColumnName("SOGIOCHUAN");

                entity.Property(e => e.Tenchucdanh)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TENCHUCDANH");
            });

            modelBuilder.Entity<Hedaotao>(entity =>
            {
                entity.HasKey(e => e.Mahedt)
                    .HasName("PK__HEDAOTAO__1AB2F6CA862D5DB2");

                entity.ToTable("HEDAOTAO");

                entity.Property(e => e.Mahedt)
                    .HasMaxLength(50)
                    .HasColumnName("MAHEDT");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(150)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Sobuoitren1dvht).HasColumnName("SOBUOITREN1DVHT");

                entity.Property(e => e.Tenhedt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TENHEDT");
            });

            modelBuilder.Entity<Hocnangcao>(entity =>
            {
                entity.HasKey(e => e.Mahocnangcao)
                    .HasName("PK__HOCNANGC__0564F01BB4084AB1");

                entity.ToTable("HOCNANGCAO");

                entity.Property(e => e.Mahocnangcao)
                    .ValueGeneratedNever()
                    .HasColumnName("MAHOCNANGCAO");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Magv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Namhoc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("NAMHOC");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Hocnangcaos)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIHOCNGANGCAO1");
            });

            modelBuilder.Entity<Huongdannckh>(entity =>
            {
                entity.HasKey(e => e.Manckh)
                    .HasName("PK__HUONGDAN__110E1680650A347A");

                entity.ToTable("HUONGDANNCKH");

                entity.Property(e => e.Manckh)
                    .HasMaxLength(50)
                    .HasColumnName("MANCKH");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Magv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Namhoc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("NAMHOC");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Svnam)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SVNAM");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Huongdannckhs)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIHDNCKH");
            });

            modelBuilder.Entity<Loaimon>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LOAIMON__2F633F23A4437E0D");

                entity.ToTable("LOAIMON");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(50)
                    .HasColumnName("MALOAI");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Tenloai)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TENLOAI");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.Malop)
                    .HasName("PK__LOP__7A3DE211EB984BB4");

                entity.ToTable("LOP");

                entity.Property(e => e.Malop)
                    .HasMaxLength(50)
                    .HasColumnName("MALOP");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Hinhthucdt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("HINHTHUCDT");

                entity.Property(e => e.Mahedt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MAHEDT");

                entity.Property(e => e.Siso).HasColumnName("SISO");

                entity.Property(e => e.Tenlop)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TENLOP");

                entity.HasOne(d => d.MahedtNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.Mahedt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAILOP");
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.Mamon)
                    .HasName("PK__MONHOC__7B73E985A3165F1F");

                entity.ToTable("MONHOC");

                entity.Property(e => e.Mamon)
                    .HasMaxLength(50)
                    .HasColumnName("MAMON");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Mahdt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MAHDT");

                entity.Property(e => e.Maloai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MALOAI");

                entity.Property(e => e.Sotiet).HasColumnName("SOTIET");

                entity.Property(e => e.Tenmon)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TENMON");

                entity.HasOne(d => d.MahdtNavigation)
                    .WithMany(p => p.Monhocs)
                    .HasForeignKey(d => d.Mahdt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KNMONHOC1");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Monhocs)
                    .HasForeignKey(d => d.Maloai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KNMONHOC");
            });

            modelBuilder.Entity<Qlphongmay>(entity =>
            {
                entity.HasKey(e => e.Maql)
                    .HasName("PK__QLPHONGM__602379F42DF9285E");

                entity.ToTable("QLPHONGMAY");

                entity.Property(e => e.Maql)
                    .HasMaxLength(50)
                    .HasColumnName("MAQL");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Magv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Soluongpm).HasColumnName("SOLUONGPM");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Qlphongmays)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KHOANGOAIQLPM");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Tendangnhap)
                    .HasName("PK__TAIKHOAN__6C836FE448AA0A0B");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(50)
                    .HasColumnName("TENDANGNHAP");

                entity.Property(e => e.Magv)
                    .HasMaxLength(50)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MATKHAU");

                entity.Property(e => e.Ngaytaotk)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYTAOTK");

                entity.Property(e => e.Quyen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("QUYEN");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Taikhoans)
                    .HasForeignKey(d => d.Magv)
                    .HasConstraintName("KHOANGOAITK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
