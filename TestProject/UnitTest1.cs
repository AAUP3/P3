using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using System;
using System.Diagnostics;
using System.Data;
using Bunit;
using P3_Project.Pages.UnionActivities.AdministratorViews;
using P3_Project.Pages.UnionActivities.MemberViews;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using P3_Project.Models;

namespace TestProject
{
    public class UnitTest1 : TestContext
    {
        //arrange

        private static List<InformationFieldModel> infoFields = new List<InformationFieldModel> { new InformationFieldModel("G1") , new InformationFieldModel("G2") , new InformationFieldModel("G3") , new InformationFieldModel("G4") , new InformationFieldModel("G5") };
        private static List<InformationFieldModel> pInfoFields = new List<InformationFieldModel> { new InformationFieldModel("P1") , new InformationFieldModel("P2") , new InformationFieldModel("P3") , new InformationFieldModel("P4") , new InformationFieldModel("P5") };


        private static DisplayUnionActivityModel newUnionActivity = new DisplayUnionActivityModel
        {
            Name = "Flyvetur",
            Description = "Beskrivelse",
            DateOfActivity = new DateTime(2001, 9, 8),
            IsVisible = false,
            RequireName = true,
            RequireEmail = true,
            RequirePhonenumber = true,
            IsYearlyActivity = true,
            AllowRegistration = true,
            AllowGroupRegistration = true
        };


        private static UnionActivityModel testUnionActivity = new UnionActivityModel
        {
            Name = "",
            Description = "",
            DateOfActivity = DateTime.Today,
            IsVisible = false,
            RequireName = false,
            RequireEmail = false,
            RequirePhonenumber = false,
            Information1 = "",
            Information2 = "",
            Information3 = "",
            Information4 = "",
            Information5 = "",
            PInformation1 = "",
            PInformation2 = "",
            PInformation3 = "",
            PInformation4 = "",
            PInformation5 = "",
            IsYearlyActivity = false,
            AllowRegistration = false,
            AllowGroupRegistration = false
        };

        private static int infoCount, pInfoCount = 0;


        [Fact]
        public void TestUnionActivityModelTransfer()
        {
            //act

            testUnionActivity = CreateUnionActivity.SubmitUnionActivity(infoCount, pInfoCount, infoFields, pInfoFields, newUnionActivity, testUnionActivity);

            //assert
            Assert.Equal(newUnionActivity.Name, testUnionActivity.Name);
            Assert.Equal(newUnionActivity.Description, testUnionActivity.Description);
            Assert.Equal(newUnionActivity.DateOfActivity, testUnionActivity.DateOfActivity);

            Assert.Equal(infoFields[0].Name, testUnionActivity.Information1);
            Assert.Equal(infoFields[1].Name, testUnionActivity.Information2);
            Assert.Equal(infoFields[2].Name, testUnionActivity.Information3);
            Assert.Equal(infoFields[3].Name, testUnionActivity.Information4);
            Assert.Equal(infoFields[4].Name, testUnionActivity.Information5);

            Assert.Equal(pInfoFields[0].Name, testUnionActivity.PInformation1);
            Assert.Equal(pInfoFields[1].Name, testUnionActivity.PInformation2);
            Assert.Equal(pInfoFields[2].Name, testUnionActivity.PInformation3);
            Assert.Equal(pInfoFields[3].Name, testUnionActivity.PInformation4);
            Assert.Equal(pInfoFields[4].Name, testUnionActivity.PInformation5);

            Assert.True(testUnionActivity.RequireName);
            Assert.True(testUnionActivity.RequireEmail);
            Assert.True(testUnionActivity.RequirePhonenumber);
            Assert.True(testUnionActivity.IsYearlyActivity);
            Assert.True(testUnionActivity.AllowRegistration);
            Assert.True(testUnionActivity.AllowGroupRegistration);

        }
    }

    public class UnitTest2 : TestContext 
    {
        private static int Id = 5;
        private static string userId = "iuwery78weiofu89";
        string format = "## ## ## ##";


        private static List<DisplayRegistrationModel> testRegistrations = new List<DisplayRegistrationModel>();

        private static DisplayRegistrationModel DisplayRegistration = new DisplayRegistrationModel
        {
            FlightRegistrationNumber = "",
            Type = "",
            MaxTakeoffWeight = 0,
            Club = "",
            StartDestination = "",
            Name = "",
            Email = "",
            Phonenumber = "",
            ParticipantType = "",
            UnionActivityID = 0,
            UserId = "",
            Information1 = "",
            Information2 = "",
            Information3 = "",
            Information4 = "",
            Information5 = "",
            PInformation1 = "",
            PInformation2 = "",
            PInformation3 = "",
            PInformation4 = "",
            PInformation5 = ""
        };

        private static UnionActivityModel UnionActivity = new UnionActivityModel
        {
            Name = "Flyvetur",
            Description = "Beskrivelse",
            DateOfActivity = new DateTime(2001, 9, 8),
            IsVisible = false,
            RequireName = true,
            RequireEmail = true,
            RequirePhonenumber = true,
            IsYearlyActivity = true,
            AllowRegistration = true,
            AllowGroupRegistration = true
        };

        private static List<RegistrationModel> testRegistrations = new List<RegistrationModel>();



        [Fact]
        public void TestRegistrationModelTransfer() 
        {

            testRegistrations = RegistrationPage.SubmitRegistration(Id, userId, format, DisplayRegistration, DisplayRegistrations, unionActivity, unionActivities);



        }
    
    }
    
}