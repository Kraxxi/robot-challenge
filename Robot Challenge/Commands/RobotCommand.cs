namespace Robot_Challenge.Commands
{
    public class RobotCommand : Command
    {
        public override void Execute(string[] args, CommandContext ctx)
        {
            if(!CheckArgs(args)) return;

            int index;
            int robotCount;

            if(ctx.ToyRobots.Count == 0)
            {
                Console.WriteLine("No robots have been placed yet.");
                return;
            }


            try
            {
                index = int.Parse(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not parse integer");
                return;
            }

            //Get current robot count
            robotCount = ctx.ToyRobots.Count;

            //Ensure the supplied value is within range of existing robot count. Incrementing by 1 for user friendly 1-based indexing
            if(index >= robotCount+1 || index < 1)
            {
                Console.WriteLine($"Invalid index, there are {robotCount} robots. Select from 1 - {robotCount}");
                return;
            }

            //Update active robot
            ctx.ActiveRobot = ctx.ToyRobots[index-1];
        }
    }
}
