using AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos;

namespace AspNetMvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IPersonApplicationService
    {
        Task PostAsync(PostPersonDto postPersonDto); //Post

        Task PutAsync(PutPersonDto putPersonDto); //Put

        Task DeleteAsync(DeletePersonDto deletePersonDto); //Delete

        Task<List<GetPersonDto>> GetAsync(); //GetAll

        Task<PersonDetail?> GetPersonById(Guid id); //GetById
    }
}
