using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovementFramework.Core;

namespace MovementFramework.Collisions
{
    public interface ICollisionAction
    {
        void PerformAction(IGame game, GameObject source1, GameObject source2);
    }
}
