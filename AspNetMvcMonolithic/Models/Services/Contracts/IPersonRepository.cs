using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        Task Insert(Person person); //Insert

        Task Update(Person person); //UpdatePerson

        Task Delete(Guid id); //Delete

        Task<IEnumerable<Person>> SelectAll();//SelectAll

        Task<Person?> GetPersonById(Guid id); //SelectPersonById

    }
}
