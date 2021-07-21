
using KeepInv.Utilities;
using System.Collections.Generic;

namespace KeepInv.Commands
{
    class Home_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            Location home = null;

            if (args.Length <= 0 && SetHome_Cmd.defaultHomeExists())
                home = SetHome_Cmd.getHome();

            else if (args.Length > 0)
                home = SetHome_Cmd.getHome(args[0]);

            if (home == null)
            {
                ChatHelper.addString("404, Home not found.");
                return;
            }

            Back_Cmd.updateLastLocation();
            Player.m_localPlayer.TeleportTo(home.position, home.rotation, true);

        }
    }
}
