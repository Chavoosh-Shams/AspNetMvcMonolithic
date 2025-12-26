using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> SelectAll();//SelectAll

        Person GetPersonById(Guid id); //SelectPersonById

        void UpdatePerson(Person person); //UpdatePerson
    }
}
