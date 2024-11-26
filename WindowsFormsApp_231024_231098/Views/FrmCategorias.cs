using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_231024_231098.Models;

namespace WindowsFormsApp_231024_231098.Views
{
    public partial class FrmCategorias : Form
    {
        Categoria c;
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty) return;
            c = new Categoria()
            {
                nome = txtNome.Text
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty) return;
            c = new Categoria()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text
            };
            c.Alterar();
            limpaControles();
            carregarGrid("");
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Categoria()
            {
                nome = pesquisa
            };

            dgvCategoria.DataSource = c.Consultar();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.RowCount > 0)
            {
                txtID.Text = dgvCategoria.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCategoria.CurrentRow.Cells["categoria"].Value.ToString();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "") return;
            if (MessageBox.Show("Deseja excluir a categoria?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Categoria() { id = int.Parse(txtID.Text) };
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
