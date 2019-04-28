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
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1391), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1396) },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1890), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1891) },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1950), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1951) },
                    { 4L, new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1974), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(1975) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6893), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6894), 3 },
                    { 23L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6836), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6837), 3 },
                    { 22L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6777), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6779), 3 },
                    { 21L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6718), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6719), 3 },
                    { 19L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6600), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6601), 3 },
                    { 18L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6540), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6542), 3 },
                    { 17L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6471), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6473), 3 },
                    { 16L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6411), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6413), 3 },
                    { 15L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6353), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6354), 3 },
                    { 14L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6295), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6296), 3 },
                    { 13L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6236), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6238), 3 },
                    { 20L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6659), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6660), 3 },
                    { 11L, 6, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6118), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6120), 4 },
                    { 12L, 6, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6177), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6179), 3 },
                    { 1L, 4, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(3380), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(3388), 4 },
                    { 3L, 6, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5605), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5607), 4 },
                    { 4L, 4, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5697), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5699), 2 },
                    { 5L, 4, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5758), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5759), 2 },
                    { 2L, 6, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5513), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5515), 5 },
                    { 7L, 4, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5880), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5881), 4 },
                    { 8L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5939), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5941), 3 },
                    { 9L, 2, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5998), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6000), 2 },
                    { 10L, 5, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6060), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(6061), 3 },
                    { 6L, 6, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5822), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(5824), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(157), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(158) },
                    { 11L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9437), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9438) },
                    { 17L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(54), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(55) },
                    { 16L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9953), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9954) },
                    { 15L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9844), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9846) },
                    { 14L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9752), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9753) },
                    { 13L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9653), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9654) },
                    { 12L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9545), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9546) },
                    { 10L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9331), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9332) },
                    { 4L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8644), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8645) },
                    { 8L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9104), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9106) },
                    { 7L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8993), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8995) },
                    { 6L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8864), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8865) },
                    { 5L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8756), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8758) },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8118), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(8119) },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(7676), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(7678) },
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 115, DateTimeKind.Local).AddTicks(6902), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 28, 11, 36, 28, 115, DateTimeKind.Local).AddTicks(6970) },
                    { 19L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(291), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(292) },
                    { 9L, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9214), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 4, 28, 11, 36, 28, 120, DateTimeKind.Local).AddTicks(9215) },
                    { 20L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(387), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(388) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(9782), "BM310", 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 28, 11, 36, 28, 124, DateTimeKind.Local).AddTicks(9803) },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(511), "BM311", 1L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(513) },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(579), "BM312", 1L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(580) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1430), 3, 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1431) },
                    { 36L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1409), 2, 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1410) },
                    { 35L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1387), 1, 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1388) },
                    { 34L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1366), 3, 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1366) },
                    { 33L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1340), 2, 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1341) },
                    { 32L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1288), 1, 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1290) },
                    { 31L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1237), 3, 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1239) },
                    { 29L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1103), 1, 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1105) },
                    { 38L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1451), 1, 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1452) },
                    { 28L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1049), 3, 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1051) },
                    { 27L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(991), 2, 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(993) },
                    { 26L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(937), 1, 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(938) },
                    { 25L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(880), 3, 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(882) },
                    { 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(802), 2, 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(803) },
                    { 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(747), 1, 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(748) },
                    { 30L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1181), 2, 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1183) },
                    { 39L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1502), 2, 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1503) },
                    { 41L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1578), 1, 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1579) },
                    { 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(695), 2, 12L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(697) },
                    { 58L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2086), 3, 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2087) },
                    { 57L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2057), 2, 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2058) },
                    { 56L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2034), 1, 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2035) },
                    { 55L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2011), 3, 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(2011) },
                    { 54L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1987), 2, 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1988) },
                    { 53L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1962), 1, 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1963) },
                    { 52L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1940), 3, 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1941) },
                    { 40L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1550), 3, 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1551) },
                    { 51L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1917), 2, 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1918) },
                    { 49L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1872), 3, 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1873) },
                    { 48L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1851), 2, 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1852) },
                    { 47L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1829), 1, 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1831) },
                    { 46L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1809), 3, 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1810) },
                    { 45L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1763), 2, 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1765) },
                    { 44L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1733), 1, 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1734) },
                    { 43L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1680), 3, 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1682) },
                    { 50L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1895), 1, 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1895) },
                    { 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(641), 1, 12L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(642) },
                    { 42L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1624), 2, 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(1625) },
                    { 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(534), 1, 11L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(536) },
                    { 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(588), 2, 11L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(589) },
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9295), 1, 1L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9298) },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9638), 2, 1L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9639) },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9700), 1, 2L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9701) },
                    { 4L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9755), 2, 2L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9756) },
                    { 6L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9867), 2, 3L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9869) },
                    { 7L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9917), 1, 4L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9918) },
                    { 8L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9964), 1, 5L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9965) },
                    { 9L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(11), 1, 6L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(13) },
                    { 5L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9810), 1, 3L, new DateTime(2019, 4, 28, 11, 36, 28, 122, DateTimeKind.Local).AddTicks(9811) },
                    { 11L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(107), 1, 7L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(109) },
                    { 10L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(60), 2, 6L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(62) },
                    { 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(424), 1, 10L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(425) },
                    { 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(367), 2, 9L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(368) },
                    { 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(296), 1, 9L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(297) },
                    { 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(480), 2, 10L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(482) },
                    { 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(201), 1, 8L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(203) },
                    { 12L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(154), 2, 7L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(156) },
                    { 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(249), 2, 8L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(250) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(251), 1L, "1007", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(252) },
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 126, DateTimeKind.Local).AddTicks(6978), 1L, "1000", new DateTime(2019, 4, 28, 11, 36, 28, 126, DateTimeKind.Local).AddTicks(6989) },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(74), 1L, "1001", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(75) },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(127), 1L, "1002", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(128) },
                    { 4L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(151), 1L, "1003", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(152) },
                    { 5L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(174), 1L, "1004", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(175) },
                    { 6L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(205), 1L, "1005", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(205) },
                    { 7L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(228), 1L, "1006", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(228) },
                    { 9L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(276), 1L, "1008", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(277) },
                    { 14L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(396), 1L, "10013", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(397) },
                    { 11L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(326), 1L, "10010", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(326) },
                    { 12L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(348), 1L, "10011", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(349) },
                    { 13L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(373), 1L, "10012", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(374) },
                    { 15L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(419), 1L, "10014", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(420) },
                    { 16L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(440), 1L, "10015", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(441) },
                    { 17L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(463), 1L, "10016", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(464) },
                    { 10L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(302), 1L, "1009", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(303) },
                    { 18L, new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(603), 1L, "10017", new DateTime(2019, 4, 28, 11, 36, 28, 127, DateTimeKind.Local).AddTicks(603) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6753), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6755), 7L, 14 },
                    { 16L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7025), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7025), 17L, 16 },
                    { 7L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6782), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6783), 8L, 8 },
                    { 15L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6999), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6999), 16L, 12 },
                    { 8L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6808), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6809), 9L, 10 },
                    { 10L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6865), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6866), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6837), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6838), 10L, 12 },
                    { 13L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6949), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6950), 14L, 16 },
                    { 11L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6893), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6894), 12L, 12 },
                    { 5L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6722), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6723), 6L, 12 },
                    { 14L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6974), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6975), 15L, 16 },
                    { 17L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7051), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7052), 18L, 9 },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6581), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6582), 3L, 6 },
                    { 4L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6695), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6696), 5L, 10 },
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(5784), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(5789), 2L, 4 },
                    { 19L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7104), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7105), 20L, 16 },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6663), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6664), 4L, 8 },
                    { 18L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7078), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(7079), 19L, 16 },
                    { 12L, new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6920), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 4, 28, 11, 36, 28, 121, DateTimeKind.Local).AddTicks(6921), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5449), 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5450), 17L },
                    { 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4818), 8L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4819), 13L },
                    { 28L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5112), 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5113), 13L },
                    { 29L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5132), 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5133), 13L },
                    { 9L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4568), 3L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4569), 13L },
                    { 30L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5153), 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5153), 13L },
                    { 42L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5488), 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5489), 17L },
                    { 10L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4591), 4L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4592), 14L },
                    { 49L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5711), 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5712), 20L },
                    { 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4911), 9L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4912), 14L },
                    { 31L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5183), 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5184), 14L },
                    { 32L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5224), 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5225), 14L },
                    { 45L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5592), 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5593), 18L },
                    { 33L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5244), 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5247), 14L },
                    { 48L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5691), 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5692), 19L },
                    { 43L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5548), 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5550), 18L },
                    { 35L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5298), 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5300), 15L },
                    { 36L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5338), 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5339), 15L },
                    { 47L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5670), 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5671), 19L },
                    { 61L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6052), 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6053), 15L },
                    { 46L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5614), 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5614), 19L },
                    { 37L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5359), 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5359), 16L },
                    { 44L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5570), 18L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5570), 18L },
                    { 38L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5378), 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5379), 16L },
                    { 39L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5411), 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5413), 16L },
                    { 41L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5469), 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5469), 17L },
                    { 34L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5268), 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5269), 15L },
                    { 4L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4429), 2L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4430), 2L },
                    { 27L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5079), 12L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5081), 12L },
                    { 11L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4640), 5L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4641), 7L },
                    { 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5004), 11L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5005), 6L },
                    { 57L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5941), 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5941), 5L },
                    { 17L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4797), 8L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4798), 5L },
                    { 8L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4548), 3L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4549), 5L },
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(3590), 1L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(3593), 5L },
                    { 25L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5024), 11L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5025), 7L },
                    { 56L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5921), 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5922), 4L },
                    { 12L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4663), 6L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4664), 4L },
                    { 55L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5899), 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5900), 3L },
                    { 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4982), 10L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4983), 3L },
                    { 7L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4517), 3L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4519), 3L },
                    { 22L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4932), 10L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4932), 2L },
                    { 50L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5731), 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5731), 20L },
                    { 26L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5044), 12L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5044), 4L },
                    { 60L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6033), 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6034), 12L },
                    { 63L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6125), 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6126), 7L },
                    { 19L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4867), 9L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4869), 8L },
                    { 15L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4753), 7L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4755), 12L },
                    { 6L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4475), 2L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4476), 12L },
                    { 59L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6013), 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6014), 11L },
                    { 14L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4702), 7L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4703), 11L },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4389), 1L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4391), 11L },
                    { 58L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5961), 23L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5964), 10L },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4340), 1L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4341), 8L },
                    { 54L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5847), 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5850), 10L },
                    { 13L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4682), 6L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4683), 10L },
                    { 62L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6075), 24L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(6076), 9L },
                    { 53L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5828), 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5829), 9L },
                    { 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4890), 9L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4890), 9L },
                    { 5L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4448), 2L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4449), 9L },
                    { 52L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5808), 21L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5809), 8L },
                    { 16L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4778), 7L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(4779), 10L },
                    { 51L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5783), 20L, new DateTime(2019, 4, 28, 11, 36, 28, 123, DateTimeKind.Local).AddTicks(5787), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(7897), 1L, 1L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(7905) },
                    { 22L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9663), 1L, 22L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9664) },
                    { 21L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9636), 1L, 21L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9637) },
                    { 20L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9615), 1L, 20L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9615) },
                    { 19L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9593), 1L, 19L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9595) },
                    { 18L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9572), 1L, 18L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9573) },
                    { 17L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9549), 1L, 17L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9550) },
                    { 16L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9527), 1L, 16L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9528) },
                    { 15L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9503), 1L, 15L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9504) },
                    { 14L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9479), 1L, 14L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9480) },
                    { 13L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9455), 1L, 13L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9456) },
                    { 12L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9432), 1L, 12L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9433) },
                    { 11L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9408), 1L, 11L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9409) },
                    { 10L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9383), 1L, 10L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9384) },
                    { 9L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9354), 1L, 9L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9355) },
                    { 8L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9330), 1L, 8L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9332) },
                    { 7L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9307), 1L, 7L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9308) },
                    { 6L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9283), 1L, 6L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9284) },
                    { 5L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9250), 1L, 5L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9251) },
                    { 4L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9226), 1L, 4L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9227) },
                    { 3L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9199), 1L, 3L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9200) },
                    { 2L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9155), 1L, 2L, new DateTime(2019, 4, 28, 11, 36, 28, 125, DateTimeKind.Local).AddTicks(9156) },
                    { 23L, new DateTime(2019, 4, 28, 11, 36, 28, 126, DateTimeKind.Local).AddTicks(2178), 1L, 23L, new DateTime(2019, 4, 28, 11, 36, 28, 126, DateTimeKind.Local).AddTicks(2180) },
                    { 24L, new DateTime(2019, 4, 28, 11, 36, 28, 126, DateTimeKind.Local).AddTicks(2288), 1L, 24L, new DateTime(2019, 4, 28, 11, 36, 28, 126, DateTimeKind.Local).AddTicks(2288) }
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
