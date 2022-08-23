namespace Robot_Challenge
{
    public class Tabletop
    {
        //Assuming this will always be a square
        public int Size { get; private set; }

        //Default size 5 but can be any positive number greater than 0.
        public Tabletop(int size = 5)
        {
            if(size <= 0) throw new ArgumentException("Tabletop size must be greater than 0");

            Size = size;
        }

        //Ensure that the position is within tabletop bounds
        public bool IsValidPosition(Vector2 position)
        {
            //Return false if x or y are greater than the tabletop size (+1 for zero index) or less than zero
            return (
                position.x >= Size ||
                position.y >= Size ||
                position.x < 0 ||
                position.y < 0
                ) ? false : true;
        }

        //Places a new robot on the board at x, y with a provided direction. Optionally activate it straight away
        public void Place(ToyRobot robot, Vector2 position, Vector2 direction)
        {
            if (!IsValidPosition(position))
            {
                Console.WriteLine($"Position {position} is out of bounds. Ensure X and Y are < {Size}");
                return;
            }

            //Set position, direction and table
            robot.SetPosition(position);
            robot.SetDirection(direction);
            robot.SetTabletop(this);
        }

    }
}
