using System;
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
        private int indiceAnterior = 0;

        public Form1()
        {
            InitializeComponent();
            connectString = $"Data Source={dbpath};Version=3;";

            // Configurar ComboBoxes para DropDownList (não editáveis)
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tipocomb.DropDownStyle = ComboBoxStyle.DropDownList;

            // Adicionar eventos KeyPress para validação dos campos numéricos
            textBox_fone.KeyPress += ApenasNumeros_KeyPress;
            textBox_cnh.KeyPress += ApenasNumeros_KeyPress;
            textBox_consumo.KeyPress += ApenasNumerosEDecimal_KeyPress;
            textBox_carga.KeyPress += ApenasNumerosEDecimal_KeyPress;
            textBox_distancia.KeyPress += ApenasNumerosEDecimal_KeyPress;
            textBox_precocomb.KeyPress += ApenasNumerosEDecimal_KeyPress;

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        // Permite somente números inteiros
        private void ApenasNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Permite números e separador decimal (virgula/ponto, conforme sistema)
        private void ApenasNumerosEDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            char separadorDecimal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            // Permite control, dígito ou decimal (somente um decimal)
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != separadorDecimal || textBox.Text.Contains(separadorDecimal.ToString())))
            {
                e.Handled = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpa campos da aba anterior ao trocar
            switch (indiceAnterior)
            {
                case 0:
                    LimparCamposVeiculo();
                    break;
                case 1:
                    LimparCamposMotorista();
                    break;
                case 2:
                    LimparCamposRota();
                    break;
                case 3:
                    LimparCamposPrecoCombustivel();
                    break;
                case 4:
                    LimparCamposViagem();
                    break;
            }
            indiceAnterior = tabControl1.SelectedIndex;
        }

        private void LimparCamposVeiculo()
        {
            textBox_modelo.Clear();
            textBox_placa.Clear();
            textBox_consumo.Clear();
            textBox_carga.Clear();
            textBox_veiculoID.Clear();
        }

        private void LimparCamposMotorista()
        {
            textBox_nomeMotorista.Clear();
            textBox_cnh.Clear();
            textBox_fone.Clear();
            textBox_MotoristaID.Clear();
        }

        private void LimparCamposRota()
        {
            textBox_origem.Clear();
            textBox_destino.Clear();
            textBox_distancia.Clear();
            textBox_rotaID.Clear();
        }

        private void LimparCamposPrecoCombustivel()
        {
            comboBox_tipocomb.SelectedIndex = -1;
            textBox_precocomb.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox_combustivelID.Clear();
        }

        private void LimparCamposViagem()
        {
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
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

        private bool ValidarCamposParaSalvarOuEditar()
        {
            int indice = tabControl1.SelectedIndex;

            if (indice == 0) // Veículo
            {
                if (string.IsNullOrWhiteSpace(textBox_modelo.Text))
                {
                    MessageBox.Show("O campo Modelo é obrigatório.");
                    textBox_modelo.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_placa.Text))
                {
                    MessageBox.Show("O campo Placa é obrigatório.");
                    textBox_placa.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_consumo.Text))
                {
                    MessageBox.Show("O campo Consumo Médio é obrigatório.");
                    textBox_consumo.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_carga.Text))
                {
                    MessageBox.Show("O campo Carga Máxima é obrigatório.");
                    textBox_carga.Focus();
                    return false;
                }
            }
            else if (indice == 1) // Motorista
            {
                if (string.IsNullOrWhiteSpace(textBox_nomeMotorista.Text))
                {
                    MessageBox.Show("O campo Nome do Motorista é obrigatório.");
                    textBox_nomeMotorista.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_cnh.Text))
                {
                    MessageBox.Show("O campo CNH é obrigatório.");
                    textBox_cnh.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_fone.Text))
                {
                    MessageBox.Show("O campo Telefone é obrigatório.");
                    textBox_fone.Focus();
                    return false;
                }
            }
            else if (indice == 2) // Rota
            {
                if (string.IsNullOrWhiteSpace(textBox_origem.Text))
                {
                    MessageBox.Show("O campo Origem é obrigatório.");
                    textBox_origem.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_destino.Text))
                {
                    MessageBox.Show("O campo Destino é obrigatório.");
                    textBox_destino.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_distancia.Text))
                {
                    MessageBox.Show("O campo Distância é obrigatório.");
                    textBox_distancia.Focus();
                    return false;
                }
            }
            else if (indice == 3) // Preço combustível
            {
                if (string.IsNullOrWhiteSpace(comboBox_tipocomb.Text))
                {
                    MessageBox.Show("Selecione um Tipo de Combustível.");
                    comboBox_tipocomb.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(textBox_precocomb.Text))
                {
                    MessageBox.Show("O campo Preço do Combustível é obrigatório.");
                    textBox_precocomb.Focus();
                    return false;
                }
                if (dateTimePicker1.Value > DateTime.Now)
                {
                    MessageBox.Show("A Data da Consulta não pode ser futura.");
                    dateTimePicker1.Focus();
                    return false;
                }
            }
            else if (indice == 4) // Viagem
            {
                if (dateTimePicker2.Value > dateTimePicker3.Value)
                {
                    MessageBox.Show("A Data de Saída não pode ser maior que a Data de Chegada.");
                    dateTimePicker2.Focus();
                    return false;
                }
                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione um Veículo.");
                    comboBox1.Focus();
                    return false;
                }
                if (comboBox2.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione um Motorista.");
                    comboBox2.Focus();
                    return false;
                }
                if (comboBox3.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione uma Rota.");
                    comboBox3.Focus();
                    return false;
                }
            }

            return true;
        }
        
        private void btn_save_Click(object sender, EventArgs e)
        {
            saveForm();
        }

        private void saveForm()
        {
            if (!ValidarCamposParaSalvarOuEditar())
                return;

            int indice = tabControl1.SelectedIndex;

            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string insertQuery = "";

                    if (indice == 0) // Veiculo
                    {
                        insertQuery = @"INSERT INTO VEICULO (MODELO, PLACA, CONSUMO_MEDIO, CARGA_MAXIMA) 
                                        VALUES (@Modelo, @Placa, @ConsMedio, @CargaMax)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Modelo", textBox_modelo.Text);
                            cmd.Parameters.AddWithValue("@Placa", textBox_placa.Text);
                            cmd.Parameters.AddWithValue("@ConsMedio", textBox_consumo.Text);
                            cmd.Parameters.AddWithValue("@CargaMax", textBox_carga.Text);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Veiculo Salvo com sucesso!");
                    }
                    else if (indice == 1) // Motorista
                    {
                        insertQuery = @"INSERT INTO MOTORISTA (NOME, CNH, TELEFONE) 
                                        VALUES (@Nome, @CNH, @Phone)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Nome", textBox_nomeMotorista.Text);
                            cmd.Parameters.AddWithValue("@CNH", textBox_cnh.Text);
                            cmd.Parameters.AddWithValue("@Phone", textBox_fone.Text);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Motorista Salvo com sucesso!");
                    }
                    else if (indice == 2) // Rota
                    {
                        insertQuery = @"INSERT INTO ROTA (ORIGEM, DESTINO, DISTANCIA) 
                                        VALUES (@Origem, @Destino, @Distancia)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Origem", textBox_origem.Text);
                            cmd.Parameters.AddWithValue("@Destino", textBox_destino.Text);
                            cmd.Parameters.AddWithValue("@Distancia", textBox_distancia.Text);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Rota Salva com sucesso!");
                    }
                    else if (indice == 3) // Preço combustivel
                    {
                        insertQuery = @"INSERT INTO PRECO_COMBUSTIVEL (COMBUSTIVEL, PRECO, DATA_CONSULTA) 
                                        VALUES (@Combustivel, @Preco, @dataConsulta)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Combustivel", comboBox_tipocomb.Text);
                            cmd.Parameters.AddWithValue("@Preco", textBox_precocomb.Text);
                            cmd.Parameters.AddWithValue("@dataConsulta", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Preço combustível Salvo com sucesso!");
                    }
                    else if (indice == 4) // Viagem
                    {
                        insertQuery = @"INSERT INTO VIAGEM (DATA_SAIDA, DATA_CHEGADA, SITUACAO, VEICULOID, MOTORISTAID, ROTAID) 
                                        VALUES (@Data_saida, @Data_chegada, @Situacao, @Veiculo, @Motorista, @Rota)";
                        using (var cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Data_saida", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Data_chegada", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Situacao", "Em Andamento");
                            cmd.Parameters.AddWithValue("@Veiculo", comboBox1.SelectedValue);
                            cmd.Parameters.AddWithValue("@Motorista", comboBox2.SelectedValue);
                            cmd.Parameters.AddWithValue("@Rota", comboBox3.SelectedValue);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Viagem Salva com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }


        private void consultaVeiculo()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string sqlselect = "SELECT (VEICULOID || ' - ' || MODELO || ' - ' || PLACA) AS DESCRICAO, VEICULOID FROM VEICULO ORDER BY MODELO";
                    using (var adapter = new SQLiteDataAdapter(sqlselect, connection))
                    {
                        DataTable tabelaVeiculos = new DataTable();
                        adapter.Fill(tabelaVeiculos);
                        comboBox1.DataSource = tabelaVeiculos;
                        comboBox1.DisplayMember = "DESCRICAO";
                        comboBox1.ValueMember = "VEICULOID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void consultaRota()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string sqlselect = "SELECT (ROTAID || ' - ' || ORIGEM || ' - Até - ' || DESTINO) AS DESCRICAO, ROTAID FROM ROTA ORDER BY ORIGEM";
                    using (var adapter = new SQLiteDataAdapter(sqlselect, connection))
                    {
                        DataTable tabelaRotas = new DataTable();
                        adapter.Fill(tabelaRotas);
                        comboBox2.DataSource = tabelaRotas;
                        comboBox2.DisplayMember = "DESCRICAO";
                        comboBox2.ValueMember = "ROTAID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void consultaMotorista()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string sqlselect = "SELECT (MOTORISTAID || ' - '|| NOME || ' - CNH: ' || CNH) AS NOME, MOTORISTAID FROM MOTORISTA ORDER BY NOME";
                    using (var adapter = new SQLiteDataAdapter(sqlselect, connection))
                    {
                        DataTable tabelaMotorista = new DataTable();
                        adapter.Fill(tabelaMotorista);
                        comboBox3.DataSource = tabelaMotorista;
                        comboBox3.DisplayMember = "NOME";
                        comboBox3.ValueMember = "MOTORISTAID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
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

        private void button3_Click(object sender, EventArgs e) // Consultar e preencher campos
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
                        selectQuery = "SELECT VEICULOID, MODELO, PLACA, CONSUMO_MEDIO, CARGA_MAXIMA FROM VEICULO";
                    else if (indice == 1) // Motorista
                        selectQuery = "SELECT MOTORISTAID, NOME, CNH, TELEFONE FROM MOTORISTA";
                    else if (indice == 2) // Rota
                        selectQuery = "SELECT ROTAID, ORIGEM, DESTINO, DISTANCIA FROM ROTA";
                    else if (indice == 3) // Combustível
                        selectQuery = "SELECT PRECOID, COMBUSTIVEL, PRECO, DATA_CONSULTA FROM PRECO_COMBUSTIVEL";
                    else if (indice == 4) // Viagem
                        selectQuery = @"SELECT 
                                        v.VIAGEMID,
                                        v.DATA_SAIDA, 
                                        v.DATA_CHEGADA, 
                                        v.SITUACAO,
                                        v.VEICULOID,
                                        v.MOTORISTAID,
                                        v.ROTAID,
                                        c.MODELO AS MODELO, 
                                        c.PLACA AS PLACA, 
                                        m.NOME AS NOME, 
                                        m.CNH AS CNH, 
                                        r.ORIGEM AS ORIGEM, 
                                        r.DESTINO AS DESTINO
                                    FROM VIAGEM AS v
                                    LEFT JOIN VEICULO AS c ON v.VEICULOID = c.VEICULOID
                                    LEFT JOIN MOTORISTA AS m ON v.MOTORISTAID = m.MOTORISTAID
                                    LEFT JOIN ROTA AS r ON v.ROTAID = r.ROTAID
                                    ORDER BY v.VIAGEMID";


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
                        textBox_veiculoID.Text = row["VEICULOID"].ToString();
                    }
                    else if (indice == 1)
                    {
                        textBox_nomeMotorista.Text = row["NOME"].ToString();
                        textBox_cnh.Text = row["CNH"].ToString();
                        textBox_fone.Text = row["TELEFONE"].ToString();
                        textBox_MotoristaID.Text = row["MOTORISTAID"].ToString();
                    }
                    else if (indice == 2)
                    {
                        textBox_origem.Text = row["ORIGEM"].ToString();
                        textBox_destino.Text = row["DESTINO"].ToString();
                        textBox_distancia.Text = row["DISTANCIA"].ToString();
                        textBox_rotaID.Text = row["ROTAID"].ToString();
                    }
                    else if (indice == 3)
                    {
                        comboBox_tipocomb.Text = row["COMBUSTIVEL"].ToString();
                        textBox_precocomb.Text = row["PRECO"].ToString();
                        dateTimePicker1.Value = DateTime.Parse(row["DATA_CONSULTA"].ToString());
                        textBox_combustivelID.Text = row["PRECOID"].ToString();
                    }
                    else if (indice == 4)
                    {
                        dateTimePicker2.Value = DateTime.Parse(row["DATA_SAIDA"].ToString());
                        dateTimePicker3.Value = DateTime.Parse(row["DATA_CHEGADA"].ToString());
                        textBox1.Text = row["VIAGEMID"].ToString();

                        comboBox1.SelectedValue = row["VEICULOID"];
                        comboBox2.SelectedValue = row["MOTORISTAID"];
                        comboBox3.SelectedValue = row["ROTAID"];
                    }
                };
                consulta.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Editar/Atualizar
        {
            if (!ValidarCamposParaSalvarOuEditar())
                return;

            int indice = tabControl1.SelectedIndex;
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string updateQuery = "";

                    if (indice == 0) // Veículo
                    {
                        updateQuery = @"UPDATE VEICULO SET 
                                            MODELO = @Modelo, 
                                            PLACA = @Placa, 
                                            CONSUMO_MEDIO = @ConsMedio, 
                                            CARGA_MAXIMA = @CargaMax 
                                        WHERE VEICULOID = @Id";
                        using (var cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Modelo", textBox_modelo.Text);
                            cmd.Parameters.AddWithValue("@Placa", textBox_placa.Text);
                            cmd.Parameters.AddWithValue("@ConsMedio", textBox_consumo.Text);
                            cmd.Parameters.AddWithValue("@CargaMax", textBox_carga.Text);
                            cmd.Parameters.AddWithValue("@Id", textBox_veiculoID.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (indice == 1) // Motorista
                    {
                        updateQuery = @"UPDATE MOTORISTA SET 
                                            NOME = @Nome, 
                                            CNH = @CNH, 
                                            TELEFONE = @Phone 
                                        WHERE MOTORISTAID = @Id";
                        using (var cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Nome", textBox_nomeMotorista.Text);
                            cmd.Parameters.AddWithValue("@CNH", textBox_cnh.Text);
                            cmd.Parameters.AddWithValue("@Phone", textBox_fone.Text);
                            cmd.Parameters.AddWithValue("@Id", textBox_MotoristaID.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (indice == 2) // Rota
                    {
                        updateQuery = @"UPDATE ROTA SET 
                                            ORIGEM = @Origem, 
                                            DESTINO = @Destino, 
                                            DISTANCIA = @Distancia 
                                        WHERE ROTAID = @Id";
                        using (var cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Origem", textBox_origem.Text);
                            cmd.Parameters.AddWithValue("@Destino", textBox_destino.Text);
                            cmd.Parameters.AddWithValue("@Distancia", textBox_distancia.Text);
                            cmd.Parameters.AddWithValue("@Id", textBox_rotaID.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (indice == 3) // Preço combustível
                    {
                        updateQuery = @"UPDATE PRECO_COMBUSTIVEL SET 
                                            COMBUSTIVEL = @Combustivel, 
                                            PRECO = @Preco, 
                                            DATA_CONSULTA = @dataConsulta 
                                        WHERE PRECO_COMBUSTIVELID = @Id";
                        using (var cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Combustivel", comboBox_tipocomb.Text);
                            cmd.Parameters.AddWithValue("@Preco", textBox_precocomb.Text);
                            cmd.Parameters.AddWithValue("@dataConsulta", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Id", textBox_combustivelID.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (indice == 4) // Viagem
                    {
                        updateQuery = @"UPDATE VIAGEM SET 
                                            DATA_SAIDA = @Data_saida, 
                                            DATA_CHEGADA = @Data_chegada, 
                                            SITUACAO = @Situacao, 
                                            VEICULOID = @Veiculo, 
                                            MOTORISTAID = @Motorista, 
                                            ROTAID = @Rota 
                                        WHERE VIAGEMID = @Id";
                        using (var cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Data_saida", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Data_chegada", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@Situacao", "Em Andamento");
                            cmd.Parameters.AddWithValue("@Veiculo", comboBox1.SelectedValue);
                            cmd.Parameters.AddWithValue("@Motorista", comboBox2.SelectedValue);
                            cmd.Parameters.AddWithValue("@Rota", comboBox3.SelectedValue);
                            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Deletar
        {
            int indice = tabControl1.SelectedIndex;
            try
            {
                using (var connection = new SQLiteConnection(connectString))
                {
                    connection.Open();
                    string deleteQuery = "";
                    string idValue = "";

                    if (indice == 0) // Veículo
                    {
                        idValue = textBox_veiculoID.Text;
                        deleteQuery = "DELETE FROM VEICULO WHERE VEICULOID = @Id";
                    }
                    else if (indice == 1) // Motorista
                    {
                        idValue = textBox_MotoristaID.Text;
                        deleteQuery = "DELETE FROM MOTORISTA WHERE MOTORISTAID = @Id";
                    }
                    else if (indice == 2) // Rota
                    {
                        idValue = textBox_rotaID.Text;
                        deleteQuery = "DELETE FROM ROTA WHERE ROTAID = @Id";
                    }
                    else if (indice == 3) // Preço combustível
                    {
                        idValue = textBox_combustivelID.Text;
                        deleteQuery = "DELETE FROM PRECO_COMBUSTIVEL WHERE PRECOID = @Id";
                    }
                    else if (indice == 4) // Viagem
                    {
                        idValue = textBox1.Text;
                        deleteQuery = "DELETE FROM VIAGEM WHERE VIAGEMID = @Id";
                    }

                    if (string.IsNullOrEmpty(idValue))
                    {
                        MessageBox.Show("Nenhum registro selecionado para exclusão.");
                        return;
                    }

                    using (var cmd = new SQLiteCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", idValue);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro excluído com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro encontrado para exclusão.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            textBox_modelo.Clear();
            textBox_placa.Clear();
            textBox_consumo.Clear();
            textBox_carga.Clear();
            textBox_veiculoID.Clear();

            textBox_nomeMotorista.Clear();
            textBox_cnh.Clear();
            textBox_fone.Clear();
            textBox_MotoristaID.Clear();

            textBox_origem.Clear();
            textBox_destino.Clear();
            textBox_distancia.Clear();
            textBox_rotaID.Clear();

            comboBox_tipocomb.SelectedIndex = -1;
            textBox_precocomb.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox_combustivelID.Clear();

            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
        }
    }
}
