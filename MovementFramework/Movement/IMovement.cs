using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MovementFramework.Movement
{
    public interface IMovement
    {
        Point move(Point location1, Point location2);
    }
}
