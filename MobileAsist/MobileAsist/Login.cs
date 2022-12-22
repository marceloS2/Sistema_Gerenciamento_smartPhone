using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileAsist
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserNomeTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Erro Login");


            }
            else if (UserNomeTb.Text == "admin" && PasswordTb.Text == "admin")
            {
                Reparar Obj = new Reparar();
                Obj.Show();
                this.Hide();
            }else 
            {
                MessageBox.Show("Erro Senha ou login ");
            }
        }
    }
}
