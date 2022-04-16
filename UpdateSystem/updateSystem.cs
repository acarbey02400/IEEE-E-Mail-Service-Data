using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using AutoUpdaterDotNET;

namespace UpdateSystem
{
    public partial class updateSystem : Form
    {
        
        public updateSystem()
        {
            InitializeComponent();
            string server = "https://acaribrahim.tr.ht/";
            string updateNotesDownload = "https://acaribrahim.tr.ht/updateNotes.txt";
            string fileMap = @"./";
            TextReader text = new StreamReader(@".\updateInfo.txt");//Burası ".\updateInfo.txt olacak"
            string document = text.ReadToEnd();
            string[] info = document.Split(Environment.NewLine);
            string path = info[0];
            string fileName = "";
            string pid = info[2];
            Process.GetProcessById(Convert.ToInt32(pid)).Kill();
            string[] controlMessage;

            using (WebClient client = new WebClient())
            {
                controlMessage = client.DownloadString(updateNotesDownload).Split(Environment.NewLine);

                for (int i = 1; i < controlMessage.Length; i++)
                {
                    fileName = controlMessage[i];
                    fileMap += fileName;
                    System.IO.File.Delete(path + fileName);
                    Uri fileDownload = new Uri(server + fileName);

                    client.DownloadFile(fileDownload, fileMap);

                    fileMap = @"./";
                    //System.IO.File.Move(path + "//"+fileName, path + "//" + fileName);
                }

                updateLabel();
            }

            MessageBox.Show("Güncelleme işlemi tamamlandı. Lütfen programı yeniden başlatınız...");
            
        }

        private void updateLabel()
        {
            string path = @".\updateLabel.txt";
            string updateLabel = "";
            using (WebClient client = new WebClient())
            {
                updateLabel = client.DownloadString("https://acaribrahim.tr.ht/control.txt");
            }
            System.IO.File.Delete(path);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Close();
            }
           System.IO.File.AppendAllText(path, updateLabel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
           
        }
      
        private void updateSystem_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
