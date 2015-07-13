using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Snow : EnvironmentObject
    {

        public Snow(int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Ground;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '.' } };
        }

        public Snow(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
        }


        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }
    }
}