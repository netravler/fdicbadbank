using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
//
using System.Net;

namespace FDIC_Bad_Banks
{
    public partial class Form1 : Form
    {
        int[] failYearCount;
        StringCollection failYearName = new StringCollection();

        public Form1()
        {
            InitializeComponent();

            //try
            //{
                WebClient clientTXT = new WebClient();
                var holdstufffromcsv = clientTXT.DownloadString(@textBox1.Text);
                richTextBox1.Text += holdstufffromcsv + "\n";

                // copy contents of rtb into string array to process.
                string s;
                string[] lines = richTextBox1.Lines;

                foreach (string lineCheck in lines)
                {
                    if (lineCheck.Length > 0)
                    {
                        listBox1.Items.Add(lineCheck.Substring(lineCheck.Length - 2));
                    }
                }
            //}
            //catch
            //{
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void exportAsCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // filepicker dialog will appear.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // build defaults
            saveFileDialog1.FileName = "FDICassumed.csv";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // enter open here!!!
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))

                    // write out richtextbox1 to file!!!
                    foreach (string line in richTextBox1.Lines)
                    {
                        sw.WriteLine(line);
                    }
            }
        }
    }
}
