using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Entity_Framework;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Tests
{
    [TestClass()]
    public class AnswerRepositoryTests
    {
        [TestMethod()]
        public async Task CreateAnswerAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("answer");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            Answer answer1 = new Answer { Id = 1, Horodatage = DateTime.Now, QuestionId = 12, ChoiceId = 1, AnonymousId = 1 };

            AnswerRepository answerRepository = new AnswerRepository(context);

            //Act 
            var answer = await answerRepository.CreateAnswerAsync(answer1);

            //Assert
            Assert.AreEqual(12, answer.QuestionId);
        }

        [TestMethod()]
        public async Task CreateAnswerAsyncTestIdAutoIncrement()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("answer");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            Answer answer1 = new Answer { Id = 0, Horodatage = DateTime.Now, QuestionId = 12, ChoiceId = 1, AnonymousId = 1 };

            AnswerRepository answerRepository = new AnswerRepository(context);

            //Act 
            var answer = await answerRepository.CreateAnswerAsync(answer1);

            //Assert
            Assert.AreEqual(1, answer.Id);
        }

        [TestMethod()]
        public async Task GetAllAnswerAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("answer");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Answers.Add(new Answer { Id = 1, Horodatage = DateTime.Now, QuestionId = 12, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 2, Horodatage = DateTime.Now, QuestionId = 1, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 3, Horodatage = DateTime.Now, QuestionId = 2, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 4, Horodatage = DateTime.Now, QuestionId = 10, ChoiceId = 1, AnonymousId = 1 });

            context.SaveChanges();
            AnswerRepository answerRepository = new AnswerRepository(context);

            //Act
            var answers = await answerRepository.GetAllAnswerAsync();

            //Assert
            Assert.IsNotNull(answers);
            Assert.AreEqual(4, answers.Count());
        }

        [TestMethod()]
        public async Task GetAnswerByIdAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("answer");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Answers.Add(new Answer { Id = 1, Horodatage = DateTime.Now, QuestionId = 12, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 2, Horodatage = DateTime.Now, QuestionId = 1, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 3, Horodatage = DateTime.Now, QuestionId = 2, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 4, Horodatage = DateTime.Now, QuestionId = 10, ChoiceId = 1, AnonymousId = 1 });

            context.SaveChanges();
            AnswerRepository answerRepository = new AnswerRepository(context);

            //Act
            var answers = await answerRepository.GetAnswerByIdAsync(3);

            //Assert
            Assert.AreEqual(3, answers.Id);
        }

        [TestMethod()]
        public async Task GetAnswerByChoiceAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("answer");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Answers.Add(new Answer { Id = 1, Horodatage = DateTime.Now, QuestionId = 12, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 2, Horodatage = DateTime.Now, QuestionId = 1, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 3, Horodatage = DateTime.Now, QuestionId = 2, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 4, Horodatage = DateTime.Now, QuestionId = 10, ChoiceId = 1, AnonymousId = 1 });

            context.SaveChanges();
            AnswerRepository answerRepository = new AnswerRepository(context);

            //Act
            var answers = await answerRepository.GetAnswerByChoiceAsync(1);

            //Assert
            Assert.IsNotNull(answers);
            Assert.AreEqual(4, answers.Count());
        }

        [TestMethod()]
        public async Task GetAnswerByGenderAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("answer");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Genders.Add(new Gender { Id = 1, Label = "masculin" });
            context.Genders.Add(new Gender { Id = 2, Label = "feminin" });
            context.Anonymouses.Add(new Anonymous { Id = 1, Age = 30, GenderId = 1, });
            context.Anonymouses.Add(new Anonymous { Id = 2, Age = 30, GenderId = 2, });
            context.Answers.Add(new Answer { Id = 1, Horodatage = DateTime.Now, QuestionId = 12, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 2, Horodatage = DateTime.Now, QuestionId = 1, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 3, Horodatage = DateTime.Now, QuestionId = 2, ChoiceId = 1, AnonymousId = 2 });
            context.Answers.Add(new Answer { Id = 4, Horodatage = DateTime.Now, QuestionId = 10, ChoiceId = 1, AnonymousId = 2 });
            
            

            context.SaveChanges();
            AnswerRepository answerRepository = new AnswerRepository(context);

            //Act
            var answers = await answerRepository.GetAnswerByGenderAsync(2);

            //Assert
            Assert.IsNotNull(answers);
            Assert.AreEqual(2, answers.Count());
        }

        [TestMethod()]
        public async Task DeleteAnswerAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("answer");
            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Answers.Add(new Answer { Id = 1, Horodatage = DateTime.Now, QuestionId = 12, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 2, Horodatage = DateTime.Now, QuestionId = 1, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 3, Horodatage = DateTime.Now, QuestionId = 2, ChoiceId = 1, AnonymousId = 1 });
            context.Answers.Add(new Answer { Id = 4, Horodatage = DateTime.Now, QuestionId = 10, ChoiceId = 1, AnonymousId = 1 });

            context.SaveChanges();

            AnswerRepository answerRepository = new AnswerRepository(context);

            //Act
            await answerRepository.DeleteAnswerAsync(1);

            //Assert
            var answerDeleted = await context.Answers.FindAsync(1);
            Assert.IsNull(answerDeleted);
        }
    }
}