using Entities;
using IRepositories;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Repositories.Repositories
{
    public class UserPersonRepository(ApplicationDbContext _context) : IUserPersonRepository
    {
        public async Task<UserPerson> CreateUserPersonAsync(UserPerson userPerson)
        {
            if (string.IsNullOrWhiteSpace(userPerson.UserName))
            {
                throw new UserPersonRepositoryException($"UserPerson UserName value invalid: null, empty or whitespace.");
            }
            if (_context.UserPersons.Any(u => userPerson.UserName == u.UserName))
            {
                throw new UserPersonRepositoryException($"UserPerson UserName value invalid: already exists in DB.");
            }
            if (string.IsNullOrWhiteSpace(userPerson.Email))
            {
                throw new UserPersonRepositoryException($"UserPerson Email value invalid: null, empty or whitespace.");
            }

            if (_context.UserPersons.Any(u => userPerson.Email == u.Email))
            {
                throw new UserPersonRepositoryException($"UserPerson Email value invalid: already exists in DB.");
            }
            if (userPerson.DateOfBirth == DateOnly.MinValue)
            {
                throw new UserPersonRepositoryException($"UserPerson DateOfBirth value invalid: shouldn't be DateOnly MinValue.");
            }

            _context.UserPersons.Add(userPerson);
            await _context.SaveChangesAsync();
            return userPerson;
        }
    }
}
