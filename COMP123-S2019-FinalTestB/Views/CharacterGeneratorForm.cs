using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
                        Program.character.FirstName = inputStream.ReadLine();
                        Program.character.LastName = inputStream.ReadLine();
                        CharacterNameTextBox.Text = Program.character.FirstName + " " + Program.character.LastName;
                        Program.character.Strength = inputStream.ReadLine();
                        Program.character.Dexterity = inputStream.ReadLine();
                        Program.character.Constitution = inputStream.ReadLine();
                        Program.character.Intelligence = inputStream.ReadLine();
                        Program.character.Wisdom = inputStream.ReadLine();
                        Program.character.Charisma = inputStream.ReadLine();
                        
                        inputStream.Close();
                        inputStream.Dispose();

                        MainTabControl_SelectedIndexChanged(sender, e);
                        
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
            GenerateNames();
        }

        private void LoadNames()
        {
            // load the list of first names 

            
             using (StreamReader inputStream = new StreamReader(
               File.Open("..\\..\\Data\\firstNames.txt", FileMode.Open)))
            {
                //read file
                string[] firstNames = inputStream.ReadToEnd().Split();
                Program.character.FirstNameList = firstNames.ToList();

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
               File.Open("..\\..\\Data\\lastNames.txt", FileMode.Open)))
            {
                //read file
                string[] lastNames = inputStream.ReadToEnd().Split();
                Program.character.LastNameList = lastNames.ToList();

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
        /// This method loads the inventory file 
        /// </summary>
        private void LoadInventory()
        {
            // load the list of items

            using (StreamReader inputStream = new StreamReader(
              File.Open("..\\..\\Data\\inventory.txt", FileMode.Open)))
            {
                //read file
                string [] inventory = inputStream.ReadToEnd().Split();
                Program.character.Inventory = inventory.ToList();

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
                    outputString.WriteLine(Program.character.FirstName);
                    outputString.WriteLine(Program.character.LastName);
                    outputString.WriteLine(Program.character.Strength);
                    outputString.WriteLine(Program.character.Dexterity);
                    outputString.WriteLine(Program.character.Constitution);
                    outputString.WriteLine(Program.character.Intelligence);
                    outputString.WriteLine(Program.character.Wisdom);
                    outputString.WriteLine(Program.character.Charisma);

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
        /// <summary>
        /// Event handler for loading the Character Generator Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            LoadInventory();
        }
        private void GenerateNames()
        {
            Random rnd = new Random();
            int indFirst = rnd.Next(0, Program.character.FirstNameList.Count);
            FirstNameDataLabel.Text = Program.character.FirstNameList[indFirst];
            int indLast = rnd.Next(0, Program.character.LastNameList.Count);
            LastNameDataLabel.Text = Program.character.LastNameList[indLast];
            CharacterNameTextBox.Text = FirstNameDataLabel.Text + " " + LastNameDataLabel.Text;
        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Program.character.Strength = rnd.Next(3, 18).ToString();
            Program.character.Dexterity = rnd.Next(3, 18).ToString();
            Program.character.Constitution = rnd.Next(3, 18).ToString();
            Program.character.Intelligence = rnd.Next(3, 18).ToString();
            Program.character.Wisdom = rnd.Next(3, 18).ToString();
            Program.character.Charisma = rnd.Next(3, 18).ToString();
            StrengthDataLabel.Text = Program.character.Strength;
            DexterityDataLabel.Text = Program.character.Dexterity;
            ConstitutionDataLabel.Text = Program.character.Constitution;
            IntelligenceDataLabel.Text = Program.character.Intelligence;
            WisdomDataLabel.Text = Program.character.Wisdom;
            CharismaDataLabel.Text = Program.character.Charisma;
        }

        private void GenerateInventoryButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int indItem = rnd.Next(0, Program.character.Inventory.Count);
            InventoryItemDataLabel1.Text = Program.character.Inventory[indItem];
            indItem = rnd.Next(0, Program.character.Inventory.Count);
            InventoryItemDataLabel2.Text = Program.character.Inventory[indItem];
            indItem = rnd.Next(0, Program.character.Inventory.Count);
            InventoryItemDataLabel3.Text = Program.character.Inventory[indItem];
            indItem = rnd.Next(0, Program.character.Inventory.Count);
            InventoryItemDataLabel4.Text = Program.character.Inventory[indItem];
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 3)
            {
                HeroNameDataLabel.Text = CharacterNameTextBox.Text;
                StrSheetDataLabel.Text = Program.character.Strength;
                DexSheetDataLabel.Text = Program.character.Dexterity;
                ConsSheetDataLabel.Text = Program.character.Constitution;
                IntSheetDataLabel.Text = Program.character.Intelligence;
                WisSheetDataLabel.Text = Program.character.Wisdom;
                ChaSheetDataLabel.Text = Program.character.Charisma;
                Item1SheetDataLabel.Text = InventoryItemDataLabel1.Text;
                Item2SheetDataLabel.Text = InventoryItemDataLabel2.Text;
                Item3SheetDataLabel.Text = InventoryItemDataLabel3.Text;
                Item4SheetDataLabel.Text = InventoryItemDataLabel4.Text;
            }
        }
    }
   
}
