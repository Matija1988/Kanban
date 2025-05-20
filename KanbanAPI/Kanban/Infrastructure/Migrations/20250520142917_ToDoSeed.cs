using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ToDoSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "UserToDos");

            migrationBuilder.AlterColumn<string>(
                name: "Tekst",
                table: "Comments",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ae6139d2-375c-40df-b5ab-293346277d2f"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { "5/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("05fc5276-8a16-450d-ba3e-4760267ec381"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("09345fd8-9400-48c7-85e8-e2d5e082ac11"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("0e70a5ca-5c3b-4ba4-a5c1-6a389a37f8df"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1be3e19f-13fe-4c3b-953e-eedbdee16134"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("47fb53da-e324-459e-9bb5-d2dccff741d7"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("de734256-7f1a-403d-a14c-6bd545426e08"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ef66ce84-4ce5-468c-92da-4745160b4a8c"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateEnd", "DateModified", "DateStart", "Description", "ModifiedBy", "Priority", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("13c5d63b-a320-46b0-b3e5-7d205cfb7814"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task27" },
                    { new Guid("1797096f-fc95-4d78-9002-0976acdb6b31"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "MED", "TO_DO", "Task29" },
                    { new Guid("1ac1c57f-0754-4439-8366-f67c3c8d2770"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task41" },
                    { new Guid("1dbd2445-9be3-496b-9f1d-02a093adcd78"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task40" },
                    { new Guid("22c7b843-819d-4d3a-879d-891c86d271ef"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task33" },
                    { new Guid("28d4e06a-a868-4524-b8d7-186ce0f40506"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task42" },
                    { new Guid("33f8daeb-192b-4253-8e6d-d075aaf110a6"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task18" },
                    { new Guid("38f30e6c-d554-43f1-b65b-49ed08fba319"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task26" },
                    { new Guid("3c83b113-7134-4e9a-9b22-1a953367a426"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task51" },
                    { new Guid("3fd41d79-582c-493a-a769-77cf6b0469b0"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task23" },
                    { new Guid("463ee6e5-a64a-4af5-b3c9-cc6915935784"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "MED", "TO_DO", "Task15" },
                    { new Guid("4a6310f0-c348-40f5-a78a-a213855c75fc"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task56" },
                    { new Guid("551a6e50-f9a7-4c79-86ec-e84edb7ec4ad"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task54" },
                    { new Guid("562ed64a-2eac-4a12-83e9-5a7b9a32994f"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task11" },
                    { new Guid("584a8ae5-d4cb-4f82-9252-b3fca8e53ce7"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "MED", "TO_DO", "Task50" },
                    { new Guid("61497cf4-db7d-45f1-8a3d-7d9f5546b4a5"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task30" },
                    { new Guid("64452277-77ea-4087-bb50-b00bad7b8a12"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task35" },
                    { new Guid("679829ad-fc67-42d0-9d9f-533b7eeacc6f"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task52" },
                    { new Guid("6bdcb1f6-bfce-462b-afe2-8332a524399a"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task55" },
                    { new Guid("78c897ad-b438-4b30-8781-faf82f66e819"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task21" },
                    { new Guid("792910e4-f88b-4971-9766-246a5bac736c"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task48" },
                    { new Guid("7e93a6c4-cbf7-4873-af17-3d133194c17d"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task38" },
                    { new Guid("80bda57f-b222-405b-a1d5-59e3e8f3317c"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task19" },
                    { new Guid("87df559c-cc00-4aec-af3e-51a8a3f49cbc"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "MED", "TO_DO", "Task36" },
                    { new Guid("8a75e858-f606-4bca-8e07-a02ae2fafe20"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task45" },
                    { new Guid("8daa8a57-fa0d-411e-9c8a-7ce7e657d4a9"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task12" },
                    { new Guid("909cb444-d959-45a4-b9b7-8503b061887f"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task28" },
                    { new Guid("919b1e72-b78e-4cb9-8978-a65a39ed21b6"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task53" },
                    { new Guid("9d7cfd09-f7bc-4333-9936-7afa35f441d1"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task14" },
                    { new Guid("9da798a1-3e6f-4183-81af-be347451ab77"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task47" },
                    { new Guid("a544266b-a461-4d33-b426-01b540181617"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task39" },
                    { new Guid("a553ddf9-eccd-4723-9d33-6e3e1045909b"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task49" },
                    { new Guid("b4c862a8-4259-460d-a39e-d000df86f064"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task9" },
                    { new Guid("b72f8cb0-6dfc-4681-90d4-4c4a9b344935"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task34" },
                    { new Guid("b7a41bb7-a2af-40fd-9f24-f1f31075760a"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task13" },
                    { new Guid("b820cbd7-3c30-4ecc-b72a-e00351799414"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task31" },
                    { new Guid("b8647a3b-0711-4210-8397-d77376005a81"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task10" },
                    { new Guid("bd5bec0a-d954-4d04-99aa-17bbd003a712"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task44" },
                    { new Guid("ce4b4e99-017f-4ce8-8b1f-39d9289690e4"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "MED", "TO_DO", "Task22" },
                    { new Guid("d1776d57-d568-4058-9f14-f3522ff9db09"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task32" },
                    { new Guid("d3fae83c-042c-438e-8cda-fc988de90130"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task37" },
                    { new Guid("dd166506-798b-4304-b988-f7c90494c3c4"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "MED", "TO_DO", "Task43" },
                    { new Guid("e28821d5-c960-459a-9055-98e520d9b24b"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task17" },
                    { new Guid("e9e1bd12-2165-45ac-8824-0dd47ac0755f"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task24" },
                    { new Guid("ea545c41-9030-4cff-ac92-ba7753beb98d"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task16" },
                    { new Guid("efa3a555-8c33-4106-8292-602d933bbb95"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task25" },
                    { new Guid("f450674b-12b3-458d-bb17-b30467a2d083"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task20" },
                    { new Guid("f453ff36-067b-45f9-9c46-4c312495166a"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "LOW", "TO_DO", "Task46" },
                    { new Guid("f5fee937-1a62-4c00-b1ee-fbcbeff1c8d9"), "seed", "5/20/2025 2:29:16 PM", "6/20/2025 2:29:16 PM", "5/20/2025 2:29:16 PM", "5/20/2025", null, null, "MED", "TO_DO", "Task8" }
                });

            migrationBuilder.UpdateData(
                table: "UserToDos",
                keyColumns: new[] { "ToDoId", "UserId" },
                keyValues: new object[] { new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"), new Guid("6d8de1aa-3d88-450a-a35c-408efd8f5bb2") },
                column: "AssignedDate",
                value: "5/20/2025 2:29:16 PM");

            migrationBuilder.UpdateData(
                table: "UserToDos",
                keyColumns: new[] { "ToDoId", "UserId" },
                keyValues: new object[] { new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"), new Guid("a3b1e294-c106-4dd4-bce1-a97132d16c3d") },
                column: "AssignedDate",
                value: "5/20/2025 2:29:16 PM");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d8de1aa-3d88-450a-a35c-408efd8f5bb2"),
                column: "DateCreated",
                value: "5/20/2025 2:29:16 PM");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3b1e294-c106-4dd4-bce1-a97132d16c3d"),
                column: "DateCreated",
                value: "5/20/2025 2:29:16 PM");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d20b73cf-aab9-459a-90d5-2d9f65bd4f91"),
                column: "DateCreated",
                value: "5/20/2025 2:29:16 PM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("13c5d63b-a320-46b0-b3e5-7d205cfb7814"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1797096f-fc95-4d78-9002-0976acdb6b31"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1ac1c57f-0754-4439-8366-f67c3c8d2770"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1dbd2445-9be3-496b-9f1d-02a093adcd78"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("22c7b843-819d-4d3a-879d-891c86d271ef"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("28d4e06a-a868-4524-b8d7-186ce0f40506"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("33f8daeb-192b-4253-8e6d-d075aaf110a6"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("38f30e6c-d554-43f1-b65b-49ed08fba319"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("3c83b113-7134-4e9a-9b22-1a953367a426"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("3fd41d79-582c-493a-a769-77cf6b0469b0"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("463ee6e5-a64a-4af5-b3c9-cc6915935784"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("4a6310f0-c348-40f5-a78a-a213855c75fc"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("551a6e50-f9a7-4c79-86ec-e84edb7ec4ad"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("562ed64a-2eac-4a12-83e9-5a7b9a32994f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("584a8ae5-d4cb-4f82-9252-b3fca8e53ce7"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("61497cf4-db7d-45f1-8a3d-7d9f5546b4a5"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("64452277-77ea-4087-bb50-b00bad7b8a12"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("679829ad-fc67-42d0-9d9f-533b7eeacc6f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("6bdcb1f6-bfce-462b-afe2-8332a524399a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("78c897ad-b438-4b30-8781-faf82f66e819"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("792910e4-f88b-4971-9766-246a5bac736c"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("7e93a6c4-cbf7-4873-af17-3d133194c17d"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("80bda57f-b222-405b-a1d5-59e3e8f3317c"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("87df559c-cc00-4aec-af3e-51a8a3f49cbc"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("8a75e858-f606-4bca-8e07-a02ae2fafe20"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("8daa8a57-fa0d-411e-9c8a-7ce7e657d4a9"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("909cb444-d959-45a4-b9b7-8503b061887f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("919b1e72-b78e-4cb9-8978-a65a39ed21b6"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("9d7cfd09-f7bc-4333-9936-7afa35f441d1"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("9da798a1-3e6f-4183-81af-be347451ab77"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a544266b-a461-4d33-b426-01b540181617"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a553ddf9-eccd-4723-9d33-6e3e1045909b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("b4c862a8-4259-460d-a39e-d000df86f064"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("b72f8cb0-6dfc-4681-90d4-4c4a9b344935"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("b7a41bb7-a2af-40fd-9f24-f1f31075760a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("b820cbd7-3c30-4ecc-b72a-e00351799414"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("b8647a3b-0711-4210-8397-d77376005a81"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("bd5bec0a-d954-4d04-99aa-17bbd003a712"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ce4b4e99-017f-4ce8-8b1f-39d9289690e4"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d1776d57-d568-4058-9f14-f3522ff9db09"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d3fae83c-042c-438e-8cda-fc988de90130"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("dd166506-798b-4304-b988-f7c90494c3c4"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e28821d5-c960-459a-9055-98e520d9b24b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e9e1bd12-2165-45ac-8824-0dd47ac0755f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ea545c41-9030-4cff-ac92-ba7753beb98d"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("efa3a555-8c33-4106-8292-602d933bbb95"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f450674b-12b3-458d-bb17-b30467a2d083"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f453ff36-067b-45f9-9c46-4c312495166a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f5fee937-1a62-4c00-b1ee-fbcbeff1c8d9"));

            migrationBuilder.AddColumn<string>(
                name: "RemovedDate",
                table: "UserToDos",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tekst",
                table: "Comments",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ae6139d2-375c-40df-b5ab-293346277d2f"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { "5/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("05fc5276-8a16-450d-ba3e-4760267ec381"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("09345fd8-9400-48c7-85e8-e2d5e082ac11"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("0e70a5ca-5c3b-4ba4-a5c1-6a389a37f8df"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1be3e19f-13fe-4c3b-953e-eedbdee16134"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("47fb53da-e324-459e-9bb5-d2dccff741d7"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("de734256-7f1a-403d-a14c-6bd545426e08"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ef66ce84-4ce5-468c-92da-4745160b4a8c"),
                columns: new[] { "DateCreated", "DateEnd", "DateModified", "DateStart" },
                values: new object[] { "5/19/2025 7:00:37 PM", "6/19/2025 7:00:37 PM", "5/19/2025 7:00:37 PM", "5/19/2025" });

            migrationBuilder.UpdateData(
                table: "UserToDos",
                keyColumns: new[] { "ToDoId", "UserId" },
                keyValues: new object[] { new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"), new Guid("6d8de1aa-3d88-450a-a35c-408efd8f5bb2") },
                columns: new[] { "AssignedDate", "RemovedDate" },
                values: new object[] { "5/19/2025 7:00:37 PM", null });

            migrationBuilder.UpdateData(
                table: "UserToDos",
                keyColumns: new[] { "ToDoId", "UserId" },
                keyValues: new object[] { new Guid("6cb4f5bb-764d-4344-9e29-35fc7b5e1d47"), new Guid("a3b1e294-c106-4dd4-bce1-a97132d16c3d") },
                columns: new[] { "AssignedDate", "RemovedDate" },
                values: new object[] { "5/19/2025 7:00:37 PM", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d8de1aa-3d88-450a-a35c-408efd8f5bb2"),
                column: "DateCreated",
                value: "5/19/2025 7:00:37 PM");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3b1e294-c106-4dd4-bce1-a97132d16c3d"),
                column: "DateCreated",
                value: "5/19/2025 7:00:37 PM");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d20b73cf-aab9-459a-90d5-2d9f65bd4f91"),
                column: "DateCreated",
                value: "5/19/2025 7:00:37 PM");
        }
    }
}
