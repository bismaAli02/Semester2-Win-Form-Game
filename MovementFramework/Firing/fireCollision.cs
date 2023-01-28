using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MovementFramework.Core;
using MovementFramework.Collisions;

namespace MovementFramework.Firing
{
    public class fireCollision : IFireCollide
    {

        public void PerformAction(IGame game, GameObject go, FireClass fire)
        {
            GameObject player;
            player = go;
            if (go.OType == "player")
            {
                if (fire.FireMovement.GetType() == typeof(MoveFireLeft))
                {
                    game.RaisePlayerFireDieEvent(player, fire);
                }
            }
            else if (go.OType == "enemy")
            {
                if (fire.FireMovement.GetType() == typeof(MoveFireRight))
                {
                    game.RaisePlayerFireDieEvent(player, fire);
                }
            }
        }
    }
}
