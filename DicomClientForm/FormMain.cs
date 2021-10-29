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
            byte[] bytes = new byte[bmp.Width * bmp.Height * 3];
            int n = -1;
            for (int i = 1; i <= bmp.Height; i++)
            {
                for (int j = 1; j <= bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(i, j);
                    bytes[++n] = pixel.R;
                    bytes[++n] = pixel.G;
                    bytes[++n] = pixel.B;
                }
            }

            //DicomFile file = new DicomFile(files[0].FullName);

            DicomFile df = new DicomFile();

            df.MediaStorageSopClassUid = SopClass.DigitalXRayImageStorageForPresentation.Uid;
            df.TransferSyntax = TransferSyntax.ExplicitVrLittleEndian;

            df.DataSet[DicomTags.ImageType].SetStringValue(@"ORIGINAL\PRIMARY");
            df.DataSet[DicomTags.SopClassUid].SetStringValue(SopClass.DigitalXRayImageStorageForPresentation.Uid);
            df.DataSet[DicomTags.Columns].SetInt32(0, bmp.Width);
            df.DataSet[DicomTags.Rows].SetInt32(0, bmp.Height);
            df.DataSet[DicomTags.BitsAllocated].SetInt16(0, 24);//(Rgba*8)(4byte*8=32bit)
            df.DataSet[DicomTags.BitsStored].SetInt16(0, 24);
            df.DataSet[DicomTags.HighBit].SetInt16(0, 23);
            df.DataSet[DicomTags.PixelData].Values = bytes;

            string fileName = DateTime.UtcNow.Timestamp().ToString() + ".dcm";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dicom", fileName);
            df.Save(filePath);
        }
    }
}
