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
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }
        //Picture Changing upon Text
        private void txtSearchEnrollement_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchEnrollement.Text != "") // AGAR TEXT BOX KHALI NAHI HA MATLAB IF ITS BEING USED usme TYPING HORHI HA TO ACTIVE THIS CODE
            {
                label1.Visible = false;
                label2.Visible = false;
                //AUR YAI ANIMATED HAI JISKO SIRF SEARCHING PE DALI 
                Image image = Image.FromFile("C:/Users/Muhammad Taha/Desktop/Project Accessories/search1.gif");
                pictureBox1.Image=image;

                //Connection for Searching Via Enrollment number
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM NewStudent WHERE enroll LIKE '" + txtSearchEnrollement.Text + "%'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //Passing Data from SQL Server to Data Grid View.
                    dataGridView1.DataSource = ds.Tables[0];
            }
            else 
            {
                label1.Visible = true;
                label2.Visible = true;
        
                Image image = Image.FromFile("C:/Users/Muhammad Taha/Desktop/Project Accessories/search.gif");
                pictureBox1.Image = image;

                //If data is deleted so that the searching goes back to it's previous state
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //Passing Data from SQL Server to Data Grid View.
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible=false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //Passing Data from SQL Server to Data Grid View.
            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            //Assigning Values from Data Grid to Text Box into 2nd Panel below
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM NewStudent WHERE stuid=" + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtSName.Text        = ds.Tables[0].Rows[0][1].ToString();
            txtEnrollement.Text  = ds.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text   = ds.Tables[0].Rows[0][3].ToString();
            txtSemester.Text     = ds.Tables[0].Rows[0][4].ToString();
            txtContact.Text      = ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text        = ds.Tables[0].Rows[0][6].ToString();

        }
        //Cancel Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
           
        }

        //Update Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                String sname = txtSName.Text;
                String enroll = txtEnrollement.Text;
                String dep = txtDepartment.Text;
                String sem = txtSemester.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "UPDATE NewStudent SET sname='" + sname + "', enroll='" + enroll + "', dep='" + dep + "', sem='" + sem + "', contact=" + contact + ", email='" + email + "' WHERE stuid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }

        }
        //Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String sname = txtSName.Text;
                String enroll = txtEnrollement.Text;
                String dep = txtDepartment.Text;
                String sem = txtSemester.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM NewStudent WHERE stuid ="+rowid+"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudentInformation_Load(this, null);
            }
        }
        //Refresh Button
        private void button1_Click(object sender, EventArgs e)
        {
            ViewStudentInformation_Load(this, null);
        }

    }
}
