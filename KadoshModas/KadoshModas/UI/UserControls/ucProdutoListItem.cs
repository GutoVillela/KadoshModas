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
using KadoshModas.INF;

namespace KadoshModas.UI.UserControls
{
    public partial class ucProdutoListItem : UserControl
    {
        public ucProdutoListItem()
        {
            InitializeComponent();
        }

        #region Propriedades
        private DmoProduto _produto;

        /// <summary>
        /// DmoProduto com as informações do Produto a serem manipuladas pelo UserControl
        /// </summary>
        public DmoProduto Produto
        {
            get { return _produto; }
            set
            {
                _produto = value;

                lblNomeProduto.Text = Produto.Nome;
                lblValorProduto.Text = Produto.Preco.ToString("C");

                if (!string.IsNullOrEmpty(Produto.UrlFoto))
                    picFotoProduto.Image = new Bitmap(Produto.UrlFoto);
            }
        }
        #endregion

        #region Eventos
        private void ucProdutoListItem_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width - SystemInformation.VerticalScrollBarWidth - 20;
        }

        private void btnDetalhesProduto_Click(object sender, EventArgs e)
        {
            new CadProduto(Produto).ShowDialog();
        }
        #endregion
    }
}
