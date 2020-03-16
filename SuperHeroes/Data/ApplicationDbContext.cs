using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Models;

namespace SuperHeroes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
