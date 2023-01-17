using System.Collections.Generic;

namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T>(string sql);
        Task SaveData<T>(string sql, T parameters);
        Task<T> LoadDataSingle<T>(string sql);
        Task UpdateTable(string sql);
        

    }
}