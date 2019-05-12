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
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(9574), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(9581) },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(78), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(79) },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(114), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(115) },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(139), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(140) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9459), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9459), 3 },
                    { 23L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9434), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9434), 3 },
                    { 22L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9411), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9412), 3 },
                    { 21L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9387), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9388), 3 },
                    { 19L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9337), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9338), 3 },
                    { 18L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9313), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9314), 3 },
                    { 17L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9287), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9288), 3 },
                    { 16L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9262), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9263), 3 },
                    { 15L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9234), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9235), 3 },
                    { 14L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9204), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9205), 3 },
                    { 13L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9178), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9178), 3 },
                    { 20L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9361), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9362), 3 },
                    { 11L, 6, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9120), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9121), 4 },
                    { 12L, 6, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9150), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9151), 3 },
                    { 1L, 4, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(2924), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(2940), 4 },
                    { 3L, 6, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8853), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8854), 4 },
                    { 4L, 4, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8890), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8891), 2 },
                    { 5L, 4, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8916), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8918), 2 },
                    { 2L, 6, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8541), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8543), 5 },
                    { 7L, 4, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8988), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8989), 4 },
                    { 8L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9015), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9016), 3 },
                    { 9L, 2, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9039), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9040), 2 },
                    { 10L, 5, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9066), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(9067), 3 },
                    { 6L, 6, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8959), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 5, 12, 3, 21, 8, 430, DateTimeKind.Local).AddTicks(8960), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2826), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2827) },
                    { 11L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2133), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2135) },
                    { 17L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2735), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2736) },
                    { 16L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2648), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2649) },
                    { 15L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2552), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2553) },
                    { 14L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2455), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2456) },
                    { 13L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2341), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2342) },
                    { 12L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2244), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2245) },
                    { 10L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(1998), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2000) },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7560), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7562) },
                    { 8L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(403), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(405) },
                    { 7L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(78), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(82) },
                    { 6L, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7866), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7868) },
                    { 5L, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7730), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7732) },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7412), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(7414) },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(6944), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 5, 12, 3, 21, 8, 427, DateTimeKind.Local).AddTicks(6947) },
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 423, DateTimeKind.Local).AddTicks(8691), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 5, 12, 3, 21, 8, 423, DateTimeKind.Local).AddTicks(8713) },
                    { 19L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2965), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(2967) },
                    { 9L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(1641), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(1647) },
                    { 20L, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(3076), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 5, 12, 3, 21, 8, 428, DateTimeKind.Local).AddTicks(3077) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "FirstActiveSyllabusId", "SecondActiveSyylabusId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(6867), "BM310", 1L, 0L, 0L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(6871) },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(7433), "BM311", 1L, 0L, 0L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(7435) },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(7478), "BM312", 1L, 0L, 0L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(7478) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5660), 3, 17L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5661) },
                    { 36L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5637), 2, 17L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5637) },
                    { 35L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5614), 1, 17L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5615) },
                    { 34L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5592), 3, 16L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5593) },
                    { 33L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5568), 2, 16L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5569) },
                    { 32L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5544), 1, 16L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5545) },
                    { 31L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5522), 3, 15L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5523) },
                    { 29L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5464), 1, 15L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5464) },
                    { 38L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5681), 1, 18L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5682) },
                    { 28L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5440), 3, 14L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5441) },
                    { 27L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5415), 2, 14L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5416) },
                    { 26L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5391), 1, 14L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5392) },
                    { 25L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5367), 3, 13L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5367) },
                    { 24L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5343), 2, 13L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5344) },
                    { 23L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5322), 1, 13L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5323) },
                    { 30L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5500), 2, 15L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5501) },
                    { 39L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5702), 2, 18L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5703) },
                    { 41L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5744), 1, 19L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5745) },
                    { 22L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5300), 2, 12L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5301) },
                    { 58L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6182), 3, 24L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6183) },
                    { 57L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6157), 2, 24L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6158) },
                    { 56L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6130), 1, 24L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6131) },
                    { 55L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6096), 3, 23L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6097) },
                    { 54L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6078), 2, 23L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6078) },
                    { 53L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6057), 1, 23L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6058) },
                    { 52L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6036), 3, 22L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6037) },
                    { 40L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5723), 3, 18L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5723) },
                    { 51L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6016), 2, 22L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(6017) },
                    { 48L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5945), 2, 21L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5946) },
                    { 47L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5923), 1, 21L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5923) },
                    { 46L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5899), 3, 20L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5900) },
                    { 45L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5878), 2, 20L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5879) },
                    { 44L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5857), 1, 20L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5858) },
                    { 43L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5834), 3, 19L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5835) },
                    { 42L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5764), 2, 19L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5765) },
                    { 49L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5969), 3, 21L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5971) },
                    { 21L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5279), 1, 12L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5280) },
                    { 50L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5991), 1, 22L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5992) },
                    { 19L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5238), 1, 11L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5239) },
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4155), 1, 1L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4160) },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4858), 2, 1L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4859) },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4896), 1, 2L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4896) },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4919), 2, 2L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4919) },
                    { 5L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4940), 1, 3L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4941) },
                    { 6L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4966), 2, 3L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4967) },
                    { 7L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4988), 1, 4L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(4989) },
                    { 8L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5008), 1, 5L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5009) },
                    { 9L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5029), 1, 6L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5029) },
                    { 20L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5259), 2, 11L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5259) },
                    { 11L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5070), 1, 7L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5071) },
                    { 12L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5091), 2, 7L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5091) },
                    { 13L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5113), 1, 8L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5114) },
                    { 14L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5135), 2, 8L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5135) },
                    { 15L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5155), 1, 9L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5155) },
                    { 16L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5174), 2, 9L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5175) },
                    { 17L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5194), 1, 10L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5195) },
                    { 18L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5217), 2, 10L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5218) },
                    { 10L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5049), 2, 6L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(5050) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 7L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9212), 1L, "1006", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9212) },
                    { 6L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9180), 1L, "1005", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9180) },
                    { 5L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9153), 1L, "1004", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9154) },
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(7962), 1L, "1000", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(7966) },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9108), 1L, "1002", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9108) },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9065), 1L, "1001", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9067) },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9130), 1L, "1003", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9131) },
                    { 9L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9256), 1L, "1008", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9257) },
                    { 8L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9234), 1L, "1007", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9235) },
                    { 12L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9322), 1L, "10011", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9323) },
                    { 11L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9300), 1L, "10010", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9301) },
                    { 13L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9344), 1L, "10012", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9345) },
                    { 14L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9367), 1L, "10013", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9368) },
                    { 15L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9389), 1L, "10014", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9390) },
                    { 16L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9411), 1L, "10015", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9412) },
                    { 17L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9434), 1L, "10016", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9434) },
                    { 18L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9458), 1L, "10017", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9458) },
                    { 10L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9280), 1L, "1009", new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(9281) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5332), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5333), 18L, 9 },
                    { 16L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5285), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5287), 17L, 16 },
                    { 5L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4854), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4855), 6L, 12 },
                    { 15L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5236), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5237), 16L, 12 },
                    { 6L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4897), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4898), 7L, 14 },
                    { 9L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4991), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4992), 10L, 12 },
                    { 7L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4928), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4929), 8L, 8 },
                    { 13L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5117), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5119), 14L, 16 },
                    { 8L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4960), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4961), 9L, 10 },
                    { 12L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5087), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5088), 13L, 16 },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4821), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4823), 5L, 10 },
                    { 14L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5168), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5169), 15L, 16 },
                    { 10L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5024), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5025), 11L, 12 },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4788), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4789), 4L, 8 },
                    { 19L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5433), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5434), 20L, 16 },
                    { 11L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5055), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5056), 12L, 12 },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4707), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(4708), 3L, 6 },
                    { 18L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5385), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(5387), 19L, 16 },
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(3133), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 5, 12, 3, 21, 8, 429, DateTimeKind.Local).AddTicks(3157), 2L, 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 95L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2776), 19L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2776), 20L },
                    { 69L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2149), 17L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2150), 14L },
                    { 68L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2124), 16L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2125), 14L },
                    { 67L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2100), 15L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2101), 14L },
                    { 66L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2077), 14L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2078), 14L },
                    { 96L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2798), 20L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2799), 20L },
                    { 97L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2822), 21L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2822), 20L },
                    { 65L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2051), 13L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2052), 13L },
                    { 63L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2005), 11L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2005), 13L },
                    { 70L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2172), 18L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2173), 14L },
                    { 62L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1981), 10L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1983), 13L },
                    { 61L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1957), 9L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1958), 13L },
                    { 98L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2846), 22L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2847), 20L },
                    { 60L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1933), 8L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1934), 12L },
                    { 59L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1910), 7L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1911), 12L },
                    { 58L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1887), 6L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1888), 12L },
                    { 57L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1863), 5L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1864), 12L },
                    { 56L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1830), 4L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1831), 12L },
                    { 64L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2027), 12L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2028), 13L },
                    { 89L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2632), 13L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2633), 18L },
                    { 71L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2195), 19L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2196), 15L },
                    { 72L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2219), 20L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2219), 15L },
                    { 88L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2610), 12L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2611), 18L },
                    { 87L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2587), 11L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2588), 18L },
                    { 86L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2563), 10L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2564), 18L },
                    { 91L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2680), 15L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2681), 19L },
                    { 85L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2539), 9L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2540), 17L },
                    { 84L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2516), 8L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2517), 17L },
                    { 83L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2491), 7L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2492), 17L },
                    { 82L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2460), 6L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2461), 17L },
                    { 81L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2435), 5L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2436), 17L },
                    { 90L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2656), 14L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2657), 18L },
                    { 92L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2703), 16L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2704), 19L },
                    { 79L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2387), 3L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2388), 16L },
                    { 78L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2363), 2L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2364), 16L },
                    { 93L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2728), 17L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2729), 19L },
                    { 77L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2340), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2341), 16L },
                    { 76L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2316), 24L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2317), 16L },
                    { 94L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2752), 18L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2753), 19L },
                    { 75L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2291), 23L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2292), 15L },
                    { 74L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2267), 22L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2268), 15L },
                    { 73L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2242), 21L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2243), 15L },
                    { 80L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2410), 4L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2411), 16L },
                    { 55L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1804), 3L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1805), 11L },
                    { 16L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(861), 16L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(861), 5L },
                    { 53L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1755), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1756), 11L },
                    { 24L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1054), 24L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1055), 5L },
                    { 23L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1029), 23L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1030), 5L },
                    { 22L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1005), 22L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1006), 5L },
                    { 21L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(981), 21L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(982), 5L },
                    { 20L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(959), 20L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(959), 5L },
                    { 19L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(934), 19L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(935), 5L },
                    { 18L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(910), 18L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(911), 5L },
                    { 17L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(883), 17L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(883), 5L },
                    { 99L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2870), 23L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2871), 20L },
                    { 15L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(837), 15L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(838), 4L },
                    { 14L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(814), 14L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(815), 4L },
                    { 25L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1078), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1078), 5L },
                    { 13L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(793), 13L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(794), 4L },
                    { 11L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(744), 11L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(745), 4L },
                    { 10L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(621), 10L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(622), 3L },
                    { 9L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(596), 9L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(597), 3L },
                    { 8L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(573), 8L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(574), 3L },
                    { 7L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(550), 7L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(551), 3L },
                    { 6L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(526), 6L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(527), 3L },
                    { 5L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(498), 5L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(499), 2L },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(473), 4L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(475), 2L },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(446), 3L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(447), 2L },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(398), 2L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(399), 2L },
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(9196), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 431, DateTimeKind.Local).AddTicks(9201), 2L },
                    { 12L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(770), 12L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(771), 4L },
                    { 54L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1779), 2L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1780), 11L },
                    { 26L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1102), 2L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1103), 6L },
                    { 28L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1149), 4L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1150), 6L },
                    { 52L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1732), 24L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1733), 11L },
                    { 51L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1708), 23L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1709), 11L },
                    { 50L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1685), 2L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1686), 10L },
                    { 49L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1662), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1663), 10L },
                    { 48L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1639), 24L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1640), 10L },
                    { 47L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1615), 23L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1616), 10L },
                    { 46L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1591), 22L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1592), 10L },
                    { 45L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1568), 21L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1569), 9L },
                    { 44L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1544), 20L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1545), 9L },
                    { 43L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1520), 19L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1521), 9L },
                    { 42L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1496), 18L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1497), 9L },
                    { 27L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1126), 3L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1127), 6L },
                    { 41L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1473), 17L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1474), 9L },
                    { 39L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1426), 15L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1426), 8L },
                    { 38L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1403), 14L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1403), 8L },
                    { 37L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1380), 13L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1381), 8L },
                    { 36L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1357), 12L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1357), 8L },
                    { 35L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1333), 11L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1334), 7L },
                    { 34L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1309), 10L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1310), 7L },
                    { 33L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1281), 9L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1282), 7L },
                    { 32L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1258), 8L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1258), 7L },
                    { 31L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1234), 7L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1235), 7L },
                    { 30L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1211), 6L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1212), 6L },
                    { 29L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1186), 5L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1187), 6L },
                    { 40L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1449), 16L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(1450), 8L },
                    { 100L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2895), 24L, new DateTime(2019, 5, 12, 3, 21, 8, 432, DateTimeKind.Local).AddTicks(2896), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Department",
                table: "DepartmentInstructor",
                columns: new[] { "DepartmentInstructorId", "CreatedDate", "DepartmentId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(9849), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 433, DateTimeKind.Local).AddTicks(9852), 2L },
                    { 19L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1325), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1326), 20L },
                    { 18L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1303), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1304), 19L },
                    { 17L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1279), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1280), 18L },
                    { 16L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1256), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1257), 17L },
                    { 14L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1211), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1212), 15L },
                    { 13L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1189), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1190), 14L },
                    { 12L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1166), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1166), 13L },
                    { 11L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1143), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1144), 12L },
                    { 15L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1234), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1235), 16L },
                    { 9L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1095), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1096), 10L },
                    { 8L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1072), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1073), 9L },
                    { 7L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1049), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1050), 8L },
                    { 6L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1026), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1027), 7L },
                    { 5L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(998), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(999), 6L },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(974), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(975), 5L },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(950), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(951), 4L },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(916), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(917), 3L },
                    { 10L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1120), 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(1121), 11L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 14L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4792), 1L, 14L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4793) },
                    { 15L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4817), 1L, 15L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4817) },
                    { 16L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4842), 1L, 16L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4843) },
                    { 17L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4868), 1L, 17L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4869) },
                    { 22L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4998), 1L, 22L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4998) },
                    { 19L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4922), 1L, 19L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4923) },
                    { 20L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4948), 1L, 20L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4948) },
                    { 21L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4973), 1L, 21L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4974) },
                    { 13L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4770), 1L, 13L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4771) },
                    { 18L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4897), 1L, 18L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4898) },
                    { 12L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4747), 1L, 12L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4748) },
                    { 3L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4516), 1L, 3L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4517) },
                    { 10L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4698), 1L, 10L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4699) },
                    { 9L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4671), 1L, 9L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4672) },
                    { 8L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4647), 1L, 8L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4648) },
                    { 7L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4626), 1L, 7L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4626) },
                    { 6L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4590), 1L, 6L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4591) },
                    { 5L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4562), 1L, 5L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4563) },
                    { 4L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4539), 1L, 4L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4540) },
                    { 23L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(5022), 1L, 23L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(5023) },
                    { 2L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4481), 1L, 2L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4482) },
                    { 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(3480), 1L, 1L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(3483) },
                    { 11L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4724), 1L, 11L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(4725) },
                    { 24L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(5048), 1L, 24L, new DateTime(2019, 5, 12, 3, 21, 8, 434, DateTimeKind.Local).AddTicks(5049) }
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
