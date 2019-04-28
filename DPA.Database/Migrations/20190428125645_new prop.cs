using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DPA.Database.Migrations
{
    public partial class newprop : Migration
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
                    IsActive = table.Column<bool>(nullable: false),
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
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(6839), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(6840) },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(7108), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(7108) },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(7128), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(7129) },
                    { 4L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(7224), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(7225) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(3158), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(3160), 3 },
                    { 23L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(3051), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(3053), 3 },
                    { 22L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2782), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2783), 3 },
                    { 21L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2754), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2754), 3 },
                    { 19L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2722), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2722), 3 },
                    { 18L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2700), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2700), 3 },
                    { 17L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2613), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2614), 3 },
                    { 16L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2542), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2543), 3 },
                    { 15L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2520), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2521), 3 },
                    { 14L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2499), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2499), 3 },
                    { 13L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2476), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2477), 3 },
                    { 20L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2738), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2738), 3 },
                    { 11L, 6, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2426), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2427), 4 },
                    { 12L, 6, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2452), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2453), 3 },
                    { 1L, 4, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(123), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(127), 4 },
                    { 3L, 6, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(1999), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(1999), 4 },
                    { 4L, 4, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2024), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2025), 2 },
                    { 5L, 4, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2042), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2043), 2 },
                    { 2L, 6, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(1965), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(1965), 5 },
                    { 7L, 4, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2140), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2140), 4 },
                    { 8L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2159), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2160), 3 },
                    { 9L, 2, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2191), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2192), 2 },
                    { 10L, 5, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2390), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2391), 3 },
                    { 6L, 6, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2062), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(2063), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7228), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7229) },
                    { 11L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6834), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6835) },
                    { 17L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7172), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7172) },
                    { 16L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7115), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7116) },
                    { 15L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7056), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7056) },
                    { 14L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7002), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7002) },
                    { 13L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6946), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6947) },
                    { 12L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6892), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6893) },
                    { 10L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6773), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6773) },
                    { 4L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6416), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6416) },
                    { 8L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6660), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6661) },
                    { 7L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6603), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6604) },
                    { 6L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6536), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6537) },
                    { 5L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6472), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6473) },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6354), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6355) },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6189), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6190) },
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 138, DateTimeKind.Local).AddTicks(5581), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 28, 15, 56, 44, 138, DateTimeKind.Local).AddTicks(5603) },
                    { 19L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7299), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7300) },
                    { 9L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6716), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(6717) },
                    { 20L, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7354), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 4, 28, 15, 56, 44, 140, DateTimeKind.Local).AddTicks(7355) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(1350), "BM310", 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(1352) },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(1573), "BM311", 1L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(1573) },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(1594), "BM312", 1L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(1594) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7796), 3, 17L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7797) },
                    { 36L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7782), 2, 17L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7782) },
                    { 35L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7768), 1, 17L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7769) },
                    { 34L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7754), 3, 16L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7755) },
                    { 33L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7739), 2, 16L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7739) },
                    { 32L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7725), 1, 16L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7726) },
                    { 31L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7711), 3, 15L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7711) },
                    { 29L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7683), 1, 15L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7684) },
                    { 38L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7810), 1, 18L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7811) },
                    { 28L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7665), 3, 14L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7666) },
                    { 27L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7651), 2, 14L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7652) },
                    { 26L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7637), 1, 14L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7638) },
                    { 25L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7624), 3, 13L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7624) },
                    { 24L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7609), 2, 13L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7610) },
                    { 23L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7595), 1, 13L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7596) },
                    { 30L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7697), 2, 15L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7698) },
                    { 39L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7824), 2, 18L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7825) },
                    { 41L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7854), 1, 19L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7855) },
                    { 22L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7580), 2, 12L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7580) },
                    { 58L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8122), 3, 24L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8122) },
                    { 57L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8108), 2, 24L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8108) },
                    { 56L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8093), 1, 24L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8094) },
                    { 55L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8078), 3, 23L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8079) },
                    { 54L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8064), 2, 23L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8065) },
                    { 53L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8050), 1, 23L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8051) },
                    { 52L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8036), 3, 22L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8037) },
                    { 40L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7838), 3, 18L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7839) },
                    { 51L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8022), 2, 22L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8023) },
                    { 49L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7994), 3, 21L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7995) },
                    { 48L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7980), 2, 21L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7981) },
                    { 47L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7966), 1, 21L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7967) },
                    { 46L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7952), 3, 20L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7953) },
                    { 45L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7938), 2, 20L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7939) },
                    { 44L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7924), 1, 20L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7925) },
                    { 43L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7910), 3, 19L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7911) },
                    { 50L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8008), 1, 22L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(8009) },
                    { 21L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7566), 1, 12L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7566) },
                    { 42L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7877), 2, 19L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7878) },
                    { 19L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7537), 1, 11L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7538) },
                    { 20L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7552), 2, 11L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7552) },
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(6964), 1, 1L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(6966) },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7262), 2, 1L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7262) },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7282), 1, 2L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7283) },
                    { 4L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7297), 2, 2L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7298) },
                    { 6L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7332), 2, 3L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7333) },
                    { 7L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7346), 1, 4L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7347) },
                    { 8L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7361), 1, 5L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7361) },
                    { 9L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7375), 1, 6L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7376) },
                    { 5L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7312), 1, 3L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7313) },
                    { 11L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7404), 1, 7L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7405) },
                    { 10L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7390), 2, 6L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7391) },
                    { 17L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7507), 1, 10L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7508) },
                    { 16L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7492), 2, 9L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7492) },
                    { 15L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7478), 1, 9L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7478) },
                    { 18L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7523), 2, 10L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7524) },
                    { 13L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7434), 1, 8L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7435) },
                    { 12L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7420), 2, 7L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7421) },
                    { 14L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7463), 2, 8L, new DateTime(2019, 4, 28, 15, 56, 44, 142, DateTimeKind.Local).AddTicks(7463) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7830), 1L, "1007", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7831) },
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7065), 1L, "1000", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7066) },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7736), 1L, "1001", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7737) },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7761), 1L, "1002", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7762) },
                    { 4L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7775), 1L, "1003", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7775) },
                    { 5L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7788), 1L, "1004", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7789) },
                    { 6L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7804), 1L, "1005", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7804) },
                    { 7L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7817), 1L, "1006", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7818) },
                    { 9L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7843), 1L, "1008", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7844) },
                    { 14L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7910), 1L, "10013", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7911) },
                    { 11L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7870), 1L, "10010", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7871) },
                    { 12L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7884), 1L, "10011", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7884) },
                    { 13L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7897), 1L, "10012", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7898) },
                    { 15L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7923), 1L, "10014", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7924) },
                    { 16L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7937), 1L, "10015", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7937) },
                    { 17L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7960), 1L, "10016", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7961) },
                    { 10L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7857), 1L, "1009", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7857) },
                    { 18L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7974), 1L, "10017", new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(7975) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4453), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4454), 7L, 14 },
                    { 16L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4596), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4597), 17L, 16 },
                    { 7L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4467), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4468), 8L, 8 },
                    { 15L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4583), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4583), 16L, 12 },
                    { 8L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4481), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4482), 9L, 10 },
                    { 10L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4511), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4512), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4495), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4495), 10L, 12 },
                    { 13L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4555), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4555), 14L, 16 },
                    { 11L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4526), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4526), 12L, 12 },
                    { 5L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4436), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4437), 6L, 12 },
                    { 14L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4569), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4570), 15L, 16 },
                    { 17L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4610), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4610), 18L, 9 },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4371), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4372), 3L, 6 },
                    { 4L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4422), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4422), 5L, 10 },
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(3638), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(3642), 2L, 4 },
                    { 19L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4639), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4640), 20L, 16 },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4407), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4407), 4L, 8 },
                    { 18L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4625), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4626), 19L, 16 },
                    { 12L, new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4539), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 4, 28, 15, 56, 44, 141, DateTimeKind.Local).AddTicks(4540), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1185), 17L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1185), 17L },
                    { 18L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(894), 8L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(895), 13L },
                    { 28L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1025), 13L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1026), 13L },
                    { 29L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1039), 13L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1039), 13L },
                    { 9L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(764), 3L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(765), 13L },
                    { 30L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1052), 13L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1053), 13L },
                    { 42L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1216), 17L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1217), 17L },
                    { 10L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(778), 4L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(779), 14L },
                    { 49L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1310), 20L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1310), 20L },
                    { 21L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(934), 9L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(934), 14L },
                    { 31L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1065), 14L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1065), 14L },
                    { 32L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1078), 14L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1079), 14L },
                    { 45L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1256), 18L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1256), 18L },
                    { 33L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1091), 14L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1092), 14L },
                    { 48L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1296), 19L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1297), 19L },
                    { 43L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1229), 18L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1230), 18L },
                    { 35L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1119), 15L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1120), 15L },
                    { 36L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1132), 15L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1133), 15L },
                    { 47L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1283), 19L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1284), 19L },
                    { 61L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1467), 24L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1468), 15L },
                    { 46L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1269), 19L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1270), 19L },
                    { 37L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1145), 16L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1146), 16L },
                    { 44L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1242), 18L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1243), 18L },
                    { 38L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1159), 16L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1160), 16L },
                    { 39L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1172), 16L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1173), 16L },
                    { 41L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1203), 17L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1204), 17L },
                    { 34L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1105), 15L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1106), 15L },
                    { 4L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(694), 2L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(695), 2L },
                    { 27L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1012), 12L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1013), 12L },
                    { 11L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(792), 5L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(792), 7L },
                    { 24L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(973), 11L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(974), 6L },
                    { 57L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1414), 22L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1415), 5L },
                    { 17L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(880), 8L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(881), 5L },
                    { 8L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(750), 3L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(751), 5L },
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(11), 1L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(13), 5L },
                    { 25L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(986), 11L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(987), 7L },
                    { 56L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1401), 22L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1402), 4L },
                    { 12L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(805), 6L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(806), 4L },
                    { 55L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1388), 22L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1389), 3L },
                    { 23L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(960), 10L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(961), 3L },
                    { 7L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(737), 3L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(738), 3L },
                    { 22L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(947), 10L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(947), 2L },
                    { 50L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1323), 20L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1324), 20L },
                    { 26L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(999), 12L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1000), 4L },
                    { 60L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1454), 23L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1455), 12L },
                    { 63L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1493), 24L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1494), 7L },
                    { 19L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(908), 9L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(908), 8L },
                    { 15L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(854), 7L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(854), 12L },
                    { 6L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(723), 2L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(724), 12L },
                    { 59L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1440), 23L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1441), 11L },
                    { 14L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(841), 7L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(841), 11L },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(681), 1L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(682), 11L },
                    { 58L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1427), 23L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1428), 10L },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(660), 1L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(660), 8L },
                    { 54L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1375), 21L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1376), 10L },
                    { 13L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(827), 6L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(828), 10L },
                    { 62L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1480), 24L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1481), 9L },
                    { 53L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1362), 21L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1363), 9L },
                    { 20L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(921), 9L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(921), 9L },
                    { 5L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(708), 2L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(708), 9L },
                    { 52L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1349), 21L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1350), 8L },
                    { 16L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(867), 7L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(868), 10L },
                    { 51L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1336), 20L, new DateTime(2019, 4, 28, 15, 56, 44, 143, DateTimeKind.Local).AddTicks(1337), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4145), 1L, 1L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4148) },
                    { 22L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5131), 1L, 22L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5132) },
                    { 21L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5117), 1L, 21L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5117) },
                    { 20L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5094), 1L, 20L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5094) },
                    { 19L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5080), 1L, 19L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5081) },
                    { 18L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5066), 1L, 18L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5067) },
                    { 17L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5051), 1L, 17L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5052) },
                    { 16L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5038), 1L, 16L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5039) },
                    { 15L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5024), 1L, 15L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5025) },
                    { 14L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5011), 1L, 14L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5012) },
                    { 13L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4997), 1L, 13L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4998) },
                    { 12L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4984), 1L, 12L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4984) },
                    { 11L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4970), 1L, 11L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4971) },
                    { 10L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4957), 1L, 10L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4958) },
                    { 9L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4942), 1L, 9L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4943) },
                    { 8L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4929), 1L, 8L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4929) },
                    { 7L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4915), 1L, 7L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4916) },
                    { 6L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4901), 1L, 6L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4902) },
                    { 5L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4884), 1L, 5L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4884) },
                    { 4L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4870), 1L, 4L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4871) },
                    { 3L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4856), 1L, 3L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4856) },
                    { 2L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4832), 1L, 2L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(4833) },
                    { 23L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5145), 1L, 23L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5145) },
                    { 24L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5158), 1L, 24L, new DateTime(2019, 4, 28, 15, 56, 44, 144, DateTimeKind.Local).AddTicks(5159) }
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
