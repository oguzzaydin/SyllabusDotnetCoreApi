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
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3455), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3458) },
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3663), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3664) },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3685), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3686) },
                    { 4L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3700), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(3701) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7096), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7096), 3 },
                    { 10L, 6, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7063), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7063), 4 },
                    { 9L, 6, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7042), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7043), 4 },
                    { 8L, 6, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7024), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7025), 5 },
                    { 7L, 4, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6999), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7001), 4 },
                    { 11L, 4, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7079), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(7080), 3 },
                    { 5L, 4, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6950), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6950), 2 },
                    { 4L, 4, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6926), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6927), 2 },
                    { 3L, 6, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6908), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6908), 4 },
                    { 2L, 6, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6871), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6872), 5 },
                    { 1L, 4, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6038), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6041), 4 },
                    { 6L, 6, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6983), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(6983), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(9004), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(9005) },
                    { 11L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8948), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8949) },
                    { 10L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8891), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8892) },
                    { 9L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8824), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8825) },
                    { 8L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8769), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8770) },
                    { 7L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8714), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8715) },
                    { 4L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8514), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8515) },
                    { 5L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8580), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8581) },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8455), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8456) },
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8289), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8290) },
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 249, DateTimeKind.Local).AddTicks(820), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 14, 21, 23, 4, 249, DateTimeKind.Local).AddTicks(837) },
                    { 13L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(9059), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(9060) },
                    { 6L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8658), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(8659) },
                    { 14L, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(9113), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 14, 21, 23, 4, 250, DateTimeKind.Local).AddTicks(9114) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "HeadOfDepartmentId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(7361), "BM311", 1L, null, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(7362) },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(7385), "BM312", 1L, null, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(7385) },
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(6470), "BM310", 1L, 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(6472) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8264), 1, 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8265) },
                    { 6L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8283), 2, 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8284) },
                    { 7L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8298), 1, 4L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8298) },
                    { 8L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8313), 1, 5L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8314) },
                    { 9L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8329), 1, 6L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8329) },
                    { 10L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8344), 2, 6L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8345) },
                    { 11L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8361), 1, 7L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8361) },
                    { 12L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8376), 2, 7L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8376) },
                    { 14L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8405), 2, 8L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8406) },
                    { 4L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8249), 2, 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8249) },
                    { 15L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8420), 1, 9L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8420) },
                    { 16L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8434), 2, 9L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8435) },
                    { 17L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8449), 1, 10L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8449) },
                    { 18L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8464), 2, 10L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8465) },
                    { 19L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8478), 1, 11L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8479) },
                    { 20L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8501), 2, 11L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8501) },
                    { 22L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8530), 2, 12L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8531) },
                    { 13L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8390), 1, 8L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8391) },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8234), 1, 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8234) },
                    { 21L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8516), 1, 12L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8516) },
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8060), 1, 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8062) },
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8216), 2, 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(8216) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(632), 1L, "10016", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(633) },
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(35), 1L, "1000", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(37) },
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(403), 1L, "1001", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(403) },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(426), 1L, "1002", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(427) },
                    { 18L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(648), 1L, "10017", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(648) },
                    { 6L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(473), 1L, "1005", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(473) },
                    { 7L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(487), 1L, "1006", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(488) },
                    { 8L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(502), 1L, "1007", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(502) },
                    { 4L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(441), 1L, "1003", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(442) },
                    { 10L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(532), 1L, "1009", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(532) },
                    { 9L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(516), 1L, "1008", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(517) },
                    { 15L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(604), 1L, "10014", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(605) },
                    { 14L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(590), 1L, "10013", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(590) },
                    { 16L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(618), 1L, "10015", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(618) },
                    { 12L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(561), 1L, "10011", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(562) },
                    { 11L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(547), 1L, "10010", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(547) },
                    { 13L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(575), 1L, "10012", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(576) },
                    { 5L, new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(456), 1L, "1004", new DateTime(2019, 4, 14, 21, 23, 4, 253, DateTimeKind.Local).AddTicks(457) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1955), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1956), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2080), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2080), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2065), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2065), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2050), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2051), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2035), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2035), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2019), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2020), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2004), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(2004), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1988), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1989), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1973), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1974), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1937), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1938), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1881), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1882), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1491), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1493), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1913), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(1914), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9969), 4L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9970), 14L },
                    { 18L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(79), 8L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(80), 13L },
                    { 9L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9955), 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9956), 13L },
                    { 15L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(37), 7L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(38), 12L },
                    { 6L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9914), 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9915), 12L },
                    { 4L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9884), 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9884), 2L },
                    { 14L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(24), 7L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(25), 11L },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9869), 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9870), 11L },
                    { 22L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(135), 10L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(135), 2L },
                    { 16L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(51), 7L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(52), 10L },
                    { 13L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(10), 6L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(11), 10L },
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9504), 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9506), 5L },
                    { 20L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(107), 9L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(108), 9L },
                    { 5L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9898), 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9898), 9L },
                    { 7L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9928), 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9929), 3L },
                    { 19L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(93), 9L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(94), 8L },
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9848), 1L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9849), 8L },
                    { 23L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(148), 10L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(149), 3L },
                    { 25L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(176), 11L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(176), 7L },
                    { 11L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9983), 5L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9984), 7L },
                    { 24L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(162), 11L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(163), 6L },
                    { 12L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9997), 6L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9997), 4L },
                    { 17L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(65), 8L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(65), 5L },
                    { 8L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9941), 3L, new DateTime(2019, 4, 14, 21, 23, 4, 251, DateTimeKind.Local).AddTicks(9942), 5L },
                    { 26L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(197), 12L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(198), 4L },
                    { 21L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(121), 9L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(122), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8324), 1L, 1L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8326) },
                    { 2L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8804), 1L, 2L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8805) },
                    { 3L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8826), 1L, 3L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8827) },
                    { 4L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8842), 1L, 4L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8843) },
                    { 5L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8857), 1L, 5L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8858) },
                    { 6L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8888), 1L, 6L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8888) },
                    { 7L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8902), 1L, 7L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8903) },
                    { 8L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8916), 1L, 8L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8917) },
                    { 9L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8930), 1L, 9L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8931) },
                    { 10L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8946), 1L, 10L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8946) },
                    { 11L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8960), 1L, 11L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8961) },
                    { 12L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8974), 1L, 12L, new DateTime(2019, 4, 14, 21, 23, 4, 252, DateTimeKind.Local).AddTicks(8975) }
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
