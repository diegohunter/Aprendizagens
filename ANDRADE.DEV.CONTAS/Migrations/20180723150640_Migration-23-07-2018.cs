using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class Migration23072018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRD_TRANSACOES_DETALHAMENTO_TRA_TRANSACOES_tra_transacoes_id",
                table: "TRD_TRANSACOES_DETALHAMENTO");

            migrationBuilder.RenameColumn(
                name: "tra_transacoes_id",
                table: "TRD_TRANSACOES_DETALHAMENTO",
                newName: "tra_transacao_id");

            migrationBuilder.RenameIndex(
                name: "IX_TRD_TRANSACOES_DETALHAMENTO_tra_transacoes_id",
                table: "TRD_TRANSACOES_DETALHAMENTO",
                newName: "IX_TRD_TRANSACOES_DETALHAMENTO_tra_transacao_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TRD_TRANSACOES_DETALHAMENTO_TRA_TRANSACOES_tra_transacao_id",
                table: "TRD_TRANSACOES_DETALHAMENTO",
                column: "tra_transacao_id",
                principalTable: "TRA_TRANSACOES",
                principalColumn: "tra_transacao_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRD_TRANSACOES_DETALHAMENTO_TRA_TRANSACOES_tra_transacao_id",
                table: "TRD_TRANSACOES_DETALHAMENTO");

            migrationBuilder.RenameColumn(
                name: "tra_transacao_id",
                table: "TRD_TRANSACOES_DETALHAMENTO",
                newName: "tra_transacoes_id");

            migrationBuilder.RenameIndex(
                name: "IX_TRD_TRANSACOES_DETALHAMENTO_tra_transacao_id",
                table: "TRD_TRANSACOES_DETALHAMENTO",
                newName: "IX_TRD_TRANSACOES_DETALHAMENTO_tra_transacoes_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TRD_TRANSACOES_DETALHAMENTO_TRA_TRANSACOES_tra_transacoes_id",
                table: "TRD_TRANSACOES_DETALHAMENTO",
                column: "tra_transacoes_id",
                principalTable: "TRA_TRANSACOES",
                principalColumn: "tra_transacao_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
