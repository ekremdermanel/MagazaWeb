using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazaWeb.Migrations
{
    /// <inheritdoc />
    public partial class yeni1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimAdi",
                table: "tblUrunler",
                type: "longtext",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResimAdi",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklenmeTarihi", "ResimAdi" },
                values: new object[] { new DateTime(2023, 5, 16, 11, 53, 1, 378, DateTimeKind.Local).AddTicks(1163), null });

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EklenmeTarihi", "ResimAdi" },
                values: new object[] { new DateTime(2023, 5, 16, 11, 53, 1, 378, DateTimeKind.Local).AddTicks(1175), null });

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EklenmeTarihi", "ResimAdi" },
                values: new object[] { new DateTime(2023, 5, 16, 11, 13, 1, 378, DateTimeKind.Local).AddTicks(1183), null });

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 5,
                column: "ResimAdi",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 6,
                column: "ResimAdi",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EklenmeTarihi", "ResimAdi" },
                values: new object[] { new DateTime(2023, 5, 1, 11, 53, 1, 378, DateTimeKind.Local).AddTicks(1210), null });

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EklenmeTarihi", "ResimAdi" },
                values: new object[] { new DateTime(2023, 3, 16, 11, 53, 1, 378, DateTimeKind.Local).AddTicks(1218), null });

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EklenmeTarihi", "ResimAdi" },
                values: new object[] { new DateTime(2023, 5, 16, 11, 43, 1, 378, DateTimeKind.Local).AddTicks(1238), null });

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EklenmeTarihi", "ResimAdi" },
                values: new object[] { new DateTime(2023, 5, 16, 8, 53, 1, 378, DateTimeKind.Local).AddTicks(1247), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimAdi",
                table: "tblUrunler");

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 2,
                column: "EklenmeTarihi",
                value: new DateTime(2023, 5, 16, 10, 13, 55, 103, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 3,
                column: "EklenmeTarihi",
                value: new DateTime(2023, 5, 16, 10, 13, 55, 103, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 4,
                column: "EklenmeTarihi",
                value: new DateTime(2023, 5, 16, 9, 33, 55, 103, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 7,
                column: "EklenmeTarihi",
                value: new DateTime(2023, 5, 1, 10, 13, 55, 103, DateTimeKind.Local).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 8,
                column: "EklenmeTarihi",
                value: new DateTime(2023, 3, 16, 10, 13, 55, 103, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 9,
                column: "EklenmeTarihi",
                value: new DateTime(2023, 5, 16, 10, 3, 55, 103, DateTimeKind.Local).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "tblUrunler",
                keyColumn: "Id",
                keyValue: 10,
                column: "EklenmeTarihi",
                value: new DateTime(2023, 5, 16, 7, 13, 55, 103, DateTimeKind.Local).AddTicks(4234));
        }
    }
}
