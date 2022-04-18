using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.EmailService.Abstract;
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
    public partial class Form1 : Form
    {
        Form _form;
        int _userId;
        IUserService _userService;
        ICustomerService _customerService;
        IEmailService _emailService;
        public Form1(bool adminValid,Form form,int userId, IUserService userService, ICustomerService customerService, IEmailService emailService)
        {
            InitializeComponent();
            if (!adminValid)
            {
                button1.Hide();
            }
            _form = form;
            _userId = userId;
            _customerService = customerService;
            _emailService = emailService;
            _userService = userService;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        public void button1_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm(_userId,_userService);
           
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm(_userId,_customerService);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MailForm form = new MailForm(_userId,_emailService,_customerService);
            
                form.Show();
            
           
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            _form.Close();
            
        }
    }
}
