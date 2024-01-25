using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Entity_Framework
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Period> Durations { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TimerCD> Timers { get; set; }
        public DbSet<UserPerson> UserPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=PIRESQuestionsDB;Integrated Security=True");
                base.OnConfiguring(optionsBuilder);
            }
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Category category1 = new() { Id = 1, Label = "Travel" };
            Category category2 = new() { Id = 2, Label = "Food" };
            List<Category> categories = new List<Category>() {category1,category2};

            Choice choice1 = new(){ Id = 1, Label = "Paris", QuestionId = 1 };
            Choice choice2 = new(){ Id = 2, Label = "Bordeau", QuestionId = 1 };
            Choice choice3 = new(){ Id = 3, Label = "Red", QuestionId = 2 };
            Choice choice4 = new(){ Id = 4, Label = "Cyan", QuestionId = 2 };
            List<Choice> choices = new List<Choice>() { choice1, choice2, choice3, choice4};

            Country country1 = new() { Id = 1, Name = "France" };
            Country country2 = new() { Id = 2, Name = "Spain" };
            List<Country> countries = new List<Country>() {country1, country2};

            Period period1 = new() { Id = 1, Start = new DateTime(2024, 02, 11, 10, 50, 0), End = new DateTime(2024, 02, 20, 17, 30, 0) };
            Period period2 = new() { Id = 2, Start = new DateTime(2024, 01, 01, 5, 30, 0), End = new DateTime(2024, 12, 31, 23, 59, 59) };
            List<Period> periods = new List<Period>() {period1,period2};

            Status status1 = new() { Id = 1, Label = "In progress" };
            Status status2 = new() { Id = 2, Label = "Validated" };
            Status status3 = new() { Id = 3, Label = "Archived" };
            List<Status> statuses = new List<Status>() { status1, status2, status3 };

            Gender gender1 = new() { Id = 1, Label = "Woman" };
            Gender gender2 = new() { Id = 2, Label = "Man" };
            Gender gender3 = new() { Id = 3, Label = "Other" };
            List<Gender> genders = new List<Gender>() { gender1, gender2, gender3 };

            UserPerson userPerson1 = new() { Id = "951173f4-7557-4cde-b839-1ac488b30f9f", DateOfBirth = new DateOnly(1991, 12, 25),
                FirstName="Michel", LastName="Does", GenderId=2, CountryId=1 };
            List<UserPerson> userPersons = new List<UserPerson>();

            
            Form form1 = new() { Id = 1, CategoryId = 1, Description = "Questions about cities", StatusId = 2,
                Title = "Europeans Capitals", UserPersonId = "951173f4-7557-4cde-b839-1ac488b30f9f", PeriodId = 1};
            List<Form> forms = new List<Form>() { form1 };

            Question question1 = new() { Id = 1, Label = "Witch city is the French Capital", FormId = 1, Description = "choose 1 reply" };
            Question question2 = new() { Id = 2, Label = "What is the color of the sky", FormId = 1, Description = "choose 1 reply" };
            List<Question> questions = new List<Question>() { question1, question2 };

            
            List<TimerCD> timers = new List<TimerCD>();

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Choice>().HasData(choices);
            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Period>().HasData(periods);
            modelBuilder.Entity<Form>().HasData(forms);
            modelBuilder.Entity<Gender>().HasData(genders);
            modelBuilder.Entity<Question>().HasData(questions);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<TimerCD>().HasData(timers);
            modelBuilder.Entity<UserPerson>().HasData(userPersons);

            base.OnModelCreating(modelBuilder);
        }
    }
}
