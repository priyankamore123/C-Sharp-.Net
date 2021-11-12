using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Management_Systeam
{
    public partial class frm_Add_New_Student : Form
    {
        public frm_Add_New_Student()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DB_Student_Mannagement_Systeam;Integrated Security=True");
       
        void Con_Open()
        { 
           if( Con.State == ConnectionState.Closed)
            {
              Con.Open();
            }
        }

        void Con_Close()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        void Clear_Controls()
        {
            tb_Roll_No.Clear();
            tb_Name.Clear();
            dtp_DOB.ResetText();
            cb_Course.ResetText();
        }
        private void tb_Roll_No_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_Add_New_Student_Load(object sender, EventArgs e)
        {

        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are you sure you want to Logout?", "Loggiong Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }

        }

        private void tb_Save_Click(object sender, EventArgs e)
        {
            if (tb_Roll_No.Text != " " && tb_Name.Text != " " && dtp_DOB.Text != " " && cb_Course.Text != " ")
            {
                Con_Open();

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;

                Cmd.CommandText = " Insert into Student_Details (Roll_No,Name,DOB,Course)VALUES(@Roll_No,@Name,@DOB,@Course)";

                Cmd.Parameters.Add("Roll_No", SqlDbType.Int).Value = tb_Roll_No.Text;
                Cmd.Parameters.Add("Name", SqlDbType.VarChar).Value = tb_Name.Text;
                Cmd.Parameters.Add("Dob", SqlDbType.Date).Value = dtp_DOB.Text;
                Cmd.Parameters.Add("Course", SqlDbType.VarChar).Value = cb_Course.Text;
                Cmd.ExecuteNonQuery();

                MessageBox.Show("Record Saved Succesfully!!", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear_Controls();

                Con_Close();
                
            

            
            }

         }

        private void tb_Next_Click(object sender, EventArgs e)
        {
            frm_View_Student_Details obj = new frm_View_Student_Details();
            obj.Show();
            this.Hide();
        }

        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;

            }
        }

        private void Only_Char(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == (Char)Keys.Back)) || (e.KeyChar == (Char)Keys.Space))
            {
                e.Handled = true;
            }

        }

       
    }
}
