using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class MainProjectContext:DbContext
    {
        public MainProjectContext(DbContextOptions<MainProjectContext>options):base(options)
        {

        }

        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<ReimbursementData> ReimbursementDatas { get; set; }
    }
}
