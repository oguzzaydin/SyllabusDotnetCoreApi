using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DPA.Database.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Faculty");

            migrationBuilder.EnsureSchema(
                name: "Department");

            migrationBuilder.EnsureSchema(
                name: "Syllabus");

            migrationBuilder.CreateTable(
                name: "Faculty",
                schema: "Faculty",
                columns: table => new
                {
                    FacultyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    FacultyCode = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                schema: "Faculty",
                columns: table => new
                {
                    LessonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    LessonCode = table.Column<string>(nullable: false),
                    AKTS = table.Column<int>(nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    WeeklyHour = table.Column<int>(nullable: false),
                    SemesterType = table.Column<int>(nullable: false),
                    LessonType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.LessonId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Surname = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 500, nullable: false),
                    Roles = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "Faculty",
                columns: table => new
                {
                    DepartmentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    DepartmentCode = table.Column<string>(maxLength: 50, nullable: false),
                    FacultyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "Faculty",
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Faculty",
                columns: table => new
                {
                    LocationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    FacultyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "Faculty",
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonGroup",
                schema: "Faculty",
                columns: table => new
                {
                    LessonGroupId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    GroupType = table.Column<int>(nullable: false),
                    LessonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonGroup", x => x.LessonGroupId);
                    table.ForeignKey(
                        name: "FK_LessonGroup_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Faculty",
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Constraint",
                schema: "User",
                columns: table => new
                {
                    ConstraintId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    StartTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    IsFreeDay = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    WeeklyHour = table.Column<int>(nullable: false),
                    EducationType = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraint", x => x.ConstraintId);
                    table.ForeignKey(
                        name: "FK_Constraint_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLesson",
                schema: "User",
                columns: table => new
                {
                    UserLessonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    LessonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLesson", x => x.UserLessonId);
                    table.ForeignKey(
                        name: "FK_UserLesson_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Faculty",
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLesson_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersLog",
                schema: "User",
                columns: table => new
                {
                    UserLogId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    LogType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 8000, nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLog", x => x.UserLogId);
                    table.ForeignKey(
                        name: "FK_UsersLog_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentInstructor",
                schema: "Department",
                columns: table => new
                {
                    DepartmentInstructorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInstructor", x => x.DepartmentInstructorId);
                    table.ForeignKey(
                        name: "FK_DepartmentInstructor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Faculty",
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentInstructor_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLesson",
                schema: "Faculty",
                columns: table => new
                {
                    DepartmentLessonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    LessonId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLesson", x => x.DepartmentLessonId);
                    table.ForeignKey(
                        name: "FK_DepartmentLesson_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Faculty",
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLesson_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Faculty",
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Syllabus",
                schema: "Syllabus",
                columns: table => new
                {
                    SyllabusId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PeriodType = table.Column<int>(nullable: false),
                    EducationType = table.Column<int>(nullable: false),
                    WeeklyHour = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabus", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_Syllabus_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Faculty",
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitLesson",
                schema: "Syllabus",
                columns: table => new
                {
                    UnitLessonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    LessonId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    SyllabusId = table.Column<long>(nullable: false),
                    StarTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    GroupType = table.Column<int>(nullable: false),
                    DayOfTheWeekType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitLesson", x => x.UnitLessonId);
                    table.ForeignKey(
                        name: "FK_UnitLesson_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Faculty",
                        principalTable: "Lesson",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitLesson_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Faculty",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitLesson_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalSchema: "Syllabus",
                        principalTable: "Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitLesson_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Faculty",
                columns: new[] { "FacultyId", "CreatedDate", "FacultyCode", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7679), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7681) },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7910), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7911) },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7941), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7942) },
                    { 4L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7966), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(7966) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7213), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7214), 3 },
                    { 23L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7187), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7188), 3 },
                    { 22L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7158), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7161), 3 },
                    { 21L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7132), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7134), 3 },
                    { 19L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7081), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7082), 3 },
                    { 18L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7056), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7057), 3 },
                    { 17L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7028), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7029), 3 },
                    { 16L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6869), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6870), 3 },
                    { 15L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6842), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6843), 3 },
                    { 14L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6816), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6817), 3 },
                    { 13L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6639), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6640), 3 },
                    { 20L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7106), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(7107), 3 },
                    { 11L, 6, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6505), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6506), 4 },
                    { 12L, 6, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6530), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6531), 3 },
                    { 1L, 4, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(5136), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(5138), 4 },
                    { 3L, 6, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6289), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6290), 4 },
                    { 4L, 4, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6317), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6318), 2 },
                    { 5L, 4, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6343), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6344), 2 },
                    { 2L, 6, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6238), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6239), 5 },
                    { 7L, 4, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6399), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6400), 4 },
                    { 8L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6424), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6425), 3 },
                    { 9L, 2, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6451), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6452), 2 },
                    { 10L, 5, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6479), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6480), 3 },
                    { 6L, 6, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6372), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(6373), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4651), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4652) },
                    { 11L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4021), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4022) },
                    { 17L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4563), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4564) },
                    { 16L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4472), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4473) },
                    { 15L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4384), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4385) },
                    { 14L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4287), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4288) },
                    { 13L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4197), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4198) },
                    { 12L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4109), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4110) },
                    { 10L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3931), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3932) },
                    { 4L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3361), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3362) },
                    { 8L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3740), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3741) },
                    { 7L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3652), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3653) },
                    { 6L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3563), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3565) },
                    { 5L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3452), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3453) },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3264), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3265) },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3037), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3039) },
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 825, DateTimeKind.Local).AddTicks(8834), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 28, 2, 35, 48, 825, DateTimeKind.Local).AddTicks(8860) },
                    { 19L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4765), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4766) },
                    { 9L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3828), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(3829) },
                    { 20L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4856), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(4857) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(1871), "BM310", 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(1873) },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(2102), "BM311", 1L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(2104) },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(2138), "BM312", 1L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(2138) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9643), 3, 17L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9644) },
                    { 36L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9620), 2, 17L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9621) },
                    { 35L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9596), 1, 17L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9597) },
                    { 34L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9572), 3, 16L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9573) },
                    { 33L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9537), 2, 16L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9538) },
                    { 32L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9513), 1, 16L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9514) },
                    { 31L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9490), 3, 15L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9491) },
                    { 29L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9440), 1, 15L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9441) },
                    { 38L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9666), 1, 18L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9667) },
                    { 28L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9416), 3, 14L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9417) },
                    { 27L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9393), 2, 14L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9394) },
                    { 26L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9369), 1, 14L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9370) },
                    { 25L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9345), 3, 13L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9346) },
                    { 24L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9321), 2, 13L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9322) },
                    { 23L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9298), 1, 13L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9299) },
                    { 30L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9466), 2, 15L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9467) },
                    { 39L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9690), 2, 18L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9690) },
                    { 41L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9738), 1, 19L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9739) },
                    { 22L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9273), 2, 12L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9274) },
                    { 58L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(163), 3, 24L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(164) },
                    { 57L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(139), 2, 24L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(140) },
                    { 56L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(117), 1, 24L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(117) },
                    { 55L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(93), 3, 23L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(94) },
                    { 54L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(69), 2, 23L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(70) },
                    { 53L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(46), 1, 23L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(47) },
                    { 52L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(23), 3, 22L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(24) },
                    { 40L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9713), 3, 18L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9715) },
                    { 51L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local), 2, 22L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1) },
                    { 49L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9954), 3, 21L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9955) },
                    { 48L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9929), 2, 21L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9930) },
                    { 47L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9905), 1, 21L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9906) },
                    { 46L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9881), 3, 20L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9882) },
                    { 45L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9858), 2, 20L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9859) },
                    { 44L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9834), 1, 20L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9835) },
                    { 43L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9810), 3, 19L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9811) },
                    { 50L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9977), 1, 22L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9978) },
                    { 21L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9250), 1, 12L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9251) },
                    { 42L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9761), 2, 19L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9762) },
                    { 19L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9202), 1, 11L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9203) },
                    { 20L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9226), 2, 11L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9227) },
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8572), 1, 1L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8574) },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8777), 2, 1L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8779) },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8805), 1, 2L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8806) },
                    { 4L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8830), 2, 2L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8831) },
                    { 6L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8892), 2, 3L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8893) },
                    { 7L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8916), 1, 4L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8917) },
                    { 8L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8939), 1, 5L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8940) },
                    { 9L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8963), 1, 6L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8964) },
                    { 5L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8854), 1, 3L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8855) },
                    { 11L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9013), 1, 7L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9014) },
                    { 10L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8989), 2, 6L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(8990) },
                    { 17L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9153), 1, 10L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9154) },
                    { 16L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9130), 2, 9L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9131) },
                    { 15L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9107), 1, 9L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9107) },
                    { 18L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9178), 2, 10L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9180) },
                    { 13L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9060), 1, 8L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9061) },
                    { 12L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9037), 2, 7L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9038) },
                    { 14L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9083), 2, 8L, new DateTime(2019, 4, 28, 2, 35, 48, 829, DateTimeKind.Local).AddTicks(9084) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6357), 1L, "1007", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6358) },
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(5709), 1L, "1000", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(5712) },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6208), 1L, "1001", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6209) },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6242), 1L, "1002", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6243) },
                    { 4L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6265), 1L, "1003", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6266) },
                    { 5L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6287), 1L, "1004", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6288) },
                    { 6L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6312), 1L, "1005", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6313) },
                    { 7L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6335), 1L, "1006", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6336) },
                    { 9L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6379), 1L, "1008", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6380) },
                    { 14L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6505), 1L, "10013", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6506) },
                    { 11L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6437), 1L, "10010", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6438) },
                    { 12L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6461), 1L, "10011", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6462) },
                    { 13L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6483), 1L, "10012", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6484) },
                    { 15L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6527), 1L, "10014", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6528) },
                    { 16L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6758), 1L, "10015", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6759) },
                    { 17L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6785), 1L, "10016", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6786) },
                    { 10L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6403), 1L, "1009", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6404) },
                    { 18L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6810), 1L, "10017", new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(6811) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9508), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9509), 7L, 14 },
                    { 16L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9750), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9751), 17L, 16 },
                    { 7L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9532), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9533), 8L, 8 },
                    { 15L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9727), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9728), 16L, 12 },
                    { 8L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9555), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9556), 9L, 10 },
                    { 10L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9608), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9609), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9581), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9582), 10L, 12 },
                    { 13L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9679), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9680), 14L, 16 },
                    { 11L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9631), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9632), 12L, 12 },
                    { 5L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9481), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9482), 6L, 12 },
                    { 14L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9704), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9705), 15L, 16 },
                    { 17L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9773), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9774), 18L, 9 },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9370), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9371), 3L, 6 },
                    { 4L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9456), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9457), 5L, 10 },
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(8831), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(8834), 2L, 4 },
                    { 19L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9830), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9831), 20L, 16 },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9431), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9432), 4L, 8 },
                    { 18L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9798), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9798), 19L, 16 },
                    { 12L, new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9656), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 4, 28, 2, 35, 48, 828, DateTimeKind.Local).AddTicks(9657), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2578), 17L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2579), 17L },
                    { 18L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2062), 8L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2063), 13L },
                    { 28L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2293), 13L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2294), 13L },
                    { 29L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2316), 13L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2317), 13L },
                    { 9L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1852), 3L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1853), 13L },
                    { 30L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2339), 13L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2340), 13L },
                    { 42L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2625), 17L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2626), 17L },
                    { 10L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1876), 4L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1877), 14L },
                    { 49L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2784), 20L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2785), 20L },
                    { 21L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2132), 9L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2133), 14L },
                    { 31L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2363), 14L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2364), 14L },
                    { 32L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2387), 14L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2387), 14L },
                    { 45L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2693), 18L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2694), 18L },
                    { 33L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2409), 14L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2410), 14L },
                    { 48L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2761), 19L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2762), 19L },
                    { 43L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2647), 18L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2648), 18L },
                    { 35L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2464), 15L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2465), 15L },
                    { 36L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2487), 15L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2488), 15L },
                    { 47L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2739), 19L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2740), 19L },
                    { 61L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3058), 24L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3059), 15L },
                    { 46L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2716), 19L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2717), 19L },
                    { 37L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2510), 16L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2511), 16L },
                    { 44L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2670), 18L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2671), 18L },
                    { 38L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2532), 16L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2533), 16L },
                    { 39L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2555), 16L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2556), 16L },
                    { 41L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2602), 17L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2603), 17L },
                    { 34L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2442), 15L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2443), 15L },
                    { 4L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1723), 2L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1724), 2L },
                    { 27L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2269), 12L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2270), 12L },
                    { 11L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1899), 5L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1900), 7L },
                    { 24L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2201), 11L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2202), 6L },
                    { 57L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2969), 22L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2970), 5L },
                    { 17L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2037), 8L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2038), 5L },
                    { 8L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1828), 3L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1830), 5L },
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1213), 1L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1215), 5L },
                    { 25L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2224), 11L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2225), 7L },
                    { 56L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2946), 22L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2947), 4L },
                    { 12L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1922), 6L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1923), 4L },
                    { 55L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2924), 22L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2925), 3L },
                    { 23L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2178), 10L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2179), 3L },
                    { 7L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1805), 3L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1806), 3L },
                    { 22L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2155), 10L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2156), 2L },
                    { 50L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2807), 20L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2808), 20L },
                    { 26L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2246), 12L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2247), 4L },
                    { 60L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3036), 23L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3037), 12L },
                    { 63L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3112), 24L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3113), 7L },
                    { 19L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2085), 9L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2086), 8L },
                    { 15L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1991), 7L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1992), 12L },
                    { 6L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1782), 2L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1783), 12L },
                    { 59L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3014), 23L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3014), 11L },
                    { 14L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1968), 7L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1969), 11L },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1700), 1L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1701), 11L },
                    { 58L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2991), 23L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2992), 10L },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1669), 1L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1670), 8L },
                    { 54L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2899), 21L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2900), 10L },
                    { 13L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1945), 6L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1946), 10L },
                    { 62L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3089), 24L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(3090), 9L },
                    { 53L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2876), 21L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2877), 9L },
                    { 20L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2108), 9L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2109), 9L },
                    { 5L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1746), 2L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(1747), 9L },
                    { 52L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2853), 21L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2854), 8L },
                    { 16L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2015), 7L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2016), 10L },
                    { 51L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2829), 20L, new DateTime(2019, 4, 28, 2, 35, 48, 830, DateTimeKind.Local).AddTicks(2830), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3198), 1L, 1L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3200) },
                    { 22L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4165), 1L, 22L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4166) },
                    { 21L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4142), 1L, 21L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4143) },
                    { 20L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4119), 1L, 20L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4120) },
                    { 19L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4096), 1L, 19L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4097) },
                    { 18L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4073), 1L, 18L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4074) },
                    { 17L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4048), 1L, 17L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4049) },
                    { 16L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4024), 1L, 16L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4025) },
                    { 15L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4001), 1L, 15L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4002) },
                    { 14L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3977), 1L, 14L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3978) },
                    { 13L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3953), 1L, 13L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3954) },
                    { 12L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3919), 1L, 12L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3920) },
                    { 11L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3894), 1L, 11L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3895) },
                    { 10L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3871), 1L, 10L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3872) },
                    { 9L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3845), 1L, 9L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3846) },
                    { 8L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3822), 1L, 8L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3823) },
                    { 7L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3798), 1L, 7L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3799) },
                    { 6L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3775), 1L, 6L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3776) },
                    { 5L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3748), 1L, 5L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3749) },
                    { 4L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3725), 1L, 4L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3726) },
                    { 3L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3701), 1L, 3L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3702) },
                    { 2L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3668), 1L, 2L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(3668) },
                    { 23L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4188), 1L, 23L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4189) },
                    { 24L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4211), 1L, 24L, new DateTime(2019, 4, 28, 2, 35, 48, 831, DateTimeKind.Local).AddTicks(4212) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentInstructor_DepartmentId",
                schema: "Department",
                table: "DepartmentInstructor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentInstructor_UserId",
                schema: "Department",
                table: "DepartmentInstructor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                schema: "Faculty",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLesson_DepartmentId",
                schema: "Faculty",
                table: "DepartmentLesson",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLesson_LessonId",
                schema: "Faculty",
                table: "DepartmentLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonGroup_LessonId",
                schema: "Faculty",
                table: "LessonGroup",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_FacultyId",
                schema: "Faculty",
                table: "Location",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_DepartmentId",
                schema: "Syllabus",
                table: "Syllabus",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitLesson_LessonId",
                schema: "Syllabus",
                table: "UnitLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitLesson_LocationId",
                schema: "Syllabus",
                table: "UnitLesson",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitLesson_SyllabusId",
                schema: "Syllabus",
                table: "UnitLesson",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitLesson_UserId",
                schema: "Syllabus",
                table: "UnitLesson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Constraint_UserId",
                schema: "User",
                table: "Constraint",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "User",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                schema: "User",
                table: "User",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLesson_LessonId",
                schema: "User",
                table: "UserLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLesson_UserId",
                schema: "User",
                table: "UserLesson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLog_UserId",
                schema: "User",
                table: "UsersLog",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentInstructor",
                schema: "Department");

            migrationBuilder.DropTable(
                name: "DepartmentLesson",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "LessonGroup",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "UnitLesson",
                schema: "Syllabus");

            migrationBuilder.DropTable(
                name: "Constraint",
                schema: "User");

            migrationBuilder.DropTable(
                name: "UserLesson",
                schema: "User");

            migrationBuilder.DropTable(
                name: "UsersLog",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "Syllabus",
                schema: "Syllabus");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "User",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "Faculty",
                schema: "Faculty");
        }
    }
}
