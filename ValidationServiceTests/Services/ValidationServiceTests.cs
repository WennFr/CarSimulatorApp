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

        [Test]
        public void Menu_Selection_InvalidInput()
        {
            // Arrange
            var input = "abc";
            var expectedOutput = $"{Environment.NewLine}Choose between the available menu numbers{Environment.NewLine}";

            using (ManualResetEventSlim resetEvent = new ManualResetEventSlim(false))
            {
                // Start a separate thread to execute the method
                Thread executionThread = new Thread(() =>
                {
                    _sut.ValidateMenuSelection(7);
                    resetEvent.Set(); // Signal the test thread when execution is complete
                });

                // Capture the console output
                using (StringWriter stringWriter = new StringWriter())
                {
                    var consoleOut = Console.Out; // Backup original Console.Out
                    Console.SetOut(stringWriter); // Redirect Console.Out to the StringWriter

                    // Start the execution thread
                    executionThread.Start();

                    // Wait for the expected output or execution completion
                    resetEvent.Wait(); // Wait for the signal from the execution thread

                    var output = stringWriter.ToString();

                    // Assert
                    Assert.AreEqual(expectedOutput, output);

                    // Restore original Console.Out
                    Console.SetOut(consoleOut);

                    // Wait for the execution thread to complete
                    executionThread.Join();
                }
            }
        }








    }
}
