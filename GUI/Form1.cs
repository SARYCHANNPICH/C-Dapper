using DATAACCESS.IService;
using DATAACCESS.Model;
using DATAACCESS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepDapper
{
    public partial class Form1 : Form
    {
        private readonly IContactService contact;
        private readonly IAgentService _agent;
        private readonly IEmailService email;
        private readonly IOrderService order;
        private readonly ISIDBINFOService service;

        public Form1(IContactService contact, IAgentService agent, IEmailService email, IOrderService order, ISIDBINFOService service)
        {
            this.contact = contact;
            _agent = agent;
            this.email = email;
            this.order = order;
            this.service = service;
            InitializeComponent();
        }
        private async void LoadData()
        {
            dgvContacts.DataSource = await contact.GetContactsAsync();
        }
        private async void GetBranch()
        {
            try
            {
                comboBox1.DataSource = await service.GetSIDBINFO();
                comboBox1.DisplayMember = "DB_NAME";
                comboBox1.ValueMember = "Db_Code";
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch
            {

            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = 0;
            loadingOrder();
            //GetBranch();

        }
        private async void loadingOrder()
        {
            dgvContacts.DataSource = await order.GetAllOrders();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void GetButtonText(Action<Button> Button)
        {

        }
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            MessageBox.Show(btn.ToString());

            //string FirstName = txtFirstName.Text.Trim();
            //ContactModel model = new ContactModel();
            //model.FirstName  = txtFirstName.Text;
            //model.LastName  = txtLastName.Text;
            //var exist = await contact.ExistCityzenByNameAsyncTask(FirstName);
            //if (exist)
            //{
            //    MessageBox.Show($"{FirstName } មានរួចហើយ!");
            //    return;
            //}
            
            //var affectedRow = await contact.CreateContactAsync(model);
            //if(affectedRow > 0)
            //{
            //    txtFirstName.Clear();
            //    txtLastName.Clear();
            //    LoadData();
            //    txtFirstName.Focus();
            //}
            //else
            //{
            //    MessageBox.Show($"ការបញ្ចូលបរាជ័យ");
            //}
            //var con =  new SqlConnection("");
           
           
           
          
        }

        private async void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        private void loading(string text)
        {
           
            MessageBox.Show(text.ToString());
        }
        private  async void txtId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvContacts.DataSource = await order.GetSingleOrder(txtId.Text);
            }
            catch
            {

            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            int MaxId =await contact.GetMaxCode();
            MessageBox.Show(MaxId.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            string text = comboBox1.SelectedValue.ToString();
            label1.Text = text;
            loading(text);
            //loading(text);
        }
    }
}
