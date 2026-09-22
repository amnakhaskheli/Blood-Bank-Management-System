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
    public partial class DeleteDonor : Form
    {
        function fn = new function();
        String query;

        public DeleteDonor()
        {
            InitializeComponent();
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

        private void DeleteDonor_Load(object sender, EventArgs e)
        {
            try
            {
                // Optional: initialization logic if needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textDonorID.Text))
                {
                    query = "SELECT * FROM newDonor WHERE did = " + textDonorID.Text;
                    DataSet ds = fn.getData(query);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count != 0)
                    {
                        textName.Text = ds.Tables[0].Rows[0][1].ToString();
                        textFname.Text = ds.Tables[0].Rows[0][2].ToString();
                        textDOB.Text = ds.Tables[0].Rows[0][3].ToString();
                        textMobile.Text = ds.Tables[0].Rows[0][4].ToString();
                        textGender.Text = ds.Tables[0].Rows[0][5].ToString();
                        textEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                        textBloodgroup.Text = ds.Tables[0].Rows[0][7].ToString();
                        textCity.Text = ds.Tables[0].Rows[0][8].ToString();
                        textAddress.Text = ds.Tables[0].Rows[0][9].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Record Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textDonorID.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a Donor ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching donor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textAddress_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Optional: if any live filtering needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in address text change: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textDonorID.Text))
                {
                    if (MessageBox.Show("Are You Sure?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        query = "DELETE FROM newDonor WHERE did = " + textDonorID.Text;
                        fn.setData(query);
                        MessageBox.Show("Donor deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a Donor ID to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting donor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textDonorID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textDonorID.Text))
                {
                    textName.Clear();
                    textFname.Clear();
                    textDOB.Clear();
                    textMobile.Clear();
                    textGender.Clear();
                    textEmail.Clear();
                    textBloodgroup.Clear();
                    textCity.Clear();
                    textAddress.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing fields: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textDonorID.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing Donor ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
