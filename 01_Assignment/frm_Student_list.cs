using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Assignment
{
    public partial class frm_Student_list : Form
    {
        public frm_Student_list()
        {
            InitializeComponent();
        }

        private void btn_Add_Student_Click(object sender, EventArgs e)
        {
            frm_Add_Student obj = new frm_Add_Student();
            obj.Show();
            this.Hide();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            frm_Login obj = new frm_Login();
            obj.Show();
            this.Hide();
        }

        private void frm_Student_list_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_Addmision_System_DBDataSet.Student_Details' table. You can move, or remove it, as needed.
            this.student_DetailsTableAdapter.Fill(this.student_Addmision_System_DBDataSet.Student_Details);

        }
    }
}
