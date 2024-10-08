using System;
using System.Windows.Forms;
using WindowsFormsApp_231024_231098.Models;

namespace WindowsFormsApp_231024_231098.Views
{
    public partial class FrmMarcas : Form
    {
        Marca c;

        public FrmMarcas()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == string.Empty) return;
            c = new Marca()
            {
                nome = txtMarca.Text
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        void limpaControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Marca()
            {
                nome = pesquisa
            };

            dgvMarcas.DataSource = c.Consultar();
        }

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                txtID.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvMarcas.CurrentRow.Cells["marca"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty) return;
            c = new Marca()
            {
                id = int.Parse(txtID.Text),
                nome = txtMarca.Text
            };
            c.Alterar();
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;
            if (MessageBox.Show("Deseja excluir a marca?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Marca() { id = int.Parse(txtID.Text) };
                c.Excluir();
                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
