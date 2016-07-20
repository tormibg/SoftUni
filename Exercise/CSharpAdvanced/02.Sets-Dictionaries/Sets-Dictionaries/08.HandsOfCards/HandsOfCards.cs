namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        public static void Main()
        {
            Dictionary<string, HashSet<string>> playersCardsDictionary = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string[] input =
                    Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string playerName = input[0];
                if (input[0] == "JOKER")
                {
                    break;
                }
                string[] playerCards = input[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (!playersCardsDictionary.ContainsKey(playerName))
                {
                    playersCardsDictionary.Add(playerName, new HashSet<string>());
                }
                for (int i = 0; i < playerCards.Length; i++)
                {
                    playersCardsDictionary[playerName].Add(playerCards[i]);
                }
            }
            foreach (KeyValuePair<string, HashSet<string>> playersPair in playersCardsDictionary)
            {
                int power = 0;
                foreach (var card in playersPair.Value)
                {
                    power += GetCardPower(card.Trim());
                }
                Console.WriteLine($"{playersPair.Key}: {power}");
            }
        }

        private static int GetCardPower(string card)
        {
            string[] faces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] powers = new string[] { "C", "D", "H", "S" };

            string faceCard = "";

            faceCard = card.Length > 2 ? "10" : card[0].ToString();

            string powerCard = card.Substring(card.Length - 1);

            return (Array.IndexOf(faces, faceCard) + 2) * (Array.IndexOf(powers, powerCard) + 1);
        }
    }
}
