using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class menu_pembayaran : Form
    {
        public int ID;
        public menu_pembayaran()
        {
            InitializeComponent();
        }
        public void initial()
        {
            ID = 0;
            no_meja_txt.Text = "";
            subtotal_txt.Text = "0";
            total_bayar_txt.Text = "0";
            kembali_txt.Text = "0";
            btn_bayar.Enabled = false;
            btn_biling.Enabled = false;
            MappingToDataGrid();
        }
        public void MappingToDataGrid()
        {
            dataGridView1.ClearSelection();
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("No Meja", typeof(string));
            table.Columns.Add("SubTotal", typeof(decimal));
            table.Columns.Add("Status", typeof(string));
   

            var getOrder = GetListOrder();

            foreach (var order in getOrder)
            {
                var status = "";
                if (order.status.Value == 0)
                {
                    status = "Belum Bayar";
                }
                else if (order.status.Value == 1)
                {
                    status = "Sudah Bayar";
                }
                table.Rows.Add(order.id,order.no_meja,order.subtotal,status);
            }

            dataGridView1.DataSource = table;
        }
        public List<tbl_order> GetListOrder()
        {
            using (var ctx = new db_dataEntities())
            {
                var getMenu = ctx.tbl_order.Where(o => o.is_active == 1).ToList();
                return getMenu;
            }
        }
        private void menu_pembayaran_Load(object sender, EventArgs e)
        {
            initial();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
            {

                var id = int.Parse(row.Cells[0].Value.ToString());
                using (var ctx = new db_dataEntities())
                {
                    
                    var order = ctx.tbl_order.Where(o => o.id == id).FirstOrDefault();
                    this.no_meja_txt.Text = order.no_meja;
                    this.subtotal_txt.Text = order.subtotal.ToString();
                    this.total_bayar_txt.Text = order.total_bayar.ToString();
                    this.kembali_txt.Text = order.kembali.ToString();
                    if(order.status == 0)
                    {
                        btn_bayar.Enabled = true;
                        btn_biling.Enabled = false;
                    }else if(order.status == 1)
                    {
                        btn_bayar.Enabled = false;
                        btn_biling.Enabled = true;
                    }
                    ID = id;
                }
              
         
            }
        }

        private void btn_bayar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                using (var ctx = new db_dataEntities())
                {
                    ObjectCache cache = MemoryCache.Default;
                    dynamic user = cache.Get("userLogin");

                    var order = ctx.tbl_order.Where(o => o.id == ID).FirstOrDefault();
                    order.total_bayar = decimal.Parse(total_bayar_txt.Text);
                    order.kembali = decimal.Parse(kembali_txt.Text);
                    order.status = 1;
                    order.updated_by = user.username;
                    order.updated_date = DateTime.Now;


                    var date = order.updated_date.Value.ToString("yyyy-M-dd hh:mm:ss");
                    var query = "UPDATE tbl_order " +
                       " SET " +
                       " updated_by = '" + order.updated_by + "'," +
                       " updated_date = CAST('" + date + "' AS DATETIME2)," +
                       " total_bayar = " + order.total_bayar + "," +
                       " kembali = " + order.kembali + "," +
                       " status = " + order.status +
                       " WHERE id = " + order.id;

                    ctx.Database.ExecuteSqlCommand(query);

                    //ctx.tbl_order.AddOrUpdate(order);
                    //ctx.SaveChanges();

                    MessageBox.Show("Pembayaran Selesai");

                    //ID = 0;
                    btn_bayar.Enabled = false;
                    btn_biling.Enabled = true;

                    MappingToDataGrid();
                }
            }
        }

        private void total_bayar_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.total_bayar_txt.Text != "" && this.total_bayar_txt.Text != "0")
            {
                var kembali = decimal.Parse(this.total_bayar_txt.Text) - decimal.Parse(this.subtotal_txt.Text);
                this.kembali_txt.Text = kembali.ToString();
            }
            else
            {
                this.kembali_txt.Text = "";
            }
        }

        private void btn_kembali_Click(object sender, EventArgs e)
        {

            this.Hide();

            menu_admin frm2 = new menu_admin();
            frm2.Show();
        }

        private void btn_biling_Click(object sender, EventArgs e)
        {
            menu_billing frm2 = new menu_billing();
            frm2.ID = ID;
            frm2.Show();
        }
    }
}
