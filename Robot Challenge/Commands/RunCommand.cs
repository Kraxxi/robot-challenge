using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Challenge.Commands
{
    public class RunCommand : Command
    {
        public override void Execute(string[] args, CommandContext ctx)
        {
            if (!CheckArgs(args)) return;

            ctx.ActiveRobot.SetMoveSpeed(2);
        }
    }
}
