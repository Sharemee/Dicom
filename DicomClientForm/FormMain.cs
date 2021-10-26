using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClearCanvas.Dicom;

namespace DicomClientForm
{
    public partial class FormMain : Form
    {
        private readonly DirectoryInfo di;
        public FormMain()
        {
            InitializeComponent();

            string dir = ConfigurationManager.AppSettings["DicomDir"];
            di = new DirectoryInfo(dir);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var files = di.GetFiles("*.dcm");

            DicomFile df = new DicomFile(files[0].FullName);

            df.Load();

            var a = df.DataSet.Count;
            var b = df.DataSet.DumpString;
            Console.WriteLine(b);

            foreach (var item in df.DataSet)
            {
                string desc = item.DicomTagDescription;
                string value = item.GetString(0, string.Empty);
                Console.WriteLine($"Desc: {desc}\t\t\t{value}");

                Console.WriteLine(item.Tag.Name); 
            }
        }
    }
}
