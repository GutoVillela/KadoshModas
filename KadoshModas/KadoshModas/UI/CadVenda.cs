using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI
{
    public partial class CadVenda : Form
    {
        public CadVenda()
        {
            InitializeComponent();
        }

        #region Propriedades
        private DmoVenda _venda;

        private float _totalVenda;

        /// <summary>
        /// Propriedade utilizada como base para realizar o cadastro da nova Venda
        /// </summary>
        private DmoVenda Venda 
        { 
            get { return _venda; } 
            set 
            {
                _venda = value;
            } 
        }
        #endregion

        #region Métodos
        private void AdicionarItemDaVenda(DmoItemDaVenda pItemDaVenda)
        {
            if(pItemDaVenda != null)
            {
                pItemDaVenda.Valor = pItemDaVenda.Produto.Preco;

                //Verificar se Item da Venda já havia sido adicionado anteriormente
                if (Venda.ItensDaVenda.Any(item => item.Produto.IdProduto == pItemDaVenda.Produto.IdProduto))
                {
                    //Incrementar uma unidade do produto
                    pItemDaVenda.Quantidade = ++Venda.ItensDaVenda.Find(item => item.Produto.IdProduto == pItemDaVenda.Produto.IdProduto).Quantidade;

                    //Encontrar linha que contém o Item da Venda
                    DataGridViewRow row = dgvItensDaVenda.Rows.Cast<DataGridViewRow>().Where(item => item.Cells["Codigo"].Value.ToString().Equals(pItemDaVenda.Produto.IdProduto.ToString())).FirstOrDefault();

                    row.Cells["Quantidade"].Value = int.Parse(row.Cells["Quantidade"].Value.ToString()) + 1;
                    row.Cells["Subtotal"].Value = (pItemDaVenda.Produto.Preco * pItemDaVenda.Quantidade).ToString("C");
                }
                else
                {
                    //Caso seja a primeira unidade adicionada, informar que temos apenas uma unidade
                    pItemDaVenda.Quantidade = 1;
                    dgvItensDaVenda.Rows.Add(
                        pItemDaVenda.Produto.IdProduto,
                        pItemDaVenda.Produto.Nome,
                        pItemDaVenda.Quantidade,
                        pItemDaVenda.Produto.Preco.ToString("C"),
                        (pItemDaVenda.Produto.Preco * pItemDaVenda.Quantidade).ToString("C")
                    );

                    dgvItensDaVenda.Rows[dgvItensDaVenda.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = pItemDaVenda;

                    Venda.ItensDaVenda.Add(pItemDaVenda);
                }

                AtualizarTotal();
            }
        }

        private void AtualizarTotal()
        {
            float total = 0;

            foreach (DmoItemDaVenda item in Venda.ItensDaVenda)
            {
                total += item.Valor;
            }

            lblTotalVenda.Text = total.ToString("C");
        }
        #endregion

        #region Eventos
        private void CadVenda_Load(object sender, EventArgs e)
        {
            Venda = new DmoVenda();
        }

        private void btnDefinirCliente_Click(object sender, EventArgs e)
        {
            new ConClienteVenda().ShowDialog();
            Venda.Cliente = ConClienteVenda.ClienteEscolhido;

            if(Venda.Cliente != null)
            {
                btnDefinirCliente.BackColor = Color.Green;
                btnDefinirCliente.IconChar = FontAwesome.Sharp.IconChar.Check;
                btnDefinirCliente.IconColor = Color.LightGreen;
                btnDefinirCliente.Text = Venda.Cliente.Nome;
            }
            else
            {
                btnDefinirCliente.BackColor = Color.DarkRed;
                btnDefinirCliente.IconChar = FontAwesome.Sharp.IconChar.Times;
                btnDefinirCliente.IconColor = Color.LightPink;
                btnDefinirCliente.Text = "Não definido";
            }
        }

        private void btnRemoverCliente_Click(object sender, EventArgs e)
        {
            Venda.Cliente = null;
            btnDefinirCliente.BackColor = Color.DarkRed;
            btnDefinirCliente.IconChar = FontAwesome.Sharp.IconChar.Times;
            btnDefinirCliente.IconColor = Color.LightPink;
            btnDefinirCliente.Text = "Não definido";
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            new ConProdutosVenda().ShowDialog();
            AdicionarItemDaVenda(ConProdutosVenda.ProdutoEscolhido);
            ConProdutosVenda.ProdutoEscolhido = null;
        }
        #endregion
    }
}
