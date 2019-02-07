using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Repetition.Models;
using MVC_Repetition.Models.Entities;

namespace MVC_Repetition.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MVC_Repetition.Models.Dog> Dog { get; set; }
        public DbSet<MVC_Repetition.Models.Owner> Owner { get; set; }
        public DbSet<MVC_Repetition.Models.Entities.Test> Test { get; set; }
    }
}
