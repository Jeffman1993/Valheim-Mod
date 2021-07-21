using KeepInv.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepInv.Commands
{
    class DelHome_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            if (args.Length == 0)
                return;

            bool homeWasDeleted = SetHome_Cmd.deleteHome(args[0]);

            string chatMsg = homeWasDeleted ? $"Successfully deleted home: {args[0]}" : $"Could not find a home named: {args[0]}";

            ChatHelper.addString(chatMsg);
        }
    }
}
