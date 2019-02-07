using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mvc02.Models.Entities;

namespace Mvc02.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mvc02.Models.Entities.Product> Product { get; set; }
        public DbSet<Mvc02.Models.Entities.Category> Category { get; set; }
        public DbSet<Mvc02.Models.Entities.Admin> Admin { get; set; }
    }
}
