using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Set = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    Hash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    RefSetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefTerms_RefSets_RefSetId",
                        column: x => x.RefSetId,
                        principalTable: "RefSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressBooks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefSetMappings",
                columns: table => new
                {
                    RefSetId = table.Column<Guid>(nullable: false),
                    RefTermId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSetMappings", x => new { x.RefSetId, x.RefTermId });
                    table.ForeignKey(
                        name: "FK_RefSetMappings_RefSets_RefSetId",
                        column: x => x.RefSetId,
                        principalTable: "RefSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefSetMappings_RefTerms_RefTermId",
                        column: x => x.RefTermId,
                        principalTable: "RefTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Line1 = table.Column<string>(maxLength: 25, nullable: false),
                    Line2 = table.Column<string>(maxLength: 25, nullable: false),
                    City = table.Column<string>(maxLength: 25, nullable: false),
                    StateName = table.Column<string>(maxLength: 25, nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    AddressBookId = table.Column<Guid>(nullable: false),
                    AddressTypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressBooks_AddressBookId",
                        column: x => x.AddressBookId,
                        principalTable: "AddressBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(maxLength: 25, nullable: false),
                    DownloadUrl = table.Column<string>(nullable: false),
                    FileTypeId = table.Column<Guid>(nullable: false),
                    size = table.Column<int>(nullable: false),
                    Content = table.Column<byte[]>(nullable: false),
                    AddressBookId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AddressBooks_AddressBookId",
                        column: x => x.AddressBookId,
                        principalTable: "AddressBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    AddressBookId = table.Column<Guid>(nullable: false),
                    EmailTypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_AddressBooks_AddressBookId",
                        column: x => x.AddressBookId,
                        principalTable: "AddressBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 13, nullable: false),
                    AddressBookId = table.Column<Guid>(nullable: false),
                    PhoneTypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_AddressBooks_AddressBookId",
                        column: x => x.AddressBookId,
                        principalTable: "AddressBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressBooks_UserId",
                table: "AddressBooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressBookId",
                table: "Addresses",
                column: "AddressBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AddressBookId",
                table: "Assets",
                column: "AddressBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_AddressBookId",
                table: "Emails",
                column: "AddressBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_UserId",
                table: "Emails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_AddressBookId",
                table: "Phones",
                column: "AddressBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefSetMappings_RefTermId",
                table: "RefSetMappings",
                column: "RefTermId");

            migrationBuilder.CreateIndex(
                name: "IX_RefTerms_RefSetId",
                table: "RefTerms",
                column: "RefSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "RefSetMappings");

            migrationBuilder.DropTable(
                name: "AddressBooks");

            migrationBuilder.DropTable(
                name: "RefTerms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RefSets");
        }
    }
}
