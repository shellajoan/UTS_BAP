using Microsoft.Reporting.WinForms;
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

namespace Restoran
{
    public partial class menu_billing : Form
    {
        public int ID;
        public menu_billing()
        {
            InitializeComponent();
        }

        private void menu_billing_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            LoadReport();
        }

       public void LoadReport()
        {
            ReportDataSource rptDS;
            this.reportViewer1.RefreshReport();
            try
            {

                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\Report_Billing.rdlc";


                var ds = new DataSet_Billing();
                var da = new SqlDataAdapter();



                using (var ctx = new db_dataEntities())
                {
                    var getOrder = ctx.tbl_order.Where(o => o.id == ID).FirstOrDefault();

                    DataRow row;
                    var status = "";
                    if (getOrder.status == 0)
                    {
                        status = "Belum Bayar";
                    }else if(getOrder.status == 1)
                    {
                        status = "Sudah Bayar";
                    }

                    var getDetailOrder = ctx.tbl_detail_order.Where(o => o.id_order == getOrder.id).ToList();

                    foreach(var detailOrder in getDetailOrder)
                    {
                        var menu = ctx.tbl_menu.Where(o => o.id == detailOrder.id_menu).FirstOrDefault();
                        row = ds.Tables["DataTableBilling"].NewRow();
                        
                        row[0] = getOrder.id.ToString();
                        row[1] = getOrder.no_meja.ToString();
                        row[2] = menu.nama_menu.ToString();
                        row[3] = detailOrder.qty.ToString();
                        row[4] = menu.harga_satuan.ToString();
                        row[5] = detailOrder.harga_total.ToString();
                        row[6] = getOrder.subtotal.ToString();
                        row[7] = getOrder.total_bayar.ToString();
                        row[8] = getOrder.kembali.ToString();
                        row[9] = status.ToString();


                        ds.Tables["DataTableBilling"].Rows.Add(row);
                    }
                   

                }

 


                rptDS = new ReportDataSource("DataTableBilling", ds.Tables["DataTableBilling"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex ){
                //MsgBox(ex.Message)
            }
            
            
        }
    }
}
