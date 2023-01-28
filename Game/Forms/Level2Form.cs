using MovementFramework.Collisions;
using MovementFramework.Core;
using MovementFramework.Firing;
using MovementFramework.Movement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game.Forms
{
    public partial class Level2Form : Form
    {
        private string name;
        private int score = 0;
        private GameObjectList game;
        private List<GameObject> Enemies;
        System.Random random = new System.Random();
        public Level2Form(string name, int score)
        {
            InitializeComponent();
            this.name = name;
            this.score = score;
        }

        private void Level2Form_Load(object sender, EventArgs e)
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

            AddCars();
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
            if (go.OType != "car")
            {
                this.Controls.Add(go.Health);
            }
            if (go.OType == "enemy")
            {
                Enemies.Add(go);
            }

        }
        private void AddCars()
        {
            int left = random.Next(this.Width / 2, this.Width - 100);
            game.AddGameObj(Game.Properties.Resources.Car, this.Width - 500, left, 150, 75, new Horizontal("Left", 5, new Point(this.Width, this.Height)), "car");
            //left = random.Next(this.Width / 2, this.Width - 100);
            //game.AddGameObj(Game.Properties.Resources.Car, this.Width - 150, left, 150, 75, new Horizontal("Left", 5, new Point(this.Width, this.Height)), "car");
            //left = random.Next(this.Width / 2, this.Width - 100);
            //game.AddGameObj(Game.Properties.Resources.Car, this.Width - 150, left, 150, 75, new Horizontal("Left", 5, new Point(this.Width, this.Height)), "car");
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
            if (score >= 400)
            {
                timer1.Enabled = false;
                MessageBox.Show("YOU WON!!!!");
                PlayerDL.AddPlayerInList(name, score);
                PlayerDL.StoreScore();
                MenuForm menu = new MenuForm();
                this.Hide();
                menu.ShowDialog();
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
        private void Level2Form_KeyDown(object sender, KeyEventArgs e)
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

        private void Level2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlayerDL.AddPlayerInList(name, score);
            PlayerDL.StoreScore();
            Application.Exit();
        }
    }
}
