using LibraryAPI.Model;
using LibraryAPI.Model.Context;
using LibraryAPI.Repository.Generic;
using System;
using System.Linq;

namespace LibraryAPI.Repository.Implementations
{
    public class PersonRepositoryImplementation : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepositoryImplementation(MySQLContext context): base (context) { }

        public Person Disable(long id)
        {
            if (!_context.People.Any(p => p.Id.Equals(id))) return null;
            Person user = _context.People.SingleOrDefault(p => p.Id.Equals(id));
            if(user != null)
            {
                user.Enabled = true;

                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return user;
        }
    }
}
