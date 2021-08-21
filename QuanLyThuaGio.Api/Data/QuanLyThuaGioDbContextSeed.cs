using Microsoft.Extensions.Logging;
using QuanLyThuaGio.Api.Entities;
using QuanLyThuaGio.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyThuaGio.Api.Data
{
    public class QuanLyThuaGioDbContextSeed
    {
        public async Task SeedAsync(QUANLYTHUAGIOContext context, ILogger<QuanLyThuaGioDbContextSeed> logger )
        {
            if(!context.Taikhoans.Any())
            {
                context.Taikhoans.Add(new Taikhoan()
                {
                    Tendangnhap = "admin",
                    Matkhau = "admin",
                    Quyen = Quyen.Admin,
                    Magv = "admin"
                });
            }
        }
    }
}
