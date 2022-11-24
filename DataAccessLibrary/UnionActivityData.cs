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
            string sql = @"insert into dbo.UnionActivity (Name, Description) values (@Name, @Description);";

            return _db.SaveData(sql, unionActivity);
        }

    }
}
