using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    DateStart = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DateEnd = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    isInProgress = table.Column<bool>(type: "boolean", nullable: true),
                    DateCreated = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DateModified = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DateModified = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tekst = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ToDoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DateModified = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToDos",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToDoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedDate = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    RemovedDate = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToDos", x => new { x.UserId, x.ToDoId });
                    table.ForeignKey(
                        name: "FK_UserToDos_Tasks_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToDos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("121b4b8b-d3f9-4b88-ab11-857dc9941c3b"), "User" },
                    { new Guid("a11b1a7f-c5e0-45a0-ba0f-f68435c826eb"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateEnd", "DateModified", "DateStart", "Description", "ModifiedBy", "Title", "isInProgress" },
                values: new object[,]
                {
                    { new Guid("05fc5276-8a16-450d-ba3e-4760267ec381"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Task2", true },
                    { new Guid("09345fd8-9400-48c7-85e8-e2d5e082ac11"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Task7", true },
                    { new Guid("0e70a5ca-5c3b-4ba4-a5c1-6a389a37f8df"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Task6", true },
                    { new Guid("1be3e19f-13fe-4c3b-953e-eedbdee16134"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Task5", true },
                    { new Guid("47fb53da-e324-459e-9bb5-d2dccff741d7"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Task1", true },
                    { new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Increase power to the warp engine", true },
                    { new Guid("de734256-7f1a-403d-a14c-6bd545426e08"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Task3", true },
                    { new Guid("ef66ce84-4ce5-468c-92da-4745160b4a8c"), "seed", "5/18/2025 5:21:48 PM", "6/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", "5/18/2025", null, null, "Task4", true }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Tekst", "ToDoId" },
                values: new object[] { new Guid("ae6139d2-375c-40df-b5ab-293346277d2f"), "user1", "5/18/2025 5:21:48 PM", "5/18/2025 5:21:48 PM", null, "We will overload the flux capacitors!", new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Email", "ModifiedBy", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("6d8de1aa-3d88-450a-a35c-408efd8f5bb2"), "seed", "5/18/2025 5:21:48 PM", null, "user2@example.com", null, "$2a$12$dHimz4GciBJHZTDs4BoqruADW.wgIEPckq2ceCbJTkX9F.8GC/QoO", new Guid("121b4b8b-d3f9-4b88-ab11-857dc9941c3b"), "user2" },
                    { new Guid("a3b1e294-c106-4dd4-bce1-a97132d16c3d"), "seed", "5/18/2025 5:21:48 PM", null, "user@example.com", null, "$2a$12$KEY3WPXYB5ldI/fInlj3geJj12OCmXHu9AouvyKffORMypumTVtP.", new Guid("121b4b8b-d3f9-4b88-ab11-857dc9941c3b"), "user1" },
                    { new Guid("d20b73cf-aab9-459a-90d5-2d9f65bd4f91"), "seed", "5/18/2025 5:21:48 PM", null, "admin@example.com", null, "$2a$12$pCF8WvWAwvDtSKZJtpm9ZuPxiibhVEm4t9j8M1mAEjsa55UdVCyF2", new Guid("a11b1a7f-c5e0-45a0-ba0f-f68435c826eb"), "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserToDos",
                columns: new[] { "ToDoId", "UserId", "AssignedDate", "Id", "RemovedDate" },
                values: new object[,]
                {
                    { new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"), new Guid("6d8de1aa-3d88-450a-a35c-408efd8f5bb2"), "5/18/2025 5:21:48 PM", new Guid("32e4c3bb-900b-4dd5-b7f6-18277027985d"), null },
                    { new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"), new Guid("a3b1e294-c106-4dd4-bce1-a97132d16c3d"), "5/18/2025 5:21:48 PM", new Guid("b68ec62d-c943-40ba-a652-3a226bb36a66"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ToDoId",
                table: "Comments",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToDos_ToDoId",
                table: "UserToDos",
                column: "ToDoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UserToDos");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
