using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodHamburger.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addAcompanhamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acompanhamentos_Pedidos_PedidoId",
                table: "Acompanhamentos");

            migrationBuilder.DropIndex(
                name: "IX_Acompanhamentos_PedidoId",
                table: "Acompanhamentos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Acompanhamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sanduiches",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AcompanhamentoPedido",
                columns: table => new
                {
                    AcompanhamentosId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanhamentoPedido", x => new { x.AcompanhamentosId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_AcompanhamentoPedido_Acompanhamentos_AcompanhamentosId",
                        column: x => x.AcompanhamentosId,
                        principalTable: "Acompanhamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcompanhamentoPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AcompanhamentoPedido_PedidoId",
                table: "AcompanhamentoPedido",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompanhamentoPedido");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Sanduiches",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Acompanhamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acompanhamentos_PedidoId",
                table: "Acompanhamentos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acompanhamentos_Pedidos_PedidoId",
                table: "Acompanhamentos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }
    }
}
