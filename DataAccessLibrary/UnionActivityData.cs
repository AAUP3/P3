using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLibrary
{
    public class UnionActivityData : IUnionActivityData
    {
        private readonly ISqlDataAccess _db;

        public UnionActivityData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<UnionActivityModel>> GetUnionActivities()
        {
            string sql = "select * from dbo.UnionActivity";

            return _db.LoadData<UnionActivityModel, dynamic>(sql, new { });
        }


        public Task InsertUnionActivity(UnionActivityModel unionActivity)
        {
            string sql = @"insert into dbo.UnionActivity (Name, Description, DateOfActivity, IsVisible) values (@Name, @Description, @DateOfActivity, @IsVisible);";

            return _db.SaveData(sql, unionActivity);
        }


        public Task UpdateUnionActivity(int id, UnionActivityModel unionActivity)
        {
            string sql = @"update dbo.UnionActivity set Name=@Name, Description=@Description, DateOfActivity=@DateOfActivity, IsVisible=@IsVisible where Id=@id;";

            return _db.SaveData(sql, unionActivity);
        }


        public Task DeleteUnionActivity(int id, UnionActivityModel unionActivity)
        {
            string sql = @"delete from dbo.UnionActivity where Id=@id;";

            return _db.SaveData(sql, unionActivity);
        }
    }
}
