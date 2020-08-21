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
        public static StringBuilder Read(string fileName)
        {
            string readLine;
            StringBuilder sb = new StringBuilder();

            try
            {
                StreamReader reader = new StreamReader(fileName);

                readLine = reader.ReadLine();

                while (readLine != null)
                {
                    sb.Append(readLine);
                    sb.AppendLine();
                    readLine = reader.ReadLine();
                }
                reader.Close();
                return sb;
            }
            catch
            {
                MessageBox.Show("Neizdevas atvert failu!");
                return null;
            }
        }

        public static void Write(StringBuilder sb, string fileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileName, false);
                sw.WriteLine(sb.ToString());
                sw.Close();
                MessageBox.Show("Saved successfully");
            }
            catch
            {
                MessageBox.Show("Neizdevas ierakstit faila!");
            }
        }
    }
}
