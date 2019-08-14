using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// <summary>
        /// This method handles the Open File event on the strip and tool menus on Character
        /// Generator Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //configure open file dialog
            CharacterOpenFileDialog.FileName = "Character.txt";
            CharacterOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterOpenFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            //open the file dialog
            var result = CharacterOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                using (StreamReader inputStream = new StreamReader(
                File.Open(CharacterOpenFileDialog.FileName, FileMode.Open)))
                {
                    try
                    {
                        //read file
                        //Program.computers.ProductID = int.Parse(inputStream.ReadLine());
                        //Program.computers.Cost = double.Parse(inputStream.ReadLine());
                        //Program.computers.Condition = inputStream.ReadLine();

                        inputStream.Close();
                        inputStream.Dispose();

                        //ProductInfoForm_Activated(sender, e);
                    }
                    catch (IOException exception)
                    {
                        MessageBox.Show("Error: " + exception.Message, "File I/O Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// This method handles the generate name button by selecting a random first and 
        /// last name from the txt files on Character Generator Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // load the list of first names 
            using (StreamReader inputStream = new StreamReader(
               File.Open("firstNames.txt", FileMode.Open)))
            {
                //read file
                string[] firstNames = inputStream.ReadToEnd().Split();
                int indFirst = rnd.Next(0, firstNames.Length);
                FirstNameDataLabel.Text = firstNames[indFirst];
                try
                {
                    inputStream.Close();
                    inputStream.Dispose();
                }
                catch (IOException exception)
                {
                    MessageBox.Show("Error: " + exception.Message, "File I/O Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            // load the list of last names
            using (StreamReader inputStream = new StreamReader(
               File.Open("lastNames.txt", FileMode.Open)))
            {
                //read file
                string[] lastNames = inputStream.ReadToEnd().Split();
                int indLast = rnd.Next(0, lastNames.Length);
                LastNameDataLabel.Text = lastNames[indLast];
                try
                {
                    inputStream.Close();
                    inputStream.Dispose();
                }
                catch (IOException exception)
                {
                    MessageBox.Show("Error: " + exception.Message, "File I/O Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// This method handles the save file dialog from save options in menu and tool strip on
        /// Character Generator form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //configuring the dialog
            CharacterSaveFileDialog.FileName = "Character.txt";
            CharacterSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterSaveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            //open file dialog - Modal Form
            var result = CharacterSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                //open file
                using (StreamWriter outputString = new StreamWriter(
                    File.Open(CharacterSaveFileDialog.FileName, FileMode.Create)))
                {
                    //write file
                    //outputString.WriteLine(Program.computers.ProductID);
                    //outputString.WriteLine(Program.computers.Cost.ToString());
                    //outputString.WriteLine(Program.computers.Condition);
                    
                    //close file
                    outputString.Close();

                    //dispose of the memory
                    outputString.Dispose();
                }
                MessageBox.Show("File Saved", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            Program.aboutBox.ShowDialog();
        }
    }
}
