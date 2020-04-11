using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Fornecedor
    /// </summary>
    public class DmoFornecedor : DmoBase
    {
        #region Propriedades
        /// <summary>
        /// Id do Fornecedor
        /// </summary>
        public int? IdFornecedor { get; set; }

        /// <summary>
        /// Nome do Fornecedor
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CNPJ do Fornecedor
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        /// Endereço do Fornecedor
        /// </summary>
        public DmoEndereco Endereco { get; set; }

        /// <summary>
        /// Lista de Telefones do Fornecedor
        /// </summary>
        public List<DmoTelefoneDoFornecedor> Telefones { get; set; }

        /// <summary>
        /// Lista de Produtos que este Fornecedor fornece
        /// </summary>
        public List<DmoProduto> ProdutosQueFornece { get; set; }
        #endregion
    }
}
