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
    /// <summary>
    /// Gera uma instância de UserControl usado para listar Telefones
    /// </summary>
    public partial class ucTelefone : UserControl
    {
        public ucTelefone()
        {
            InitializeComponent();
        }

        #region Propriedades
        /// <summary>
        /// Atributo usado para obter informações do Telefone a ser exibido (não manipular este atributo, utilize a propriedade Telefone)
        /// </summary>
        private DmoTelefone _telefone;

        /// <summary>
        /// Propriedade que contém o Telefone a ser exibido no UserControl
        /// </summary>
        public DmoTelefone Telefone
        {
            get { return _telefone; }
            set 
            { 
                _telefone = value;
                txtDDD.Text = Telefone.DDD;
                txtNumero.Text = Telefone.Numero;

                if (Telefone.TipoDeTelefone == DmoTelefone.TiposDeTelefone.Residencial)
                    picTelefone.IconChar = FontAwesome.Sharp.IconChar.Mobile;
                else if(Telefone.TipoDeTelefone == DmoTelefone.TiposDeTelefone.Comercial)
                    picTelefone.IconChar = FontAwesome.Sharp.IconChar.PhoneAlt;
                else if (Telefone.TipoDeTelefone == DmoTelefone.TiposDeTelefone.WhatsApp)
                    picTelefone.IconChar = FontAwesome.Sharp.IconChar.Whatsapp;
                else if (Telefone.TipoDeTelefone == DmoTelefone.TiposDeTelefone.NumeroDeParente)
                    picTelefone.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
                else if (Telefone.TipoDeTelefone == DmoTelefone.TiposDeTelefone.NumeroDeConhecido)
                    picTelefone.IconChar = FontAwesome.Sharp.IconChar.Voicemail;
                else if (Telefone.TipoDeTelefone == DmoTelefone.TiposDeTelefone.Outro)
                    picTelefone.IconChar = FontAwesome.Sharp.IconChar.Phone;

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(picTelefone, Telefone.TipoDeTelefone.DescricaoEnum());
            }
        }

        #endregion

        #region Eventos
        private void ucTelefone_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width - SystemInformation.VerticalScrollBarWidth;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
        #endregion


    }
}
