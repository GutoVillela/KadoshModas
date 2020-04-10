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
    public partial class FichaCliente : Form
    {
        #region Construtor
        public FichaCliente(DmoCliente pCliente)
        {
            InitializeComponent();
            CarregarCliente(pCliente);
        }
        #endregion

        #region Métodos
        private void CarregarCliente(DmoCliente pCliente)
        {
            if (!string.IsNullOrEmpty(pCliente.UrlFoto))
                picFotoCliente.Image = Image.FromFile(pCliente.UrlFoto);

            txtNomeCliente.Text = pCliente.Nome;
            txtCPF.Text = string.IsNullOrEmpty(pCliente.CPF) ? "Não definido" : pCliente.CPF;
            cbSexo.Text = pCliente.DescricaoEnum<DmoCliente.Sexos>(pCliente.Sexo);
            txtRua.Text = (pCliente.Endereco != null && !string.IsNullOrEmpty(pCliente.Endereco.Rua)) ? pCliente.Endereco.Rua : "Não cadastrado";
            txtBairro.Text = (pCliente.Endereco != null && !string.IsNullOrEmpty(pCliente.Endereco.Bairro)) ? pCliente.Endereco.Bairro : "Não cadastrado";

            //Telefones do Cliente
            if(pCliente.Telefones != null && pCliente.Telefones.Any())
            {
                foreach(DmoTelefone telefone in pCliente.Telefones)
                {
                    Panel pnlTelefone = GerarPanelDeTelefone(telefone);
                    pnlTelefones.Controls.Add(pnlTelefone);
                    pnlTelefones.Height += pnlTelefone.Height;
                }
            }
        }

        /// <summary>
        /// Gera um Panel contendo os controles necessários para exibição do Telefone na tela
        /// </summary>
        /// <returns>Retona um Panel com Controles necessários para exibição do Telefone</returns>
        private Panel GerarPanelDeTelefone(DmoTelefone pTelefone)
        {
            Panel pnlTelefone = new Panel
            {
                Dock = DockStyle.Top
            };

            Label lblDDD = new Label
            {
                Text = "DDD: ",
                Dock = DockStyle.Left
            };

            TextBox txtDDD = new TextBox
            {
                Text = pTelefone.DDD,
                Dock = DockStyle.Left
            };

            Label lblTelefone = new Label
            {
                Text = "Telefone:",
                Dock = DockStyle.Left
            };

            TextBox txtTelefone = new TextBox
            {
                Text = pTelefone.Numero,
                Dock = DockStyle.Left
            };

            pnlTelefone.Controls.Add(txtTelefone);
            pnlTelefone.Controls.Add(lblTelefone);
            pnlTelefone.Controls.Add(txtDDD);
            pnlTelefone.Controls.Add(lblDDD);

            return pnlTelefone;
        }
        #endregion

        #region Eventos
        private void FichaCliente_Load(object sender, EventArgs e)
        {
            //Formulário
            this.Size = INF.ParametrosDoSistema.TAMANHO_FORMULARIOS;
        }
        #endregion
    }
}
