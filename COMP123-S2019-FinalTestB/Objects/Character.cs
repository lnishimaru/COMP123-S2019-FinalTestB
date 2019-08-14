using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Student Name: Lilian Nishimaru de Souza 
 *  Student ID: 301044056   
 *  Description: This is the Character Class used in Character creation 
 *               This is the Data Container for the application
 */
namespace COMP123_S2019_FinalTestB.Objects
{
    public class Character
    {
        //Character Abilities
        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Constitution { get; set; }
        public string Intelligence { get; set; }
        public string Wisdom { get; set; }
        public string Charisma { get; set; }
        //Secondary Abilities
        public int ArmourClass { get; set; }
        public int HitPoints { get; set; }
        //Character Class
        public CharacterClass Class { get; set; }
        public int Level { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<string> FirstNameList;
        public List<string> LastNameList;
        //Equipment
        public List<string> Inventory;
        //Constructor method
        public Character()
        {
            this.Inventory = new List<string>();
        }
    }
}
