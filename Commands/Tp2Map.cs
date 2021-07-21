using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KeepInv.Commands
{
    class Tp2Map : CustomCommand
    {
        public override void handle(string[] args)
        {

            Player player = Player.m_localPlayer;

            Vector3 location = Vector3.zero;


            //if (ZoneSystem.instance.GetLocationIcon(args[0]))

        }
    }
}
