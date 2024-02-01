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
            Choice choice1 = new Choice { Id = 1, Label = "reponse A : oui" };

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
            Choice choice1 = new Choice { Id = 0, Label = "reponse A : oui" };

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
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui" });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : oui" });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: non" });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre" });

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
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui" });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : oui" });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: non" });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre" });

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
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui" });
            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            Choice choiceUpdate = new Choice { Id = 1, Label = "reponse A : non" };

            //Act
            await choiceRepository.UpdateChoiceAsync(choiceUpdate);

            var choiceConfirmed = await context.Choices.FindAsync(1);

            //Assert
            Assert.AreEqual("reponse A : non", choiceConfirmed.Label);
        }

        [TestMethod()]
        public async Task DeleteChoiceAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui" });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : oui" });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: non" });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre" });

            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            //Act
            await choiceRepository.DeleteChoiceAsync(3);

            //Assert
            var choiceDeleted = await context.Choices.FindAsync(3);
            Assert.IsNull(choiceDeleted);
        }

        [TestMethod()]
        public async Task GetChoicesByIdsAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui" });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : oui" });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: non" });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre" });

            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);
            List<int> choiceIds = new List<int>() { 1, 2, 3, 4 };
            //Act
            var choice = await choiceRepository.GetChoicesByIdsAsync(choiceIds);

            //Assert
            Assert.IsNotNull(choice);
            Assert.AreEqual(4, choice.Count());
        }

        [TestMethod()]
        public async Task GetChoicesByIdQuestionAsyncTest()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("choice");

            var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureDeleted();


            context.Choices.Add(new Choice { Id = 1, Label = "reponse A : oui", Questions = new List<Question> { new Question { Id = 1, FormId = 1, Label = "test" } } });
            context.Choices.Add(new Choice { Id = 2, Label = "reponse B : non", Questions = new List<Question> { new Question { Id = 2, FormId = 1, Label = "test" } } });
            context.Choices.Add(new Choice { Id = 3, Label = "reponse C: test", Questions = new List<Question> { new Question { Id = 3, FormId = 1, Label = "test" } } });
            context.Choices.Add(new Choice { Id = 4, Label = "reponse D : peut-etre", Questions = new List<Question> { new Question { Id = 4, FormId = 1, Label = "test" } } });

            context.SaveChanges();

            ChoiceRepository choiceRepository = new ChoiceRepository(context);

            // Act
            var choices = await choiceRepository.GetChoicesByIdQuestionAsync(2);

            // Assert
            Assert.IsNotNull(choices);
            Assert.AreEqual(1, choices.Count);            
        }
    }
}