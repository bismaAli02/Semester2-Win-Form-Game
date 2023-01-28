using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovementFramework.Firing
{
    public class FireCollisionClass
    {
        private string o1Type;
        private string o2Type;
        private IFireCollide behavior;
        public FireCollisionClass(string o1Type, string o2Type, IFireCollide behavior)
        {
            this.O1Type = o1Type;
            this.O2Type = o2Type;
            this.Behavior = behavior;
        }

        public string O1Type { get => o1Type; set => o1Type = value; }
        public string O2Type { get => o2Type; set => o2Type = value; }
        public IFireCollide Behavior { get => behavior; set => behavior = value; }
    }
}
