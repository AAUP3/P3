using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IUnionActivityData
    {
        Task<List<UnionActivityModel>> GetUnionActivities();
        Task InsertUnionActivity(UnionActivityModel unionActivity);
    }
}