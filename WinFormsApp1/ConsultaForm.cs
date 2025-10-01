using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ConsultaForm : Form
    {
        public event Action<DataRow> RegistroSelecionado;

        public ConsultaForm(DataTable tabela)
        {
            InitializeComponent();
            dataGridView1.DataSource = tabela;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                RegistroSelecionado?.Invoke(row);
                this.Close();
            }
        }
    }

}
