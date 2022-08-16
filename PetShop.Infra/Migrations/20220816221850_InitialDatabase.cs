using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PetShop.Infra.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Verificado = table.Column<bool>(type: "boolean", nullable: false),
                    Acessos = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Raca = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Cor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Porte = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cobranca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCobranca = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Desconto = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    ColaboradorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobranca_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cobranca_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobrancaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<int>(type: "integer", nullable: true),
                    ServicoId = table.Column<int>(type: "integer", nullable: true),
                    Quantidade = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false),
                    CobrancaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrancaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobrancaItem_Cobranca_CobrancaId",
                        column: x => x.CobrancaId,
                        principalTable: "Cobranca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CobrancaItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CobrancaItem_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuarioId",
                table: "Cliente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_ClienteId",
                table: "Cobranca",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_ColaboradorId",
                table: "Cobranca",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrancaItem_CobrancaId",
                table: "CobrancaItem",
                column: "CobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrancaItem_ProdutoId",
                table: "CobrancaItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrancaItem_ServicoId",
                table: "CobrancaItem",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_UsuarioId",
                table: "Colaborador",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ClienteId",
                table: "Pet",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrancaItem");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Cobranca");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
