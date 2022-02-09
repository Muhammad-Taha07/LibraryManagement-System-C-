using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement1
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }
        
        //Issue Book Frame Event
        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("SELECT bName from NewBook", con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            //Reading Data till 10 if there are 10datas
            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        //Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Search Student
        int count;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (txtEnrollement.Text != "")
            {
                String eid = txtEnrollement.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM NewStudent WHERE enroll = '" + eid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
               
                //-----------------------------------------------------------------------------------------------------------
                //Code to Count How many book has been issues on this enrollement Number

                cmd.CommandText = "SELECT COUNT(std_enroll) FROM IRBook WHERE std_enroll = '" + eid + "' and book_return_date is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                //-----------------------------------------------------------------------------------------------------------



                // Trying to Assign a null value to text box, to catch error. / Displaing Executes when dataset has value
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDep.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSem.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();

                }
                    //User Entering Wrong Student ID
                else
                {
                    txtName.Clear();
                    txtDep.Clear();
                    txtSem.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();

                    MessageBox.Show("You have Entered Invalid Student ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Issue Books Button
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtName.Text != null)
            {
                if (comboBoxBooks.SelectedIndex != -1 && count <= 2)
                {
                    String enroll = txtEnrollement.Text;
                    String sname = txtName.Text;
                    String sdep = txtDep.Text;
                    String sem = txtSem.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String email = txtEmail.Text;
                    String bookname = comboBoxBooks.Text;
                    String bookIssueDate = dateTimePicker.Text;

                    String eid = txtEnrollement.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = cmd.CommandText = "INSERT INTO IRBook (std_enroll, std_name, std_dep, std_sem, std_contact, std_email, book_name, book_issue_date) VALUES ('" + enroll + "', '" + sname + "', '" + sdep + "', '" + sem + "', " + contact + ", '" + email + "', '" + bookname + "', '" + bookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book has been Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //IssueBooks_Load(this, null);
                    txtEnrollement.Clear();
                    txtName.Clear();
                    txtDep.Clear();
                    txtSem.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    
                }
                else
                {
                    MessageBox.Show("Select Book OR Maximum number of Book has been Issued", "No Book issued", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter Valid Enrollement No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            IssueBooks_Load(this, null);
        }
    }
}
