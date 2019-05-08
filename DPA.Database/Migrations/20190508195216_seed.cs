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
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8241), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8243) },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8457), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8457) },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8479), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8480) },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8495), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(8496) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7720), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7721), 3 },
                    { 23L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7704), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7705), 3 },
                    { 22L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7688), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7689), 3 },
                    { 21L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7672), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7673), 3 },
                    { 19L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7640), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7641), 3 },
                    { 18L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7624), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7625), 3 },
                    { 17L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7606), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7607), 3 },
                    { 16L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7590), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7590), 3 },
                    { 15L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7573), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7574), 3 },
                    { 14L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7556), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7557), 3 },
                    { 13L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7539), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7540), 3 },
                    { 20L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7656), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7657), 3 },
                    { 11L, 6, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7495), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7495), 4 },
                    { 12L, 6, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7521), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7521), 3 },
                    { 1L, 4, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(5318), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(5321), 4 },
                    { 3L, 6, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7359), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7359), 4 },
                    { 4L, 4, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7377), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7378), 2 },
                    { 5L, 4, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7393), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7394), 2 },
                    { 2L, 6, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7321), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7322), 5 },
                    { 7L, 4, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7429), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7429), 4 },
                    { 8L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7445), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7446), 3 },
                    { 9L, 2, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7461), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7462), 2 },
                    { 10L, 5, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7479), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7479), 3 },
                    { 6L, 6, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7412), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(7413), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(2051), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(2051) },
                    { 11L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1633), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1634) },
                    { 17L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1979), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1980) },
                    { 16L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1924), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1925) },
                    { 15L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1867), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1868) },
                    { 14L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1811), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1811) },
                    { 13L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1747), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1748) },
                    { 12L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1689), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1691) },
                    { 10L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1577), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1578) },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1202), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1203) },
                    { 8L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1455), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1456) },
                    { 7L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1398), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1399) },
                    { 6L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1340), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1341) },
                    { 5L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1274), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1275) },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1139), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1140) },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(970), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(971) },
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 951, DateTimeKind.Local).AddTicks(422), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 5, 8, 22, 52, 14, 951, DateTimeKind.Local).AddTicks(446) },
                    { 19L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(2129), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(2130) },
                    { 9L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1511), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(1512) },
                    { 20L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(2189), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(2189) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "FirstActiveSyllabusId", "SecondActiveSyylabusId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(2602), "BM310", 1L, 0L, 0L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(2604) },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(2805), "BM311", 1L, 0L, 0L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(2806) },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(2827), "BM312", 1L, 0L, 0L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(2827) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(581), 3, 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(581) },
                    { 36L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(566), 2, 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(566) },
                    { 35L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(552), 1, 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(552) },
                    { 34L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(537), 3, 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(538) },
                    { 33L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(522), 2, 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(522) },
                    { 32L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(501), 1, 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(502) },
                    { 31L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(487), 3, 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(488) },
                    { 29L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(459), 1, 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(460) },
                    { 38L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(595), 1, 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(596) },
                    { 28L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(445), 3, 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(446) },
                    { 27L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(431), 2, 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(432) },
                    { 26L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(417), 1, 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(418) },
                    { 25L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(403), 3, 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(404) },
                    { 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(389), 2, 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(389) },
                    { 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(374), 1, 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(374) },
                    { 30L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(473), 2, 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(474) },
                    { 39L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(609), 2, 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(610) },
                    { 41L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(638), 1, 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(638) },
                    { 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(360), 2, 12L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(360) },
                    { 58L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(901), 3, 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(902) },
                    { 57L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(887), 2, 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(887) },
                    { 56L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(873), 1, 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(873) },
                    { 55L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(858), 3, 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(859) },
                    { 54L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(844), 2, 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(844) },
                    { 53L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(829), 1, 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(830) },
                    { 52L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(815), 3, 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(816) },
                    { 40L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(624), 3, 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(625) },
                    { 51L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(801), 2, 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(801) },
                    { 49L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(772), 3, 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(773) },
                    { 48L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(758), 2, 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(758) },
                    { 47L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(743), 1, 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(744) },
                    { 46L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(729), 3, 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(730) },
                    { 45L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(714), 2, 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(715) },
                    { 44L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(699), 1, 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(699) },
                    { 43L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(684), 3, 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(685) },
                    { 50L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(786), 1, 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(787) },
                    { 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(346), 1, 12L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(347) },
                    { 42L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(652), 2, 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(652) },
                    { 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(318), 1, 11L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(319) },
                    { 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(332), 2, 11L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(333) },
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(9873), 1, 1L, new DateTime(2019, 5, 8, 22, 52, 14, 954, DateTimeKind.Local).AddTicks(9875) },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(54), 2, 1L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(55) },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(73), 1, 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(73) },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(98), 2, 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(98) },
                    { 6L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(129), 2, 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(130) },
                    { 7L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(143), 1, 4L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(144) },
                    { 8L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(158), 1, 5L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(159) },
                    { 9L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(172), 1, 6L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(173) },
                    { 5L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(112), 1, 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(113) },
                    { 11L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(202), 1, 7L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(203) },
                    { 10L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(188), 2, 6L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(189) },
                    { 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(289), 1, 10L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(289) },
                    { 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(274), 2, 9L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(275) },
                    { 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(260), 1, 9L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(261) },
                    { 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(304), 2, 10L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(305) },
                    { 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(231), 1, 8L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(231) },
                    { 12L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(217), 2, 7L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(217) },
                    { 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(245), 2, 8L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(245) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1765), 1L, "1007", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1766) },
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(993), 1L, "1000", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(995) },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1674), 1L, "1001", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1674) },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1695), 1L, "1002", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1695) },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1708), 1L, "1003", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1709) },
                    { 5L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1722), 1L, "1004", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1723) },
                    { 6L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1738), 1L, "1005", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1739) },
                    { 7L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1752), 1L, "1006", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1752) },
                    { 9L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1779), 1L, "1008", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1779) },
                    { 14L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1847), 1L, "10013", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1848) },
                    { 11L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1807), 1L, "10010", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1808) },
                    { 12L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1821), 1L, "10011", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1821) },
                    { 13L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1834), 1L, "10012", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1835) },
                    { 15L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1870), 1L, "10014", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1871) },
                    { 16L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1884), 1L, "10015", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1885) },
                    { 17L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1897), 1L, "10016", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1898) },
                    { 10L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1793), 1L, "1009", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1794) },
                    { 18L, new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1912), 1L, "10017", new DateTime(2019, 5, 8, 22, 52, 14, 957, DateTimeKind.Local).AddTicks(1913) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9253), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9253), 7L, 14 },
                    { 16L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9398), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9398), 17L, 16 },
                    { 7L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9267), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9268), 8L, 8 },
                    { 15L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9384), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9385), 16L, 12 },
                    { 8L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9281), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9282), 9L, 10 },
                    { 10L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9312), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9313), 11L, 12 },
                    { 9L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9297), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9297), 10L, 12 },
                    { 13L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9355), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9356), 14L, 16 },
                    { 11L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9327), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9328), 12L, 12 },
                    { 5L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9234), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9235), 6L, 12 },
                    { 14L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9370), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9371), 15L, 16 },
                    { 17L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9412), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9412), 18L, 9 },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9161), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9161), 3L, 6 },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9220), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9220), 5L, 10 },
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(8383), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(8387), 2L, 4 },
                    { 19L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9455), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9456), 20L, 16 },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9201), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9201), 4L, 8 },
                    { 18L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9440), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9441), 19L, 16 },
                    { 12L, new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9341), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 5, 8, 22, 52, 14, 953, DateTimeKind.Local).AddTicks(9341), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3737), 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3738), 17L },
                    { 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3429), 8L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3430), 13L },
                    { 28L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3565), 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3566), 13L },
                    { 29L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3579), 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3580), 13L },
                    { 9L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3301), 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3302), 13L },
                    { 30L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3592), 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3593), 13L },
                    { 42L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3764), 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3765), 17L },
                    { 10L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3317), 4L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3318), 14L },
                    { 49L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3860), 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3861), 20L },
                    { 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3470), 9L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3471), 14L },
                    { 31L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3606), 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3607), 14L },
                    { 32L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3626), 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3626), 14L },
                    { 45L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3805), 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3806), 18L },
                    { 33L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3641), 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3642), 14L },
                    { 48L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3846), 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3847), 19L },
                    { 43L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3778), 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3778), 18L },
                    { 35L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3669), 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3670), 15L },
                    { 36L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3683), 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3683), 15L },
                    { 47L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3833), 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3833), 19L },
                    { 61L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4031), 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4032), 15L },
                    { 46L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3819), 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3820), 19L },
                    { 37L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3696), 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3697), 16L },
                    { 44L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3791), 18L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3792), 18L },
                    { 38L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3710), 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3711), 16L },
                    { 39L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3724), 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3724), 16L },
                    { 41L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3751), 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3752), 17L },
                    { 34L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3655), 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3656), 15L },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3226), 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3227), 2L },
                    { 27L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3552), 12L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3553), 12L },
                    { 11L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3331), 5L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3332), 7L },
                    { 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3511), 11L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3512), 6L },
                    { 57L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3970), 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3971), 5L },
                    { 17L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3415), 8L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3415), 5L },
                    { 8L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3287), 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3288), 5L },
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(2529), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(2531), 5L },
                    { 25L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3525), 11L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3525), 7L },
                    { 56L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3957), 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3957), 4L },
                    { 12L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3345), 6L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3345), 4L },
                    { 55L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3943), 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3944), 3L },
                    { 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3497), 10L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3498), 3L },
                    { 7L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3271), 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3272), 3L },
                    { 22L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3484), 10L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3484), 2L },
                    { 50L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3874), 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3874), 20L },
                    { 26L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3538), 12L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3539), 4L },
                    { 60L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4017), 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4017), 12L },
                    { 63L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4058), 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4059), 7L },
                    { 19L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3443), 9L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3444), 8L },
                    { 15L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3387), 7L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3388), 12L },
                    { 6L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3256), 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3257), 12L },
                    { 59L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3998), 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3998), 11L },
                    { 14L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3373), 7L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3373), 11L },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3203), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3203), 11L },
                    { 58L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3984), 23L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3985), 10L },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3179), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3180), 8L },
                    { 54L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3929), 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3930), 10L },
                    { 13L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3358), 6L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3359), 10L },
                    { 62L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4044), 24L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(4045), 9L },
                    { 53L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3915), 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3916), 9L },
                    { 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3457), 9L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3457), 9L },
                    { 5L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3240), 2L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3241), 9L },
                    { 52L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3901), 21L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3902), 8L },
                    { 16L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3401), 7L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3402), 10L },
                    { 51L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3888), 20L, new DateTime(2019, 5, 8, 22, 52, 14, 955, DateTimeKind.Local).AddTicks(3888), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Department",
                table: "DepartmentInstructor",
                columns: new[] { "DepartmentInstructorId", "CreatedDate", "DepartmentId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(4436), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(4438), 2L },
                    { 19L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5414), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5414), 20L },
                    { 18L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5400), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5401), 19L },
                    { 17L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5385), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5386), 18L },
                    { 16L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5372), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5373), 17L },
                    { 14L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5344), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5345), 15L },
                    { 13L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5330), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5331), 14L },
                    { 12L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5314), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5314), 13L },
                    { 11L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5295), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5296), 12L },
                    { 15L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5358), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5358), 16L },
                    { 9L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5188), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5189), 10L },
                    { 8L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5174), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5175), 9L },
                    { 7L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5161), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5161), 8L },
                    { 6L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5147), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5148), 7L },
                    { 5L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5130), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5130), 6L },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5116), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5117), 5L },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5101), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5102), 4L },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5081), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5082), 3L },
                    { 10L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5203), 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(5203), 11L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 14L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8738), 1L, 14L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8739) },
                    { 15L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8753), 1L, 15L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8753) },
                    { 16L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8766), 1L, 16L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8767) },
                    { 17L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8781), 1L, 17L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8782) },
                    { 22L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8862), 1L, 22L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8862) },
                    { 19L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8819), 1L, 19L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8820) },
                    { 20L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8834), 1L, 20L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8835) },
                    { 21L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8848), 1L, 21L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8849) },
                    { 13L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8724), 1L, 13L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8725) },
                    { 18L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8796), 1L, 18L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8797) },
                    { 12L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8710), 1L, 12L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8711) },
                    { 3L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8576), 1L, 3L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8577) },
                    { 10L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8682), 1L, 10L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8683) },
                    { 9L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8667), 1L, 9L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8668) },
                    { 8L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8652), 1L, 8L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8653) },
                    { 7L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8638), 1L, 7L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8638) },
                    { 6L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8623), 1L, 6L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8624) },
                    { 5L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8605), 1L, 5L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8605) },
                    { 4L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8591), 1L, 4L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8591) },
                    { 23L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8875), 1L, 23L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8876) },
                    { 2L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8552), 1L, 2L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8553) },
                    { 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(7497), 1L, 1L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(7502) },
                    { 11L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8696), 1L, 11L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8697) },
                    { 24L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8889), 1L, 24L, new DateTime(2019, 5, 8, 22, 52, 14, 956, DateTimeKind.Local).AddTicks(8890) }
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
