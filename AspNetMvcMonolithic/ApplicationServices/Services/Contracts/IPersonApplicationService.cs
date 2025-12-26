using AspNetMvcMonolithic.ApplicationServices.Dtos;

namespace AspNetMvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IPersonApplicationService
    {
        Task<List<GetPersonDtos>> GetAllPersonAsync(); //GetAllPersonAsync

        Task<PersonDetail> GetPersonById(Guid id); //GetPersonById

        void UpdatePersonAsync(PersonUpdate personUpdate); //Post_UpdatePeron

    }
}
