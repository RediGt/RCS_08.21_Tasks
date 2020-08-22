using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCS_Tasks
{
    public partial class Form1 : Form
    {
        string saveFilePath;
        bool savedOnAdding = false;
        List<string> listOfStrings = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tBoxInput.Text == "")
                return;
            listView1.Items.Add(tBoxInput.Text);
            listOfStrings.Add(tBoxInput.Text);
            tBoxInput.Text = "";
            savedOnAdding = true;
            SaveToFile();
        }

        private void SaveToFile()
        {
            if (saveFilePath != null)
            {
                FileIO.Write(listOfStrings, saveFilePath, savedOnAdding);
                savedOnAdding = false;
            }
                
            else
                SaveAsToFile();
        }

        private void SaveAsToFile()
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFD.RestoreDirectory = true;

            if (saveFD.ShowDialog() == DialogResult.OK)
            {              
                FileIO.Write(listOfStrings, saveFD.FileName, savedOnAdding);
                saveFilePath = saveFD.FileName;
                savedOnAdding = false;
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Filter = "Text Files|*.txt|All Files|*.*";
            if (openFD.ShowDialog() != DialogResult.OK)
                return;

            listOfStrings = FileIO.Read(openFD.FileName);

            if (listOfStrings == null)
                return;

            listView1.Clear();
            foreach (var str in listOfStrings)
                listView1.Items.Add(str);

            saveFilePath = openFD.FileName;
            //lastSaved = tBoxMain.Text;
        }
    }
}
