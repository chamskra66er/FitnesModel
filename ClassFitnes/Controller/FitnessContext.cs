﻿using System.Data.Entity;
using ClassFitnes.Model;

namespace ClassFitnes.Controller
{
    class FitnessContext:DbContext
    {
        public FitnessContext() : base("DbConnection") { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
