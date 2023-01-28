using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovementFramework.Core;

namespace MovementFramework.Collisions
{
    public class PlayerCollision : ICollisionAction
    {
        public void PerformAction(IGame game, GameObject source1, GameObject source2)
        {
            GameObject player;
            if (source1.OType == "player")
            {
                player = source1;
            }
            else
            {
                player = source2;
            }
            game.RaisePlayerDieEvent(player);
        }
    }
}
