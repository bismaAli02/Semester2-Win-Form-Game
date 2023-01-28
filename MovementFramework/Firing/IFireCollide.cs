using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovementFramework.Core;
using System.Windows.Forms;
using System.Drawing;
using MovementFramework.Collisions;

namespace MovementFramework.Firing
{
    public interface IFireCollide
    {
        void PerformAction(IGame game, GameObject go, FireClass fire);
    }
}
