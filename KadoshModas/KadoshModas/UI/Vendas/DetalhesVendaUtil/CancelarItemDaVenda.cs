using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.UI.Dialogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI.DetalhesVendaUtil
{
    public partial class CancelarItemDaVenda : Form
    {
        #region Construtor(es)
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public CancelarItemDaVenda()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construtor que define Item da Venda a cancelar e Venda
        /// </summary>
        /// <param name="pItemDaVenda">Item da Venda</param>
        public CancelarItemDaVenda(DmoItemDaVenda pItemDaVenda, DmoVenda pVenda)
        {
            InitializeComponent();
            ItemDaVenda = pItemDaVenda;
            Venda = pVenda;

            txtQtdItensACancelar.Text = "1";
            chkCancelarTodos.Checked = ItemDaVenda.Quantidade == 1;
            chkCancelarTodos.Enabled = !chkCancelarTodos.Checked;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Item da Venda a ser cancelado
        /// </summary>
        private DmoItemDaVenda ItemDaVenda { get; set; }

        /// <summary>
        /// Venda relacionada ao Item da Venda. 
        /// </summary>
        private DmoVenda Venda { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Processa o cancelamento do Item da Venda com base nas informações fornecidas em tela.
        /// </summary>
        /// <returns></returns>
        private async Task ProcessarCancelamentoDoItem()
        {
            #region Atualizar Situação dos Itens da Venda
            uint qtdInformada = Convert.ToUInt32(txtQtdItensACancelar.Text);

            // Se nem todos os produtos foram cancelados, é necessário criar outro registro de Item da Venda atualizando a quantidade de Itens
            if (qtdInformada < ItemDaVenda.Quantidade)
            {
                DmoItemDaVenda itensNaoCancelados = (DmoItemDaVenda)ItemDaVenda.Clone();
                itensNaoCancelados.Quantidade -= qtdInformada;

                await new BoItemDaVenda().AtualizarAsync(itensNaoCancelados);
            }
            else
            {
                await new BoItemDaVenda().ApagarAsync(ItemDaVenda);
            }

            SituacaoItemDaVenda situacaoItem;
            string descricaoSituacao;

            #region Definindo propriedades da nova situação do Item da Venda
            if (rdoClienteDesistiuDoProduto.Checked)
            {
                situacaoItem = SituacaoItemDaVenda.Cancelado;
                descricaoSituacao = rdoClienteDesistiuDoProduto.Text;
            }
            else if (rdoProdutoComDefeito.Checked)
            {
                situacaoItem = SituacaoItemDaVenda.Cancelado;
                descricaoSituacao = rdoProdutoComDefeito.Text;
            }
            else if (rdoProdutoNaoServiu.Checked)
            {
                situacaoItem = SituacaoItemDaVenda.Cancelado;
                descricaoSituacao = rdoProdutoNaoServiu.Text;
            }
            else
            {
                situacaoItem = SituacaoItemDaVenda.Trocado;
                descricaoSituacao = rdoTrocaItem.Text;
            }
            #endregion

            //Tratamento caso exista o mesmo Item com a mesma situação para a mesma Venda
            if (Venda.ItensDaVenda.Any(i => i.Situacao == situacaoItem && i.Produto.IdProduto == ItemDaVenda.Produto.IdProduto))
            {
                DmoItemDaVenda itemAtual = Venda.ItensDaVenda.Find(i => i.Situacao == situacaoItem && i.Produto.IdProduto == ItemDaVenda.Produto.IdProduto);
                itemAtual.Quantidade += qtdInformada;

                await new BoItemDaVenda().AtualizarAsync(itemAtual);
            }
            else
            {
                ItemDaVenda.Situacao = situacaoItem;
                ItemDaVenda.DescricaoSituacao = descricaoSituacao;
                ItemDaVenda.Quantidade = qtdInformada;
                await new BoItemDaVenda().CadastrarAsync(ItemDaVenda);
            }
            #endregion

            #region Atualizar Venda

            // Atualizar Total da Venda
            Venda.Total = await new BoVenda().CalcularEAtualizarTotalAsync(Convert.ToInt32(ItemDaVenda.Venda.IdVenda));

            if (Venda.Total < Venda.Pago)
            {
                double valorASerEstornado = Venda.Pago - Venda.Total;
                if(MessageBox.Show($"Foi identificado o valor de {valorASerEstornado:C} a ser estornado ao cliente depois de cancelar este item. Gostaria de lançar o valor de {valorASerEstornado:C} no fechamento de Caixa? Lançar este estorno no fechamento de caixa significa que o valor foi devolvido ao cliente.", "Identificamos valor a ser estornado ao cliente.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Venda.Pago -= valorASerEstornado;
                    await new BoVenda().AtualizarValorPagoAsync(Venda, Venda.Pago);

                    #region Registrar novo lançamento do Cliente para estorno
                    DmoLancamentoDoCliente lancamentoDoCliente = new DmoLancamentoDoCliente
                    {
                        Cliente = Venda.Cliente,
                        TipoLancamentoDoCliente = TipoLancamentoDoCliente.Estorno,
                        ValorLancamento = valorASerEstornado,
                        DataDoLancamento = DateTime.Now
                    };

                    await new BoLancamentoDoCliente().CadastrarAsync(lancamentoDoCliente);
                    #endregion

                    new AlertaPersonalizado().MostrarAlerta($"Valor de {valorASerEstornado:C} estornado ao cliente.", TipoAlerta.Sucesso);
                }
                else
                {
                    new AlertaPersonalizado().MostrarAlerta("ATENÇÃO! Estorno não identificado e não lançado.", TipoAlerta.Aviso);
                }
            }
            #endregion
            new AlertaPersonalizado().MostrarAlerta("Itens cancelados.", TipoAlerta.Sucesso);
            this.Close();
        }
        #endregion

        #region Eventos
        private void CancelarItemDaVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
        }

        private void txtQtdItensACancelar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQtdItensACancelar_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtQtdItensACancelar.Text.Trim(), out int qtdInformada))
            {
                if (qtdInformada > ItemDaVenda.Quantidade)
                {
                    chkCancelarTodos.Checked = true;
                    txtQtdItensACancelar.Text = ItemDaVenda.Quantidade.ToString();
                }
            }
        }

        private void chkCancelarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCancelarTodos.Checked)
                txtQtdItensACancelar.Text = ItemDaVenda.Quantidade.ToString();
            else
                txtQtdItensACancelar.Text = "1";
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
             await ProcessarCancelamentoDoItem();
        }
        #endregion
    }
}
