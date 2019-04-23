using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DPA.Database.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Faculty");

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
                    HeadOfDepartmentId = table.Column<long>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Department_User_HeadOfDepartmentId",
                        column: x => x.HeadOfDepartmentId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7464), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7466) },
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7724), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7725) },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7745), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7746) },
                    { 4L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7760), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(7760) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(194), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(195), 3 },
                    { 10L, 6, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(137), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(138), 4 },
                    { 9L, 6, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(110), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(110), 4 },
                    { 8L, 6, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(80), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(81), 5 },
                    { 7L, 4, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(41), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(42), 4 },
                    { 11L, 4, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(168), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(169), 3 },
                    { 5L, 4, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9962), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9962), 2 },
                    { 4L, 4, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9944), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9945), 2 },
                    { 3L, 6, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9926), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9927), 4 },
                    { 2L, 6, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9888), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9889), 5 },
                    { 1L, 4, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(8704), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(8710), 4 },
                    { 6L, 6, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9999), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(488), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(489) },
                    { 11L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(434), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(435) },
                    { 10L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(376), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(377) },
                    { 9L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(310), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(311) },
                    { 8L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(255), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(255) },
                    { 7L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(200), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(201) },
                    { 4L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(8), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(9) },
                    { 5L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(80), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(81) },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 371, DateTimeKind.Local).AddTicks(9948), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 23, 21, 39, 5, 371, DateTimeKind.Local).AddTicks(9949) },
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 371, DateTimeKind.Local).AddTicks(9748), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 23, 21, 39, 5, 371, DateTimeKind.Local).AddTicks(9749) },
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 370, DateTimeKind.Local).AddTicks(1280), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 23, 21, 39, 5, 370, DateTimeKind.Local).AddTicks(1300) },
                    { 13L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(543), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(543) },
                    { 6L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(145), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(146) },
                    { 14L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(597), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(598) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "HeadOfDepartmentId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(948), "BM311", 1L, null, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(949) },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(983), "BM312", 1L, null, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(984) },
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(182), "BM310", 1L, 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(183) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1644), 1, 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1645) },
                    { 6L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1660), 2, 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1661) },
                    { 7L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1675), 1, 4L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1675) },
                    { 8L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1689), 1, 5L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1689) },
                    { 9L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1703), 1, 6L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1703) },
                    { 10L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1718), 2, 6L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1719) },
                    { 11L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1732), 1, 7L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1733) },
                    { 12L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1746), 2, 7L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1747) },
                    { 14L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1774), 2, 8L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1775) },
                    { 4L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1629), 2, 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1630) },
                    { 15L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1788), 1, 9L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1789) },
                    { 16L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1803), 2, 9L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1804) },
                    { 17L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1817), 1, 10L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1817) },
                    { 18L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1832), 2, 10L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1832) },
                    { 19L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1854), 1, 11L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1855) },
                    { 20L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1869), 2, 11L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1870) },
                    { 22L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1897), 2, 12L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1898) },
                    { 13L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1760), 1, 8L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1761) },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1614), 1, 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1615) },
                    { 21L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1883), 1, 12L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1884) },
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1399), 1, 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1401) },
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1594), 2, 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(1594) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4791), 1L, "10016", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4791) },
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4053), 1L, "1000", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4057) },
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4549), 1L, "1001", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4550) },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4575), 1L, "1002", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4576) },
                    { 18L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4807), 1L, "10017", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4807) },
                    { 6L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4624), 1L, "1005", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4625) },
                    { 7L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4640), 1L, "1006", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4640) },
                    { 8L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4655), 1L, "1007", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4655) },
                    { 4L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4592), 1L, "1003", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4592) },
                    { 10L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4686), 1L, "1009", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4686) },
                    { 9L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4669), 1L, "1008", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4670) },
                    { 15L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4761), 1L, "10014", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4762) },
                    { 14L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4746), 1L, "10013", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4747) },
                    { 16L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4776), 1L, "10015", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4776) },
                    { 12L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4716), 1L, "10011", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4717) },
                    { 11L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4701), 1L, "10010", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4702) },
                    { 13L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4731), 1L, "10012", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4732) },
                    { 5L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4607), 1L, "1004", new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(4608) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4221), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4222), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4338), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4338), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4323), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4323), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4309), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4309), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4295), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4295), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4279), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4280), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4266), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4266), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4252), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4252), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4238), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4239), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4207), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4208), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4149), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4150), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(3434), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(3437), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4190), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 23, 21, 39, 5, 372, DateTimeKind.Local).AddTicks(4191), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3493), 4L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3494), 14L },
                    { 18L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3606), 8L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3607), 13L },
                    { 9L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3479), 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3479), 13L },
                    { 15L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3563), 7L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3564), 12L },
                    { 6L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3437), 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3437), 12L },
                    { 4L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3407), 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3407), 2L },
                    { 14L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3549), 7L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3550), 11L },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3393), 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3393), 11L },
                    { 22L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3662), 10L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3662), 2L },
                    { 16L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3577), 7L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3578), 10L },
                    { 13L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3535), 6L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3536), 10L },
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(2959), 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(2961), 5L },
                    { 20L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3634), 9L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3635), 9L },
                    { 5L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3421), 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3422), 9L },
                    { 7L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3451), 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3451), 3L },
                    { 19L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3620), 9L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3621), 8L },
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3368), 1L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3369), 8L },
                    { 23L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3675), 10L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3676), 3L },
                    { 25L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3712), 11L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3712), 7L },
                    { 11L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3507), 5L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3508), 7L },
                    { 24L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3689), 11L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3690), 6L },
                    { 12L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3521), 6L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3522), 4L },
                    { 17L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3591), 8L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3592), 5L },
                    { 8L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3465), 3L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3466), 5L },
                    { 26L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3727), 12L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3727), 4L },
                    { 21L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3648), 9L, new DateTime(2019, 4, 23, 21, 39, 5, 373, DateTimeKind.Local).AddTicks(3648), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(1955), 1L, 1L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(1956) },
                    { 2L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2356), 1L, 2L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2357) },
                    { 3L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2381), 1L, 3L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2382) },
                    { 4L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2395), 1L, 4L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2396) },
                    { 5L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2409), 1L, 5L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2410) },
                    { 6L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2426), 1L, 6L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2427) },
                    { 7L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2460), 1L, 7L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2460) },
                    { 8L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2474), 1L, 8L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2475) },
                    { 9L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2488), 1L, 9L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2489) },
                    { 10L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2503), 1L, 10L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2504) },
                    { 11L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2517), 1L, 11L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2518) },
                    { 12L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2531), 1L, 12L, new DateTime(2019, 4, 23, 21, 39, 5, 374, DateTimeKind.Local).AddTicks(2532) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                schema: "Faculty",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_HeadOfDepartmentId",
                schema: "Faculty",
                table: "Department",
                column: "HeadOfDepartmentId",
                unique: true,
                filter: "[HeadOfDepartmentId] IS NOT NULL");

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
                name: "Department",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "Faculty",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "User",
                schema: "User");
        }
    }
}
