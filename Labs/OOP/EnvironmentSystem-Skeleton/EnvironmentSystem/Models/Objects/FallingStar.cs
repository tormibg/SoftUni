using System.Collections;
using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class FallingStar : MovingObject
    {
        private const int FalStarWidth = 1;
        private const int FalStarHeight = 1;

        public FallingStar(int x, int y, Point direction)
            : base(x, y, FalStarWidth, FalStarHeight, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Snowflake;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { 'O' } };
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[]
            {
              //new Tail(this.Bounds.TopLeft.X-1,this.Bounds.TopLeft.Y-1,this.Bounds.Width, this.Bounds.Height,this.Direction),
              //new Tail(this.Bounds.TopLeft.X-2,this.Bounds.TopLeft.Y-2,this.Bounds.Width, this.Bounds.Height,this.Direction),
              //new Tail(this.Bounds.TopLeft.X-3,this.Bounds.TopLeft.Y-3,this.Bounds.Width, this.Bounds.Height,this.Direction),
              new Tail(this.Bounds.TopLeft.X-this.Direction.X, this.Bounds.TopLeft.Y-this.Direction.Y), 
              new Tail(this.Bounds.TopLeft.X-2*this.Direction.X, this.Bounds.TopLeft.Y-2*this.Direction.Y), 
              new Tail(this.Bounds.TopLeft.X-3*this.Direction.X, this.Bounds.TopLeft.Y-3*this.Direction.Y), 
            };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObject = collisionInfo.HitObject.CollisionGroup;
            if (hitObject == CollisionGroup.Ground)
            {
                this.Exists = false;
            }
            var hitObject1 = collisionInfo.HitObject;
            if (hitObject1 is Explosion)
            {
                this.Exists = false;
            }
        }
    }
}
