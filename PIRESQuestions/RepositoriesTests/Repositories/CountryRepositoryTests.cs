using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Entity_Framework;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using IRepositories;
using Repositories.Exceptions;
using System;

namespace Repositories.Repositories.Tests
{
    [TestClass()]
    public class CountryRepositoryTests
    {
        private readonly ApplicationDbContext context;
        private readonly CountryRepository countryRepository;

        private readonly DbConnection connection;

        public CountryRepositoryTests()
        {
            SQLitePCL.Batteries.Init();
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options;

            context = new ApplicationDbContext(options);
            countryRepository = new(context);
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
        public async Task CreateCountryAsync_ValidId_Succeeds()
        {
            // Arrange
            Country countryFranceTwo = new() { Id = 0, Name = "France2" };

            // Act
            var createdCountryFranceTwo = await countryRepository.CreateCountryAsync(countryFranceTwo);

            // Assert
            Assert.IsNotNull(createdCountryFranceTwo);
            Assert.AreEqual(193, createdCountryFranceTwo.Id);
        }
        [TestMethod]
        public async Task CreateCountryAsync_InvalidId_ThrowsException()
        {
            // Arrange
            Country countryExists = new() { Id = 1, Name = "Afghanistan" };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<CountryRepositoryException>(() => countryRepository.CreateCountryAsync(countryExists));
        }
        [TestMethod]
        public async Task CreateCountryAsync_NullName_ThrowsException()
        {
            // Arrange
            Country countryLabel = new() { Id = 0, Name = null };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<CountryRepositoryException>(() => countryRepository.CreateCountryAsync(countryLabel));
        }
        [TestMethod]
        public async Task CreateCountryAsync_EmptyLabel_ThrowsException()
        {
            // Arrange
            Country countryLabel = new() { Id = 0, Name = string.Empty };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<CountryRepositoryException>(() => countryRepository.CreateCountryAsync(countryLabel));
        }
        [TestMethod]
        public async Task CreateCountryAsync_WhitespaceLabel_ThrowsException()
        {
            // Arrange
            Country countryLabel = new() { Id = 0, Name = " " };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<CountryRepositoryException>(() => countryRepository.CreateCountryAsync(countryLabel));
        }
        #endregion
        #region Delete
        [TestMethod()]
        public async Task DeleteCountryAsync_ValidId_Succeeds()
        {
            // Arrange
            Country countryFranceTwo = new() { Id = 0, Name = "France2" };

            // Act
            Country deletedCountry = await countryRepository.CreateCountryAsync(countryFranceTwo);
            await countryRepository.DeleteCountryAsync(deletedCountry);

            // Assert
            Assert.IsNotNull(deletedCountry);
            bool countryExists = await context.Countries.Where(g => g.Id == deletedCountry.Id).AnyAsync();
            Assert.IsFalse(countryExists);
        }
        [TestMethod()]
        public async Task DeleteCountryAsync_InvalidId_ReturnsFalse()
        {
            // Arrange
            Country countryName = new() { Id = Int32.MaxValue, Name = "France" };

            // Act
            var deletedCountry = await countryRepository.DeleteCountryAsync(countryName);

            // Assert
            Country? countryExists = await context.Countries.Where(g => g.Id == countryName.Id).FirstOrDefaultAsync();
            Assert.IsNull(countryExists);
            Assert.IsFalse(deletedCountry);
        }
        [TestMethod()]
        public async Task DeleteCountryAsync_NonExistingCountry_ReturnsFalse()
        {
            // Arrange
            Country countryName = new() { Id = 0, Name = "Non-existing country" };

            // Act 
            var deletedCountry = await countryRepository.DeleteCountryAsync(countryName);

            // Assert
            var countryExists = await context.Countries.Where(g => g.Name == countryName.Name).FirstOrDefaultAsync();
            Assert.IsNull(countryExists);
            Assert.IsFalse(deletedCountry);
        }
        #endregion
        #region GetAll
        [TestMethod()]
        public async Task GetAllCountriesAsync_NonEmptyDatabase_ReturnsAllCountries()
        {
            // Arrange

            // Act
            var countries = await countryRepository.GetAllCountriesAsync();

            // Assert
            Assert.IsTrue(countries.Count() == 192);
        }
        [TestMethod()]
        public async Task GetAllCountriesAsync_ThreadSafe()
        {
            // Arrange
            var country1 = new Country() { Name = "country1" };
            var country2 = new Country() { Name = "country2" };
            var country3 = new Country() { Name = "country3" };

            await countryRepository.CreateCountryAsync(country1);
            await countryRepository.CreateCountryAsync(country2);
            await countryRepository.CreateCountryAsync(country3);

            // Act
            var countries1 = await countryRepository.GetAllCountriesAsync();
            var countries2 = await countryRepository.GetAllCountriesAsync();

            // Assert
            Assert.AreSame(countries1.Last().Name, countries2.Last().Name);
        }
        #endregion
        #region GetById
        [TestMethod()]
        public async Task GetByIdCountryAsync_ValidId_ReturnsCountry()
        {
            // Arrange

            // Act
            var fetchedCountry = await countryRepository.GetByIdCountryAsync(1);

            // Assert
            Assert.IsNotNull(fetchedCountry);
            Assert.AreEqual("Afghanistan", fetchedCountry.Name);
        }
        [TestMethod()]
        public async Task GetByIdCountryAsync_InvalidId_ThrowsException()
        {
            // Arrange
            var country1 = new Country() { Id = Int32.MaxValue, Name = "country1" };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<CountryRepositoryException>(() => countryRepository.GetByIdCountryAsync(country1.Id));
        }
        #endregion
        #region Update
        [TestMethod()]
        public async Task UpdateCountryAsync_ValidIdAndLabel_UpdatesCountry()
        {
            // Arrange
            Country countryUpdated = new() { Id = 0, Name = "Test Country" };
            await countryRepository.CreateCountryAsync(countryUpdated);
            // Act
            countryUpdated.Name = "Updated Country";
            await countryRepository.UpdateCountryAsync(countryUpdated);

            // Assert
            Country fetchedCountry = await countryRepository.GetByIdCountryAsync(countryUpdated.Id);
            Assert.IsNotNull(fetchedCountry);
            Assert.AreEqual(countryUpdated.Name, fetchedCountry.Name);
        }

        [TestMethod()]
        public async Task UpdateCountryAsync_NullOrWhiteSpaceName_ThrowsException()
        {
            // Arrange
            Country updatedCountry = new() { Id = 0, Name = string.Empty };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<CountryRepositoryException>(() => countryRepository.UpdateCountryAsync(updatedCountry));
        }
        [TestMethod()]
        public async Task UpdateCountryAsync_InvalidId_UpdatesCountry()
        {
            // Arrange
            Country updatedCountry = new() { Id = Int32.MaxValue, Name = "Updated Country" };

            // Act 
            var update = await countryRepository.UpdateCountryAsync(updatedCountry);

            // Assert
            Assert.AreEqual(0, update);
        }
        #endregion
    }
}