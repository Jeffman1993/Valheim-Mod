using KeepInv.Utilities;
using System;
using System.Linq;
using System.Text;

namespace KeepInv.Commands
{
    class ListHomes_Cmd : CustomCommand
    {
        public override void handle(string[] args)
        {

            string[] homes = SetHome_Cmd.homes.Keys.ToArray();

            if(homes.Length == 0)
            {
                ChatHelper.addString("You are homeless. Get off my porch!");
                return;
            }


            StringBuilder sb = new StringBuilder("Homes: ");

            for (int i = 0; i < homes.Length; i++)
            {

                sb.Append(homes[i]);

                if (i != homes.Length - 1)
                    sb.Append(", ");
            }

            ChatHelper.addString(sb.ToString());
        }
    }
}
