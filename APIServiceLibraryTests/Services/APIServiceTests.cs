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
        public async Task GetOneDriver_Returns_Valid_Driver_Information()
        {


            //Act
            var result = await _sut.GetOneDriver();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Name.Title));
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Name.First));
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Name.Last));
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Location.City));
            Assert.IsFalse(string.IsNullOrEmpty(result.Results[0].Location.Country));

        }
    }
}