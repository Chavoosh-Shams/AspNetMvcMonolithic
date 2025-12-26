using AspNetMvcMonolithic.ApplicationServices.Dtos;

namespace AspNetMvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IPersonApplicationService
    {
        Task<List<GetPersonDtos>> GetAllPersonAsync();
    }
}
