using BlazorDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDemo.DataAccess.Services
{
    public class PetDataService:IPetDataService
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public PetDataService(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public Task<Pet> GetPet(int id)
        {
            var sql = $"select * from dbo.Pet where PetId = {id}";
            return _sqlDataAccess.LoadDataEntityAsync<Pet, dynamic>(sql, id);
        }
    
        public Task<int> GetLastInsertedPetId()
        {
            const string sql = @"select top (1) PetId from dbo.Pet order by PetId desc";
            return _sqlDataAccess.LoadDataNoParameterAsync<int>(sql);
        }

        public Task<List<Pet>> GetPets()
        {
            const string sql = "select * from dbo.Pet";
            return _sqlDataAccess.LoadDataListAsync<Pet, dynamic>(sql, new { });
        }

        public Task<bool> InsertPet(Pet pet)
        {
            if (string.IsNullOrWhiteSpace(pet.Name) || string.IsNullOrWhiteSpace(pet.Species)
                || pet.UserId == 0) throw new Exception();
            const string sql = @"insert into dbo.Pet (Name, Species, UserId)" +
                      "values (@Name, @Species, @UserId)";
            var response = _sqlDataAccess.ExecuteSqlAsync(sql, pet);
            return response;
        }
        public Task<bool> UpdatePet(int id, Pet pet)
        {
            if (string.IsNullOrWhiteSpace(pet.Name) || string.IsNullOrWhiteSpace(pet.Species) ||
                pet.UserId == 0) throw new Exception();
            var sql = @"update dbo.Pet " +
                              $@"set Name = '{pet.Name}',Species = '{pet.Species}'," +
                              $"UserId = '{pet.UserId}' " +
                              $"where id = {id}";
            var response = _sqlDataAccess.ExecuteSqlAsync(sql, pet);
            return response;
        }
        public Task<bool> DeletePet(int id)
        {
            var sql = $"delete from dbo.Pet where PetId = {id}";
            var response = _sqlDataAccess.ExecuteSqlAsync(sql, id);
            return response;
        }
    }
}
