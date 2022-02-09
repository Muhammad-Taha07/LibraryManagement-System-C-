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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // Load Event
        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString =  @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM NewBook";
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
            panel4.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM NewBook WHERE bid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
            txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();

            }
        //Cancel Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        //Text Change event for Book Search
        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM NewBook WHERE bName LIKE '"+txtBookName.Text+"%'";
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //Passing Data from SQL Server to Data Grid View.
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
                // if it is empty then we want to have original values back therefore same code have been used here again
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //Passing Data from SQL Server to Data Grid View.
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        //Refresh Button
        private void button1_Click(object sender, EventArgs e)
        {
            ViewBook_Load(this, null);

        }
        //Update Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtBName.Text;
                String bauthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                String pdate = txtPDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quantity = Int64.Parse(txtQuantity.Text);

                //Connection for Update
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "UPDATE NewBook SET bName= '" + bname + "', bAuthor='" + bauthor + "', bPubl='" + publication + "', bPDate='" + pdate + "', bPrice=" + price + ", bQuan=" + quantity + " WHERE bid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
        // Adding a Book Button
        private void button2_Click(object sender, EventArgs e)
        {
            AddBook abs = new AddBook();
            abs.Show();
        }
        //Delete Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                //Connection for Delete
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source= Satellite-V\SQLEXPRESS; Initial Catalog=library1; Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                SqlCommand del = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM NewBook WHERE bid=" + rowid + "";       
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewBook_Load(this, null);

            }
        }

    }
}
