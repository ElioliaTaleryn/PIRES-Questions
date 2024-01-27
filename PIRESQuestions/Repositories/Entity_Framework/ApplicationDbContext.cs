using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Repositories.Entity_Framework
{
    public class ApplicationDbContext : IdentityDbContext<UserPerson>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserPerson> UserPersons { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Choice> Choices { get; set; }
        
        public DbSet<TimerCD> Timers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            Category category1 = new() { Id = 1, Label = "Travel" };
            Category category2 = new() { Id = 2, Label = "Food" };
            List<Category> categories = new List<Category>() {category1,category2};

            Country country1 = new() { Id = 1, Name = "France" };
            Country country2 = new() { Id = 2, Name = "Spain" };
            List<Country> countries = new List<Country>() { country1, country2 };

            Period period1 = new() { Id = 1, Start = new DateTime(2024, 02, 11, 10, 50, 0), End = new DateTime(2024, 02, 20, 17, 30, 0) };
            Period period2 = new() { Id = 2, Start = new DateTime(2024, 01, 01, 5, 30, 0), End = new DateTime(2024, 12, 31, 23, 59, 59) };
            List<Period> periods = new List<Period>() { period1, period2 };

            Status status1 = new() { Id = 1, Label = "In progress" };
            Status status2 = new() { Id = 2, Label = "Validated" };
            Status status3 = new() { Id = 3, Label = "Archived" };
            List<Status> statuses = new List<Status>() { status1, status2, status3 };

            Gender gender1 = new() { Id = 1, Label = "Woman" };
            Gender gender2 = new() { Id = 2, Label = "Man" };
            Gender gender3 = new() { Id = 3, Label = "Other" };
            List<Gender> genders = new List<Gender>() { gender1, gender2, gender3 };

            UserPerson userPerson1 = new()
            {
                Id = "981173f4-7557-4cde-b839-1ac488b30f9f",
                UserName = "JohnDoe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateOnly(1991, 12, 25),
                FirstName = "Michel",
                LastName = "Does",
                GenderId = 2,
                CountryId = 1
            };

            var hasher = new PasswordHasher<IdentityRole>();
            UserPerson userPerson2 = new()
            {
                Id = "951173f4-7557-4cde-b839-1ac488b30f9f",
                UserName = "example@example.com",
                NormalizedUserName = "EXAMPLE@EXAMPLE.COM",
                Email = "example@example.com",
                NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
                EmailConfirmed=true,
                DateOfBirth = new DateOnly(1991, 12, 25),
                PasswordHash = "AQAAAAIAAYagAAAAEEtM0G8yJiz5QPiNu4bkpQyhQcMtPWB0EkxiCNV2IGqjriKU7WLoDwvBr6uCjH1+Fg==",
                FirstName = "Michel",
                LastName = "Does",
                GenderId = 2,
                CountryId = 1,
                SecurityStamp = "2EKLCF5HV2AN7DRFWTAEU5A5MCQ2OOYX",
                ConcurrencyStamp = "514a216a-0c07-4ca1-bae7-25b389afc715",
                AccessFailedCount = 0
            };

            List<UserPerson> userPersons = new List<UserPerson>() { userPerson1, userPerson2 };

            Form form1 = new()
            {
                Id = 1,
                CategoryId = 1,
                Description = "Questions about cities",
                StatusId = 2,
                Title = "Europeans Capitals",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
                PeriodId = 1
            };
            Form form2 = new()
            {
                Id = 2,
                CategoryId = 1,
                Description = "Questions about cities v2",
                StatusId = 2,
                Title = "Europeans Capitals",
                UserPersonId = "951173f4-7557-4cde-b839-1ac488b30f9f",
                PeriodId = 1
            };
            List<Form> forms = new List<Form>() { form1, form2 };

            Question question1 = new() { Id = 1, Label = "Witch city is the French Capital", FormId = 2, Description = "choose 1 reply" };
            Question question2 = new() { Id = 2, Label = "What is the color of the sky", FormId = 2, Description = "choose 1 reply", TimerCDId=1 };
            List<Question> questions = new List<Question>() { question1, question2 };

            Choice choice1 = new() { Id = 1, Label = "Paris", QuestionId = 1 };
            Choice choice2 = new() { Id = 2, Label = "Bordeau", QuestionId = 1 };
            Choice choice3 = new() { Id = 3, Label = "Red", QuestionId = 2 };
            Choice choice4 = new() { Id = 4, Label = "Cyan", QuestionId = 2 };
            List<Choice> choices = new List<Choice>() { choice1, choice2, choice3, choice4 };

            TimerCD timerCD1 = new TimerCD() { Id = 1, CountDown=90};
            List<TimerCD> timers = new List<TimerCD>() { timerCD1};
            
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Period>().HasData(periods);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<Gender>().HasData(genders);
            modelBuilder.Entity<UserPerson>().HasData(userPersons);
            modelBuilder.Entity<Form>().HasData(forms);
            modelBuilder.Entity<Question>().HasData(questions);
            modelBuilder.Entity<Choice>().HasData(choices);
            modelBuilder.Entity<TimerCD>().HasData(timers);


            base.OnModelCreating(modelBuilder);
        }
    }
}
