using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class cadastro : Form
    {
        string dbpath = @"C:\Users\pedro.ahghiraldelli\Desktop\logistica.db";
        string connectString;

        public cadastro()
        {
            InitializeComponent();
            connectString = $"Data Source={dbpath};Version=3;";

            // Ocultar caracteres digitados na senha
            textBox_pwd.PasswordChar = '*';
            textBox_cpwd.PasswordChar = '*';
        }




        private void button_cadastrar_Click(object sender, EventArgs e)
        {
            string login = textBox_user.Text.Trim();
            string senha = textBox_pwd.Text;
            string confirmaSenha = textBox_cpwd.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmaSenha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }
            if (senha != confirmaSenha)
            {
                MessageBox.Show("As senhas não conferem.");
                return;
            }

            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string query = @"INSERT INTO USUARIOS (LOGIN, SENHA) VALUES (@login, @senha)";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@senha", senha);  // Para maior segurança, utilize hash!
                        cmd.ExecuteNonQuery();
                       
                    }

                   
                }

                MessageBox.Show("Usuário cadastrado com sucesso!");
                this.Close();
              
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE"))
                    MessageBox.Show("Este usuário já existe. Escolha outro login.");
                else
                    MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }
    }
}
