namespace Robot_Challenge
{
    public abstract class Command
    {
        public string CommandName { get; protected set; }
        public int ArgumentCount { get; protected set; }

        //Abstract Execute function to be implemented in concrete command classes
        public abstract void Execute(string[] args, CommandContext ctx);

        //Serves effectively as a constructor
        public void Initialize(string name, int argCount)
        {
            CommandName = name;
            ArgumentCount = argCount;
        }


        //Ensure argument length matches the registered argument
        protected bool CheckArgs(string[] args)
        {
            int receivedArguments = 0;

            foreach (string arg in args)
            {
                if (!string.IsNullOrWhiteSpace(arg)) receivedArguments++;
            }


            if(receivedArguments != ArgumentCount)
            {
                Console.WriteLine($"Invalid argument count. Received {receivedArguments}, Expected {ArgumentCount}");
                return false;
            }

            return true;
        }
    }
}
