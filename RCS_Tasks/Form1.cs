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

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tBoxInput.Text == "")
                return;
            listView1.Items.Add(tBoxInput.Text);
            tBoxInput.Text = "";
            SaveAsToFile();
        }

        private void SaveAsToFile()
        {
            SaveFileDialog saveFD = new SaveFileDialog();
            saveFD.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFD.RestoreDirectory = true;

            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                if (listView1.Items.Count > 0)
                {
                    // the actual data
                    foreach (ListViewItem item in listView1.Items)
                    {
                        sb = new StringBuilder();

                        foreach (ListViewItem.ListViewSubItem listViewSubItem in item.SubItems)
                        {
                            sb.Append(string.Format("{0}\t", listViewSubItem.Text));
                        }
                    }
                }
                FileIO.Write(sb, saveFD.FileName);
            }
        }
    }
}
