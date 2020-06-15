using KadoshModas.BLL;
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
        #region Construtor
        public CadVenda()
        {
            InitializeComponent();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributo que define se formulário emitirá mensagem de confirmação antes de fechar
        /// </summary>
        private bool _confirmaFechamentoForm = true;
        #endregion

        #region Propriedades

        private float _totalVenda;

        /// <summary>
        /// Propriedade utilizada como base para realizar o cadastro da nova Venda
        /// </summary>
        private DmoVenda Venda { get; set; }
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

        /// <summary>
        /// Atualiza o Total da Venda com base nos itens adicionados na propriedade Venda e exibe o resultado atualizado na Label de Total da tela
        /// </summary>
        private void AtualizarTotal()
        {
            _totalVenda = 0;

            foreach (DmoItemDaVenda item in Venda.ItensDaVenda)
            {
                _totalVenda += item.Valor * item.Quantidade;
            }

            lblTotalVenda.Text = _totalVenda.ToString("C");
        }

        /// <summary>
        /// Fecha a Venda utilizando as informações já definidas em Tela
        /// </summary>
        private void FecharVendaCliente()
        {
            if (!Venda.ItensDaVenda.Any())
            {
                MessageBox.Show("É obrigatório acrescentar pelo menos um produto para fechar a venda!", "Não foi possível fechar a venda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new FecharVenda(this.Venda).ShowDialog();

                switch (FecharVenda.SituacaoVenda)
                {
                    case FecharVenda.SituacoesVenda.Sucesso:
                        _confirmaFechamentoForm = false;
                        AbrirFormulario(new VisaoGeral());
                        break;

                    case FecharVenda.SituacoesVenda.Indefinido:
                        break;

                    case FecharVenda.SituacoesVenda.VendaCancelada:
                        if (MessageBox.Show("Deseja continuar Fechando esta venda?", "Venda Cancelada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            _confirmaFechamentoForm = false;
                            AbrirFormulario(new VisaoGeral());
                        }
                        break;

                    case FecharVenda.SituacoesVenda.Erro:
                        if (MessageBox.Show("Venda Cancelada por causa de erro! Gostaria de tentar Fechar esta venda novamente?", "Venda Cancelada por Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            FecharVendaCliente();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Abre um Formulário na Tela Principal
        /// </summary>
        /// <param name="pFormulario">Formulário a ser aberto</param>
        private void AbrirFormulario(Form pFormulario)
        {
            pFormulario.TopLevel = false;
            pFormulario.FormBorderStyle = FormBorderStyle.None;
            pFormulario.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(pFormulario);
            this.Parent.Tag = pFormulario;
            pFormulario.BringToFront();
            pFormulario.Show();
            this.Close();
        }
        #endregion

        #region Eventos
        private async void CadVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            Venda = new DmoVenda();
            lblNumeroVenda.Text = (await new BoVenda().ContarVendasAsync() + 1).ToString().PadLeft(5, '0');
        }

        private void btnDefinirCliente_Click(object sender, EventArgs e)
        {
            new ConClienteVenda().ShowDialog();
            Venda.Cliente = ConClienteVenda.ClienteEscolhido;

            if(Venda.Cliente != null && Venda.Cliente.IdCliente != DmoCliente.IdClienteIndefinido)
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
            Venda.Cliente = new DmoCliente() { IdCliente = DmoCliente.IdClienteIndefinido };
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

        private void dgvItensDaVenda_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvItensDaVenda.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 2)
            {
                int idProduto = int.Parse(dgvItensDaVenda.Rows[e.RowIndex].Cells[0].Value.ToString());
                int qtd = int.Parse(dgvItensDaVenda.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                
                //Verificar se quantidade é menor ou igual a zero
                if(qtd <= 0)
                {
                    //Remover produto da lista
                    Venda.ItensDaVenda.Remove(Venda.ItensDaVenda.Find(item => item.Produto.IdProduto == idProduto));
                    dgvItensDaVenda.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    //Atualizar subtotal da Venda
                    float preco = float.Parse(dgvItensDaVenda.Rows[e.RowIndex].Cells[3].Value.ToString().Replace("R$", ""));
                    float subtotal = qtd * preco;

                    dgvItensDaVenda.Rows[e.RowIndex].Cells["Subtotal"].Value = subtotal.ToString("C");

                    Venda.ItensDaVenda.Find(item => item.Produto.IdProduto == idProduto).Quantidade = uint.Parse(qtd.ToString());
                }

                AtualizarTotal();
            }
        }

        private void btnFecharVenda_Click(object sender, EventArgs e)
        {
            FecharVendaCliente();
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quer mesmo cancelar a venda?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _confirmaFechamentoForm = false;
                AbrirFormulario(new VisaoGeral());
            }
        }

        private void CadVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_confirmaFechamentoForm && MessageBox.Show("Quer mesmo cancelar a venda?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        private void dtpDataVenda_ValueChanged(object sender, EventArgs e)
        {
            Venda.DataVenda = dtpDataVenda.Value;
        }
    }
}
