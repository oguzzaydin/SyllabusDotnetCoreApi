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
                    SemesterType = table.Column<int>(nullable: false),
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
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5616), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5619) },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5902), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5903) },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5934), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5935) },
                    { 4L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5960), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(5960) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4479), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4480), 3 },
                    { 23L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4454), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4455), 3 },
                    { 22L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4426), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4427), 3 },
                    { 21L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4401), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4402), 3 },
                    { 19L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4349), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4350), 3 },
                    { 18L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4322), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4323), 3 },
                    { 17L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4294), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4295), 3 },
                    { 16L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4268), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4270), 3 },
                    { 15L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4243), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4244), 3 },
                    { 14L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4218), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4219), 3 },
                    { 13L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4190), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4191), 3 },
                    { 20L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4375), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4376), 3 },
                    { 11L, 6, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4114), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4115), 4 },
                    { 12L, 6, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4146), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4147), 3 },
                    { 1L, 4, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(1942), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(1946), 4 },
                    { 3L, 6, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3564), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3564), 4 },
                    { 4L, 4, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3594), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3595), 2 },
                    { 5L, 4, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3620), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3621), 2 },
                    { 2L, 6, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3508), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3509), 5 },
                    { 7L, 4, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3997), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3997), 4 },
                    { 8L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4033), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4034), 3 },
                    { 9L, 2, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4059), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4060), 2 },
                    { 10L, 5, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4088), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(4089), 3 },
                    { 6L, 6, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3651), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(3652), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7590), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7591) },
                    { 11L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6935), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6936) },
                    { 17L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7498), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7499) },
                    { 16L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7403), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7404) },
                    { 15L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7312), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7313) },
                    { 14L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7212), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7213) },
                    { 13L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7120), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7122) },
                    { 12L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7030), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7031) },
                    { 10L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6838), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6839) },
                    { 4L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6232), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6233) },
                    { 8L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6632), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6634) },
                    { 7L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6541), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6542) },
                    { 6L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6447), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6448) },
                    { 5L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6327), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6328) },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6129), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6131) },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(5722), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(5724) },
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 122, DateTimeKind.Local).AddTicks(1094), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 27, 0, 0, 19, 122, DateTimeKind.Local).AddTicks(1119) },
                    { 19L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7753), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7754) },
                    { 9L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6728), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(6729) },
                    { 20L, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7846), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 4, 27, 0, 0, 19, 124, DateTimeKind.Local).AddTicks(7847) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(9732), "BM310", 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(9734) },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6), "BM311", 1L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(8) },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(38), "BM312", 1L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(39) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7306), 3, 17L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7307) },
                    { 36L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7283), 2, 17L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7284) },
                    { 35L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7259), 1, 17L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7260) },
                    { 34L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7236), 3, 16L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7237) },
                    { 33L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7202), 2, 16L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7202) },
                    { 32L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7176), 1, 16L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7177) },
                    { 31L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7153), 3, 15L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7154) },
                    { 29L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7106), 1, 15L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7107) },
                    { 38L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7330), 1, 18L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7331) },
                    { 28L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7082), 3, 14L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7083) },
                    { 27L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7059), 2, 14L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7060) },
                    { 26L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7035), 1, 14L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7036) },
                    { 25L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7012), 3, 13L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7012) },
                    { 24L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6987), 2, 13L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6988) },
                    { 23L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6963), 1, 13L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6964) },
                    { 30L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7129), 2, 15L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7130) },
                    { 39L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7353), 2, 18L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7354) },
                    { 41L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7398), 1, 19L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7399) },
                    { 22L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6940), 2, 12L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6941) },
                    { 58L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7846), 3, 24L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7847) },
                    { 57L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7824), 2, 24L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7824) },
                    { 56L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7798), 1, 24L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7799) },
                    { 55L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7773), 3, 23L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7774) },
                    { 54L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7749), 2, 23L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7750) },
                    { 53L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7726), 1, 23L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7727) },
                    { 52L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7701), 3, 22L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7702) },
                    { 40L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7376), 3, 18L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7377) },
                    { 51L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7676), 2, 22L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7677) },
                    { 49L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7630), 3, 21L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7631) },
                    { 48L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7606), 2, 21L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7607) },
                    { 47L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7581), 1, 21L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7582) },
                    { 46L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7555), 3, 20L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7559) },
                    { 45L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7531), 2, 20L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7532) },
                    { 44L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7507), 1, 20L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7508) },
                    { 43L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7483), 3, 19L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7484) },
                    { 50L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7653), 1, 22L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7654) },
                    { 21L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6916), 1, 12L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6917) },
                    { 42L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7423), 2, 19L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(7424) },
                    { 19L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6867), 1, 11L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6868) },
                    { 20L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6890), 2, 11L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6891) },
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6109), 1, 1L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6111) },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6420), 2, 1L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6421) },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6450), 1, 2L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6451) },
                    { 4L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6474), 2, 2L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6475) },
                    { 6L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6541), 2, 3L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6542) },
                    { 7L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6566), 1, 4L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6567) },
                    { 8L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6592), 1, 5L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6592) },
                    { 9L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6615), 1, 6L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6616) },
                    { 5L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6498), 1, 3L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6499) },
                    { 11L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6667), 1, 7L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6668) },
                    { 10L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6640), 2, 6L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6641) },
                    { 17L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6818), 1, 10L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6819) },
                    { 16L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6793), 2, 9L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6793) },
                    { 15L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6765), 1, 9L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6766) },
                    { 18L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6843), 2, 10L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6844) },
                    { 13L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6715), 1, 8L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6716) },
                    { 12L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6691), 2, 7L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6692) },
                    { 14L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6739), 2, 8L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(6740) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5916), 1L, "1007", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5917) },
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(4851), 1L, "1000", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(4861) },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5755), 1L, "1001", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5756) },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5793), 1L, "1002", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5794) },
                    { 4L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5818), 1L, "1003", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5819) },
                    { 5L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5842), 1L, "1004", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5843) },
                    { 6L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5869), 1L, "1005", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5870) },
                    { 7L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5893), 1L, "1006", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5894) },
                    { 9L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5940), 1L, "1008", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5941) },
                    { 14L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6074), 1L, "10013", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6075) },
                    { 11L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6002), 1L, "10010", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6002) },
                    { 12L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6026), 1L, "10011", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6027) },
                    { 13L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6050), 1L, "10012", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6051) },
                    { 15L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6098), 1L, "10014", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6099) },
                    { 16L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6122), 1L, "10015", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6123) },
                    { 17L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6146), 1L, "10016", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6147) },
                    { 10L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5965), 1L, "1009", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(5966) },
                    { 18L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6172), 1L, "10017", new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(6173) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3577), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3578), 7L, 14 },
                    { 16L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3984), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3985), 17L, 16 },
                    { 7L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3602), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3603), 8L, 8 },
                    { 15L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3959), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3960), 16L, 12 },
                    { 8L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3626), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3627), 9L, 10 },
                    { 10L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3676), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3677), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3651), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3652), 10L, 12 },
                    { 13L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3808), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3809), 14L, 16 },
                    { 11L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3727), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3728), 12L, 12 },
                    { 5L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3548), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3549), 6L, 12 },
                    { 14L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3931), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3932), 15L, 16 },
                    { 17L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(4009), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(4010), 18L, 9 },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3434), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3435), 3L, 6 },
                    { 4L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3522), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3523), 5L, 10 },
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(2615), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(2623), 2L, 4 },
                    { 19L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(4078), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(4079), 20L, 16 },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3495), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3496), 4L, 8 },
                    { 18L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(4036), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(4037), 19L, 16 },
                    { 12L, new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3761), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 4, 27, 0, 0, 19, 125, DateTimeKind.Local).AddTicks(3762), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(394), 17L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(395), 17L },
                    { 18L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9878), 8L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9879), 13L },
                    { 28L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(108), 13L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(109), 13L },
                    { 29L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(131), 13L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(132), 13L },
                    { 9L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9660), 3L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9661), 13L },
                    { 30L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(153), 13L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(154), 13L },
                    { 42L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(441), 17L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(442), 17L },
                    { 10L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9686), 4L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9687), 14L },
                    { 49L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(602), 20L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(603), 20L },
                    { 21L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9947), 9L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9948), 14L },
                    { 31L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(176), 14L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(177), 14L },
                    { 32L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(199), 14L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(200), 14L },
                    { 45L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(509), 18L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(510), 18L },
                    { 33L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(222), 14L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(222), 14L },
                    { 48L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(579), 19L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(580), 19L },
                    { 43L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(464), 18L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(465), 18L },
                    { 35L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(279), 15L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(280), 15L },
                    { 36L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(302), 15L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(303), 15L },
                    { 47L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(556), 19L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(556), 19L },
                    { 61L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(887), 24L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(888), 15L },
                    { 46L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(532), 19L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(533), 19L },
                    { 37L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(324), 16L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(325), 16L },
                    { 44L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(486), 18L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(487), 18L },
                    { 38L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(347), 16L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(348), 16L },
                    { 39L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(371), 16L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(372), 16L },
                    { 41L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(418), 17L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(419), 17L },
                    { 34L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(256), 15L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(257), 15L },
                    { 4L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9531), 2L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9532), 2L },
                    { 27L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(85), 12L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(86), 12L },
                    { 11L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9711), 5L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9712), 7L },
                    { 24L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(15), 11L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(16), 6L },
                    { 57L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(787), 22L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(788), 5L },
                    { 17L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9852), 8L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9853), 5L },
                    { 8L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9637), 3L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9638), 5L },
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(8979), 1L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(8982), 5L },
                    { 25L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(39), 11L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(40), 7L },
                    { 56L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(764), 22L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(765), 4L },
                    { 12L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9735), 6L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9735), 4L },
                    { 55L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(739), 22L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(740), 3L },
                    { 23L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9993), 10L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9994), 3L },
                    { 7L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9615), 3L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9616), 3L },
                    { 22L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9970), 10L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9971), 2L },
                    { 50L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(625), 20L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(626), 20L },
                    { 26L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(62), 12L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(63), 4L },
                    { 60L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(855), 23L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(856), 12L },
                    { 63L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(945), 24L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(946), 7L },
                    { 19L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9901), 9L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9902), 8L },
                    { 15L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9806), 7L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9807), 12L },
                    { 6L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9593), 2L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9593), 12L },
                    { 59L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(833), 23L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(834), 11L },
                    { 14L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9784), 7L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9785), 11L },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9505), 1L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9507), 11L },
                    { 58L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(811), 23L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(812), 10L },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9471), 1L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9473), 8L },
                    { 54L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(717), 21L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(718), 10L },
                    { 13L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9760), 6L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9761), 10L },
                    { 62L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(920), 24L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(921), 9L },
                    { 53L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(694), 21L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(695), 9L },
                    { 20L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9924), 9L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9925), 9L },
                    { 5L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9565), 2L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9566), 9L },
                    { 52L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(672), 21L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(673), 8L },
                    { 16L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9829), 7L, new DateTime(2019, 4, 27, 0, 0, 19, 126, DateTimeKind.Local).AddTicks(9830), 10L },
                    { 51L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(649), 20L, new DateTime(2019, 4, 27, 0, 0, 19, 127, DateTimeKind.Local).AddTicks(650), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1422), 1L, 1L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1425) },
                    { 22L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2427), 1L, 22L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2428) },
                    { 21L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2404), 1L, 21L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2405) },
                    { 20L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2381), 1L, 20L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2382) },
                    { 19L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2358), 1L, 19L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2359) },
                    { 18L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2335), 1L, 18L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2336) },
                    { 17L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2310), 1L, 17L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2311) },
                    { 16L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2286), 1L, 16L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2287) },
                    { 15L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2263), 1L, 15L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2264) },
                    { 14L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2240), 1L, 14L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2241) },
                    { 13L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2214), 1L, 13L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2215) },
                    { 12L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2180), 1L, 12L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2181) },
                    { 11L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2157), 1L, 11L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2158) },
                    { 10L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2134), 1L, 10L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2135) },
                    { 9L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2108), 1L, 9L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2109) },
                    { 8L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2083), 1L, 8L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2084) },
                    { 7L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2061), 1L, 7L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2062) },
                    { 6L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2038), 1L, 6L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2039) },
                    { 5L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2010), 1L, 5L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2011) },
                    { 4L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1985), 1L, 4L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1986) },
                    { 3L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1960), 1L, 3L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1961) },
                    { 2L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1924), 1L, 2L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(1925) },
                    { 23L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2452), 1L, 23L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2453) },
                    { 24L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2475), 1L, 24L, new DateTime(2019, 4, 27, 0, 0, 19, 128, DateTimeKind.Local).AddTicks(2476) }
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
