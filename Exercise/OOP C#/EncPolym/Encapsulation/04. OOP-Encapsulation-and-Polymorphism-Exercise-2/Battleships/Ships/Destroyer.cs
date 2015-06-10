﻿namespace Battleships.Ships
{
    using System;

    public class Destroyer : Battleship
    {
        private string name;
        private double lengthInMeters;
        private double volume;
        private int numberOfAmmunition;

        public Destroyer(string name, double lengthInMeters, double volume, int numberOfAmmunition)
            : base(name, lengthInMeters, volume)
        {
            this.NumberOfAmmunition = numberOfAmmunition;
        }

        public int NumberOfAmmunition
        {
            get
            {
                return this.numberOfAmmunition;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The number of ammunition in a destroyer cannot be negative.");
                }

                this.numberOfAmmunition = value;
            }
        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyTarget(targetShip);
            return "Destroyer destroy ship !!!";
        }       
    }
}
