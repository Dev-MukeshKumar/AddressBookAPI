using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookAPI.Migrations
{
    public partial class updatedRefSetMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefTerms_RefSets_RefSetId",
                table: "RefTerms");

            migrationBuilder.DropIndex(
                name: "IX_RefTerms_RefSetId",
                table: "RefTerms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefSetMappings",
                table: "RefSetMappings");

            migrationBuilder.DropColumn(
                name: "RefSetId",
                table: "RefTerms");

            migrationBuilder.DropColumn(
                name: "FileTypeId",
                table: "Assets");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RefSetMappings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Assets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefSetMappings",
                table: "RefSetMappings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RefSetMappings_RefSetId",
                table: "RefSetMappings",
                column: "RefSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefSetMappings",
                table: "RefSetMappings");

            migrationBuilder.DropIndex(
                name: "IX_RefSetMappings_RefSetId",
                table: "RefSetMappings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RefSetMappings");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Assets");

            migrationBuilder.AddColumn<Guid>(
                name: "RefSetId",
                table: "RefTerms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FileTypeId",
                table: "Assets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefSetMappings",
                table: "RefSetMappings",
                columns: new[] { "RefSetId", "RefTermId" });

            migrationBuilder.CreateIndex(
                name: "IX_RefTerms_RefSetId",
                table: "RefTerms",
                column: "RefSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefTerms_RefSets_RefSetId",
                table: "RefTerms",
                column: "RefSetId",
                principalTable: "RefSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
