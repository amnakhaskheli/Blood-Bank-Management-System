using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blood_bank_system_project__window_form_
{
    public partial class UpdateDonorDetails : Form
    {
        function fn = new function();

        public UpdateDonorDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textDonorID.Text))
                {
                    string query = "UPDATE newDonor SET " +
                                   "dname='" + textName.Text + "', " +
                                   "fname='" + textFname.Text + "', " +
                                   "dob='" + textDOB.Text + "', " +
                                   "mobile='" + textMobile.Text + "', " +
                                   "gender='" + textGender.Text + "', " +
                                   "email='" + textEmail.Text + "', " +
                                   "bloodgroup='" + textBloodGroup.Text + "', " +
                                   "city='" + textCity.Text + "', " +
                                   "daddress='" + textAddress.Text + "' " +
                                   "WHERE did = " + textDonorID.Text;

                    try
                    {
                        fn.setData(query);
                        MessageBox.Show("Donor details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateDonorDetails_Load(this, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating donor: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Donor ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textDonorID.Text, out int id))
                {
                    string query = "SELECT * FROM newDonor WHERE did = " + id;
                    DataSet ds = fn.getData(query);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count != 0)
                    {
                        textName.Text = ds.Tables[0].Rows[0][1].ToString();
                        textFname.Text = ds.Tables[0].Rows[0][2].ToString();
                        textDOB.Text = ds.Tables[0].Rows[0][3].ToString();
                        textMobile.Text = ds.Tables[0].Rows[0][4].ToString();
                        textGender.Text = ds.Tables[0].Rows[0][5].ToString();
                        textEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                        textBloodGroup.Text = ds.Tables[0].Rows[0][7].ToString();
                        textCity.Text = ds.Tables[0].Rows[0][8].ToString();
                        textAddress.Text = ds.Tables[0].Rows[0][9].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Donor ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric Donor ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching donor details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    textDOB.ResetText();
                    textMobile.Clear();
                    textGender.ResetText();
                    textEmail.Clear();
                    textBloodGroup.ResetText();
                    textCity.Clear();
                    textAddress.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing fields: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                textDonorID.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting Donor ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDonorDetails_Load(object sender, EventArgs e)
        {
            try
            {
                textDonorID.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Optional label click event, no database code
        }
    }

}
