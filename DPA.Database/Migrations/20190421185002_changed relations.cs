using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DPA.Database.Migrations
{
    public partial class changedrelations : Migration
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
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(9948), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(9951) },
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(274), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(275) },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(301), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(302) },
                    { 4L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(338), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(339) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2782), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2783), 3 },
                    { 10L, 6, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2741), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2741), 4 },
                    { 9L, 6, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2722), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2723), 4 },
                    { 8L, 6, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2705), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2706), 5 },
                    { 7L, 4, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2688), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2689), 4 },
                    { 11L, 4, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2757), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2758), 3 },
                    { 5L, 4, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2651), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2652), 2 },
                    { 4L, 4, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2632), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2633), 2 },
                    { 3L, 6, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2615), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2615), 4 },
                    { 2L, 6, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2578), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2579), 5 },
                    { 1L, 4, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(1741), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(1743), 4 },
                    { 6L, 6, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2672), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(2672), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4193), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4193) },
                    { 11L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4129), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4130) },
                    { 10L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4073), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4074) },
                    { 9L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4015), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4016) },
                    { 8L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3959), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3960) },
                    { 7L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3903), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3903) },
                    { 4L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3716), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3717) },
                    { 5L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3774), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3775) },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3657), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3658) },
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3490), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3491) },
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 792, DateTimeKind.Local).AddTicks(6368), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 21, 21, 50, 1, 792, DateTimeKind.Local).AddTicks(6390) },
                    { 13L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4249), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4249) },
                    { 6L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3837), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(3838) },
                    { 14L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4305), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(4305) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "HeadOfDepartmentId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(4514), "BM311", 1L, null, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(4516) },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(4544), "BM312", 1L, null, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(4545) },
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(3602), "BM310", 1L, 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(3604) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4003), 1, 3L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4004) },
                    { 6L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4019), 2, 3L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4020) },
                    { 7L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4034), 1, 4L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4035) },
                    { 8L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4049), 1, 5L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4050) },
                    { 9L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4065), 1, 6L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4066) },
                    { 10L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4082), 2, 6L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4083) },
                    { 11L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4098), 1, 7L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4099) },
                    { 12L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4113), 2, 7L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4113) },
                    { 14L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4142), 2, 8L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4143) },
                    { 4L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3989), 2, 2L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3989) },
                    { 15L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4156), 1, 9L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4157) },
                    { 16L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4171), 2, 9L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4172) },
                    { 17L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4187), 1, 10L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4187) },
                    { 18L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4203), 2, 10L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4203) },
                    { 19L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4217), 1, 11L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4218) },
                    { 20L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4231), 2, 11L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4232) },
                    { 22L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4259), 2, 12L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4260) },
                    { 13L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4127), 1, 8L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4128) },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3974), 1, 2L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3974) },
                    { 21L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4245), 1, 12L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(4246) },
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3782), 1, 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3784) },
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3956), 2, 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(3956) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9510), 1L, "10016", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9511) },
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(8466), 1L, "1000", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(8468) },
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(8979), 1L, "1001", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(8980) },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9017), 1L, "1002", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9018) },
                    { 18L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9537), 1L, "10017", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9538) },
                    { 6L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9095), 1L, "1005", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9096) },
                    { 7L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9130), 1L, "1006", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9131) },
                    { 8L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9154), 1L, "1007", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9155) },
                    { 4L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9043), 1L, "1003", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9044) },
                    { 10L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9205), 1L, "1009", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9206) },
                    { 9L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9179), 1L, "1008", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9180) },
                    { 15L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9327), 1L, "10014", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9327) },
                    { 14L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9302), 1L, "10013", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9303) },
                    { 16L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9351), 1L, "10015", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9352) },
                    { 12L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9254), 1L, "10011", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9255) },
                    { 11L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9230), 1L, "10010", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9231) },
                    { 13L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9278), 1L, "10012", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9279) },
                    { 5L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9068), 1L, "1004", new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(9068) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7677), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7678), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7804), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7804), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7789), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7790), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7775), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7776), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7753), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7754), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7737), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7738), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7723), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7724), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7708), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7709), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7694), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7695), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7662), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7663), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7614), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7615), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(6981), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(6984), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7646), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 21, 21, 50, 1, 794, DateTimeKind.Local).AddTicks(7648), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5493), 4L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5493), 14L },
                    { 18L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5611), 8L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5612), 13L },
                    { 9L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5477), 3L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5478), 13L },
                    { 15L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5565), 7L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5565), 12L },
                    { 6L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5433), 2L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5434), 12L },
                    { 4L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5393), 2L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5394), 2L },
                    { 14L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5550), 7L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5551), 11L },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5376), 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5377), 11L },
                    { 22L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5667), 10L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5668), 2L },
                    { 16L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5579), 7L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5580), 10L },
                    { 13L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5536), 6L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5536), 10L },
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5009), 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5011), 5L },
                    { 20L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5639), 9L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5640), 9L },
                    { 5L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5408), 2L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5408), 9L },
                    { 7L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5448), 3L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5449), 3L },
                    { 19L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5625), 9L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5626), 8L },
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5355), 1L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5356), 8L },
                    { 23L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5682), 10L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5683), 3L },
                    { 25L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5715), 11L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5715), 7L },
                    { 11L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5507), 5L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5508), 7L },
                    { 24L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5699), 11L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5700), 6L },
                    { 12L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5521), 6L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5522), 4L },
                    { 17L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5595), 8L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5595), 5L },
                    { 8L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5463), 3L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5463), 5L },
                    { 26L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5730), 12L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5730), 4L },
                    { 21L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5654), 9L, new DateTime(2019, 4, 21, 21, 50, 1, 795, DateTimeKind.Local).AddTicks(5654), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(5631), 1L, 1L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(5634) },
                    { 2L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6386), 1L, 2L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6387) },
                    { 3L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6442), 1L, 3L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6443) },
                    { 4L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6469), 1L, 4L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6470) },
                    { 5L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6494), 1L, 5L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6495) },
                    { 6L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6524), 1L, 6L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6524) },
                    { 7L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6569), 1L, 7L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6570) },
                    { 8L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6590), 1L, 8L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6591) },
                    { 9L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6613), 1L, 9L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6614) },
                    { 10L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6639), 1L, 10L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6640) },
                    { 11L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6663), 1L, 11L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6664) },
                    { 12L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6687), 1L, 12L, new DateTime(2019, 4, 21, 21, 50, 1, 796, DateTimeKind.Local).AddTicks(6688) }
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
