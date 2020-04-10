using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DMO para Endereço
    /// </summary>
    public class DmoEndereco : DmoBase
    {
        #region Propriedades de Endereço
        /// <summary>
        /// Id do endereço
        /// </summary>
        public int? IdEndereco { get; set; }

        /// <summary>
        /// Rua
        /// </summary>
        public string Rua { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        public string CEP { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public DmoCidade Cidade { get; set; }
        #endregion
    }

    /// <summary>
    /// Classe DMO para Cidade
    /// </summary>
    public class DmoCidade
    {
        #region Propriedades de Cidade
        /// <summary>
        /// Id da Cidade
        /// </summary>
        public int? IdCidade { get; set; }

        /// <summary>
        /// Nome da Cidade
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Unidade Federativa (estado) da Cidade
        /// </summary>
        public DmoEstado Estado { get; set; }

        /// <summary>
        /// IBGE da Cidade
        /// </summary>
        public int IBGE { get; set; }
        #endregion
    }

    /// <summary>
    /// Classe DMO para Estado
    /// </summary>
    public class DmoEstado
    {
        #region Propriedades de Estado
        /// <summary>
        /// Id do Estado
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// Nome do Estado
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sigla da Unidade Federativa (UF) do Estado
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        /// Número do IBGE do Estado
        /// </summary>
        public int IBGE { get; set; }

        /// <summary>
        /// País do Estado
        /// </summary>
        public DmoPais Pais { get; set; }

        /// <summary>
        /// DDD do Estado
        /// </summary>
        public string DDD { get; set; }
        #endregion
    }

    public class DmoPais
    {
        #region Propriedades do País
        /// <summary>
        /// Id do País
        /// </summary>
        public int IdPais { get; set; }

        /// <summary>
        /// Nome do País
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Nome do País em Português do Brasil
        /// </summary>
        public string NomePt { get; set; }

        /// <summary>
        /// Sigla do País
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// Número do Bacen do País
        /// </summary>
        public int Bacen { get; set; }
        #endregion
    }
}
