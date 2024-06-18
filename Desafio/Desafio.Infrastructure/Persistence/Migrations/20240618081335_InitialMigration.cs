using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DELIVERY_PERSON",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CnhNumber = table.Column<string>(type: "text", nullable: false),
                    CnhType = table.Column<string>(type: "text", nullable: false),
                    CnhImageLocation = table.Column<string>(type: "text", nullable: true),
                    IdPerson = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DELIVERY_PERSON", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MOTORCYCLE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Plate = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MOTORCYCLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSON",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdDeliveryPerson = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSON", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PERSON_TB_DELIVERY_PERSON_IdDeliveryPerson",
                        column: x => x.IdDeliveryPerson,
                        principalTable: "TB_DELIVERY_PERSON",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_RENT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RentPlan = table.Column<int>(type: "integer", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdMotorcycle = table.Column<long>(type: "bigint", nullable: false),
                    IdDeliveryPerson = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_RENT_TB_DELIVERY_PERSON_IdMotorcycle",
                        column: x => x.IdMotorcycle,
                        principalTable: "TB_DELIVERY_PERSON",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_RENT_TB_MOTORCYCLE_IdMotorcycle",
                        column: x => x.IdMotorcycle,
                        principalTable: "TB_MOTORCYCLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DELIVERY_PERSON_CnhNumber",
                table: "TB_DELIVERY_PERSON",
                column: "CnhNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_MOTORCYCLE_Plate",
                table: "TB_MOTORCYCLE",
                column: "Plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSON_Cnpj",
                table: "TB_PERSON",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSON_IdDeliveryPerson",
                table: "TB_PERSON",
                column: "IdDeliveryPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_RENT_IdMotorcycle",
                table: "TB_RENT",
                column: "IdMotorcycle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSON");

            migrationBuilder.DropTable(
                name: "TB_RENT");

            migrationBuilder.DropTable(
                name: "TB_DELIVERY_PERSON");

            migrationBuilder.DropTable(
                name: "TB_MOTORCYCLE");
        }
    }
}
