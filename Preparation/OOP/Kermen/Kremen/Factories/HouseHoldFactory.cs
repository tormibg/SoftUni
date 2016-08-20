namespace Kremen.Factories
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Models;

    static class HouseHoldFactory
    {
        public static HouseHold CreateHouseHold(string input)
        {
            string pattern = @"(\w+)\(([\d\.\s,]+)\)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);
            if (rgx.IsMatch(input))
            {
                string houseHoldType = matches[0].Groups[1].Value;
                if (houseHoldType == "YoungCouple")
                {
                    return CreateYoungCouple(matches);
                }
                else if (houseHoldType == "YoungCoupleWithChildren")
                {
                    return CreateYoungCoupleWithChildren(matches);
                }
                else if (houseHoldType == "AloneYoung")
                {
                    return CreateAlongYoung(matches);
                }
                else if (houseHoldType == "OldCouple")
                {
                    return CreateOldCouple(matches);
                }
                else if (houseHoldType == "AloneOld")
                {
                    return CreateAloneOld(matches);
                }
                else
                {
                    throw new ArgumentException("Invalid houseHoldType");
                }
            }

            throw new ArgumentException("Invalid household");
        }

        private static HouseHold CreateAloneOld(MatchCollection matches)
        {
            decimal salary = decimal.Parse(matches[0].Groups[2].Value);

            return new AloneOld(salary);
        }

        private static HouseHold CreateOldCouple(MatchCollection matches)
        {
            decimal[] pension =
                matches[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal stoveCost = decimal.Parse(matches[3].Groups[2].Value);

            return new OldCouple(pension[0], pension[1], tvCost, fridgeCost, stoveCost);
        }

        private static HouseHold CreateAlongYoung(MatchCollection matches)
        {
            decimal salary = decimal.Parse(matches[0].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[1].Groups[2].Value);

            return new AlongYoung(salary, laptopCost);
        }

        private static HouseHold CreateYoungCoupleWithChildren(MatchCollection matches)
        {
            decimal[] salaries =
                matches[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

            Child[] children = new Child[matches.Count - 4];
            for (int i = 4; i < matches.Count; i++)
            {
                decimal[] consumtions =
                    matches[i].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(decimal.Parse)
                        .ToArray();
                children[i - 4] = new Child(consumtions);
            }
            return new YoungCoupleWithChildren(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost, children);
        }

        private static HouseHold CreateYoungCouple(MatchCollection matches)
        {
            decimal[] salaries =
                matches[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();
            decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

            return new YoungCouple(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost);
        }
    }
}
