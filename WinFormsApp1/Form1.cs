using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form

    {
        string dbpath = @"C:\Users\pedro.ahghiraldelli\Desktop\logistica.db";
        string connectString;

        public Form1()
        {
            InitializeComponent();

            connectString = $"Data Source={dbpath};Version=3;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectdb();
        }

        private void connectdb()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    MessageBox.Show("Conexão OK!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro, Tudo errado!: {ex.Message}");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveForm();
        }

        private void saveForm()
        {
            int indice = tabControl1.SelectedIndex;

            if (indice == 0)
            {


                try
                {
                    using (var connection = new SQLiteConnection(connectString))
                    {
                        connection.Open();
                        string insertQuery = @"INSERT INTO VEICULO (MODELO, PLACA, CONSUMO_MEDIO, CARGA_MAXIMA) " +
                                "VALUES (@Modelo, @Placa, @ConsMedio, @CargaMax)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Modelo", textBox_modelo.Text);
                            cmd.Parameters.AddWithValue("@Placa", textBox_placa.Text);
                            cmd.Parameters.AddWithValue("@ConsMedio", textBox_consumo.Text);
                            cmd.Parameters.AddWithValue("@CargaMax", textBox_carga.Text);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Veiculo Salvo com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro" + ex.Message);
                }

            }
            else if (indice == 1)
            {
                try
                {
                    using (var connection = new SQLiteConnection(connectString))
                    {
                        connection.Open();
                        string insertQuery = @"INSERT INTO MOTORISTA (NOME, CNH, TELEFONE) " +
                                "VALUES (@Nome, @CNH, @Phone)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Nome", textBox_nomeMotorista.Text);
                            cmd.Parameters.AddWithValue("@CNH", textBox_cnh.Text);
                            cmd.Parameters.AddWithValue("@Phone", textBox_fone.Text);


                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Motorista Salvo com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro" + ex.Message);
                }
            }
            else if (indice == 2)
            {
                try
                {
                    using (var connection = new SQLiteConnection(connectString))
                    {
                        connection.Open();
                        string insertQuery = @"INSERT INTO ROTA (ORIGEM, DESTINO, DISTANCIA) " +
                                "VALUES (@Origem, @Destino, @Distancia)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Origem", textBox_origem.Text);
                            cmd.Parameters.AddWithValue("@Destino", textBox_destino.Text);
                            cmd.Parameters.AddWithValue("@Distancia", textBox_distancia.Text);


                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Rota Salva com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro" + ex.Message);
                }
            }
            else if (indice == 3)
            {
                try
                {
                    using (var connection = new SQLiteConnection(connectString))
                    {
                        connection.Open();
                        string insertQuery = @"INSERT INTO PRECO_COMBUSTIVEL (COMBUSTIVEL, PRECO, DATA_CONSULTA) " +
                                "VALUES (@Combustivel, @Preco, @dataConsulta)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Combustivel", comboBox_tipocomb.Text);
                            cmd.Parameters.AddWithValue("@Preco", textBox_precocomb.Text);
                            cmd.Parameters.AddWithValue("@dataConsulta", dateTimePicker1.Value.ToString("yyyy-MM-dd"));


                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Rota Salva com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro" + ex.Message);
                }
            }
            else if (indice == 4)
            {
                try
                {
                    using (var connection = new SQLiteConnection(connectString))
                    {
                        connection.Open();
                        string insertQuery = @"INSERT INTO VIAGEM (COMBUSTIVEL, PRECO, DATA_CONSULTA) " +
                                "VALUES (@Combustivel, @Preco, @dataConsulta)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Combustivel", comboBox_tipocomb.Text);
                            cmd.Parameters.AddWithValue("@Preco", textBox_precocomb.Text);
                            cmd.Parameters.AddWithValue("@dataConsulta", dateTimePicker1.Value.ToString("yyyy-MM-dd"));


                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Rota Salva com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro" + ex.Message);
                }
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {

        }
    }
}
