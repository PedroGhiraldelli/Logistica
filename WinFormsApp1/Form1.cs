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

            if (indice == 0)//incluir/salvar de Veiculo
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
            else if (indice == 1)//incluir/salvar de Motorista
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
            else if (indice == 2)//incluir/salvar de ROTA
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
            else if (indice == 3)//incluir/salvar de preço combustivel
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
                        string insertQuery = @"INSERT INTO VIAGEM (DATA_SAIDA, DATA_CHEGADA, SITUACAO, VEICULOID, MOTORISTAID, ROTAID) " +
                                "VALUES (@Data_saida, @Data_chegada, @Situacao, @Veiculo, @Motorista, @Rota)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Data_saida", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Data_chegada", dateTimePicker3.Value.ToString("yyyy-MM-dd"));

                            cmd.Parameters.AddWithValue("@Situacao", "Em Andamento");

                            cmd.Parameters.AddWithValue("@Veiculo", comboBox1.Text);
                            cmd.Parameters.AddWithValue("@Motorista", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@Rota", comboBox3.Text);



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

        private void consultaVeiculo()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();

                    string sqlselect = "SELECT (MODELO || ' - ' || PLACA) AS DESCRICAO, PLACA FROM VEICULO ORDER BY MODELO";

                    using (var adapter = new SQLiteDataAdapter(sqlselect, connection))
                    {

                        DataTable tabelaVeiculos = new DataTable();

                        adapter.Fill(tabelaVeiculos);

                        comboBox1.DataSource = tabelaVeiculos;

                        comboBox1.DisplayMember = "DESCRICAO";

                        comboBox1.ValueMember = "PLACA";

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }
        }

        private void consultaRota()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();

                    string sqlselect = "SELECT (ORIGEM || ' - Até - ' || DESTINO) AS DESCRICAO, ORIGEM FROM ROTA ORDER BY ORIGEM";

                    using (var adapter = new SQLiteDataAdapter(sqlselect, connection))
                    {

                        DataTable tabelaRotas = new DataTable();

                        adapter.Fill(tabelaRotas);

                        comboBox2.DataSource = tabelaRotas;

                        comboBox2.DisplayMember = "DESCRICAO";

                        comboBox2.ValueMember = "ORIGEM";

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }
        }

        private void consultaMotorista()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();

                    string sqlselect = "SELECT (NOME || ' - CNH: ' || CNH) AS NOME, CNH FROM MOTORISTA ORDER BY NOME";

                    using (var adapter = new SQLiteDataAdapter(sqlselect, connection))
                    {

                        DataTable tabelaMotorista = new DataTable();

                        adapter.Fill(tabelaMotorista);

                        comboBox3.DataSource = tabelaMotorista;

                        comboBox3.DisplayMember = "NOME";

                        comboBox3.ValueMember = "CNH";

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }
        }



        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            consultaVeiculo();
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            consultaRota();
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            consultaMotorista();
        }

        private void consultarForm()
        {
            int indice = tabControl1.SelectedIndex;
            string sql = "";

            if (indice == 0) sql = "SELECT * FROM VEICULO";
            else if (indice == 1) sql = "SELECT * FROM MOTORISTA";
            else if (indice == 2) sql = "SELECT * FROM ROTA";
            else if (indice == 3) sql = "SELECT * FROM PRECO_COMBUSTIVEL";
            else if (indice == 4) sql = "SELECT * FROM VIAGEM";
            else return;

            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    using (var da = new SQLiteDataAdapter(sql, connection))
                    {
                        DataTable tabela = new DataTable();
                        da.Fill(tabela);
                        ConsultaForm consulta = new ConsultaForm(tabela);
                        consulta.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int indice = tabControl1.SelectedIndex;
            DataTable tabelaConsulta = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string selectQuery = "";

                    if (indice == 0) // Veículo
                        selectQuery = "SELECT MODELO, PLACA, CONSUMO_MEDIO, CARGA_MAXIMA FROM VEICULO";
                    else if (indice == 1) // Motorista
                        selectQuery = "SELECT NOME, CNH, TELEFONE FROM MOTORISTA";
                    else if (indice == 2) // Rota
                        selectQuery = "SELECT ORIGEM, DESTINO, DISTANCIA FROM ROTA";
                    else if (indice == 3) // Combustível
                        selectQuery = "SELECT COMBUSTIVEL, PRECO, DATA_CONSULTA FROM PRECO_COMBUSTIVEL";
                    else if (indice == 4) // Viagem
                        selectQuery = "SELECT DATA_SAIDA, DATA_CHEGADA, SITUACAO, VEICULOID, MOTORISTAID, ROTAID FROM VIAGEM";

                    if (!string.IsNullOrEmpty(selectQuery))
                    {
                        using (var adapter = new SQLiteDataAdapter(selectQuery, connection))
                        {
                            adapter.Fill(tabelaConsulta);
                        }
                    }
                }

                var consulta = new ConsultaForm(tabelaConsulta);
                consulta.RegistroSelecionado += row =>
                {
                    if (indice == 0)
                    {
                        textBox_modelo.Text = row["MODELO"].ToString();
                        textBox_placa.Text = row["PLACA"].ToString();
                        textBox_consumo.Text = row["CONSUMO_MEDIO"].ToString();
                        textBox_carga.Text = row["CARGA_MAXIMA"].ToString();
                    }
                    else if (indice == 1)
                    {
                        textBox_nomeMotorista.Text = row["NOME"].ToString();
                        textBox_cnh.Text = row["CNH"].ToString();
                        textBox_fone.Text = row["TELEFONE"].ToString();
                    }
                    else if (indice == 2)
                    {
                        textBox_origem.Text = row["ORIGEM"].ToString();
                        textBox_destino.Text = row["DESTINO"].ToString();
                        textBox_distancia.Text = row["DISTANCIA"].ToString();
                    }
                    else if (indice == 3)
                    {
                        comboBox_tipocomb.Text = row["COMBUSTIVEL"].ToString();
                        textBox_precocomb.Text = row["PRECO"].ToString();
                        dateTimePicker1.Value = DateTime.Parse(row["DATA_CONSULTA"].ToString());
                    }
                    else if (indice == 4)
                    {
                        dateTimePicker2.Value = DateTime.Parse(row["DATA_SAIDA"].ToString());
                        dateTimePicker3.Value = DateTime.Parse(row["DATA_CHEGADA"].ToString());

                                              

                        comboBox1.SelectedValue = row["VEICULOID"].ToString();
                        comboBox2.SelectedValue = row["MOTORISTAID"].ToString();
                        comboBox3.SelectedValue = row["ROTAID"].ToString();
                        // Caso queira preencher outros campos relacionados a VEICULOID, MOTORISTAID, ROTAID, adapte conforme necessário
                    }
                };
                consulta.ShowDialog();

                // Atualize ou limpe componentes após fechar o form de consulta, se necessário
                // chamar o método consultarForm (como no código original) caso exista para atualizar dados
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar: " + ex.Message);
            }
        }

    }
}
