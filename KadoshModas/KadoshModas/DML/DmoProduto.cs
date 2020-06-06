using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Produto
    /// </summary>
    public class DmoProduto : DmoBase
    {
        #region Propriedades de Produto
        /// <summary>
        /// Id do Produto
        /// </summary>
        public int? IdProduto { get; set; }

        /// <summary>
        /// Código de Barras do Produto
        /// </summary>
        public string CodigoDeBarra { get; set; }

        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Preço do Produto
        /// </summary>
        public float Preco { get; set; }

        /// <summary>
        /// URL da foto do Produto
        /// </summary>
        public string UrlFoto { get; set; }

        /// <summary>
        /// Categoria do Produto
        /// </summary>
        public DmoCategoria Categoria { get; set; }

        /// <summary>
        /// Marca do Produto
        /// </summary>
        public DmoMarca Marca { get; set; }

        /// <summary>
        /// Atributos do Produto
        /// </summary>
        public List<DmoAtributosDoProduto> Atributos { get; set; }

        /// <summary>
        /// Lista de Fornecedores que fornecem o Produto
        /// </summary>
        public List<DmoFornecedor> Fornecedores { get; set; }
        #endregion
    }
}
