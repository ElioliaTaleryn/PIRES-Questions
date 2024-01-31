using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Entity_Framework
{
    public class ApplicationDbContext : IdentityDbContext<UserPerson>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TimerCD> Timers { get; set; }
        public DbSet<UserPerson> UserPersons { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Anonymous> Anonymouses { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            List<Country> countries = AddAllONUCountries();
            List<Gender> genders = AddCommonsGenders();
            List<Status> statuses = AddPresetStatuses();
            List<TimerCD> timerCDs = AddPresetTimerCDs();
            List<UserPerson> userPersons = AddDefaultTestUserPersons();
            List<Form> forms = AddDefaultTestForms();
            List<Question> questions = AddDefaultTestQuestions();
            List<Choice> choices = AddPresetChoices();
            List<Anonymous> anonymouses = AddDefaultAnonymouses();
            List<Answer> answers = AddDefaultAnwers();

            builder.Entity<Country>().HasData(countries);
            builder.Entity<Gender>().HasData(genders);
            builder.Entity<Status>().HasData(statuses);
            builder.Entity<TimerCD>().HasData(timerCDs);
            builder.Entity<UserPerson>().HasData(userPersons);
            builder.Entity<Form>().HasData(forms);
            builder.Entity<Question>().HasData(questions);
            builder.Entity<Choice>().HasData(choices);
            builder.Entity<Anonymous>().HasData(anonymouses);
            builder.Entity<Answer>().HasData(answers);

            base.OnModelCreating(builder);
        }

        private List<Answer> AddDefaultAnwers()
        {
            List<Answer> answers = new();

            // ADD Datas

            return answers;
        }

        private List<Anonymous> AddDefaultAnonymouses()
        {
            List<Anonymous> anonymouses = new();

            anonymouses.Add(new Anonymous() { Id = 1, Age = 18 });
            anonymouses.Add(new Anonymous() { Id = 2, Age = 60 });
            anonymouses.Add(new Anonymous() { Id = 3, Age = 36 });
            anonymouses.Add(new Anonymous() { Id = 4, Age = 42 });

            return anonymouses;
        }

        protected List<Question> AddDefaultTestQuestions()
        {
            List<Question> questions = new();

            Question question1 = new()
            {
                Id = 1,
                Label = "Do you like Paris ?",
                FormId = 2,
                Description = "Choose one answer"
            };

            Question question2 = new()
            {
                Id = 2,
                Label = "How much?",
                FormId = 2,
                Description = "Choose one answer",
                TimerCDId = 1
            };

            questions.Add(question1);
            questions.Add(question2);

            return questions;
        }

        protected List<Form> AddDefaultTestForms()
        {
            List<Form> forms = new();

            Form form1 = new()
            {
                Id = 1,
                Description = "Questions about cities",
                StatusId = 1,
                Title = "Europeans Capitals",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };
            Form form2 = new()
            {
                Id = 2,
                Description = "Questions about cities v2",
                StatusId = 2,
                Title = "Europeans Capitals",
                UserPersonId = "951173f4-7557-4cde-b839-1ac488b30f9f",
            };

            forms.Add(form1);
            forms.Add(form2);

            return forms;
        }
        protected List<UserPerson> AddDefaultTestUserPersons()
        {
            List<UserPerson> userPersons = new();

            UserPerson userPerson1 = new()
            {
                Id = "951173f4-7557-4cde-b839-1ac488b30f9f",
                UserName = "example@example.com",
                NormalizedUserName = "EXAMPLE@EXAMPLE.COM",
                Email = "example@example.com",
                NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
                EmailConfirmed = true,
                DateOfBirth = new DateOnly(1991, 12, 25),
                PasswordHash = "AQAAAAIAAYagAAAAEEtM0G8yJiz5QPiNu4bkpQyhQcMtPWB0EkxiCNV2IGqjriKU7WLoDwvBr6uCjH1+Fg==",
                FirstName = "Michel",
                LastName = "Does",
                SecurityStamp = "2EKLCF5HV2AN7DRFWTAEU5A5MCQ2OOYX",
                ConcurrencyStamp = "514a216a-0c07-4ca1-bae7-25b389afc715",
                AccessFailedCount = 0
            };

            UserPerson userPerson2 = new()
            {
                Id = "981173f4-7557-4cde-b839-1ac488b30f9f",
                UserName = "JohnDoe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateOnly(1991, 12, 25),
            };

            userPersons.Add(userPerson1);
            userPersons.Add(userPerson2);

            return userPersons;
        }

        protected List<TimerCD> AddPresetTimerCDs()
        {
            List<TimerCD> timerCDs = new();

            timerCDs.Add(new TimerCD() { Id = 1, CountDown = 30 });
            timerCDs.Add(new TimerCD() { Id = 2, CountDown = 60 });
            timerCDs.Add(new TimerCD() { Id = 3, CountDown = 90 });
            timerCDs.Add(new TimerCD() { Id = 4, CountDown = 120 });

            return timerCDs;
        }
        protected List<Status> AddPresetStatuses()
        {
            List<Status> statuses = new();

            statuses.Add(new Status() { Id = 1, Label = "In progress" });
            statuses.Add(new Status() { Id = 2, Label = "Validated" });
            statuses.Add(new Status() { Id = 3, Label = "Archived" });

            return statuses;
        }

        protected List<Choice> AddPresetChoices()
        {
            List<Choice> choices = new();

            choices.Add(new Choice() { Id = 1, Label = "Yes", QuestionId = 1 });
            choices.Add(new Choice() { Id = 2, Label = "No", QuestionId = 1 });
            choices.Add(new Choice() { Id = 3, Label = "Unconcerned", QuestionId = 1 });
            choices.Add(new Choice() { Id = 4, Label = "0", QuestionId = 2 });
            choices.Add(new Choice() { Id = 5, Label = "1", QuestionId = 2 });
            choices.Add(new Choice() { Id = 6, Label = "2", QuestionId = 2 });
            choices.Add(new Choice() { Id = 7, Label = "3", QuestionId = 2 });
            choices.Add(new Choice() { Id = 8, Label = "4", QuestionId = 2 });
            choices.Add(new Choice() { Id = 9, Label = "5", QuestionId = 2 });

            return choices;
        }

        protected List<Gender> AddCommonsGenders()
        {
            List<Gender> genders = new();

            genders.Add(new Gender() { Id = 1, Label = "Woman" });
            genders.Add(new Gender() { Id = 2, Label = "Man" });
            genders.Add(new Gender() { Id = 3, Label = "Other" });

            return genders;
        }

        protected List<Country> AddAllONUCountries()
        {
            List<Country> countries = new();

            countries.Add(new Country() { Id = 1, Name = "Afghanistan" });
            countries.Add(new Country() { Id = 2, Name = "Albania" });
            countries.Add(new Country() { Id = 3, Name = "Algeria" });
            countries.Add(new Country() { Id = 4, Name = "Andorra" });
            countries.Add(new Country() { Id = 5, Name = "Angola" });
            countries.Add(new Country() { Id = 6, Name = "Antigua" });
            countries.Add(new Country() { Id = 7, Name = "Argentina" });
            countries.Add(new Country() { Id = 8, Name = "Armenia" });
            countries.Add(new Country() { Id = 9, Name = "Australia" });
            countries.Add(new Country() { Id = 10, Name = "Austria" });
            countries.Add(new Country() { Id = 11, Name = "Azerbaijan" });
            countries.Add(new Country() { Id = 12, Name = "Bahamas" });
            countries.Add(new Country() { Id = 13, Name = "Bahrain" });
            countries.Add(new Country() { Id = 14, Name = "Bangladesh" });
            countries.Add(new Country() { Id = 15, Name = "Barbados" });
            countries.Add(new Country() { Id = 16, Name = "Belarus" });
            countries.Add(new Country() { Id = 17, Name = "Belgium" });
            countries.Add(new Country() { Id = 18, Name = "Belize" });
            countries.Add(new Country() { Id = 19, Name = "Benin" });
            countries.Add(new Country() { Id = 20, Name = "Bhutan" });
            countries.Add(new Country() { Id = 21, Name = "Bolivia" });
            countries.Add(new Country() { Id = 22, Name = "Bosnia" });
            countries.Add(new Country() { Id = 23, Name = "Botswana" });
            countries.Add(new Country() { Id = 24, Name = "Brazil" });
            countries.Add(new Country() { Id = 25, Name = "Brunei Darussalam" });
            countries.Add(new Country() { Id = 26, Name = "Bulgaria" });
            countries.Add(new Country() { Id = 27, Name = "Burkina Faso" });
            countries.Add(new Country() { Id = 28, Name = "Burundi" });
            countries.Add(new Country() { Id = 29, Name = "Cambodia" });
            countries.Add(new Country() { Id = 30, Name = "Cameroon" });
            countries.Add(new Country() { Id = 31, Name = "Canada" });
            countries.Add(new Country() { Id = 32, Name = "Cape Verde" });
            countries.Add(new Country() { Id = 33, Name = "Central African Republic" });
            countries.Add(new Country() { Id = 34, Name = "Chad" });
            countries.Add(new Country() { Id = 35, Name = "Chile" });
            countries.Add(new Country() { Id = 36, Name = "China" });
            countries.Add(new Country() { Id = 37, Name = "Colombia" });
            countries.Add(new Country() { Id = 38, Name = "Comoros" });
            countries.Add(new Country() { Id = 39, Name = "Congo (Republic of the)" });
            countries.Add(new Country() { Id = 40, Name = "Costa Rica" });
            countries.Add(new Country() { Id = 41, Name = "Côte d’Ivoire" });
            countries.Add(new Country() { Id = 42, Name = "Croatia" });
            countries.Add(new Country() { Id = 43, Name = "Cuba" });
            countries.Add(new Country() { Id = 44, Name = "Cyprus" });
            countries.Add(new Country() { Id = 45, Name = "Czech RepubliC" });
            countries.Add(new Country() { Id = 46, Name = "Democratic People’s Republic of Korea" });
            countries.Add(new Country() { Id = 47, Name = "Democratic Republic of the Congo" });
            countries.Add(new Country() { Id = 48, Name = "Denmark" });
            countries.Add(new Country() { Id = 49, Name = "Djibouti" });
            countries.Add(new Country() { Id = 50, Name = "Dominica" });
            countries.Add(new Country() { Id = 51, Name = "Dominican Republic" });
            countries.Add(new Country() { Id = 52, Name = "Ecuador" });
            countries.Add(new Country() { Id = 53, Name = "Egypt" });
            countries.Add(new Country() { Id = 54, Name = "El Salvador" });
            countries.Add(new Country() { Id = 55, Name = "Equatorial Guinea" });
            countries.Add(new Country() { Id = 56, Name = "Eritrea" });
            countries.Add(new Country() { Id = 57, Name = "Estonia" });
            countries.Add(new Country() { Id = 58, Name = "Ethiopia" });
            countries.Add(new Country() { Id = 59, Name = "Fiji" });
            countries.Add(new Country() { Id = 60, Name = "Finland" });
            countries.Add(new Country() { Id = 61, Name = "France" });
            countries.Add(new Country() { Id = 62, Name = "Gabon" });
            countries.Add(new Country() { Id = 63, Name = "Gambia" });
            countries.Add(new Country() { Id = 64, Name = "Georgia" });
            countries.Add(new Country() { Id = 65, Name = "Germany" });
            countries.Add(new Country() { Id = 66, Name = "Ghana" });
            countries.Add(new Country() { Id = 67, Name = "Greece" });
            countries.Add(new Country() { Id = 68, Name = "Grenada" });
            countries.Add(new Country() { Id = 69, Name = "Guatemala" });
            countries.Add(new Country() { Id = 70, Name = "Guinea" });
            countries.Add(new Country() { Id = 71, Name = "Guinea-Bissau" });
            countries.Add(new Country() { Id = 72, Name = "Guyana" });
            countries.Add(new Country() { Id = 73, Name = "Haiti" });
            countries.Add(new Country() { Id = 74, Name = "Honduras" });
            countries.Add(new Country() { Id = 75, Name = "Hungary" });
            countries.Add(new Country() { Id = 76, Name = "Iceland" });
            countries.Add(new Country() { Id = 77, Name = "India" });
            countries.Add(new Country() { Id = 78, Name = "Indonesia" });
            countries.Add(new Country() { Id = 79, Name = "Iran" });
            countries.Add(new Country() { Id = 80, Name = "Iraq" });
            countries.Add(new Country() { Id = 81, Name = "Ireland" });
            countries.Add(new Country() { Id = 82, Name = "Israel" });
            countries.Add(new Country() { Id = 83, Name = "Italy" });
            countries.Add(new Country() { Id = 84, Name = "Jamaica" });
            countries.Add(new Country() { Id = 85, Name = "Japan" });
            countries.Add(new Country() { Id = 86, Name = "Jordan" });
            countries.Add(new Country() { Id = 87, Name = "Kazakhstan" });
            countries.Add(new Country() { Id = 88, Name = "Kenya" });
            countries.Add(new Country() { Id = 89, Name = "Kiribati" });
            countries.Add(new Country() { Id = 90, Name = "Kuwait" });
            countries.Add(new Country() { Id = 91, Name = "Kyrgyzstan" });
            countries.Add(new Country() { Id = 92, Name = "Lao People's Democratic Republic" });
            countries.Add(new Country() { Id = 93, Name = "Latvia" });
            countries.Add(new Country() { Id = 94, Name = "Lebanon" });
            countries.Add(new Country() { Id = 95, Name = "Lesotho" });
            countries.Add(new Country() { Id = 96, Name = "Liberia" });
            countries.Add(new Country() { Id = 97, Name = "Libya" });
            countries.Add(new Country() { Id = 98, Name = "Liechtenstein" });
            countries.Add(new Country() { Id = 99, Name = "Lithuania" });
            countries.Add(new Country() { Id = 100, Name = "Luxembourg" });
            countries.Add(new Country() { Id = 101, Name = "Madagascar" });
            countries.Add(new Country() { Id = 102, Name = "Malawi" });
            countries.Add(new Country() { Id = 103, Name = "Malaysia" });
            countries.Add(new Country() { Id = 104, Name = "Maldives" });
            countries.Add(new Country() { Id = 105, Name = "Mali" });
            countries.Add(new Country() { Id = 106, Name = "Malta" });
            countries.Add(new Country() { Id = 107, Name = "Marshall Islands" });
            countries.Add(new Country() { Id = 108, Name = "Mauritania" });
            countries.Add(new Country() { Id = 109, Name = "Mauritius" });
            countries.Add(new Country() { Id = 110, Name = "Mexico" });
            countries.Add(new Country() { Id = 111, Name = "Micronesia (Federated States of)" });
            countries.Add(new Country() { Id = 112, Name = "Monaco" });
            countries.Add(new Country() { Id = 113, Name = "Mongolia" });
            countries.Add(new Country() { Id = 114, Name = "Montenegro" });
            countries.Add(new Country() { Id = 115, Name = "Morocco" });
            countries.Add(new Country() { Id = 116, Name = "Mozambique" });
            countries.Add(new Country() { Id = 117, Name = "Myanmar" });
            countries.Add(new Country() { Id = 118, Name = "Namibia" });
            countries.Add(new Country() { Id = 119, Name = "Nauru" });
            countries.Add(new Country() { Id = 120, Name = "Nepal" });
            countries.Add(new Country() { Id = 121, Name = "Netherlands" });
            countries.Add(new Country() { Id = 122, Name = "New Zealand" });
            countries.Add(new Country() { Id = 123, Name = "Nicaragua" });
            countries.Add(new Country() { Id = 124, Name = "Niger" });
            countries.Add(new Country() { Id = 125, Name = "Nigeria" });
            countries.Add(new Country() { Id = 126, Name = "Norway" });
            countries.Add(new Country() { Id = 127, Name = "Oman" });
            countries.Add(new Country() { Id = 128, Name = "Pakistan" });
            countries.Add(new Country() { Id = 129, Name = "Palau" });
            countries.Add(new Country() { Id = 130, Name = "Panama" });
            countries.Add(new Country() { Id = 131, Name = "Papua New Guinea" });
            countries.Add(new Country() { Id = 132, Name = "Paraguay" });
            countries.Add(new Country() { Id = 133, Name = "Peru" });
            countries.Add(new Country() { Id = 134, Name = "Philippines" });
            countries.Add(new Country() { Id = 135, Name = "Poland" });
            countries.Add(new Country() { Id = 136, Name = "Portugal" });
            countries.Add(new Country() { Id = 137, Name = "Qatar" });
            countries.Add(new Country() { Id = 138, Name = "Republic of Korea" });
            countries.Add(new Country() { Id = 139, Name = "Republic of Moldova" });
            countries.Add(new Country() { Id = 140, Name = "Romania" });
            countries.Add(new Country() { Id = 141, Name = "Russian Federation" });
            countries.Add(new Country() { Id = 142, Name = "Rwanda" });
            countries.Add(new Country() { Id = 143, Name = "Saint Kitts and Nevis" });
            countries.Add(new Country() { Id = 144, Name = "Saint Lucia" });
            countries.Add(new Country() { Id = 145, Name = "Saint Vincent and the Grenadines" });
            countries.Add(new Country() { Id = 146, Name = "Samoa" });
            countries.Add(new Country() { Id = 147, Name = "San Marino" });
            countries.Add(new Country() { Id = 148, Name = "Sao Tome and Principe" });
            countries.Add(new Country() { Id = 149, Name = "Saudi Arabia" });
            countries.Add(new Country() { Id = 150, Name = "Senegal" });
            countries.Add(new Country() { Id = 151, Name = "Serbia" });
            countries.Add(new Country() { Id = 152, Name = "Seychelles" });
            countries.Add(new Country() { Id = 153, Name = "Sierra Leone" });
            countries.Add(new Country() { Id = 154, Name = "Singapore" });
            countries.Add(new Country() { Id = 155, Name = "Slovakia" });
            countries.Add(new Country() { Id = 156, Name = "Slovenia" });
            countries.Add(new Country() { Id = 157, Name = "Solomon Islands" });
            countries.Add(new Country() { Id = 158, Name = "Somalia" });
            countries.Add(new Country() { Id = 159, Name = "South Africa" });
            countries.Add(new Country() { Id = 160, Name = "Spain" });
            countries.Add(new Country() { Id = 161, Name = "Sri Lanka" });
            countries.Add(new Country() { Id = 162, Name = "Sudan" });
            countries.Add(new Country() { Id = 163, Name = "Suriname" });
            countries.Add(new Country() { Id = 164, Name = "Swaziland" });
            countries.Add(new Country() { Id = 165, Name = "Switzerland" });
            countries.Add(new Country() { Id = 166, Name = "Sweden" });
            countries.Add(new Country() { Id = 167, Name = "Syria" });
            countries.Add(new Country() { Id = 168, Name = "Tajikistan" });
            countries.Add(new Country() { Id = 169, Name = "Thailand" });
            countries.Add(new Country() { Id = 170, Name = "The former Yugoslav Republic of Macedonia" });
            countries.Add(new Country() { Id = 171, Name = "Timor Leste" });
            countries.Add(new Country() { Id = 172, Name = "Togo" });
            countries.Add(new Country() { Id = 173, Name = "Tonga" });
            countries.Add(new Country() { Id = 174, Name = "Trinidad and Tobago" });
            countries.Add(new Country() { Id = 175, Name = "Tunisia" });
            countries.Add(new Country() { Id = 176, Name = "Turkey" });
            countries.Add(new Country() { Id = 177, Name = "Turkmenistan" });
            countries.Add(new Country() { Id = 178, Name = "Tuvalu" });
            countries.Add(new Country() { Id = 179, Name = "Uganda" });
            countries.Add(new Country() { Id = 180, Name = "Ukraine" });
            countries.Add(new Country() { Id = 181, Name = "United Arab Emirates" });
            countries.Add(new Country() { Id = 182, Name = "United Kingdom" });
            countries.Add(new Country() { Id = 183, Name = "United of Republic of Tanzania" });
            countries.Add(new Country() { Id = 184, Name = "United States" });
            countries.Add(new Country() { Id = 185, Name = "Uruguay" });
            countries.Add(new Country() { Id = 186, Name = "Uzbekistan" });
            countries.Add(new Country() { Id = 187, Name = "Vanuatu" });
            countries.Add(new Country() { Id = 188, Name = "Venezuela" });
            countries.Add(new Country() { Id = 189, Name = "Viet Nam" });
            countries.Add(new Country() { Id = 190, Name = "Yemen" });
            countries.Add(new Country() { Id = 191, Name = "Zambia" });
            countries.Add(new Country() { Id = 192, Name = "Zimbabwe" });

            return countries;
        }
    }
}
