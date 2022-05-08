using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.DataAccess.Services
{
    public interface ISqlDataAccess
    {
        Task<T> LoadDataNoParameterAsync<T>(string sql);
        Task<T> LoadDataEntityAsync<T, TU>(string sql, TU parameters);
        Task<List<T>> LoadDataListAsync<T, TU>(string sql, TU parameters);
        Task<bool> ExecuteSqlAsync<T>(string sql, T parameters);
    }
}