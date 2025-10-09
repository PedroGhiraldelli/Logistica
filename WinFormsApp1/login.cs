using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class login : Form
    {
        string dbpath = @"C:\Users\pedro.ahghiraldelli\Desktop\logistica.db";
        string connectString;

        public login()
        {
            InitializeComponent();
            connectString = $"Data Source={dbpath};Version=3;";

            // Ocultar caracteres digitados na senha
            textBox_senha.PasswordChar = '*';
        }

        private void button_entrar_Click_1(object sender, EventArgs e)
        {
            string usuario = textBox_usuario.Text.Trim();
            string senha = textBox_senha.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM USUARIOS WHERE LOGIN = @login AND SENHA = @senha";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", usuario);
                        cmd.Parameters.AddWithValue("@senha", senha); // para maior segurança, use hash!
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha inválidos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao autenticar: " + ex.Message);
            }
        }

        private void button_cadastro_Click_1(object sender, EventArgs e)
        {
            using (var cadForm = new cadastro())
            {
                cadForm.ShowDialog();  // Modal. Após fechar, volta ao login
            }
        }
    }
}
