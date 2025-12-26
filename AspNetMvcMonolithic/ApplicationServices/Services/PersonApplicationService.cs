using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.ApplicationServices.Services.Contracts;
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
    }
}
