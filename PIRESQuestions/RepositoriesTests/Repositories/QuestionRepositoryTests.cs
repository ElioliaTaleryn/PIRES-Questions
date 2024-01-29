using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    public class QuestionRepositoryTests
    {
        [TestMethod()]
        public async Task CreateQuestionAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            Question question1 = new Question { Id = 1, Label = "question test 1 ?", FormId = 1 };

            QuestionRepository questionRepository = new QuestionRepository(context);

            //Act
            var question = await questionRepository.CreateQuestionAsync(question1);

            //Assert
            Assert.AreEqual("question test 1 ?", question.Label);
        }

        [TestMethod()]
        public async Task CreateQuestionAsyncTestIdAutoIncrement()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            Question question1 = new Question { Id = 0, Label = "question test 1 ?", FormId = 1 };

            QuestionRepository questionRepository = new QuestionRepository(context);

            //Act
            var question = await questionRepository.CreateQuestionAsync(question1);

            //Assert
            Assert.AreEqual(1, question.Id);
        }

        [TestMethod()]
        public async Task GetAllQuestionsAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Questions.Add(new Question { Id = 1, Label = "question test 1 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 2, Label = "question test 2 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 3, Label = "question test 3 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 4, Label = "question test 4 ?", FormId = 1 });
            context.Forms.Add(new Form { Id = 1, CategoryId = 1, Description = "test test", StatusId = 1, Title = "test", UserPersonId = "1" });

            context.SaveChanges();

            QuestionRepository questionRepository = new QuestionRepository(context);

            //Act
            var questions = await questionRepository.GetAllQuestionsAsync();

            //Assert
            Assert.IsNotNull(questions);
            Assert.AreEqual(4, questions.Count());
        }

        [TestMethod()]
        public async Task DeleteQuestionAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Questions.Add(new Question { Id = 1, Label = "question test 1 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 2, Label = "question test 2 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 3, Label = "question test 3 ?", FormId = 2 });
            context.Questions.Add(new Question { Id = 4, Label = "question test 4 ?", FormId = 2 });

            context.SaveChanges();

            QuestionRepository questionRepository = new QuestionRepository(context);

            //Act
            await questionRepository.DeleteQuestionAsync(4);

            //Assert
            var questionDeleted = await context.Questions.FindAsync(4);
            Assert.IsNull(questionDeleted);

        }

        [TestMethod()]
        public async Task GetQuestionByIdAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Questions.Add(new Question { Id = 1, Label = "question test 1 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 2, Label = "question test 2 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 3, Label = "question test 3 ?", FormId = 2 });
            context.Questions.Add(new Question { Id = 4, Label = "question test 4 ?", FormId = 2 });

            context.SaveChanges();

            QuestionRepository questionRepository = new QuestionRepository(context);

            //Act
            var question = await questionRepository.GetQuestionByIdAsync(2);

            //Assert
            Assert.AreEqual(2, question.Id);
        }

        [TestMethod()]
        public async Task UpdateQuestionAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();

            context.Questions.Add(new Question { Id = 1, Label = "question test 1 ?", FormId = 1 });
            context.SaveChanges();

            QuestionRepository questionRepository = new QuestionRepository(context);

            Question questionUpdate = new Question { Id = 1, Label = "nouveau label", FormId = 1 };

            //Act
            await questionRepository.UpdateQuestionAsync(questionUpdate);

            var questionConfirmed = await context.Questions.FindAsync(1);

            //Assert
            Assert.AreEqual("nouveau label", questionConfirmed.Label);
        }
        [TestMethod()]
        public async Task UpdateQuestionAsyncTestFormId()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();

            context.Questions.Add(new Question { Id = 1, Label = "question test 1 ?", FormId = 1 });
            context.SaveChanges();

            QuestionRepository questionRepository = new QuestionRepository(context);

            Question questionUpdate = new Question { Id = 1, Label = "nouveau label", FormId = 2 };

            //Act
            await questionRepository.UpdateQuestionAsync(questionUpdate);

            var questionConfirmed = await context.Questions.FindAsync(1);

            //Assert
            Assert.AreEqual(2, questionConfirmed.FormId);
        }

        [TestMethod()]
        public async Task GetQuestionByFormIdAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Questions.Add(new Question { Id = 1, Label = "question test 1 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 2, Label = "question test 2 ?", FormId = 1 });
            context.Questions.Add(new Question { Id = 3, Label = "question test 3 ?", FormId = 2 });
            context.Questions.Add(new Question { Id = 4, Label = "question test 4 ?", FormId = 2 });
            context.Forms.Add(new Form { Id = 1, CategoryId = 1, Description = "test test", StatusId = 1, Title = "test", UserPersonId = "1" });

            context.SaveChanges();

            QuestionRepository questionRepository = new QuestionRepository(context);

            //Act
            var questions = await questionRepository.GetQuestionByFormIdAsync(1);

            //Assert
            Assert.IsNotNull(questions);
            Assert.AreEqual(2, questions.Count());
        }

        [TestMethod()]
        public async Task CreateQuestionWithChoiceAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("question");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            Question question1 = new Question { Id = 1, Label = "question test 1 ?", FormId = 1 };
            List<Choice> choices = new List<Choice>
            {
                new Choice { Id = 1, Label = "reponse A" , QuestionId = question1.Id},
                new Choice {Id = 2, Label = "reponse B", QuestionId = question1.Id }
            };

            QuestionRepository questionRepository = new QuestionRepository(context);

            //Act
            var question = await questionRepository.CreateQuestionWithChoiceAsync(question1, choices);

            //Assert
            Assert.AreEqual("question test 1 ?", question.Label);
            Assert.AreEqual(2, question.Choices.Count());
        }
    }
}