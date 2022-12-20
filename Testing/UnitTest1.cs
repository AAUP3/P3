using Autofac.Extras.Moq;
using Bunit;
using Bunit.Asserting;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Moq;
using P3_Project.Pages;
using P3_Project.Pages.UnionActivities.AdministratorViews;
using P3_Project.Pages.UnionActivities.MemberViews;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Xunit;


namespace Testing
{
    public class ParameterizedTests 
    {
        
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
                    Debug.WriteLine("Expected:" + expected[i].Name + " Actual:" + actual[i].Name);
                    
                }
            }
            
            
        }


        [Fact]
        public void SaveUnionActivity_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var activity = new UnionActivityModel
                {
                    Id = 3,
                    Name = "Begivenhed 3",
                    Description = "Tredje beskrivelse"
                };
                string sql = $"insert into dbo.UnionActivityData (Id, Name, Description) values ({activity.Id}, {activity.Name}, {activity.Description});";

                var context = new Mock<ISqlDataAccess>();
                var command = mock.Create<UnionActivityData>();

                command.InsertUnionActivity(activity);

                mock.Mock<ISqlDataAccess>()
                    .Setup(x => x.LoadDataNew<UnionActivityModel>("select * from dbo.UnionActivityData;"))
                    .Returns(LoadSampleActivities());

                mock.Mock<ISqlDataAccess>().Setup(x => x.SaveDataTest(sql));

                

                var expected = activity;

                var actual = command.GetUnionActivitiesTest();



/*
                mock.Mock<ISqlDataAccess>()
                    .Setup(x => x.SaveDataTest(sql));

                mock.Mock<ISqlDataAccess>()
                    .Setup(x => x.LoadDataNew<UnionActivityModel>("select * from dbo.UnionActivityData;"))
                    .Returns(LoadSampleActivities());

                var cls = mock.Create<UnionActivityData>();
                cls.InsertUnionActivity(activity);

                var expected = activity;

                var actual = cls.GetSingleUnionActivity(activity.Id);
                var actual2 = cls.GetUnionActivitiesTest();*/

                Assert.True(expected != null);
                Assert.True(actual != null);
                //Assert.True(actual2 != null);
                //Assert.Equal(expected.Name, actual2[actual2.Count].Name);
                for (int i = 0; i < actual.Count; i++)
                {
                    Debug.WriteLine(actual[i].Name);
                }
            }
        }


        [Fact]
        public void UpdateCounter_ValidCall()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();
            var cut2 = cut.Find($"#test");
            cut2.Click();
            //cut.FindComponents<>("test");

            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }


        
        public void UpdateUnionActivity_ValidCall()
        {
            using var ctx = new TestContext();
           // ctx.Services.AddSingleton<IUnionActivityData>(new UnionActivityData());
            //var UA = ctx.RenderComponent<ListOfUnionActivities>();

            //Assert.NotNull(UA.Instance);
            
            
            
            /*var updateActivity = ctx.RenderComponent<UpdateUnionActivityFormPage>();
            var skrivebord = ctx.RenderComponent<Skrivebord>();
            var updateActivityButton = updateActivity.Find($"#update");
            updateActivityButton.Click();*/
            //cut.FindComponents<>("test");
            //cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }

    }
}