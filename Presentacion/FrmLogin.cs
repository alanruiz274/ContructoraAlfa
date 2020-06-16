using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LogicaNegocio;
using Entidades;
using System.Collections.Generic;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        LoginManejador _loginLogicaNegocio;
        Login _loginEntidades;

        List<Login> lista = new List<Login>();
        public FrmLogin()
        {
            InitializeComponent();
            _loginEntidades = new Login();
            _loginLogicaNegocio = new LoginManejador();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "INGRESE USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }

        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "INGRESE USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "INGRESE CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "INGRESE CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lista = _loginLogicaNegocio.ObtenerLista(txtUser.Text, txtPassword.Text);
                if (_loginLogicaNegocio.UsuarioValido(txtUser.Text))
                {
                    if (txtUser.Text == lista[0].User && txtPassword.Text == lista[0].Password)
                    {
                        Principal principal = new Principal(Convert.ToInt32(lista[0].Id), lista[0].User, lista[0].Password, Convert.ToInt32(lista[0].Nivel));
                        this.Hide();
                        principal.ShowDialog();

                    }
                }
                else
                    MessageBox.Show("Datos Incorrectos");
            }
            catch (Exception) 
            {
                MessageBox.Show("Error en los datos");
            }
        }
    }
}
