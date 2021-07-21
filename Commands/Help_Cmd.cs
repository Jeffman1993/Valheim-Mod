using KeepInv.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepInv.Commands
{
    class Help_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            StringBuilder sb = new StringBuilder("Commands: ");

            string[] commands = CmdHandler.customCommands.Keys.ToArray();

            for (int i = 0; i < commands.Length; i++)
            {
                sb.Append(commands[i]);

                if (i != commands.Length - 1)
                    sb.Append(", ");
            }

            ChatHelper.addString(sb.ToString());

            }
    }
}
