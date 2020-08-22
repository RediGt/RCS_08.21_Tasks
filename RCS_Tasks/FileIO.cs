using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCS_Tasks
{
    class FileIO
    {
        public static List<string> Read(string fileName)
        {
            string readLine;
            List<string> listOfStrings = new List<string>();

            try
            {
                StreamReader reader = new StreamReader(fileName);

                readLine = reader.ReadLine();

                while (readLine != null)
                {
                    listOfStrings.Add(readLine);
                    readLine = reader.ReadLine();
                }
                reader.Close();
                return listOfStrings;
            }
            catch
            {
                MessageBox.Show("Neizdevas atvert failu!");
                return null;
            }
        }

        public static void Write(List<string> listOfStrings, string fileName, bool adding)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName, false);
                foreach (var str in listOfStrings)               
                    sw.WriteLine(str);

                sw.Close();
                if (!adding)
                    MessageBox.Show("Saved successfully");
            }
            catch
            {
                MessageBox.Show("Neizdevas ierakstit faila!");
            }
        }
    }
}
