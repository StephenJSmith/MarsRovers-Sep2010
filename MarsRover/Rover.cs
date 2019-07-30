namespace MarsRover
{
    public class Rover
    {
        private int maxX;
        private int maxY;
        private IOrientation orientation;

        public Rover(IOrientation orientation, int maxX, int maxY) 
            : this(orientation, maxX, maxY, 0, 0)
        {
        }

        public Rover(IOrientation orientation, int maxX, int maxY, int initialX, int initialY)
        {
            this.orientation = orientation;
            
            this.maxX = maxX;
            this.maxY = maxY;

            this.X = initialX;
            this.Y = initialY;
        }


        public int X { get; private set; }

        public int Y { get; private set; }

        public string OrientationCompassPoint
        {
            get { return orientation.CompassPoint;}
        }

        public void SpinLeft()
        {
            this.orientation.SpinLeft();
        }

        public void SpinRight()
        {
            this.orientation.SpinRight();
        }

        public void MoveForward()
        {
            // Do NOT move beyond boundaries
            if (!IsMoveWithinBoundaries()) return;

            this.X += orientation.XIncrement;
            this.Y += orientation.YIncrement;
        }

        private bool IsMoveWithinBoundaries()
        {
            if (this.X + orientation.XIncrement > this.maxX) return false;
            if (this.X + orientation.XIncrement < 0) return false;

            if (this.Y + orientation.YIncrement > this.maxY) return false;
            if (this.Y + orientation.YIncrement < 0) return false;

            return true;
        }
    }
}
