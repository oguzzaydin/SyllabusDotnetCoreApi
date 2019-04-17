using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DPA.Database.Migrations
{
    public partial class timeenttiychanged : Migration
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
                    Group = table.Column<string>(maxLength: 1, nullable: false)
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
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6087), "BM310", "BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ", new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6090) },
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6471), "MF123", "Mühendislik Fakültesi", new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6471) },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6503), "HKK112", "Hukuk Fakültesi", new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6504) },
                    { 4L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6524), "TKL423", "Teknoloji Fakültesi", new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(6525) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Lesson",
                columns: new[] { "LessonId", "AKTS", "CreatedDate", "Credit", "LessonCode", "LessonType", "Name", "SemesterType", "UpdatedDate", "WeeklyHour" },
                values: new object[,]
                {
                    { 12L, 4, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6684), 3, "IST 108", 1, "OLASILIK VE İSTATİSTİK", 2, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6685), 3 },
                    { 10L, 6, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6630), 4, "BSM 102", 1, "NESNEYE DAYALI PROGRAMLAMA", 2, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6631), 4 },
                    { 9L, 6, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6601), 4, "MAT 112", 1, "MATEMATİK II", 2, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6602), 4 },
                    { 8L, 6, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6557), 4, "FIZ 112", 1, "FİZİK II", 2, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6558), 5 },
                    { 7L, 4, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6529), 4, "ING 190", 1, "İNGİLİZCE", 2, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6530), 4 },
                    { 11L, 4, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6658), 3, "BSM 104", 1, "WEB TEKNOLOJİLERİ", 2, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6659), 3 },
                    { 5L, 4, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6470), 2, "BSM 101", 1, "BİLGİSAYAR MÜHENDİSLİĞİNE GİRİŞ", 1, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6471), 2 },
                    { 4L, 4, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6442), 2, "MAT 113", 1, "LİNEER CEBİR", 1, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6443), 2 },
                    { 3L, 6, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6398), 4, "MAT 111", 1, "MATEMATİK I", 1, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6400), 4 },
                    { 2L, 6, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6311), 4, "FIZ 111", 1, "FİZİK I", 1, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6313), 5 },
                    { 1L, 4, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(4780), 4, "TUR 101", 1, "TÜRK DİLİ", 1, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(4785), 4 },
                    { 6L, 6, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6501), 4, "BSM 103", 1, "PROGRAMLAMAYA GİRİŞ", 1, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(6502), 4 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Login", "Name", "Password", "Roles", "Status", "Surname", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 12L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2893), "hasantutan@sakarya.edu.tr", "GgWLS/9l9VKx7d18VXX+K3i3oJ6emqeCCniMnl6Gbg1cJftNXfCWUFao5OpNTaWCw39B/Z/1E5vV2+PPDFFesQ==", "Hasan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Tutan", 4, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2894) },
                    { 11L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2781), "oguz@sakarya.edu.tr", "N2dbG766DJ+GQaFDlEPrH3ioi+ZD9VpnVGVHCtTxZl9nC+ruFrcTi7zgOIydZKCFaBqwKxpowNV2GYBRSPvNbQ==", "Oguzhan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2783) },
                    { 10L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2659), "ddural@sakarya.edu.tr", "+tqmuZBVWUcLTVBaSyXnHUGxLiN8+kdgrkW2Ds9wxhS4wAC/NO+vSPFKLYoWHkZDvtP6gVUSfW77X9FkB/Bimw==", "Deniz", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Balta", 2, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2661) },
                    { 9L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2544), "beken@sakarya.edu.tr", "1J8MNqnuIyH/yRYMDQUejip91vrhoW+A3YdeD9eAYDtLuWx17l706wt6sXrzabpaW6CePiIxw5YU8jDQqnhMmA==", "Beyza", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Eken", 2, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2546) },
                    { 8L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2429), "ahmetarslan@sakarya.edu.tr", "h0g/LYGJK7QP9Lo3ZNMnCtlyzkVTVhf3c+S+lA7ExZ/U9XP+84SvRNjjmnYrCMKQS2r6D7TPuuHH75zNwTU4YQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Arslan", 2, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2431) },
                    { 7L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2319), "cbayilmis@sakarya.edu.tr", "dOGHhzh1rEnqFOee38OOgEWmQM5Ex3+PtVwdLHWpKNlAjyuX+Zx9m91+f4TmlpEZKHL1hK/SunceSqkZ+m/u2g==", "Cüneyt", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Bayılmış", 3, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2320) },
                    { 4L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(1958), "umit@sakarya.edu.tr", "aYoce2dux8eT5/nvryziC97/nrEiqS5+S0hEMEvKhB0fGnI8dbF7AFLAi/+6dnvNOZwnHDJi+9VQwUtKaPeEcA==", "Ümit", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Kocabıçak", 1, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(1960) },
                    { 5L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2074), "azengin@sakarya.edu.tr", "3b8hL6Cd/mm0v6MgNvkKvnoUjLbK/8+JNw/0AIXmtZjxfOcpZYndmXqV8UHH4dI8b1EnJ4LZWNs8lQV74pv2jQ==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Zengin", 3, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2076) },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(1835), "coz@sakarya.edu.tr", "lpe17pCaWVWNiI8dXvCHIEgaSpoTiULAZbWhSDxk1zbEdv3je87szjOl8CFst+hU8hITlcCc2AtvEIAdxgA+ng==", "Cemil", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 2, 1, "Öz", 1, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(1836) },
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(1550), "celalceken@sakarya.edu.tr", "sqqdGm+QyoYM0p0Co1hgYX9aPayWbuCoIpPkN3vm+ntuFm8/mNW901g1mPJP0V/ZdOuD05U5btfuffNNkvRSMQ==", "Celal", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Çeken", 1, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(1551) },
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 628, DateTimeKind.Local).AddTicks(6807), "administrator@administrator.com", "1h0ATANFe6x7kMHo1PURE74WI0ayevUwfK/+Ie+IWX/xWrFWngcVUwL/ewryn38EMVMQBFaNo4SaVwgXaBWnDw==", "Administrator", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 3, 1, "Administrator", 0, new DateTime(2019, 4, 17, 22, 37, 18, 628, DateTimeKind.Local).AddTicks(6831) },
                    { 13L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(3005), "ercanpala@sakarya.edu.tr", "PS+3mJHvWnYUHEhmnfo8APwTthPB92Bf2CDAupt1vAWgbc78SYmxb+wL48kZAUB6jHANlNfpH9yuAjRAyF6vlA==", "Ercan", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Palabıyık", 4, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(3007) },
                    { 6L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2207), "ozmen@sakarya.edu.tr", "DQFv5btLPxS0XrNFtrqeFiKSgPMPHwmrdk88CVFWmRBn2jK6vVpms4u8MoLUCvNMEhI99ECRDR8Rh6kuwDy+Zg==", "Ahmet", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Özmen", 3, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(2209) },
                    { 14L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(3116), "meltemayy@sakarya.edu.tr", "Ee6akHsxZOrmTyxqSHZL9vRY+MZdM6mUeRwEc7K+dRE8k1k0qagjmU8MN7KF0yVy7EkplM/ZIx90EbzYa4vTdA==", "Meltem", "CkcVGgdOYzq3tr7Wqrckq73c0yUPgKBrxhKiM6kHgFEB8kQbWykm5UzorIz7wHS7elZ0iDBIffCVkdvhZ+gA9g==", 1, 1, "Aydın", 4, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(3117) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Department",
                columns: new[] { "DepartmentId", "CreatedDate", "DepartmentCode", "FacultyId", "HeadOfDepartmentId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(1715), "BM311", 1L, null, "Bilişim Sistemleri Mühendisliği Bölümü", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(1716) },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(1763), "BM312", 1L, null, "Yazılım Mühendisliği Bölümü", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(1765) },
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(606), "BM310", 1L, 1L, "Bilgisayar Mühendisliği Bölümü", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(610) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "LessonGroup",
                columns: new[] { "LessonGroupId", "CreatedDate", "GroupType", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8756), 1, 3L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8757) },
                    { 6L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8782), 2, 3L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8783) },
                    { 7L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8806), 1, 4L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8807) },
                    { 8L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8830), 1, 5L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8831) },
                    { 9L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8853), 1, 6L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8854) },
                    { 10L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8877), 2, 6L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8878) },
                    { 11L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8902), 1, 7L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8903) },
                    { 12L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8927), 2, 7L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8928) },
                    { 14L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8974), 2, 8L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8975) },
                    { 4L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8734), 2, 2L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8735) },
                    { 15L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8998), 1, 9L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8999) },
                    { 16L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9044), 2, 9L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9045) },
                    { 17L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9085), 1, 10L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9087) },
                    { 18L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9214), 2, 10L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9215) },
                    { 19L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9239), 1, 11L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9240) },
                    { 20L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9262), 2, 11L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9263) },
                    { 22L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9321), 2, 12L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9322) },
                    { 13L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8949), 1, 8L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8950) },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8712), 1, 2L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8713) },
                    { 21L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9285), 1, 12L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(9286) },
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8397), 1, 1L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8400) },
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8682), 2, 1L, new DateTime(2019, 4, 17, 22, 37, 18, 632, DateTimeKind.Local).AddTicks(8683) }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "Location",
                columns: new[] { "LocationId", "CreatedDate", "FacultyId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 17L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5906), 1L, "10016", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5907) },
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5255), 1L, "1000", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5257) },
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5649), 1L, "1001", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5649) },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5687), 1L, "1002", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5688) },
                    { 18L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5923), 1L, "10017", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5923) },
                    { 6L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5737), 1L, "1005", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5738) },
                    { 7L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5753), 1L, "1006", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5753) },
                    { 8L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5768), 1L, "1007", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5769) },
                    { 4L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5704), 1L, "1003", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5704) },
                    { 10L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5799), 1L, "1009", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5800) },
                    { 9L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5783), 1L, "1008", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5784) },
                    { 15L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5876), 1L, "10014", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5876) },
                    { 14L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5861), 1L, "10013", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5861) },
                    { 16L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5891), 1L, "10015", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5891) },
                    { 12L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5830), 1L, "10011", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5831) },
                    { 11L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5815), 1L, "10010", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5816) },
                    { 13L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5846), 1L, "10012", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5846) },
                    { 5L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5719), 1L, "1004", new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(5720) }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "Constraint",
                columns: new[] { "ConstraintId", "CreatedDate", "Description", "EducationType", "IsActive", "IsFreeDay", "Title", "UpdatedDate", "UserId", "WeeklyHour" },
                values: new object[,]
                {
                    { 5L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8020), "Description", 1, true, true, "Kısıt 5", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8021), 6L, 12 },
                    { 13L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8250), "Description", 3, true, false, "Kısıt 13", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8250), 14L, 16 },
                    { 12L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8226), "Description", 3, true, false, "Kısıt 12", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8228), 13L, 16 },
                    { 11L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8202), "Description", 2, true, true, "Kısıt 11", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8203), 12L, 12 },
                    { 10L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8177), "Description", 1, true, true, "Kısıt 10", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8178), 11L, 12 },
                    { 9L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8148), "Description", 3, true, false, "Kısıt 9", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8149), 10L, 12 },
                    { 8L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8121), "Description", 1, true, true, "Kısıt 8", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8122), 9L, 10 },
                    { 7L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8093), "Description", 2, true, true, "Kısıt 7", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8096), 8L, 8 },
                    { 6L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8062), "Description", 3, true, false, "Kısıt 6", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(8063), 7L, 14 },
                    { 4L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7993), "Description", 2, true, true, "Kısıt 4", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7994), 5L, 10 },
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7906), "Description", 2, true, true, "Kısıt 2", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7908), 3L, 6 },
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7224), "Description", 1, true, true, "Kısıt 1", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7227), 2L, 4 },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7965), "Description", 3, true, false, "Kısıt 3", new DateTime(2019, 4, 17, 22, 37, 18, 631, DateTimeKind.Local).AddTicks(7966), 4L, 8 }
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "UserLesson",
                columns: new[] { "UserLessonId", "CreatedDate", "LessonId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 10L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1897), 4L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1898), 14L },
                    { 18L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2115), 8L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2116), 13L },
                    { 9L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1869), 3L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1870), 13L },
                    { 15L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2017), 7L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2018), 12L },
                    { 6L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1722), 2L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1724), 12L },
                    { 4L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1620), 2L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1621), 2L },
                    { 14L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1994), 7L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1995), 11L },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1570), 1L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1572), 11L },
                    { 22L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2185), 10L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2186), 2L },
                    { 16L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2042), 7L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2043), 10L },
                    { 13L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1970), 6L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1971), 10L },
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(708), 1L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(714), 5L },
                    { 20L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2157), 9L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2158), 9L },
                    { 5L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1667), 2L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1668), 9L },
                    { 7L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1773), 3L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1792), 3L },
                    { 19L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2141), 9L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2142), 8L },
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1507), 1L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1509), 8L },
                    { 23L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2199), 10L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2199), 3L },
                    { 25L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2226), 11L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2227), 7L },
                    { 11L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1921), 5L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1922), 7L },
                    { 24L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2212), 11L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2213), 6L },
                    { 12L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1946), 6L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1947), 4L },
                    { 17L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2063), 8L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2066), 5L },
                    { 8L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1843), 3L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(1844), 5L },
                    { 26L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2240), 12L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2241), 4L },
                    { 21L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2171), 9L, new DateTime(2019, 4, 17, 22, 37, 18, 633, DateTimeKind.Local).AddTicks(2172), 14L }
                });

            migrationBuilder.InsertData(
                schema: "Faculty",
                table: "DepartmentLesson",
                columns: new[] { "DepartmentLessonId", "CreatedDate", "DepartmentId", "LessonId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3146), 1L, 1L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3149) },
                    { 2L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3789), 1L, 2L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3790) },
                    { 3L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3813), 1L, 3L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3814) },
                    { 4L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3828), 1L, 4L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3829) },
                    { 5L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3842), 1L, 5L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3843) },
                    { 6L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3876), 1L, 6L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3877) },
                    { 7L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3891), 1L, 7L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3892) },
                    { 8L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3905), 1L, 8L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3906) },
                    { 9L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3919), 1L, 9L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3920) },
                    { 10L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3934), 1L, 10L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3935) },
                    { 11L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3949), 1L, 11L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3949) },
                    { 12L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3962), 1L, 12L, new DateTime(2019, 4, 17, 22, 37, 18, 634, DateTimeKind.Local).AddTicks(3963) }
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
