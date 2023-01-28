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
    public class Horizontal : IMovement
    {
        private string direction;
        private Point boundary;
        private int speed;
        private int offset;
        public string Direction { get => direction; set => direction = value; }
        public Point Boundary { get => boundary; set => boundary = value; }
        public int Speed { get => speed; set => speed = value; }


        public Horizontal(string direction, int speed, Point boundary)
        {
            this.direction = direction;
            this.speed = speed;
            this.boundary = boundary;
            offset = 55;
        }

        public Point move(Point location1, Point location2)
        {
            if (location1.X < 0)
            {
                direction = "Right";
            }
            else if (location1.X + offset >= boundary.X)
            {
                direction = "Left";
            }
            if (direction == "Left")
            {
                location1.X -= speed;
                location2.X -= speed;
            }
            else
            {
                location1.X += speed;
                location2.X += speed;
            }
            return location1;
        }

    }
}
