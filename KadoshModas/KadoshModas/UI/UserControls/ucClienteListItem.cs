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

namespace KadoshModas.UI.UserControls
{
    public partial class ucClienteListItem : UserControl
    {
        /// <summary>
        /// Gera uma instância de UserControl usado para listar Clientes
        /// </summary>
        public ucClienteListItem()
        {
            InitializeComponent();
        }

        #region Propriedades
        private DmoCliente _cliente;
        /// <summary>
        /// DmoCliente com as informações do cliente a serem manipuladas pelo UserControl
        /// </summary>
        public DmoCliente Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                if (!string.IsNullOrEmpty(_cliente.Nome))
                    lblNomeCliente.Text = _cliente.Nome;

                if (!string.IsNullOrEmpty(_cliente.UrlFoto))
                    picFotoCliente.Image = new Bitmap(_cliente.UrlFoto);
            }
        }
        #endregion

        #region Eventos
        private void ucClienteListItem_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width - SystemInformation.VerticalScrollBarWidth - 20;
        }

        private void btnVerFicha_Click(object sender, EventArgs e)
        {
            new FichaCliente(Cliente).ShowDialog();
        }
        #endregion


    }
}
