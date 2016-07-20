namespace _14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DragonArmy
    {
        public static void Main()
        {
            uint defaultHealth = 250;
            uint defaultDamage = 45;
            uint defaultArmor = 10;
            Dictionary<string, double[]> typesOfDragons = new Dictionary<string, double[]>();
            Dictionary<string, SortedDictionary<string, uint[]>> dragonsDictionary = new Dictionary<string, SortedDictionary<string, uint[]>>();

            uint inputLines = uint.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string typeOfDragon = inputArgs[0];
                string dragon = inputArgs[1];
                var damage = inputArgs[2] == "null" ? defaultDamage : uint.Parse(inputArgs[2]);
                var health = inputArgs[3] == "null" ? defaultHealth : uint.Parse(inputArgs[3]);
                var armor = inputArgs[4] == "null" ? defaultArmor : uint.Parse(inputArgs[4]);

                if (!dragonsDictionary.ContainsKey(typeOfDragon))
                {
                    dragonsDictionary.Add(typeOfDragon, new SortedDictionary<string, uint[]>());
                    typesOfDragons.Add(typeOfDragon, new double[4]);
                }

                if (!dragonsDictionary[typeOfDragon].ContainsKey(dragon))
                {
                    dragonsDictionary[typeOfDragon].Add(dragon, new uint[3]);
                }
                else
                {
                    uint[] dragonStats = dragonsDictionary[typeOfDragon][dragon];
                    typesOfDragons[typeOfDragon][0] -= dragonStats[0];
                    typesOfDragons[typeOfDragon][1] -= dragonStats[1];
                    typesOfDragons[typeOfDragon][2] -= dragonStats[2];
                    typesOfDragons[typeOfDragon][3] -= 1;
                }

                dragonsDictionary[typeOfDragon][dragon][0] = damage;
                dragonsDictionary[typeOfDragon][dragon][1] = health;
                dragonsDictionary[typeOfDragon][dragon][2] = armor;

                typesOfDragons[typeOfDragon][0] += damage;
                typesOfDragons[typeOfDragon][1] += health;
                typesOfDragons[typeOfDragon][2] += armor;
                typesOfDragons[typeOfDragon][3] += 1;
            }

            StringBuilder dragonsSB = new StringBuilder();
            foreach (var type in typesOfDragons)
            {
                string dragonType = type.Key;
                uint dragonCount = (uint)type.Value[3];
                var avrDamage = type.Value[0] / dragonCount;
                var avrHealth = type.Value[1] / dragonCount;
                var avrArmor = type.Value[2] / dragonCount;
                dragonsSB.Append(dragonType + "::");
                dragonsSB.Append($"({avrDamage:F2}/{avrHealth:F2}/{avrArmor:F2})\n");
                foreach (var dragons in dragonsDictionary[dragonType])
                {
                    dragonsSB.Append(
                        $"-{dragons.Key} -> damage: {dragons.Value[0]}, health: {dragons.Value[1]}, armor: {dragons.Value[2]}\n");
                }
            }
            Console.WriteLine(dragonsSB);
        }
    }
}
