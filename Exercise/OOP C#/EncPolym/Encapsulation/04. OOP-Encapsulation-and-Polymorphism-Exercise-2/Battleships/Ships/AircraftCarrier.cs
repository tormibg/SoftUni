﻿using System;

namespace Battleships.Ships
{

    public class AircraftCarrier : Battleship
    {
        private string name;
        private double lengthInMeters;
        private double volume;
        private int fighterCapacity;

        public AircraftCarrier(string name, double lengthInMeters, double volume, int fighterCapacity)
            : base(name, lengthInMeters, volume)
        {
            this.FighterCapacity = fighterCapacity;
        }

        public int FighterCapacity
        {
            get
            {
                return this.fighterCapacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The fighter capacity of an aircraft carrier cannot be negative.");
                }

                this.fighterCapacity = value;
            }
        }
        public override string Attack(Ship targetShip)
        {
            this.DestroyTarget(targetShip);
            return "My bomb destroy your ship !!!";
        }
    }
}
