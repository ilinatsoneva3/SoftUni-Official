﻿namespace SpaceStation.Models.Planets
{
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string name;
        private IList<string> items;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items;

        public string Name
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }      
    }
}
