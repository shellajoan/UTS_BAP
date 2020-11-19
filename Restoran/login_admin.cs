using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class login_admin : Form
    {
        public login_admin()
        {
            InitializeComponent();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            using (var ctx = new db_dataEntities())
            {
                var username = this.txtusername.Text;
                var password = this.txtpassword.Text;

                var getUser = ctx.tbl_user.Where(o => o.username == username && o.password == password).FirstOrDefault();

                if(getUser != null)
                {
                    ObjectCache cache = MemoryCache.Default;
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();                  
                    cache.Add("userLogin", getUser,cacheItemPolicy);
                   
                    this.Hide();

                    menu_admin frm2 = new menu_admin();
                    frm2.Show();
            
                }
                else
                {
                    MessageBox.Show("please check username and password");
                    this.txtusername.Text = "";
                    this.txtpassword.Text = "";
                }
            }
           

        }

        private void btn_kembali_Click(object sender, EventArgs e)
        {

            this.Hide();

            MenuUtama frm2 = new MenuUtama();
            frm2.Show();

        }

        private void login_admin_Load(object sender, EventArgs e)
        {

        }
    }
}
