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
using Microsoft.VisualBasic;

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
            string sql = "select * from dbo.UnionActivityData";

            return _db.LoadData<UnionActivityModel>(sql);
        }


        public Task<UnionActivityModel> GetSingleUnionActivity(int id)
        {
            string sql = $"select * from dbo.UnionActivityData where Id={id};";

            return _db.LoadDataSingle<UnionActivityModel>(sql);
        }


        public Task InsertUnionActivity(UnionActivityModel unionActivity)
        {
            string sql = @"insert into dbo.UnionActivityData (Name, Description, DateOfActivity, IsVisible, RequireName, RequireEmail, RequirePhonenumber, 
                                                            Information1, Information2, Information3, Information4, Information5, IsYearlyActivity, 
                                                            AllowRegistration, AllowGroupRegistration, PInformation1, PInformation2, PInformation3, 
                                                            PInformation4, PInformation5) 
                                                     values (@Name, @Description, @DateOfActivity, @IsVisible, @RequireName, @RequireEmail, @RequirePhonenumber, 
                                                            @Information1, @Information2, @Information3, @Information4, @Information5, @IsYearlyActivity, 
                                                            @AllowRegistration, @AllowGroupRegistration, @PInformation1, @PInformation2, @PInformation3, 
                                                            @PInformation4, @PInformation5);";

            return _db.SaveData(sql, unionActivity);
        }


        public Task UpdateUnionActivity(int id, UnionActivityModel unionActivity)
        {
            string sql = @"update dbo.UnionActivityData set Name=@Name, Description=@Description, DateOfActivity=@DateOfActivity, IsVisible=@IsVisible, 
                                                            RequireName=@RequireName, RequireEmail=@RequireEmail, RequirePhonenumber=@RequirePhonenumber, 
                                                            IsYearlyActivity=@IsYearlyActivity, AllowRegistration=@AllowRegistration, 
                                                            AllowGroupRegistration=@AllowGroupRegistration where Id=@id;";

            return _db.SaveData(sql, unionActivity);
        }


        public Task DeleteUnionActivity(int id, UnionActivityModel unionActivity)
        {
            string sql = @"delete from dbo.UnionActivityData where Id=@id;";

            return _db.SaveData(sql, unionActivity);
        }

        public Task<List<UnionActivityModel>> OrderActivities(string column)
        {
            string sql = $"select * from dbo.UnionActivityData order by {column};";

            //await _db.SaveDataTest(sql, List);
            return _db.LoadData<UnionActivityModel>(sql);
        }

        public Task SaveSingle(string column ,int i, int id, string value)
        {
            string sql = $"update dbo.UnionActivityData set {column}{i}='{value}' where Id={id};";

            return _db.UpdateTable(sql);
        }

        public Task CheckIfColumnExistsElseCreate(string column)
        {
            if (column == null)
            {
                throw new Exception("It's Britney B*tch");
            }
            else
            {
                string sql = $"if COL_LENGTH('dbo.Registration', '{column}') is null begin alter table Registration add {column} nvarchar(max) null end;";
                return _db.UpdateTable(sql);
            }
            

            
        }

        


    }
}
