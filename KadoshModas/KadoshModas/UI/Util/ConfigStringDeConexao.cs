using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI.Util
{
    public partial class ConfigStringDeConexao : Form
    {
        #region Construtor
        public ConfigStringDeConexao()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void ConfigStringDeConexao_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string servidor = txtServidor.Text.Trim();
                string bd = txtBancoDeDados.Text.Trim();

                new INF.ParametrosDoSistema().ConfigurarStringDeConexao(servidor, bd);

                MessageBox.Show("String de Conexão configurada com sucesso!", "String de conexão configurada com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro ao tentar acessar configurar a string de conexão! Por favor entre em contato com o Administrador! Mensagem original: " + erro.Message, "Erro ao configurar a string de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
    }
}
