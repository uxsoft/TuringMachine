namespace TuringMachine
{
    public class Transition
    {
        public Transition(int nextState, char write, Direction movementDirection) : this(nextState, movementDirection)
        {
            Write = write;
        }

        public Transition(int nextState, Direction movementDirection)
        {
            NextState = nextState;
            MovementDirection = movementDirection;
        }
        public int NextState { get; set; }
        public char? Write { get; set; }
        public Direction MovementDirection { get; set; }
    }
}