using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IRegistrationData
    {
        Task DeleteRegistration(int id, UnionActivityModel unionActivity);
        Task<List<RegistrationModel>> GetRegistrations(int id);
        Task InsertRegistration(RegistrationModel registration);
        Task<List<RegistrationModel>> GetCurrentUserRegistrations(string userId);
        Task<RegistrationModel> GetSingleUserRegistration(string userId, int unionActivityId);
        Task CancelRegistration(string userId, int unionActivityId);
        Task<List<RegistrationModel>> GetAllRegistrations();
        Task DeleteAllRegistrationsOfUnionActivity(int unionActivityId);
        Task<List<RegistrationModel>> OrderRegistrations(int id, string column);
    }
}