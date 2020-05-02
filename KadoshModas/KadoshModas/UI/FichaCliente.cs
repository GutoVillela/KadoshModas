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
using KadoshModas.UI.UserControls;

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
                    ucTelefone ucTelefone = new ucTelefone();
                    ucTelefone.Telefone = telefone;
                    pnlTelefones.Controls.Add(ucTelefone);
                }
            }
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
