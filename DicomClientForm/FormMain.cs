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
        private Bitmap bmp;
        private readonly DirectoryInfo di;
        private readonly List<FileInfo> files;
        public FormMain()
        {
            InitializeComponent();

            string dir = ConfigurationManager.AppSettings["DicomDir"];
            di = new DirectoryInfo(dir);
            files = di.GetFiles("*.dcm").ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pic = ConfigurationManager.AppSettings["PicPath"];
            bmp = new Bitmap(pic);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DicomFile df = new DicomFile(files[0].FullName);
            df.Load();

            var a = df.DataSet.Count;
            var b = df.DataSet.DumpString;
            Console.WriteLine(b);

            foreach (var item in df.DataSet)
            {
                string desc = item.DicomTagDescription;
                string value = item.GetString(0, string.Empty);
                Console.WriteLine($"Desc: {desc}\t\t{value}");

                Console.WriteLine(item.Tag.Name); 
            }

        }

        private void BtnCreateDicom_Click(object sender, EventArgs e)
        {
            //DicomFile df = new DicomFile(files[0].FullName);

            DicomFile df = new DicomFile();

            DicomMessage dm = new DicomMessage(df);

        }
    }
}
