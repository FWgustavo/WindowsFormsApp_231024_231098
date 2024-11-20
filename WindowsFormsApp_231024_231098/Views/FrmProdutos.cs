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
            cboMarca.DisplayMember = "nome";
            cboMarca.ValueMember = "id";

            c = new Categoria();
            cboCategoria.DataSource = c.Consultar();
            cboCategoria.DisplayMember = "nome";
            cboCategoria.ValueMember = "id";

            limpaControles();
            carregarGrid("");
        }

        void carregarGrid(string pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };

            dgvProdutos.DataSource = p.Consultar();
        }
    }
}
