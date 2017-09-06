using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infra.Repositories.Migrations
{
    public partial class AddEmailAndPasswordToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_Email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuario");
        }
    }
}
