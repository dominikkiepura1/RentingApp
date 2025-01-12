﻿using Microsoft.EntityFrameworkCore;
using RentingApp.Models;

namespace RentingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<CarVersion> CarVersions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
