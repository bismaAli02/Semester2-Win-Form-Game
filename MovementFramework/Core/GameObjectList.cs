using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MovementFramework.Movement;
using MovementFramework.Collisions;
using MovementFramework.Firing;

namespace MovementFramework.Core
{
    public class GameObjectList : IGame
    {
        private List<GameObject> gameObjects;
        private List<CollisionClass> collisions;
        private List<FireCollisionClass> fireCollide;
        private List<FireClass> fireList;
        public event EventHandler onAddingGameObject;
        public event EventHandler onAddingFire;
        public event EventHandler OnPlayerDie;
        public event EventHandler RemoveFire;
        public GameObjectList()
        {
            collisions = new List<CollisionClass>();
            GameObjects = new List<GameObject>();
            fireList = new List<FireClass>();
            FireCollide = new List<FireCollisionClass>();
        }
        public void AddFire(Image img, int top, int left, IFire fireMovement, string oType)
        {
            FireClass fire = new FireClass(img, top, left, fireMovement, oType);
            FireList.Add(fire);
            onAddingFire?.Invoke(fire.FirePb, EventArgs.Empty);
        }
        public void RaisePlayerDieEvent(GameObject pb)
        {
            OnPlayerDie?.Invoke(pb, EventArgs.Empty);
        }
        public void RaisePlayerFireDieEvent(GameObject pb, FireClass fire)
        {
            OnPlayerDie?.Invoke(pb, EventArgs.Empty);
            RemoveFire?.Invoke(fire, EventArgs.Empty);
            fireList.Remove(fire);
        }
        public void AddCollisions(CollisionClass c)
        {
            collisions.Add(c);
        }
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        public List<FireClass> FireList { get => fireList; set => fireList = value; }
        public List<FireCollisionClass> FireCollide { get => fireCollide; set => fireCollide = value; }

        public void AddGameObj(Image img, int top, int left, int width, int height, IMovement movement, string oType)
        {
            GameObject gb = new GameObject(img, top, left, width, height, movement, oType);
            GameObjects.Add(gb);
            onAddingGameObject?.Invoke(gb, EventArgs.Empty);
        }
        public void KeyPressed(Keys KeyCode)
        {
            foreach (GameObject gameObj in GameObjects)
            {
                if (gameObj.Movement.GetType() == typeof(KeyBoard))
                {
                    KeyBoard keyBoard = (KeyBoard)gameObj.Movement;
                    keyBoard.KeyPressed(KeyCode);
                }
            }
        }
        public void update()
        {
            detectCollision();
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.GameObjectMove();
            }
            foreach (FireClass fire in fireList)
            {
                fire.FireMove();
            }
        }
        public GameObject GetPlayer()
        {
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.OType == "player")
                {
                    return gameObject;
                }
            }
            return null;
        }
        public GameObject GetEnemy(int idx)
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                if (GameObjects[i].OType == "enemy")
                {
                    if (i == idx)
                    {
                        return gameObjects[i];
                    }

                }
            }
            return null;
        }
        public void detectCollision()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = 0; j < gameObjects.Count; j++)
                {
                    if (gameObjects[i].Character.Bounds.IntersectsWith(gameObjects[j].Character.Bounds))
                    {
                        foreach (CollisionClass c in collisions)
                        {
                            if (gameObjects[i].OType == c.O1Type && gameObjects[j].OType == c.O2Type)
                            {
                                c.Behavior.PerformAction(this, gameObjects[i], gameObjects[j]);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = 0; j < fireList.Count; j++)
                {
                    if (gameObjects[i].Character.Bounds.IntersectsWith(fireList[j].FirePb.Bounds))
                    {
                        foreach (FireCollisionClass f in fireCollide)
                        {
                            if (gameObjects[i].OType == f.O1Type && fireList[j].OType == f.O2Type)
                            {
                                f.Behavior.PerformAction(this, gameObjects[i], fireList[j]);
                            }
                        }
                    }
                }
            }
        }
    }
}
