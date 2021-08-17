using LibraryAPI.Data.Converter.Implementations;
using LibraryAPI.Data.VO;
using LibraryAPI.Model;
using LibraryAPI.Repository;
using LibraryAPI.Repository.Generic;
using System.Collections.Generic;

namespace LibraryAPI.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            this._repository = repository;
            this._converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public PersonVO Create(PersonVO personVO)
        {
            var personEntity = _converter.Parse(personVO); // converter to person
            personEntity = _repository.Create(personEntity); // the persistence of the data is make by entities not VO's
            return _converter.Parse(personEntity);// converter to VO
        }

        public PersonVO Update(PersonVO personVO)
        {
            var personEntity = _converter.Parse(personVO);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            Person entity = _repository.Disable(id);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
