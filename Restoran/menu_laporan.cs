using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran
{
    public partial class menu_laporan : Form
    {
        public menu_laporan()
        {
            InitializeComponent();
        }

        private void menu_laporan_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void LoadReport(DateTime startDate, DateTime endDate)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(rptds);
            reportViewer1.LocalReport.Refresh();
            ReportDataSource rptDS;
            this.reportViewer1.RefreshReport();
            try
            {

                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Reports\\Report_Laporan.rdlc";


                var ds = new DataSet_Billing();
                var da = new SqlDataAdapter();


                using (var ctx = new db_dataEntities())
                {
                    var listOrder = ctx.tbl_order.Where(o => EntityFunctions.TruncateTime(o.created_date.Value) >= startDate.Date && EntityFunctions.TruncateTime(o.created_date.Value) <= endDate.Date).ToList();

                    foreach(var getOrder in listOrder)
                    {
                        DataRow row;
                        var status = "";
                        if (getOrder.status == 0)
                        {
                            status = "Belum Bayar";
                        }
                        else if (getOrder.status == 1)
                        {
                            status = "Sudah Bayar";
                        }

                        var getDetailOrder = ctx.tbl_detail_order.Where(o => o.id_order == getOrder.id).ToList();

                        foreach (var detailOrder in getDetailOrder)
                        {
                            var menu = ctx.tbl_menu.Where(o => o.id == detailOrder.id_menu).FirstOrDefault();
                            row = ds.Tables["DataTableLaporan"].NewRow();

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
                            row[10] = detailOrder.created_date.Value.Date.ToString();

                            ds.Tables["DataTableLaporan"].Rows.Add(row);
                        }
                    }
                    
                }




                rptDS = new ReportDataSource("DataTableLaporan", ds.Tables["DataTableLaporan"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                //MsgBox(ex.Message)
            }


        }

        private void btn_cetak_Click(object sender, EventArgs e)
        {
            var startDate = DateTime.Parse(dateTimePicker1.Text);
            var endDate = DateTime.Parse(dateTimePicker2.Text);
            LoadReport(startDate,endDate);
        }

        private void btn_kembali_Click(object sender, EventArgs e)
        {
            this.Hide();

            menu_admin frm2 = new menu_admin();
            frm2.Show();
        }
    }
}
