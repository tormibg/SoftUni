using System;

namespace GalacticGPS
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                if (value > 90 || value < -90)
                {
                    throw new ArgumentOutOfRangeException("latitude", "Latitude should be in the range [-90 ... 90].");
                }
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (value > 180 || value < -180)
                {
                    throw new ArgumentOutOfRangeException("longitude", "Longitude should be in the range [-180 ... 180].");
                }
                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get { return this.planet; }
            set { this.planet = value; }
        }

        public override string ToString()
        {
            return string.Format("{0:F6}, {1:F6} - {2}", this.Latitude, this.Longitude, this.Planet);
        }
    }
}