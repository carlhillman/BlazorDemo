using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDemo.Models; 

namespace BlazorDemo.DataAccess.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public UserDataService(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        //Metod som hämtar en specifik användare
        public Task<User> GetUser(int id)
        {
            var sql = $"select * from dbo.[User] where UserId = {id}";
            return _sqlDataAccess.LoadDataEntityAsync<User, dynamic>(sql, id);
        }
        //Metod som hämtar senaste användareId
        public Task<int> GetLastInsertedUserId()
        {
            const string sql = @"select top (1) UserId from dbo.[User] order by UserId desc";
            return _sqlDataAccess.LoadDataNoParameterAsync<int>(sql);
        }

        //Metod som hämtar alla användare
        public Task<List<User>> GetUsers()
        {
            const string sql = "select * from dbo.[User]";
            return _sqlDataAccess.LoadDataListAsync<User, dynamic>(sql, new { });
        }
        //Metod som lägger till en användare
        public Task<bool> InsertUser(User person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName) ||
                string.IsNullOrWhiteSpace(person.EmailAddress)) throw new Exception();
            const string sql = @"insert into dbo.[User] (FirstName, LastName, EmailAddress)" +
                      "values (@FirstName, @LastName, @EmailAddress)";
            var response = _sqlDataAccess.ExecuteSqlAsync(sql, person);
            return response;
        }
        //Metod som uppdaterar en användare
        public Task<bool> UpdateUser(int id, User person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName) ||
                string.IsNullOrWhiteSpace(person.EmailAddress)) throw new Exception();
            var sql = @"update dbo.[User] " +
                              $@"set Firstname = '{person.FirstName}',LastName = '{person.LastName}'," +
                              $"EmailAddress = '{person.EmailAddress}' " +
                              $"where UserId = {id}";
            var response = _sqlDataAccess.ExecuteSqlAsync(sql, person);
            return response;
        }
        //Metod som tar bort en användare
        public Task<bool> DeleteUser(int id)
        {
            var sql = $"delete from dbo.[User] where UserId = {id}";
            var response = _sqlDataAccess.ExecuteSqlAsync(sql, id);
            return response;
        }
    }
}
