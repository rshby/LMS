using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_university",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_university", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalChapter = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Level_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_class_tb_m_category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "tb_m_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_class_tb_m_level_Level_Id",
                        column: x => x.Level_Id,
                        principalTable: "tb_m_level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_city",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_city", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_city_tb_m_province_Province_Id",
                        column: x => x.Province_Id,
                        principalTable: "tb_m_province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    University_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_tr_education_tb_m_university_University_Id",
                        column: x => x.University_Id,
                        principalTable: "tb_m_university",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chapter = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_section_tb_m_class_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "tb_m_class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_district",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_district", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_district_tb_m_city_City_Id",
                        column: x => x.City_Id,
                        principalTable: "tb_m_city",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_subdistrict",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_subdistrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_subdistrict_tb_m_district_District_Id",
                        column: x => x.District_Id,
                        principalTable: "tb_m_district",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subdistrict_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_tr_address_tb_m_subdistrict_Subdistrict_Id",
                        column: x => x.Subdistrict_Id,
                        principalTable: "tb_m_subdistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_user",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Education_Id = table.Column<int>(type: "int", nullable: false),
                    Address_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_user", x => x.Email);
                    table.ForeignKey(
                        name: "FK_tb_m_user_tb_tr_address_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "tb_tr_address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_user_tb_tr_education_Education_Id",
                        column: x => x.Education_Id,
                        principalTable: "tb_tr_education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_account",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<int>(type: "int", nullable: false),
                    ExpiredToken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_account", x => x.Email);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_tb_m_role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "tb_m_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_tb_m_user_Email",
                        column: x => x.Email,
                        principalTable: "tb_m_user",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_takenclass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgressChapter = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_takenclass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_tr_takenclass_tb_m_class_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "tb_m_class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_takenclass_tb_m_user_Email",
                        column: x => x.Email,
                        principalTable: "tb_m_user",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakenClass_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_tr_certificate_tb_tr_takenclass_TakenClass_Id",
                        column: x => x.TakenClass_Id,
                        principalTable: "tb_tr_takenclass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakenClass_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_tr_feedback_tb_tr_takenclass_TakenClass_Id",
                        column: x => x.TakenClass_Id,
                        principalTable: "tb_tr_takenclass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_city_Province_Id",
                table: "tb_m_city",
                column: "Province_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_class_Category_Id",
                table: "tb_m_class",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_class_Level_Id",
                table: "tb_m_class",
                column: "Level_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_district_City_Id",
                table: "tb_m_district",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_section_Class_Id",
                table: "tb_m_section",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_subdistrict_District_Id",
                table: "tb_m_subdistrict",
                column: "District_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_user_Address_Id",
                table: "tb_m_user",
                column: "Address_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_user_Education_Id",
                table: "tb_m_user",
                column: "Education_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_Role_Id",
                table: "tb_tr_account",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_address_Subdistrict_Id",
                table: "tb_tr_address",
                column: "Subdistrict_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_certificate_TakenClass_Id",
                table: "tb_tr_certificate",
                column: "TakenClass_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_education_University_Id",
                table: "tb_tr_education",
                column: "University_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_feedback_TakenClass_Id",
                table: "tb_tr_feedback",
                column: "TakenClass_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_takenclass_Class_Id",
                table: "tb_tr_takenclass",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_takenclass_Email",
                table: "tb_tr_takenclass",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_section");

            migrationBuilder.DropTable(
                name: "tb_tr_account");

            migrationBuilder.DropTable(
                name: "tb_tr_certificate");

            migrationBuilder.DropTable(
                name: "tb_tr_feedback");

            migrationBuilder.DropTable(
                name: "tb_m_role");

            migrationBuilder.DropTable(
                name: "tb_tr_takenclass");

            migrationBuilder.DropTable(
                name: "tb_m_class");

            migrationBuilder.DropTable(
                name: "tb_m_user");

            migrationBuilder.DropTable(
                name: "tb_m_category");

            migrationBuilder.DropTable(
                name: "tb_m_level");

            migrationBuilder.DropTable(
                name: "tb_tr_address");

            migrationBuilder.DropTable(
                name: "tb_tr_education");

            migrationBuilder.DropTable(
                name: "tb_m_subdistrict");

            migrationBuilder.DropTable(
                name: "tb_m_university");

            migrationBuilder.DropTable(
                name: "tb_m_district");

            migrationBuilder.DropTable(
                name: "tb_m_city");

            migrationBuilder.DropTable(
                name: "tb_m_province");
        }
    }
}
