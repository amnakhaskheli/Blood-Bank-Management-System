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
    public partial class SearchDonorByBlood : Form
    {
        function fn = new function();
        String query;

        public SearchDonorByBlood()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                // Optional: label click logic if needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in label click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void SearchDonorByBlood_Load(object sender, EventArgs e)
        {
            try
            {
                query = "select * from newDonor";
                DataSet ds = fn.getData(query);

                if (ds != null && ds.Tables.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
                else
                    dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textSearchBlood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textSearchBlood.Text))
                {
                    query = "select * from newDonor where bloodgroup Like '" + textSearchBlood.Text + "%'";
                }
                else
                {
                    query = "select * from newDonor";
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
