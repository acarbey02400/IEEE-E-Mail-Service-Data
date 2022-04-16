using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Update.Concrete;

namespace E_MailService
{
    public partial class LogIn : Form
    {

        //UserManager _userManager;
        LogManager _logManager;
        Autofac.IContainer _container;
        IUserService _userService;
        public LogIn(Autofac.IContainer container)
        {
            InitializeComponent();
            //UserManager userManager = new UserManager(new UserDal()); //Burada program çalışırken işlem yapacağımız manager'ı çağırarak programın daha hızlı çalışmasını sağlıyoruz
            LogManager logManager = new LogManager(new LogDal());
           // _userManager = userManager;
            _logManager = logManager;
            _container = container;
            _userService = _container.Resolve<IUserService>();
            using (TextReader text = new StreamReader(@".\updateLabel.txt")) //Güncelleme işlemini kontrol etmek için label'i önce en son güncellemeden gelen label değeri ile değiştiriyoruz
            {
                updateLabel.Text = text.ReadToEnd();
                
            }       
            WebClientUpdateSystem updateSystem = new WebClientUpdateSystem();
            var _result = updateSystem.updateControl(updateLabel.Text); //Güncellememizin olup olmadığını kontrol etmek için fonksiyonumuzu çağırıyoruz
            if (_result.Success)
            {
                DialogResult result = MessageBox.Show("Yeni Güncelleme Tespit edildi. Yüklemek için Evet'e basın", "Uyarı!",
            MessageBoxButtons.YesNo);

                //Burada programımızın başlangıç noktası ismi ve process id gibi özelliklerini gönderiyoruz. Böylece update programımız çalışırken bu bilgileri alıp gerekli işlemleri yapabilecek
                if (result == DialogResult.Yes)
                {
                    string path = Application.StartupPath;
                    string fileName = Path.GetFileName(Application.ExecutablePath);
                    string pid = Process.GetCurrentProcess().Id.ToString();
                    updateSystem.update(path, fileName, pid);
                    Process.Start(@".\UpdateSystem\UpdateSystem.exe");
                }
                
            }
            MessageBox.Show(_userService.GetHashCode().ToString());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
   
            var result= _userService.validation(userName.Text,password.Text,comboBox1.SelectedIndex); //Girilen kullanıcı adı ve şifreyi kontrol eden fonksiyonu çağırıyoruz
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                _logManager.add(new Log { typeId = 4, logTime = DateTime.Now, description = "username: " + userName.Text + " \n " + "password: " + password.Text});
                return;
            }    
            //Burada admin veya employee kullanıcısına göre forma true false değerlerini gönderiyoruz.
           else if (comboBox1.SelectedIndex==0) 
           {
                    Form1 form1 = new Form1(true,this,result.Data.id,_container);
                    this.Hide();
                    form1.Show();
                MessageBox.Show(result.Message);
            }
                
            else
            {
                this.Hide();
                MessageBox.Show(result.Message);
                Form1 form2 = new Form1(false, this,result.Data.id,_container);
                form2.Show();
            }
            _logManager.add(new Log { userId = result.Data.id, logTime = DateTime.Now, typeId = 5, description = userName.Text });
               
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        //Şifreyi gizlemek için kullandığımız fonksiyon
        private void password_TextChanged(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
        } 
    }
}
