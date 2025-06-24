using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrifit.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteemEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimento_AlimentoIbge_CodigoIBGE",
                table: "Alimento");

            migrationBuilder.DropColumn(
                name: "AGLinoleicoG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "AGLinolenicoG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "AGMonoG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "AGPoliG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "AGSaturaDosG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "AGTransTotalG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "AcucarDeAdicaoG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "AcucarTotalG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "CobalaminaMcg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "CodigoDePreparacao",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "DescricaoDaPreparacao",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "DescricaoDoAlimento",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "FibraAlimentarTotalG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "Folato_DFE_Mcg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "LipidiosTotaisG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "Niacina_NE_Mg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "VitaminaA_RAE_Mcg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "VitaminaC_Mg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "VitaminaD_Mcg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "VitaminaE_Mg",
                table: "AlimentoIbge");

            migrationBuilder.RenameColumn(
                name: "SodioDeAdicaoMg",
                table: "AlimentoIbge",
                newName: "Umidade");

            migrationBuilder.RenameColumn(
                name: "SelenioMcg",
                table: "AlimentoIbge",
                newName: "LipideosG");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "AlimentoIbge",
                newName: "NumeroDoAlimento");

            migrationBuilder.RenameColumn(
                name: "CodigoIBGE",
                table: "Alimento",
                newName: "AlimentoIbgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Alimento_CodigoIBGE",
                table: "Alimento",
                newName: "IX_Alimento_AlimentoIbgeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "ZincoMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "TiaminaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "SodioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "RiboflavinaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "RetinolMcg",
                table: "AlimentoIbge",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProteinaG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "PotassioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "PiridoxinaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "NiacinaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManganesMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "MagnesioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "FosforoMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "FerroMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "EnergiaKcal",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "ColesterolMg",
                table: "AlimentoIbge",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CobreMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "CarboidratoG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "CalcioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "CategoriaDoAlimento",
                table: "AlimentoIbge",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CinzasG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoDosAlimentos",
                table: "AlimentoIbge",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EnergiaKJ",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FibraAlimentarG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RAEMcg",
                table: "AlimentoIbge",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "REMcg",
                table: "AlimentoIbge",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VitaminaCMg",
                table: "AlimentoIbge",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alimento_AlimentoIbge_AlimentoIbgeId",
                table: "Alimento",
                column: "AlimentoIbgeId",
                principalTable: "AlimentoIbge",
                principalColumn: "NumeroDoAlimento",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimento_AlimentoIbge_AlimentoIbgeId",
                table: "Alimento");

            migrationBuilder.DropColumn(
                name: "CategoriaDoAlimento",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "CinzasG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "DescricaoDosAlimentos",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "EnergiaKJ",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "FibraAlimentarG",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "RAEMcg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "REMcg",
                table: "AlimentoIbge");

            migrationBuilder.DropColumn(
                name: "VitaminaCMg",
                table: "AlimentoIbge");

            migrationBuilder.RenameColumn(
                name: "Umidade",
                table: "AlimentoIbge",
                newName: "SodioDeAdicaoMg");

            migrationBuilder.RenameColumn(
                name: "LipideosG",
                table: "AlimentoIbge",
                newName: "SelenioMcg");

            migrationBuilder.RenameColumn(
                name: "NumeroDoAlimento",
                table: "AlimentoIbge",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "AlimentoIbgeId",
                table: "Alimento",
                newName: "CodigoIBGE");

            migrationBuilder.RenameIndex(
                name: "IX_Alimento_AlimentoIbgeId",
                table: "Alimento",
                newName: "IX_Alimento_CodigoIBGE");

            migrationBuilder.AlterColumn<decimal>(
                name: "ZincoMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TiaminaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SodioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RiboflavinaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RetinolMcg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProteinaG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PotassioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PiridoxinaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NiacinaMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ManganesMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MagnesioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FosforoMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FerroMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EnergiaKcal",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ColesterolMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CobreMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CarboidratoG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CalcioMg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AGLinoleicoG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AGLinolenicoG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AGMonoG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AGPoliG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AGSaturaDosG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AGTransTotalG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AcucarDeAdicaoG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AcucarTotalG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "AlimentoIbge",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CobalaminaMcg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CodigoDePreparacao",
                table: "AlimentoIbge",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoDaPreparacao",
                table: "AlimentoIbge",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoDoAlimento",
                table: "AlimentoIbge",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "FibraAlimentarTotalG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Folato_DFE_Mcg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LipidiosTotaisG",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Niacina_NE_Mg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminaA_RAE_Mcg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminaC_Mg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminaD_Mcg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VitaminaE_Mg",
                table: "AlimentoIbge",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Alimento_AlimentoIbge_CodigoIBGE",
                table: "Alimento",
                column: "CodigoIBGE",
                principalTable: "AlimentoIbge",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
