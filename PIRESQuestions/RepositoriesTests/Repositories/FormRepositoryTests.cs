using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.SqlServer.Server;

namespace Repositories.Repositories.Tests
{
    [TestClass()]
    public class FormRepositoryTests
    {
        private readonly ApplicationDbContext context;
        private readonly FormRepository formRepository;
        private readonly string _userPersonId = "951173f4-7557-4cde-b839-1ac488b30f9f";

        private readonly DbConnection connection;

        public FormRepositoryTests()
        {
            SQLitePCL.Batteries.Init();
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options;

            context = new ApplicationDbContext(options);
            formRepository = new(context);
        }

        [TestInitialize]
        public void Init()
        {
            context.Database.EnsureCreated();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }

        #region Create
        [TestMethod()]
        public async Task CreateFormAsyncTest_ValidId_Suceeds()
        {
            // Arange
            Form form1 = new() { Id = 0, Description = "descForm1", StatusId = 1, Title = "titleForm1", UserPersonId = _userPersonId };
            Form form2 = new() { Id = 0, Description = "descForm2", StatusId = 1, Title = "titleForm2", UserPersonId = _userPersonId };


            // Act
            var createdForm1 = await formRepository.CreateFormAsync(form1);
            var createdForm2 = await formRepository.CreateFormAsync(form2);


            // Asserts
            Assert.IsNotNull(createdForm1);
            Assert.IsNotNull(createdForm2);

        }

        [TestMethod()]
        public async Task CreateFormAsync_InvalidId_ThrowsException()
        {
            // Arrange
            Form form3 = new() { Id = 1, Description = "desc", StatusId = 1, Title = "t", UserPersonId = _userPersonId };

            // act/assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form3));
        }

