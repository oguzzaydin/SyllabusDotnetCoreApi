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
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6495), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6497) },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6705), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6705) },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6724), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6725) },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6740), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(6740) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 24L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(5021), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 7", 7, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(5022), 3 },
                    { 23L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4992), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 6", 7, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4993), 3 },
                    { 22L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4965), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 5", 7, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4966), 3 },
                    { 21L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4941), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 4", 7, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4942), 3 },
                    { 19L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4887), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 2", 7, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4889), 3 },
                    { 18L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4861), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 1", 7, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4862), 3 },
                    { 17L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4822), 3, "BSM 305", 1, "VERİ İLETİŞİMİ", 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4823), 3 },
                    { 16L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4796), 3, "BSM 301", 1, "İŞLETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4797), 3 },
                    { 15L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4771), 3, "BSM 301", 1, "İŞARETLER VE SİSTEMLER", 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4771), 3 },
                    { 14L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4746), 3, "BSM 301", 1, "VERİTABANI YÖNETİM SİSTEMLERİ", 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4747), 3 },
                    { 13L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4721), 3, "BSM 301", 1, "BİÇİMSEL DİLLER VE SOYUT MAKİNELER", 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4722), 3 },
                    { 20L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4916), 3, "BSM 305", 1, "BF-TEKNİK SEÇMELİ 3", 7, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4917), 3 },
                    { 11L, 6, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4674), 4, "BSM 205", 1, "WEB PROGRAMLAMA", 3, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4675), 4 },
                    { 12L, 6, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4699), 3, "BSM 207", 1, "VERİ YAPILARI", 3, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4700), 3 },
                    { 1L, 4, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(1899), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(1902), 4 },
                    { 3L, 6, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4339), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4339), 4 },
                    { 4L, 4, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4460), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4461), 2 },
                    { 5L, 4, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4484), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4485), 2 },
                    { 2L, 6, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4304), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4304), 5 },
                    { 7L, 4, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4570), 4, "ATA 203", 1, "ATATÜRK İLKELERİ VE İNKILÂP TARİHİ", 3, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4571), 4 },
                    { 8L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4598), 3, "MAT 217", 1, "SAYISAL ANALİZ", 3, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4598), 3 },
                    { 9L, 2, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4623), 4, "BSM 201", 1, "ELEKTRİK DEVRE TEMELLERİ", 3, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4624), 2 },
                    { 10L, 5, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4653), 3, "BSM 203", 1, "MANTIK DEVRELERİ", 3, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4653), 3 },
                    { 6L, 6, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4535), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(4536), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 18L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8873), "can@sakarya.edu.tr", "EXGEOz4WKbTsMDfSGACQ+BMH8rn0apVYZToUR7ss0cO8f5pWAyNfQ9cL9xKS4QCxZbGiRNw0CgpBGYp0/X4R3w==", "Can", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yüzkollar", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8874) },
                    { 11L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8454), "nyurtay@sakarya.edu.tr", "NFTi/cFJcT8h5yY0UpJhltsU2mCwgK4AbYymzvky8XZUlI4gWEndM0RjrosrUbUz8o+hMw5ro8LtJU4SEVpkhw==", "Nilüfer", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 2, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8455) },
                    { 17L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8814), "serapkazan@sakarya.edu.tr", "lR3oKyKmlc2NzfofOUDhBBK9FMmdypYK+n1uqN20NAdjUZ6urMyOGkLHI3rwVAnaqwcJaffNAg2zVwHlFCcpcg==", "Serap", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kazan", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8815) },
                    { 16L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8754), "seckinari@sakarya.edu.tr", "l9n3z3IBAdDyyP83xaiA5WHji4oLBlYuM/nipDiyLhkUfazHBxBX9MvDA29MW1CK0JQf5hR0HYhufeJXo17pjQ==", "Seçkin", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arı", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8755) },
                    { 15L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8691), "miskef@sakarya.edu.tr", "vLCeezqHONz59p1gP4UHHPBf1n/dTJ5TsnFeHwb8RS97W1RXU7tY8sTuQyLJi9le46cdr+jAfSt+YxgZPe4sXA==", "Murat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "İskefiyeli", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8692) },
                    { 14L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8634), "fatihadak@sakarya.edu.tr", "s8y7jzkFKBdBHPF4zHiZNqvC4E2FTVgi8zzS8xjngz+YSLrCGTKVtONFuQg8YbUeu/k29J7g1wZHAvs8wkoMTg==", "Fatih", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Adak", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8635) },
                    { 13L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8576), "agulbag@sakarya.edu.tr", "7d6nE7p6rStHH9LOq4yrXjjLusimmnkfMFSlRV8uBoG3soo8K6hn8kOftt8Q62zoi2Iq4yWjKjhYXev9Naknvg==", "Ali", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Gülbağ", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8577) },
                    { 12L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8517), "asevin@sakarya.edu.tr", "ReTE23hComkIuWFJGqzBYbGSqqsJlxcU4fvErusBB5GwGSl3/so1Nx66eFjHOdMUk+/O10DJD0AxzcaOOlpSBg==", "Abdullah", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Sevin", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8518) },
                    { 10L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8397), "ozcelik@sakarya.edu.tr", "dbENn/dSsI2wTmNjY7XAhEjEErYcawAQhvQ4bBgz3Oydl5ZPb6RI+OL2Hh+Pp12jmxRJrwrPhPQ5zfiZfqvAUw==", "İbrahim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özçelik", 2, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8398) },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8022), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8023) },
                    { 8L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8278), "cbayilmis@sakarya.edu.tr", "2ukaaiAPmD1WI5vB2DNF3G8cGG/4CF4jmenRh2mtUVlsFXNALB3wCBAAEJGlwCr6GirwZ8vF+t3bX6i1f08Fqw==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 2, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8281) },
                    { 7L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8220), "ahmet@ozmen.edu.tr", "+V9zQP4jWDZf88qz2NibIYxiCk699CtBwCHeNGtNruFmnORyQcnT3129v8qD3okWItlMLA9uwR0FnFyWM+DjLw==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 2, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8221) },
                    { 6L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8152), "ahmet@zengin.edu.tr", "GtKPNF7Fdjfz/eUK+hiMuAhkX9BARIjU6dsAlRiUyRTjRrVjqopGItYDR+ECwRBb2FGOxwjsgdYimPxpyUa2+w==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 2, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8153) },
                    { 5L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8086), "nejat@sakarya.edu.tr", "bJESMDXcVEU3ih1JAraPSj51liTleBkNlw/csh08wLspqXxUdwIBzsqof0ZbnowPzMO1JREc2nRSgMBcUuoaOQ==", "Nejat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yumuşak", 1, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8087) },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(7842), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(7844) },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(7611), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(7612) },
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 402, DateTimeKind.Local).AddTicks(7347), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 28, 19, 29, 24, 402, DateTimeKind.Local).AddTicks(7370) },
                    { 19L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8947), "yyurtay@sakarya.edu.tr", "oZKgqT6IcnJF3rx47Yjd5+y13jStgAE2qV9t1K/XFDj28JLIW2D8AGZBt32rH3LAt/2u4lC0pc7EZSnL/qSXHw==", "Yüksel", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Yurtay", 4, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8948) },
                    { 9L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8338), "dakgun@sakarya.edu.tr", "6uTll1SCuCHE/i+eNw91QJSZO05/0tyszKxNymGKVBBXI2c0/jFIwhLIxMHmaz/H+HhM3KNq02cGhxYc1LpvLg==", "Devrim", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Akgün", 2, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(8339) },
                    { 20L, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(9006), "ntasbasi@sakarya.edu.tr", "3VzecPpKVC9mfl7UFdtJKD6Hqh1/HQ4t+4J2+PYSwO1ICdytzRdnkp7g1QdzbkTfxs48DVdM8WwAxxydlqnYsw==", "Nevzat", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Taşbaşı", 5, new DateTime(2019, 4, 28, 19, 29, 24, 404, DateTimeKind.Local).AddTicks(9007) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "FirstActiveSyllabusId", "SecondActiveSyylabusId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(3553), "BM310", 1L, 0L, 0L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(3560) },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(3922), "BM311", 1L, 0L, 0L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(3923) },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(3945), "BM312", 1L, 0L, 0L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(3946) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 37L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8587), 3, 17L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8587) },
                    { 36L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8379), 2, 17L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8380) },
                    { 35L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8364), 1, 17L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8366) },
                    { 34L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8345), 3, 16L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8346) },
                    { 33L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8299), 2, 16L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8300) },
                    { 32L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8276), 1, 16L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8277) },
                    { 31L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8241), 3, 15L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8241) },
                    { 29L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8196), 1, 15L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8197) },
                    { 38L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8602), 1, 18L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8603) },
                    { 28L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8174), 3, 14L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8175) },
                    { 27L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8151), 2, 14L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8152) },
                    { 26L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8129), 1, 14L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8130) },
                    { 25L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8107), 3, 13L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8108) },
                    { 24L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8085), 2, 13L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8086) },
                    { 23L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8063), 1, 13L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8064) },
                    { 30L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8220), 2, 15L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8220) },
                    { 39L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8616), 2, 18L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8617) },
                    { 41L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8644), 1, 19L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8645) },
                    { 22L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8041), 2, 12L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8042) },
                    { 58L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8922), 3, 24L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8923) },
                    { 57L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8908), 2, 24L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8909) },
                    { 56L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8894), 1, 24L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8895) },
                    { 55L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8879), 3, 23L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8880) },
                    { 54L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8865), 2, 23L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8866) },
                    { 53L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8851), 1, 23L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8852) },
                    { 52L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8837), 3, 22L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8838) },
                    { 40L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8630), 3, 18L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8631) },
                    { 51L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8823), 2, 22L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8824) },
                    { 49L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8795), 3, 21L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8796) },
                    { 48L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8781), 2, 21L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8781) },
                    { 47L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8766), 1, 21L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8767) },
                    { 46L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8751), 3, 20L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8752) },
                    { 45L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8737), 2, 20L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8738) },
                    { 44L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8722), 1, 20L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8723) },
                    { 43L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8707), 3, 19L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8708) },
                    { 50L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8809), 1, 22L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8810) },
                    { 21L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8020), 1, 12L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8020) },
                    { 42L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8658), 2, 19L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(8659) },
                    { 19L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7976), 1, 11L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7976) },
                    { 20L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7998), 2, 11L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7999) },
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7349), 1, 1L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7351) },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7537), 2, 1L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7538) },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7556), 1, 2L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7557) },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7571), 2, 2L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7572) },
                    { 6L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7602), 2, 3L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7602) },
                    { 7L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7616), 1, 4L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7616) },
                    { 8L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7630), 1, 5L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7630) },
                    { 9L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7643), 1, 6L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7644) },
                    { 5L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7585), 1, 3L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7586) },
                    { 11L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7673), 1, 7L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7676) },
                    { 10L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7659), 2, 6L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7660) },
                    { 17L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7838), 1, 10L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7839) },
                    { 16L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7816), 2, 9L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7817) },
                    { 15L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7782), 1, 9L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7783) },
                    { 18L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7950), 2, 10L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7953) },
                    { 13L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7704), 1, 8L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7705) },
                    { 12L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7690), 2, 7L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7691) },
                    { 14L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7725), 2, 8L, new DateTime(2019, 4, 28, 19, 29, 24, 406, DateTimeKind.Local).AddTicks(7727) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4883), 1L, "1007", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4884) },
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4136), 1L, "1000", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4138) },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4785), 1L, "1001", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4786) },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4805), 1L, "1002", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4805) },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4826), 1L, "1003", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4826) },
                    { 5L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4840), 1L, "1004", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4841) },
                    { 6L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4856), 1L, "1005", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4857) },
                    { 7L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4870), 1L, "1006", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4870) },
                    { 9L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4896), 1L, "1008", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4897) },
                    { 14L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4964), 1L, "10013", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4964) },
                    { 11L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4925), 1L, "10010", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4925) },
                    { 12L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4938), 1L, "10011", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4938) },
                    { 13L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4951), 1L, "10012", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4951) },
                    { 15L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4977), 1L, "10014", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4977) },
                    { 16L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4990), 1L, "10015", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4990) },
                    { 17L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(5003), 1L, "10016", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(5003) },
                    { 10L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4911), 1L, "1009", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(4912) },
                    { 18L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(5017), 1L, "10017", new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(5018) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "EndTime", "IsActive", "IsFreeDay", "StartTime", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 6L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5519), "Description", 3, 18, true, false, 9, "Kısıt 6", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5520), 7L, 14 },
                    { 16L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5659), "Description", 3, 18, true, true, 10, "Kısıt 16", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5660), 17L, 16 },
                    { 7L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5533), "Description", 2, 22, true, true, 17, "Kısıt 7", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5534), 8L, 8 },
                    { 15L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5645), "Description", 1, 15, true, false, 10, "Kısıt 15", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5646), 16L, 12 },
                    { 8L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5547), "Description", 1, 15, true, true, 11, "Kısıt 8", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5548), 9L, 10 },
                    { 10L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5576), "Description", 1, 18, true, true, 11, "Kısıt 10", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5577), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5561), "Description", 3, 18, true, false, 11, "Kısıt 9", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5561), 10L, 12 },
                    { 13L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5618), "Description", 3, 22, true, false, 12, "Kısıt 13", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5619), 14L, 16 },
                    { 11L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5591), "Description", 2, 20, true, true, 16, "Kısıt 11", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5592), 12L, 12 },
                    { 5L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5502), "Description", 1, 15, true, true, 13, "Kısıt 5", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5503), 6L, 12 },
                    { 14L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5632), "Description", 2, 22, true, true, 18, "Kısıt 14", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5632), 15L, 16 },
                    { 17L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5672), "Description", 1, 15, true, false, 15, "Kısıt 17", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5673), 18L, 9 },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5437), "Description", 2, 20, true, true, 15, "Kısıt 2", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5438), 3L, 6 },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5488), "Description", 2, 23, true, true, 18, "Kısıt 4", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5489), 5L, 10 },
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(4726), "Description", 1, 15, true, true, 10, "Kısıt 1", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(4728), 2L, 4 },
                    { 19L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5701), "Description", 1, 15, true, true, 13, "Kısıt 19", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5701), 20L, 16 },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5474), "Description", 3, 20, true, false, 9, "Kısıt 3", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5474), 4L, 8 },
                    { 18L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5687), "Description", 2, 22, true, false, 18, "Kısıt 18", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5688), 19L, 16 },
                    { 12L, new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5605), "Description", 3, 20, true, false, 12, "Kısıt 12", new DateTime(2019, 4, 28, 19, 29, 24, 405, DateTimeKind.Local).AddTicks(5605), 13L, 16 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 40L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2108), 17L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2109), 17L },
                    { 18L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1808), 8L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1809), 13L },
                    { 28L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1944), 13L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1945), 13L },
                    { 29L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1958), 13L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1958), 13L },
                    { 9L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1670), 3L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1671), 13L },
                    { 30L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1971), 13L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1972), 13L },
                    { 42L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2142), 17L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2142), 17L },
                    { 10L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1685), 4L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1686), 14L },
                    { 49L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2238), 20L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2239), 20L },
                    { 21L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1848), 9L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1849), 14L },
                    { 31L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1985), 14L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1985), 14L },
                    { 32L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1998), 14L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1999), 14L },
                    { 45L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2182), 18L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2183), 18L },
                    { 33L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2013), 14L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2014), 14L },
                    { 48L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2224), 19L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2224), 19L },
                    { 43L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2155), 18L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2156), 18L },
                    { 35L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2041), 15L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2042), 15L },
                    { 36L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2054), 15L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2055), 15L },
                    { 47L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2210), 19L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2211), 19L },
                    { 61L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2399), 24L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2400), 15L },
                    { 46L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2196), 19L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2197), 19L },
                    { 37L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2067), 16L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2068), 16L },
                    { 44L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2169), 18L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2169), 18L },
                    { 38L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2081), 16L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2081), 16L },
                    { 39L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2094), 16L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2095), 16L },
                    { 41L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2122), 17L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2122), 17L },
                    { 34L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2028), 15L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2028), 15L },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1598), 2L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1598), 2L },
                    { 27L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1931), 12L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1932), 12L },
                    { 11L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1700), 5L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1700), 7L },
                    { 24L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1890), 11L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1891), 6L },
                    { 57L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2346), 22L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2347), 5L },
                    { 17L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1792), 8L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1794), 5L },
                    { 8L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1656), 3L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1657), 5L },
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(929), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(931), 5L },
                    { 25L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1904), 11L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1905), 7L },
                    { 56L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2333), 22L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2333), 4L },
                    { 12L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1715), 6L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1716), 4L },
                    { 55L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2319), 22L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2320), 3L },
                    { 23L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1876), 10L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1876), 3L },
                    { 7L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1642), 3L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1643), 3L },
                    { 22L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1862), 10L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1862), 2L },
                    { 50L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2252), 20L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2252), 20L },
                    { 26L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1918), 12L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1919), 4L },
                    { 60L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2386), 23L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2387), 12L },
                    { 63L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2427), 24L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2428), 7L },
                    { 19L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1821), 9L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1822), 8L },
                    { 15L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1765), 7L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1765), 12L },
                    { 6L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1628), 2L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1629), 12L },
                    { 59L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2373), 23L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2373), 11L },
                    { 14L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1743), 7L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1744), 11L },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1583), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1584), 11L },
                    { 58L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2359), 23L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2360), 10L },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1561), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1561), 8L },
                    { 54L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2306), 21L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2307), 10L },
                    { 13L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1729), 6L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1730), 10L },
                    { 62L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2414), 24L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2414), 9L },
                    { 53L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2292), 21L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2293), 9L },
                    { 20L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1835), 9L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1836), 9L },
                    { 5L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1612), 2L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1612), 9L },
                    { 52L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2279), 21L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2280), 8L },
                    { 16L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1779), 7L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(1780), 10L },
                    { 51L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2265), 20L, new DateTime(2019, 4, 28, 19, 29, 24, 407, DateTimeKind.Local).AddTicks(2266), 20L }
                });

            migrationBuilder.InsertData(
                schema: "Department",
                table: "DepartmentInstructor",
                columns: new[] { "DepartmentInstructorId", "CreatedDate", "DepartmentId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(5734), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(5736), 2L },
                    { 19L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7301), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7302), 20L },
                    { 18L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7271), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7272), 19L },
                    { 17L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7244), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7245), 18L },
                    { 16L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7219), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7220), 17L },
                    { 14L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7054), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7055), 15L },
                    { 13L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7035), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7036), 14L },
                    { 12L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7014), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7015), 13L },
                    { 11L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6995), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6996), 12L },
                    { 15L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7202), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(7202), 16L },
                    { 9L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6953), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6954), 10L },
                    { 8L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6933), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6934), 9L },
                    { 7L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6913), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6914), 8L },
                    { 6L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6892), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6893), 7L },
                    { 5L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6867), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6868), 6L },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6848), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6848), 5L },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6811), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6813), 4L },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6767), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6768), 3L },
                    { 10L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6976), 1L, new DateTime(2019, 4, 28, 19, 29, 24, 408, DateTimeKind.Local).AddTicks(6976), 11L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 14L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1956), 1L, 14L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1957) },
                    { 15L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1969), 1L, 15L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1970) },
                    { 16L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1983), 1L, 16L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1984) },
                    { 17L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1997), 1L, 17L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1998) },
                    { 22L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2067), 1L, 22L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2067) },
                    { 19L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2026), 1L, 19L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2026) },
                    { 20L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2039), 1L, 20L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2040) },
                    { 21L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2053), 1L, 21L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2054) },
                    { 13L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1942), 1L, 13L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1943) },
                    { 18L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2012), 1L, 18L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2013) },
                    { 12L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1929), 1L, 12L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1929) },
                    { 3L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1795), 1L, 3L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1795) },
                    { 10L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1901), 1L, 10L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1901) },
                    { 9L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1885), 1L, 9L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1885) },
                    { 8L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1871), 1L, 8L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1871) },
                    { 7L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1856), 1L, 7L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1857) },
                    { 6L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1842), 1L, 6L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1843) },
                    { 5L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1825), 1L, 5L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1825) },
                    { 4L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1811), 1L, 4L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1811) },
                    { 23L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2080), 1L, 23L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2081) },
                    { 2L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1760), 1L, 2L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1761) },
                    { 1L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(905), 1L, 1L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(908) },
                    { 11L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1915), 1L, 11L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(1915) },
                    { 24L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2094), 1L, 24L, new DateTime(2019, 4, 28, 19, 29, 24, 409, DateTimeKind.Local).AddTicks(2095) }
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
