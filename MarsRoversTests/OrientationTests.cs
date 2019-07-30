using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Constants;
using NUnit.Framework;
using MarsRover;

namespace MarsRoversTests
{
    [TestFixture]
    public class OrientationTests
    {

        [Test]
        public void Constructor_Default_North()
        {
            var orientation = new Orientation(CompassPoints.AllPoints);

            AssertOrientationIsNorth(orientation);
        }

        [Test]
        public void Constructor_SetSouth_South()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.South);

            AssertOrientationIsSouth(orientation);
        }

        [Test]
        public void SpinRight_InitiallyNorth_East()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.North);

            orientation.SpinRight();

            AssertOrientationIsEast(orientation);
        }

        [Test]
        public void SpinRight_InitiallyEast_South()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.East);

            orientation.SpinRight();

            AssertOrientationIsSouth(orientation);
        }

        [Test]
        public void SpinRight_InitiallyEastThenSpinRightTwice_West()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.East);

            orientation.SpinRight();
            orientation.SpinRight();

            AssertOrientationIsWest(orientation);
        }

        [Test]
        public void SpinRight_InitiallyWest_North()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.West);

            orientation.SpinRight();

            AssertOrientationIsNorth(orientation);
        }

        [Test]
        public void SpinLeft_InitiallyNorth_West()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.North);

            orientation.SpinLeft();

            AssertOrientationIsWest(orientation);
        }

        [Test]
        public void SpinLeft_InitiallyWest_South()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.West);

            orientation.SpinLeft();

            AssertOrientationIsSouth(orientation);
        }

        [Test]
        public void SpinLeft_InitiallyWestTheSpinLeftTwice_East()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.West);

            orientation.SpinLeft();
            orientation.SpinLeft();

            AssertOrientationIsEast(orientation);
        }

        [Test]
        public void MoveForward_NotChangeDirectionInitiallyWest_West()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.West);

            orientation.MoveForward();

            AssertOrientationIsWest(orientation);
        }

        [Test]
        public void XYIncrements_NorthOrientation_YPlus1()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.North);

            Assert.That(orientation.XIncrement, Is.EqualTo(0));
            Assert.That(orientation.YIncrement, Is.EqualTo(1));
        }

        [Test]
        public void XYIncrements_EastOrientation_XPlus1()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.East);

            Assert.That(orientation.XIncrement, Is.EqualTo(1));
            Assert.That(orientation.YIncrement, Is.EqualTo(0));
        }

        [Test]
        public void XYIncrements_SouthOrientation_YMinus1()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.South);

            Assert.That(orientation.XIncrement, Is.EqualTo(0));
            Assert.That(orientation.YIncrement, Is.EqualTo(-1));
        }

        [Test]
        public void XYIncrements_WestOrientation_XMinus1()
        {
            var orientation = new Orientation(CompassPoints.AllPoints, CompassPoints.West);


            Assert.That(orientation.XIncrement, Is.EqualTo(-1));
            Assert.That(orientation.YIncrement, Is.EqualTo(0));
        }
        private void AssertOrientationIsNorth(Orientation orientation)
        {
            Assert.That(orientation.CompassPoint, Is.EqualTo(CompassPoints.North));
        }

        private void AssertOrientationIsEast(Orientation orientation)
        {
            Assert.That(orientation.CompassPoint, Is.EqualTo(CompassPoints.East));
        }

        private void AssertOrientationIsSouth(Orientation orientation)
        {
            Assert.That(orientation.CompassPoint, Is.EqualTo(CompassPoints.South));
        }

        private void AssertOrientationIsWest(Orientation orientation)
        {
            Assert.That(orientation.CompassPoint, Is.EqualTo(CompassPoints.West));
        }
        
    }
}
