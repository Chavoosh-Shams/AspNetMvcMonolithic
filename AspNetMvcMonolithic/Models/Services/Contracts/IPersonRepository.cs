using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {

        Task Insert(Person person); //Insert

        Task Update(Person person); //Update

        Task Delete(Person person); //Delete

        Task<Person?> SelectPersonForEdite(Person person); //SelectPersonForEdite

        Task<Person?> SelectPersonForDelete(Person person); //SelectPersonForDelete

        Task<Person?> SelectPersonById(Person person); //SelectPersonById

        Task<IEnumerable<Person>> SelectAll();//SelectAll

    }
}
