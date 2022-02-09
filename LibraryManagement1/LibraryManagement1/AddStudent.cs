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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        //Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Refresh Button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        //Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Taking input from Text Fields
            if (txtName.Text != "" && txtEnrollment.Text != "" && txtDepartment.Text != "" && txtSemester.Text != "" && txtContact.Text != "" && txtEmail.Text != "")
            {
                String name = txtName.Text;
                String enroll = txtEnrollment.Text;
                String dep = txtDepartment.Text;
                String sem = txtSemester.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;


                //Implementing SQL Connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open(); //Opening Connection
                cmd.CommandText = "INSERT INTO NewStudent(sname,enroll,dep,sem,contact,email) VALUES ('" + name + "', '" + enroll + "', '" + dep + "', '" + sem + "', " + mobile + ", '" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                txtEnrollment.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
            else
            {
                MessageBox.Show("Please Fill the empty fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }




    }
}
