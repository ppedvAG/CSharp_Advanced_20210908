using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMovie.Share.Entites;

namespace MyMovie.Service.Data
{
    public class MovieDbContext : DbContext //DbContext ist eine Klasse aus EF Core 
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyMovie.Share.Entites.Movie> Movie { get; set; }
    }
}
