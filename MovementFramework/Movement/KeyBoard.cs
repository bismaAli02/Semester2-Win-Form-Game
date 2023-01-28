using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MovementFramework.Movement
{
    public class KeyBoard : IMovement
    {
        private Point boundary;
        private int speed;
        private string arrowAction;
        private int offset;

        public KeyBoard(int speed, Point boundary)
        {
            this.Speed = speed;
            this.Boundary = boundary;
            offset = 55;
            arrowAction = null;
        }

        public Point Boundary { get => boundary; set => boundary = value; }
        public int Speed { get => speed; set => speed = value; }

        public void KeyPressed(Keys KeyCode)
        {
            if (KeyCode == Keys.Up)
            {
                arrowAction = "Up";
            }
            else if (KeyCode == Keys.Down)
            {
                arrowAction = "Down";
            }
            else if (KeyCode == Keys.Left)
            {
                arrowAction = "Left";
            }
            else if (KeyCode == Keys.Right)
            {
                arrowAction = "Right";
            }
        }

        public Point move(Point location1, Point location2)
        {
            if (arrowAction != null)
            {
                if (arrowAction == "Up")
                {
                    if (!(location1.Y < Boundary.Y / (3 * 0.8)))
                    {
                        location1.Y -= Speed;
                        location2.Y -= Speed;
                    }
                }
                else if (arrowAction == "Down")
                {
                    if (!(location2.Y >= Boundary.Y))
                    {
                        location1.Y += Speed;
                        location2.Y += Speed;
                    }
                }
                else if (arrowAction == "Left")
                {
                    if (!(location1.X < 0))
                    {
                        location1.X -= Speed;
                        location2.X += Speed;
                    }
                }
                else if (arrowAction == "Right")
                {
                    if (!(location1.X + offset >= Boundary.X))
                    {
                        location1.X += Speed;
                        location2.X += Speed;
                    }
                }
                arrowAction = null;
            }
            return location1;
        }

    }
}
