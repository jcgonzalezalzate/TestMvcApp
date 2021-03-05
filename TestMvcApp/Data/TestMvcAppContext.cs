using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestMvcApp.Models;

namespace TestMvcApp.Data
{
    public class TestMvcAppContext : DbContext
    {
        public TestMvcAppContext (DbContextOptions<TestMvcAppContext> options)
            : base(options)
        {
        }

        public DbSet<TestMvcApp.Models.TeacherViewModel> TeacherViewModel { get; set; }

        public DbSet<TestMvcApp.Models.StudentsViewModel> StudentsViewModel { get; set; }
    }
}
