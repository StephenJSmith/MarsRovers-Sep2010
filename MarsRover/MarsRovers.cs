using System.Collections.Generic;
using System.Text;
using Constants;

namespace MarsRover
{
    public class MarsRovers
    {
        // These constants could be passed as constructor arguments
        private char inputDelimiter = ' ';            
        private char spinLeftCommand = 'L';
        private char spinRightCommand = 'R';
        private char moveForwardCommand = 'M';

        private IList<string > inputs = new List<string>();

        private IList<Rover> rovers = new List<Rover>();

        public MarsRovers()
        {
            this.Output = new List<string>();
        }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public IList<string> Output { get; private set; }

        public int Count
        {
            get { return rovers.Count; }
        }


        public void Input(string input)
        {
            inputs.Add(input);
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (inputs.Count == 1)
            {
                SetBoundaries();
            }
            else if (inputs.Count % 2 == 0)
            {
                InitialiseAnotherRover();
            }
            else
            {
                ActivateCurrentRover();
                OutputRoversStatus();
            }
        }

        private void SetBoundaries()
        {
            string [] splitInput = inputs[0].Split(inputDelimiter);

            this.MaxX = int.Parse(splitInput[0]);
            this.MaxY = int.Parse(splitInput[1]);
        }

        private void InitialiseAnotherRover()
        {
            string[] splitInput = inputs[inputs.Count - 1].Split(inputDelimiter);

            int initialX = int.Parse(splitInput[0]);
            int initialY = int.Parse(splitInput[1]);
            string initialOrientation = splitInput[2];

            var orientation = new Orientation(CompassPoints.AllPoints, initialOrientation);
            var rover = new Rover(orientation, this.MaxX, this.MaxY, initialX, initialY);

            rovers.Add(rover);
        }

        private void ActivateCurrentRover()
        {
            string instructions = inputs[inputs.Count - 1];

            foreach (char instruction in instructions)
            {
                InstructRover(instruction);
            }
        }

        private void InstructRover(char instruction)
        {
            Rover rover = CurrentRover();

            if (instruction == spinLeftCommand)
            {
                rover.SpinLeft();
            }
            else if (instruction == spinRightCommand)
            {
                rover.SpinRight();
            }
            else if (instruction == moveForwardCommand)
            {
                rover.MoveForward();
            }
        }

        private void OutputRoversStatus()
        {
            Rover rover = CurrentRover();
            StringBuilder sb = new StringBuilder();

            sb.Append(rover.X.ToString()).Append(inputDelimiter);
            sb.Append(rover.Y.ToString()).Append(inputDelimiter);
            sb.Append(rover.OrientationCompassPoint);

            Output.Add(sb.ToString());
        }

        private Rover CurrentRover()
        {
            return rovers[rovers.Count - 1];
        }
    }
}
