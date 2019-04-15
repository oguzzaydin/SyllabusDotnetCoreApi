using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DPA.Database.Migrations
{
    public partial class initialdb : Migration
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
                    SyllabusId = table.Column<long>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Time",
                schema: "Syllabus",
                columns: table => new
                {
                    TimeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    DayOfTheWeekType = table.Column<int>(nullable: false),
                    StarTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    UnitLessonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.TimeId);
                    table.ForeignKey(
                        name: "FK_Time_UnitLesson_UnitLessonId",
                        column: x => x.UnitLessonId,
                        principalSchema: "Syllabus",
                        principalTable: "UnitLesson",
                        principalColumn: "UnitLessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Faculty",
                columns: new[] { "FacultyId", "CreatedDate", "FacultyCode", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2744), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2746) },
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2918), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2919) },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2938), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2938) },
                    { 4L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2952), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(2953) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6603), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6603), 3 },
                    { 10L, 6, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6569), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6570), 4 },
                    { 9L, 6, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6551), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6552), 4 },
                    { 8L, 6, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6535), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6535), 5 },
                    { 7L, 4, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6518), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6519), 4 },
                    { 11L, 4, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6586), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6587), 3 },
                    { 5L, 4, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6483), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6483), 2 },
                    { 4L, 4, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6467), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6467), 2 },
                    { 3L, 6, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6449), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6449), 4 },
                    { 2L, 6, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6416), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6416), 5 },
                    { 1L, 4, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(5590), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(5592), 4 },
                    { 6L, 6, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6502), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(6503), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8158), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8159) },
                    { 11L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8099), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8100) },
                    { 10L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8045), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8046) },
                    { 9L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7988), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7989) },
                    { 8L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7933), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7934) },
                    { 7L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7871), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7871) },
                    { 4L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7696), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7697) },
                    { 5L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7753), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7754) },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7636), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7637) },
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7451), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7452) },
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 985, DateTimeKind.Local).AddTicks(8862), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 15, 22, 7, 12, 985, DateTimeKind.Local).AddTicks(8881) },
                    { 13L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8214), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8215) },
                    { 6L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7815), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(7816) },
                    { 14L, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8267), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 15, 22, 7, 12, 987, DateTimeKind.Local).AddTicks(8268) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "HeadOfDepartmentId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(6144), "BM311", 1L, null, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(6145) },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(6166), "BM312", 1L, null, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(6167) },
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(5341), "BM310", 1L, 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(5343) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7766), 1, 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7767) },
                    { 6L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7783), 2, 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7783) },
                    { 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7796), 1, 4L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7797) },
                    { 8L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7810), 1, 5L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7811) },
                    { 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7823), 1, 6L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7824) },
                    { 10L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7838), 2, 6L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7839) },
                    { 11L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7852), 1, 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7853) },
                    { 12L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7866), 2, 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7867) },
                    { 14L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7893), 2, 8L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7894) },
                    { 4L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7752), 2, 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7753) },
                    { 15L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7907), 1, 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7908) },
                    { 16L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7921), 2, 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7921) },
                    { 17L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7934), 1, 10L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7935) },
                    { 18L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7949), 2, 10L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7949) },
                    { 19L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7962), 1, 11L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7963) },
                    { 20L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7975), 2, 11L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7976) },
                    { 22L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(8001), 2, 12L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(8002) },
                    { 13L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7880), 1, 8L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7880) },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7732), 1, 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7732) },
                    { 21L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7988), 1, 12L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7989) },
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7560), 1, 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7562) },
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7715), 2, 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(7715) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9535), 1L, "10016", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9536) },
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(8537), 1L, "1000", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(8540) },
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9288), 1L, "1001", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9289) },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9311), 1L, "1002", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9312) },
                    { 18L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9551), 1L, "10017", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9552) },
                    { 6L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9360), 1L, "1005", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9361) },
                    { 7L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9375), 1L, "1006", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9376) },
                    { 8L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9390), 1L, "1007", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9391) },
                    { 4L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9327), 1L, "1003", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9328) },
                    { 10L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9431), 1L, "1009", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9431) },
                    { 9L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9405), 1L, "1008", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9406) },
                    { 15L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9505), 1L, "10014", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9506) },
                    { 14L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9490), 1L, "10013", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9491) },
                    { 16L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9520), 1L, "10015", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9521) },
                    { 12L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9461), 1L, "10011", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9462) },
                    { 11L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9446), 1L, "10010", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9447) },
                    { 13L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9476), 1L, "10012", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9476) },
                    { 5L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9342), 1L, "1004", new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(9343) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1708), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1709), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1827), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1828), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1813), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1814), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1798), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1799), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1784), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1785), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1769), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1770), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1754), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1755), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1740), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1741), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1726), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1726), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1694), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1695), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1650), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1651), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1231), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1233), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1680), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(1680), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9802), 4L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9802), 14L },
                    { 18L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9913), 8L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9914), 13L },
                    { 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9777), 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9778), 13L },
                    { 15L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9870), 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9871), 12L },
                    { 6L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9737), 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9737), 12L },
                    { 4L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9706), 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9707), 2L },
                    { 14L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9857), 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9857), 11L },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9692), 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9693), 11L },
                    { 22L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9968), 10L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9968), 2L },
                    { 16L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9884), 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9884), 10L },
                    { 13L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9843), 6L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9844), 10L },
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9123), 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9125), 5L },
                    { 20L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9941), 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9942), 9L },
                    { 5L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9721), 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9721), 9L },
                    { 7L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9750), 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9751), 3L },
                    { 19L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9927), 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9928), 8L },
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9671), 1L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9672), 8L },
                    { 23L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9981), 10L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9982), 3L },
                    { 25L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(8), 11L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(8), 7L },
                    { 11L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9816), 5L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9817), 7L },
                    { 24L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9995), 11L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9995), 6L },
                    { 12L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9830), 6L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9831), 4L },
                    { 17L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9897), 8L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9898), 5L },
                    { 8L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9764), 3L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9764), 5L },
                    { 26L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(21), 12L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(22), 4L },
                    { 21L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9955), 9L, new DateTime(2019, 4, 15, 22, 7, 12, 988, DateTimeKind.Local).AddTicks(9955), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(6942), 1L, 1L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(6943) },
                    { 2L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7297), 1L, 2L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7297) },
                    { 3L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7318), 1L, 3L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7318) },
                    { 4L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7331), 1L, 4L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7332) },
                    { 5L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7345), 1L, 5L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7346) },
                    { 6L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7381), 1L, 6L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7381) },
                    { 7L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7395), 1L, 7L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7395) },
                    { 8L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7408), 1L, 8L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7409) },
                    { 9L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7422), 1L, 9L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7423) },
                    { 10L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7437), 1L, 10L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7437) },
                    { 11L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7450), 1L, 11L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7451) },
                    { 12L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7464), 1L, 12L, new DateTime(2019, 4, 15, 22, 7, 12, 989, DateTimeKind.Local).AddTicks(7465) }
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
                name: "IX_Time_UnitLessonId",
                schema: "Syllabus",
                table: "Time",
                column: "UnitLessonId");

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
                name: "Time",
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
                name: "UnitLesson",
                schema: "Syllabus");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Faculty");

            migrationBuilder.DropTable(
                name: "Syllabus",
                schema: "Syllabus");

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
