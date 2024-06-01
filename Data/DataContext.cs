using Microsoft.EntityFrameworkCore;
using SeaKids.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SeaKids.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Curiosidade> Curiosidades { get; set; }
        public DbSet<Video> Videos { get; set; }


    }
}

