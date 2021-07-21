using KeepInv.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepInv.Commands
{
    class List_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            List<ZNet.PlayerInfo> playersList = ZNet.instance.GetPlayerList();

            StringBuilder sb = new StringBuilder("Players Online: ");

            for(int i = 0; i < playersList.Count; i++)
            {

                sb.Append(playersList[i].m_name);

                if (i != playersList.Count - 1)
                    sb.Append(", ");
            }

            ChatHelper.addString(sb.ToString());
        }
    }
}
