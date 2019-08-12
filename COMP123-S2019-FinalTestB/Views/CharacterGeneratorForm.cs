using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/*
 *  Student Name: Lilian Nishimaru de Souza 
 *  Student ID: 301044056   
 *  Description: This is the Character Generator Form - the main form of the application  
 */
namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : COMP123_S2019_FinalTestB.Views.MasterForm
    {
        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is the event handler to the next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count -1)
            {
                MainTabControl.SelectedIndex++;
            }
        }
        /// <summary>
        /// This is the event handler for the back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }
    }
}
