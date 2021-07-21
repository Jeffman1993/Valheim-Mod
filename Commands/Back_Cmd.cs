
using KeepInv.Utilities;

namespace KeepInv.Commands
{
    class Back_Cmd : CustomCommand
    {
        public static Location lastLocation { get; private set; }

        public Back_Cmd()
        {
            lastLocation = null;
        }

        public static void updateLastLocation()
        {
            lastLocation = new Location(Player.m_localPlayer);
        }

        public static void updateLastLocation(Location location)
        {
            lastLocation = location;
        }

        public override void handle(string[] args)
        {

            if(lastLocation == null)
            {
                ChatHelper.addString("No /back location saved.");
                return;
            }

            Player player = Player.m_localPlayer;

            Location teleportLocation = lastLocation;
            lastLocation = new Location(player);

            player.TeleportTo(teleportLocation.position, teleportLocation.rotation, true);

        }
    }
}
