using KeepInv.Utilities;
using System;
using UnityEngine;

namespace KeepInv.Commands
{
    class Tp2p_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            if (args.Length != 3)
            {
                ChatHelper.addString("Not enough arguements for command.");
                return;
            }

            Vector3 location = Vector3.zero;

            try
            {
                location.x = float.Parse(args[0]);
                location.y = float.Parse(args[1]);
                location.z = float.Parse(args[2]);

                location.y += 0.5f;
            }
            catch (FormatException)
            {
                ChatHelper.addString("Cannot teleport to an invalid point.");
                return;
            }

            Player player = Player.m_localPlayer;

            Back_Cmd.updateLastLocation();
            player.TeleportTo(location, player.transform.rotation, true);

        }
    }
}
