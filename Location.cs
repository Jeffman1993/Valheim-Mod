
using UnityEngine;

namespace KeepInv
{
    class Location
    {
        public Vector3 position { get; set; }
        public Quaternion rotation { get; set; }


        public Location()
        {
            this.position = Vector3.zero;
            this.rotation = Quaternion.identity;
        }

        public Location(Player player)
        {
            this.position = player.transform.position;
            this.rotation = player.transform.rotation;
        }

        public Location(Vector3 position)
        {
            this.position = position;
            this.rotation = Quaternion.identity;
        }

        public Location(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }
}
