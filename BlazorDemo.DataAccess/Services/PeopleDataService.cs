using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDemo.DataAccess.Models;

namespace BlazorDemo.DataAccess.Services
{
    public class PeopleDataService : IPeopleDataService
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public PeopleDataService(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        //Metod som hämtar en specifik person
        public Task<Person> GetPerson(int id)
        {
            var sql = $"select * from dbo.Person where id = {id}";
            return _sqlDataAccess.LoadDataEntityAsync<Person, dynamic>(sql, id);
        }
        //Metod som hämtar senaste personid
        public Task<int> GetLastInsertedPersonId()
        {
            const string sql = @"select top (1) id from dbo.Person order by id desc";
            return _sqlDataAccess.LoadDataNoParameterAsync<int>(sql);
        }

        //Metod som hämtar alla personer
        public Task<List<Person>> GetPeople()
        {
            const string sql = "select * from dbo.Person";
            return _sqlDataAccess.LoadDataListAsync<Person, dynamic>(sql, new { });
        }
        //Metod som lägger till en person
        public Task InsertPerson(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName) ||
                string.IsNullOrWhiteSpace(person.EmailAddress)) throw new Exception();
            const string sql = @"insert into dbo.Person (FirstName, LastName, EmailAddress)" +
                      "values (@FirstName, @LastName, @EmailAddress)";
            return _sqlDataAccess.ExecuteSqlAsync(sql, person);
        }
        //Metod som uppdaterar en person
        public Task UpdatePerson(int id, Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName) ||
                string.IsNullOrWhiteSpace(person.EmailAddress)) throw new Exception();
            var sql = @"update dbo.Person " +
                              $@"set Firstname = '{person.FirstName}',LastName = '{person.LastName}'," +
                              $"EmailAddress = '{person.EmailAddress}' " +
                              $"where id = {id}";
            return _sqlDataAccess.ExecuteSqlAsync(sql, person);
        }
        //Metod som tar bort en person
        public Task DeletePerson(int id)
        {
            var sql = $"delete from dbo.Person where id = {id}";
            return _sqlDataAccess.ExecuteSqlAsync(sql, id);
        }
    }
}
