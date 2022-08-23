namespace Robot_Challenge
{
    public class CommandContext
    {
        public ToyRobot ActiveRobot { get; set; }
        public Tabletop Tabletop { get; private set; }
        public List<ToyRobot> ToyRobots { get; private set; }

        //Context container for running commands
        public CommandContext(ToyRobot activeRobot, Tabletop tabletop, List<ToyRobot> toyRobots)
        {
            ActiveRobot = activeRobot;
            Tabletop = tabletop;
            ToyRobots = toyRobots;
        }
    }
}
