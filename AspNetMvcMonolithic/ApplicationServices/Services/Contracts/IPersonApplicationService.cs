using AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IPersonApplicationService
    {
        Task PostAsync(PostPersonDto postPersonDto); //Post

        Task PutAsync(PutPersonDto putPersonDto); //Put

        Task<GetPersonForEdite?> GetForEditAsync(GetPersonForEdite getPersonForEdite);

        Task<GetPersonForDelete?> GetForDeleteAsync(GetPersonForDelete getPersonForDelete);

        Task DeleteAsync(DeletePersonDto deletePersonDto); //Delete

        Task<List<GetPersonDto>> GetAsync(); //GetAll

        Task<PersonDetail?> GetPersonById(PersonDetail personDetail); //GetById

    }
}
