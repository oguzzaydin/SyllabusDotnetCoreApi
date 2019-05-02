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
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(662), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(665) },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(941), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(942) },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(962), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(963) },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(978), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(979) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2185), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2185), 3 },
                    { 23L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2160), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2160), 3 },
                    { 22L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2134), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2135), 3 },
                    { 21L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2109), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2110), 3 },
                    { 19L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2036), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2037), 3 },
                    { 18L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2013), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2014), 3 },
                    { 17L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1989), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1989), 3 },
                    { 16L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1965), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1966), 3 },
                    { 15L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1942), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1943), 3 },
                    { 14L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1918), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1919), 3 },
                    { 13L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1893), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1894), 3 },
                    { 20L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2080), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(2081), 3 },
                    { 11L, 6, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1844), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1845), 4 },
                    { 12L, 6, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1868), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1869), 3 },
                    { 1L, 4, new DateTime(2019, 5, 1, 23, 57, 40, 68, DateTimeKind.Local).AddTicks(7054), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 5, 1, 23, 57, 40, 68, DateTimeKind.Local).AddTicks(7084), 4 },
                    { 3L, 6, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1434), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1435), 4 },
                    { 4L, 4, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1462), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1463), 2 },
                    { 5L, 4, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1486), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1487), 2 },
                    { 2L, 6, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1343), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1344), 5 },
                    { 7L, 4, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1725), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1726), 4 },
                    { 8L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1759), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1760), 3 },
                    { 9L, 2, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1787), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1788), 2 },
                    { 10L, 5, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1815), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1816), 3 },
                    { 6L, 6, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1522), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 5, 1, 23, 57, 40, 69, DateTimeKind.Local).AddTicks(1523), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8493), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8494) },
                    { 11L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8078), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8079) },
                    { 17L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8432), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8433) },
                    { 16L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8370), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8370) },
                    { 15L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8314), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8314) },
                    { 14L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8258), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8259) },
                    { 13L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8199), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8200) },
                    { 12L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8135), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8136) },
                    { 10L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8021), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8022) },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7657), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7658) },
                    { 8L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7905), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7906) },
                    { 7L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7839), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7840) },
                    { 6L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7781), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7782) },
                    { 5L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7716), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7717) },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7593), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7594) },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7382), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7383) },
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 62, DateTimeKind.Local).AddTicks(8236), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 5, 1, 23, 57, 40, 62, DateTimeKind.Local).AddTicks(8337) },
                    { 19L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8564), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8565) },
                    { 9L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7962), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(7963) },
                    { 20L, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8621), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 5, 1, 23, 57, 40, 65, DateTimeKind.Local).AddTicks(8622) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "FirstActiveSyllabusId", "SecondActiveSyylabusId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(5181), "BM310", 1L, 0L, 0L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(5185) },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(5444), "BM311", 1L, 0L, 0L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(5445) },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(5479), "BM312", 1L, 0L, 0L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(5479) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1851), 3, 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1852) },
                    { 36L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1837), 2, 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1838) },
                    { 35L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1823), 1, 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1824) },
                    { 34L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1809), 3, 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1810) },
                    { 33L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1794), 2, 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1795) },
                    { 32L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1779), 1, 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1780) },
                    { 31L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1765), 3, 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1765) },
                    { 29L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1737), 1, 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1737) },
                    { 38L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1865), 1, 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1866) },
                    { 28L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1723), 3, 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1723) },
                    { 27L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1709), 2, 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1710) },
                    { 26L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1695), 1, 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1695) },
                    { 25L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1680), 3, 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1680) },
                    { 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1666), 2, 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1666) },
                    { 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1651), 1, 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1652) },
                    { 30L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1751), 2, 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1751) },
                    { 39L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1879), 2, 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1880) },
                    { 41L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1907), 1, 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1908) },
                    { 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1637), 2, 12L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1637) },
                    { 58L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2190), 3, 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2191) },
                    { 57L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2175), 2, 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2176) },
                    { 56L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2161), 1, 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2162) },
                    { 55L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2147), 3, 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2148) },
                    { 54L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2134), 2, 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2134) },
                    { 53L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2120), 1, 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2120) },
                    { 52L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2106), 3, 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2106) },
                    { 40L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1893), 3, 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1894) },
                    { 51L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2092), 2, 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2093) },
                    { 49L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2057), 3, 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2058) },
                    { 48L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2043), 2, 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2044) },
                    { 47L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2029), 1, 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2030) },
                    { 46L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2015), 3, 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2016) },
                    { 45L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2001), 2, 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2001) },
                    { 44L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1986), 1, 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1987) },
                    { 43L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1971), 3, 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1972) },
                    { 50L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2078), 1, 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(2079) },
                    { 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1622), 1, 12L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1623) },
                    { 42L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1921), 2, 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1922) },
                    { 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1576), 1, 11L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1576) },
                    { 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1590), 2, 11L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1591) },
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(421), 1, 1L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(437) },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1296), 2, 1L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1297) },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1335), 1, 2L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1335) },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1350), 2, 2L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1351) },
                    { 6L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1385), 2, 3L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1386) },
                    { 7L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1401), 1, 4L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1402) },
                    { 8L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1417), 1, 5L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1417) },
                    { 9L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1431), 1, 6L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1432) },
                    { 5L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1365), 1, 3L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1366) },
                    { 11L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1461), 1, 7L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1461) },
                    { 10L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1446), 2, 6L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1447) },
                    { 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1546), 1, 10L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1546) },
                    { 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1531), 2, 9L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1532) },
                    { 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1517), 1, 9L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1518) },
                    { 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1561), 2, 10L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1562) },
                    { 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1489), 1, 8L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1489) },
                    { 12L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1475), 2, 7L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1475) },
                    { 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1503), 2, 8L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(1504) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4143), 1L, "1007", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4144) },
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(3361), 1L, "1000", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(3365) },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4042), 1L, "1001", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4042) },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4063), 1L, "1002", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4063) },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4077), 1L, "1003", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4077) },
                    { 5L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4091), 1L, "1004", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4091) },
                    { 6L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4108), 1L, "1005", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4108) },
                    { 7L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4121), 1L, "1006", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4122) },
                    { 9L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4158), 1L, "1008", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4159) },
                    { 14L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4228), 1L, "10013", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4229) },
                    { 11L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4187), 1L, "10010", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4187) },
                    { 12L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4200), 1L, "10011", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4201) },
                    { 13L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4214), 1L, "10012", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4215) },
                    { 15L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4242), 1L, "10014", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4242) },
                    { 16L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4255), 1L, "10015", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4256) },
                    { 17L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4269), 1L, "10016", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4269) },
                    { 10L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4173), 1L, "1009", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4173) },
                    { 18L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4283), 1L, "10017", new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(4284) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5874), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5875), 7L, 14 },
                    { 16L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6035), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6036), 17L, 16 },
                    { 7L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5889), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5889), 8L, 8 },
                    { 15L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6020), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6021), 16L, 12 },
                    { 8L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5917), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5918), 9L, 10 },
                    { 10L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5947), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5948), 11L, 12 },
                    { 9L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5931), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5932), 10L, 12 },
                    { 13L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5991), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5992), 14L, 16 },
                    { 11L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5962), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5962), 12L, 12 },
                    { 5L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5853), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5854), 6L, 12 },
                    { 14L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6006), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6007), 15L, 16 },
                    { 17L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6049), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6050), 18L, 9 },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5775), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5776), 3L, 6 },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5838), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5839), 5L, 10 },
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(4804), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(4807), 2L, 4 },
                    { 19L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6079), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6080), 20L, 16 },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5822), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5822), 4L, 8 },
                    { 18L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6065), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(6065), 19L, 16 },
                    { 12L, new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5977), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 5, 1, 23, 57, 40, 66, DateTimeKind.Local).AddTicks(5978), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5365), 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5365), 17L },
                    { 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5055), 8L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5055), 13L },
                    { 28L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5202), 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5202), 13L },
                    { 29L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5215), 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5215), 13L },
                    { 9L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4927), 3L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4928), 13L },
                    { 30L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5228), 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5229), 13L },
                    { 42L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5391), 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5392), 17L },
                    { 10L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4942), 4L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4943), 14L },
                    { 49L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5491), 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5492), 20L },
                    { 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5104), 9L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5105), 14L },
                    { 31L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5242), 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5242), 14L },
                    { 32L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5255), 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5256), 14L },
                    { 45L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5431), 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5432), 18L },
                    { 33L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5269), 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5269), 14L },
                    { 48L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5478), 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5478), 19L },
                    { 43L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5405), 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5405), 18L },
                    { 35L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5297), 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5298), 15L },
                    { 36L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5311), 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5311), 15L },
                    { 47L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5458), 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5459), 19L },
                    { 61L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5801), 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5802), 15L },
                    { 46L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5445), 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5445), 19L },
                    { 37L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5324), 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5324), 16L },
                    { 44L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5418), 18L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5419), 18L },
                    { 38L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5338), 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5338), 16L },
                    { 39L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5351), 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5352), 16L },
                    { 41L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5378), 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5379), 17L },
                    { 34L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5283), 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5284), 15L },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4856), 2L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4857), 2L },
                    { 27L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5188), 12L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5189), 12L },
                    { 11L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4956), 5L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4957), 7L },
                    { 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5146), 11L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5147), 6L },
                    { 57L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5710), 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5711), 5L },
                    { 17L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5040), 8L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5041), 5L },
                    { 8L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4914), 3L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4914), 5L },
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4106), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4108), 5L },
                    { 25L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5161), 11L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5162), 7L },
                    { 56L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5688), 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5689), 4L },
                    { 12L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4970), 6L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4970), 4L },
                    { 55L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5656), 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5658), 3L },
                    { 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5132), 10L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5132), 3L },
                    { 7L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4899), 3L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4900), 3L },
                    { 22L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5118), 10L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5119), 2L },
                    { 50L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5505), 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5505), 20L },
                    { 26L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5174), 12L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5175), 4L },
                    { 60L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5788), 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5789), 12L },
                    { 63L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5830), 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5830), 7L },
                    { 19L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5068), 9L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5069), 8L },
                    { 15L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5013), 7L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5013), 12L },
                    { 6L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4885), 2L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4886), 12L },
                    { 59L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5772), 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5772), 11L },
                    { 14L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4999), 7L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5000), 11L },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4842), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4842), 11L },
                    { 58L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5739), 23L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5741), 10L },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4819), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4820), 8L },
                    { 54L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5560), 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5561), 10L },
                    { 13L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4985), 6L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4986), 10L },
                    { 62L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5815), 24L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5815), 9L },
                    { 53L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5547), 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5548), 9L },
                    { 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5091), 9L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5091), 9L },
                    { 5L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4870), 2L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(4870), 9L },
                    { 52L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5531), 21L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5532), 8L },
                    { 16L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5026), 7L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5027), 10L },
                    { 51L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5518), 20L, new DateTime(2019, 5, 1, 23, 57, 40, 71, DateTimeKind.Local).AddTicks(5518), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Department",
                table: "DepartmentInstructor",
                columns: new[] { "DepartmentInstructorId", "CreatedDate", "DepartmentId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(7716), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(7718), 2L },
                    { 19L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8680), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8681), 20L },
                    { 18L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8667), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8667), 19L },
                    { 17L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8652), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8653), 18L },
                    { 16L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8639), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8640), 17L },
                    { 14L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8612), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8613), 15L },
                    { 13L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8599), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8599), 14L },
                    { 12L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8585), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8586), 13L },
                    { 11L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8571), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8572), 12L },
                    { 15L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8626), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8627), 16L },
                    { 9L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8544), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8544), 10L },
                    { 8L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8530), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8531), 9L },
                    { 7L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8517), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8517), 8L },
                    { 6L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8503), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8504), 7L },
                    { 5L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8486), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8486), 6L },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8472), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8473), 5L },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8458), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8458), 4L },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8437), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8437), 3L },
                    { 10L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8558), 1L, new DateTime(2019, 5, 1, 23, 57, 40, 72, DateTimeKind.Local).AddTicks(8559), 11L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 14L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1226), 1L, 14L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1227) },
                    { 15L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1240), 1L, 15L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1241) },
                    { 16L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1254), 1L, 16L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1254) },
                    { 17L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1267), 1L, 17L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1268) },
                    { 22L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1337), 1L, 22L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1337) },
                    { 19L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1296), 1L, 19L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1296) },
                    { 20L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1309), 1L, 20L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1310) },
                    { 21L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1323), 1L, 21L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1324) },
                    { 13L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1212), 1L, 13L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1213) },
                    { 18L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1282), 1L, 18L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1283) },
                    { 12L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1198), 1L, 12L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1199) },
                    { 3L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1056), 1L, 3L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1056) },
                    { 10L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1169), 1L, 10L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1170) },
                    { 9L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1154), 1L, 9L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1155) },
                    { 8L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1139), 1L, 8L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1140) },
                    { 7L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1116), 1L, 7L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1116) },
                    { 6L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1101), 1L, 6L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1102) },
                    { 5L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1084), 1L, 5L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1084) },
                    { 4L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1070), 1L, 4L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1070) },
                    { 23L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1350), 1L, 23L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1351) },
                    { 2L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1035), 1L, 2L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1036) },
                    { 1L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(287), 1L, 1L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(288) },
                    { 11L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1184), 1L, 11L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1185) },
                    { 24L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1364), 1L, 24L, new DateTime(2019, 5, 1, 23, 57, 40, 73, DateTimeKind.Local).AddTicks(1365) }
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
