using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PERSON_TB_DELIVERY_PERSON_IdDeliveryPerson",
                table: "TB_PERSON");

            migrationBuilder.DropIndex(
                name: "IX_TB_PERSON_IdDeliveryPerson",
                table: "TB_PERSON");

            migrationBuilder.DropColumn(
                name: "IdDeliveryPerson",
                table: "TB_PERSON");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TB_RENT",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedEndDate",
                table: "TB_RENT",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TB_RENT",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_RENT",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_PERSON",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "TB_PERSON",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_MOTORCYCLE",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_DELIVERY_PERSON",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DELIVERY_PERSON_IdPerson",
                table: "TB_DELIVERY_PERSON",
                column: "IdPerson",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_DELIVERY_PERSON_TB_PERSON_IdPerson",
                table: "TB_DELIVERY_PERSON",
                column: "IdPerson",
                principalTable: "TB_PERSON",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_DELIVERY_PERSON_TB_PERSON_IdPerson",
                table: "TB_DELIVERY_PERSON");

            migrationBuilder.DropIndex(
                name: "IX_TB_DELIVERY_PERSON_IdPerson",
                table: "TB_DELIVERY_PERSON");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "TB_RENT",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedEndDate",
                table: "TB_RENT",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "TB_RENT",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_RENT",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_PERSON",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "TB_PERSON",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<long>(
                name: "IdDeliveryPerson",
                table: "TB_PERSON",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_MOTORCYCLE",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TB_DELIVERY_PERSON",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSON_IdDeliveryPerson",
                table: "TB_PERSON",
                column: "IdDeliveryPerson",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PERSON_TB_DELIVERY_PERSON_IdDeliveryPerson",
                table: "TB_PERSON",
                column: "IdDeliveryPerson",
                principalTable: "TB_DELIVERY_PERSON",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
