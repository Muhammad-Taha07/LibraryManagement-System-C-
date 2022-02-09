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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Enter Password")
            {
                txtPassword.Clear();
               txtPassword.PasswordChar= '*';
            }
        }
        //Login Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            //Connection String for SQL Server Windows based Authentication
            con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
            //Connection String for SQL Server based Authentication
            //con.ConnectionString = (@"data source = Satellite-V\SQLEXPRESS ; database=library; User ID=sa;Password=nexus123");
            
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from loginTable where username ='" + txtUsername.Text + "' and pass = '" + txtPassword.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //If User and Pass are Correct Dashboard shows up
            if (ds.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("Login Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                this.Hide();
                //Dashboard dsa = new Dashboard();
                //dsa.Show();
                ProjectDetails PD1 = new ProjectDetails();
                PD1.Show();
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //User Registration
        private void btnRegister_Click(object sender, EventArgs e)
        {
            AddUser AU = new AddUser();
            AU.Show();
        }
    }
}
