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
    public partial class TestingDoubleClick : Form
    {
        private ContactUc _contact;
        public TestingDoubleClick()
        {
            InitializeComponent();
            Loading();
        }
        private void Loading()
        {
            var resignControl = new ContactUc();
            _contact = resignControl;
            tabPage1.Controls.Add(resignControl);
            resignControl.Dock = DockStyle.Fill;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = "E";
            _contact.GetContact();
        }
    }
}
