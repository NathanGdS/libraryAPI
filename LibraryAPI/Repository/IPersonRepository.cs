using LibraryAPI.Model;
using LibraryAPI.Repository.Generic;

namespace LibraryAPI.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
