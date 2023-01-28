using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MovementFramework.Core;

namespace MovementFramework.Movement
{
    public class Vertical : IMovement
    {
        private string direction;
        private Point boundary;
        private int speed;
        public string Direction { get => direction; set => direction = value; }
        public Point Boundary { get => boundary; set => boundary = value; }
        public int Speed { get => speed; set => speed = value; }

        public Vertical(string direction, int speed, Point boundary)
        {
            this.direction = direction;
            this.speed = speed;
            this.boundary = boundary;
        }

        public Point move(Point location1, Point location2)
        {
            if (location1.Y < Boundary.Y / (3 * 0.8))
            {
                Direction = "Down";
            }
            else if (location2.Y >= Boundary.Y)
            {
                Direction = "Up";
            }
            if (Direction == "Up")
            {
                location1.Y -= Speed;
                location2.Y -= Speed;
            }
            else if (Direction == "Down")
            {
                location1.Y += Speed;
                location2.Y += Speed;
            }
            return location1;
        }
    }
}
