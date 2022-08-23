namespace Robot_Challenge.Commands
{
    public class MoveCommand : Command
    {
        public override void Execute(string[] args, CommandContext ctx)
        {
            if (!CheckArgs(args)) return;

            ctx.ActiveRobot.Move();
        }
    }
}
