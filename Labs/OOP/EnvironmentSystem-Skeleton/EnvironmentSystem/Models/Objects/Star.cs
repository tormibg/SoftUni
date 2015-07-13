using System;
using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Star : EnvironmentObject
    {
        private int counter = 0;
        private const int StarWidth = 1;
        private const int StarHeight = 1;
        private static readonly Random rand = new Random();
        private static readonly char[] chars = new[] { 'O', '@', '0' };

        public Star(int x, int y)
            : base(x, y, StarWidth, StarHeight)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Snow;
        }

        protected virtual char[,] GenerateImageProfile()
        {         
            var chari = chars[rand.Next(0,chars.Length)];

            return new char[,] { { chari } };
            
        }

        public Star(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            counter++;
            if (this.counter == 10)
            {
                this.ImageProfile = this.GenerateImageProfile();
                counter = 0;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObject = collisionInfo.HitObject;
            if (hitObject is Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}