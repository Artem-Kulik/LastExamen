namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class TestModel : DbContext
    {
        public TestModel()
            : base("name=TestModel")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Temperament> Temperaments { get; set; }
        public virtual DbSet<Result> Results { get; set; }
    }


    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Admin { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }

        public int SanguinePercent { get; set; }
        public int PhlegmaticPercent { get; set; }
        public int CholericPercent { get; set; }
        public int MelancholicPercent { get; set; }
                
        public int? UserId { get; set; }


        public virtual User User { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int TemperamentId { get; set; }
        public int? TemperamentAntonimID { get; set; }

        public virtual Temperament Temperament { get; set; }
    }

    public class Temperament
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}