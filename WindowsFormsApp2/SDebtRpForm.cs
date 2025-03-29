using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class SDebtRpForm: Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";

        public SDebtRpForm()
        {
            InitializeComponent();
        }

        private void SDeptRpForm_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp2.SDebtRp.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "NewDataSet";
                string query = "SELECT * FROM SUPPLIER_INFO";
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
