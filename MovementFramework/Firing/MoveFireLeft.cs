using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovementFramework.Firing
{
    public class MoveFireLeft : IFire
    {
        private int speed;

        public MoveFireLeft(int speed)
        {
            this.speed = speed;
        }
        public void MoveFire(PictureBox fire)
        {
            fire.Left -= speed;
        }
    }
}
