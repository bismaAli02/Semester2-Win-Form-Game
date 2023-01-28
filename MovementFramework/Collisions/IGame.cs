using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovementFramework.Core;
using MovementFramework.Firing;

namespace MovementFramework.Collisions
{
    public interface IGame
    {
        void RaisePlayerDieEvent(GameObject pb);
        void RaisePlayerFireDieEvent(GameObject pb, FireClass fire);
    }
}
