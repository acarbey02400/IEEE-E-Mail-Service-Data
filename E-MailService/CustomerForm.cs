using Business.Concrete;
using Business.Constants;
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
    public partial class CustomerForm : Form
    {
        CustomerManger _customerManager;
        LogManager _logManager;
        int _userId;
        public CustomerForm(int userId)
        {
            InitializeComponent();
            CustomerManger manager = new CustomerManger( new CustomerDal());
            LogManager logManager = new LogManager(new LogDal());
            _customerManager = manager;
            _userId = userId;
            _logManager = logManager;
            dataListed();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex==0)
            {
                customerAdded();
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 1, description = companyName.Text, userId = _userId });
            }
            else if(comboBox2.SelectedIndex==1)
            {
                customerUpdate();
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 3, description = companyName.Text, userId = _userId });
            }
            else if(comboBox2.SelectedIndex==2)
            {
                customerDeleted();
                _logManager.add(new Log { logTime = DateTime.Now, typeId = 2, description = companyName.Text, userId = _userId });
            }
            else
            {
                MessageBox.Show(Messages.nullError);
            }
        }

        private void customerUpdate()
        {
          var result=  _customerManager.update(new Customer
            {
                address = address.Text,
                companyName = companyName.Text,
                phoneNumber = phoneNumber.Text,
                categoryId = category.SelectedIndex + 1,
                cityId = city.SelectedIndex + 1,
                eMail =eMail.Text,
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value)
            });
            dataListed();
            MessageBox.Show(result.Message);
        }

        private void customerAdded()
        {
            var result = _customerManager.add(new Customer
            {
                address = address.Text,
                companyName = companyName.Text,
                phoneNumber = phoneNumber.Text,
                categoryId = category.SelectedIndex + 1,
                cityId = city.SelectedIndex + 1,
                eMail = eMail.Text
            });
            MessageBox.Show(result.Message);
            dataListed();
        }

        private void dataListed()
        {
            var result = _customerManager.getCustomerDetail();
            dataGridView1.DataSource = result.Data;
           
        }

        private void customerDeleted()
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            var result = _customerManager.getById(id);
            var resultDelete = _customerManager.delete(result.Data);
            MessageBox.Show(resultDelete.Message);
            dataListed();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            var result = _customerManager.getById(id);
            address.Text = result.Data.address;
            companyName.Text = result.Data.companyName;
            phoneNumber.Text = result.Data.phoneNumber;
            eMail.Text = result.Data.eMail;
            category.SelectedIndex = result.Data.categoryId-1;
            city.SelectedIndex = result.Data.cityId - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex==2)
            {
                category.Enabled = false;
                city.Enabled = false;
                address.Enabled = false;
                companyName.Enabled = false;
                phoneNumber.Enabled = false;
                eMail.Enabled = false;
            }
            else
            {
                category.Enabled = true;
                city.Enabled = true;
                address.Enabled = true;
                companyName.Enabled = true;
                phoneNumber.Enabled = true;
                eMail.Enabled = true;
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
