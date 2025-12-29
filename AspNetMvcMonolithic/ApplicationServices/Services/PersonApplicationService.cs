using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;

namespace AspNetMvcMonolithic.ApplicationServices.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {

        #region [- Private Fields -]
        private readonly IPersonRepository _personRepository;
        #endregion

        #region [- Ctor -]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region [- PostAsync() -]
        public Task PostAsync(PostPersonDto postPersonDto)
        {
            var person = new Person()
            {
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName
            };
            return _personRepository.Insert(person);
        }
        #endregion

        #region [- PutAsync() -]
        public Task PutAsync(PutPersonDto putPersonDto)
        {
            var person = new Person()
            {
                FirstName = putPersonDto.FirstName,
                LastName = putPersonDto.LastName
            };
            return _personRepository.Update(person);
        }
        #endregion


        public Task DeleteAsync(DeletePersonDto deletePersonDto)
        {
           return _personRepository.Delete(deletePersonDto.Id);
        }

        #region [- GetAsync() -]
        public async Task<List<GetPersonDto>> GetAsync()
        {
            var persons = await Task.FromResult(_personRepository.SelectAll());
            if (persons == null)
            {
                return new List<GetPersonDto>();
            }
            var getPersonDtos = new List<GetPersonDto>();
            foreach (var person in await persons)
            {
                var g = new GetPersonDto
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                };
                getPersonDtos.Add(g);
            }
            return getPersonDtos;
        }
        #endregion

        #region [- GetPersonById() -]
        public async Task<PersonDetail?> GetPersonById(Guid id)
        {
            var person = await _personRepository.GetPersonById(id);
            if (person == null)
            {
                return null;
            }
            var personDetail=new PersonDetail()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return personDetail;
        }


        #endregion

    }
}
