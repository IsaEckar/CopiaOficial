using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEGES.Shared.Migrations
{
    /// <inheritdoc />
    public partial class DBCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "DocTraceabilityTypes",
                columns: table => new
                {
                    DocTraceabilityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTraceabilityTypes", x => x.DocTraceabilityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GoalDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.GoalId);
                });

            migrationBuilder.CreateTable(
                name: "HUApprovalStatuses",
                columns: table => new
                {
                    HUApprovalStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HUApprovalStatuses", x => x.HUApprovalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "HUPriorities",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HUPriorities", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "HUPublicationStatuses",
                columns: table => new
                {
                    HUPublicationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HUPublicationStatuses", x => x.HUPublicationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "HUStatuses",
                columns: table => new
                {
                    HUStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HUStatuses", x => x.HUStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModuleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    ProjectStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.ProjectStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SourceDocTraceabilities",
                columns: table => new
                {
                    SorceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceName = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceDocTraceabilities", x => x.SorceId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KPIs",
                columns: table => new
                {
                    KPI_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KPI_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KPI_Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    KPI_Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Goal_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIs", x => x.KPI_ID);
                    table.ForeignKey(
                        name: "FK_KPIs_Goal_Goal_Id",
                        column: x => x.Goal_Id,
                        principalTable: "Goal",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    RequirementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequirementDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Goal_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.RequirementID);
                    table.ForeignKey(
                        name: "FK_Requirements_Goal_Goal_ID",
                        column: x => x.Goal_ID,
                        principalTable: "Goal",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Module_ID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Modules_Module_ID",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "secundaryKPIs",
                columns: table => new
                {
                    SecundaryKPI_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecundaryKPI_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecundaryKPI_Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    SecundaryKPI_Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    KPI_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secundaryKPIs", x => x.SecundaryKPI_Id);
                    table.ForeignKey(
                        name: "FK_secundaryKPIs_KPIs_KPI_Id",
                        column: x => x.KPI_Id,
                        principalTable: "KPIs",
                        principalColumn: "KPI_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocTraceabilities",
                columns: table => new
                {
                    DocTraceabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Requirement_ID = table.Column<int>(type: "int", nullable: false),
                    RequirementID = table.Column<int>(type: "int", nullable: false),
                    Source_Id = table.Column<int>(type: "int", nullable: true),
                    Type_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTraceabilities", x => x.DocTraceabilityId);
                    table.ForeignKey(
                        name: "FK_DocTraceabilities_DocTraceabilityTypes_Type_Id",
                        column: x => x.Type_Id,
                        principalTable: "DocTraceabilityTypes",
                        principalColumn: "DocTraceabilityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocTraceabilities_Requirements_RequirementID",
                        column: x => x.RequirementID,
                        principalTable: "Requirements",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocTraceabilities_SourceDocTraceabilities_Source_Id",
                        column: x => x.Source_Id,
                        principalTable: "SourceDocTraceabilities",
                        principalColumn: "SorceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UseCases",
                columns: table => new
                {
                    UseCaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UseCaseDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    UseCaseFrequency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UseCaseBussinessRule = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    UseCasePreondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCasePostcondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCaseExceptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCaseWarnings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseCaseCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UseCaseUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Requirement_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCases", x => x.UseCaseID);
                    table.ForeignKey(
                        name: "FK_UseCases_Requirements_Requirement_Id",
                        column: x => x.Requirement_Id,
                        principalTable: "Requirements",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserStories",
                columns: table => new
                {
                    UserStoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserStoryDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    AcceptanceCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    HUPriority_Id = table.Column<int>(type: "int", nullable: false),
                    HUPublicationStatus_Id = table.Column<int>(type: "int", nullable: false),
                    HUApprovalStatus_Id = table.Column<int>(type: "int", nullable: false),
                    HUStatus_Id = table.Column<int>(type: "int", nullable: false),
                    Requirement_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStories", x => x.UserStoryId);
                    table.ForeignKey(
                        name: "FK_UserStories_HUApprovalStatuses_HUApprovalStatus_Id",
                        column: x => x.HUApprovalStatus_Id,
                        principalTable: "HUApprovalStatuses",
                        principalColumn: "HUApprovalStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStories_HUPriorities_HUPriority_Id",
                        column: x => x.HUPriority_Id,
                        principalTable: "HUPriorities",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStories_HUPublicationStatuses_HUPublicationStatus_Id",
                        column: x => x.HUPublicationStatus_Id,
                        principalTable: "HUPublicationStatuses",
                        principalColumn: "HUPublicationStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStories_HUStatuses_HUStatus_Id",
                        column: x => x.HUStatus_Id,
                        principalTable: "HUStatuses",
                        principalColumn: "HUStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStories_Requirements_Requirement_Id",
                        column: x => x.Requirement_Id,
                        principalTable: "Requirements",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IssueStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Project_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IssueId);
                });

            migrationBuilder.CreateTable(
                name: "Rel_IssueGoals",
                columns: table => new
                {
                    Issue_ID = table.Column<int>(type: "int", nullable: false),
                    Goal_ID = table.Column<int>(type: "int", nullable: false),
                    Rel_IssueGoalId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel_IssueGoals", x => new { x.Issue_ID, x.Goal_ID });
                    table.ForeignKey(
                        name: "FK_Rel_IssueGoals_Goal_Goal_ID",
                        column: x => x.Goal_ID,
                        principalTable: "Goal",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rel_IssueGoals_Issues_Issue_ID",
                        column: x => x.Issue_ID,
                        principalTable: "Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ProjectStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    StakeHolder_ID = table.Column<int>(type: "int", nullable: false),
                    ProjectManager_ID = table.Column<int>(type: "int", nullable: false),
                    RequirementsEngineer_ID = table.Column<int>(type: "int", nullable: false),
                    ProjectStatus_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectStatuses_ProjectStatus_ID",
                        column: x => x.ProjectStatus_ID,
                        principalTable: "ProjectStatuses",
                        principalColumn: "ProjectStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rel_RolPermissions",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    Permission_ID = table.Column<int>(type: "int", nullable: false),
                    RolePermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rel_RolPermissions", x => new { x.Role_ID, x.Permission_ID });
                    table.ForeignKey(
                        name: "FK_Rel_RolPermissions_Permissions_Permission_ID",
                        column: x => x.Permission_ID,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId_Name",
                table: "Cities",
                columns: new[] { "StateId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocTraceabilities_RequirementID",
                table: "DocTraceabilities",
                column: "RequirementID");

            migrationBuilder.CreateIndex(
                name: "IX_DocTraceabilities_Source_Id",
                table: "DocTraceabilities",
                column: "Source_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DocTraceabilities_Type_Id",
                table: "DocTraceabilities",
                column: "Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_Project_ID",
                table: "Issues",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KPIs_Goal_Id",
                table: "KPIs",
                column: "Goal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_Name",
                table: "Modules",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Module_ID",
                table: "Permissions",
                column: "Module_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                table: "Permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManager_ID",
                table: "Projects",
                column: "ProjectManager_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectName",
                table: "Projects",
                column: "ProjectName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStatus_ID",
                table: "Projects",
                column: "ProjectStatus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_RequirementsEngineer_ID",
                table: "Projects",
                column: "RequirementsEngineer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StakeHolder_ID",
                table: "Projects",
                column: "StakeHolder_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_IssueGoals_Goal_ID",
                table: "Rel_IssueGoals",
                column: "Goal_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rel_RolPermissions_Permission_ID",
                table: "Rel_RolPermissions",
                column: "Permission_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_Goal_ID",
                table: "Requirements",
                column: "Goal_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_secundaryKPIs_KPI_Id",
                table: "secundaryKPIs",
                column: "KPI_Id");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId_Name",
                table: "States",
                columns: new[] { "CountryId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UseCases_Requirement_Id",
                table: "UseCases",
                column: "Requirement_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_City_Id",
                table: "Users",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_ID",
                table: "Users",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_HUApprovalStatus_Id",
                table: "UserStories",
                column: "HUApprovalStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_HUPriority_Id",
                table: "UserStories",
                column: "HUPriority_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_HUPublicationStatus_Id",
                table: "UserStories",
                column: "HUPublicationStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_HUStatus_Id",
                table: "UserStories",
                column: "HUStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_Requirement_Id",
                table: "UserStories",
                column: "Requirement_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_Project_ID",
                table: "Issues",
                column: "Project_ID",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ProjectManager_ID",
                table: "Projects",
                column: "ProjectManager_ID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_RequirementsEngineer_ID",
                table: "Projects",
                column: "RequirementsEngineer_ID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_StakeHolder_ID",
                table: "Projects",
                column: "StakeHolder_ID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rel_RolPermissions_Roles_Role_ID",
                table: "Rel_RolPermissions",
                column: "Role_ID",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "DocTraceabilities");

            migrationBuilder.DropTable(
                name: "Rel_IssueGoals");

            migrationBuilder.DropTable(
                name: "Rel_RolPermissions");

            migrationBuilder.DropTable(
                name: "secundaryKPIs");

            migrationBuilder.DropTable(
                name: "UseCases");

            migrationBuilder.DropTable(
                name: "UserStories");

            migrationBuilder.DropTable(
                name: "DocTraceabilityTypes");

            migrationBuilder.DropTable(
                name: "SourceDocTraceabilities");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "KPIs");

            migrationBuilder.DropTable(
                name: "HUApprovalStatuses");

            migrationBuilder.DropTable(
                name: "HUPriorities");

            migrationBuilder.DropTable(
                name: "HUPublicationStatuses");

            migrationBuilder.DropTable(
                name: "HUStatuses");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
