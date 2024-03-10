using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Added_Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PbDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    validation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    published = table.Column<bool>(type: "bit", nullable: false),
                    fullText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    medical_product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    showed = table.Column<bool>(type: "bit", nullable: false),
                    DVKCBId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PbDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PbDocuments_AbpUsers_DVKCBId",
                        column: x => x.DVKCBId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PbOldDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    validation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    published = table.Column<bool>(type: "bit", nullable: false),
                    fullText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    medical_product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    showed = table.Column<bool>(type: "bit", nullable: false),
                    DVKCBId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PbOldDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PbOldDocuments_AbpUsers_DVKCBId",
                        column: x => x.DVKCBId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PbOldDocuments_PbDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "PbDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PbDocuments_DVKCBId",
                table: "PbDocuments",
                column: "DVKCBId");

            migrationBuilder.CreateIndex(
                name: "IX_PbOldDocuments_DocumentId",
                table: "PbOldDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PbOldDocuments_DVKCBId",
                table: "PbOldDocuments",
                column: "DVKCBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PbOldDocuments");

            migrationBuilder.DropTable(
                name: "PbDocuments");
        }
    }
}
