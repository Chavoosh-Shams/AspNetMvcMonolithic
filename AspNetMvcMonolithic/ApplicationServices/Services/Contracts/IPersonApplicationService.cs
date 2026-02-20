using AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IPersonApplicationService
    {
        Task PostAsync(PostPersonDto postPersonDto); //Post

        Task PutAsync(PutPersonDto putPersonDto); //Put

        Task DeleteAsync(DeletePersonDto deletePersonDto); //Delete

        Task<GetPersonForEdit?> GetForEditAsync(GetPersonForEdit getPersonForEdite);

        Task<GetPersonForDelete?> GetForDeleteAsync(GetPersonForDelete getPersonForDelete);

        Task<PersonDetail?> GetPersonById(PersonDetail personDetail); //GetById

        Task<List<GetPersonDto>> GetAsync(); //GetAll

    }
}
