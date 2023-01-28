using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MovementFramework.Firing
{
    public class FireClass
    {
        private PictureBox firePb;
        private IFire fireMovement;
        private string oType;
        public FireClass(Image img, int top, int left, IFire fireMovement, string oType)
        {
            this.FireMovement = fireMovement;

            firePb = new PictureBox();
            firePb.Image = img;
            firePb.BackColor = Color.Transparent;
            firePb.Left = left;
            firePb.Top = top;
            firePb.Height = 10;
            firePb.Width = 30;
            firePb.SizeMode = PictureBoxSizeMode.StretchImage;
            this.OType = oType;
        }

        public PictureBox FirePb { get => firePb; set => firePb = value; }
        public IFire FireMovement { get => fireMovement; set => fireMovement = value; }
        public string OType { get => oType; set => oType = value; }

        public void FireMove()
        {
            fireMovement.MoveFire(firePb);
        }
    }
}
