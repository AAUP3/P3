using Autofac.Extras.Moq;
using Bunit;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Diagnostics;
using Xunit; 

namespace Testing
{
    public class ParameterizedTests
    {
        public bool IsOddNumber(int number)
        {
            return number % 2 != 0;
        }

        [Theory]
        //[InlineData(5, 1, 3, 9)]
        //[InlineData(7, 1, 5, 3)]
        [InlineData(7, 9, 5, 5, "hello")]

        public void AllNumbers_AreOdd_WithInlineData(int a, int b, int c, int d, string e)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
            //Assert.Equal(a, 7);
            Assert.Equal(e, "hello");
        }



        public Task<List<UnionActivityModel>> GetUnionActivities()
        {
            string sql = "select * from dbo.UnionActivityData";

            //return _db.LoadData<UnionActivityModel, dynamic>(sql, new { });
            return null;
        }



        public void LoadUnionActivities_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {

            }
            throw new NotImplementedException();
        }



        private List<UnionActivityModel> LoadSampleActivities()
        {
            List<UnionActivityModel> output = new List<UnionActivityModel>
            {
                new UnionActivityModel
                {
                    Id = 1,
                    Name = "Første begivenhed",
                    Description = "Første beskrivelse"
                    
                },
                new UnionActivityModel
                {
                    Id = 2,
                    Name = "Begivenhed 2 navn",
                    Description = "Beskrivelse2"
                }
            };
            return output;
        }



        [Fact]
        public void Load_valid()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ISqlDataAccess>()
                    .Setup(x => x.LoadDataNew<UnionActivityModel>("select * from dbo.UnionActivityData;"))
                    .Returns(LoadSampleActivities());

                var cls = mock.Create<UnionActivityData>();
                var expected = LoadSampleActivities();

                var actual = cls.GetUnionActivitiesTest();

                Assert.True(actual != null);
                Assert.True(expected != null);
                Assert.Equal(expected.Count, actual.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].Name, actual[i].Name);
                    Debug.WriteLine("Test");
                    
                }
            }
            
            
        }
        /*
        [Fact]
        public async void LoadActivities_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ISqlDataAccess>()
                    .Setup(x => x.LoadData<UnionActivityModel, dynamic > ("select * from dbo.UnionActivityData", new { }))
                    .Returns(LoadSampleActivities());

                var cls = mock.Create<UnionActivityData>();
                var expected = LoadSampleActivities();

                var expected2 = cls.GetUnionActivities();
                var actual = cls.GetUnionActivities();
                
                Assert.True(actual != null);
                Assert.True(expected != null);
                Assert.Equal(actual.Result, expected.Result);
               // Assert.Equal(expected, 2);
                //Assert.Equal(expected, actual);
                

                for (int i = 0; i < 2; i++)
                {
                   // Assert.Equal(expected[i], actual[i]);
                }
            }
            
        }*/
    }
}