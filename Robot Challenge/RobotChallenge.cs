using Robot_Challenge.Commands;

namespace Robot_Challenge
{
    public class RobotChallenge
    {
        private List<ToyRobot> _robots = new List<ToyRobot>();
        private Dictionary<string, Command> _commands = new Dictionary<string, Command>();
        private Tabletop _tabletop = new Tabletop();
        private ToyRobot _activeRobot;

        //Register the command classes
        public void Initialize()
        {

            RegisterCommand("MOVE", 0, new MoveCommand());
            RegisterCommand("PLACE", 3, new PlaceCommand());
            RegisterCommand("REPORT", 0, new ReportCommand());
            RegisterCommand("ROBOT", 1, new RobotCommand());
            RegisterCommand("LEFT", 0, new RotateLeft());
            RegisterCommand("RIGHT", 0, new RotateRight());
            RegisterCommand("WALK", 0, new WalkCommand());
            RegisterCommand("RUN", 0, new RunCommand());
            RegisterCommand("CHARGE", 0, new ChargeCommand());
            RegisterCommand("STRAFELEFT", 0, new StrafeLeftCommand());
            RegisterCommand("STRAFERIGHT", 0, new StrafeRightCommand());

            Console.WriteLine("Program Ready!");
            PrintCommands();

            ReadUserInput();
        }

        //Prints all available commands
        private void PrintCommands()
        {
            Console.WriteLine("Available Commands:");

            foreach (var keyValuePair in _commands)
            {
                Console.WriteLine(keyValuePair.Key);
            }
        }

        //Registers a command with a name, type and parameter count
        private void RegisterCommand<T>(string name, int argCount, T cmd) where T : Command
        {
            cmd.Initialize(name, argCount);
            _commands.Add(name,cmd);
        }

        //Main loop of the program, listening and processing user inputs
        private void ReadUserInput()
        {
            bool isRunning = true;

            while (isRunning)
            {
                //Read user input
                string input = Console.ReadLine();

                if (input == null) continue;

                ProcessCommand(input.ToUpper());
            }
        }

        //Determine which command to run with which parameters
        private void ProcessCommand(string input)
        {
            //Grab the command
            string command = input.Split(' ')[0];

            //Trim the command (and space) away
            string argString = input.Substring(command.Length).Trim();

            //Split args into strings
            string[] args = argString.Split(',');

            //Check if the command exists
            if (!_commands.ContainsKey(command))
            {
                Console.WriteLine($"Command {command} not found.");
                PrintCommands();
                return;   
            }

            //Fetch command
            Command cmdToExecute = _commands[command];

            //If no robot has been placed yet then discard the command unless it's PLACE
            if (_activeRobot == null && command != "PLACE") return;

            //Create command context
            CommandContext context = new CommandContext(_activeRobot, _tabletop, _robots);

            //Execute!
            cmdToExecute.Execute(args, context);

            _activeRobot = context.ActiveRobot;
        }
    }
}
