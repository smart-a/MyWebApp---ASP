using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyAppAPI.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.CreateTable(
                name: "TBL_JWT_CREDENTIALS",
                schema: "core",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_JWT_CREDENTIALS", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_APPLICANT_TYPE",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_APPLICANT_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_APPLICATION_TYPE",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_APPLICATION_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_DISABILITY",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_DISABILITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_GENDERS",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_GENDERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_MARITAL_STATUS",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_MARITAL_STATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_STATES",
                schema: "core",
                columns: table => new
                {
                    StatesId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_STATES", x => x.StatesId);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_TRADE",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_TRADE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_TRAIL_ACTIONS",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_TRAIL_ACTIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PICTURES",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(maxLength: 36, nullable: false),
                    FilePath = table.Column<string>(maxLength: 500, nullable: true),
                    FileName = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PICTURES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LK_LGA",
                schema: "core",
                columns: table => new
                {
                    LgaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatesId = table.Column<int>(nullable: false),
                    LgaName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LK_LGA", x => x.LgaId);
                    table.ForeignKey(
                        name: "FK_TBL_LK_LGA_TBL_LK_STATES_StatesId",
                        column: x => x.StatesId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_STATES",
                        principalColumn: "StatesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_TRAIL",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrailActionsId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    Narrative = table.Column<string>(maxLength: 400, nullable: false),
                    IpAddress = table.Column<string>(maxLength: 50, nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_TRAIL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_TRAIL_TBL_LK_TRAIL_ACTIONS_TrailActionsId",
                        column: x => x.TrailActionsId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_TRAIL_ACTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_APPLICANTS",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantTypeId = table.Column<int>(nullable: false),
                    ApplicationTypeId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true, defaultValue: ""),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Tel1 = table.Column<string>(maxLength: 11, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    StatesId = table.Column<int>(nullable: false),
                    LgaId = table.Column<int>(nullable: false),
                    LkTradeId = table.Column<int>(nullable: false, defaultValue: 8),
                    DisabilityId = table.Column<int>(nullable: false, defaultValue: 8),
                    NumOfChildren = table.Column<int>(nullable: false, defaultValue: 0),
                    AverageEarning = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 36, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 36, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(maxLength: 152, nullable: true),
                    RefKey = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_APPLICANTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_APPLICANT_TYPE_ApplicantTypeId",
                        column: x => x.ApplicantTypeId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_APPLICANT_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_APPLICATION_TYPE_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_APPLICATION_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_DISABILITY_DisabilityId",
                        column: x => x.DisabilityId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_DISABILITY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_GENDERS_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_GENDERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_LGA_LgaId",
                        column: x => x.LgaId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_LGA",
                        principalColumn: "LgaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_TRADE_LkTradeId",
                        column: x => x.LkTradeId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_TRADE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_MARITAL_STATUS_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_MARITAL_STATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_APPLICANTS_TBL_LK_STATES_StatesId",
                        column: x => x.StatesId,
                        principalSchema: "core",
                        principalTable: "TBL_LK_STATES",
                        principalColumn: "StatesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_ApplicantTypeId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "ApplicantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_ApplicationTypeId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_DisabilityId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "DisabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_FullName",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_GenderId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_LgaId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "LgaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_LkTradeId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "LkTradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_MaritalStatusId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_APPLICANTS_StatesId",
                schema: "core",
                table: "TBL_APPLICANTS",
                column: "StatesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_LK_LGA_StatesId",
                schema: "core",
                table: "TBL_LK_LGA",
                column: "StatesId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_TRAIL_TrailActionsId",
                schema: "core",
                table: "TBL_TRAIL",
                column: "TrailActionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_APPLICANTS",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_JWT_CREDENTIALS",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_PICTURES",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_TRAIL",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_APPLICANT_TYPE",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_APPLICATION_TYPE",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_DISABILITY",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_GENDERS",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_LGA",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_TRADE",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_MARITAL_STATUS",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_TRAIL_ACTIONS",
                schema: "core");

            migrationBuilder.DropTable(
                name: "TBL_LK_STATES",
                schema: "core");
        }
    }
}
