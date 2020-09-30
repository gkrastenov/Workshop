namespace AdelphoiDemo
{
    using System;
    using System.Collections.Generic;
    using Zoo;
    class Program
    {
        private static List<Animal> allAnimals = new List<Animal>();
        static void Main(string[] args)
        {
            CreateAnimalsAndAddToList();
            ReduceHealth(allAnimals);
            ReduceHealth(allAnimals);
            ReduceHealth(allAnimals);
            ReduceHealth(allAnimals);

            FeedingAnimal(allAnimals);

            var aliveAnimals = ReturnAliveAnimal(allAnimals);
        }

        private static void CreateAnimalsAndAddToList()
        {
            Elephant el1 = new Elephant(20);
            Elephant el2 = new Elephant(100);
            Elephant el3 = new Elephant(100);
            Elephant el4 = new Elephant(100);
            Elephant el5 = new Elephant(100);
            allAnimals.Add(el1);
            allAnimals.Add(el2);
            allAnimals.Add(el3);
            allAnimals.Add(el4);
            allAnimals.Add(el5);

            Giraff gir1 = new Giraff(100);
            Giraff gir2 = new Giraff(100);
            Giraff gir3 = new Giraff(100);
            Giraff gir4 = new Giraff(100);
            Giraff gir5 = new Giraff(100);
            allAnimals.Add(gir1);
            allAnimals.Add(gir2);
            allAnimals.Add(gir3);
            allAnimals.Add(gir4);
            allAnimals.Add(gir5);

            Monkey mon1 = new Monkey(100);
            Monkey mon2 = new Monkey(100);
            Monkey mon3 = new Monkey(100);
            Monkey mon4 = new Monkey(100);
            Monkey mon5 = new Monkey(100);
            allAnimals.Add(mon1);
            allAnimals.Add(mon2);
            allAnimals.Add(mon3);
            allAnimals.Add(mon4);
            allAnimals.Add(mon5);
        }

        static void ReduceHealth(List<Animal> animals)
        {
            Random random = new Random();
            int randomValue =  random.Next(0, 20);

            foreach (var animal in animals)
            {
                // If animal is dead, we do not have to reduce him health value
                animal.CheckIsDeadAnimal();
                if (animal.IsDeadAnimal == true)
                {
                    continue;
                }
                else
                {
                    animal.HealthValue -= randomValue;
                }
            }
        }
        static void FeedingAnimal(List<Animal> animals)
        {
            Random random = new Random();
            int randomValueForMonkeys = random.Next(10, 25);
            int randomValueForGiraffes = random.Next(10, 25);
            int randomValueForElephants = random.Next(10, 25);

            foreach (var animal in animals)
            {
                // If animal is dead, we do not have to reduce him health value
                if (animal.IsDeadAnimal == true)
                {
                    continue;
                }
                switch (animal.TypeAnimal)
                {
                    case "Monkey": animal.HealthValue += randomValueForMonkeys;
                            break;
                    case "Giraff":
                        animal.HealthValue += randomValueForGiraffes;
                        break;
                    case "Elephant":
                        animal.HealthValue += randomValueForElephants;
                        break;
                    default:
                        // TODO : throw new ArgumentException()
                        break;
                }

                // HeathValue have to be from 0 to 100
                if (animal.HealthValue > 100)
                {
                    animal.HealthValue = 100;
                }
            }

        }
        static List<Animal> ReturnAliveAnimal(List<Animal> animals)
        {
            var liveAnimals = new List<Animal>();
            foreach (var animal in animals)
            {
                if (animal.IsDeadAnimal == false)
                {
                    liveAnimals.Add(animal);
                }
            }

            return liveAnimals;
        }
    }
}
