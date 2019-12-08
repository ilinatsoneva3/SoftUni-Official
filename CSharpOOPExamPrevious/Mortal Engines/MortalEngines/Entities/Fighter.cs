namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Fighter : BaseMachine, IFighter, IMachine
    {
        public const int InitialHealthPoints = 200;
        private bool aggressiveMode = true;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode
        {
            get => this.aggressiveMode;
            private set
            {
                this.aggressiveMode = value;
            }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode==true)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;          
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Aggressive: {(this.AggressiveMode == true ? "ON" : "OFF")}";
        }
    }
}
