﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Asr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asr.Data
{
    public static class SeedData
    {

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roles = new[] { Constants.StaffRole, Constants.StudentRole };

            using (var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>())
            using (var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>())
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                foreach (var role in roles)
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole { Name = role });


                await CreateUserAndEnsureUserHasRole(userManager, "e12345", "Matt", "e12345@rmit.edu.au");
                await CreateUserAndEnsureUserHasRole(userManager, "e56789", "See", "e56789@rmit.edu.au");
                await CreateUserAndEnsureUserHasRole(userManager, "s1234567", "Example", "s1234567@student.rmit.edu.au");
                await CreateUserAndEnsureUserHasRole(userManager, "s4567890", "Sample", "s4567890@student.rmit.edu.au");
                InitialiseAsrData(context, userManager);
            }

        }

        private static async Task CreateUserAndEnsureUserHasRole(
            UserManager<AppUser> userManager, string id, string name, string email)
        {
            var role = id.StartsWith('e') ? Constants.StaffRole : Constants.StudentRole;

            //TODO What really is user manager? and what does having AppUser as generic do?
            if (userManager.FindByIdAsync(id) == null)
                await userManager.CreateAsync(new AppUser { Id = id, UserName = name, Email = email }, "abc123");
            await EnsureUserHasRole(userManager, id, role);
        }

        private static async Task EnsureUserHasRole(
            UserManager<AppUser> userManager, string id, string role)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null && await userManager.IsInRoleAsync(user, role))
                await userManager.AddToRoleAsync(user, role);
        }




        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>())
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                InitiliaseUsers(userManager);
                InitialiseAsrData(context, userManager);
            }
        }

        private static void InitiliaseUsers(UserManager<AppUser> userManager)
        {
            // Look for any users.
            if (userManager.Users.Any())
                return; // DB has been seeded.

            CreateUser(userManager, "e12345@rmit.edu.au");
            CreateUser(userManager, "e56789@rmit.edu.au");
            CreateUser(userManager, "s1234567@student.rmit.edu.au");
            CreateUser(userManager, "s4567890@student.rmit.edu.au");
        }

        private static void CreateUser(UserManager<AppUser> userManager, string userName) =>
            userManager.CreateAsync(new AppUser { UserName = userName, Email = userName }, "abc123").Wait();

        private static void InitialiseAsrData(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            // Look for any rooms.
            if (context.Room.Any())
                return; // DB has been seeded.

            context.Room.AddRange(
                new Room { RoomID = "A" },
                new Room { RoomID = "B" },
                new Room { RoomID = "C" },
                new Room { RoomID = "D" }
            );

            CreateStaff(context, "e12345", "Matt");
            CreateStaff(context, "e56789", "Matt");

            CreateStudent(context, "s1234567", "Kevin");
            CreateStudent(context, "s4567890", "Olivier");

            context.Slot.AddRange(
                new Slot
                {
                    RoomID = "A",
                    StartTime = new DateTime(2019, 1, 30),
                    StaffID = "e12345"
                },
                new Slot
                {
                    RoomID = "B",
                    StartTime = new DateTime(2019, 1, 30),
                    StaffID = "e56789",
                    StudentID = "s1234567"
                }
            );

            context.SaveChanges();

            UpdateUser(userManager, "e12345@rmit.edu.au", "e12345");
            UpdateUser(userManager, "e56789@rmit.edu.au", "e56789");
            UpdateUser(userManager, "s1234567@student.rmit.edu.au", "s1234567");
            UpdateUser(userManager, "s4567890@student.rmit.edu.au", "s4567890");
        }

        private static void CreateStaff(ApplicationDbContext context, string id, string name)
        {
            context.Staff.Add(new Staff
            {
                StaffID = id,
                Email = id + "@rmit.edu.au",
                Name = name
            });
        }

        private static void CreateStudent(ApplicationDbContext context, string id, string name)
        {
            context.Student.Add(new Student
            {
                StudentID = id,
                Email = id + "@student.rmit.edu.au",
                Name = name
            });
        }

        private static void UpdateUser(UserManager<AppUser> userManager, string userName, string id)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            if (user.UserName.StartsWith('e'))
                user.StaffID = id;
            if (user.UserName.StartsWith('s'))
                user.StudentID = id;

            userManager.UpdateAsync(user).Wait();
        }


    }
}
