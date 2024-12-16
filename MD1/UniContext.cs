using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;
using Microsoft.IdentityModel.Protocols;

namespace UniversityClasses
{
    public class UniContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Submission> Submission { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = "";
            cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;       // panācu, ka strādā App.config risinājums ar sekojošā resursa palīdzību (2. atbilde):
                                                                                        // https://stackoverflow.com/questions/19239314/how-can-i-get-a-connection-string-from-a-text-file
            optionsBuilder.UseSqlServer(cs);
        }

    }
}
