using System;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    public class NewEngine : Engine
    {

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {

                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
            }
            base.ExecuteCommand(inputParams);
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character newCharacter;
            switch (inputParams[1].ToLower())
            {
                case "warrior" :
                    newCharacter = new Warrior(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]),(Team)Enum.Parse(typeof(Team),inputParams[5],true));
                    this.characterList.Add(newCharacter);
                    break;
                case "mage" :
                    newCharacter = new Mage(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]),(Team)Enum.Parse(typeof(Team),inputParams[5],true));
                    this.characterList.Add(newCharacter);
                    break;
                case "healer" :
                    newCharacter = new Healer(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]),(Team)Enum.Parse(typeof(Team),inputParams[5],true));
                    this.characterList.Add(newCharacter);
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            Character charToAdd = GetCharacterById(inputParams[1]);
            switch (inputParams[2].ToLower())
            {
                case "axe":
                    charToAdd.AddToInventory(new Axe(inputParams[3]));
                    break;
                case "shield":
                    charToAdd.AddToInventory(new Shield(inputParams[3]));
                    break;
                case "injection":
                    charToAdd.AddToInventory(new Injection(inputParams[3]));
                    break;
                case "pill":
                    charToAdd.AddToInventory(new Pill (inputParams[3]));
                    break;
            }
        }
    }
}