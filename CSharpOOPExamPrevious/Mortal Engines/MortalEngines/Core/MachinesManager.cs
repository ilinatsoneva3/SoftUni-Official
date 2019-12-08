namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;

    public class MachinesManager : IMachinesManager
    {
        private Dictionary<string, IPilot> pilots;
        private Dictionary<string, IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.ContainsKey(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                var pilot = new Pilot(name);
                this.pilots.Add(name, pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                Tank tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(name, tank);
                return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                Fighter fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(name, fighter);
                return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints,
                    fighter.DefensePoints, (fighter.AggressiveMode == true ? "ON" : "OFF"));
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.ContainsKey(selectedPilotName))
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (!this.machines.ContainsKey(selectedMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            Pilot pilot = this.pilots[selectedPilotName] as Pilot;
            IMachine machine = this.machines[selectedMachineName];

            if (machine.Pilot!=null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.ContainsKey(attackingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            if (!this.machines.ContainsKey(defendingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            var attackingMachine = this.machines[attackingMachineName];
            var defendingMachine = this.machines[defendingMachineName];

            if (attackingMachine.HealthPoints==0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            if (defendingMachine.HealthPoints==0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);
            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots[pilotReporting];
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines[machineName];
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.ContainsKey(fighterName))
            {
                Fighter fighter = this.machines[fighterName] as Fighter;
                fighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.ContainsKey(tankName))
            {
                Tank tank = this.machines[tankName] as Tank;
                tank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
            else
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
        }
    }
}