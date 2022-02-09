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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (txtReg.Text != "" && txtRegPw.Text != "")
            {
                String uname = txtReg.Text;
                String passw = txtRegPw.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "INSERT INTO loginTable (username, pass) values ('" + uname + "', '" + passw + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Registration Success!", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReg.Clear();
                txtRegPw.Clear();
            }
            else
            {
                MessageBox.Show("Please Fill the empty fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
