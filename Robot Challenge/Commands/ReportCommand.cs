namespace Robot_Challenge.Commands
{
    public class ReportCommand : Command
    {
        public override void Execute(string[] args, CommandContext ctx)
        {
            if(!CheckArgs(args)) return;

            int numRobots = ctx.ToyRobots.Count;
            Console.WriteLine($"There are {numRobots} robots.");

            //Nothing else to report if there is no active robot
            if (ctx.ActiveRobot == null) return;

            //Cache activeRobot
            ToyRobot activeRobot = ctx.ActiveRobot;

            //User-friendly reporting of 1-based index
            Console.WriteLine($"Active Robot: Robot {ctx.ToyRobots.IndexOf(activeRobot) + 1}");
            Console.WriteLine($"{activeRobot.Position},{activeRobot.Direction.ToCardinalString()}");
        }
    }
}
