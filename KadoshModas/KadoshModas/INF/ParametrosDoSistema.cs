using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Constante que define o tamanho padrão que todos os formulários devem assumir para encaixarem na Tela Principal. O tamanho desta constante deve ser igual ao Panel que receberá os formulários na tela principal
        /// </summary>
        public static readonly System.Drawing.Size TAMANHO_FORMULARIOS = new System.Drawing.Size { Width = 650, Height = 550 };
    }
}
