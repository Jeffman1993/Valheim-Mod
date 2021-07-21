using KeepInv.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KeepInv.Commands
{
    class GetPos_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            Vector3 playerLocation = Player.m_localPlayer.transform.position;

            ChatHelper.addString($"You are at: {Math.Floor(playerLocation.x)}, {Math.Floor(playerLocation.y)}, {Math.Floor(playerLocation.z)}");

        }
    }
}
