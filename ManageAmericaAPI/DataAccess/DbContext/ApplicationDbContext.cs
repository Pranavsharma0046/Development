using ManageAmericaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
          : base(options)
        {
        }
        public DbSet<ManagerModel> Manager { get; set; }
        public DbSet<ScheduledTourModel> TourDetail { get; set; }
        public DbSet<PropertyModel> Property { get; set; }
        public DbSet<AvailablityModel> Availablity { get; set; }
        public DbSet<Reccurence> Reccurence { get; set; }

    }
}
