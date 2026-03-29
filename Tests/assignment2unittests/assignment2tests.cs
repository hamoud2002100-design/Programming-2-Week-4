using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using Assignment2;

namespace Assignment2.Tests
{
    [TestFixture]
    public class VehicleTests
    {
        [Test]
        public void BoatStart_ShouldPrintPropellerIsSpinning()
        {
            // Arrange
            var boat = new Boat();
            var expectedOutput = "Propeller is spinning.\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                boat.Start();

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }

        [Test]
        public void CarStart_ShouldPrintEngineIsRevving()
        {
            // Arrange
            var car = new Car();
            var expectedOutput = "Engine is revving.\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                car.Start();

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }

        [Test]
        public void StartAllVehicles_ShouldPrintStartingMessages()
        {
            // Arrange
            var vehicles = new Dictionary<string, IVehicle>
            {
                { "Car", new Car() },
                { "Boat", new Boat() }
            };
            var program = new Program();
            var expectedOutput = "Starting Car: Engine is revving.\n" +
                                 "Starting Boat: Propeller is spinning.\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                program.StartAllVehicles(vehicles);

                // Assert
                var result = sw.ToString().Replace("\r\n", "\n");
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }
    }
}


