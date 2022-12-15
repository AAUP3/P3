using DataAccessLibrary.Models;
using System.Data;

namespace DataAccessLibrary
{
    public interface IUnionActivityData
    {
        Task<List<UnionActivityModel>> GetUnionActivities();
        Task InsertUnionActivity(UnionActivityModel unionActivity);
        Task UpdateUnionActivity(int id, UnionActivityModel unionActivity);
        Task DeleteUnionActivity(int id, UnionActivityModel unionActivity);
        Task<List<UnionActivityModel>> OrderActivities(string column);
        Task CheckIfColumnExistsElseCreate(string column);
        Task<UnionActivityModel> GetSingleUnionActivity(int id);
        List<UnionActivityModel> GetUnionActivitiesTest();

    }
}