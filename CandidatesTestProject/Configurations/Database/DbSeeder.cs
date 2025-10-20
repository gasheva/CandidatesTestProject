using CandidatesTestProject.Database;
using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTestProject.Configurations.Database;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db, CancellationToken ct = default)
        {
            // Users
            var admin1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var admin2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var admin3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var bcryptHash = "$2a$11$EzJTX5FXtdZtGw0mMREoUOOhe5EQP/uePhjF76zh9PagFgAwFKmV.";
            var nowUtc = DateTime.UtcNow;

            await EnsureUserAsync(db, new User
            {
                Id = admin1Id,
                FullName = "Admin User One",
                Login = "admin1",
                PasswordHash = bcryptHash,
                Role = "Admin",
                CreatedAt = nowUtc,
                RefreshToken = null,
                RefreshTokenExpiryTime = null
            }, ct);

            await EnsureUserAsync(db, new User
            {
                Id = admin2Id,
                FullName = "Admin User Two",
                Login = "admin2",
                PasswordHash = bcryptHash,
                Role = "Admin",
                CreatedAt = nowUtc,
                RefreshToken = null,
                RefreshTokenExpiryTime = null
            }, ct);

            await EnsureUserAsync(db, new User
            {
                Id = admin3Id,
                FullName = "Admin User Three",
                Login = "admin3",
                PasswordHash = bcryptHash,
                Role = "Admin",
                CreatedAt = nowUtc,
                RefreshToken = null,
                RefreshTokenExpiryTime = null
            }, ct);

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

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData1Id,
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                Email = "ivan.ivanov@example.com",
                Phone = "+79001234567",
                Country = "Russia",
                DateOfBirth = new DateOnly(1990, 5, 15)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData2Id,
                FirstName = "Петр",
                LastName = "Петров",
                MiddleName = "Петрович",
                Email = "petr.petrov@example.com",
                Phone = "+79002345678",
                Country = "Russia",
                DateOfBirth = new DateOnly(1992, 8, 20)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData3Id,
                FirstName = "Анна",
                LastName = "Сидорова",
                MiddleName = null,
                Email = "anna.sidorova@example.com",
                Phone = "+79003456789",
                Country = "Russia",
                DateOfBirth = new DateOnly(1995, 3, 10)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData4Id,
                FirstName = "Мария",
                LastName = "Васильева",
                MiddleName = "Александровна",
                Email = "maria.vasilyeva@example.com",
                Phone = "+79004567890",
                Country = "Russia",
                DateOfBirth = new DateOnly(1993, 11, 25)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData5Id,
                FirstName = "Алексей",
                LastName = "Смирнов",
                MiddleName = "Викторович",
                Email = "alexey.smirnov@example.com",
                Phone = "+79005678901",
                Country = "Russia",
                DateOfBirth = new DateOnly(1991, 7, 30)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData6Id,
                FirstName = "Ольга",
                LastName = "Козлова",
                MiddleName = null,
                Email = "olga.kozlova@example.com",
                Phone = "+79006789012",
                Country = "Russia",
                DateOfBirth = new DateOnly(1994, 2, 14)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData7Id,
                FirstName = "Дмитрий",
                LastName = "Новиков",
                MiddleName = "Сергеевич",
                Email = "dmitry.novikov@example.com",
                Phone = "+79007890123",
                Country = "Russia",
                DateOfBirth = new DateOnly(1988, 12, 5)
            }, ct);
            
            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData8Id,
                FirstName = "Дмитрий",
                LastName = "Новиков",
                MiddleName = "Олегович",
                Email = "dmitry_oleg.novikov@example.com",
                Phone = "+79007830123",
                Country = "Russia",
                DateOfBirth = new DateOnly(1983, 12, 5)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = candidateData9Id,
                FirstName = "Дмитрий",
                LastName = "Новиков",
                MiddleName = "Петрович",
                Email = "dmitry_petrov.novikov@example.com",
                Phone = "+79017830123",
                Country = "Russia",
                DateOfBirth = new DateOnly(1983, 12, 5)
            }, ct);

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

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate1Id,
                CandidateDataId = candidateData1Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-5),
                WorkSchedule = WorkSchedule.Office, 
                CreatedByUserId = admin1Id
            }, ct);

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate2Id,
                CandidateDataId = candidateData2Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-3),
                WorkSchedule = WorkSchedule.Hybrid,
                CreatedByUserId = admin1Id
            }, ct);

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate3Id,
                CandidateDataId = candidateData3Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-7),
                WorkSchedule = WorkSchedule.Remote,
                CreatedByUserId = admin2Id
            }, ct);

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate4Id,
                CandidateDataId = candidateData4Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-1),
                WorkSchedule = WorkSchedule.Hybrid,
                CreatedByUserId = admin2Id
            }, ct);

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate5Id,
                CandidateDataId = candidateData5Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-10),
                WorkSchedule = WorkSchedule.Remote, 
                CreatedByUserId = admin3Id
            }, ct);

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate6Id,
                CandidateDataId = candidateData6Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-90),
                WorkSchedule = WorkSchedule.Remote, 
                CreatedByUserId = admin3Id
            }, ct);

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate7Id,
                CandidateDataId = candidateData7Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-100),
                WorkSchedule = WorkSchedule.Remote, 
                CreatedByUserId = admin3Id
            }, ct);
            
            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate8Id,
                CandidateDataId = candidateData8Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-100),
                WorkSchedule = WorkSchedule.Remote, 
                CreatedByUserId = admin3Id
            }, ct);

            await EnsureCandidateAsync(db, new Candidate
            {
                Id = candidate9Id,
                CandidateDataId = candidateData9Id,
                LastUpdatedAt = DateTime.UtcNow.AddDays(-100),
                WorkSchedule = WorkSchedule.Office, 
                CreatedByUserId = admin3Id
            }, ct);
            
            // Social Networks for Candidates
            await EnsureSocialAsync(db, candidateData1Id, "ivan_ivanov", SocialNetworkType.LinkedIn, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData1Id, "ivan_ivanov_gh", SocialNetworkType.GitHub, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData2Id, "petr.petrov", SocialNetworkType.LinkedIn, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData2Id, "petrpetrov", SocialNetworkType.Telegram, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData3Id, "anna_sidorova", SocialNetworkType.LinkedIn, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData3Id, "anna_s", SocialNetworkType.GitHub, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData4Id, "maria_vas", SocialNetworkType.Twitter, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData5Id, "alexey_smirnov", SocialNetworkType.LinkedIn, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData5Id, "alex_smirn", SocialNetworkType.GitHub, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData6Id, "olga_kozlova", SocialNetworkType.LinkedIn, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData6Id, "olga_kozlova_tg", SocialNetworkType.Telegram, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData7Id, "dmitry_novikov", SocialNetworkType.LinkedIn, nowUtc, ct);
            await EnsureSocialAsync(db, candidateData7Id, "dmitry_novikov_gh", SocialNetworkType.GitHub, nowUtc, ct);

            // CandidateData for Employees
            var employeeData1Id = Guid.Parse("e1111111-1111-1111-1111-111111111111");
            var employeeData2Id = Guid.Parse("e2222222-2222-2222-2222-222222222222");
            var employeeData3Id = Guid.Parse("e3333333-3333-3333-3333-333333333333");
            var employeeData4Id = Guid.Parse("e4444444-4444-4444-4444-444444444444");
            var employeeData5Id = Guid.Parse("e5555555-5555-5555-5555-555555555555");

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = employeeData1Id,
                FirstName = "Сергей",
                LastName = "Соколов",
                MiddleName = "Михайлович",
                Email = "sergey.sokolov@company.com",
                Phone = "+79008901234",
                Country = "Russia",
                DateOfBirth = new DateOnly(1985, 4, 18)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = employeeData2Id,
                FirstName = "Елена",
                LastName = "Морозова",
                MiddleName = "Игоревна",
                Email = "elena.morozova@company.com",
                Phone = "+79009012345",
                Country = "Russia",
                DateOfBirth = new DateOnly(1987, 9, 22)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = employeeData3Id,
                FirstName = "Андрей",
                LastName = "Павлов",
                MiddleName = null,
                Email = "andrey.pavlov@company.com",
                Phone = "+79000123456",
                Country = "Russia",
                DateOfBirth = new DateOnly(1989, 6, 12)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = employeeData4Id,
                FirstName = "Татьяна",
                LastName = "Федорова",
                MiddleName = "Олеговна",
                Email = "tatyana.fedorova@company.com",
                Phone = "+79001234560",
                Country = "Russia",
                DateOfBirth = new DateOnly(1990, 1, 8)
            }, ct);

            await EnsureCandidateDataAsync(db, new CandidateData
            {
                Id = employeeData5Id,
                FirstName = "Дмитрий",
                LastName = "Новиков",
                MiddleName = "",
                Email = "dmitry_novikov@company.com",
                Phone = "+79035234560",
                Country = "Russia",
                DateOfBirth = new DateOnly(1990, 1, 8)
            }, ct);

            // Employees
            await EnsureEmployeeAsync(db, new Employee
            {
                Id = Guid.Parse("ea111111-1111-1111-1111-111111111111"),
                CandidateDataId = employeeData1Id,
                HireDate = new DateTime(2020, 3, 1, 0, 0, 0, DateTimeKind.Utc)
            }, ct);

            await EnsureEmployeeAsync(db, new Employee
            {
                Id = Guid.Parse("ea222222-2222-2222-2222-222222222222"),
                CandidateDataId = employeeData2Id,
                HireDate = new DateTime(2021, 5, 15, 0, 0, 0, DateTimeKind.Utc)
            }, ct);

            await EnsureEmployeeAsync(db, new Employee
            {
                Id = Guid.Parse("ea333333-3333-3333-3333-333333333333"),
                CandidateDataId = employeeData3Id,
                HireDate = new DateTime(2022, 8, 20, 0, 0, 0, DateTimeKind.Utc)
            }, ct);

            await EnsureEmployeeAsync(db, new Employee
            {
                Id = Guid.Parse("ea444444-4444-4444-4444-444444444444"),
                CandidateDataId = employeeData4Id,
                HireDate = new DateTime(2023, 2, 10, 0, 0, 0, DateTimeKind.Utc)
            }, ct);

             await EnsureEmployeeAsync(db, new Employee
            {
                Id = Guid.Parse("ea555555-5555-5555-5555-555555555555"),
                CandidateDataId = employeeData5Id,
                HireDate = new DateTime(2023, 2, 10, 0, 0, 0, DateTimeKind.Utc)
            }, ct);

            await db.SaveChangesAsync(ct);
        }

        private static async Task EnsureUserAsync(ApplicationDbContext db, User user, CancellationToken ct)
        {
            var exists = await db.Users.AnyAsync(u => u.Id == user.Id, ct);
            if (!exists)
            {
                if (!await db.Users.AnyAsync(u => u.Login == user.Login, ct))
                    db.Users.Add(user);
            }
        }

        private static async Task EnsureCandidateDataAsync(ApplicationDbContext db, CandidateData data, CancellationToken ct)
        {
            var exists = await db.CandidateData.AnyAsync(cd => cd.Id == data.Id, ct);
            if (!exists)
            {
                if (!await db.CandidateData.AnyAsync(cd => cd.Email == data.Email, ct))
                    db.CandidateData.Add(data);
            }
        }

        private static async Task EnsureCandidateAsync(ApplicationDbContext db, Candidate candidate, CancellationToken ct)
        {
            var exists = await db.Candidates.AnyAsync(c => c.Id == candidate.Id, ct);
            if (!exists)
            {
                // Check both in DB and in ChangeTracker (local cache)
                var candidateDataExists = await db.CandidateData.AnyAsync(cd => cd.Id == candidate.CandidateDataId, ct) 
                    || db.CandidateData.Local.Any(cd => cd.Id == candidate.CandidateDataId);
                
                if (!candidateDataExists)
                    throw new InvalidOperationException($"Missing CandidateData {candidate.CandidateDataId} for Candidate {candidate.Id}");

                db.Candidates.Add(candidate);
            }
        }

        private static async Task EnsureEmployeeAsync(ApplicationDbContext db, Employee employee, CancellationToken ct)
        {
            var exists = await db.Employees.AnyAsync(e => e.Id == employee.Id, ct);
            if (!exists)
            {
                // Check both in DB and in ChangeTracker (local cache)
                var candidateDataExists = await db.CandidateData.AnyAsync(cd => cd.Id == employee.CandidateDataId, ct)
                    || db.CandidateData.Local.Any(cd => cd.Id == employee.CandidateDataId);
                
                if (!candidateDataExists)
                    throw new InvalidOperationException($"Missing CandidateData {employee.CandidateDataId} for Employee {employee.Id}");

                db.Employees.Add(employee);
            }
        }

        private static async Task EnsureSocialAsync(
            ApplicationDbContext db,
            Guid candidateDataId,
            string username,
            SocialNetworkType type,
            DateTime addedAtUtc,
            CancellationToken ct)
        {
            var exists = await db.SocialNetworks.AnyAsync(
                s => s.CandidateDataId == candidateDataId && s.Username == username && (s.Type == type),
                ct);

            if (!exists)
            {
                // Check both in DB and in ChangeTracker (local cache)
                var candidateDataExists = await db.CandidateData.AnyAsync(cd => cd.Id == candidateDataId, ct)
                    || db.CandidateData.Local.Any(cd => cd.Id == candidateDataId);
                
                if (!candidateDataExists)
                    throw new InvalidOperationException($"Missing CandidateData {candidateDataId} for SocialNetwork {username}");

                db.SocialNetworks.Add(new SocialNetwork
                {
                    Id = Guid.NewGuid(),
                    CandidateDataId = candidateDataId,
                    Username = username,
                    Type = type,
                    AddedAt = addedAtUtc
                });
            }
        }
}