﻿using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.Properties;
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
    public partial class VisaoGeral : Form
    {
        public VisaoGeral()
        {
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Monta o Ambiente Inicial de forma assíncrona
        /// </summary>
        private async Task MontarAmbienteInicialAsync()
        {
            try
            {
                List<DmoVenda> vendas = await new BoVenda().ConsultarAsync();

                #region Vendas da Semana
                int diaDaSemana = (int)DateTime.Today.DayOfWeek;
                int vendasDaSemana = vendas.FindAll(v => v.DataVenda > DateTime.Today.AddDays(-Convert.ToDouble(diaDaSemana))).Count();

                btnVendasDaSemana.Text = vendasDaSemana.ToString().PadLeft(3, '0');
                #endregion

                #region Vendas Em Aberto
                int vendasEmAberto = vendas.FindAll(v => v.Situacao == SituacaoVenda.EmAberto).Count();

                btnVendasEmAberto.Text = vendasEmAberto.ToString().PadLeft(3, '0');
                #endregion

                #region Clientes Inadimplentes
                List<int?> idClientesInadimplentes = new List<int?>();
                foreach (DmoVenda venda in vendas)
                {
                    if (venda.ParcelasDaVenda != null && venda.ParcelasDaVenda.Any(p => p.SituacaoParcela == SituacaoParcela.EmAberto))
                    {
                        if (venda.ParcelasDaVenda.First().Vencimento < DateTime.Today)
                        {
                            if (!idClientesInadimplentes.Any(c => c == venda.Cliente.IdCliente))
                                idClientesInadimplentes.Add(venda.Cliente.IdCliente);
                        }
                    }
                }

                btnClientesInadimplentes.Text = idClientesInadimplentes.Count().ToString().PadLeft(3, '0');

                if (idClientesInadimplentes.Any())
                {
                    pnlClientesInadimplentes.BackgroundImage = Resources.retangulo_vermelho_claro;
                    btnRotuloClientesInadimplentes.ForeColor = Color.FromArgb(192, 0, 0);
                    btnClientesInadimplentes.ForeColor = Color.FromArgb(192, 0, 0);
                    picClientesInadimplentes.IconChar = FontAwesome.Sharp.IconChar.Frown;
                    picClientesInadimplentes.IconColor = Color.FromArgb(192, 0, 0);
                }
                else
                {
                    pnlClientesInadimplentes.BackgroundImage = Resources.retangulo_verde_claro;
                    btnRotuloClientesInadimplentes.ForeColor = Color.DarkGreen;
                    btnClientesInadimplentes.ForeColor = Color.DarkGreen;
                    picClientesInadimplentes.IconChar = FontAwesome.Sharp.IconChar.Smile;
                    picClientesInadimplentes.IconColor = Color.DarkGreen;
                }
                #endregion
            }
            catch (Exception erro)
            {
                MessageBox.Show("Atenção! Aconteceu um erro ao carregar as estatísticas da loja. Por favor contacte o adminsitrador do sistema. Mensagem original: " + erro.Message, "Erro ao carregar estatísticas da loja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private async void VisaoGeral_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            await MontarAmbienteInicialAsync();
        }

        private void btnAtalhoCadVenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CadVenda());
        }

        private void btnAtalhoConCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ConCliente());
        }

        private void btnAtalhoConProd_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ConProduto());
        }
        #endregion
    }
}
