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
    class DmoProduto
    {
        #region Propriedades de Produto
        /// <summary>
        /// Id do Produto
        /// </summary>
        public int? IdProduto { get; set; }

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
        /// Data de criação do registro na base de dados
        /// </summary>
        public DateTime DataDeCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro na base de dados
        /// </summary>
        public DateTime DataDeAtualizacao { get; set; }
        #endregion
    }
}
