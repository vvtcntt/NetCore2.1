using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.EF.Migrations
{
    public partial class initalCustomId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_CustomerId",
                table: "Bills");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Bills",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(Guid),
                oldMaxLength: 450);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_AspNetUsers_CustomerId",
                table: "Bills");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Bills",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(Guid),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_AspNetUsers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
