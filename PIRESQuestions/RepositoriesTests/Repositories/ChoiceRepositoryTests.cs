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
    public class ChoiceRepositoryTests
    {
        [TestMethod()]
        public async Task CreateChoiceAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            Choice choice1 = new Choice { Id = 1, Label = "reponse A : oui", QuestionId = 1 };

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            //Act
            var choice = await choiceRepository.CreateChoiceAsync(choice1);

            //Assert
            Assert.AreEqual("reponse A : oui", choice.Label);
        }
        [TestMethod()]
        public async Task CreateChoiceAsyncTestIdAutoIncrement()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            Choice choice1 = new Choice { Id = 0, Label = "reponse A : oui", QuestionId = 1 };

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            //Act
            var choice = await choiceRepository.CreateChoiceAsync(choice1);

            //Assert
            Assert.AreEqual(1, choice.Id);
        }

        [TestMethod()]
        public async Task GetAllChoiceAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui", QuestionId = 1 });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : oui", QuestionId = 1 });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: non", QuestionId = 2 });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre", QuestionId = 2 });

            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            //Act
            var choices = await choiceRepository.GetAllChoiceAsync();

            //Assert
            Assert.IsNotNull(choices);
            Assert.AreEqual(4, choices.Count());
        }

        [TestMethod()]
        public async Task GetChoiceByIdAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui", QuestionId = 1 });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : oui", QuestionId = 1 });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: non", QuestionId = 2 });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre", QuestionId = 2 });

            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            //Act
            var choice = await choiceRepository.GetChoiceByIdAsync(3);

            //Assert
            Assert.IsNotNull(choice);
            Assert.AreEqual(3, choice.Id);
        }

        [TestMethod()]
        public async Task UpdateChoiceAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui", QuestionId = 1 });
            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            Choice choiceUpdate = new Choice { Id = 1, Label = "reponse A : non", QuestionId = 1 };

            //Act
            await choiceRepository.UpdateChoiceAsync(choiceUpdate);

            var choiceConfirmed = await context.Choices.FindAsync(1);

            //Assert
            Assert.AreEqual("reponse A : non", choiceConfirmed.Label);
        }
        [TestMethod()]
        public async Task UpdateChoiceAsyncTestQuestionId()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui", QuestionId = 1 });
            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            Choice choiceUpdate = new Choice { Id = 1, Label = "reponse A : non", QuestionId = 3 };

            //Act
            await choiceRepository.UpdateChoiceAsync(choiceUpdate);

            var choiceConfirmed = await context.Choices.FindAsync(1);

            //Assert
            Assert.AreEqual(3, choiceConfirmed.QuestionId);
        }

        [TestMethod()]
        public async Task DeleteChoiceAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui", QuestionId = 1 });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : oui", QuestionId = 1 });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: non", QuestionId = 2 });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre", QuestionId = 2 });

            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            //Act
            await choiceRepository.DeleteChoiceAsync(3);

            //Assert
            var choiceDeleted = await context.Choices.FindAsync(3);
            Assert.IsNull(choiceDeleted);
        }
    }
}