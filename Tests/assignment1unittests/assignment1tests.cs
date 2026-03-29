using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using Assignment1;

namespace Assignment1.Tests
{
    [TestFixture]
    public class AssignmentTests
    {
        [SetUp]
        public void SetUp()
        {
            // Set the culture to invariant culture for the tests
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [Test]
        public void StudentConstructor_ShouldInitializeProperties()
        {
            // Arrange
            string expectedName = "John Doe";
            int expectedID = 123;
            double expectedGrade = 95.5;

            // Act
            Student student = new Student(expectedName, expectedID, expectedGrade);

            // Assert
            Assert.That(student.Name, Is.EqualTo(expectedName));
            Assert.That(student.ID, Is.EqualTo(expectedID));
            Assert.That(student.Grade, Is.EqualTo(expectedGrade));
        }

        [Test]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            string name = "Jane Doe";
            int id = 456;
            double grade = 88.7;
            Student student = new Student(name, id, grade);
            string expectedString = "Student: Jane Doe, ID: 456, Grade: 88.7";

            // Act
            string result = student.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expectedString));
        }

        [Test]
        public void DisplayAllStudents_ShouldPrintAllStudents()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student("John", 1, 95.5),
                new Student("Jane", 2, 88.0),
                new Student("Alice", 3, 76.3)
            };
            var program = new Program();
            var expectedOutput = "Student: John, ID: 1, Grade: 95.5\n" +
                                 "Student: Jane, ID: 2, Grade: 88.0\n" +
                                 "Student: Alice, ID: 3, Grade: 76.3\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.DisplayAllStudents(students);

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n").ToLower(CultureInfo.InvariantCulture);
                Assert.That(result, Is.EqualTo(expectedOutput.ToLower(CultureInfo.InvariantCulture)));
            }
        }
    }
}

