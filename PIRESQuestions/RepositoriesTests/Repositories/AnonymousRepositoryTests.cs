using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using IRepositories;

namespace Repositories.Repositories.Tests
{
    [TestClass()]
    public class AnonymousRepositoryTests
    {
        private readonly ApplicationDbContext context;
        private readonly AnonymousRepository anonymousRepository;

        private readonly DbConnection connection;
        public AnonymousRepositoryTests()
        {
            SQLitePCL.Batteries.Init();
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options;

            context = new ApplicationDbContext(options);
            anonymousRepository = new(context);
        }

        [TestInitialize]
        public void Init()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
        #region Create
        [TestMethod()]
        public async Task CreateAnonymousAsync_ValidId_Succeeds()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = 18 };

            // Act
            var createdAnonymous = await anonymousRepository.CreateAnonymousAsync(anonymous);

            // Asserts
            Assert.IsNotNull(createdAnonymous);

            Assert.AreEqual(5, createdAnonymous.Id);
        }
        [TestMethod]
        public async Task CreateAnonymousAsync_MinValueAge_ThrowsException()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = int.MinValue };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<AnonymousRepositoryException>(() => anonymousRepository.CreateAnonymousAsync(anonymous));
        }
        [TestMethod]
        public async Task CreateAnonymousAsync_NegativeAge_ThrowsException()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = -1 };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<AnonymousRepositoryException>(() => anonymousRepository.CreateAnonymousAsync(anonymous));
        }
        [TestMethod]
        public async Task CreateAnonymousAsync_TooHigherAge_ThrowsException()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = 126 };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<AnonymousRepositoryException>(() => anonymousRepository.CreateAnonymousAsync(anonymous));
        }
        #endregion
        #region Delete
        [TestMethod()]
        public async Task DeleteAnonymousAsync_ValidId_Succeeds()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = 18 };

            // Act
            Anonymous deletedAnonymous = await anonymousRepository.CreateAnonymousAsync(anonymous);
            await anonymousRepository.DeleteAnonymousAsync(anonymous);

            // Assert
            Assert.IsNotNull(deletedAnonymous);
            bool anonymousExists = await context.Anonymouses.Where(a => a.Id == deletedAnonymous.Id).AnyAsync();
            Assert.IsFalse(anonymousExists);
        }

        [TestMethod()]
        public async Task DeleteAnonymousAsync_InvalidId_ReturnsFalse()
        {
            // Arrange
            Anonymous anonymous = new() { Id = Int32.MinValue, Age = 18 };

            // Act
            var deletedAnonymous = await anonymousRepository.DeleteAnonymousAsync(anonymous);

            // Assert
            Anonymous? anonymousExists = await context.Anonymouses.Where(a => a.Id == anonymous.Id).FirstOrDefaultAsync();
            Assert.IsNull(anonymousExists);
            Assert.IsFalse(deletedAnonymous);
        }
        [TestMethod()]
        public async Task DeleteAnonymousAsync_MinValueAge_ReturnsFalse()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = Int32.MinValue };

            // Act 
            var deletedAnonymous = await anonymousRepository.DeleteAnonymousAsync(anonymous);

            // Assert
            var anonymousExists = await context.Anonymouses.Where(a => a.Age == anonymous.Age).FirstOrDefaultAsync();
            Assert.IsNull(anonymousExists);
            Assert.IsFalse(deletedAnonymous);
        }
        [TestMethod()]
        public async Task DeleteAnonymousAsync_TooHigherAge_ReturnsFalse()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = 126 };

            // Act 
            var deletedAnonymous = await anonymousRepository.DeleteAnonymousAsync(anonymous);

            // Assert
            var anonymousExists = await context.Anonymouses.Where(a => a.Age == anonymous.Age).FirstOrDefaultAsync();
            Assert.IsNull(anonymousExists);
            Assert.IsFalse(deletedAnonymous);
        }
        #endregion
        #region GetAll
        [TestMethod()]
        public async Task GetAllAnonymousesAsync_NonEmptyDatabase_ReturnsAllAnonymouses()
        {
            // Arrange

            // Act
            var anonymouses = await anonymousRepository.GetAllAnonymousesAsync();

            // Assert
            Assert.IsTrue(anonymouses.Count() == 4);
        }
        [TestMethod()]
        public async Task GetAllAnonymousesAsync_AddOneToDatabase_ReturnsAllAnonymouses()
        {
            // Arrange
            Anonymous anonymous = new() { Id = 0, Age = 15 };
            // Act

            Anonymous AddAnonymous = await anonymousRepository.CreateAnonymousAsync(anonymous);
            var anonymouses = await anonymousRepository.GetAllAnonymousesAsync();

            // Assert
            Assert.IsTrue(anonymouses.Count() == 5);
        }
        #endregion
        #region GetById
        [TestMethod()]
        public async Task GetByIdAnonymousAsync_ValidId_ReturnsAnonymous()
        {
            // Arrange

            // Act
            var fetchedAnonymous = await anonymousRepository.GetByIdAnonymousAsync(1);

            // Assert
            Assert.IsNotNull(fetchedAnonymous);
            Assert.AreEqual(1, fetchedAnonymous.Id);
        }

        [TestMethod()]
        public async Task GetByIdAnonymousAsync_InvalidId_ThrowsException()
        {
            // Arrange
            Anonymous anonymous = new() { Id = Int32.MaxValue, Age = 15 };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<AnonymousRepositoryException>(() => anonymousRepository.GetByIdAnonymousAsync(anonymous.Id));
        }
        #endregion
    }
}