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
    public class Random : IMovement
    {
        private string direction;
        private Point boundary;
        private int speed;
        private int offset;

        public Random(string direction, int speed, Point boundary)
        {
            this.Direction = direction;
            this.Speed = speed;
            this.Boundary = boundary;
            offset = 55;
        }

        public string Direction { get => direction; set => direction = value; }
        public Point Boundary { get => boundary; set => boundary = value; }
        public int Speed { get => speed; set => speed = value; }

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
            else if (location1.X < 0)
            {
                Direction = "Right";
            }
            else if (location1.X + offset >= Boundary.X)
            {
                Direction = "Left";
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
            else if (Direction == "Left")
            {
                location1.X -= Speed;
                location2.X -= Speed;
            }
            else if (Direction == "Right")
            {
                location1.X += Speed;
                location2.X += Speed;
            }
            return location1;
        }
    }
}
