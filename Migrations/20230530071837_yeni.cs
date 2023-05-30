using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagazaWeb.Migrations
{
    /// <inheritdoc />
    public partial class yeni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    KategoriAdi = table.Column<string>(type: "longtext", nullable: false),
                    Slogan = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblUrunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UrunAdi = table.Column<string>(type: "longtext", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bilgi = table.Column<string>(type: "longtext", nullable: true),
                    Stok = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ResimAdi = table.Column<string>(type: "longtext", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUrunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblUrunler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "KategoriAdi", "Slogan" },
                values: new object[,]
                {
                    { 1, "Telefon", "Son model telefonlar" },
                    { 2, "Notebook", "Yeni nesil elektronik ürünler" },
                    { 3, "Televizyon", "Büyük ekran Full HD TV ler" },
                    { 4, "Diğer", "Aradığınız herşey uygun fiyata" }
                });

            migrationBuilder.InsertData(
                table: "tblUrunler",
                columns: new[] { "Id", "Bilgi", "EklenmeTarihi", "Fiyat", "KategoriId", "ResimAdi", "Stok", "UrunAdi" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. [onemli]Quis voluptas reiciendis,[/onemli] iste accusantium ipsa magni culpa ad distinctio?", new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000m, 1, null, 40, "Apple iPhone 13" },
                    { 2, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis voluptas reiciendis, iste accusantium ipsa magni culpa ad distinctio? At illo doloribus cupiditate amet ex eligendi, qui optio ducimus eaque deleniti molestiae eos praesentium soluta fugiat? Nulla totam ipsam explicabo quo nam dolorem numquam dolore vero velit, asperiores sequi odit in.\r\n        Laborum nulla molestiae sit vitae. Praesentium accusamus quidem blanditiis aliquam voluptatum ab ad magni soluta, maxime cupiditate et sint. Minus corporis quae quisquam pariatur enim architecto quo aliquam, molestias expedita sit consequatur accusantium ut dignissimos ducimus sapiente, natus repudiandae itaque suscipit officiis, eius fuga corrupti rerum fugit. Sunt, illo nulla.", new DateTime(2023, 5, 30, 10, 18, 36, 991, DateTimeKind.Local).AddTicks(6431), 30000m, 1, null, 100, "Apple iPhone 14" },
                    { 3, "Lorem ipsum dolor sit amet.", new DateTime(2023, 5, 30, 10, 18, 36, 991, DateTimeKind.Local).AddTicks(6449), 20000m, 1, null, 5, "Samsung A55" },
                    { 4, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?\r\n[onemli]Pariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo![/onemli]", new DateTime(2023, 5, 30, 9, 38, 36, 991, DateTimeKind.Local).AddTicks(6458), 19900m, 1, null, 50, "Samsung Galaxy S22" },
                    { 5, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?\r\nPariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo!", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m, 1, null, 10, "Xiaomi Note 10 Pro" },
                    { 6, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?", new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 23999m, 2, null, 8, "Lenovo Ideapad 3" },
                    { 7, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?\r\nPariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo!", new DateTime(2023, 5, 15, 10, 18, 36, 991, DateTimeKind.Local).AddTicks(6494), 59999m, 2, null, 1, "Apple Macbook Pro" },
                    { 8, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.", new DateTime(2023, 3, 30, 10, 18, 36, 991, DateTimeKind.Local).AddTicks(6503), 34500m, 3, null, 50, "Samsung QE 65B750 TV" },
                    { 9, "Lorem ipsum dolor sit amet.", new DateTime(2023, 5, 30, 10, 8, 36, 991, DateTimeKind.Local).AddTicks(6529), 29999m, 3, null, 15, "LG 55UQ81 TV" },
                    { 10, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Porro, suscipit.\r\nArchitecto, eum quasi amet porro voluptatum consequatur? Numquam, quas voluptate.", new DateTime(2023, 5, 30, 7, 18, 36, 991, DateTimeKind.Local).AddTicks(6540), 250m, 4, null, 100, "LG Bluetooth Kulaklık" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUrunler_KategoriId",
                table: "tblUrunler",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUrunler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
