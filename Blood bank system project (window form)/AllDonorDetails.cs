using System;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;
using Blood_bank_system_project__window_form_;

namespace Blood_bank_system_project__window_form_
{
    public partial class AllDonorDetails : Form
    {
        function fn = new function();

        public AllDonorDetails()
        {
            InitializeComponent();
            LoadAllDonors(); // Load grid on form load
        }

        
        private void LoadAllDonors()
        {
            try
            {

                string query = "SELECT * FROM newDonor ORDER BY did ASC";
                DataSet ds = fn.getData(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];

                    
                    if (dataGridView1.Columns["did"] != null)
                        dataGridView1.Columns["did"].HeaderText = "Donor ID";
                    if (dataGridView1.Columns["dname"] != null)
                        dataGridView1.Columns["dname"].HeaderText = "Name";
                    if (dataGridView1.Columns["fname"] != null)
                        dataGridView1.Columns["fname"].HeaderText = "Father Name";
                    if (dataGridView1.Columns["dob"] != null)
                        dataGridView1.Columns["dob"].HeaderText = "DOB";
                    if (dataGridView1.Columns["mobile"] != null)
                        dataGridView1.Columns["mobile"].HeaderText = "Mobile";
                    if (dataGridView1.Columns["gender"] != null)
                        dataGridView1.Columns["gender"].HeaderText = "Gender";
                    if (dataGridView1.Columns["email"] != null)
                        dataGridView1.Columns["email"].HeaderText = "Email";
                    if (dataGridView1.Columns["bloodgroup"] != null)
                        dataGridView1.Columns["bloodgroup"].HeaderText = "Blood Group";
                    if (dataGridView1.Columns["city"] != null)
                        dataGridView1.Columns["city"].HeaderText = "City";
                    if (dataGridView1.Columns["daddress"] != null)
                        dataGridView1.Columns["daddress"].HeaderText = "Address";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donors: " + ex.Message);
            }
        }
        private void AllDonorDetails_Load(object sender, EventArgs e)
        {
            // Grid me new row add disable
            dataGridView1.AllowUserToAddRows = false;

            // Row select mode
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                   
                    
                        int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        AddNewDonor editForm = new AddNewDonor(id);
                        editForm.Show();
                        this.Hide(); 
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening donor for edit: " + ex.Message);
            }
        }

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllDonors();
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {

                        int donorID = Convert.ToInt32(row.Cells["did"].Value);
                        string deleteQuery = "DELETE FROM newDonor WHERE did = '" + donorID + "'";
                        fn.setData(deleteQuery);

                    }

                    LoadAllDonors(); // refresh grid
                }

                else
                {
                    MessageBox.Show("Please select a row to delete!");
                }
            }
            catch (Exception ex)
                {
                    MessageBox.Show("Please select row to delete" +ex.Message);
                }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
