using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DPA.Database.Migrations
{
    public partial class initial : Migration
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
                    DayOfTheWeek = table.Column<int>(nullable: false),
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
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5450), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5460) },
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5720), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5730) },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5760), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5760) },
                    { 4L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5790), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(5790) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2930), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2930), 3 },
                    { 10L, 6, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2850), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2850), 4 },
                    { 9L, 6, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2810), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2810), 4 },
                    { 8L, 6, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2770), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2780), 5 },
                    { 7L, 4, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2720), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2720), 4 },
                    { 11L, 4, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2890), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2890), 3 },
                    { 5L, 4, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2640), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2640), 2 },
                    { 4L, 4, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2600), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2610), 2 },
                    { 3L, 6, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2560), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2570), 4 },
                    { 2L, 6, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2500), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2500), 5 },
                    { 1L, 4, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(220), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(240), 4 },
                    { 6L, 6, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2680), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(2690), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4890), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4900) },
                    { 11L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4780), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4780) },
                    { 10L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4660), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4670) },
                    { 9L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4530), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4530) },
                    { 8L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4410), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4420) },
                    { 7L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4300), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4300) },
                    { 4L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(3910), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(3910) },
                    { 5L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4050), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4050) },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(3770), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(3770) },
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(3460), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(3470) },
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 293, DateTimeKind.Local).AddTicks(3590), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 14, 16, 27, 1, 293, DateTimeKind.Local).AddTicks(3630) },
                    { 13L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(5010), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(5010) },
                    { 6L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4180), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(4190) },
                    { 14L, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(5130), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 14, 16, 27, 1, 296, DateTimeKind.Local).AddTicks(5140) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "HeadOfDepartmentId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(1490), "BM311", 1L, null, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(1490) },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(1530), "BM312", 1L, null, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(1530) },
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(280), "BM310", 1L, 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(290) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6020), 1, 3L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6030) },
                    { 6L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6060), 2, 3L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6060) },
                    { 7L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6100), 1, 4L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6100) },
                    { 8L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6130), 1, 5L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6130) },
                    { 9L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6160), 1, 6L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6160) },
                    { 10L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6200), 2, 6L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6200) },
                    { 11L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6230), 1, 7L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6230) },
                    { 12L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6260), 2, 7L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6260) },
                    { 14L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6320), 2, 8L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6330) },
                    { 4L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5990), 2, 2L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5990) },
                    { 15L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6350), 1, 9L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6360) },
                    { 16L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6390), 2, 9L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6390) },
                    { 17L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6420), 1, 10L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6420) },
                    { 18L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6470), 2, 10L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6470) },
                    { 19L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6510), 1, 11L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6510) },
                    { 20L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6540), 2, 11L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6540) },
                    { 22L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6610), 2, 12L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6610) },
                    { 13L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6290), 1, 8L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6290) },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5960), 1, 2L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5960) },
                    { 21L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6570), 1, 12L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(6580) },
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5610), 1, 1L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5620) },
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5910), 2, 1L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(5920) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(8000), 1L, "10016", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(8010) },
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(6720), 1L, "1000", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(6730) },
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7530), 1L, "1001", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7530) },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7570), 1L, "1002", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7580) },
                    { 18L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(8050), 1L, "10017", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(8050) },
                    { 6L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7670), 1L, "1005", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7670) },
                    { 7L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7700), 1L, "1006", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7710) },
                    { 8L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7730), 1L, "1007", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7740) },
                    { 4L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7610), 1L, "1003", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7610) },
                    { 10L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7800), 1L, "1009", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7800) },
                    { 9L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7760), 1L, "1008", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7770) },
                    { 15L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7940), 1L, "10014", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7950) },
                    { 14L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7910), 1L, "10013", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7920) },
                    { 16L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7970), 1L, "10015", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7980) },
                    { 12L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7860), 1L, "10011", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7860) },
                    { 11L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7830), 1L, "10010", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7830) },
                    { 13L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7890), 1L, "10012", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7890) },
                    { 5L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7640), 1L, "1004", new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(7640) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2500), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2510), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2780), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2790), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2750), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2750), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2720), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2720), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2680), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2690), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2650), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2650), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2620), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2620), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2580), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2580), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2540), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2550), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2470), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2470), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2370), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2370), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(1350), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(1360), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2430), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 14, 16, 27, 1, 297, DateTimeKind.Local).AddTicks(2430), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9840), 4L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9840), 14L },
                    { 18L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(90), 8L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(100), 13L },
                    { 9L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9800), 3L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9810), 13L },
                    { 15L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local), 7L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local), 12L },
                    { 6L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9710), 2L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9710), 12L },
                    { 4L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9640), 2L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9640), 2L },
                    { 14L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9970), 7L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9970), 11L },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9600), 1L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9600), 11L },
                    { 22L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(220), 10L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(230), 2L },
                    { 16L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(30), 7L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(30), 10L },
                    { 13L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9930), 6L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9940), 10L },
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(8630), 1L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(8640), 5L },
                    { 20L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(160), 9L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(160), 9L },
                    { 5L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9670), 2L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9670), 9L },
                    { 7L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9740), 3L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9740), 3L },
                    { 19L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(130), 9L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(130), 8L },
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9550), 1L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9560), 8L },
                    { 23L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(260), 10L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(260), 3L },
                    { 25L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(340), 11L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(340), 7L },
                    { 11L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9870), 5L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9870), 7L },
                    { 24L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(300), 11L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(310), 6L },
                    { 12L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9900), 6L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9910), 4L },
                    { 17L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(60), 8L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(60), 5L },
                    { 8L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9770), 3L, new DateTime(2019, 4, 14, 16, 27, 1, 298, DateTimeKind.Local).AddTicks(9770), 5L },
                    { 26L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(370), 12L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(370), 4L },
                    { 21L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(190), 9L, new DateTime(2019, 4, 14, 16, 27, 1, 299, DateTimeKind.Local).AddTicks(190), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(3280), 1L, 1L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(3290) },
                    { 2L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4070), 1L, 2L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4070) },
                    { 3L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4110), 1L, 3L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4110) },
                    { 4L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4140), 1L, 4L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4140) },
                    { 5L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4160), 1L, 5L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4170) },
                    { 6L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4230), 1L, 6L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4230) },
                    { 7L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4260), 1L, 7L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4260) },
                    { 8L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4290), 1L, 8L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4290) },
                    { 9L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4320), 1L, 9L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4320) },
                    { 10L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4350), 1L, 10L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4350) },
                    { 11L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4370), 1L, 11L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4370) },
                    { 12L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4400), 1L, 12L, new DateTime(2019, 4, 14, 16, 27, 1, 300, DateTimeKind.Local).AddTicks(4400) }
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
