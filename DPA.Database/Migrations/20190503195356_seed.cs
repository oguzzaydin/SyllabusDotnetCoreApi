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
                    FacultyId = table.Column<long>(nullable: false),
                    SecondActiveSyylabusId = table.Column<long>(nullable: false),
                    FirstActiveSyllabusId = table.Column<long>(nullable: false)
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
                    SemesterType = table.Column<int>(nullable: false),
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
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6558), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6560) },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6771), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6771) },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6792), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6793) },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6809), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(6810) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5884), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5884), 3 },
                    { 23L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5860), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5861), 3 },
                    { 22L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5833), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5834), 3 },
                    { 21L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5817), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5818), 3 },
                    { 19L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5784), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5785), 3 },
                    { 18L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5767), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5768), 3 },
                    { 17L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5750), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5750), 3 },
                    { 16L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5733), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5734), 3 },
                    { 15L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5716), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5717), 3 },
                    { 14L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5699), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5699), 3 },
                    { 13L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5682), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5683), 3 },
                    { 20L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5801), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5801), 3 },
                    { 11L, 6, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5649), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5650), 4 },
                    { 12L, 6, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5666), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5666), 3 },
                    { 1L, 4, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(3652), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(3655), 4 },
                    { 3L, 6, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5496), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5497), 4 },
                    { 4L, 4, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5514), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5515), 2 },
                    { 5L, 4, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5533), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5533), 2 },
                    { 2L, 6, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5459), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5460), 5 },
                    { 7L, 4, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5570), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5571), 4 },
                    { 8L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5587), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5588), 3 },
                    { 9L, 2, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5614), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5615), 2 },
                    { 10L, 5, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5633), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5633), 3 },
                    { 6L, 6, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5553), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(5553), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5708), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5709) },
                    { 11L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5311), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5312) },
                    { 17L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5647), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5647) },
                    { 16L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5591), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5592) },
                    { 15L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5536), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5537) },
                    { 14L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5482), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5483) },
                    { 13L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5427), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5427) },
                    { 12L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5366), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5367) },
                    { 10L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5255), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5256) },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4902), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4903) },
                    { 8L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5131), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5132) },
                    { 7L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5075), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5076) },
                    { 6L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5019), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5020) },
                    { 5L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4957), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4958) },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4825), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4826) },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4657), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(4658) },
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 274, DateTimeKind.Local).AddTicks(4513), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 5, 3, 22, 53, 55, 274, DateTimeKind.Local).AddTicks(4537) },
                    { 19L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5789), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5789) },
                    { 9L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5195), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5196) },
                    { 20L, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5845), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 5, 3, 22, 53, 55, 276, DateTimeKind.Local).AddTicks(5846) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "FirstActiveSyllabusId", "SecondActiveSyylabusId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(1431), "BM310", 1L, 0L, 0L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(1434) },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(1692), "BM311", 1L, 0L, 0L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(1693) },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(1716), "BM312", 1L, 0L, 0L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(1717) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8859), 3, 17L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8859) },
                    { 36L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8844), 2, 17L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8845) },
                    { 35L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8830), 1, 17L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8831) },
                    { 34L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8815), 3, 16L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8816) },
                    { 33L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8800), 2, 16L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8801) },
                    { 32L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8786), 1, 16L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8787) },
                    { 31L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8771), 3, 15L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8771) },
                    { 29L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8741), 1, 15L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8742) },
                    { 38L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8873), 1, 18L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8874) },
                    { 28L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8727), 3, 14L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8728) },
                    { 27L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8713), 2, 14L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8714) },
                    { 26L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8698), 1, 14L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8699) },
                    { 25L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8674), 3, 13L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8675) },
                    { 24L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8660), 2, 13L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8660) },
                    { 23L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8646), 1, 13L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8646) },
                    { 30L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8755), 2, 15L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8756) },
                    { 39L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8888), 2, 18L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8889) },
                    { 41L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8918), 1, 19L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8919) },
                    { 22L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8632), 2, 12L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8632) },
                    { 58L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9187), 3, 24L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9188) },
                    { 57L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9173), 2, 24L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9173) },
                    { 56L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9159), 1, 24L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9159) },
                    { 55L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9144), 3, 23L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9144) },
                    { 54L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9122), 2, 23L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9123) },
                    { 53L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9108), 1, 23L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9109) },
                    { 52L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9094), 3, 22L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9095) },
                    { 40L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8903), 3, 18L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8904) },
                    { 51L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9080), 2, 22L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9080) },
                    { 49L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9050), 3, 21L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9050) },
                    { 48L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9035), 2, 21L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9036) },
                    { 47L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9021), 1, 21L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9022) },
                    { 46L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9007), 3, 20L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9008) },
                    { 45L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8993), 2, 20L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8994) },
                    { 44L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8979), 1, 20L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8979) },
                    { 43L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8964), 3, 19L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8965) },
                    { 50L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9065), 1, 22L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(9066) },
                    { 21L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8618), 1, 12L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8618) },
                    { 42L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8932), 2, 19L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8933) },
                    { 19L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8589), 1, 11L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8590) },
                    { 20L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8604), 2, 11L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8604) },
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8136), 1, 1L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8138) },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8332), 2, 1L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8332) },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8351), 1, 2L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8352) },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8367), 2, 2L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8367) },
                    { 6L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8398), 2, 3L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8399) },
                    { 7L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8413), 1, 4L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8413) },
                    { 8L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8427), 1, 5L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8428) },
                    { 9L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8441), 1, 6L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8442) },
                    { 5L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8381), 1, 3L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8382) },
                    { 11L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8472), 1, 7L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8473) },
                    { 10L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8457), 2, 6L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8458) },
                    { 17L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8560), 1, 10L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8560) },
                    { 16L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8546), 2, 9L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8546) },
                    { 15L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8531), 1, 9L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8532) },
                    { 18L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8575), 2, 10L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8576) },
                    { 13L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8503), 1, 8L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8503) },
                    { 12L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8488), 2, 7L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8489) },
                    { 14L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8517), 2, 8L, new DateTime(2019, 5, 3, 22, 53, 55, 278, DateTimeKind.Local).AddTicks(8518) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9676), 1L, "1007", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9677) },
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(8919), 1L, "1000", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(8921) },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9582), 1L, "1001", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9582) },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9605), 1L, "1002", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9605) },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9619), 1L, "1003", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9619) },
                    { 5L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9632), 1L, "1004", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9633) },
                    { 6L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9649), 1L, "1005", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9649) },
                    { 7L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9663), 1L, "1006", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9663) },
                    { 9L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9690), 1L, "1008", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9690) },
                    { 14L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9769), 1L, "10013", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9769) },
                    { 11L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9727), 1L, "10010", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9728) },
                    { 12L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9742), 1L, "10011", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9743) },
                    { 13L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9755), 1L, "10012", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9756) },
                    { 15L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9782), 1L, "10014", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9783) },
                    { 16L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9795), 1L, "10015", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9796) },
                    { 17L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9809), 1L, "10016", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9809) },
                    { 10L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9704), 1L, "1009", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9705) },
                    { 18L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9823), 1L, "10017", new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(9824) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5537), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5538), 7L, 14 },
                    { 16L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5955), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5956), 17L, 16 },
                    { 7L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5561), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5561), 8L, 8 },
                    { 15L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5935), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5935), 16L, 12 },
                    { 8L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5583), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5584), 9L, 10 },
                    { 10L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5629), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5630), 11L, 12 },
                    { 9L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5604), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5605), 10L, 12 },
                    { 13L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5863), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5864), 14L, 16 },
                    { 11L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5650), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5651), 12L, 12 },
                    { 5L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5505), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5506), 6L, 12 },
                    { 14L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5896), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5898), 15L, 16 },
                    { 17L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5976), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5977), 18L, 9 },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5380), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5381), 3L, 6 },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5480), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5481), 5L, 10 },
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(4010), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(4024), 2L, 4 },
                    { 19L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(6022), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(6023), 20L, 16 },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5451), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5452), 4L, 8 },
                    { 18L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(6000), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(6001), 19L, 16 },
                    { 12L, new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5837), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 5, 3, 22, 53, 55, 277, DateTimeKind.Local).AddTicks(5838), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2006), 17L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2007), 17L },
                    { 18L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1691), 8L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1692), 13L },
                    { 28L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1836), 13L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1837), 13L },
                    { 29L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1850), 13L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1851), 13L },
                    { 9L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1562), 3L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1563), 13L },
                    { 30L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1865), 13L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1865), 13L },
                    { 42L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2033), 17L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2034), 17L },
                    { 10L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1577), 4L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1578), 14L },
                    { 49L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2130), 20L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2131), 20L },
                    { 21L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1733), 9L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1733), 14L },
                    { 31L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1879), 14L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1879), 14L },
                    { 32L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1893), 14L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1893), 14L },
                    { 45L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2075), 18L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2076), 18L },
                    { 33L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1907), 14L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1908), 14L },
                    { 48L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2117), 19L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2117), 19L },
                    { 43L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2048), 18L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2048), 18L },
                    { 35L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1937), 15L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1937), 15L },
                    { 36L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1951), 15L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1951), 15L },
                    { 47L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2103), 19L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2103), 19L },
                    { 61L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2308), 24L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2308), 15L },
                    { 46L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2089), 19L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2090), 19L },
                    { 37L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1965), 16L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1966), 16L },
                    { 44L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2061), 18L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2062), 18L },
                    { 38L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1979), 16L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1979), 16L },
                    { 39L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1992), 16L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1993), 16L },
                    { 41L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2020), 17L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2020), 17L },
                    { 34L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1922), 15L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1923), 15L },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1489), 2L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1490), 2L },
                    { 27L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1823), 12L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1823), 12L },
                    { 11L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1591), 5L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1592), 7L },
                    { 24L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1774), 11L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1775), 6L },
                    { 57L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2253), 22L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2254), 5L },
                    { 17L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1676), 8L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1677), 5L },
                    { 8L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1548), 3L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1549), 5L },
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(816), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(818), 5L },
                    { 25L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1794), 11L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1795), 7L },
                    { 56L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2240), 22L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2240), 4L },
                    { 12L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1606), 6L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1606), 4L },
                    { 55L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2226), 22L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2227), 3L },
                    { 23L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1760), 10L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1761), 3L },
                    { 7L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1534), 3L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1535), 3L },
                    { 22L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1746), 10L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1747), 2L },
                    { 50L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2144), 20L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2145), 20L },
                    { 26L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1809), 12L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1810), 4L },
                    { 60L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2294), 23L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2295), 12L },
                    { 63L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2335), 24L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2335), 7L },
                    { 19L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1705), 9L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1706), 8L },
                    { 15L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1648), 7L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1649), 12L },
                    { 6L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1520), 2L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1521), 12L },
                    { 59L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2280), 23L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2281), 11L },
                    { 14L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1634), 7L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1635), 11L },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1475), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1476), 11L },
                    { 58L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2267), 23L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2268), 10L },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1453), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1454), 8L },
                    { 54L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2211), 21L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2212), 10L },
                    { 13L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1620), 6L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1621), 10L },
                    { 62L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2321), 24L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2322), 9L },
                    { 53L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2196), 21L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2197), 9L },
                    { 20L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1719), 9L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1720), 9L },
                    { 5L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1504), 2L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1505), 9L },
                    { 52L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2172), 21L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2172), 8L },
                    { 16L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1662), 7L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(1662), 10L },
                    { 51L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2158), 20L, new DateTime(2019, 5, 3, 22, 53, 55, 279, DateTimeKind.Local).AddTicks(2158), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Department",
                table: "DepartmentInstructor",
                columns: new[] { "DepartmentInstructorId", "CreatedDate", "DepartmentId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(3332), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(3334), 2L },
                    { 19L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4227), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4228), 20L },
                    { 18L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4212), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4213), 19L },
                    { 17L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4197), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4198), 18L },
                    { 16L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4182), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4183), 17L },
                    { 14L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4154), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4154), 15L },
                    { 13L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4140), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4141), 14L },
                    { 12L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4126), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4126), 13L },
                    { 11L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4111), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4112), 12L },
                    { 15L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4167), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4168), 16L },
                    { 9L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4081), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4082), 10L },
                    { 8L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4067), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4068), 9L },
                    { 7L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4054), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4055), 8L },
                    { 6L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4040), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4041), 7L },
                    { 5L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4022), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4023), 6L },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4000), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4001), 5L },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(3986), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(3986), 4L },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(3965), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(3966), 3L },
                    { 10L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4097), 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(4098), 11L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 14L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6680), 1L, 14L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6681) },
                    { 15L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6694), 1L, 15L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6694) },
                    { 16L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6707), 1L, 16L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6708) },
                    { 17L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6721), 1L, 17L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6722) },
                    { 22L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6791), 1L, 22L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6792) },
                    { 19L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6750), 1L, 19L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6751) },
                    { 20L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6764), 1L, 20L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6765) },
                    { 21L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6778), 1L, 21L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6778) },
                    { 13L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6664), 1L, 13L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6665) },
                    { 18L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6736), 1L, 18L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6737) },
                    { 12L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6643), 1L, 12L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6643) },
                    { 3L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6513), 1L, 3L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6514) },
                    { 10L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6615), 1L, 10L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6616) },
                    { 9L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6600), 1L, 9L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6600) },
                    { 8L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6586), 1L, 8L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6587) },
                    { 7L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6572), 1L, 7L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6572) },
                    { 6L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6558), 1L, 6L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6558) },
                    { 5L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6542), 1L, 5L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6543) },
                    { 4L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6527), 1L, 4L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6528) },
                    { 23L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6805), 1L, 23L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6805) },
                    { 2L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6492), 1L, 2L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6493) },
                    { 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(5777), 1L, 1L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(5778) },
                    { 11L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6629), 1L, 11L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6630) },
                    { 24L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6818), 1L, 24L, new DateTime(2019, 5, 3, 22, 53, 55, 280, DateTimeKind.Local).AddTicks(6819) }
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
