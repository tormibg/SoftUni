using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CountrySS
{
    class Country
    {
        private string name;
        private Int64 population;
        private float area;
        private HashSet<string> cities;
        private string[] arrays; 

        public Country(string name, int population, int area)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;   
        }

        public Country(string name, int population, int area, params string[] cities)
            : this(name, population, area)
        {
            this.Cities = new HashSet<string>(cities);
        }

        public string Name { get; set; }
        public Int64 Population { get; set; }
        public float Area { get; set; }
        public HashSet<string> Cities { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Area.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Country tmpCountry = obj as Country;
            if (tmpCountry == null)
            {
                return false;
            }
            if (this.Name == tmpCountry.Name)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Country c1, Country c2)
        {
            return Equals(c1, c2);
        }

        public static bool operator !=(Country c1, Country c2)
        {
            return !Equals(c1, c2);
        }
    }
}
