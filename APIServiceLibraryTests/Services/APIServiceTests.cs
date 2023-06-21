using APIServiceLibrary.Services;
using System;

namespace APIServiceLibraryTests.Services
{
    [TestClass]
    public class APIServiceTests
    {
        public APIServiceTests()
        {
            _sut = new APIService();
        }

        private APIService _sut;

        [TestMethod]
        public async Task GetOneDriver_Returns_Not_Null_Object()
        {

            //Act
            var result = await _sut.GetOneDriver();

            //Assert
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public async Task GetOneDriver_Returns_Valid_Title()
        {

            //Act
            var result = await _sut.GetOneDriver();

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Name.Title));
        }


        [TestMethod]
        public async Task GetOneDriver_Returns_Valid_First_Name()
        {
            //Act
            var result = await _sut.GetOneDriver();

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Name.First));
        }


 

        [TestMethod]
        public async Task GetOneDriver_Returns_Valid_Last_Name()
        {


            //Act
            var result = await _sut.GetOneDriver();

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Name.Last));

        }

        
        [TestMethod]
        public async Task GetOneDriver_Returns_Valid_City()
        {


            //Act
            var result = await _sut.GetOneDriver();

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Location.City));

        }

        [TestMethod]
        public async Task GetOneDriver_Returns_Valid_Country()
        {

            //Act
            var result = await _sut.GetOneDriver();

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Location.Country));
        }



    }
}