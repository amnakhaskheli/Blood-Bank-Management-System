using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Blood_bank_system_project__window_form_;
namespace Blood_bank_system_project__window_form_
{
    public partial class AddNewDonor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\\SQLEXPRESS;Initial Catalog=blood bank;Integrated Security=True");
        function fn = new function();

        bool isEditMode = false;
        int editID = 0;

        //  NEW DONOR CONSTRUCTOR 
        public AddNewDonor()
        {
            InitializeComponent();
            SetNextID();  // Generate next ID for UI reference
        }

        //  EDIT DONOR CONSTRUCTOR 
        public AddNewDonor(int id)
        {
            InitializeComponent();
            editID = id;
            isEditMode = true;
            LoadDonorData(id);   // Fill existing donor data
        }

        // LOAD DONOR DATA (EDIT MODE)
        private void LoadDonorData(int id)
        {
            try
            {
                string query = "SELECT * FROM newDonor WHERE did=" + id;
                DataSet ds = fn.getData(query);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    LabelNewID.Text = ds.Tables[0].Rows[0]["did"].ToString();
                    textName.Text = ds.Tables[0].Rows[0]["dname"].ToString();
                    textFname.Text = ds.Tables[0].Rows[0]["fname"].ToString();
                    textDOB.Text = ds.Tables[0].Rows[0]["dob"].ToString();
                    textMobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                    textGender.Text = ds.Tables[0].Rows[0]["gender"].ToString();
                    textEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    textBloodgroup.Text = ds.Tables[0].Rows[0]["bloodgroup"].ToString();
                    textCity.Text = ds.Tables[0].Rows[0]["city"].ToString();
                    textAddress.Text = ds.Tables[0].Rows[0]["daddress"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donor: " + ex.Message);
            }
        }

        // -------------------------- AUTO GENERATE NEXT ID (UI Only) --------------------------
        private void SetNextID()
        {
            if (isEditMode) return; // Edit mode me ID change nahi honi chahiye

            try
            {
                string query = "SELECT ISNULL(MAX(did), 0) + 1 AS NextID FROM newDonor";
                DataSet ds = fn.getData(query);


                LabelNewID.Text = ds.Tables[0].Rows[0][0].ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next ID: " + ex.Message);
            }
        }

        // -------------------------- SAVE BUTTON (NEW + EDIT) --------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEditMode)
                {
                    // ---------------- UPDATE EXISTING DONOR ----------------
                    string query = @"UPDATE newDonor SET 
                                        dname=@dname,
                                        fname=@fname,
                                        dob=@dob,
                                        mobile=@mobile,
                                        gender=@gender,
                                        email=@email,
                                        bloodgroup=@bloodgroup,
                                        city=@city,
                                        daddress=@daddress
                                     WHERE did=@did";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@did", editID);
                    cmd.Parameters.AddWithValue("@dname", textName.Text);
                    cmd.Parameters.AddWithValue("@fname", textFname.Text);
                    cmd.Parameters.AddWithValue("@dob", textDOB.Text);
                    cmd.Parameters.AddWithValue("@mobile", textMobile.Text);
                    cmd.Parameters.AddWithValue("@gender", textGender.Text);
                    cmd.Parameters.AddWithValue("@email", textEmail.Text);
                    cmd.Parameters.AddWithValue("@bloodgroup", textBloodgroup.Text);
                    cmd.Parameters.AddWithValue("@city", textCity.Text);
                    cmd.Parameters.AddWithValue("@daddress", textAddress.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Donor updated successfully!");
                }
                else
                {
                    // ---------------- INSERT NEW DONOR ----------------
                    string query = @"INSERT INTO newDonor(did, dname, fname, dob, mobile, gender, email, bloodgroup, city, daddress)
                                     VALUES(@did,@dname,@fname,@dob,@mobile,@gender,@email,@bloodgroup,@city,@daddress)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dname", textName.Text);
                    cmd.Parameters.AddWithValue("@dname", textName.Text);
                    cmd.Parameters.AddWithValue("@fname", textFname.Text);
                    cmd.Parameters.AddWithValue("@dob", textDOB.Text);
                    cmd.Parameters.AddWithValue("@mobile", textMobile.Text);
                    cmd.Parameters.AddWithValue("@gender", textGender.Text);
                    cmd.Parameters.AddWithValue("@email", textEmail.Text);
                    cmd.Parameters.AddWithValue("@bloodgroup", textBloodgroup.Text);
                    cmd.Parameters.AddWithValue("@city", textCity.Text);
                    cmd.Parameters.AddWithValue("@daddress", textAddress.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("New donor added successfully!");
                }

                btnReset.PerformClick(); // Clear form
                isEditMode = false;
                SetNextID(); // Update Label for next new donor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        // -------------------------- RESET BUTTON --------------------------
        private void btnReset_Click(object sender, EventArgs e)
        {
            textName.Clear();
            textFname.Clear();
            textDOB.ResetText();
            textMobile.Clear();
            textGender.ResetText();
            textEmail.Clear();
            textBloodgroup.ResetText();
            textCity.Clear();
            textAddress.Clear();

            isEditMode = false;
            SetNextID();
        }

        // -------------------------- CLOSE BUTTON --------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewDonor_Load(object sender, EventArgs e)
        {

        }
    }
}