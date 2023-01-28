using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MovementFramework.Movement;

namespace MovementFramework.Core
{
    public class GameObject
    {
        private PictureBox character;
        private ProgressBar health;
        private IMovement movement;
        private string oType;

        public GameObject(Image img, int top, int left, int width, int height, IMovement movement, string oType)
        {
            //character = new ucCharacter(img);
            Character = new PictureBox();
            Character.Image = img;
            Character.BackColor = Color.Transparent;
            Character.Left = left;
            Character.Top = top;
            Character.Height = height;
            Character.Width = width;
            Health = new ProgressBar();
            Health.Left = left;
            Health.Top = top + 90;
            Health.Width = 90;
            Health.Height = 25;
            Health.Value = 100;

            Character.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Movement = movement;
            this.OType = oType;
        }

        public PictureBox Character { get => character; set => character = value; }
        public IMovement Movement { get => movement; set => movement = value; }
        public string OType { get => oType; set => oType = value; }
        public ProgressBar Health { get => health; set => health = value; }

        public void GameObjectMove()
        {
            Character.Location = Movement.move(Character.Location, health.Location);
            health.Left = Character.Left;
            health.Top = Character.Top + 90;
        }
    }
}
