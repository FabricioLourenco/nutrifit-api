using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nutrifit.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration_inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlimentoIbge",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescricaoDoAlimento = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    CodigoDePreparacao = table.Column<int>(type: "integer", nullable: true),
                    DescricaoDaPreparacao = table.Column<string>(type: "text", nullable: false),
                    EnergiaKcal = table.Column<decimal>(type: "numeric", nullable: false),
                    ProteinaG = table.Column<decimal>(type: "numeric", nullable: false),
                    LipidiosTotaisG = table.Column<decimal>(type: "numeric", nullable: false),
                    CarboidratoG = table.Column<decimal>(type: "numeric", nullable: false),
                    FibraAlimentarTotalG = table.Column<decimal>(type: "numeric", nullable: false),
                    ColesterolMg = table.Column<decimal>(type: "numeric", nullable: true),
                    AGSaturaDosG = table.Column<decimal>(type: "numeric", nullable: false),
                    AGMonoG = table.Column<decimal>(type: "numeric", nullable: false),
                    AGPoliG = table.Column<decimal>(type: "numeric", nullable: false),
                    AGLinoleicoG = table.Column<decimal>(type: "numeric", nullable: false),
                    AGLinolenicoG = table.Column<decimal>(type: "numeric", nullable: false),
                    AGTransTotalG = table.Column<decimal>(type: "numeric", nullable: false),
                    AcucarTotalG = table.Column<decimal>(type: "numeric", nullable: false),
                    AcucarDeAdicaoG = table.Column<decimal>(type: "numeric", nullable: false),
                    CalcioMg = table.Column<decimal>(type: "numeric", nullable: false),
                    MagnesioMg = table.Column<decimal>(type: "numeric", nullable: false),
                    ManganesMg = table.Column<decimal>(type: "numeric", nullable: false),
                    FosforoMg = table.Column<decimal>(type: "numeric", nullable: false),
                    FerroMg = table.Column<decimal>(type: "numeric", nullable: false),
                    SodioMg = table.Column<decimal>(type: "numeric", nullable: false),
                    SodioDeAdicaoMg = table.Column<decimal>(type: "numeric", nullable: true),
                    PotassioMg = table.Column<decimal>(type: "numeric", nullable: false),
                    CobreMg = table.Column<decimal>(type: "numeric", nullable: false),
                    ZincoMg = table.Column<decimal>(type: "numeric", nullable: false),
                    SelenioMcg = table.Column<decimal>(type: "numeric", nullable: true),
                    RetinolMcg = table.Column<decimal>(type: "numeric", nullable: true),
                    VitaminaA_RAE_Mcg = table.Column<decimal>(type: "numeric", nullable: false),
                    TiaminaMg = table.Column<decimal>(type: "numeric", nullable: false),
                    RiboflavinaMg = table.Column<decimal>(type: "numeric", nullable: false),
                    NiacinaMg = table.Column<decimal>(type: "numeric", nullable: false),
                    Niacina_NE_Mg = table.Column<decimal>(type: "numeric", nullable: false),
                    PiridoxinaMg = table.Column<decimal>(type: "numeric", nullable: false),
                    CobalaminaMcg = table.Column<decimal>(type: "numeric", nullable: false),
                    Folato_DFE_Mcg = table.Column<decimal>(type: "numeric", nullable: false),
                    VitaminaD_Mcg = table.Column<decimal>(type: "numeric", nullable: false),
                    VitaminaE_Mg = table.Column<decimal>(type: "numeric", nullable: false),
                    VitaminaC_Mg = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentoIbge", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenhaHash = table.Column<string>(type: "text", nullable: false),
                    TipoUsuario = table.Column<int>(type: "integer", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    FotoPerfilUrl = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    AutenticacaoDoisFatoresHabilitada = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Calorias = table.Column<decimal>(type: "numeric", nullable: false),
                    Proteinas = table.Column<decimal>(type: "numeric", nullable: false),
                    Carboidratos = table.Column<decimal>(type: "numeric", nullable: false),
                    Gorduras = table.Column<decimal>(type: "numeric", nullable: false),
                    CodigoIBGE = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimento_AlimentoIbge_CodigoIBGE",
                        column: x => x.CodigoIBGE,
                        principalTable: "AlimentoIbge",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionista",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CrefNutricionista = table.Column<string>(type: "text", nullable: false),
                    Especialidades = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nutricionista_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sexo = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    NutricionistaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Nutricionista_NutricionistaId",
                        column: x => x.NutricionistaId,
                        principalTable: "Nutricionista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioPaciente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataComentario = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentarioPaciente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataHora = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvolucaoPaciente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Peso = table.Column<decimal>(type: "numeric", nullable: false),
                    Altura = table.Column<decimal>(type: "numeric", nullable: true),
                    Sintomas = table.Column<string>(type: "text", nullable: true),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolucaoPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvolucaoPaciente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoAlimentar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObservacoesGerais = table.Column<string>(type: "text", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoAlimentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoAlimentar_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PlanoAlimentarId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refeicao_PlanoAlimentar_PlanoAlimentarId",
                        column: x => x.PlanoAlimentarId,
                        principalTable: "PlanoAlimentar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemRefeicao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    UnidadeMedida = table.Column<int>(type: "integer", nullable: false),
                    RefeicaoId = table.Column<long>(type: "bigint", nullable: false),
                    AlimentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRefeicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRefeicao_Alimento_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRefeicao_Refeicao_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_CodigoIBGE",
                table: "Alimento",
                column: "CodigoIBGE");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioPaciente_PacienteId",
                table: "ComentarioPaciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EvolucaoPaciente_PacienteId",
                table: "EvolucaoPaciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRefeicao_AlimentoId",
                table: "ItemRefeicao",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRefeicao_RefeicaoId",
                table: "ItemRefeicao",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionista_UsuarioId",
                table: "Nutricionista",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_NutricionistaId",
                table: "Paciente",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_UsuarioId",
                table: "Paciente",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAlimentar_PacienteId",
                table: "PlanoAlimentar",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_PlanoAlimentarId",
                table: "Refeicao",
                column: "PlanoAlimentarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioPaciente");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "EvolucaoPaciente");

            migrationBuilder.DropTable(
                name: "ItemRefeicao");

            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Refeicao");

            migrationBuilder.DropTable(
                name: "AlimentoIbge");

            migrationBuilder.DropTable(
                name: "PlanoAlimentar");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Nutricionista");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
