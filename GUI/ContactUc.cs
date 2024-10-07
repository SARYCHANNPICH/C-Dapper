using DATAACCESS.IService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepDapper.GUI
{
    public partial class ContactUc : UserControl
    {


        public ContactUc()
        {
            InitializeComponent();
            GetContact();
        }
        public async void GetContact()
        {
            var service = Program.ServiceProvider.GetRequiredService<IContactService>();
            dataGridView1.DataSource = await service.GetContactsAsync();
        }
    }
}
