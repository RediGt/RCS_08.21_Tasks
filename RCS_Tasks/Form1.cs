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
        bool textEqualsToFile = true;
        List<string> listOfStrings = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tBoxInput.Text == "")
                return;

            if (IfDuplicate())
                return;

            listView1.Items.Add(tBoxInput.Text);
            listOfStrings.Add(tBoxInput.Text);
            tBoxInput.Text = "";
            savedOnAdding = true;
            SaveToFile();
            tBoxInput.Focus();
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
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            tBoxInput.Text = "";
            saveFilePath = null;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsToFile();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (listOfStrings.Count != listView1.Items.Count)
            
            /*if (!lastSaved.Equals(tBoxMain.Text))
            {
                DialogResult res = MessageBox.Show("Wish to save changes?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                    SaveToFile();
            }*/

            this.Close();
        }

        private bool IfDuplicate()
        {
            bool duplicate = false;
            foreach (var str in listOfStrings)
            {
                if (tBoxInput.Text == str)
                {
                    MessageBox.Show("Duplicate");
                    duplicate = true;
                    break;
                }
            }

            return duplicate;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                index = item.Index;
                listView1.Items.RemoveAt(index);
                listOfStrings.RemoveAt(index);
            }
        }
    }
}
