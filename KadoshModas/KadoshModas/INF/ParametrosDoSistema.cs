using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.INF
{
    /// <summary>
    /// Classe de Infraestrutuda contendo os parâmetros do sistema
    /// </summary>
    class ParametrosDoSistema
    {
        #region Propriedades
        /// <summary>
        /// Constante que define o tamanho padrão que todos os formulários devem assumir para encaixarem na Tela Principal. O tamanho desta constante deve ser igual ao Panel que receberá os formulários na tela principal
        /// </summary>
        public static readonly Size TAMANHO_FORMULARIOS = new Size { Width = 934, Height = 661 };

        /// <summary>
        /// Propriedade que define quantos Cliente serão buscadas por vez em uma busca paginada
        /// </summary>
        public static uint QuantidadeDeItensPorBuscaDeCliente = 20;
        #endregion
        #region Métodos
        /// <summary>
        /// Configura a string de Conexão padrão para o banco de dados Kadosh e Master, e persiste a configuração nas Propriedades
        /// </summary>
        /// <param name="pServidor">Nome do Servidor</param>
        /// <param name="pBd">Nome do Banco de dados</param>
        public void ConfigurarStringDeConexao(string pServidor, string pBd)
        {
            Properties.Settings.Default.StringDeConexaoKadosh = $"Server={pServidor}; Initial Catalog={pBd}; Integrated Security=true"; ;
            Properties.Settings.Default.StringDeConexaoMaster = $"Server={pServidor}; Initial Catalog=master; Integrated Security=true";
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
