using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.INF
{
    /// <summary>
    /// Classe de infraestrutura que define os diretórios do sistema
    /// </summary>
    class DiretoriosDoSistema
    {
        /// <summary>
        /// Diretório aonde serão gravados as informações de configuração do sistema (caso não exista, será criado e seu caminho retornado em uma string)
        /// </summary>
        public static string DIR_ARQUIVOS_DE_CONFIGURACAO
        {
            get { return Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\Config").FullName; }
        }

        /// <summary>
        /// Diretório aonde serão salvas as fotos dos Clientes (caso não exista, será criado e seu caminho retornado em uma string)
        /// </summary>
        public static string DIR_FOTOS_CLIENTES
        {
            get { return Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\FotosClientes").FullName; }
        }

        /// <summary>
        /// Diretório aonde serão salvas as fotos dos Produtos (caso não exista, será criado e seu caminho retornado em uma string)
        /// </summary>
        public static string DIR_FOTOS_PRODUTOS
        {
            get { return Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\FotosProdutos").FullName; }
        }

        /// <summary>
        /// Diretório aonde estão salvos os relatórios (arquivos RDLC).
        /// </summary>
        public static string DIR_RELATORIOS
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath) + @"\..\..\Relatorios"; }
        }
    }
}
