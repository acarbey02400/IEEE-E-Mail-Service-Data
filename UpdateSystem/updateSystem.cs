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
            updateStart();
            
                
                MessageBox.Show("Güncelleme işlemi tamamlandı. Lütfen programı yeniden başlatınız...");
            
            
        }

        private void updateStart()
        {

            string server = "https://acaribrahim.tr.ht/";
            string updateNotesDownload = "";
            string fileMap = @"./";
            TextReader text = new StreamReader(@".\updateInfo.txt");//Burası ".\updateInfo.txt olacak"
            string document = text.ReadToEnd();
            TextReader textReader = new StreamReader(@".\updateLabel.txt");
            string updateLabel = textReader.ReadToEnd();
            
            textReader.Close();
            int updateNumberControl = Convert.ToInt32((updateLabel.Substring(updateLabel.Length - 1))) + 1;

            updateLabel = updateLabel.Substring(0, updateLabel.Length - 1) + updateNumberControl.ToString();
            string[] info = document.Split(Environment.NewLine);
            string path = info[0];
            string fileName = "";
            string pid = info[2];
            server += updateLabel+"/";
            //Process.GetProcessById(Convert.ToInt32(pid)).Kill();
            string[] controlMessage;

            using (WebClient client = new WebClient())
            {
                
                updateNotesDownload = server  + "updateNotes.txt";
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

                UpdateLabel(updateLabel);
                using (WebClient wc = new WebClient())
                {
                    if (!wc.DownloadString("https://acaribrahim.tr.ht/control.txt").Contains(updateLabel))
                    {
                        updateStart();
                    }
                    MessageBox.Show("Güncelleme işlemi tamamlandı, uygulamayı yeniden başlatınız...");
                }
            }

            
        }

        private void UpdateLabel(string updateLabel)
        {
            string path = @".\updateLabel.txt";
            
            
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
