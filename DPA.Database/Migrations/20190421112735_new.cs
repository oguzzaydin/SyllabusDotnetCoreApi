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
                        name: "FK_UnitLesson_Location_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Faculty",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitLesson_Syllabus_LessonId",
                        column: x => x.LessonId,
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
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9048), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9062) },
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9648), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9650) },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9707), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9709) },
                    { 4L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9757), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(9758) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(7128), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(7129), 3 },
                    { 10L, 6, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(7003), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(7005), 4 },
                    { 9L, 6, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6942), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6943), 4 },
                    { 8L, 6, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6908), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6908), 5 },
                    { 7L, 4, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6878), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6879), 4 },
                    { 11L, 4, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(7066), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(7067), 3 },
                    { 5L, 4, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6814), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6814), 2 },
                    { 4L, 4, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6784), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6785), 2 },
                    { 3L, 6, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6749), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6751), 4 },
                    { 2L, 6, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6648), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6650), 5 },
                    { 1L, 4, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(4677), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(4682), 4 },
                    { 6L, 6, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6849), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(6850), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9203), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9204) },
                    { 11L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9035), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9036) },
                    { 10L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8883), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8884) },
                    { 9L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8730), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8732) },
                    { 8L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8615), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8617) },
                    { 7L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8507), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8509) },
                    { 4L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8083), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8084) },
                    { 5L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8214), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8215) },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(7954), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(7956) },
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(7557), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(7560) },
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 52, DateTimeKind.Local).AddTicks(8174), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 21, 14, 27, 34, 52, DateTimeKind.Local).AddTicks(8207) },
                    { 13L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9341), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9343) },
                    { 6L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8362), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(8365) },
                    { 14L, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9440), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 21, 14, 27, 34, 55, DateTimeKind.Local).AddTicks(9442) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "HeadOfDepartmentId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(5731), "BM311", 1L, null, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(5732) },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(5779), "BM312", 1L, null, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(5780) },
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(4507), "BM310", 1L, 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(4514) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9495), 1, 3L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9496) },
                    { 6L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9520), 2, 3L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9521) },
                    { 7L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9543), 1, 4L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9544) },
                    { 8L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9571), 1, 5L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9572) },
                    { 9L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9612), 1, 6L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9612) },
                    { 10L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9647), 2, 6L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9649) },
                    { 11L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9692), 1, 7L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9692) },
                    { 12L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9714), 2, 7L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9716) },
                    { 14L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9799), 2, 8L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9800) },
                    { 4L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9472), 2, 2L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9473) },
                    { 15L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9852), 1, 9L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9853) },
                    { 16L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9904), 2, 9L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9905) },
                    { 17L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9941), 1, 10L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9942) },
                    { 18L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9966), 2, 10L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9967) },
                    { 19L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9988), 1, 11L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9989) },
                    { 20L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(34), 2, 11L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(35) },
                    { 22L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(202), 2, 12L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(203) },
                    { 13L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9746), 1, 8L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9748) },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9429), 1, 2L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9430) },
                    { 21L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(169), 1, 12L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(170) },
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9045), 1, 1L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9048) },
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9397), 2, 1L, new DateTime(2019, 4, 21, 14, 27, 34, 57, DateTimeKind.Local).AddTicks(9398) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2297), 1L, "10016", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2298) },
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(830), 1L, "1000", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(832) },
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1594), 1L, "1001", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1596) },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1669), 1L, "1002", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1670) },
                    { 18L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2333), 1L, "10017", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2334) },
                    { 6L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1846), 1L, "1005", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1847) },
                    { 7L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1877), 1L, "1006", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1878) },
                    { 8L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1924), 1L, "1007", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1925) },
                    { 4L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1725), 1L, "1003", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1727) },
                    { 10L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1985), 1L, "1009", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1986) },
                    { 9L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1951), 1L, "1008", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1952) },
                    { 15L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2182), 1L, "10014", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2183) },
                    { 14L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2123), 1L, "10013", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2125) },
                    { 16L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2239), 1L, "10015", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2240) },
                    { 12L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2063), 1L, "10011", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2064) },
                    { 11L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2021), 1L, "10010", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2023) },
                    { 13L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2096), 1L, "10012", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(2097) },
                    { 5L, new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1784), 1L, "1004", new DateTime(2019, 4, 21, 14, 27, 34, 60, DateTimeKind.Local).AddTicks(1786) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7902), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7903), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8104), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8105), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8081), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8082), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8043), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8044), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8022), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8023), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7999), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(8000), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7979), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7980), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7960), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7961), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7939), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7940), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7880), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7881), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7803), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7804), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(6841), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(6858), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7855), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 21, 14, 27, 34, 56, DateTimeKind.Local).AddTicks(7856), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2745), 4L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2746), 14L },
                    { 18L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3159), 8L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3160), 13L },
                    { 9L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2715), 3L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2716), 13L },
                    { 15L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3003), 7L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3004), 12L },
                    { 6L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2604), 2L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2605), 12L },
                    { 4L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2544), 2L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2545), 2L },
                    { 14L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2951), 7L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2953), 11L },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2511), 1L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2512), 11L },
                    { 22L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3357), 10L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3358), 2L },
                    { 16L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3055), 7L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3057), 10L },
                    { 13L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2900), 6L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2902), 10L },
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(1647), 1L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(1650), 5L },
                    { 20L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3257), 9L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3258), 9L },
                    { 5L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2567), 2L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2567), 9L },
                    { 7L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2650), 3L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2650), 3L },
                    { 19L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3208), 9L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3210), 8L },
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2468), 1L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2469), 8L },
                    { 23L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3397), 10L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3398), 3L },
                    { 25L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3458), 11L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3458), 7L },
                    { 11L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2799), 5L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2801), 7L },
                    { 24L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3427), 11L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3428), 6L },
                    { 12L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2850), 6L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2851), 4L },
                    { 17L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3106), 8L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3107), 5L },
                    { 8L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2693), 3L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(2693), 5L },
                    { 26L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3480), 12L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3481), 4L },
                    { 21L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3306), 9L, new DateTime(2019, 4, 21, 14, 27, 34, 58, DateTimeKind.Local).AddTicks(3308), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(7200), 1L, 1L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(7203) },
                    { 2L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8274), 1L, 2L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8275) },
                    { 3L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8312), 1L, 3L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8313) },
                    { 4L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8340), 1L, 4L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8341) },
                    { 5L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8372), 1L, 5L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8373) },
                    { 6L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8431), 1L, 6L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8433) },
                    { 7L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8538), 1L, 7L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8540) },
                    { 8L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8587), 1L, 8L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8589) },
                    { 9L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8636), 1L, 9L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8637) },
                    { 10L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8665), 1L, 10L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8666) },
                    { 11L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8688), 1L, 11L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8689) },
                    { 12L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8711), 1L, 12L, new DateTime(2019, 4, 21, 14, 27, 34, 59, DateTimeKind.Local).AddTicks(8712) }
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
                name: "IX_UnitLesson_UserId",
                schema: "Syllabus",
                table: "UnitLesson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Constraint_UserId",
                schema: "User",
                table: "Constraint",
                column: "UserId");

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
