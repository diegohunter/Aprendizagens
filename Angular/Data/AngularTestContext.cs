using Angular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Data
{
    public class AngularTestContext : DbContext
    {
        public AngularTestContext(DbContextOptions<AngularTestContext> optionsBuilder) : base(optionsBuilder)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
