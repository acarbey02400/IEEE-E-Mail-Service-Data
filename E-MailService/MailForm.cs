using Business.Abstract;
using Business.Concrete;
using Core.Utilities.EmailService.Abstract;
using Core.Utilities.EmailService.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_MailService
{
    public partial class MailForm : Form
    {
        IEmailService _emailManager;
        ICustomerService _customerManager;
        LogManager _logManager;
        int _userId;
        public MailForm(int userId, IEmailService emailManager, ICustomerService customerService)
        {
            InitializeComponent();


            LogManager logManager = new LogManager(new LogDal());
            _logManager = logManager;
            _userId = userId;

            _customerManager = customerService;
            _emailManager = emailManager;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("lütfen bir şirket seçiniz");
                return;
            }


            if (checkedListBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                checkedListBox1.SetItemChecked(0, false);
            }
            checkedListBox1.SetItemChecked(0, false);


            MailMessageSend();
            //EMailTemplate eMail1 = new EMailTemplate { to = item.ToString(), body = body.Text, subject = subject.Text, file = openFileDialog1.FileName };
            //var result = _emailManager.sendMail(eMail1);//Burada email bilgileri gönderilecek
            //message = message + "\n" + item.ToString() + " " + result.Message;

        }

        private void MailMessageSend()

        {
            string message = "Mail detayı;\n";
            foreach (var item in checkedListBox1.CheckedItems)
            {
                var mailMessage = new MailMessage();
                mailMessage.Subject = subject.Text;
                mailMessage.Body = body.Text;
                mailMessage.To.Add(new MailAddress(item.ToString()));
                
                string file = openFileDialog1.FileName;
                if (file != "openFileDialog1")
                    mailMessage.Attachments.Add(new Attachment(file));
                MimeMessage mimeMessage = MimeMessage.CreateFromMailMessage(mailMessage);
                _emailManager.sendMail(mimeMessage);

                _logManager.add(new Log { logTime = DateTime.Now, typeId = 6, description = item.ToString(), userId = _userId });
                message+=item.ToString()+"\n"+"Mail send.";
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
            if (label4.Text == "")
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
            openFileDialog1.FileName = "";

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
