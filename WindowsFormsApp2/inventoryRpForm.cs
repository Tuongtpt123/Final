using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace WindowsFormsApp2
{
    public partial class inventoryRpForm: Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";

        public inventoryRpForm()
        {
            InitializeComponent();
        }

        private void ItemSoldRpForm_Load(object sender, EventArgs e)
        {
            try {
                reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp2.inventoryRp.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                string query = "SELECT * FROM PRODUCT_INFO";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            rds.Value = dt;
                            reportViewer1.LocalReport.DataSources.Add(rds);
                        }
                    }
                }

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
