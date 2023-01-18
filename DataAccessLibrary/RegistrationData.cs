using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class RegistrationData : IRegistrationData
    {
        private readonly ISqlDataAccess _db;

        public RegistrationData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<RegistrationModel>> GetAllRegistrations()
        {
            string sql = $"select * from dbo.Registration;";

            return _db.LoadData<RegistrationModel>(sql);
        }

        public Task<List<RegistrationModel>> OrderRegistrations(int id, string column)
        {
            string sql = $"select * from dbo.Registration where UnionActivityID={id} order by {column};";

            return _db.LoadData<RegistrationModel>(sql);
        }

        public Task InsertRegistration(RegistrationModel registration)
        {
            string sql = @"insert into dbo.Registration (FlightRegistrationNumber, Type, MTOW, Club, Startdestination, Name, Email, Phonenumber, ParticipantType, UnionActivityID, UserId, Information1, Information2, Information3, Information4, Information5, PInformation1, PInformation2, PInformation3, PInformation4, PInformation5) 
                                                values (@FlightRegistrationNumber, @Type, @MTOW, @Club, @Startdestination, @Name, @Email, @Phonenumber, @ParticipantType, @UnionActivityID, @UserId, @Information1, @Information2, @Information3, @Information4, @Information5, @PInformation1, @PInformation2, @PInformation3, @PInformation4, @PInformation5);";

            return _db.SaveData(sql, registration);
        }

        public Task<List<RegistrationModel>> GetCurrentUserRegistrations(string userId)
        {
            string sql = $"select * from dbo.Registration where UserId='{userId}';";

            return _db.LoadData<RegistrationModel>(sql);
        }

        public Task CancelRegistration(string userId, int unionActivityId)
        {
            string sql = $"delete from dbo.Registration where UserId='{userId}' and UnionActivityID={unionActivityId};";

            return _db.UpdateTable(sql);
        }

        public Task DeleteAllRegistrationsOfUnionActivity(int unionActivityId)
        {
            string sql = $"delete from dbo.Registration where UnionActivityID={unionActivityId};";

            return _db.UpdateTable(sql);
        }


        





    }
}
