using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MagazaWeb.Models
{
    public class MagazaContext : IdentityDbContext<Kullanici>
    {
        public MagazaContext() { }
        public MagazaContext(DbContextOptions<MagazaContext> options) : base(options) { }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Degerlendirme> Degerlendirmeler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            OrnekVeri(builder);
        }

        private void OrnekVeri(ModelBuilder builder)
        {
            IdentityRole roleAdmin = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
            builder.Entity<IdentityRole>().HasData(roleAdmin);

            IdentityRole roleUser = new IdentityRole { Name = "User", NormalizedName = "USER" };
            builder.Entity<IdentityRole>().HasData(roleUser);

            Kullanici user = new Kullanici { AdSoyad = "Admin", UserName = "Admin", Email = "admin@gmail.com", EmailConfirmed = true, NormalizedUserName = "ADMIN", NormalizedEmail = "ADMIN@GMAIL.COM" };
            user.PasswordHash = new PasswordHasher<Kullanici>().HashPassword(user, "AAaa11..");
            builder.Entity<Kullanici>().HasData(user);

            IdentityUserRole<string> userRole = new IdentityUserRole<string> { UserId = user.Id, RoleId = roleAdmin.Id };
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);


            Kategori kategori;

            kategori = new Kategori { Id = 1, KategoriAdi = "Telefon", Slogan = "Son model telefonlar" };
            builder.Entity<Kategori>().HasData(kategori);

            kategori = new Kategori { Id = 2, KategoriAdi = "Notebook", Slogan = "Yeni nesil elektronik ürünler" };
            builder.Entity<Kategori>().HasData(kategori);

            kategori = new Kategori { Id = 3, KategoriAdi = "Televizyon", Slogan = "Büyük ekran Full HD TV ler" };
            builder.Entity<Kategori>().HasData(kategori);

            kategori = new Kategori { Id = 4, KategoriAdi = "Diğer", Slogan = "Aradığınız herşey uygun fiyata" };
            builder.Entity<Kategori>().HasData(kategori);


            Urun urun;

            urun = new Urun
            {
                Id = 1,
                UrunAdi = "Apple iPhone 13",
                Fiyat = 25000,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. [onemli]Quis voluptas reiciendis,[/onemli] iste accusantium ipsa magni culpa ad distinctio?",
                Stok = 40,
                EklenmeTarihi = new DateTime(2022, 11, 20),
                KategoriId = 1
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 2,
                UrunAdi = "Apple iPhone 14",
                Fiyat = 30000,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis voluptas reiciendis, iste accusantium ipsa magni culpa ad distinctio? At illo doloribus cupiditate amet ex eligendi, qui optio ducimus eaque deleniti molestiae eos praesentium soluta fugiat? Nulla totam ipsam explicabo quo nam dolorem numquam dolore vero velit, asperiores sequi odit in.
        Laborum nulla molestiae sit vitae. Praesentium accusamus quidem blanditiis aliquam voluptatum ab ad magni soluta, maxime cupiditate et sint. Minus corporis quae quisquam pariatur enim architecto quo aliquam, molestias expedita sit consequatur accusantium ut dignissimos ducimus sapiente, natus repudiandae itaque suscipit officiis, eius fuga corrupti rerum fugit. Sunt, illo nulla.",
                Stok = 100,
                EklenmeTarihi = DateTime.Now,
                KategoriId = 1
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 3,
                UrunAdi = "Samsung A55",
                Fiyat = 20000,
                Aciklama = @"Lorem ipsum dolor sit amet.",
                Stok = 5,
                EklenmeTarihi = DateTime.Now,
                KategoriId = 1
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 4,
                UrunAdi = "Samsung Galaxy S22",
                Fiyat = 19900,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.
Sequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?
[onemli]Pariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo![/onemli]",
                Stok = 50,
                EklenmeTarihi = DateTime.Now.AddMinutes(-40),
                KategoriId = 1
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 5,
                UrunAdi = "Xiaomi Note 10 Pro",
                Fiyat = 20000,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.
Sequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?
Pariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo!",
                Stok = 10,
                EklenmeTarihi = new DateTime(2023, 5, 5),
                KategoriId = 1
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 6,
                UrunAdi = "Lenovo Ideapad 3",
                Fiyat = 23999,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.
Sequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?",
                Stok = 8,
                EklenmeTarihi = new DateTime(2022, 11, 25),
                KategoriId = 2
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 7,
                UrunAdi = "Apple Macbook Pro",
                Fiyat = 59999,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.
Sequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?
Pariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo!",
                Stok = 1,
                EklenmeTarihi = DateTime.Now.AddDays(-15),
                KategoriId = 2
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 8,
                UrunAdi = "Samsung QE 65B750 TV",
                Fiyat = 34500,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.",
                Stok = 50,
                EklenmeTarihi = DateTime.Now.AddMonths(-2),
                KategoriId = 3
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 9,
                UrunAdi = "LG 55UQ81 TV",
                Fiyat = 29999,
                Aciklama = @"Lorem ipsum dolor sit amet.",
                Stok = 15,
                EklenmeTarihi = DateTime.Now.AddMinutes(-10),
                KategoriId = 3
            };
            builder.Entity<Urun>().HasData(urun);

            urun = new Urun
            {
                Id = 10,
                UrunAdi = "LG Bluetooth Kulaklık",
                Fiyat = 250,
                Aciklama = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Porro, suscipit.
Architecto, eum quasi amet porro voluptatum consequatur? Numquam, quas voluptate.",
                Stok = 100,
                EklenmeTarihi = DateTime.Now.AddHours(-3),
                KategoriId = 4
            };
            builder.Entity<Urun>().HasData(urun);

        }
    }
}