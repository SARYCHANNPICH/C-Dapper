using DATAACCESS.IService;
using DeepDapper.Extensions;
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

namespace DeepDapper.GUI
{
    public partial class Userfrm : Form
    {
        private readonly IUserService user;

        public Userfrm(IUserService user)
        {
            InitializeComponent();
            this.user = user;
           
        }
        public string Db_Code = "KC7";
        private async void Loading()
        {
           
            dgvUser.DataSource = await user.GetAllUser(Db_Code);
        }

        private void Userfrm_Load(object sender, EventArgs e)
        {
            //label1.Text = EntryFormTitle.Create.GetEnumDescription();
            label1.Text = FormTitleExtensions.GetEnumDescriptions(EntryFormTitle.Edit);
            Loading();
        }

        private async void dgvUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Image Image;
            foreach (DataGridViewRow row in dgvUser.SelectedRows)
            {
                string UserId = row.Cells[0].Value.ToString();
                byte[] ImageData = await user.GetImage(UserId);
                if (ImageData == null)
                {
                    ptbUser.Image = Properties.Resources.NoImage;
                    return;
                }
                using (MemoryStream ms = new MemoryStream(ImageData))
                {
                    Image = Image.FromStream(ms);
                }
                ptbUser.Image = Image;
            }
        }
        private async void searching(string UserName)
        {
            dgvUser.DataSource = await user.GetSingleUser(UserName, Db_Code);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                searching(txtSearch.Text);
            }
            catch
            {

            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Enabled = false;
        }
    }
}
