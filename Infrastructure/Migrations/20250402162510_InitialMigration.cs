using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Symbol = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    EventRules = table.Column<string>(type: "JSON", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TelegramId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2025, 4, 2, 16, 25, 10, 44, DateTimeKind.Utc).AddTicks(2452))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    ScenarioId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Condition = table.Column<string>(type: "JSON", nullable: false),
                    RewardType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    RewardValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    AdditionalData = table.Column<string>(type: "JSON", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.ScenarioId);
                    table.ForeignKey(
                        name: "FK_Scenarios_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserBalances",
                columns: table => new
                {
                    BalanceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2025, 4, 2, 16, 25, 10, 43, DateTimeKind.Utc).AddTicks(9655))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBalances", x => x.BalanceId);
                    table.ForeignKey(
                        name: "FK_UserBalances_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBalances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Details = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2025, 4, 2, 16, 25, 10, 44, DateTimeKind.Utc).AddTicks(8283))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_UserTransactions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTransactions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTransactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventParticipation",
                columns: table => new
                {
                    ParticipationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ScenarioId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "pending"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipation", x => x.ParticipationId);
                    table.ForeignKey(
                        name: "FK_EventParticipation_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "ScenarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    WinnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ScenarioId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RewardValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2025, 4, 2, 16, 25, 10, 45, DateTimeKind.Utc).AddTicks(3644))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.WinnerId);
                    table.ForeignKey(
                        name: "FK_Winners_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Winners_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "ScenarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Winners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Name",
                table: "Currencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Symbol",
                table: "Currencies",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipation_ScenarioId",
                table: "EventParticipation",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipation_UserId",
                table: "EventParticipation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenarios_EventId",
                table: "Scenarios",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBalances_CurrencyId",
                table: "UserBalances",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBalances_UserId",
                table: "UserBalances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "idx_users_telegram_id",
                table: "Users",
                column: "TelegramId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactions_CurrencyId",
                table: "UserTransactions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactions_EventId",
                table: "UserTransactions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactions_UserId",
                table: "UserTransactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_CurrencyId",
                table: "Winners",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_ScenarioId",
                table: "Winners",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_UserId",
                table: "Winners",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipation");

            migrationBuilder.DropTable(
                name: "UserBalances");

            migrationBuilder.DropTable(
                name: "UserTransactions");

            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
