using SIGIV.CLS.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txbUsername.Text) || string.IsNullOrEmpty(txbPassword.Text))
                {
                    throw new Exception("Debe ingresar un usuario y contraseña");
                }
                bool succes = await UserManager.IniciarSession(txbUsername.Text, txbPassword.Text);
                if (succes)
                {
                    this.Hide();
                    DashBoard dashBoard = new DashBoard();
                    dashBoard.Show();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
