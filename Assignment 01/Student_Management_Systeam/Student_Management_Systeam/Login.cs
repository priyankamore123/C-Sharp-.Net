using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Management_Systeam
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void tb_Username_TextChanged(object sender, EventArgs e)
        {
            tb_Password.Enabled = true;
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            btn_Submit.Enabled = true;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if ((tb_Username.Text == "a") && (tb_Password.Text == "a123"))
            {
                MessageBox.Show("Login Successfull !!", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);

                frm_Add_New_Student ANS = new frm_Add_New_Student();

                ANS.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter Valid Username && Password");
            }

            tb_Username.Clear();
            tb_Password.Clear();
            tb_Username.Focus();

        }


    }

}
