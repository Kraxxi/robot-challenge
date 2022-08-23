namespace Robot_Challenge.Commands
{
    public class PlaceCommand : Command
    {
        public override void Execute(string[] args, CommandContext ctx)
        {
            if(!CheckArgs(args)) return;

            //Validate input by parsing as ints
            int x = 0;
            int y = 0;

            try
            {
                x = int.Parse(args[0]);
                y = int.Parse(args[1]);
            }catch(Exception e)
            {
                Console.WriteLine("Could not parse integer");
                return;
            }

            //Confirm it's a valid position within bounds
            Vector2 position = new Vector2(x, y);
            if (!ctx.Tabletop.IsValidPosition(position))
            {
                Console.WriteLine($"Invalid Position. Please place within {0}-{ctx.Tabletop.Size - 1}, {0}-{ctx.Tabletop.Size - 1}");
                return;
            }

            //Parse a direction from string
            Vector2 direction = Vector2.Parse(args[2]);
            if (direction == Vector2.Zero)
            {
                Console.WriteLine("Could not parse Direction, please use NORTH EAST SOUTH or WEST");
                return;
            }

            //Create a new robot and add it to the tracked list
            ToyRobot robot = new ToyRobot();
            ctx.ToyRobots.Add(robot);

            //If this is the first robot then set it as active
            if (ctx.ToyRobots.Count == 1) ctx.ActiveRobot = robot;

            //Place the robot on the tabletop
            ctx.Tabletop.Place(robot, position, direction);
        }
    }
}
