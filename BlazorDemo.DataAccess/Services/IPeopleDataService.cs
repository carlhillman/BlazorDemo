using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDemo.DataAccess.Models;

namespace BlazorDemo.DataAccess.Services
{
    public interface IPeopleDataService
    {
        Task<int> GetLastInsertedPersonId();
        Task<Person> GetPerson(int id);
        Task<List<Person>> GetPeople();
        Task InsertPerson(Person person);
        Task UpdatePerson(int id, Person person);
        Task DeletePerson(int id);

    }
}
