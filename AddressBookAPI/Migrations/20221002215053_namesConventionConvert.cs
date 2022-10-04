using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBookAPI.Migrations
{
    public partial class namesConventionConvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressBooks_Users_UserId",
                table: "AddressBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressBooks_AddressBookId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AddressBooks_AddressBookId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Users_UserId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_AddressBooks_AddressBookId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Users_UserId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_AddressBooks_AddressBookId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_RefSetMappings_RefSets_RefSetId",
                table: "RefSetMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_RefSetMappings_RefTerms_RefTermId",
                table: "RefSetMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefTerms",
                table: "RefTerms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefSets",
                table: "RefSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefSetMappings",
                table: "RefSetMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressBooks",
                table: "AddressBooks");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "RefTerms",
                newName: "ref_term");

            migrationBuilder.RenameTable(
                name: "RefSets",
                newName: "ref_set");

            migrationBuilder.RenameTable(
                name: "RefSetMappings",
                newName: "set_term_mapping");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "phone");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "email");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "asset");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "address");

            migrationBuilder.RenameTable(
                name: "AddressBooks",
                newName: "address_book");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "user",
                newName: "hash");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "user",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "user",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "user",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "ref_term",
                newName: "key");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ref_term",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ref_term",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Set",
                table: "ref_set",
                newName: "set");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ref_set",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ref_set",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "set_term_mapping",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RefTermId",
                table: "set_term_mapping",
                newName: "ref_term_id");

            migrationBuilder.RenameColumn(
                name: "RefSetId",
                table: "set_term_mapping",
                newName: "ref_set_id");

            migrationBuilder.RenameIndex(
                name: "IX_RefSetMappings_RefTermId",
                table: "set_term_mapping",
                newName: "IX_set_term_mapping_ref_term_id");

            migrationBuilder.RenameIndex(
                name: "IX_RefSetMappings_RefSetId",
                table: "set_term_mapping",
                newName: "IX_set_term_mapping_ref_set_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "phone",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "phone",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "PhoneTypeId",
                table: "phone",
                newName: "phone_type_id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "phone",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "AddressBookId",
                table: "phone",
                newName: "address_book_id");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_UserId",
                table: "phone",
                newName: "IX_phone_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_AddressBookId",
                table: "phone",
                newName: "IX_phone_address_book_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "email",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "email",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "EmailTypeId",
                table: "email",
                newName: "email_type_id");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "email",
                newName: "email_address");

            migrationBuilder.RenameColumn(
                name: "AddressBookId",
                table: "email",
                newName: "address_book_id");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_UserId",
                table: "email",
                newName: "IX_email_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_AddressBookId",
                table: "email",
                newName: "IX_email_address_book_id");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "asset",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "asset",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "asset",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "asset",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "asset",
                newName: "file_type");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "asset",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "DownloadUrl",
                table: "asset",
                newName: "download_url");

            migrationBuilder.RenameColumn(
                name: "AddressBookId",
                table: "asset",
                newName: "address_book_id");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_UserId",
                table: "asset",
                newName: "IX_asset_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_AddressBookId",
                table: "asset",
                newName: "IX_asset_address_book_id");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "address",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "address",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "address",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "address",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "StateName",
                table: "address",
                newName: "state_name");

            migrationBuilder.RenameColumn(
                name: "Line2",
                table: "address",
                newName: "line_2");

            migrationBuilder.RenameColumn(
                name: "Line1",
                table: "address",
                newName: "line_1");

            migrationBuilder.RenameColumn(
                name: "CountryTypeId",
                table: "address",
                newName: "country_type_id");

            migrationBuilder.RenameColumn(
                name: "AddressTypeId",
                table: "address",
                newName: "address_type_id");

            migrationBuilder.RenameColumn(
                name: "AddressBookId",
                table: "address",
                newName: "address_book_id");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "address",
                newName: "IX_address_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_AddressBookId",
                table: "address",
                newName: "IX_address_address_book_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "address_book",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "address_book",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "address_book",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "address_book",
                newName: "first_name");

            migrationBuilder.RenameIndex(
                name: "IX_AddressBooks_UserId",
                table: "address_book",
                newName: "IX_address_book_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_user_user_name",
                table: "user",
                column: "user_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ref_term",
                table: "ref_term",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ref_set",
                table: "ref_set",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_set_term_mapping",
                table: "set_term_mapping",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phone",
                table: "phone",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_email",
                table: "email",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_asset",
                table: "asset",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_address",
                table: "address",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_address_book",
                table: "address_book",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_address_book_address_book_id",
                table: "address",
                column: "address_book_id",
                principalTable: "address_book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_address_user_user_id",
                table: "address",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_address_book_user_user_id",
                table: "address_book",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asset_address_book_address_book_id",
                table: "asset",
                column: "address_book_id",
                principalTable: "address_book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_asset_user_user_id",
                table: "asset",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_email_address_book_address_book_id",
                table: "email",
                column: "address_book_id",
                principalTable: "address_book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_email_user_user_id",
                table: "email",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phone_address_book_address_book_id",
                table: "phone",
                column: "address_book_id",
                principalTable: "address_book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phone_user_user_id",
                table: "phone",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_set_term_mapping_ref_set_ref_set_id",
                table: "set_term_mapping",
                column: "ref_set_id",
                principalTable: "ref_set",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_set_term_mapping_ref_term_ref_term_id",
                table: "set_term_mapping",
                column: "ref_term_id",
                principalTable: "ref_term",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_address_book_address_book_id",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_user_user_id",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_book_user_user_id",
                table: "address_book");

            migrationBuilder.DropForeignKey(
                name: "FK_asset_address_book_address_book_id",
                table: "asset");

            migrationBuilder.DropForeignKey(
                name: "FK_asset_user_user_id",
                table: "asset");

            migrationBuilder.DropForeignKey(
                name: "FK_email_address_book_address_book_id",
                table: "email");

            migrationBuilder.DropForeignKey(
                name: "FK_email_user_user_id",
                table: "email");

            migrationBuilder.DropForeignKey(
                name: "FK_phone_address_book_address_book_id",
                table: "phone");

            migrationBuilder.DropForeignKey(
                name: "FK_phone_user_user_id",
                table: "phone");

            migrationBuilder.DropForeignKey(
                name: "FK_set_term_mapping_ref_set_ref_set_id",
                table: "set_term_mapping");

            migrationBuilder.DropForeignKey(
                name: "FK_set_term_mapping_ref_term_ref_term_id",
                table: "set_term_mapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_user_user_name",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_set_term_mapping",
                table: "set_term_mapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ref_term",
                table: "ref_term");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ref_set",
                table: "ref_set");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phone",
                table: "phone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_email",
                table: "email");

            migrationBuilder.DropPrimaryKey(
                name: "PK_asset",
                table: "asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_address_book",
                table: "address_book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_address",
                table: "address");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "set_term_mapping",
                newName: "RefSetMappings");

            migrationBuilder.RenameTable(
                name: "ref_term",
                newName: "RefTerms");

            migrationBuilder.RenameTable(
                name: "ref_set",
                newName: "RefSets");

            migrationBuilder.RenameTable(
                name: "phone",
                newName: "Phones");

            migrationBuilder.RenameTable(
                name: "email",
                newName: "Emails");

            migrationBuilder.RenameTable(
                name: "asset",
                newName: "Assets");

            migrationBuilder.RenameTable(
                name: "address_book",
                newName: "AddressBooks");

            migrationBuilder.RenameTable(
                name: "address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "hash",
                table: "Users",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RefSetMappings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ref_term_id",
                table: "RefSetMappings",
                newName: "RefTermId");

            migrationBuilder.RenameColumn(
                name: "ref_set_id",
                table: "RefSetMappings",
                newName: "RefSetId");

            migrationBuilder.RenameIndex(
                name: "IX_set_term_mapping_ref_term_id",
                table: "RefSetMappings",
                newName: "IX_RefSetMappings_RefTermId");

            migrationBuilder.RenameIndex(
                name: "IX_set_term_mapping_ref_set_id",
                table: "RefSetMappings",
                newName: "IX_RefSetMappings_RefSetId");

            migrationBuilder.RenameColumn(
                name: "key",
                table: "RefTerms",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "RefTerms",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RefTerms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "set",
                table: "RefSets",
                newName: "Set");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "RefSets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RefSets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Phones",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Phones",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "phone_type_id",
                table: "Phones",
                newName: "PhoneTypeId");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Phones",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "address_book_id",
                table: "Phones",
                newName: "AddressBookId");

            migrationBuilder.RenameIndex(
                name: "IX_phone_user_id",
                table: "Phones",
                newName: "IX_Phones_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_phone_address_book_id",
                table: "Phones",
                newName: "IX_Phones_AddressBookId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Emails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Emails",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "email_type_id",
                table: "Emails",
                newName: "EmailTypeId");

            migrationBuilder.RenameColumn(
                name: "email_address",
                table: "Emails",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "address_book_id",
                table: "Emails",
                newName: "AddressBookId");

            migrationBuilder.RenameIndex(
                name: "IX_email_user_id",
                table: "Emails",
                newName: "IX_Emails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_email_address_book_id",
                table: "Emails",
                newName: "IX_Emails_AddressBookId");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Assets",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Assets",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Assets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Assets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "file_type",
                table: "Assets",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Assets",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "download_url",
                table: "Assets",
                newName: "DownloadUrl");

            migrationBuilder.RenameColumn(
                name: "address_book_id",
                table: "Assets",
                newName: "AddressBookId");

            migrationBuilder.RenameIndex(
                name: "IX_asset_user_id",
                table: "Assets",
                newName: "IX_Assets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_asset_address_book_id",
                table: "Assets",
                newName: "IX_Assets_AddressBookId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AddressBooks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AddressBooks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "AddressBooks",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "AddressBooks",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_address_book_user_id",
                table: "AddressBooks",
                newName: "IX_AddressBooks_UserId");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Addresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Addresses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "Addresses",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Addresses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "state_name",
                table: "Addresses",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "line_2",
                table: "Addresses",
                newName: "Line2");

            migrationBuilder.RenameColumn(
                name: "line_1",
                table: "Addresses",
                newName: "Line1");

            migrationBuilder.RenameColumn(
                name: "country_type_id",
                table: "Addresses",
                newName: "CountryTypeId");

            migrationBuilder.RenameColumn(
                name: "address_type_id",
                table: "Addresses",
                newName: "AddressTypeId");

            migrationBuilder.RenameColumn(
                name: "address_book_id",
                table: "Addresses",
                newName: "AddressBookId");

            migrationBuilder.RenameIndex(
                name: "IX_address_user_id",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_address_address_book_id",
                table: "Addresses",
                newName: "IX_Addresses_AddressBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserName",
                table: "Users",
                column: "UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefSetMappings",
                table: "RefSetMappings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefTerms",
                table: "RefTerms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefSets",
                table: "RefSets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressBooks",
                table: "AddressBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressBooks_Users_UserId",
                table: "AddressBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressBooks_AddressBookId",
                table: "Addresses",
                column: "AddressBookId",
                principalTable: "AddressBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AddressBooks_AddressBookId",
                table: "Assets",
                column: "AddressBookId",
                principalTable: "AddressBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Users_UserId",
                table: "Assets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_AddressBooks_AddressBookId",
                table: "Emails",
                column: "AddressBookId",
                principalTable: "AddressBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Users_UserId",
                table: "Emails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_AddressBooks_AddressBookId",
                table: "Phones",
                column: "AddressBookId",
                principalTable: "AddressBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefSetMappings_RefSets_RefSetId",
                table: "RefSetMappings",
                column: "RefSetId",
                principalTable: "RefSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefSetMappings_RefTerms_RefTermId",
                table: "RefSetMappings",
                column: "RefTermId",
                principalTable: "RefTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
