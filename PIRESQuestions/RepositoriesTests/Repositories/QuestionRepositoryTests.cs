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
            context.Questions.Add(new Question { Id = 3, Label = "question test 3 ?", FormId = 2 });
            context.Questions.Add(new Question { Id = 4, Label = "question test 4 ?", FormId = 2 });

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
    }
}