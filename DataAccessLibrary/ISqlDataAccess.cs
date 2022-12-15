using DataAccessLibrary.Models;
using System.Collections.Generic;

namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        Task<T> LoadDataSingle<T, U>(string sql, U parameters);
        Task SaveDataTest(string sql);
        List<UnionActivityModel> LoadDataTest(string sql);
        List<T> LoadDataNew<T>(string sql);
    }
}