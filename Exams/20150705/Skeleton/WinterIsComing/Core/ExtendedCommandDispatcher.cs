using WinterIsComing.Core.Commands;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Core
{
    public class ExtendedCommandDispatcher : CommandDispatcher
    {
        public override void DispatchCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new GameException(
                    "Command is not supported by engine");
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public override void SeedCommands()
        {

            base.SeedCommands();
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}