        [TestMethod()]
        public async Task CreateFormAsync_NullTitle_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = "desc", StatusId = 1, Title = null, UserPersonId = _userPersonId };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }

        [TestMethod()]
        public async Task CreateFormAsync_EmptyTitle_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = "desc", StatusId = 1, Title = string.Empty, UserPersonId = _userPersonId };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }

        [TestMethod()]
        public async Task CreateFormAsync_WhitespaceTitle_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = "desc", StatusId = 1, Title = " ", UserPersonId = _userPersonId };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }
        [TestMethod()]
        public async Task CreateFormAsync_NullDescription_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = null, StatusId = 1, Title = "title", UserPersonId = _userPersonId };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }

        [TestMethod()]
        public async Task CreateFormAsync_EmptyDescription_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = string.Empty, StatusId = 1, Title = "title", UserPersonId = _userPersonId };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }

        [TestMethod()]
        public async Task CreateFormAsync_WhitespaceDescription_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = " ", StatusId = 1, Title = "title", UserPersonId = _userPersonId };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }
        [TestMethod()]
        public async Task CreateFormAsync_StatusIdIs0_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = "desc", StatusId = 0, Title = "title", UserPersonId = _userPersonId };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }
        [TestMethod()]
        public async Task CreateFormAsync_NullPersonId_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = "desc", StatusId = 1, Title = "title", UserPersonId = null };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }

        [TestMethod]
        public async Task CreateFormAsync_EmptyPersonId_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = "desc", StatusId = 1, Title = "title", UserPersonId = string.Empty };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }

        [TestMethod]
        public async Task CreateFormAsync_WhitespacePersonId_ThrowsException()
        {
            Form form4 = new() { Id = 0, Description = "desc", StatusId = 1, Title = "title", UserPersonId = " " };

            // Act/Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.CreateFormAsync(form4));
        }
        #endregion

        #region Delete
        [TestMethod()]
        public async Task DeleteFormAsync_ValidId_Succeeds()
        {
            Form form1 = new()
            {
                Id = 0,
                Description = "Questions about cities",
                StatusId = 1,
                Title = "Europeans Capitals",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };

            // Act
            Form deleteForm = await formRepository.CreateFormAsync(form1);
            bool formExists = await context.Forms.Where(f => f.Id == deleteForm.Id).AnyAsync();
            Assert.IsTrue(formExists);
        }

        [TestMethod()]
        public async Task DeleteFormAsync_InvalidId_ReturnFalse()
        {
            //Arrange
            Form form1 = new()
            {
                Id = Int32.MaxValue,
                Description = "Questions about cities",
                StatusId = 1,
                Title = "Europeans Capitals",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };

            // Act
            var deletedForm = await formRepository.DeleteFormAsync(form1);

            // Assert
            Form? formExists = await context.Forms.Where(f => f.Id == form1.Id).FirstOrDefaultAsync();
            Assert.IsNull(formExists);
            Assert.IsFalse(deletedForm);
        }
        #endregion

        #region GetAll

        [TestMethod()]
        public async Task GetAllFormAsync_NonEmptyDatabase_ReturnsAllForms()
        {
            //Arrange 

            // Act 
            var forms = await formRepository.GetAllFormsAsync();

            // Assert
            Assert.IsTrue(forms.Count() == 2);
        }
        [TestMethod()]
        public async Task GetAllFormsAsync_ThreadSafe()
        {
            var form1 = new Form()
            {
                Id = 0,
                Description = "Questions about cities",
                StatusId = 1,
                Title = "Europeans Capitals",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };
            var form2 = new Form()
            {
                Id = 0,
                Description = "Questions about cities v2",
                StatusId = 2,
                Title = "Europeans Capitals",
                UserPersonId = "951173f4-7557-4cde-b839-1ac488b30f9f",
            };

            await formRepository.CreateFormAsync(form1);
            await formRepository.CreateFormAsync(form2);

            // Act
            var forms1 = await formRepository.GetAllFormsAsync();
            var forms2 = await formRepository.GetAllFormsAsync();

            // Assert
            Assert.AreSame(forms1.Last().Description, forms2.Last().Description);

        }
        #endregion

        #region GetById
        [TestMethod()]
        public async Task GetByIdFormAsync_ValidId_ReturnForms()
        {
            // Arrange

            // Act
            var fetchedForm = await formRepository.GetByIdFormAsync(1);

            // Assert 
            Assert.IsNotNull(fetchedForm);
            Assert.AreEqual("Europeans Capitals", fetchedForm.Title);
        }
        [TestMethod()]
        public async Task GetByIdformAsync_InvalidId_ThrowsException()
        {
            // Arrange 
            var form1 = new Form()
            {
                Id = Int32.MaxValue,
                Description = "Questions about cities",
                StatusId = 1,
                Title = "Europeans Capitals",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.GetByIdFormAsync(form1.Id));

        }

        #endregion

        #region Update
        [TestMethod()]
        public async Task UpdateFormAsync_ValidIdAndTitleDesc_UpdatesForm()
        {
            //Arrange
            Form formUpdated = new Form()
            {
                Id = 0,
                Description = "test description",
                StatusId = 1,
                Title = "test title",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };
            await formRepository.CreateFormAsync(formUpdated);
            // Act
            formUpdated.Title = "new title";
            formUpdated.Description = "new desc";
            await formRepository.UpdateFormAsync(formUpdated);

            // Assert
            Form fetchedForm = await formRepository.GetByIdFormAsync(formUpdated.Id);
            Assert.IsNotNull(fetchedForm);
            Assert.AreEqual(formUpdated.Title, fetchedForm.Title);
            Assert.AreEqual(formUpdated.Description, fetchedForm.Description);
        }
        [TestMethod()]
        public async Task UpdateFormAsync_NullOrWhiteSpaceTitle_ThrowsException()
        {
            // Arrange
            var updatedForm = new Form()
            {
                Id = 0,
                Description = "Questions about cities",
                StatusId = 1,
                Title = string.Empty,
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };
            // Act & Assert
            await Assert.ThrowsExceptionAsync<FormRepositoryException>(() => formRepository.UpdateFormAsync(updatedForm));
        }
        [TestMethod()]
        public async Task UpdateFormAsync_InvalidId_UpdatesForm()
        {
            // Arrange 
            var updatedForm = new Form()
            {
                Id = Int32.MaxValue,
                Description = "Questions about cities",
                StatusId = 1,
                Title = "updated form",
                UserPersonId = "981173f4-7557-4cde-b839-1ac488b30f9f",
            };

            // Act 
            var update = await formRepository.UpdateFormAsync(updatedForm);

            // Assert
            Assert.AreEqual(0, update);
        }
    }
    #endregion
}