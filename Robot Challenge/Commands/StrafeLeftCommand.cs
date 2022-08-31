namespace Robot_Challenge.Commands
{
    public class StrafeLeftCommand : Command
    {
        public override void Execute(string[] args, CommandContext ctx)
        {
            if (!CheckArgs(args)) return;

            ctx.ActiveRobot.StrafeLeft();
        }
    }
}
