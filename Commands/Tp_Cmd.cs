using KeepInv.Utilities;
using System.Linq;
using System.Text;
using UnityEngine;
using static ZNet;

namespace KeepInv.Commands
{
    class Tp_Cmd : CustomCommand
    {
        private Vector3 lastLocation = Vector3.zero;

        public override void handle(string[] args)
        {

            if (args.Length == 0)
                return;

            string targetPlayerName = string.Empty;


            if (args.Length == 1)
                targetPlayerName = args[0].ToLower();

            else
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < args.Length; i++)
                {

                    sb.Append(args[i].ToLower());

                    if (i != args.Length - 1)
                        sb.Append(" ");
                }

                targetPlayerName = sb.ToString();
            }


            PlayerInfo targetPlayer = instance.GetPlayerList().FirstOrDefault(i => i.m_name.ToLower() == targetPlayerName);


            if (!string.IsNullOrEmpty(targetPlayer.m_name))
            {

                Player localPlayer = Player.m_localPlayer;

                Back_Cmd.updateLastLocation();
                localPlayer.TeleportTo(targetPlayer.m_position, localPlayer.transform.rotation, true);
            }

            else
            {
                Debug.LogWarning($"No player found named: {targetPlayerName}");
                ChatHelper.addString($"No player found named: {targetPlayerName}");
            }

        }
    }
}
