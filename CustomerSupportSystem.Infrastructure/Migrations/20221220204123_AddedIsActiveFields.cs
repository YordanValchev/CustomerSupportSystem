using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerSupportSystem.Infrastructure.Migrations
{
    public partial class AddedIsActiveFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Partners",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contacts",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "361c7033-86bb-42e0-a264-3f560e1da74d",
                column: "ConcurrencyStamp",
                value: "c989c208-9984-4602-9a99-e02ae068e4b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b35eb07-6f63-41eb-8a44-5178055f3019",
                column: "ConcurrencyStamp",
                value: "bfad4afd-7c68-4d90-ad06-e3940554bf00");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c838fb22-a99a-42d7-9c00-9bae1b092cfd",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9e60a57-35fe-4c1d-9122-792c058b3640", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80cb755-6247-4474-aa26-43a41d78691a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b045e6d2-b4ea-4823-badc-c6401ec9b6b7", "AQAAAAEAACcQAAAAEN2azEwMhoBG8EZ942hlo3q+agABmfm0DkbZ9GEb7KB21odoNM2tz7jw8/WDJPAHCw==", "d8ced16e-6f1f-466f-8140-cf15be625f59" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contacts");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "361c7033-86bb-42e0-a264-3f560e1da74d",
                column: "ConcurrencyStamp",
                value: "e43e77f0-405c-4b87-b845-82a0106341d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b35eb07-6f63-41eb-8a44-5178055f3019",
                column: "ConcurrencyStamp",
                value: "559fa7e0-d92b-42fa-95c2-560501bfb78d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c838fb22-a99a-42d7-9c00-9bae1b092cfd",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6271cd86-26b1-47ee-8663-aa4693b1cd66", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80cb755-6247-4474-aa26-43a41d78691a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffcc9392-0dad-42ee-bdd8-a4d21db5938f", "AQAAAAEAACcQAAAAEA3UsjTGr1v7dQNoKVcaFtQkmHcdGvxffFrIcQF14uIa5/Iu18QEsd67I0RuWT1MBQ==", "ff2457a3-128f-433a-a4b9-e0afe3f97374" });
        }
    }
}
