using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Constants;
using MarsRover;
using NUnit.Framework;

namespace MarsRoversTests
{
    [TestFixture]
    public class RoverTests
    {
        private const int LargeMaxX = 20;
        private const int LargeMaxY = 30;

        [Test]
        public void Constructor_Default_X0Y0North()
        {
            var orientation = new Orientation(CompassPoints.AllPoints);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY);

            AssertValidPositionAndOrientation(rover, 0, 0, CompassPoints.North);
        }

        [Test]
        public void Constructor_InitialPositionAndOrientationSet()
        {
            int xCoord = 1;
            int yCoord = 2;
            string compassPoint = CompassPoints.North;
            var orientation = new Orientation(CompassPoints.AllPoints, compassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, xCoord, yCoord);

            AssertValidPositionAndOrientation(rover, xCoord, yCoord, compassPoint);
        }

        [Test]
        public void SpinLeft_InitiallyNorth_SameCoordinatesFacingWest()
        {
            int xCoord = 3;
            int yCoord = 2;
            string initiallCompassPoint = CompassPoints.North;
            string expectedCompassPoint = CompassPoints.West;
            var orientation = new Orientation(CompassPoints.AllPoints, initiallCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, xCoord, yCoord);

            rover.SpinLeft();

            AssertValidPositionAndOrientation(rover, xCoord, yCoord, expectedCompassPoint);
        }

        [Test]
        public void SpinRight_InitiallySouth_SameCoordinatesFacingWest()
        {
            int xCoord = 3;
            int yCoord = 2;
            string initiallCompassPoint = CompassPoints.South;
            string expectedCompassPoint = CompassPoints.West;
            var orientation = new Orientation(CompassPoints.AllPoints, initiallCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, xCoord, yCoord);

            rover.SpinRight();

            AssertValidPositionAndOrientation(rover, xCoord, yCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_FacingNorth_YCoordIncremented()
        {
            int initialXCoord = 5;
            int initialYCoord = 3;
            string initialCompassPoint = CompassPoints.North;
            int expectedXCoord = initialXCoord;
            int expectedYCoord = initialYCoord+1;
            string expectedCompassPoint = initialCompassPoint;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_InitiallyNorthThenSpinRightThenMoveForward_XCoordIncrementedFacingEast()
        {
            int initialXCoord = 5;
            int initialYCoord = 3;
            string initialCompassPoint = CompassPoints.North;
            int expectedXCoord = initialXCoord + 1;
            int expectedYCoord = initialYCoord;
            string expectedCompassPoint = CompassPoints.East;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.SpinRight();

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_FacingSouth_YCoordDecremented()
        {
            int initialXCoord = 5;
            int initialYCoord = 3;
            string initialCompassPoint = CompassPoints.South;
            int expectedXCoord = initialXCoord;
            int expectedYCoord = initialYCoord - 1;
            string expectedCompassPoint = initialCompassPoint;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_FacingWest_XCoordDecremented()
        {
            int initialXCoord = 5;
            int initialYCoord = 3;
            string initialCompassPoint = CompassPoints.West;
            int expectedXCoord = initialXCoord - 1;
            int expectedYCoord = initialYCoord;
            string expectedCompassPoint = initialCompassPoint;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_NotToExceedWestBoundary_SameCoordinates()
        {
            int initialXCoord = 0;
            int initialYCoord = 3;
            string initialCompassPoint = CompassPoints.West;
            int expectedXCoord = initialXCoord;
            int expectedYCoord = initialYCoord;
            string expectedCompassPoint = initialCompassPoint;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_NotToExceedSouthBoundary_SameCoordinates()
        {
            int initialXCoord = 3;
            int initialYCoord = 0;
            string initialCompassPoint = CompassPoints.South;
            int expectedXCoord = initialXCoord;
            int expectedYCoord = initialYCoord;
            string expectedCompassPoint = initialCompassPoint;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_NotToExceedNorthBoundary_SameCoordinates()
        {
            int initialXCoord = 4;
            int initialYCoord = LargeMaxY;
            string initialCompassPoint = CompassPoints.North;
            int expectedXCoord = initialXCoord;
            int expectedYCoord = initialYCoord;
            string expectedCompassPoint = initialCompassPoint;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        [Test]
        public void MoveForward_NotToExceedEastBoundary_SameCoordinates()
        {
            int initialXCoord = LargeMaxX;
            int initialYCoord = 3;
            string initialCompassPoint = CompassPoints.East;
            int expectedXCoord = initialXCoord;
            int expectedYCoord = initialYCoord;
            string expectedCompassPoint = initialCompassPoint;
            var orientation = new Orientation(CompassPoints.AllPoints, initialCompassPoint);
            var rover = new Rover(orientation, LargeMaxX, LargeMaxY, initialXCoord, initialYCoord);

            rover.MoveForward();

            AssertValidPositionAndOrientation(rover, expectedXCoord, expectedYCoord, expectedCompassPoint);
        }

        private void AssertValidPositionAndOrientation(Rover rover, int xCoord, int yCoord, string compassPoint)
        {
            Assert.That(rover.X, Is.EqualTo(xCoord));
            Assert.That(rover.Y, Is.EqualTo(yCoord));
            Assert.That(rover.OrientationCompassPoint, Is.EqualTo(compassPoint));
        }
    }
}
