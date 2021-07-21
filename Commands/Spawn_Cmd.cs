using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KeepInv.Commands
{
    class Spawn_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            Vector3 spawnLocation = Vector3.up;

            if (!ZoneSystem.instance.GetLocationIcon("StartTemple", out spawnLocation))
                return;

            spawnLocation.y += 0.5f;

            Player player = Player.m_localPlayer;

            Back_Cmd.updateLastLocation();
            player.TeleportTo(spawnLocation, player.transform.rotation, true);
        }
    }
}
