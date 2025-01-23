using System;
using System.Windows.Forms;

namespace TeleBerço
{
    public partial class FrmLogin : Form
    {
        private string senhaGravada = " Tropa";

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
         
               txtUser.Text = "Bruno";
            txtPass.Text = senhaGravada;
     
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
            if (txtUser.Text == "Bruno" && txtPass.Text == senhaGravada)
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

      
        private void chckLembrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chckLembrar.Checked)
            {
                // Verifica se o texto da senha foi alterado
                if (txtPass.Text != senhaGravada && txtPass.Text != string.Empty)
                {
                    // Atualiza a senha gravada com o novo valor
                    senhaGravada = txtPass.Text;
                    MessageBox.Show("Senha alterada e salva com sucesso!");
                }
                else
                {
                    // Carrega os valores predefinidos
                    txtUser.Text = "Bruno";
                    txtPass.Text = senhaGravada;
                   
                }
            }
            else
            {
                // Limpa os campos se o checkbox for desmarcado
                txtUser.Text = string.Empty;
                txtPass.Text = string.Empty;
            }
        }
    }
}


