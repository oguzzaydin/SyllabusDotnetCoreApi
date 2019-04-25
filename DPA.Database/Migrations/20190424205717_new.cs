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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentInstructor_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(3517), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(3521) },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(4110), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(4111) },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(4171), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(4172) },
                    { 4L, new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(4223), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(4225) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(1076), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(1078), 3 },
                    { 10L, 6, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(961), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(963), 4 },
                    { 9L, 6, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(901), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(902), 4 },
                    { 8L, 6, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(844), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(845), 5 },
                    { 7L, 4, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(787), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(789), 4 },
                    { 11L, 4, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(1019), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(1020), 3 },
                    { 5L, 4, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(652), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(653), 2 },
                    { 4L, 4, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(596), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(597), 2 },
                    { 3L, 6, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(539), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(540), 4 },
                    { 2L, 6, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(448), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(450), 5 },
                    { 1L, 4, new DateTime(2019, 4, 24, 23, 57, 16, 683, DateTimeKind.Local).AddTicks(8370), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 24, 23, 57, 16, 683, DateTimeKind.Local).AddTicks(8377), 4 },
                    { 6L, 6, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(727), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(729), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(138), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(142) },
                    { 11L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(9574), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(9578) },
                    { 10L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(9368), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(9370) },
                    { 9L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8503), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8504) },
                    { 8L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8322), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8323) },
                    { 7L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8164), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8165) },
                    { 4L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7680), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7682) },
                    { 5L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7848), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7849) },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7518), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7524) },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7144), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(7146) },
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 678, DateTimeKind.Local).AddTicks(9814), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 24, 23, 57, 16, 678, DateTimeKind.Local).AddTicks(9836) },
                    { 13L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(334), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(335) },
                    { 6L, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8014), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 24, 23, 57, 16, 681, DateTimeKind.Local).AddTicks(8015) },
                    { 14L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(448), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(450) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(8861), "BM310", 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(8864) },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(9271), "BM311", 1L, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(9273) },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(9318), "BM312", 1L, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 24, 23, 57, 16, 685, DateTimeKind.Local).AddTicks(9319) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3858), 1, 3L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3860) },
                    { 6L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3915), 2, 3L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3917) },
                    { 7L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3968), 1, 4L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3969) },
                    { 8L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4010), 1, 5L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4012) },
                    { 9L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4058), 1, 6L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4060) },
                    { 10L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4116), 2, 6L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4117) },
                    { 11L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4170), 1, 7L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4172) },
                    { 12L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4225), 2, 7L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4227) },
                    { 14L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4297), 2, 8L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4299) },
                    { 4L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3823), 2, 2L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3823) },
                    { 15L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4336), 1, 9L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4338) },
                    { 16L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4386), 2, 9L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4387) },
                    { 17L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4432), 1, 10L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4434) },
                    { 18L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4473), 2, 10L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4475) },
                    { 19L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4498), 1, 11L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4499) },
                    { 21L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4551), 1, 12L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4552) },
                    { 22L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4577), 2, 12L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4579) },
                    { 13L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4271), 1, 8L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4272) },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3775), 1, 2L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3777) },
                    { 20L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4522), 2, 11L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(4523) },
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3222), 1, 1L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3227) },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3728), 2, 1L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(3730) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5294), 1L, "10016", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5295) },
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(3765), 1L, "1000", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(3769) },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4527), 1L, "1001", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4529) },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4591), 1L, "1002", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4592) },
                    { 18L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5345), 1L, "10017", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5347) },
                    { 6L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4734), 1L, "1005", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4735) },
                    { 7L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4766), 1L, "1006", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4767) },
                    { 8L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4817), 1L, "1007", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4818) },
                    { 4L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4641), 1L, "1003", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4643) },
                    { 10L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4922), 1L, "1009", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4923) },
                    { 9L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4867), 1L, "1008", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4868) },
                    { 15L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5179), 1L, "10014", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5181) },
                    { 14L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5129), 1L, "10013", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5131) },
                    { 16L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5229), 1L, "10015", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5231) },
                    { 12L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5026), 1L, "10011", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5028) },
                    { 11L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4974), 1L, "10010", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4976) },
                    { 13L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5078), 1L, "10012", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(5080) },
                    { 5L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4693), 1L, "1004", new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(4694) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7297), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7297), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7556), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7557), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7526), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7528), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7495), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7496), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7461), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7462), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7422), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7424), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7389), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7389), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7356), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7356), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7334), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7335), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7261), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7262), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7127), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7129), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(5924), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(5941), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7211), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 24, 23, 57, 16, 682, DateTimeKind.Local).AddTicks(7211), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7003), 4L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7004), 14L },
                    { 18L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7437), 8L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7439), 13L },
                    { 9L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6971), 3L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6972), 13L },
                    { 15L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7282), 7L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7283), 12L },
                    { 6L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6858), 2L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6859), 12L },
                    { 4L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6787), 2L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6788), 2L },
                    { 14L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7243), 7L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7244), 11L },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6765), 1L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6765), 11L },
                    { 22L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7653), 10L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7654), 2L },
                    { 16L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7332), 7L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7333), 10L },
                    { 13L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7219), 6L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7220), 10L },
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6123), 1L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6125), 5L },
                    { 20L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7538), 9L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7540), 9L },
                    { 5L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6812), 2L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6814), 9L },
                    { 7L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6885), 3L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6886), 3L },
                    { 19L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7488), 9L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7489), 8L },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6728), 1L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6729), 8L },
                    { 23L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7706), 10L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7707), 3L },
                    { 25L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7812), 11L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7813), 7L },
                    { 11L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7169), 5L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7170), 7L },
                    { 24L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7759), 11L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7760), 6L },
                    { 12L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7199), 6L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7200), 4L },
                    { 17L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7382), 8L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7384), 5L },
                    { 8L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6921), 3L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(6923), 5L },
                    { 26L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7865), 12L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7866), 4L },
                    { 21L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7601), 9L, new DateTime(2019, 4, 24, 23, 57, 16, 684, DateTimeKind.Local).AddTicks(7603), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(690), 1L, 1L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(696) },
                    { 2L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1357), 1L, 2L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1358) },
                    { 3L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1397), 1L, 3L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1398) },
                    { 4L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1434), 1L, 4L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1435) },
                    { 5L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1458), 1L, 5L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1459) },
                    { 6L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1535), 1L, 6L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1536) },
                    { 7L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1566), 1L, 7L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1568) },
                    { 8L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1599), 1L, 8L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1600) },
                    { 9L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1623), 1L, 9L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1624) },
                    { 10L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1695), 1L, 10L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1697) },
                    { 11L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1749), 1L, 11L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1750) },
                    { 12L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1773), 1L, 12L, new DateTime(2019, 4, 24, 23, 57, 16, 686, DateTimeKind.Local).AddTicks(1774) }
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
