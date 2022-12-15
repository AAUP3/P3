using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using System;
using System.Diagnostics;
using Bunit;
using P3_Project.Pages.UnionActivities.AdministratorViews;
using DataAccessLibrary;


namespace TestProject
{
    public class UnitTest1 : TestContext
    {
        [Fact]
        public void Test1()
        {

            var cut = RenderComponent<CreateUnionActivity>();
            //arrange

            //public List<InformationFieldModel> infoFields = new List<InformationFieldModel>();
            //public List<InformationFieldModel> pInfoFields = new List<InformationFieldModel>();

            //private DisplayUnionActivityModel newUnionActivity = new DisplayUnionActivityModel();

            //act

            //assert

            //public UnionActivityModel testUnionActivity = new UnionActivityModel();

        }

        public bool IsOddNumber(int number)
        {
            return number % 2 != 0;
        }

        [Theory]
        [InlineData(7, 9, 5, 5, "hello")]
        public void AllNumbers_AreOdd_WithInlineData(int a, int b, int c, int d, string e)
        {
            Assert.True(IsOddNumber(a));
            Assert.True(IsOddNumber(b));
            Assert.True(IsOddNumber(c));
            Assert.True(IsOddNumber(d));
            Assert.Equal(b, 9);
            Assert.Equal(e, "hello");
        }

    }




}