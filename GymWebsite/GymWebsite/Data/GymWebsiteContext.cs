using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GymWebsite.Data
{
    public class GymWebsiteContext : IdentityDbContext
    {
        public GymWebsiteContext (DbContextOptions<GymWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<GymWebsite.Model.UserProfile> UserProfile { get; set; }

        public DbSet<GymWebsite.Model.TrainingBlock> TrainingBlock { get; set; }

        public DbSet<GymWebsite.Model.Workout> Workout { get; set; }

        public DbSet<GymWebsite.Model.Exercise> Exercise { get; set; }

        public DbSet<GymWebsite.Model.User> User { get; set; }
    }
}
