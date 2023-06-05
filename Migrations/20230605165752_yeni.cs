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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    AdSoyad = table.Column<string>(type: "longtext", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Iller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IlAdi = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iller", x => x.Id);
                })
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AdSoyad = table.Column<string>(type: "longtext", nullable: false),
                    Telefon = table.Column<string>(type: "longtext", nullable: false),
                    Adres = table.Column<string>(type: "longtext", nullable: false),
                    Il = table.Column<string>(type: "longtext", nullable: false),
                    Ilce = table.Column<string>(type: "longtext", nullable: false),
                    OdemeTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IlceAdi = table.Column<string>(type: "longtext", nullable: false),
                    IlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilceler_Iller_IlId",
                        column: x => x.IlId,
                        principalTable: "Iller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "SiparisUrunu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    UrunAdi = table.Column<string>(type: "longtext", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Toplam = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisUrunu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisUrunu_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Degerlendirmeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Yorum = table.Column<string>(type: "longtext", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Onay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degerlendirmeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_tblUrunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "tblUrunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4d0375c-7b45-4779-99ed-0f9b293ddacd", "015ecb9c-558f-4ef7-aa6c-9c9e197b175f", "Admin", "ADMIN" },
                    { "fc2ae8e0-c1fe-42a6-a482-1b9b2b8a3908", "b43fca4d-3c0f-4c98-a380-dfdcd859d476", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdSoyad", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5591c08f-c164-4985-afef-2dea549efc33", 0, "Admin", "13353adb-f1cd-44fa-8f41-5454eafe3aad", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPi4/g1WAvxs9ddbCTi4mYNnuiCpRFXYeEGYpjTQr+KRhIcWHJwJsKbL6iEoiyXpBQ==", null, false, "2d3611ff-1b0f-4f9c-919f-44fb15555be3", false, "Admin" });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c4d0375c-7b45-4779-99ed-0f9b293ddacd", "5591c08f-c164-4985-afef-2dea549efc33" });

            migrationBuilder.InsertData(
                table: "tblUrunler",
                columns: new[] { "Id", "Bilgi", "EklenmeTarihi", "Fiyat", "KategoriId", "ResimAdi", "Stok", "UrunAdi" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. [onemli]Quis voluptas reiciendis,[/onemli] iste accusantium ipsa magni culpa ad distinctio?", new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000m, 1, null, 40, "Apple iPhone 13" },
                    { 2, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis voluptas reiciendis, iste accusantium ipsa magni culpa ad distinctio? At illo doloribus cupiditate amet ex eligendi, qui optio ducimus eaque deleniti molestiae eos praesentium soluta fugiat? Nulla totam ipsam explicabo quo nam dolorem numquam dolore vero velit, asperiores sequi odit in.\r\n        Laborum nulla molestiae sit vitae. Praesentium accusamus quidem blanditiis aliquam voluptatum ab ad magni soluta, maxime cupiditate et sint. Minus corporis quae quisquam pariatur enim architecto quo aliquam, molestias expedita sit consequatur accusantium ut dignissimos ducimus sapiente, natus repudiandae itaque suscipit officiis, eius fuga corrupti rerum fugit. Sunt, illo nulla.", new DateTime(2023, 6, 5, 19, 57, 52, 243, DateTimeKind.Local).AddTicks(7629), 30000m, 1, null, 100, "Apple iPhone 14" },
                    { 3, "Lorem ipsum dolor sit amet.", new DateTime(2023, 6, 5, 19, 57, 52, 243, DateTimeKind.Local).AddTicks(7653), 20000m, 1, null, 5, "Samsung A55" },
                    { 4, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?\r\n[onemli]Pariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo![/onemli]", new DateTime(2023, 6, 5, 19, 17, 52, 243, DateTimeKind.Local).AddTicks(7664), 19900m, 1, null, 50, "Samsung Galaxy S22" },
                    { 5, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?\r\nPariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo!", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m, 1, null, 10, "Xiaomi Note 10 Pro" },
                    { 6, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?", new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 23999m, 2, null, 8, "Lenovo Ideapad 3" },
                    { 7, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.\r\nSequi aperiam ullam distinctio atque, tempora voluptates perspiciatis cupiditate cumque itaque unde vero neque ratione, maxime culpa nostrum adipisci quibusdam?\r\nPariatur natus assumenda recusandae distinctio totam ipsum quo dolorem amet, dignissimos sunt quasi laboriosam ex maiores vero provident eius nemo!", new DateTime(2023, 5, 21, 19, 57, 52, 243, DateTimeKind.Local).AddTicks(7699), 59999m, 2, null, 1, "Apple Macbook Pro" },
                    { 8, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe, natus? Consequatur fugit vel assumenda iusto consectetur amet alias ex aut.", new DateTime(2023, 4, 5, 19, 57, 52, 243, DateTimeKind.Local).AddTicks(7711), 34500m, 3, null, 50, "Samsung QE 65B750 TV" },
                    { 9, "Lorem ipsum dolor sit amet.", new DateTime(2023, 6, 5, 19, 47, 52, 243, DateTimeKind.Local).AddTicks(7730), 29999m, 3, null, 15, "LG 55UQ81 TV" },
                    { 10, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Porro, suscipit.\r\nArchitecto, eum quasi amet porro voluptatum consequatur? Numquam, quas voluptate.", new DateTime(2023, 6, 5, 16, 57, 52, 243, DateTimeKind.Local).AddTicks(7741), 250m, 4, null, 100, "LG Bluetooth Kulaklık" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_KullaniciId",
                table: "Degerlendirmeler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_UrunId",
                table: "Degerlendirmeler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_IlId",
                table: "Ilceler",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_KullaniciId",
                table: "Siparisler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisUrunu_SiparisId",
                table: "SiparisUrunu",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUrunler_KategoriId",
                table: "tblUrunler",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Degerlendirmeler");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "SiparisUrunu");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblUrunler");

            migrationBuilder.DropTable(
                name: "Iller");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
