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

        // Maybe order this based on FlightRegistrationNumber to group the participants by plane (Wanted by DMU).
        public Task<List<RegistrationModel>> GetRegistrations(int id)
        {
            string sql = $"select * from dbo.Registration where UnionActivityID={id};";

            return _db.LoadData<RegistrationModel, dynamic>(sql, new { });
        }


        public Task InsertRegistration(RegistrationModel registration)
        {
            string sql = @"insert into dbo.Registration (FlightRegistrationNumber, Type, MTOW, Club, Startdestination, Name, Email, Phonenumber, ParticipantType, UnionActivityID) values (@FlightRegistrationNumber, @Type, @MaxTakeoffWeight, @Club, @Startdestination, @Name, @Email, @Phonenumber, @ParticipantType, @UnionActivityID);";

            return _db.SaveData(sql, registration);
        }


        //public Task UpdateUnionActivity(int id, UnionActivityModel unionActivity)
        //{
        //    string sql = @"update dbo.UnionActivityData set Name=@Name, Description=@Description, DateOfActivity=@DateOfActivity, IsVisible=@IsVisible where Id=@id;";
        //
        //    return _db.SaveData(sql, unionActivity);
        // }


        public Task DeleteRegistration(int id, UnionActivityModel unionActivity)
        {
            string sql = @"delete from dbo.UnionActivityData where Id=@id;";

            return _db.SaveData(sql, unionActivity);
        }


        





    }
}
