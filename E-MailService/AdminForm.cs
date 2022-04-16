using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Business.DependencyResolves.Autofac;
using Core.Entity.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_MailService
{
    public partial class AdminForm : Form
    {
        //UserManager _userManager;
        LogManager _logManager;
        int _userId;
        Autofac.IContainer _container;
        IUserService _userService;
        public AdminForm(int userId, Autofac.IContainer container)
        {
            InitializeComponent();

            //UserManager userManager = new UserManager(new UserDal()); //Burada programımız daha hızlı çalışsın diye çalıştığı anda manager'ımızı çağırıyoruz.
            LogManager logManager = new LogManager(new LogDal());
            //_userManager = userManager;
            _logManager = logManager;
            _userId = userId;
            _container = container;
            _userService = _container.Resolve<IUserService>();
            dataListedUser();
            
        }
        
        //Verileri listeleyeceğimiz fonksiyon
        private void dataListedUser()
        {
            var result = _userService.getUserDetail();
            dataGridView1.DataSource = result.Data;
        }
      
        //Kullanıcı işlemlerinin gerçekleştiği fonksiyon
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex==1) //Eğer yetkili güncelleme işlemini yapmak isterse güncelleme fonksiyonunu çağırıp mevcut fonksiyondan çıkmasını sağlıyoruz.
            {
                userUpdate();
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 3, description = userName.Text, userId=_userId });
                
                return;
            }
            if (comboBox2.SelectedIndex==2) //Silme işlemi için çağırdığımız fonksiyon
            {
                userDelete();
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 2, description = userName.Text, userId = _userId });
                return;
            }
            if (userType.SelectedIndex==0)
            {
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 1, description = userName.Text, userId = _userId });
                adminAdded();
            }
            else if(userType.SelectedIndex==1)
            {
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 1, description = userName.Text, userId = _userId });
                employeAdded();
            }
            else
            {
                MessageBox.Show(Messages.nullError);
            }
            
        }

        //Kullanıcıları silmek için kullandığımız yöntem
        private void userDelete()
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            var result = _userService.getById(id);
            var resultDelete = _userService.delete(result.Data);
            MessageBox.Show(resultDelete.Message);
            dataListedUser();
        }

        //Görevli kişileri eklemek için kullandığımız fonksiyon
        private void employeAdded()
        {
            var result = _userService.add(new User
            {
                eMail = eMail.Text,
                firstName = name.Text,
                password = password.Text,
                lastName = surName.Text,
                userName = userName.Text,
                roleId = 1
            });
            MessageBox.Show(result.Message); //burada işlem sonrası gelen mesajı kullanıcıya gönderiyoruz ve datayı tekrar listeliyoruz.
            dataListedUser();
        }

        //Adminlerin eklemek için kullandığımız fonksiyon
        private void adminAdded()
        {
            var result = _userService.add(new User
            {
                eMail = eMail.Text,
                firstName = name.Text,
                password = password.Text,
                lastName = surName.Text,
                userName = userName.Text,
                roleId = 0
            });
            MessageBox.Show(result.Message);
            dataListedUser();
        }

        //Burada güncelleme butonuna tıklandığında datagrid'deki seçili id üzerinden bilgileri işlem yapacağımız groupbox'a yönlendiriyor.
        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            var result = _userService.getById(id);
            eMail.Text = result.Data.eMail;
            name.Text = result.Data.firstName;
            password.Text = result.Data.password;
            surName.Text  = result.Data.lastName;
            userName.Text = result.Data.userName;
            comboBox2.SelectedIndex = 2;
        }

        //Gelen kullanıcıyı güncellemek için kullandığımız fonksiyon
        private void userUpdate()
        {
           var result = _userService.update(new User
            {
                eMail = eMail.Text,
                firstName = name.Text,
                password = password.Text,
                lastName = surName.Text,
                userName = userName.Text,
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value),
                roleId = userType.SelectedIndex

            });
            MessageBox.Show(result.Message);
            dataListedUser();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void userType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        //Burada kullanıcı eğer silme işlemini gerçekleştiriliyorsa bir şeyleri değiştirmesine gerek yoktur. Bu yüzden enabled değerlerini false yapıyoruz
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 2)
            {
                userType.Enabled = false;
                name.Enabled = false;
                surName.Enabled = false;
                eMail.Enabled = false;
                password.Enabled = false;
                userName.Enabled = false;
            }
            else
            {
                userType.Enabled = true;
                name.Enabled = true;
                surName.Enabled = true;
                eMail.Enabled = true;
                password.Enabled = true;
                userName.Enabled = true;
            }
        }
    }
}
