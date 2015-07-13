using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class Tail : EnvironmentObject

    {
        private const int TailWidth = 1;
        private const int TailHeight = 1;
        private int lifetime;

        public Tail(int x, int y, int lifetime = 1)
            : base(x, y, TailWidth, TailHeight)
        {
            this.lifetime = lifetime;
            this.ImageProfile = this.GenerateImageProfile();
            //this.CollisionGroup = CollisionGroup.Snowflake;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '*' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            //var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            //if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Snow)
            //{
            //    this.Exists = false;
            //}
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }

        public override void Update()
        {
            this.lifetime--;
            if (this.lifetime == 0)
            {
                this.Exists = false;
            }
        }
    }
}