using System;
using System.Collections.Generic;
using System.Text;
using Asr.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asr.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Slot> Slot { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Room> Room { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Slot>()
                .HasKey(x => new { x.RoomID, x.StartTime });
        }

    }
}
