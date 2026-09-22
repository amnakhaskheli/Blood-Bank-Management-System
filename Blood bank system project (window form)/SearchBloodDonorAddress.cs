using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_bank_system_project__window_form_
{
    public partial class SearchBloodDonorAddress : Form
    {
        function fn = new function();

        public SearchBloodDonorAddress()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Optional: code for cell click if needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in grid cell click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBloodDonorAddress_Load(object sender, EventArgs e)
        {
            try
            {
                String query = "SELECT * FROM newDonor";
                DataSet ds = fn.getData(query);

                if (ds != null && ds.Tables.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
                else
                    dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query;
                if (!string.IsNullOrWhiteSpace(textAddress.Text))
                {
                    query = "SELECT * FROM newDonor WHERE city LIKE '" + textAddress.Text + "%' OR daddress LIKE '" + textAddress.Text + "%'";
                }
                else
                {
                    query = "SELECT * FROM newDonor";
                }

                DataSet ds = fn.getData(query);

                if (ds != null && ds.Tables.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
                else
                    dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching donors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
                dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during print: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
