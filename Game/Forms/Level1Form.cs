using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovementFramework;
using MovementFramework.Core;
using MovementFramework.Movement;
using MovementFramework.Collisions;
using MovementFramework.Firing;

namespace Game.Forms
{
    public partial class Level1Form : Form
    {
        private string name;
        private int score = 0;
        private GameObjectList game;
        private List<GameObject> Enemies;
        System.Random random = new System.Random();
        public Level1Form(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void Level1Form_Load(object sender, EventArgs e)
        {
            game = new GameObjectList();
            Enemies = new List<GameObject>();
            game.onAddingGameObject += new EventHandler(addIntoControls);
            game.OnPlayerDie += new EventHandler(OnPlayerDie);
            game.onAddingFire += new EventHandler(AddFireInControls);
            game.RemoveFire += new EventHandler(RemoveFireFromControls);
            Point boundary = new Point(this.Width, this.Height);
            int left = 0;
            int top = this.Height / 2;
            game.AddGameObj(Game.Properties.Resources.Cop, top, left, 90, 90, new KeyBoard(4, boundary), "player");
            CreateEnemy(Game.Properties.Resources.enemy1, new Horizontal("Left", 4, boundary));
            CreateEnemy(Game.Properties.Resources.enemy1, new Vertical("Up", 4, boundary));
            CreateEnemy(Game.Properties.Resources.enemy1, new MovementFramework.Movement.Random("Left", 4, boundary));


            CollisionClass c = new CollisionClass("player", "enemy", new PlayerCollision());
            FireCollisionClass f = new FireCollisionClass("player", "Ebullet", new fireCollision());
            FireCollisionClass f1 = new FireCollisionClass("enemy", "Cbullet", new fireCollision());
            //CollisionClass c1 = new CollisionClass("player", "Ebullet", new PlayerFireCollision());
            //CollisionClass c2 = new CollisionClass("enemy", "Cbullet", new PlayerCollision());
            game.AddCollisions(c);
            game.FireCollide.Add(f);
            game.FireCollide.Add(f1);
            //game.AddCollisions(c1);
            //game.AddCollisions(c2);
        }

        private void RemoveFireFromControls(object sender, EventArgs e)
        {
            this.Controls.Remove(((FireClass)sender).FirePb);
        }

        private void AddFireInControls(object sender, EventArgs e)
        {
            PictureBox fire = (PictureBox)sender;
            this.Controls.Add(fire);
            fire.Visible = true;
        }

        private void CreateEnemy(Image img, IMovement movement)
        {
            int left = random.Next(this.Width * 3 / 4, this.Width - 90);
            int t2 = (int)(this.Height / (2 * 0.55));
            int t1 = (int)(Height / (3 * 0.8) - 90);
            int top = random.Next(t1, t2);
            game.AddGameObj(img, left, top, 90, 90, movement, "enemy");
        }
        private int GetRandomValues(int max)
        {
            return random.Next(0, max);
        }
        private void addIntoControls(object sender, EventArgs e)
        {
            GameObject go = (GameObject)sender;

            this.Controls.Add(go.Character);
            this.Controls.Add(go.Health);
            if (go.OType == "enemy")
            {
                Enemies.Add(go);
            }

        }
        public void OnPlayerDie(object sender, EventArgs e)
        {
            GameObject go = (GameObject)sender;
            if (go.OType == "enemy")
            {
                if (go.Health.Value != 0)
                {
                    go.Health.Value -= 25;
                }
                else
                {
                    this.Controls.Remove(go.Character);
                    this.Controls.Remove(go.Health);
                    CreateEnemy(go.Character.Image, go.Movement);
                    game.GameObjects.Remove(go);
                }
                score += 10;
            }
            else if (go.OType == "player")
            {
                if (go.Health.Value != 0)
                {
                    go.Health.Value -= 25;
                    int left = 0;
                    int top = this.Height / 2;
                    go.Character.Left = left;
                    go.Character.Top = top;
                }
                else
                {
                    this.Controls.Remove(go.Character);
                    this.Controls.Remove(go.Health);
                    timer1.Enabled = false;
                    MessageBox.Show("YOU LOSE!!!");
                    PlayerDL.AddPlayerInList(name, score);
                    PlayerDL.StoreScore();
                    MenuForm menu = new MenuForm();
                    this.Hide();
                    menu.ShowDialog();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int idx = GetRandomValues(Enemies.Count + 50);
            if (idx < Enemies.Count)
            {
                CreateEnemyFire(Enemies[idx]);
            }
            game.update();
            UpdateScore();
            if (score >= 200)
            {
                timer1.Enabled = false;
                MessageBox.Show("Level 2");
                Level2Form playlvl2 = new Level2Form(name, score);
                this.Hide();
                playlvl2.ShowDialog();
            }
        }
        private void UpdateScore()
        {
            Scorelbl.Text = "Score: " + score.ToString();
        }
        public void CreateEnemyFire(GameObject enemy)
        {
            game.AddFire(Game.Properties.Resources._2, (enemy.Character.Top + (enemy.Character.Height / 2)) - 30, enemy.Character.Left - 20, new MoveFireLeft(5), "Ebullet");
        }
        private void Level1Form_KeyDown(object sender, KeyEventArgs e)
        {
            game.KeyPressed(e.KeyCode);
            if (e.KeyCode == Keys.Space)
            {
                CreateCopFire();
            }
        }
        public void CreateCopFire()
        {
            PictureBox Cop = game.GetPlayer().Character;
            int Left = Cop.Right;
            int Top = (Cop.Top + (Cop.Height / 2)) - 30;
            game.AddFire(Game.Properties.Resources.copBullet, Top, Left, new MoveFireRight(5), "Cbullet");
        }

        private void Level1Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlayerDL.AddPlayerInList(name, score);
            PlayerDL.StoreScore();
            Application.Exit();
        }
    }
}
