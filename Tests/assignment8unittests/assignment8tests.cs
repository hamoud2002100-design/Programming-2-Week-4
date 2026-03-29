using NUnit.Framework;

namespace Assignment8.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private Program _program;

        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [TestCase(1, "Monday")]
        [TestCase(2, "Tuesday")]
        [TestCase(3, "Wednesday")]
        [TestCase(4, "Thursday")]
        [TestCase(5, "Friday")]
        [TestCase(6, "Saturday")]
        [TestCase(7, "Sunday")]
        [TestCase(0, "Invalid day number")]
        [TestCase(8, "Invalid day number")]
        public void GetDayOfWeek_VariousInputs_ReturnsExpectedResult(int dayNumber, string expected)
        {
            // Act
            string result = _program.GetDayOfWeek(dayNumber);

            // Assert
            Assert.AreEqual(expected, result, $"For day number {dayNumber}, expected {expected} but got {result}.");
        }
    }
}
