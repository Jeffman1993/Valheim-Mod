using KeepInv.Commands;
using System.Collections.Generic;
using System.Linq;

namespace KeepInv
{
    public class CmdHandler
    {
        public static string[] commandLabels { get; private set; }

        public static Dictionary<string, CustomCommand> customCommands = new Dictionary<string, CustomCommand>() 
        {
            {"tp", new Tp_Cmd() },
            {"back", new Back_Cmd() },
            {"list", new List_Cmd() },
            {"tp2p", new Tp2p_Cmd() },
            {"sethome", new SetHome_Cmd() },
            {"delhome", new DelHome_Cmd() },
            {"home", new Home_Cmd() },
            {"homes", new ListHomes_Cmd() },
            {"getpos", new GetPos_Cmd() },
            {"spawn", new Spawn_Cmd() },
            {"help", new Help_Cmd() }
        };

        public static void init()
        {
            commandLabels = customCommands.Keys.ToArray();
        }

        public static bool handle(string input)
        {

            //Check if chat contains a command else give control back to the original method.
            if (string.IsNullOrEmpty(input) || input[0] != '/')
                return true;


            string[] cmdString = input.TrimStart('/').Split(' ');

            string cmdLabel = cmdString.Length > 0 ? cmdString[0].ToLower() : null;
            string[] cmdArgs = cmdString.Length > 1 ? cmdString.Skip(1).ToArray() : new string[0];


            //If we don't find a custom command, give back control.
            if (cmdLabel == null || !customCommands.ContainsKey(cmdLabel))
                return true;


            //Else process it.
            customCommands[cmdLabel].handle(cmdArgs);


            //We found a custom command so don't process chat normally.
            return false;
        }

    }
}
