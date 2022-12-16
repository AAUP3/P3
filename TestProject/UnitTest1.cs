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
        //arrange
        private static int Id = 5;
        private static string userId = "iuwery78weiofu89";
        string format = "## ## ## ##";

        private static DisplayRegistrationModel DisplayRegistration = new DisplayRegistrationModel
        {
            FlightRegistrationNumber = "OY-9933",
            Type = "Cessna",
            MaxTakeoffWeight = 2000,
            Club = "DMU",
            StartDestination = "Aalborg",
            Information1 = "G1svar",
            Information2 = "G2svar",
            Information3 = "G3svar",
            Information4 = "G4svar",
            Information5 = "G5svar"
        };

        private static List<DisplayRegistrationModel> DisplayRegistrations = new List<DisplayRegistrationModel>
        {
            new DisplayRegistrationModel
        {
            Name = "Bj�rn",
            Email = "bj�rn@bj�rn.dk",
            Phonenumber = "99887766",
            ParticipantType = "PIC",
            PInformation1 = "P1svar",
            PInformation2 = "P2svar",
            PInformation3 = "P3svar",
            PInformation4 = "P4svar",
            PInformation5 = "P5svar"
        },
            new DisplayRegistrationModel
        {
            Name = "Ida",
            Email = "ida@ida.dk",
            Phonenumber = "66778899",
            ParticipantType = "PAX",
            PInformation1 = "P1svar2",
            PInformation2 = "P2svar2",
            PInformation3 = "P3svar2",
            PInformation4 = "P4svar2",
            PInformation5 = "P5svar2"
        }
        };

        private static UnionActivityModel unionActivity = new UnionActivityModel
        {
            AllowGroupRegistration = true
        };

        private static List<RegistrationModel> testRegistrations = new List<RegistrationModel>();



        [Fact]
        public void TestRegistrationModelTransfer() 
        {
            //act
            testRegistrations = RegistrationPage.SubmitRegistration(Id, userId, format, DisplayRegistration, DisplayRegistrations, unionActivity);

            //assert
            //registration for person 1
            Assert.Equal(DisplayRegistration.FlightRegistrationNumber, testRegistrations[0].FlightRegistrationNumber);
            Assert.Equal(DisplayRegistration.Type, testRegistrations[0].Type);
            Assert.Equal(DisplayRegistration.MaxTakeoffWeight, testRegistrations[0].MaxTakeoffWeight);
            Assert.Equal(DisplayRegistration.Club, testRegistrations[0].Club);
            Assert.Equal(DisplayRegistration.StartDestination, testRegistrations[0].StartDestination);
            Assert.Equal(DisplayRegistrations[0].Name, testRegistrations[0].Name);
            Assert.Equal(DisplayRegistrations[0].Email, testRegistrations[0].Email);
            Assert.Equal(Convert.ToInt64(DisplayRegistrations[0].Phonenumber).ToString(format), testRegistrations[0].Phonenumber);
            Assert.Equal(DisplayRegistrations[0].ParticipantType, testRegistrations[0].ParticipantType);
            Assert.Equal(Id, testRegistrations[0].UnionActivityID);
            Assert.Equal(userId, testRegistrations[0].UserId);
            Assert.Equal(DisplayRegistration.Information1, testRegistrations[0].Information1);
            Assert.Equal(DisplayRegistration.Information2, testRegistrations[0].Information2);
            Assert.Equal(DisplayRegistration.Information3, testRegistrations[0].Information3);
            Assert.Equal(DisplayRegistration.Information4, testRegistrations[0].Information4);
            Assert.Equal(DisplayRegistration.Information5, testRegistrations[0].Information5);
            Assert.Equal(DisplayRegistrations[0].PInformation1, testRegistrations[0].PInformation1);
            Assert.Equal(DisplayRegistrations[0].PInformation2, testRegistrations[0].PInformation2);
            Assert.Equal(DisplayRegistrations[0].PInformation3, testRegistrations[0].PInformation3);
            Assert.Equal(DisplayRegistrations[0].PInformation4, testRegistrations[0].PInformation4);
            Assert.Equal(DisplayRegistrations[0].PInformation5, testRegistrations[0].PInformation5);

            //registration for person 2
            Assert.Equal(DisplayRegistration.FlightRegistrationNumber, testRegistrations[1].FlightRegistrationNumber);
            Assert.Equal(DisplayRegistration.Type, testRegistrations[1].Type);
            Assert.Equal(DisplayRegistration.MaxTakeoffWeight, testRegistrations[1].MaxTakeoffWeight);
            Assert.Equal(DisplayRegistration.Club, testRegistrations[1].Club);
            Assert.Equal(DisplayRegistration.StartDestination, testRegistrations[1].StartDestination);
            Assert.Equal(DisplayRegistrations[1].Name, testRegistrations[1].Name);
            Assert.Equal(DisplayRegistrations[1].Email, testRegistrations[1].Email);
            Assert.Equal(Convert.ToInt64(DisplayRegistrations[1].Phonenumber).ToString(format), testRegistrations[1].Phonenumber);
            Assert.Equal(DisplayRegistrations[1].ParticipantType, testRegistrations[1].ParticipantType);
            Assert.Equal(Id, testRegistrations[1].UnionActivityID);
            Assert.Equal(userId, testRegistrations[1].UserId);
            Assert.Equal(DisplayRegistration.Information1, testRegistrations[1].Information1);
            Assert.Equal(DisplayRegistration.Information2, testRegistrations[1].Information2);
            Assert.Equal(DisplayRegistration.Information3, testRegistrations[1].Information3);
            Assert.Equal(DisplayRegistration.Information4, testRegistrations[1].Information4);
            Assert.Equal(DisplayRegistration.Information5, testRegistrations[1].Information5);
            Assert.Equal(DisplayRegistrations[1].PInformation1, testRegistrations[1].PInformation1);
            Assert.Equal(DisplayRegistrations[1].PInformation2, testRegistrations[1].PInformation2);
            Assert.Equal(DisplayRegistrations[1].PInformation3, testRegistrations[1].PInformation3);
            Assert.Equal(DisplayRegistrations[1].PInformation4, testRegistrations[1].PInformation4);
            Assert.Equal(DisplayRegistrations[1].PInformation5, testRegistrations[1].PInformation5);

        }
    
    }
    
}