namespace Robot_Challenge
{
    /// <summary>
    /// Represents a point in 2D space. 
    /// </summary>
    public struct Vector2
    {
        //Zero Vector
        public static readonly Vector2 Zero  = new Vector2(0, 0);

        //Cardinal Directions
        public static readonly Vector2 North = new Vector2(0, 1);
        public static readonly Vector2 East  = new Vector2(1, 0);
        public static readonly Vector2 South = new Vector2(0, -1);
        public static readonly Vector2 West  = new Vector2(-1, 0);

        //Position
        public int x;
        public int y;

        public Vector2(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
        }

        //Can't use a switch statement here as Cardinal Directions are not constants
        public static Vector2 RotateRight(Vector2 input)
        {
            if (input == North)
                return East;

            if (input == East)
                return South;

            if (input == South)
                return West;

            if(input == West)
                return North;

            //Should never run into this, do nothing if it does
            return input;
        }


        //Prettify output for cardinal directions
        public string ToCardinalString()
        {
            if (this == North)
                return "NORTH";

            if (this == East)
                return "EAST";

            if (this == South)
                return "SOUTH";

            if (this == West)
                return "WEST";

            return "Invalid Cardinal Direction";
        }

        //Parse a string input to a Vector2
        public static Vector2 Parse(string input)
        {
            input = input.ToUpper();

            switch (input)
            {
                case "NORTH":
                    return North;
                case "EAST":
                    return East;
                case "SOUTH":
                    return South;
                case "WEST":
                    return West;
            }

            return Zero;
        }

        //To reduce code duplication just re-use TurnRight with an inverted input
        public static Vector2 RotateLeft(Vector2 input)
        {
            return RotateRight(input * -1);
        }

        //Prettify output
        public override string ToString()
        {
            return $"{x},{y}";
        }

        //Comparison operators for cleaner code
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, int b) => new Vector2(a.x * b, a.y * b);
        public static bool operator ==(Vector2 a, Vector2 b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
    }
}
