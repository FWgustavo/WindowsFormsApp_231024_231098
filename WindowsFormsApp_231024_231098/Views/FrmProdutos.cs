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
    public partial class FrmProdutos : Form
    {
        Produto p;
        Categoria c;
        Marca m;

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                estoque = decimal.Parse(txtEstoque.Text),
                valorVenda = decimal.Parse(txtVlrVenda.Text),
            };
            p.Incluir();

            limpaControles();
            carregarGrid("");
        }


        void limpaControles()
        {
            txtID.Clear();
            txtDescricao.Clear();
            txtEstoque.Clear();
            txtConsulta.Clear();
            txtVlrVenda.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            m = new Marca();
            cboMarca.DataSource = m.Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";

            c = new Categoria();
            cboCategoria.DataSource = c.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";

            limpaControles();
            carregarGrid("");

            dgvProdutos.Columns["idMarca"].Visible = false;
            dgvProdutos.Columns["idCategoria"].Visible = false;
        }


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            p = new Produto()
            {
                id = int.Parse(txtID.Text),
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                estoque = decimal.Parse(txtEstoque.Text),
                valorVenda = decimal.Parse(txtVlrVenda.Text),
            };
            p.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir o Produto?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p = new Produto()
                {
                    id = int.Parse(txtID.Text),
                };
                p.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtConsulta.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        void carregarGrid(string consulta)
        {
            p = new Produto()
            {
                descricao = consulta,
            };
            dgvProdutos.DataSource = p.Consultar();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboCategoria.Text = dgvProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                cboMarca.Text = dgvProdutos.CurrentRow.Cells["marca"].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                txtVlrVenda.Text = dgvProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();
            }
        }

    }
}
