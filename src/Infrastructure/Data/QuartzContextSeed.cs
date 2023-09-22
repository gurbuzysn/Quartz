using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class QuartzContextSeed
    {
        public static async Task SeedAsync(QuartzContext db)
        {
            await db.Database.MigrateAsync();

            if (await db.Categories.AnyAsync() || await db.Brands.AnyAsync() || await db.Products.AnyAsync())
                return;

            var c1 = new Category() { Name = "Mens" };
            var c2 = new Category() { Name = "Ladies" };
            var c3 = new Category() { Name = "Smart Watch" };

            var b1 = new Brand() { Name = "Fossil" };
            var b2 = new Brand() { Name = "Casio" };
            var b3 = new Brand() { Name = "Tissot" };
            var b4 = new Brand() { Name = "Citizen" };

            var p1 = new Product() { Category = c1, Brand = b1, PictureUri = "01.jpg", Price = 211.35m, Name = " Gents Fossil Blue Watch FS6013" };
            var p2 = new Product() { Category = c1, Brand = b1, PictureUri = "02.jpg", Price = 186.42m, Name = " Gents Fossil Blue Watch FS6013" };
            var p3 = new Product() { Category = c1, Brand = b1, PictureUri = "03.jpg", Price = 156.67m, Name = " Gents Fossil Blue Watch FS6013" };
            var p4 = new Product() { Category = c2, Brand = b1, PictureUri = "04.jpg", Price = 122.98m, Name = " Ladies Fossil Blue Watch FS6013" };
            var p5 = new Product() { Category = c2, Brand = b1, PictureUri = "05.jpg", Price = 146.76m, Name = " Ladies Fossil Blue Watch FS6013" };
            var p6 = new Product() { Category = c3, Brand = b1, PictureUri = "06.jpg", Price = 215.43m, Name = " Gents Fossil Blue Watch FS6013" };
            var p7 = new Product() { Category = c1, Brand = b2, PictureUri = "07.jpg", Price = 256.76m, Name = " Mens Fossil Blue Watch FS6013" };
            var p8 = new Product() { Category = c2, Brand = b2, PictureUri = "08.jpg", Price = 316.87m, Name = " Casio Fossil Blue Watch FS6013" };
            var p9 = new Product() { Category = c3, Brand = b3, PictureUri = "09.jpg", Price = 500.00m, Name = " Mens Fossil Blue Watch FS6013" };
            var p10 = new Product() { Category = c2, Brand = b3, PictureUri = "10.jpg", Price = 450.65m, Name = " Ladies Fossil Blue Watch FS6013" };
            var p11 = new Product() { Category = c1, Brand = b4, PictureUri = "11.jpg", Price = 100.00m, Name = " Mens Fossil Blue Watch FS6013" };
            var p12 = new Product() { Category = c2, Brand = b4, PictureUri = "12.jpg", Price = 250.00m, Name = " Citizen Fossil Blue Watch FS6013" };

            db.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            await db.SaveChangesAsync();






        }
    }
}
