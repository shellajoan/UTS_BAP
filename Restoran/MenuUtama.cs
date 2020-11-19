using Restoran.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class MenuUtama : Form
    {
        public MenuUtama()
        {
            InitializeComponent();
        }
        public List<int?> idHapus;
        public List<Order> listOrder;
        public int jenis;
        public int pageNow;
        public string terlarisFilter;

        public void Initial()
        {
            idHapus = new List<int?>();
            listOrder = new List<Order>();
            terlarisFilter = "";
            MappingToDataGrid();
            MenuMapping(1, terlarisFilter, 0, 3);
            jenis = 1;
            pageNow = 0;
        }
        private void btn_menu_admin_Click(object sender, EventArgs e)
        {
           
            this.Hide();

            login_admin frm2 = new login_admin();
            frm2.Show();

           
        }
        public void MappingToDataGrid()
        {
      
            dataGridView1.ClearSelection();
            DataTable table = new DataTable();
            table.Columns.Add("No Meja", typeof(string));
            table.Columns.Add("Nama Menu", typeof(string));
            //table.Columns.Add("Jenis", typeof(string));
            table.Columns.Add("Harga Satuan", typeof(decimal));
            table.Columns.Add("Harga Total", typeof(decimal));
            table.Columns.Add("Qty", typeof(string));

          
            foreach (var menu in listOrder)
            {             
                table.Rows.Add(menu.no_meja, menu.nama_menu, menu.harga_satuan,
                    menu.harga_total, menu.qty);
            }

            dataGridView1.DataSource = table;
        }
        public void MenuMapping(int jenis, string terlaris , int page = 0,int size = 3)
        {
            var menus = GetMenu(jenis, page, size);
            var menuTerlaris = GetMenuTerlaris(jenis,terlaris, 0, 3);
            for (int i = 0; i <= 5; i++)
            {
                if (i >= 0 && i <= 2)
                {
                    var imageMenu = this.Controls.Find("pcb_menu" + i.ToString(), true).FirstOrDefault();
                    var namaMenu = this.Controls.Find("lbl_menu" + i.ToString(), true).FirstOrDefault();
                    var hargaMenu = this.Controls.Find("lbl_harga" + i.ToString(), true).FirstOrDefault();
                    var label = this.Controls.Find("lbl" + i.ToString(), true).FirstOrDefault();
                    var labelPcs = this.Controls.Find("lbl_pcs" + i.ToString(), true).FirstOrDefault();
                    var labelOrder = this.Controls.Find("lbl_order" + i.ToString(), true).FirstOrDefault();
                    var labelQty = this.Controls.Find("lbl_qty" + i.ToString(), true).FirstOrDefault();

                    try
                    {
                        var menu = menuTerlaris[i];
                        if (!string.IsNullOrEmpty(menuTerlaris[i].foto))
                        {
                            imageMenu.BackgroundImage = new Bitmap(menuTerlaris[i].foto);
                        }
                        else
                        {
                            imageMenu.BackgroundImage = null;
                        }
                        namaMenu.Tag = menuTerlaris[i].id.ToString();
                        namaMenu.Text = menuTerlaris[i].nama_menu;
                        hargaMenu.Text = menuTerlaris[i].harga_satuan.ToString();
                        labelQty.Text = "0";

                        imageMenu.Visible = true;
                        namaMenu.Visible = true;
                        hargaMenu.Visible = true;
                        //label.Visible = true;
                        //labelPcs.Visible = true;
                        labelOrder.Visible = true;
                        labelQty.Visible = true;
                    }
                    catch(Exception e)
                    {
                        imageMenu.Visible = false;
                        namaMenu.Visible = false;
                        hargaMenu.Visible = false;
                        //label.Visible = false;
                        //labelPcs.Visible = false;
                        labelOrder.Visible = false;
                        labelQty.Visible = false;
                    }
                                                       

                }

                if (i >= 3 && i <= 5)
                {
                    var imageMenu = this.Controls.Find("pcb_menu" + i.ToString(), true).FirstOrDefault();
                    var namaMenu = this.Controls.Find("lbl_menu" + i.ToString(), true).FirstOrDefault();
                    var hargaMenu = this.Controls.Find("lbl_harga" + i.ToString(), true).FirstOrDefault();
                    var label = this.Controls.Find("lbl" + i.ToString(), true).FirstOrDefault();
                    var labelPcs = this.Controls.Find("lbl_pcs" + i.ToString(), true).FirstOrDefault();
                    var labelOrder = this.Controls.Find("lbl_order" + i.ToString(), true).FirstOrDefault();
                    var labelQty = this.Controls.Find("lbl_qty" + i.ToString(), true).FirstOrDefault();
                   
                    try
                    {
                        var index = 0;
                        if (i == 3)
                        {
                            index = 0;
                        }
                        else if (i == 4)
                        {
                            index = 1;
                        }
                        else if (i == 5)
                        {
                            index = 2;
                        }

                        var menu = menus[index];
                        if (!string.IsNullOrEmpty(menus[index].foto))
                        {
                            try
                            {
                                imageMenu.BackgroundImage = new Bitmap(menus[index].foto);
                            }
                            catch (Exception e)
                            {
                                imageMenu.BackgroundImage = null;
                            }
                           
                        }
                        else
                        {
                            imageMenu.BackgroundImage = null;
                        }
                        namaMenu.Tag = menus[index].id.ToString();
                        namaMenu.Text = menus[index].nama_menu;
                        hargaMenu.Text = menus[index].harga_satuan.ToString();
                        labelQty.Text = "0";

                        imageMenu.Visible = true;
                        namaMenu.Visible = true;
                        hargaMenu.Visible = true;
                        //label.Visible = true;
                        //labelPcs.Visible = true;
                        labelOrder.Visible = true;
                        labelQty.Visible = true;
                    }
                    catch(Exception e)
                    {
                        imageMenu.Visible = false;
                        namaMenu.Visible = false;
                        hargaMenu.Visible = false;
                        //label.Visible = false;
                        //labelPcs.Visible = false;
                        labelOrder.Visible = false;
                        labelQty.Visible = false;
                    }
                                       
                }
                              
            }


            var nextPage = GetCountMenu(jenis, page + 1, size);
            if(nextPage > 0)
            {
                btn_next_page.Visible = true;
            }
            else
            {
                btn_next_page.Visible = false;
            }

            if(page > 0)
            {
                var backPage = GetCountMenu(jenis, page - 1, size);
                if (backPage > 0)
                {
                    btn_back_page.Visible = true;
                }
                else
                {
                    btn_back_page.Visible = false;
                }
            }
            else
            {
                btn_back_page.Visible = false;
            }
            

            
        }
        public List<tbl_menu> GetMenu(int jenis,int page = 0,int size = 3)
        {
            using (var ctx = new db_dataEntities())
            {
                var getMenu = ctx.tbl_menu
                .Where(o => o.jenis == jenis && o.is_active == 1)
                .OrderBy(o => o.nama_menu)
                .Skip(page * size)
                .Take(size)
                .ToList();

                return getMenu;
            }
        }
        public List<tbl_menu> GetMenuTerlaris(int jenis, string terlaris, int page = 0, int size = 3)
        {
            using (var ctx = new db_dataEntities())
            {
                var listMenuWithCount = new List<MenuWithCount>();
                
                var menuIds = ctx.tbl_detail_order.Where(o => o.is_active == 1).Select(o => o.id_menu).Distinct().ToList();
                
                foreach(var menuId in menuIds)
                {
                    var count = 0;
                    if (terlaris == "Minggu Ini")
                    {
                        var date = DateTime.Now.AddDays(-7);
                        count = ctx.tbl_detail_order.Where(o => o.is_active == 1 &&
                        o.created_date >= date && o.created_date <= DateTime.Now && 
                        o.id_menu == menuId).Count();
                    }
                    else if (terlaris == "Bulan Ini")
                    {
                        var date = DateTime.Now.AddMonths(-1);
                        count = ctx.tbl_detail_order.Where(o => o.is_active == 1 &&
                        o.created_date >= date &&
                        o.created_date <= DateTime.Now && o.id_menu == menuId).Count();
                    }
                    else
                    {
                        count = ctx.tbl_detail_order.Where(o => o.is_active == 1 && o.id_menu == menuId).Count();
                    }
                    
                    var menuWCount = new MenuWithCount
                    {
                        IdMenu = menuId.Value,
                        Count = count
                    };

                    listMenuWithCount.Add(menuWCount);
                }
                var idslistMenuWithCount = listMenuWithCount
                     .OrderByDescending(c => c.Count)
                     .Skip(page * size)
                     .Take(size)
                     .Select(c => c.IdMenu);

                var getMenu = ctx.tbl_menu
               .Where(o => o.jenis == jenis && idslistMenuWithCount.Contains(o.id))       
               .ToList();

                return getMenu;

            }
        }
        public int GetCountMenu(int jenis, int page = 0, int size = 3)
        {
            using (var ctx = new db_dataEntities())
            {
                var getMenu = ctx.tbl_menu
                .Where(o => o.jenis == jenis)
                .OrderBy(o => o.nama_menu)
                .Skip(page * size)
                .Take(size)
                .Count();

                return getMenu;
            }
        }

        private void MenuUtama_Load(object sender, EventArgs e)
        {
            Initial();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_makanan_Click(object sender, EventArgs e)
        {
            MenuMapping(1, terlarisFilter, 0, 3);
            jenis = 1;
            pageNow = 1;
        }

        private void btn_minuman_Click(object sender, EventArgs e)
        {
            MenuMapping(2, terlarisFilter, 0, 3);
            jenis = 2;
            pageNow = 1;
        }

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            pageNow = pageNow + 1;
            MenuMapping(jenis, terlarisFilter, pageNow, 3);
        }

        private void btn_back_page_Click(object sender, EventArgs e)
        {
            pageNow = pageNow - 1;
            MenuMapping(jenis, terlarisFilter,pageNow, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var subTotal = listOrder.Sum(o => o.harga_total);
            var idOrder = 0;
            if (listOrder.Count > 0)
            {
                var data = new tbl_order
                {
                    created_by = "user",
                    created_date = DateTime.Now,
                    no_meja = no_meja.Text,
                    subtotal = subTotal,
                    status = 0,
                    is_active = 1
                };

                var date = data.created_date.Value.ToString("yyyy-M-dd hh:mm:ss");

                using (var ctx = new db_dataEntities())
                {
                    var query = "INSERT INTO tbl_order (is_active,created_by,created_date," +
               "no_meja,subtotal,status) " +
               " VALUES (" +
               "" + data.is_active + "," +
               "'" + data.created_by + "'," +
               " CAST('" + date + "' AS DATETIME2)," +
               "'" + data.no_meja + "'," +
               "" + data.subtotal + "," +
               "" + data.status + ")";

                    ctx.Database.ExecuteSqlCommand(query);

                    var id = ctx.tbl_order.OrderByDescending(o => o.id).FirstOrDefault();

                    //var id = ctx.tbl_order.Add(data);
                    //ctx.SaveChanges();
                    idOrder = id.id;
                }


            }

            foreach (var order in listOrder)
            {


                var detailOrder = new tbl_detail_order
                {
                    created_by = "user",
                    created_date = DateTime.Now,
                    id_order = idOrder,
                    id_menu = order.id_menu,
                    qty = order.qty,
                    harga_satuan = order.harga_satuan,
                    harga_total = order.harga_total,
                    is_active = 1
                };

                var date = detailOrder.created_date.Value.ToString("yyyy-M-dd hh:mm:ss");

                using (var ctx = new db_dataEntities())
                {

                    var query = "INSERT INTO tbl_detail_order ([is-active],created_by,created_date," +
               "id_order,id_menu,qty,harga_satuan,harga_total) " +
               " VALUES (" +
               "" + detailOrder.is_active + "," +
               "'" + detailOrder.created_by + "'," +
               " CAST('" + date + "' AS DATETIME2)," +
               "" + detailOrder.id_order + "," +
               "" + detailOrder.id_menu + "," +
                "" + detailOrder.qty + "," +
                 "" + detailOrder.harga_satuan + "," +
               "" + detailOrder.harga_total + ")";

                    ctx.Database.ExecuteSqlCommand(query);

                    //ctx.tbl_detail_order.Add(detailOrder);
                    //ctx.SaveChanges();


                }


            }

            MessageBox.Show("Menu Telah Di Order");

            Initial();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            terlarisFilter = this.comboBox1.SelectedItem.ToString();
            MenuMapping(jenis, this.comboBox1.SelectedItem.ToString(), pageNow, 3);
            
         
        }

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 5; i++)
            {

                    var imageMenu = this.Controls.Find("pcb_menu" + i.ToString(), true).FirstOrDefault();
                    var namaMenu = this.Controls.Find("lbl_menu" + i.ToString(), true).FirstOrDefault();
                    var hargaMenu = this.Controls.Find("lbl_harga" + i.ToString(), true).FirstOrDefault();
                    var label = this.Controls.Find("lbl" + i.ToString(), true).FirstOrDefault();
                    var labelPcs = this.Controls.Find("lbl_pcs" + i.ToString(), true).FirstOrDefault();
                    var labelOrder = this.Controls.Find("lbl_order" + i.ToString(), true).FirstOrDefault();
                    var labelQty = this.Controls.Find("lbl_qty" + i.ToString(), true).Where(o => o.Visible == true).FirstOrDefault();
                
                if(labelQty != null)
                {
                    if (int.Parse(labelQty.Text) > 0)
                    {
                        var idMenu = namaMenu.Tag;
                        var order = new Order
                        {
                            no_meja = no_meja.Text,
                            nama_menu = namaMenu.Text,
                            id_order = 1,
                            id_menu = int.Parse(namaMenu.Tag.ToString()),
                            qty = int.Parse(labelQty.Text),
                            harga_satuan = decimal.Parse(hargaMenu.Text),
                            harga_total = decimal.Parse(hargaMenu.Text) * decimal.Parse(labelQty.Text)
                        };

                        listOrder.Add(order);
                        labelQty.Text = "0";
                    }
                }
                
            }
            MappingToDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idHapus.Clear();
            DataGridViewSelectedRowCollection rowList = dataGridView1.SelectedRows;
            foreach(DataGridViewRow index in rowList)
            {
                DataGridViewRow row = dataGridView1.Rows[index.Index];
                
                if(row.Cells[1].Value != null)
                {
                    if (index.Index >= 0 && !string.IsNullOrEmpty(row.Cells[1].Value.ToString()))
                    {
                        idHapus.Add(index.Index);
                    }
                }
                
            }
           
        }

        private void btn_hapus_Click(object sender, EventArgs e)
        {
            if (idHapus.Count > 0)
            {
                foreach(var idhapuss in idHapus)
                {
                    try
                    {
                        listOrder.RemoveAt(idhapuss.Value);
                    }
                    catch(Exception ex)
                    {
                        //listOrder.RemoveAt(idhapuss.Value);
                    }
                    
                   
                }
                MappingToDataGrid();
            }
            idHapus.Clear();
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

 
    }
}
