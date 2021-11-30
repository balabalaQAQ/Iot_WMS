using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kestrel.ORM.Migrations
{
    public partial class KestrelData001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reviewer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadPortrait = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NativePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    IsLockoutEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IUser_IRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "IRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialsID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    SortCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialsInfo_MCategory_MCategoryId",
                        column: x => x.MCategoryId,
                        principalTable: "MCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SortCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInfo_PCategory_PCategoryId",
                        column: x => x.PCategoryId,
                        principalTable: "PCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RMRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    setType = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SetNum = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    MaterialsInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RMRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RMRecord_MaterialsInfo_MaterialsInfoId",
                        column: x => x.MaterialsInfoId,
                        principalTable: "MaterialsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RMRecord_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    setType = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    SetNum = table.Column<int>(type: "int", nullable: false),
                    ProductInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPseudoDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRecord_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IRole",
                columns: new[] { "Id", "DepartmentName", "Description", "DisplayName", "IsPseudoDelete", "Name", "SortCode" },
                values: new object[,]
                {
                    { new Guid("8f95a79a-ba01-4c1c-9268-a73c79a9cd9d"), "管理员", "管理员：拥有用户管理、原料采购管理、产品出入库管理权限", "Adimn", false, "Admin", null },
                    { new Guid("c6ad9093-9c9c-4345-8a74-b48ab87020b6"), "采购部门", "采购部门：拥有个人信息管理、原料采购信息管理权限。", "Purchase", false, "PurchasingDepartment", null },
                    { new Guid("d3137fb2-c30f-431b-88c0-3e59230a88b1"), "生产部门", "生产部门：拥有个人信息管理、原料领取管理、生产货物信息管理、产品入库管理权限", "Production", false, "ProductionDepartment", null },
                    { new Guid("9d0387d5-795f-4d03-8582-95a82be78851"), "销售部门", "销售部门：拥有个人信息管理、产品入库管理权限", "Sale", false, "SaleDepartment", null }
                });

            migrationBuilder.InsertData(
                table: "MCategory",
                columns: new[] { "Id", "CategoryNum", "Description", "DisplayName", "IsPseudoDelete", "Name", "SortCode" },
                values: new object[,]
                {
                    { new Guid("51efd022-5180-4781-a7e8-c978cfdc31e1"), "STM-32F", "Stm32微型集成MCU", "STM32", false, "Stm32微型集成MCU（附带WIFI模块）-STM32F3206", null },
                    { new Guid("bbc0b462-dee1-42d7-8858-1a688527c31e"), "TC01", "映射模块-TC01", "映射模块", false, "映射模块-TC01", null }
                });

            migrationBuilder.InsertData(
                table: "PCategory",
                columns: new[] { "Id", "CategoryNum", "Description", "DisplayName", "IsPseudoDelete", "Name", "SortCode" },
                values: new object[,]
                {
                    { new Guid("f838a08a-9012-4ff4-84b3-d14d0d2061ff"), "ZNJJ-001", "新一代智能家居系列", "Iot设备", false, "智能家居系列-Iot设备", null },
                    { new Guid("77d79a4e-0f7f-4803-b57c-8bfdc553e2c9"), "WL-001", "新一代微量级系列", "Iot芯片", false, "微量级系列-Iot芯片", null }
                });

            migrationBuilder.InsertData(
                table: "IUser",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Description", "Email", "EmployeeNumber", "HeadPortrait", "IdentityCardNumber", "IsLockoutEnabled", "IsPseudoDelete", "Name", "NativePlace", "Password", "Phone", "Post", "RoleId", "Sex", "SortCode" },
                values: new object[] { new Guid("b3b145cd-cd37-4dff-b6bf-e141697ab342"), 0, null, null, null, "Admin", null, null, false, false, "Administrator", null, "123456", 0, null, new Guid("8f95a79a-ba01-4c1c-9268-a73c79a9cd9d"), false, null });

            migrationBuilder.CreateIndex(
                name: "IX_IUser_RoleId",
                table: "IUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsInfo_MCategoryId",
                table: "MaterialsInfo",
                column: "MCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PRecord_ProductInfoId",
                table: "PRecord",
                column: "ProductInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_PCategoryId",
                table: "ProductInfo",
                column: "PCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RMRecord_MaterialsInfoId",
                table: "RMRecord",
                column: "MaterialsInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RMRecord_OrderId",
                table: "RMRecord",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IUser");

            migrationBuilder.DropTable(
                name: "PRecord");

            migrationBuilder.DropTable(
                name: "RMRecord");

            migrationBuilder.DropTable(
                name: "IRole");

            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "MaterialsInfo");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PCategory");

            migrationBuilder.DropTable(
                name: "MCategory");
        }
    }
}
