using COMP123_S2019_FinalTestB.Objects;
using COMP123_S2019_FinalTestB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 *  Student Name: Lilian Nishimaru de Souza 
 *  Student ID: 301044056   
 *  Description: This is the main application entry 
 */
namespace COMP123_S2019_FinalTestB
{
    public static class Program
    {
        // temporary
        public static CharacterGeneratorForm characterForm;
        public static AboutForm aboutBox;
        public static Character character;
        public static Item item;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            characterForm = new CharacterGeneratorForm();
            aboutBox = new AboutForm();
            character = new Character();
            item = new Item();
            Application.Run(characterForm);
        }
    }
}
