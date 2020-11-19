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
    public partial class menu_admin : Form
    {
       
        public menu_admin()
        {
            InitializeComponent();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {

            this.Hide();

            kelola_menu frm2 = new kelola_menu();
            frm2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove("userLogin");

            this.Hide();

            login_admin frm2 = new login_admin();
            frm2.Show();

        }

        private void menu_admin_Load(object sender, EventArgs e)
        {

        }

        private void btn_pembayaran_Click(object sender, EventArgs e)
        {
            this.Hide();

            menu_pembayaran frm2 = new menu_pembayaran();
            frm2.Show();
        }

        private void btn_laporan_Click(object sender, EventArgs e)
        {
            this.Hide();

            menu_laporan frm2 = new menu_laporan();
            frm2.Show();
        }
    }
}
