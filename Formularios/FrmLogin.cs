using System;
using System.Windows.Forms;

namespace TeleBerço
{
    public partial class FrmLogin : Form
    {

        private Timer timer;

        public FrmLogin()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
       
        }
   
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            chckLembrar.Checked = true;

            if (chckLembrar.Checked)
            {
                txtUser.Text = "BrunoFernandes";
                txtPass.Text = "123";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            timer.Stop();
            this.Hide();
            FrmDocumentos frmDocumentos = new FrmDocumentos();
            frmDocumentos.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "BrunoFernandes" && txtPass.Text == "123")
            {         
                panelSucecss.Visible = true;              
                timer.Start();                                 
            }
            else if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Preencha ambos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Utilizador nao encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}


