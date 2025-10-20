using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidatesTestProject.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Users - Password for all: "qwerty123"
            var admin1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var admin2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var admin3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "Login", "PasswordHash", "Role", "CreatedAt", "RefreshToken", "RefreshTokenExpiryTime" },
                values: new object[,]
                {
                    { admin1Id, "Admin User One", "admin1", "$2a$11$EzJTX5FXtdZtGw0mMREoUOOhe5EQP/uePhjF76zh9PagFgAwFKmV.", "Admin", DateTime.UtcNow, null, null },
                    { admin2Id, "Admin User Two", "admin2", "$2a$11$EzJTX5FXtdZtGw0mMREoUOOhe5EQP/uePhjF76zh9PagFgAwFKmV.", "Admin", DateTime.UtcNow, null, null },
                    { admin3Id, "Admin User Three", "admin3", "$2a$11$EzJTX5FXtdZtGw0mMREoUOOhe5EQP/uePhjF76zh9PagFgAwFKmV.", "Admin", DateTime.UtcNow, null, null }
                });

            // CandidateData for Candidates
            var candidateData1Id = Guid.Parse("c1111111-1111-1111-1111-111111111111");
            var candidateData2Id = Guid.Parse("c2222222-2222-2222-2222-222222222222");
            var candidateData3Id = Guid.Parse("c3333333-3333-3333-3333-333333333333");
            var candidateData4Id = Guid.Parse("c4444444-4444-4444-4444-444444444444");
            var candidateData5Id = Guid.Parse("c5555555-5555-5555-5555-555555555555");
            var candidateData6Id = Guid.Parse("c6666666-6666-6666-6666-666666666666");
            var candidateData7Id = Guid.Parse("c7777777-7777-7777-7777-777777777777");
            var candidateData8Id = Guid.Parse("c8888888-8888-8888-8888-888888888888");
            var candidateData9Id = Guid.Parse("c9999999-9999-9999-9999-999999999999");
            var candidateData10Id = Guid.Parse("c1010101-1010-1010-1010-101010101010");
            var candidateData11Id = Guid.Parse("c2111111-1111-1111-1111-111111111111");
            var candidateData12Id = Guid.Parse("c1212121-1212-1212-1212-121212121121");

            migrationBuilder.InsertData(
                table: "CandidateData",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName", "Email", "Phone", "Country", "DateOfBirth" },
                values: new object[,]
                {
                    { candidateData1Id, "Иван", "Иванов", "Иванович", "ivan.ivanov@example.com", "+79001234567", "Russia", new DateOnly(1990, 5, 15) },
                    { candidateData2Id, "Петр", "Петров", "Петрович", "petr.petrov@example.com", "+79002345678", "Russia", new DateOnly(1992, 8, 20) },
                    { candidateData3Id, "Анна", "Сидорова", null, "anna.sidorova@example.com", "+79003456789", "Russia", new DateOnly(1995, 3, 10) },
                    { candidateData4Id, "Мария", "Васильева", "Александровна", "maria.vasilyeva@example.com", "+79004567890", "Russia", new DateOnly(1993, 11, 25) },
                    { candidateData5Id, "Алексей", "Смирнов", "Викторович", "alexey.smirnov@example.com", "+79005678901", "Russia", new DateOnly(1991, 7, 30) },
                    { candidateData6Id, "Ольга", "Козлова", null, "olga.kozlova@example.com", "+79006789012", "Russia", new DateOnly(1994, 2, 14) },
                    { candidateData7Id, "Дмитрий", "Новиков", "Сергеевич", "dmitry.novikov@example.com", "+79007890123", "Russia", new DateOnly(1988, 12, 5) },
                    { candidateData8Id, "Дмитрий", "Новиков", "Олегович", "dmitry.novikov_o@example.com", "+79091890123", "Russia", new DateOnly(1984, 09, 5) },
                    { candidateData9Id, "Дмитрий", "Новиков", "Петрович", "dmitry.novikov_p@example.com", "+79091890123", "Russia", new DateOnly(1983, 02, 5) },
                    { candidateData10Id, "Дмитрий", "Новиков", "Михайлович", "dmitry.novikov_m@example.com", "+79091810123", "Russia", new DateOnly(1983, 02, 5) },
                    { candidateData11Id, "Дмитрий", "Новиков", "Иванович", "dmitry.novikov_i@example.com", "+79891890123", "Russia", new DateOnly(1983, 02, 5) },
                    { candidateData12Id, "Дмитрий", "Новиков", "Петрович", "dmitry.novikov_p@example.com", "+79092890123", "Russia", new DateOnly(1983, 02, 5) },
                });

            // Candidates
            var candidate1Id = Guid.Parse("ca111111-1111-1111-1111-111111111111");
            var candidate2Id = Guid.Parse("ca222222-2222-2222-2222-222222222222");
            var candidate3Id = Guid.Parse("ca333333-3333-3333-3333-333333333333");
            var candidate4Id = Guid.Parse("ca444444-4444-4444-4444-444444444444");
            var candidate5Id = Guid.Parse("ca555555-5555-5555-5555-555555555555");
            var candidate6Id = Guid.Parse("ca666666-6666-6666-6666-666666666666");
            var candidate7Id = Guid.Parse("ca777777-7777-7777-7777-777777777777");
            var candidate8Id = Guid.Parse("ca888888-8888-8888-8888-888888888888");
            var candidate9Id = Guid.Parse("ca999999-9999-9999-9999-999999999999");
            var candidate10Id = Guid.Parse("ca101010-1010-1010-1010-101010101010");
            var candidate11Id = Guid.Parse("ca211111-1111-1111-1111-111111111111");
            var candidate12Id = Guid.Parse("ca121212-1212-1212-1212-121212121212");


            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "CandidateDataId", "LastUpdatedAt", "WorkSchedule", "CreatedByUserId" },
                values: new object[,]
                {
                    { candidate1Id, candidateData1Id, DateTime.UtcNow.AddDays(-5), 0, admin1Id },  // Office
                    { candidate2Id, candidateData2Id, DateTime.UtcNow.AddDays(-3), 1, admin1Id },  // Hybrid
                    { candidate3Id, candidateData3Id, DateTime.UtcNow.AddDays(-7), 2, admin2Id },  // Remote
                    { candidate4Id, candidateData4Id, DateTime.UtcNow.AddDays(-1), 1, admin2Id },  // Hybrid
                    { candidate5Id, candidateData5Id, DateTime.UtcNow.AddDays(-10), 2, admin3Id },  // Remote
                    { candidate6Id, candidateData6Id, DateTime.UtcNow.AddDays(-92), 2, admin3Id },  // Remote
                    { candidate7Id, candidateData7Id, DateTime.UtcNow.AddDays(-100), 2, admin3Id },  // Remote
                    { candidate8Id, candidateData8Id, DateTime.UtcNow.AddDays(-100), 0, admin3Id },  // Office
                    { candidate9Id, candidateData9Id, DateTime.UtcNow.AddDays(-100), 1, admin3Id },  // Hybrid
                    { candidate10Id, candidateData10Id, DateTime.UtcNow.AddDays(-100), 0, admin3Id },  // Office
                    { candidate11Id, candidateData11Id, DateTime.UtcNow.AddDays(-100), 1, admin3Id },  // Hybrid
                    { candidate12Id, candidateData12Id, DateTime.UtcNow.AddDays(-100), 0, admin3Id }  // Office
                });

            // Social Networks for Candidates
            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "CandidateDataId", "Username", "Type", "AddedAt" },
                values: new object[,]
                {
                    { Guid.NewGuid(), candidateData1Id, "ivan_ivanov", 0, DateTime.UtcNow },     // LinkedIn
                    { Guid.NewGuid(), candidateData1Id, "ivan_ivanov_gh", 1, DateTime.UtcNow },  // GitHub
                    { Guid.NewGuid(), candidateData2Id, "petr.petrov", 0, DateTime.UtcNow },     // LinkedIn
                    { Guid.NewGuid(), candidateData2Id, "petrpetrov", 5, DateTime.UtcNow },     // Telegram
                    { Guid.NewGuid(), candidateData3Id, "anna_sidorova", 0, DateTime.UtcNow },   // LinkedIn
                    { Guid.NewGuid(), candidateData3Id, "anna_s", 1, DateTime.UtcNow },         // GitHub
                    { Guid.NewGuid(), candidateData4Id, "maria_vas", 2, DateTime.UtcNow },      // Twitter
                    { Guid.NewGuid(), candidateData5Id, "alexey_smirnov", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), candidateData5Id, "alex_smirn", 1, DateTime.UtcNow },      // GitHub
                    { Guid.NewGuid(), candidateData6Id, "olga_kozlova", 0, DateTime.UtcNow },   // LinkedIn
                    { Guid.NewGuid(), candidateData6Id, "olga_kozlova_tg", 5, DateTime.UtcNow }, // Telegram
                    { Guid.NewGuid(), candidateData7Id, "dmitry_novikov", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), candidateData7Id, "dmitry_novikov_gh", 1, DateTime.UtcNow }, // GitHub
                    { Guid.NewGuid(), candidateData8Id, "dmitry_novikov_o", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), candidateData8Id, "dmitry_novikov_o_tg", 5, DateTime.UtcNow }, // Telegram
                    { Guid.NewGuid(), candidateData9Id, "dmitry_novikov_p", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), candidateData9Id, "dmitry_novikov_p_gh", 1, DateTime.UtcNow }, // GitHub
                    { Guid.NewGuid(), candidateData10Id, "dmitry_novikov_m", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), candidateData10Id, "dmitry_novikov_m_gh", 1, DateTime.UtcNow }, // GitHub
                    { Guid.NewGuid(), candidateData11Id, "dmitry_novikov_i", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), candidateData11Id, "dmitry_novikov_i_gh", 1, DateTime.UtcNow }, // GitHub
                    { Guid.NewGuid(), candidateData12Id, "dmitry_novikov_p", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), candidateData12Id, "dmitry_novikov_p_gh", 1, DateTime.UtcNow }, // GitHub
                });

            // CandidateData for Employees
            var employeeData1Id = Guid.Parse("e1111111-1111-1111-1111-111111111111");
            var employeeData2Id = Guid.Parse("e2222222-2222-2222-2222-222222222222");
            var employeeData3Id = Guid.Parse("e3333333-3333-3333-3333-333333333333");
            var employeeData4Id = Guid.Parse("e4444444-4444-4444-4444-444444444444");
            var employeeData5Id = Guid.Parse("e5555555-5555-5555-5555-555555555555");

            migrationBuilder.InsertData(
                table: "CandidateData",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName", "Email", "Phone", "Country", "DateOfBirth" },
                values: new object[,]
                {
                    { employeeData1Id, "Сергей", "Соколов", "Михайлович", "sergey.sokolov@company.com", "+79008901234", "Russia", new DateOnly(1985, 4, 18) },
                    { employeeData2Id, "Елена", "Морозова", "Игоревна", "elena.morozova@company.com", "+79009012345", "Russia", new DateOnly(1987, 9, 22) },
                    { employeeData3Id, "Андрей", "Павлов", null, "andrey.pavlov@company.com", "+79000123456", "Russia", new DateOnly(1989, 6, 12) },
                    { employeeData4Id, "Татьяна", "Федорова", "Олеговна", "tatyana.fedorova@company.com", "+79001234560", "Russia", new DateOnly(1990, 1, 8) },
                    { employeeData5Id, "Дмитрий", "Новиков", "Олегович", "dmitry.novikov_o@company.com", "+79035234560", "Russia", new DateOnly(1990, 1, 8) }
                });

            // Employees
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CandidateDataId", "HireDate" },
                values: new object[,]
                {
                    { Guid.Parse("ea111111-1111-1111-1111-111111111111"), employeeData1Id, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { Guid.Parse("ea222222-2222-2222-2222-222222222222"), employeeData2Id, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { Guid.Parse("ea333333-3333-3333-3333-333333333333"), employeeData3Id, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { Guid.Parse("ea444444-4444-4444-4444-444444444444"), employeeData4Id, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { Guid.Parse("ea555555-5555-5555-5555-555555555555"), employeeData5Id, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc) }

                });

            // Social Networks for Employees
            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "CandidateDataId", "Username", "Type", "AddedAt" },
                values: new object[,]
                {
                    { Guid.NewGuid(), employeeData1Id, "sergey_sokolov", 0, DateTime.UtcNow },  // LinkedIn
                    { Guid.NewGuid(), employeeData2Id, "elena.morozova", 0, DateTime.UtcNow },  // LinkedIn
                    { Guid.NewGuid(), employeeData2Id, "elena_mor", 1, DateTime.UtcNow },       // GitHub
                    { Guid.NewGuid(), employeeData3Id, "andrey_pavlov", 0, DateTime.UtcNow },   // LinkedIn
                    { Guid.NewGuid(), employeeData4Id, "tatyana_f", 0, DateTime.UtcNow },        // LinkedIn
                    { Guid.NewGuid(), employeeData5Id, "dmitry_novikov_o", 0, DateTime.UtcNow }, // LinkedIn
                    { Guid.NewGuid(), employeeData5Id, "dmitry_novikov_o_gh", 1, DateTime.UtcNow }, // GitHub
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateData",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    Guid.Parse("c1111111-1111-1111-1111-111111111111"),
                    Guid.Parse("c2222222-2222-2222-2222-222222222222"),
                    Guid.Parse("c3333333-3333-3333-3333-333333333333"),
                    Guid.Parse("c4444444-4444-4444-4444-444444444444"),
                    Guid.Parse("c5555555-5555-5555-5555-555555555555"),
                    Guid.Parse("c6666666-6666-6666-6666-666666666666"),
                    Guid.Parse("c7777777-7777-7777-7777-777777777777"),
                    Guid.Parse("c8888888-8888-8888-8888-888888888888"),
                    Guid.Parse("c9999999-9999-9999-9999-999999999999"),
                    Guid.Parse("c1010101-1010-1010-1010-101010101010"),
                    Guid.Parse("c1111111-1111-1111-1111-111111111111"),
                    Guid.Parse("c1212121-1212-1212-1212-121212121121")
                });

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    Guid.Parse("ca111111-1111-1111-1111-111111111111"),
                    Guid.Parse("ca222222-2222-2222-2222-222222222222"),
                    Guid.Parse("ca333333-3333-3333-3333-333333333333"),
                    Guid.Parse("ca444444-4444-4444-4444-444444444444"),
                    Guid.Parse("ca555555-5555-5555-5555-555555555555"),
                    Guid.Parse("ca666666-6666-6666-6666-666666666666"),
                    Guid.Parse("ca777777-7777-7777-7777-777777777777"),
                    Guid.Parse("ca888888-8888-8888-8888-888888888888"),
                    Guid.Parse("ca999999-9999-9999-9999-999999999999"),
                    Guid.Parse("ca101010-1010-1010-1010-101010101010"),
                    Guid.Parse("ca211111-1111-1111-1111-111111111111"),
                    Guid.Parse("ca121212-1212-1212-1212-121212121212")
                });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Guid.Parse("33333333-3333-3333-3333-333333333333")
                });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    Guid.Parse("ea111111-1111-1111-1111-111111111111"),
                    Guid.Parse("ea222222-2222-2222-2222-222222222222"),
                    Guid.Parse("ea333333-3333-3333-3333-333333333333"),
                    Guid.Parse("ea444444-4444-4444-4444-444444444444"),
                    Guid.Parse("ea555555-5555-5555-5555-555555555555")
                });
        }
    }
}
