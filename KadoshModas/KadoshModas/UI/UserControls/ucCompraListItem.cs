﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KadoshModas.DML;
using KadoshModas.BLL;

namespace KadoshModas.UI.UserControls
{
    public partial class ucCompraListItem : UserControl
    {
        #region Construtor
        public ucCompraListItem()
        {
            InitializeComponent();
        }
        #endregion

        #region Propriedades
        private DmoVenda _venda;

        /// <summary>
        /// DmoVenda com as informações da Venda a serem manipuladas pelo UserControl
        /// </summary>
        public DmoVenda Venda
        {
            get { return _venda; }
            set 
            {
                _venda = value;

                lblData.Text = Venda.DataDeCriacao.ToString("dd/MM/yyyy");

                if (Venda.ItensDaVenda == null || !Venda.ItensDaVenda.Any())
                    lblValor.Text = Venda.Total.ToString("C");
                else
                    lblValor.Text = Venda.TotalDaVenda().ToString("C");


                lblSituacao.Text = Venda.Situacao.DescricaoEnum();

                if (Venda.Situacao != SituacaoVenda.Concluido)
                    btnDetalhesVenda.BackColor = Color.DarkBlue;
            }
        }
        #endregion

        #region Eventos
        private void ucCompraListItem_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width - SystemInformation.VerticalScrollBarWidth - 20;
        }

        private void btnDetalhesVenda_Click(object sender, EventArgs e)
        {
            new DetalhesVenda(Venda).ShowDialog();
        }
        #endregion
    }
}
