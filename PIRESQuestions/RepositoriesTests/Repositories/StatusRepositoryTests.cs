using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using NuGet.Frameworks;
using System;

namespace Repositories.Repositories.Tests
{
    [TestClass()]
    public class StatusRepositoryTests
    {
        private readonly ApplicationDbContext context;
        private readonly StatusRepository statusRepository;

        private readonly DbConnection connection;

        public StatusRepositoryTests()
        { 
            SQLitePCL.Batteries.Init();
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options;

            context = new ApplicationDbContext(options);
            statusRepository = new(context);
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
        public async Task CreateStatusAsync_ValidId_Succeds()
        {
            // Arrange
            Status statusInProgress = new() { Id = 0, Label = "In progress" };
            Status statusValidated = new() { Id = 0, Label = "Validated" };
            Status statusArchived = new() { Id = 0, Label = "Archived" };

            // Act
            var createdStatusInProgress = await statusRepository.CreateStatusAsync(statusInProgress);
            var createdStatusValidated = await statusRepository.CreateStatusAsync(statusValidated);
            var createdStatusArchived = await statusRepository.CreateStatusAsync(statusArchived);

            // Assert
            Assert.IsNotNull(createdStatusInProgress);
            Assert.IsNotNull(createdStatusValidated);
            Assert.IsNotNull(createdStatusArchived);

            Assert.AreEqual(4, createdStatusInProgress.Id);
            Assert.AreEqual(5, createdStatusValidated.Id);
            Assert.AreEqual(6, createdStatusArchived.Id);
        }

        [TestMethod()]
        public async Task CreateStatusAsync_InvalidId_ThrowsException()
        {
            // Arrange
            Status statusInProgress = new() { Id = 1, Label = "In progress" };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<StatusRepositoryException>(() => statusRepository.CreateStatusAsync(statusInProgress));
        }

        [TestMethod()]
        public async Task CreateStatusAsync_NullLabel_ThrowsException()
        {
            // Arrange
            Status statusInProgress = new() { Id = 0, Label = null };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<StatusRepositoryException>(() => statusRepository.CreateStatusAsync(statusInProgress));
        }
        [TestMethod()]
        public async Task CreateStatusAsync_EmptyLabel_ThrowsException()
        {
            // Arrange
            Status statusInProgress = new() { Id = 0, Label = string.Empty };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<StatusRepositoryException>(() => statusRepository.CreateStatusAsync(statusInProgress));
        }
        [TestMethod()]
        public async Task CreateStatusAsync_WhitespaceLabel_ThrowsException()
        {
            // Arrange
            Status statusInProgress = new() { Id = 0, Label = " " };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<StatusRepositoryException>(() => statusRepository.CreateStatusAsync(statusInProgress));
        }
        #endregion

        #region Delete
        [TestMethod()]
        public async Task DeleteStatusAsync_ValidId_Succeeds()
        {
            // Arrange
            Status statusInProgress = new() { Id = 0, Label = "In progress" };

            // Act
            Status deletedStatus = await statusRepository.CreateStatusAsync(statusInProgress);
            await statusRepository.DeleteStatusAsync(deletedStatus);

            // Assert
            Assert.IsNotNull(deletedStatus);
            bool statusExists = await context.Statuses.Where(s => s.Id == deletedStatus.Id).AnyAsync();
            Assert.IsFalse(statusExists);
        }
        [TestMethod()]
        public async Task DeleteStatusAsync_InvalidId_ReturnsFalse()
        {
            // Arrange
            Status statusInProgress = new() { Id = Int32.MaxValue, Label = "In progress" };

            // Act
            var deletedStatus = await statusRepository.DeleteStatusAsync(statusInProgress);

            // Assert
            Status? statusExist = await context.Statuses.Where(s => s.Id ==  statusInProgress.Id).FirstOrDefaultAsync();
            Assert.IsNull(statusExist);
            Assert.IsFalse(deletedStatus);
        }
        [TestMethod()]
        public async Task DeleteStatusAsync_NonExistingStatus_ReturnsFalse()
        {
            // Arrange
            Status status = new() { Id = 0, Label = "Non-existing status" };

            // Act
            var isDeletedStatus = await statusRepository.DeleteStatusAsync(status);

            // Assert
            var statusExists = await context.Statuses.Where(s => s.Label == status.Label).FirstOrDefaultAsync();
            Assert.IsNull(statusExists);
            Assert.IsFalse(isDeletedStatus);
        }
        #endregion

        #region GetAll
        [TestMethod()]
        public async Task GetAllStatusAsync_NonEmptyDatabase_ReturnsAllStatus()
        {
            // Arrange

            // Act 
            var status = await statusRepository.GetAllStatusesAsync();

            // Assert 
            Assert.IsTrue(status.Count() == 3);
        }
        [TestMethod()]
        public async Task GetAllStatusAsync_ThreadSafe()
        {
            // Arrange 
            var status1 = new Status() { Label = "In progress" };
            var status2 = new Status() { Label = "Validated" };
            var status3 = new Status() { Label = "Archived" };

            await statusRepository.CreateStatusAsync(status1);
            await statusRepository.CreateStatusAsync(status2);
            await statusRepository.CreateStatusAsync(status3);

            //Act
            var statuses1 = await statusRepository.GetAllStatusesAsync();
            var statuses2 = await statusRepository.GetAllStatusesAsync();

            // Assert
            Assert.AreSame(statuses1.Last().Label, statuses2.Last().Label);
        }
        #endregion

        #region GetById
        [TestMethod()]
        public async Task GetByIdStatusAsync_ValidId_ReturnsStatus()
        {
            // Arrange

            // Act
            var fetchedStatus = await statusRepository.GetByIdStatusAsync(1);

            // Assert
            Assert.IsNotNull(fetchedStatus);
            Assert.AreEqual("In progress", fetchedStatus.Label);
        }

        [TestMethod()]
        public async Task GetByIdStatusAsync_InvalidId_ThrowsException()
        {
            // Arrange
            Status statusInProgress = new Status() { Id = Int32.MaxValue, Label = "In progress" };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<StatusRepositoryException>(() => statusRepository.GetByIdStatusAsync(statusInProgress.Id));
        }
        #endregion

        #region Update
        [TestMethod()]
        public async Task UpdateStatusAsync_ValidIdAndLabel_UpdateStatus()
        {
            // Arrange
            Status statusUpdated = new() { Id = 0, Label = "Test Status" };
            await statusRepository.CreateStatusAsync(statusUpdated);
            // Act
            statusUpdated.Label = "Updated Status";
            await statusRepository.UpdateStatusAsync(statusUpdated);

            // Assert
            Status fetchedStatus = await statusRepository.GetByIdStatusAsync(statusUpdated.Id);
            Assert.IsNotNull(fetchedStatus);
            Assert.AreEqual(statusUpdated.Label, fetchedStatus.Label);
        }
        [TestMethod()]
        public async Task UpdateStatusAsync_NullOrWhiteSpaceLabel_ThrowsException()
        {
            // Arrange 
            Status updatedStatus = new() { Id = 0, Label = string.Empty };
            
            // Act & Assert
            await Assert.ThrowsExceptionAsync<StatusRepositoryException>(() => statusRepository.UpdateStatusAsync(updatedStatus));

        }
        [TestMethod()]
        public async Task UpdateStatusAsync_InvalidId_UpdatesStatus()
        {
            // Arrange 
            Status updatedStatus = new() { Id = Int32.MaxValue, Label = "Updated Status" };

            // Act
            var update = await statusRepository.UpdateStatusAsync(updatedStatus);

            // Assert
            Assert.AreEqual(0, update);
        }
        #endregion
    }
}