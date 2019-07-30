using System.Collections.Generic;

namespace MarsRover
{
    public interface IOrientation
    {
        string CompassPoint { get; }
        int XIncrement { get; }
        int YIncrement { get; }
        void SpinRight();
        void SpinLeft();
        void MoveForward();
    }

    public class Orientation : IOrientation
    {
        private readonly string AllCompassPoints;
        private int orientationIndex = 0;
        private IList<int> XIncrementsForNESW = new List<int> {0, 1, 0, -1};
        private IList<int> YIncrementsForNESW = new List<int> {1, 0, -1, 0};

        public Orientation(string allCompassPoints) : this(allCompassPoints, allCompassPoints.Substring(0, 1))
        {
        }

        public Orientation(string allCompassPoints, string initialCompassPoint)
        {
            this.AllCompassPoints = allCompassPoints;
            orientationIndex = allCompassPoints.IndexOf(initialCompassPoint);
        }

        private int MaxIndex
        {
            get { return AllCompassPoints.Length - 1; }
        }

        private int MinIndex
        {
            get { return 0; }
        }

        public string CompassPoint
        {
            get { return AllCompassPoints.Substring(orientationIndex, 1); }
        }

        public int XIncrement
        {
            get { return XIncrementsForNESW[orientationIndex];}
        }

        public int YIncrement
        {
            get { return YIncrementsForNESW[orientationIndex]; }
        }

        public void SpinRight()
        {
            orientationIndex += 1;

            if (orientationIndex > MaxIndex)
            {
                orientationIndex = MinIndex;
            }
        }

        public void SpinLeft()
        {
            orientationIndex -= 1;

            if (orientationIndex < MinIndex)
            {
                orientationIndex = MaxIndex;
            }
        }

        public void MoveForward()
        {
            // No impact on orientation
        }
    }
}
