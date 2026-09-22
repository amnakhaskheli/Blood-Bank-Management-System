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
    public partial class StockDecrease : Form
    {
        function fn = new function();
        String query;

        public StockDecrease()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            
            }
    
            catch (Exception ex)
            {
                MessageBox.Show("Error in comboBox selection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StockDecrease_Load(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT blood_group, quantity FROM Bloodstock";
                DataSet ds = fn.getData(query);

                if (ds != null && ds.Tables.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
                else
                    dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blood stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           textUnits.KeyPress += new KeyPressEventHandler(comboBox1_KeyPress);

        }
           private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
           {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
               {
                   e.Handled = true; // letters block
               }

           }
        

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textUnits.Text) && !string.IsNullOrWhiteSpace(textBloodGroup.Text))
                {
                    if (int.TryParse(textUnits.Text, out int units))
                    {
                        query = "UPDATE Bloodstock SET quantity = quantity - " + units + " WHERE blood_group = '" + textBloodGroup.Text + "'";

                        try
                        {
                            fn.setData(query);
                            MessageBox.Show("Stock decreased successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StockDecrease_Load(this, null); // refresh grid
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating stock: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid numeric value for units.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill both Blood Group and Units fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textUnits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
