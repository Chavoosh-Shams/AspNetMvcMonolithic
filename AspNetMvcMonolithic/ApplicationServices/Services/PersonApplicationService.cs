using AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using AspNetMvcMonolithic.Models.Services.Repositories;

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
        public async Task PostAsync(PostPersonDto postPersonDto)
        {
            var person = new Person()
            {
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName
            };
            await _personRepository.Insert(person);
        }
        #endregion

        #region [- PutAsync() -]
        public async Task PutAsync(PutPersonDto putPersonDto)
        {
            var person = new Person()
            {
                Id = putPersonDto.Id,
                FirstName = putPersonDto.FirstName,
                LastName = putPersonDto.LastName
            };
            await _personRepository.Update(person);
        }
        #endregion

        #region [- GetForEditAsync() -]
        public async Task<GetPersonForEdit?> GetForEditAsync(GetPersonForEdit getPersonForEdite)
        {
            var person = new Person()
            {
                Id = getPersonForEdite.Id,
                FirstName = getPersonForEdite.FirstName,
                LastName = getPersonForEdite.LastName,
            };
            var personDto = await _personRepository.SelectPersonForEdite(person);
            if (personDto == null)
            {
                return null;
            }
            return new GetPersonForEdit()
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
            };
        } 
        #endregion

        #region [- Delete() -]
        public async Task DeleteAsync(DeletePersonDto deletePersonDto)
        {
            var person = new Person()
            {
                Id = deletePersonDto.Id,
                FirstName = deletePersonDto.FirstName,
                LastName = deletePersonDto.LastName
            };
            await _personRepository.Delete(person);
        }
        #endregion

        #region [- GetForDeleteAsync() -]
        public async Task<GetPersonForDelete?> GetForDeleteAsync(GetPersonForDelete getPersonForDelete)
        {
            var person = new Person()
            {
                Id = getPersonForDelete.Id,
                FirstName = getPersonForDelete.FirstName,
                LastName = getPersonForDelete.LastName,
            };
            var personDto= await _personRepository.SelectPersonForDelete(person);
            if(personDto == null)
            {
                return null;
            }
            return new GetPersonForDelete()
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
            };
        } 
        #endregion

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
        public async Task<PersonDetail?> GetPersonById(PersonDetail personDetail)
        {
            var person = new Person()
            {
                Id = personDetail.Id,
                FirstName = personDetail.FirstName,
                LastName = personDetail.LastName,
            };
            var personDto = await _personRepository.SelectPersonById(person);
            if (personDto == null)
            {
                return null;
            }
            return new PersonDetail()
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
            };
        }
        #endregion



    }
}
