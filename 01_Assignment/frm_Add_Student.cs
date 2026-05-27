using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _01_Assignment
{
   
    public partial class frm_Add_Student : Form
    {
        public frm_Add_Student()
        {
            InitializeComponent();
        }

        private void frm_Add_Student_Load(object sender, EventArgs e)
        {
            Fcon_Start();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Student_Details", Fcon);


        }

        SqlConnection Fcon = new SqlConnection(@"Data Source=LAPTOP-66UBMEL9;Initial Catalog=Student_Addmision_System_DB;Integrated Security=True");

        void Fcon_Start()
        {
            if(Fcon.State != ConnectionState.Open)
            {
                Fcon.Open
                    ();
            }
        }

        void Fcon_stop()
        {
            if(Fcon.State != ConnectionState.Open)
            {
                Fcon.Close();
            }
        }

        void FClear_Controls()
        {
            tb_Roll_No.Clear();
            tb_Name.Clear();
            tb_Mobile.Clear();
            dtp_Dob.Text = "01-06-2010";
            cmb_Course.SelectedIndex = -1;
        }


        private void btn_Student_list_Click(object sender, EventArgs e)
        {
            frm_Student_list obj = new frm_Student_list();
            obj.Show();
            this.Hide();
        }
        
        

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Fcon_Start();

            if(tb_Roll_No.Text !="" && tb_Name.Text !="" && tb_Mobile.Text !="" && cmb_Course.Text !="")
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = Fcon;
                cmd.CommandText = "Insert into Student_Details values (@RNo,@Nm,@MNo,@DB,@Cr)";

                cmd.Parameters.Add("RNo",SqlDbType.Int).Value = tb_Roll_No.Text;
                cmd.Parameters.Add("Nm", SqlDbType.VarChar).Value = tb_Name.Text;
                cmd.Parameters.Add("MNo", SqlDbType.Decimal).Value = tb_Mobile.Text;
                cmd.Parameters.Add("DB", SqlDbType.Date).Value = dtp_Dob.Value;
                cmd.Parameters.Add("Cr", SqlDbType.NVarChar).Value = cmb_Course.Text;

                

                FClear_Controls();

            }
            else
            {
                Fcon_stop();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            FClear_Controls();
        }

        
    }
}
