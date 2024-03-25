using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Added_some_more_cols_Docs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PbDocuments_AbpUsers_DVKCBId",
                table: "PbDocuments");

            migrationBuilder.DropTable(
                name: "PbVanBanPhapLy");

            migrationBuilder.DropIndex(
                name: "IX_PbDocuments_DVKCBId",
                table: "PbDocuments");

            migrationBuilder.AddColumn<string>(
                name: "approver",
                table: "PbDocuments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "docType",
                table: "PbDocuments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "publishDate",
                table: "PbDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "publishPlace",
                table: "PbDocuments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "recipient",
                table: "PbDocuments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "signer",
                table: "PbDocuments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "PbDocuments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantLegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantTaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInvoices");

            migrationBuilder.DropColumn(
                name: "approver",
                table: "PbDocuments");

            migrationBuilder.DropColumn(
                name: "docType",
                table: "PbDocuments");

            migrationBuilder.DropColumn(
                name: "publishDate",
                table: "PbDocuments");

            migrationBuilder.DropColumn(
                name: "publishPlace",
                table: "PbDocuments");

            migrationBuilder.DropColumn(
                name: "recipient",
                table: "PbDocuments");

            migrationBuilder.DropColumn(
                name: "signer",
                table: "PbDocuments");

            migrationBuilder.DropColumn(
                name: "status",
                table: "PbDocuments");

            migrationBuilder.CreateTable(
                name: "PbVanBanPhapLy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PbVanBanPhapLy", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PbDocuments_DVKCBId",
                table: "PbDocuments",
                column: "DVKCBId");

            migrationBuilder.AddForeignKey(
                name: "FK_PbDocuments_AbpUsers_DVKCBId",
                table: "PbDocuments",
                column: "DVKCBId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
