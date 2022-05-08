using BlazorDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDemo.DataAccess.Services
{
    public interface IPetDataService
    {
        Task<Pet> GetPet(int id);

        Task<int> GetLastInsertedPetId();

        Task<List<Pet>> GetPets();

        Task<bool> InsertPet(Pet pet);

        Task<bool> DeletePet(int id);
    }
}
