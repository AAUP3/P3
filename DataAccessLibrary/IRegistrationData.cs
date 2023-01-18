using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IRegistrationData
    {
        Task InsertRegistration(RegistrationModel registration);
        Task<List<RegistrationModel>> GetCurrentUserRegistrations(string userId);
        Task CancelRegistration(string userId, int unionActivityId);
        Task<List<RegistrationModel>> GetAllRegistrations();
        Task DeleteAllRegistrationsOfUnionActivity(int unionActivityId);
        Task<List<RegistrationModel>> OrderRegistrations(int id, string column);
    }
}