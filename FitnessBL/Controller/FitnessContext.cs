using FitnessBL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Controller
{
    public class FitnessContext : DbContext
    {
        //public FitnessContext() : base("DBConnection") { }
        public FitnessContext() { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eating { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get;set;}
        public DbSet<User> Users { get; set; }



    }
}
