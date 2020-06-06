using System;
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
                lblValor.Text = new BoVenda().TotalDaVenda(Venda).ToString("C");
                lblSituacao.Text = DmoVenda.DescricaoEnum<DmoVenda.SituacoesVenda>(Venda.Situacao);

                if (Venda.Situacao != DmoVenda.SituacoesVenda.Concluido)
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
