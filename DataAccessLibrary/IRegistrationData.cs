using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IRegistrationData
    {
        Task DeleteRegistration(int id, UnionActivityModel unionActivity);
        Task<List<RegistrationModel>> GetRegistrations(int id);
        Task InsertRegistration(RegistrationModel registration);
    }
}