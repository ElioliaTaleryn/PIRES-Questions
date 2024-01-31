using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace Repositories.Repositories.Tests
{
    [TestClass()]
    public class GenderRepositoryTests
    {
        private readonly ApplicationDbContext context;
        private readonly GenderRepository genderRepository;

        private readonly DbConnection connection;

        public GenderRepositoryTests()
        {
            SQLitePCL.Batteries.Init();
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options;

            context = new ApplicationDbContext(options);
            genderRepository = new(context);
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
        public async Task CreateGenderAsync_ValidId_Succeeds()
        {
            // Arrange
            Gender genderMan = new() { Id = 0, Label = "Man" };
            Gender genderWoman = new() { Id = 0, Label = "Woman" };
            Gender genderOther = new() { Id = 0, Label = "Other" };

            // Act
            var createdGenderMan = await genderRepository.CreateGenderAsync(genderMan);
            var createdGenderWoman = await genderRepository.CreateGenderAsync(genderWoman);
            var createdGenderOther = await genderRepository.CreateGenderAsync(genderOther);

            // Asserts
            Assert.IsNotNull(createdGenderMan);
            Assert.IsNotNull(createdGenderWoman);
            Assert.IsNotNull(createdGenderOther);

            Assert.AreEqual(4, createdGenderMan.Id);
            Assert.AreEqual(5, createdGenderWoman.Id);
            Assert.AreEqual(6, createdGenderOther.Id);
        }

        [TestMethod]
        public async Task CreateGenderAsync_InvalidId_ThrowsException()
        {
            // Arrange
            Gender genderWoman = new() { Id = 1, Label = "Woman" };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<GenderRepositoryException>(() => genderRepository.CreateGenderAsync(genderWoman));
        }

        [TestMethod]
        public async Task CreateGenderAsync_NullLabel_ThrowsException()
        {
            // Arrange
            Gender genderLabel = new() { Id = 0, Label = null };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<GenderRepositoryException>(() => genderRepository.CreateGenderAsync(genderLabel));
        }

        [TestMethod]
        public async Task CreateGenderAsync_EmptyLabel_ThrowsException()
        {
            // Arrange
            Gender genderLabel = new() { Id = 0, Label = string.Empty };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<GenderRepositoryException>(() => genderRepository.CreateGenderAsync(genderLabel));
        }

        [TestMethod]
        public async Task CreateGenderAsync_WhitespaceLabel_ThrowsException()
        {
            // Arrange
            Gender genderLabel = new() { Id = 0, Label = " " };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<GenderRepositoryException>(() => genderRepository.CreateGenderAsync(genderLabel));
        }
        #endregion

        #region Delete
        [TestMethod()]
        public async Task DeleteGenderAsync_ValidId_Succeeds()
        {
            // Arrange
            Gender genderMan = new() { Id = 0, Label = "Man" };

            // Act
            Gender deletedGender = await genderRepository.CreateGenderAsync(genderMan);
            await genderRepository.DeleteGenderAsync(deletedGender);

            // Assert
            Assert.IsNotNull(deletedGender);
            bool genderExists = await context.Genders.Where(g => g.Id == deletedGender.Id).AnyAsync();
            Assert.IsFalse(genderExists);
        }
        [TestMethod()]
        public async Task DeleteGenderAsync_InvalidId_ReturnsFalse()
        {
            // Arrange
            Gender genderMan = new() { Id = Int32.MaxValue, Label = "Man" };

            // Act
            var deletedMan = await genderRepository.DeleteGenderAsync(genderMan);

            // Assert
            Gender? genderExists = await context.Genders.Where(g => g.Id == genderMan.Id).FirstOrDefaultAsync();
            Assert.IsNull(genderExists);
            Assert.IsFalse(deletedMan);
        }
        [TestMethod()]
        public async Task DeleteGenderAsync_NonExistingGender_ReturnsFalse()
        {
            // Arrange
            Gender gender = new() { Id = 0, Label = "Non-existing gender" };

            // Act 
            var isDeletedGender = await genderRepository.DeleteGenderAsync(gender);

            // Assert
            var genderExists = await context.Genders.Where(g => g.Label == gender.Label).FirstOrDefaultAsync();
            Assert.IsNull(genderExists);
            Assert.IsFalse(isDeletedGender);
        }
        #endregion

        #region GetAll
        [TestMethod()]
        public async Task GetAllGendersAsync_NonEmptyDatabase_ReturnsAllGenders()
        {
            // Arrange

            // Act
            var genders = await genderRepository.GetAllGendersAsync();

            // Assert
            Assert.IsTrue(genders.Count() == 3);
        }
        [TestMethod()]
        public async Task GetAllGendersAsync_ThreadSafe()
        {
            // Arrange
            var gender1 = new Gender() { Label = "Male" };
            var gender2 = new Gender() { Label = "Female" };
            var gender3 = new Gender() { Label = "Other" };

            await genderRepository.CreateGenderAsync(gender1);
            await genderRepository.CreateGenderAsync(gender2);
            await genderRepository.CreateGenderAsync(gender3);

            // Act
            var genders1 = await genderRepository.GetAllGendersAsync();
            var genders2 = await genderRepository.GetAllGendersAsync();

            // Assert
            Assert.AreSame(genders1.Last().Label, genders2.Last().Label);
        }
        #endregion

        #region GetById
        [TestMethod()]
        public async Task GetByIdGenderAsync_ValidId_ReturnsGender()
        {
            // Arrange

            // Act
            var fetchedGender = await genderRepository.GetByIdGenderAsync(1);

            // Assert
            Assert.IsNotNull(fetchedGender);
            Assert.AreEqual("Woman", fetchedGender.Label);
        }

        [TestMethod()]
        public async Task GetByIdGenderAsync_InvalidId_ThrowsException()
        {
            // Arrange
            Gender genderMan = new() { Id = Int32.MaxValue, Label = "Man" };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<GenderRepositoryException>(() => genderRepository.GetByIdGenderAsync(genderMan.Id));
        }
        #endregion

        #region Update
        [TestMethod()]
        public async Task UpdateGenderAsync_ValidIdAndLabel_UpdatesGender()
        {
            // Arrange
            Gender genderUpdated = new() { Id = 0, Label = "Test Gender" };
            await genderRepository.CreateGenderAsync(genderUpdated);
            // Act
            genderUpdated.Label = "Updated Gender";
            await genderRepository.UpdateGenderAsync(genderUpdated);

            // Assert
            Gender fetchedGender = await genderRepository.GetByIdGenderAsync(genderUpdated.Id);
            Assert.IsNotNull(fetchedGender);
            Assert.AreEqual(genderUpdated.Label, fetchedGender.Label);
        }
        [TestMethod()]
        public async Task UpdateGenderAsync_NullOrWhiteSpaceLabel_ThrowsException()
        {
            // Arrange
            Gender updatedGender = new() { Id = 0, Label = string.Empty };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<GenderRepositoryException>(() => genderRepository.UpdateGenderAsync(updatedGender));
        }
        [TestMethod()]
        public async Task UpdateGenderAsync_InvalidId_UpdatesGender()
        {
            // Arrange
            Gender updatedGender = new() { Id = Int32.MaxValue, Label = "Updated Gender" };

            // Act 
            var update = await genderRepository.UpdateGenderAsync(updatedGender);

            // Assert
            Assert.AreEqual(0, update);
        }
        #endregion
    }
}