using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover;
using NUnit.Framework;

namespace MarsRoversTests
{
    [TestFixture]
    public class MarsRoversTests
    {
        [Test]
        public void Input_FirstInput_SetsBoundaryDimensions()
        {
            string input = "7 10";
            int expectedMaxX = 7;
            int expectedMaxY = 10;
            var rovers = new MarsRovers();

            rovers.Input(input);

            Assert.That(rovers.MaxX, Is.EqualTo(expectedMaxX));
            Assert.That(rovers.MaxY, Is.EqualTo(expectedMaxY));
        }

        [Test]
        public void Input_SecondInput_InitialisesARover()
        {
            string input1 = "5 5";
            string input2 = "1 2 N";
            var rovers = new MarsRovers();

            rovers.Input(input1);
            rovers.Input(input2);

            Assert.That(rovers.Count, Is.EqualTo(1));
        }

        [Test]
        public void Output_ThirdInputSpecifiesRoverMovements_OutputIncludesRoverPositionAndOrientation()
        {
            // Arrange
            string input1 = "5 5";
            string input2 = "1 2 N";
            string input3 = "LMLMLMLMM";
            string expectedOutput = "1 3 N";
            var rovers = new MarsRovers();

            // Act
            rovers.Input(input1);
            rovers.Input(input2);
            rovers.Input(input3);

            // Assert
            Assert.That(rovers.Output.Count, Is.EqualTo(1));
            Assert.That(rovers.Output[0], Is.EqualTo(expectedOutput));
        }

        [Test]
        public void Input_FourthInput_InitialisesSecondRover()
        {
            string input1 = "5 5";
            string input2 = "1 2 N";
            string input3 = "LMLMLMLMM";
            string input4 = "5 1 E";
            var rovers = new MarsRovers();

            rovers.Input(input1);
            rovers.Input(input2);
            rovers.Input(input3);
            rovers.Input(input4);

            Assert.That(rovers.Count, Is.EqualTo(2));
        }

        [Test]
        public void Output_FifthInputInstructsSecondRover_OuptutStringForEachRoverStatus()
        {
            // Arrange
            string input1 = "5 5";
            string input2 = "1 2 N";
            string input3 = "LMLMLMLMM";
            string input4 = "3 3 E";
            string input5 = "MMRMMRMRRM";
            string expectedOutput1 = "1 3 N";
            string expectedOutput2 = "5 1 E";
            var rovers = new MarsRovers();

            // Act
            rovers.Input(input1);
            rovers.Input(input2);
            rovers.Input(input3);
            rovers.Input(input4);
            rovers.Input(input5);

            // Assert
            Assert.That(rovers.Output.Count, Is.EqualTo(2));
            Assert.That(rovers.Output[0], Is.EqualTo(expectedOutput1));
            Assert.That(rovers.Output[1], Is.EqualTo(expectedOutput2));
        }
    }
}
