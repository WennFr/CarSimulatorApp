using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationServiceLibrary.Services;
using NUnit.Framework;
using System;
using System.IO;

namespace ValidationServiceTests.Services
{
    public class ValidationServiceTests
    {
        private IValidationService _sut;
        private StringWriter _stringWriter;
        private StringReader _stringReader;

        [SetUp]
        public void Setup()
        {
            _sut = new ValidationService();
            _stringWriter = new StringWriter();
            _stringReader = new StringReader("");
            Console.SetOut(_stringWriter);
            Console.SetIn(_stringReader);
        }

        [Test]
        public void Menu_Selection_1_Is_Valid()
        {
            _stringReader = new StringReader("1");
            Console.SetIn(_stringReader);
            var expectedMenuSelection = 1;

            // Act
            var result = _sut.ValidateMenuSelection(7);

            // Assert
            Assert.AreEqual(expectedMenuSelection, result);
        }

        [Test]
        public void Menu_Selection_2_Is_Valid()
        {
            _stringReader = new StringReader("2");
            Console.SetIn(_stringReader);
            var expectedMenuSelection = 2;

            // Act
            var result = _sut.ValidateMenuSelection(7);

            // Assert
            Assert.AreEqual(expectedMenuSelection, result);
        }

        [Test]
        public void Menu_Selection_3_Is_Valid()
        {
            _stringReader = new StringReader("3");
            Console.SetIn(_stringReader);
            var expectedMenuSelection = 3;

            // Act
            var result = _sut.ValidateMenuSelection(7);

            // Assert
            Assert.AreEqual(expectedMenuSelection, result);
        }

        [Test]
        public void Menu_Selection_4_Is_Valid()
        {
            _stringReader = new StringReader("4");
            Console.SetIn(_stringReader);
            var expectedMenuSelection = 4;

            // Act
            var result = _sut.ValidateMenuSelection(7);

            // Assert
            Assert.AreEqual(expectedMenuSelection, result);
        }

        [Test]
        public void Menu_Selection_5_Is_Valid()
        {
            _stringReader = new StringReader("5");
            Console.SetIn(_stringReader);
            var expectedMenuSelection = 5;

            // Act
            var result = _sut.ValidateMenuSelection(7);

            // Assert
            Assert.AreEqual(expectedMenuSelection, result);
        }

        [Test]
        public void Menu_Selection_6_Is_Valid()
        {
            _stringReader = new StringReader("6");
            Console.SetIn(_stringReader);
            var expectedMenuSelection = 6;

            // Act
            var result = _sut.ValidateMenuSelection(7);

            // Assert
            Assert.AreEqual(expectedMenuSelection, result);
        }


        [Test]
        public void Menu_Selection_7_Is_Valid()
        {
            _stringReader = new StringReader("7");
            Console.SetIn(_stringReader);
            var expectedMenuSelection = 7;

            // Act
            var result = _sut.ValidateMenuSelection(7);

            // Assert
            Assert.AreEqual(expectedMenuSelection, result);
        }

    }
}
