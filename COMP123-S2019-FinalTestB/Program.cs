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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            characterForm = new CharacterGeneratorForm(); 

            Application.Run(characterForm);
        }
    }
}
