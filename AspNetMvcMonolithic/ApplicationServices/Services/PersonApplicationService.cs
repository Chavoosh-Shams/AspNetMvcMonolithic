using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;

namespace AspNetMvcMonolithic.ApplicationServices.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {
        #region [-Private Fields-]
        private readonly IPersonRepository _personRepository;
        #endregion

        #region [-Ctor-]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region [-Implement IPersonApplicationService-]


        #region [-GetAllPersonAsync-]
        public async Task<List<GetPersonDtos>> GetAllPersonAsync()
        {
            var persons = await Task.FromResult(_personRepository.SelectAll());
            if (persons == null)
            {
                return new List<GetPersonDtos>();
            }
            var getPersonDtos = new List<GetPersonDtos>();
            foreach (var person in await persons)
            {
                var g = new GetPersonDtos
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


        #region [-GetPersonById-]
        public async Task<PersonDetail> GetPersonById(Guid id)
        {
            var person = _personRepository.GetPersonById(id);
            if (person == null)
            {
                return null;
            }
            var PersonDetail = new PersonDetail();
            PersonDetail.Id = person.Id;
            PersonDetail.FirstName = person.FirstName;
            PersonDetail.LastName = person.LastName;
            return PersonDetail;
        }
        #endregion


        #region [-UpdatePerson-]
        public void UpdatePersonAsync(PersonUpdate personUpdate)
        {
            var person = new Person();
            person.Id = personUpdate.Id;
            person.FirstName = personUpdate.FirstName;
            person.LastName = personUpdate.LastName;
            _personRepository.UpdatePerson(person);
        }
        #endregion


        #endregion

    }
}
