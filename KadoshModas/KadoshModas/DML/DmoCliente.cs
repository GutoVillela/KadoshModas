using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    public class DmoCliente : DmoBase
    {
        #region Propriedades de Cliente

        /// <summary>
        /// Id do Cliente
        /// </summary>
        public int? IdCliente { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// E-mail do Cliente
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// CPF do Cliente
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Sexo do Cliente
        /// </summary>
        public Sexos Sexo { get; set; }

        /// <summary>
        /// Endereço do Cliente
        /// </summary>
        public DmoEndereco Endereco { get; set; }

        /// <summary>
        /// URL da Foto do cliente
        /// </summary>
        public string UrlFoto { get; set; }

        /// <summary>
        /// Lista de telefones do Cliente
        /// </summary>
        public List<DmoTelefone> Telefones { get; set; }

        /// <summary>
        /// Sexos
        /// </summary>
        public enum Sexos
        {
            Feminino,

            Masculino
        }
        #endregion
    }
}
