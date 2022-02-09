using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Variable for preventing multiple opening of a window
        
        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                AddBook abs = new AddBook();
                abs.Show();

        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInformation VSI = new ViewStudentInformation();
            VSI.Show();
        }

        //Issue Book Event
        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks IB = new IssueBooks();
            IB.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook RB = new ReturnBook();
            RB.Show();
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails CBD = new CompleteBookDetails();
            CBD.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectDetails PD1 = new ProjectDetails();
            PD1.Show();
        }
    }
}
