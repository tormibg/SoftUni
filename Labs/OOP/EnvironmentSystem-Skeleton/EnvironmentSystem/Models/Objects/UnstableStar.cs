using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class UnstableStar : FallingStar
    {
        private int lifetime;
        public UnstableStar(int x, int y, Point direction, int lifetime = 8) : base(x, y, direction)
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            this.lifetime--;
            if (this.lifetime == 0)
            {
                this.Exists = false;
            }
            base.Update();
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists)
            {
                return base.ProduceObjects();
            }
            else
            {
                List<EnvironmentObject> explosion = new List<EnvironmentObject>();
                for (int y = this.Bounds.TopLeft.Y-2; y <= this.Bounds.TopLeft.Y+2; y++)
                {
                    for (int x = this.Bounds.TopLeft.X -2; x <= this.Bounds.TopLeft.X + 2; x++)
                    {
                        if (!(this.Bounds.TopLeft.X == x && this.Bounds.TopLeft.Y == y))
                        {
                            explosion.Add(new Explosion(x,y));
                        }
                        
                    }
                }
                return explosion;
            }
            
        }
    }
}