using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        Task Insert(Person person); //Insert

        Task Update(Person person); //UpdatePerson

        Task<Person?> SelectPersonForEdite(Person person); //GetPersonForEdite

        Task<Person?> SelectPersonForDelete(Person person); //GetPersonById

        Task Delete(Person person); //Delete

        Task<IEnumerable<Person>> SelectAll();//SelectAll

        Task<Person?> SelectPersonById(Person person); //SelectPersonById


    }
}
