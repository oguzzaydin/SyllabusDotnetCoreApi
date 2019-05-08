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
                    DayOfTheWeekType = table.Column<int>(nullable: false),
                    EducationType = table.Column<int>(nullable: false)
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
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9011), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9013) },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9260), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9260) },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9281), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9282) },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9298), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(9299) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4154), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4155), 3 },
                    { 23L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4131), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4131), 3 },
                    { 22L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4105), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4106), 3 },
                    { 21L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4079), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4080), 3 },
                    { 19L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4026), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4027), 3 },
                    { 18L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3993), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3994), 3 },
                    { 17L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3957), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3958), 3 },
                    { 16L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3925), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3926), 3 },
                    { 15L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3883), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3884), 3 },
                    { 14L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3859), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3860), 3 },
                    { 13L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3830), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3831), 3 },
                    { 20L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4056), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(4057), 3 },
                    { 11L, 6, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3750), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3753), 4 },
                    { 12L, 6, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3798), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3799), 3 },
                    { 1L, 4, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(115), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(133), 4 },
                    { 3L, 6, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3509), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3510), 4 },
                    { 4L, 4, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3542), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3543), 2 },
                    { 5L, 4, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3571), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3572), 2 },
                    { 2L, 6, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3415), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3416), 5 },
                    { 7L, 4, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3638), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3639), 4 },
                    { 8L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3662), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3662), 3 },
                    { 9L, 2, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3687), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3688), 2 },
                    { 10L, 5, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3719), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3720), 3 },
                    { 6L, 6, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3611), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(3614), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1235), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1236) },
                    { 11L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(842), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(843) },
                    { 17L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1179), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1180) },
                    { 16L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1125), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1126) },
                    { 15L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1070), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1071) },
                    { 14L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1015), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1016) },
                    { 13L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(953), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(953) },
                    { 12L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(898), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(899) },
                    { 10L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(787), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(788) },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(413), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(414) },
                    { 8L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(663), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(664) },
                    { 7L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(607), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(608) },
                    { 6L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(551), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(552) },
                    { 5L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(486), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(487) },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(352), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(353) },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(177), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(178) },
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 124, DateTimeKind.Local).AddTicks(8727), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 5, 8, 23, 37, 20, 124, DateTimeKind.Local).AddTicks(8749) },
                    { 19L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1311), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1312) },
                    { 9L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(720), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(720) },
                    { 20L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1368), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(1368) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "FirstActiveSyllabusId", "SecondActiveSyylabusId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(3579), "BM310", 1L, 0L, 0L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(3582) },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(3809), "BM311", 1L, 0L, 0L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(3809) },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(3832), "BM312", 1L, 0L, 0L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(3833) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9652), 3, 17L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9653) },
                    { 36L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9627), 2, 17L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9628) },
                    { 35L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9605), 1, 17L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9606) },
                    { 34L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9584), 3, 16L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9585) },
                    { 33L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9555), 2, 16L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9555) },
                    { 32L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9528), 1, 16L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9529) },
                    { 31L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9495), 3, 15L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9496) },
                    { 29L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9451), 1, 15L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9452) },
                    { 38L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9673), 1, 18L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9674) },
                    { 28L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9428), 3, 14L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9428) },
                    { 27L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9398), 2, 14L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9399) },
                    { 26L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9349), 1, 14L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9350) },
                    { 25L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9277), 3, 13L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9278) },
                    { 24L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9251), 2, 13L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9252) },
                    { 23L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9224), 1, 13L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9225) },
                    { 30L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9473), 2, 15L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9474) },
                    { 39L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9699), 2, 18L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9699) },
                    { 41L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9746), 1, 19L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9746) },
                    { 22L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9200), 2, 12L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9201) },
                    { 58L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(74), 3, 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(75) },
                    { 57L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(60), 2, 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(61) },
                    { 56L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(46), 1, 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(46) },
                    { 55L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(32), 3, 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(32) },
                    { 54L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(17), 2, 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(18) },
                    { 53L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3), 1, 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4) },
                    { 52L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9989), 3, 22L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9989) },
                    { 40L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9723), 3, 18L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9724) },
                    { 51L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9974), 2, 22L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9974) },
                    { 48L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9931), 2, 21L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9931) },
                    { 47L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9917), 1, 21L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9917) },
                    { 46L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9901), 3, 20L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9902) },
                    { 45L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9887), 2, 20L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9888) },
                    { 44L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9873), 1, 20L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9874) },
                    { 43L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9858), 3, 19L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9859) },
                    { 42L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9796), 2, 19L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9797) },
                    { 49L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9946), 3, 21L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9946) },
                    { 21L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9176), 1, 12L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9177) },
                    { 50L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9960), 1, 22L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9960) },
                    { 19L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9073), 1, 11L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9075) },
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(7983), 1, 1L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(7988) },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8494), 2, 1L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8495) },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8552), 1, 2L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8553) },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8581), 2, 2L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8582) },
                    { 5L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8606), 1, 3L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8607) },
                    { 6L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8635), 2, 3L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8636) },
                    { 7L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8657), 1, 4L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8658) },
                    { 8L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8684), 1, 5L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8685) },
                    { 9L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8719), 1, 6L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8720) },
                    { 20L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9126), 2, 11L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9128) },
                    { 11L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8777), 1, 7L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8778) },
                    { 12L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8800), 2, 7L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8801) },
                    { 13L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8825), 1, 8L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8826) },
                    { 14L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8851), 2, 8L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8852) },
                    { 15L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8876), 1, 9L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8877) },
                    { 16L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8914), 2, 9L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8916) },
                    { 17L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8965), 1, 10L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8967) },
                    { 18L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9020), 2, 10L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(9022) },
                    { 10L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8750), 2, 6L, new DateTime(2019, 5, 8, 23, 37, 20, 129, DateTimeKind.Local).AddTicks(8751) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 7L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1819), 1L, "1006", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1820) },
                    { 6L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1805), 1L, "1005", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1806) },
                    { 5L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1789), 1L, "1004", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1790) },
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1087), 1L, "1000", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1089) },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1761), 1L, "1002", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1762) },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1739), 1L, "1001", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1740) },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1775), 1L, "1003", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1776) },
                    { 9L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1859), 1L, "1008", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1859) },
                    { 8L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1844), 1L, "1007", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1845) },
                    { 12L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1901), 1L, "10011", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1902) },
                    { 11L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1888), 1L, "10010", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1888) },
                    { 13L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1915), 1L, "10012", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1916) },
                    { 14L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1928), 1L, "10013", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1929) },
                    { 15L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1942), 1L, "10014", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1942) },
                    { 16L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1955), 1L, "10015", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1956) },
                    { 17L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1969), 1L, "10016", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1970) },
                    { 18L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1984), 1L, "10017", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1985) },
                    { 10L, new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1874), 1L, "1009", new DateTime(2019, 5, 8, 23, 37, 20, 132, DateTimeKind.Local).AddTicks(1874) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(346), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(346), 18L, 9 },
                    { 16L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(322), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(324), 17L, 16 },
                    { 5L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(29), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(30), 6L, 12 },
                    { 15L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(300), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(301), 16L, 12 },
                    { 6L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(71), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(72), 7L, 14 },
                    { 9L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(143), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(144), 10L, 12 },
                    { 7L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(100), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(101), 8L, 8 },
                    { 13L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(249), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(250), 14L, 16 },
                    { 8L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(123), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(124), 9L, 10 },
                    { 12L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(222), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(224), 13L, 16 },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(9998), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(9999), 5L, 10 },
                    { 14L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(270), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(271), 15L, 16 },
                    { 10L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(179), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(180), 11L, 12 },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(9963), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(9964), 4L, 8 },
                    { 19L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(407), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(408), 20L, 16 },
                    { 11L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(200), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(201), 12L, 12 },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(9835), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(9837), 3L, 6 },
                    { 18L, new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(384), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 5, 8, 23, 37, 20, 128, DateTimeKind.Local).AddTicks(385), 19L, 16 },
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(8592), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 5, 8, 23, 37, 20, 127, DateTimeKind.Local).AddTicks(8601), 2L, 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 95L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4360), 19L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4361), 20L },
                    { 69L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3998), 17L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3999), 14L },
                    { 68L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3985), 16L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3986), 14L },
                    { 67L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3972), 15L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3972), 14L },
                    { 66L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3958), 14L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3959), 14L },
                    { 96L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4374), 20L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4375), 20L },
                    { 97L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4388), 21L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4389), 20L },
                    { 65L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3943), 13L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3944), 13L },
                    { 63L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3917), 11L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3918), 13L },
                    { 70L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4012), 18L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4012), 14L },
                    { 62L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3903), 10L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3904), 13L },
                    { 61L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3890), 9L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3891), 13L },
                    { 98L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4402), 22L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4402), 20L },
                    { 60L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3877), 8L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3877), 12L },
                    { 59L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3862), 7L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3863), 12L },
                    { 58L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3842), 6L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3843), 12L },
                    { 57L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3828), 5L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3829), 12L },
                    { 56L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3815), 4L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3816), 12L },
                    { 64L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3930), 12L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3931), 13L },
                    { 89L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4279), 13L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4280), 18L },
                    { 71L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4025), 19L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4026), 15L },
                    { 72L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4038), 20L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4039), 15L },
                    { 88L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4266), 12L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4266), 18L },
                    { 87L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4252), 11L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4253), 18L },
                    { 86L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4239), 10L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4240), 18L },
                    { 91L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4306), 15L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4307), 19L },
                    { 85L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4216), 9L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4217), 17L },
                    { 84L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4203), 8L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4204), 17L },
                    { 83L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4190), 7L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4190), 17L },
                    { 82L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4176), 6L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4177), 17L },
                    { 81L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4161), 5L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4162), 17L },
                    { 90L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4293), 14L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4293), 18L },
                    { 92L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4320), 16L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4320), 19L },
                    { 79L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4134), 3L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4135), 16L },
                    { 78L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4121), 2L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4121), 16L },
                    { 93L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4333), 17L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4334), 19L },
                    { 77L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4107), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4108), 16L },
                    { 76L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4094), 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4094), 16L },
                    { 94L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4346), 18L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4347), 19L },
                    { 75L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4080), 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4080), 15L },
                    { 74L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4066), 22L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4067), 15L },
                    { 73L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4053), 21L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4053), 15L },
                    { 80L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4148), 4L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4148), 16L },
                    { 55L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3801), 3L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3802), 11L },
                    { 16L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3259), 16L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3260), 5L },
                    { 53L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3775), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3775), 11L },
                    { 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3371), 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3372), 5L },
                    { 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3358), 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3358), 5L },
                    { 22L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3344), 22L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3345), 5L },
                    { 21L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3331), 21L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3331), 5L },
                    { 20L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3317), 20L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3318), 5L },
                    { 19L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3304), 19L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3304), 5L },
                    { 18L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3288), 18L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3288), 5L },
                    { 17L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3273), 17L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3274), 5L },
                    { 99L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4415), 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4416), 20L },
                    { 15L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3246), 15L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3247), 4L },
                    { 14L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3232), 14L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3233), 4L },
                    { 25L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3385), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3386), 5L },
                    { 13L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3219), 13L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3220), 4L },
                    { 11L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3192), 11L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3192), 4L },
                    { 10L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3178), 10L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3179), 3L },
                    { 9L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3164), 9L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3164), 3L },
                    { 8L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3149), 8L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3150), 3L },
                    { 7L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3135), 7L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3136), 3L },
                    { 6L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3120), 6L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3121), 3L },
                    { 5L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3103), 5L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3104), 2L },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3089), 4L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3090), 2L },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3075), 3L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3075), 2L },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3043), 2L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3043), 2L },
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(2139), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(2142), 2L },
                    { 12L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3205), 12L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3206), 4L },
                    { 54L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3788), 2L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3789), 11L },
                    { 26L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3398), 2L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3399), 6L },
                    { 28L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3426), 4L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3426), 6L },
                    { 52L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3761), 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3762), 11L },
                    { 51L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3748), 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3749), 11L },
                    { 50L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3735), 2L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3736), 10L },
                    { 49L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3722), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3722), 10L },
                    { 48L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3708), 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3709), 10L },
                    { 47L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3694), 23L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3695), 10L },
                    { 46L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3681), 22L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3681), 10L },
                    { 45L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3667), 21L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3668), 9L },
                    { 44L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3653), 20L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3654), 9L },
                    { 43L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3639), 19L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3640), 9L },
                    { 42L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3626), 18L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3627), 9L },
                    { 27L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3412), 3L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3413), 6L },
                    { 41L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3613), 17L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3613), 9L },
                    { 39L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3586), 15L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3586), 8L },
                    { 38L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3572), 14L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3573), 8L },
                    { 37L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3559), 13L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3560), 8L },
                    { 36L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3545), 12L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3546), 8L },
                    { 35L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3531), 11L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3532), 7L },
                    { 34L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3518), 10L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3518), 7L },
                    { 33L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3503), 9L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3504), 7L },
                    { 32L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3489), 8L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3490), 7L },
                    { 31L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3474), 7L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3474), 7L },
                    { 30L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3453), 6L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3453), 6L },
                    { 29L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3439), 5L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3440), 6L },
                    { 40L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3599), 16L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(3600), 8L },
                    { 100L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4428), 24L, new DateTime(2019, 5, 8, 23, 37, 20, 130, DateTimeKind.Local).AddTicks(4429), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Department",
                table: "DepartmentInstructor",
                columns: new[] { "DepartmentInstructorId", "CreatedDate", "DepartmentId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(5601), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(5603), 2L },
                    { 19L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6537), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6538), 20L },
                    { 18L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6523), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6524), 19L },
                    { 17L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6508), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6509), 18L },
                    { 16L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6494), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6495), 17L },
                    { 14L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6467), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6468), 15L },
                    { 13L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6453), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6454), 14L },
                    { 12L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6439), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6440), 13L },
                    { 11L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6425), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6426), 12L },
                    { 15L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6480), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6481), 16L },
                    { 9L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6397), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6397), 10L },
                    { 8L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6383), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6384), 9L },
                    { 7L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6370), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6370), 8L },
                    { 6L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6356), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6356), 7L },
                    { 5L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6339), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6340), 6L },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6325), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6326), 5L },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6311), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6312), 4L },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6290), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6290), 3L },
                    { 10L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6412), 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(6412), 11L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 14L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8951), 1L, 14L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8952) },
                    { 15L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8965), 1L, 15L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8966) },
                    { 16L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8979), 1L, 16L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8980) },
                    { 17L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8994), 1L, 17L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8995) },
                    { 22L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9065), 1L, 22L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9066) },
                    { 19L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9023), 1L, 19L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9024) },
                    { 20L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9037), 1L, 20L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9038) },
                    { 21L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9051), 1L, 21L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9052) },
                    { 13L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8937), 1L, 13L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8938) },
                    { 18L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9010), 1L, 18L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9010) },
                    { 12L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8923), 1L, 12L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8924) },
                    { 3L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8778), 1L, 3L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8779) },
                    { 10L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8895), 1L, 10L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8895) },
                    { 9L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8878), 1L, 9L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8879) },
                    { 8L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8856), 1L, 8L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8857) },
                    { 7L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8842), 1L, 7L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8843) },
                    { 6L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8827), 1L, 6L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8828) },
                    { 5L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8810), 1L, 5L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8810) },
                    { 4L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8793), 1L, 4L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8794) },
                    { 23L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9079), 1L, 23L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9080) },
                    { 2L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8758), 1L, 2L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8758) },
                    { 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8111), 1L, 1L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8113) },
                    { 11L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8909), 1L, 11L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(8910) },
                    { 24L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9093), 1L, 24L, new DateTime(2019, 5, 8, 23, 37, 20, 131, DateTimeKind.Local).AddTicks(9094) }
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
