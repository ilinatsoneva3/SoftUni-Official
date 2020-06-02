namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Animals;

    public class AnimalCreator
    {
        public Animal CreateAnimal(IList<string> args)
        {
            var type = args[0];
            var name = args[1];
            var weight = double.Parse(args[2]);

            switch (type)
            {
                case nameof(Cat):
                    var livingRegionCat = args[3];
                    var breedCat = args[4];
                    return new Cat(name, weight, livingRegionCat, breedCat);
                case nameof(Dog):
                    var livingRegionDog = args[3];
                    return new Dog(name, weight, livingRegionDog);
                case nameof(Tiger):
                    var livingRegionTiger = args[3];
                    var breedTiger = args[4];
                    return new Tiger(name, weight, livingRegionTiger, breedTiger);
                case nameof(Hen):
                    var wingSizeHen = double.Parse(args[3]);
                    return new Hen(name, weight, wingSizeHen);
                case nameof(Owl):
                    var wingSizeOwl = double.Parse(args[3]);
                    return new Owl(name, weight, wingSizeOwl);
                case nameof(Mouse):
                    var livingRegionMouse = args[3];
                    return new Mouse(name, weight, livingRegionMouse);
                default:
                    throw new ArgumentException($"{type} is not a valid type of animal!");
            }
        }
    }
}
