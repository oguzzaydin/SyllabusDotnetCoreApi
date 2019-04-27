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
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3620), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3623) },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3933), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3934) },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3963), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3964) },
                    { 4L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3988), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(3989) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3529), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3530), 3 },
                    { 23L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3504), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3505), 3 },
                    { 22L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3479), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3480), 3 },
                    { 21L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3453), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3454), 3 },
                    { 19L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3405), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3406), 3 },
                    { 18L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3381), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3382), 3 },
                    { 17L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3354), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3355), 3 },
                    { 16L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3328), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3329), 3 },
                    { 15L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3295), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3296), 3 },
                    { 14L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3271), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3272), 3 },
                    { 13L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3246), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3246), 3 },
                    { 20L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3429), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3430), 3 },
                    { 11L, 6, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3194), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3195), 4 },
                    { 12L, 6, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3219), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3220), 3 },
                    { 1L, 4, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(1693), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(1695), 4 },
                    { 3L, 6, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(2984), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(2985), 4 },
                    { 4L, 4, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3011), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3012), 2 },
                    { 5L, 4, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3036), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3037), 2 },
                    { 2L, 6, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(2932), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(2933), 5 },
                    { 7L, 4, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3091), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3092), 4 },
                    { 8L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3116), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3117), 3 },
                    { 9L, 2, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3141), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3142), 2 },
                    { 10L, 5, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3169), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3170), 3 },
                    { 6L, 6, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3066), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(3067), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(776), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(777) },
                    { 11L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(7) },
                    { 17L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(518), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(519) },
                    { 16L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(433), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(434) },
                    { 15L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(343), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(344) },
                    { 14L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(260), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(261) },
                    { 13L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(177), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(178) },
                    { 12L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(91), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(92) },
                    { 10L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9912), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9913) },
                    { 4L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9374), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9375) },
                    { 8L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9737), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9739) },
                    { 7L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9652), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9653) },
                    { 6L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9564), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9565) },
                    { 5L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9459), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9460) },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9285), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9286) },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9065), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9067) },
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 48, DateTimeKind.Local).AddTicks(6146), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 27, 20, 42, 10, 48, DateTimeKind.Local).AddTicks(6170) },
                    { 19L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(1018), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(1019) },
                    { 9L, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9824), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 4, 27, 20, 42, 10, 50, DateTimeKind.Local).AddTicks(9825) },
                    { 20L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(1199), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(1200) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(7838), "BM310", 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(7840) },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(8104), "BM311", 1L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(8105) },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(8138), "BM312", 1L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(8138) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5824), 3, 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5825) },
                    { 36L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5802), 2, 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5802) },
                    { 35L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5779), 1, 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5780) },
                    { 34L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5756), 3, 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5757) },
                    { 33L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5732), 2, 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5733) },
                    { 32L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5709), 1, 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5710) },
                    { 31L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5687), 3, 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5688) },
                    { 29L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5642), 1, 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5643) },
                    { 38L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5852), 1, 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5853) },
                    { 28L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5620), 3, 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5621) },
                    { 27L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5598), 2, 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5599) },
                    { 26L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5576), 1, 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5577) },
                    { 25L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5554), 3, 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5555) },
                    { 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5531), 2, 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5532) },
                    { 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5509), 1, 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5510) },
                    { 30L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5664), 2, 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5665) },
                    { 39L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5876), 2, 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5876) },
                    { 41L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5921), 1, 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5922) },
                    { 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5485), 2, 12L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5486) },
                    { 58L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6319), 3, 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6319) },
                    { 57L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6296), 2, 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6297) },
                    { 56L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6274), 1, 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6275) },
                    { 55L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6252), 3, 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6253) },
                    { 54L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6230), 2, 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6231) },
                    { 53L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6208), 1, 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6208) },
                    { 52L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6186), 3, 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6187) },
                    { 40L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5898), 3, 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5899) },
                    { 51L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6163), 2, 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6164) },
                    { 49L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6119), 3, 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6120) },
                    { 48L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6096), 2, 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6097) },
                    { 47L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6073), 1, 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6074) },
                    { 46L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6051), 3, 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6052) },
                    { 45L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6029), 2, 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6029) },
                    { 44L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6006), 1, 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6007) },
                    { 43L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5983), 3, 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5984) },
                    { 50L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6141), 1, 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(6142) },
                    { 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5463), 1, 12L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5464) },
                    { 42L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5943), 2, 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5944) },
                    { 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5419), 1, 11L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5420) },
                    { 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5441), 2, 11L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5442) },
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(4828), 1, 1L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(4830) },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5017), 2, 1L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5018) },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5044), 1, 2L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5045) },
                    { 4L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5067), 2, 2L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5068) },
                    { 6L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5114), 2, 3L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5114) },
                    { 7L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5136), 1, 4L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5137) },
                    { 8L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5159), 1, 5L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5160) },
                    { 9L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5181), 1, 6L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5182) },
                    { 5L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5089), 1, 3L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5090) },
                    { 11L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5237), 1, 7L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5238) },
                    { 10L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5213), 2, 6L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5214) },
                    { 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5373), 1, 10L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5374) },
                    { 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5350), 2, 9L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5351) },
                    { 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5328), 1, 9L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5329) },
                    { 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5397), 2, 10L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5398) },
                    { 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5283), 1, 8L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5284) },
                    { 12L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5259), 2, 7L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5260) },
                    { 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5305), 2, 8L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(5306) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2747), 1L, "1007", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2747) },
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2114), 1L, "1000", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2116) },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2603), 1L, "1001", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2604) },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2635), 1L, "1002", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2636) },
                    { 4L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2657), 1L, "1003", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2658) },
                    { 5L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2679), 1L, "1004", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2680) },
                    { 6L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2704), 1L, "1005", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2705) },
                    { 7L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2726), 1L, "1006", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2727) },
                    { 9L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2768), 1L, "1008", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2769) },
                    { 14L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2887), 1L, "10013", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2888) },
                    { 11L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2812), 1L, "10010", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2813) },
                    { 12L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2833), 1L, "10011", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2834) },
                    { 13L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2855), 1L, "10012", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2856) },
                    { 15L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2909), 1L, "10014", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2910) },
                    { 16L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2930), 1L, "10015", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2931) },
                    { 17L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2951), 1L, "10016", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2952) },
                    { 10L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2790), 1L, "1009", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2791) },
                    { 18L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2974), 1L, "10017", new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(2975) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5883), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5884), 7L, 14 },
                    { 16L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6109), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6110), 17L, 16 },
                    { 7L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5905), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5906), 8L, 8 },
                    { 15L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6086), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6087), 16L, 12 },
                    { 8L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5928), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5929), 9L, 10 },
                    { 10L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5973), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5974), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5950), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5951), 10L, 12 },
                    { 13L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6041), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6042), 14L, 16 },
                    { 11L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5995), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5996), 12L, 12 },
                    { 5L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5858), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5859), 6L, 12 },
                    { 14L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6064), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6065), 15L, 16 },
                    { 17L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6130), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6131), 18L, 9 },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5754), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5755), 3L, 6 },
                    { 4L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5835), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5836), 5L, 10 },
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5226), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5229), 2L, 4 },
                    { 19L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6176), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6177), 20L, 16 },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5811), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(5812), 4L, 8 },
                    { 18L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6154), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6155), 19L, 16 },
                    { 12L, new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6018), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 4, 27, 20, 42, 10, 51, DateTimeKind.Local).AddTicks(6019), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8624), 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8625), 17L },
                    { 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8135), 8L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8136), 13L },
                    { 28L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8352), 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8353), 13L },
                    { 29L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8373), 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8374), 13L },
                    { 9L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7928), 3L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7929), 13L },
                    { 30L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8395), 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8396), 13L },
                    { 42L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8668), 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8669), 17L },
                    { 10L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7959), 4L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7960), 14L },
                    { 49L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8823), 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8824), 20L },
                    { 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8200), 9L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8201), 14L },
                    { 31L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8416), 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8417), 14L },
                    { 32L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8439), 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8440), 14L },
                    { 45L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8735), 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8736), 18L },
                    { 33L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8460), 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8461), 14L },
                    { 48L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8801), 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8802), 19L },
                    { 43L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8690), 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8691), 18L },
                    { 35L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8505), 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8506), 15L },
                    { 36L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8527), 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8528), 15L },
                    { 47L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8779), 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8780), 19L },
                    { 61L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9084), 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9085), 15L },
                    { 46L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8757), 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8758), 19L },
                    { 37L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8557), 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8558), 16L },
                    { 44L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8712), 18L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8713), 18L },
                    { 38L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8580), 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8580), 16L },
                    { 39L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8602), 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8603), 16L },
                    { 41L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8646), 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8647), 17L },
                    { 34L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8484), 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8485), 15L },
                    { 4L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7816), 2L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7817), 2L },
                    { 27L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8329), 12L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8330), 12L },
                    { 11L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7981), 5L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7982), 7L },
                    { 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8265), 11L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8266), 6L },
                    { 57L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8997), 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8997), 5L },
                    { 17L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8113), 8L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8113), 5L },
                    { 8L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7906), 3L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7907), 5L },
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7304), 1L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7306), 5L },
                    { 25L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8286), 11L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8287), 7L },
                    { 56L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8975), 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8976), 4L },
                    { 12L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8003), 6L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8004), 4L },
                    { 55L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8953), 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8954), 3L },
                    { 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8243), 10L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8244), 3L },
                    { 7L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7885), 3L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7886), 3L },
                    { 22L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8222), 10L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8223), 2L },
                    { 50L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8844), 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8845), 20L },
                    { 26L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8308), 12L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8309), 4L },
                    { 60L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9062), 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9063), 12L },
                    { 63L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9127), 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9128), 7L },
                    { 19L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8157), 9L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8158), 8L },
                    { 15L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8070), 7L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8071), 12L },
                    { 6L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7863), 2L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7863), 12L },
                    { 59L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9040), 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9041), 11L },
                    { 14L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8047), 7L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8048), 11L },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7794), 1L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7795), 11L },
                    { 58L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9018), 23L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9019), 10L },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7761), 1L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7762), 8L },
                    { 54L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8931), 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8932), 10L },
                    { 13L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8025), 6L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8026), 10L },
                    { 62L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9106), 24L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(9106), 9L },
                    { 53L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8910), 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8911), 9L },
                    { 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8179), 9L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8179), 9L },
                    { 5L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7839), 2L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(7840), 9L },
                    { 52L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8888), 21L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8889), 8L },
                    { 16L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8091), 7L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8092), 10L },
                    { 51L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8866), 20L, new DateTime(2019, 4, 27, 20, 42, 10, 52, DateTimeKind.Local).AddTicks(8867), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9209), 1L, 1L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9211) },
                    { 22L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(186), 1L, 22L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(187) },
                    { 21L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(164), 1L, 21L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(165) },
                    { 20L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(142), 1L, 20L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(143) },
                    { 19L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(120), 1L, 19L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(120) },
                    { 18L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(97), 1L, 18L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(98) },
                    { 17L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(56), 1L, 17L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(57) },
                    { 16L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(33), 1L, 16L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(34) },
                    { 15L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(11), 1L, 15L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(12) },
                    { 14L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9989), 1L, 14L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9990) },
                    { 13L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9966), 1L, 13L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9967) },
                    { 12L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9943), 1L, 12L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9944) },
                    { 11L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9920), 1L, 11L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9921) },
                    { 10L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9897), 1L, 10L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9898) },
                    { 9L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9872), 1L, 9L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9873) },
                    { 8L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9850), 1L, 8L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9851) },
                    { 7L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9826), 1L, 7L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9827) },
                    { 6L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9803), 1L, 6L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9804) },
                    { 5L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9775), 1L, 5L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9776) },
                    { 4L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9751), 1L, 4L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9753) },
                    { 3L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9727), 1L, 3L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9728) },
                    { 2L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9694), 1L, 2L, new DateTime(2019, 4, 27, 20, 42, 10, 53, DateTimeKind.Local).AddTicks(9695) },
                    { 23L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(209), 1L, 23L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(210) },
                    { 24L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(231), 1L, 24L, new DateTime(2019, 4, 27, 20, 42, 10, 54, DateTimeKind.Local).AddTicks(232) }
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
