using KeepInv.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace KeepInv.Commands
{
    class SetHome_Cmd : CustomCommand
    {
        public static Dictionary<string, Location> homes { get; private set; }


        public SetHome_Cmd()
        {
            homes = new Dictionary<string, Location>()
            {
                {"necro", new Location(new Vector3(-1171, 51.5f, 618))},
                {"lag", new Location(new Vector3(146, 34, -1021))}
            };
        }

        public static bool defaultHomeExists()
        {
            return homes.ContainsKey("home");
        }

        public static bool deleteHome(string home)
        {
            home = home.ToLower();

            if (homes.ContainsKey(home))
            {
                homes.Remove(home);
                return true;
            }

            return false;
        }

        public static Location getHome(string homeName = "home")
        {
            homeName = homeName.ToLower();

            return homes.ContainsKey(homeName) ? homes[homeName] : null;
        }

        public override void handle(string[] args)
        {

            Location playerLocation = new Location(Player.m_localPlayer);

            if (args.Length <= 0)
            {
                if (!homes.ContainsKey("home"))
                {
                    homes.Add("home", playerLocation);
                    ChatHelper.addString("Home set.");
                    return;
                }
                else
                {
                    ChatHelper.addString("Not enough arguements for command.");
                    return;
                }
            }

            string homeName = args[0].ToLower();


            if (!homes.ContainsKey(homeName))
            {

                homes.Add(homeName, playerLocation);

                ChatHelper.addString("Home set.");

            }
            else
                ChatHelper.addString("A home already exists with this name.");

        }
    }
}
