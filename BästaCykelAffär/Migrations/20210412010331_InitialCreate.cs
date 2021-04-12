using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BästaCykelAffär.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cyklar",
                columns: table => new
                {
                    Cykel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cykeltyp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Växlar = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Färg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Däckstorlek_tum = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Pris = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cyklar", x => x.Cykel_id);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    Kund_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Efternamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefonnummer = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Gatuadress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postnummer = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.Kund_id);
                });

            migrationBuilder.CreateTable(
                name: "Ordrar",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_gjord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_price = table.Column<double>(type: "float", nullable: false),
                    Kund_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordrar", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_Ordrar_Kunder_Kund_id",
                        column: x => x.Kund_id,
                        principalTable: "Kunder",
                        principalColumn: "Kund_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CyklarOrdrar",
                columns: table => new
                {
                    CykelOrder_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cykel_id = table.Column<int>(type: "int", nullable: false),
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    Cykel_id1 = table.Column<int>(type: "int", nullable: true),
                    Order_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyklarOrdrar", x => x.CykelOrder_id);
                    table.ForeignKey(
                        name: "FK_CyklarOrdrar_Cyklar_Cykel_id1",
                        column: x => x.Cykel_id1,
                        principalTable: "Cyklar",
                        principalColumn: "Cykel_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyklarOrdrar_Ordrar_Order_id1",
                        column: x => x.Order_id1,
                        principalTable: "Ordrar",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CyklarOrdrar_Cykel_id1",
                table: "CyklarOrdrar",
                column: "Cykel_id1");

            migrationBuilder.CreateIndex(
                name: "IX_CyklarOrdrar_Order_id1",
                table: "CyklarOrdrar",
                column: "Order_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_Kund_id",
                table: "Ordrar",
                column: "Kund_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyklarOrdrar");

            migrationBuilder.DropTable(
                name: "Cyklar");

            migrationBuilder.DropTable(
                name: "Ordrar");

            migrationBuilder.DropTable(
                name: "Kunder");
        }
    }
}
