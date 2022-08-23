namespace Robot_Challenge.Commands
{
    public class RotateLeft : Command
    {
        public override void Execute(string[] args, CommandContext ctx)
        {
            if(!CheckArgs(args)) return;

            //Get current Direction
            Vector2 currentDirection = ctx.ActiveRobot.Direction;

            //Calculate new direction
            Vector2 newDirection = Vector2.RotateLeft(currentDirection);
            
            //Set new Direction
            ctx.ActiveRobot.SetDirection(newDirection);
        }
    }
}
