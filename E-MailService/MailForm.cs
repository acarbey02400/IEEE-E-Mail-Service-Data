using Business.Concrete;
using Core.Utilities.EmailService.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_MailService
{
    public partial class MailForm : Form
    {
        EMailManager _emailManager;
        CustomerManger _customerManager;
        LogManager _logManager;
        int _userId;
        public MailForm(int userId)
        {
            InitializeComponent();
            EMailManager eMail = new EMailManager(new GMailServices());
            CustomerManger manager = new CustomerManger(new CustomerDal());
            LogManager logManager = new LogManager(new LogDal());
            _logManager = logManager;
            _userId = userId;
            _emailManager = eMail;
            _customerManager = manager;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count==0)
            {
                MessageBox.Show("lütfen bir şirket seçiniz");
                return;
            }
            string message = "Mail detayı;\n";

            if (checkedListBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                checkedListBox1.SetItemChecked(0, false);
            }
            checkedListBox1.SetItemChecked(0, false);

            foreach (var item in checkedListBox1.CheckedItems)
            {
                
                EMailTemplate eMail1 = new EMailTemplate { to = item.ToString(), body = body.Text, subject = subject.Text, file = openFileDialog1.FileName };
                var result = _emailManager.SendMail(eMail1);
                message = message + "\n" + item.ToString() + " " + result.Message;
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 6, description = item.ToString(), userId = _userId });
            }
            
            
           
            MessageBox.Show(message);
        }

        private void MailForm_Load(object sender, EventArgs e)
        {
            var result = _customerManager.getAll();

            foreach (var customer in result.Data)
            {
                checkedListBox1.Items.Add(customer.eMail);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label4.Text = openFileDialog1.SafeFileName;
            if (label4.Text=="")
            {
                return;
            }
            label5.Text = "kaldır";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {

            label4.Text = "";
            label5.Text = "";
            openFileDialog1.FileName="";
        
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
    }
}
