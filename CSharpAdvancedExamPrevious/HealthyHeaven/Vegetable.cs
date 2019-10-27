﻿namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Vegetable
    {
        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }
        public string Name { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
            return $" - { this.Name} have { this.Calories} calories";
        }
    }
}
