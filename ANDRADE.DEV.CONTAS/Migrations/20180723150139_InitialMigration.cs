using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRA_TRANSACOES",
                columns: table => new
                {
                    tra_transacao_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tra_descricao = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    tra_sigla = table.Column<string>(type: "VARCHAR(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRA_TRANSACOES", x => x.tra_transacao_id);
                });

            migrationBuilder.CreateTable(
                name: "TRD_TRANSACOES_DETALHAMENTO",
                columns: table => new
                {
                    trd_transacao_detalhamento_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    trd_valor_entrada = table.Column<decimal>(type: "NUMERIC(11, 2)", nullable: true),
                    trd_valor_saida = table.Column<decimal>(type: "NUMERIC(11, 2)", nullable: true),
                    trd_ordem = table.Column<int>(nullable: true),
                    tra_transacoes_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRD_TRANSACOES_DETALHAMENTO", x => x.trd_transacao_detalhamento_id);
                    table.ForeignKey(
                        name: "FK_TRD_TRANSACOES_DETALHAMENTO_TRA_TRANSACOES_tra_transacoes_id",
                        column: x => x.tra_transacoes_id,
                        principalTable: "TRA_TRANSACOES",
                        principalColumn: "tra_transacao_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRD_TRANSACOES_DETALHAMENTO_tra_transacoes_id",
                table: "TRD_TRANSACOES_DETALHAMENTO",
                column: "tra_transacoes_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRD_TRANSACOES_DETALHAMENTO");

            migrationBuilder.DropTable(
                name: "TRA_TRANSACOES");
        }
    }
}
