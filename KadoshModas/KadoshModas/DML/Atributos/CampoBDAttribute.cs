using System;

namespace KadoshModas.DML
{
    /// <summary>
    /// Atributo que define o nome do campo na tabela do banco de dados relacionada à propriedade da classe DML
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class CampoBDAttribute : Attribute
    {
        #region Construtor
        /// <summary>
        /// Construtor padrão do atributo CampoBD
        /// </summary>
        /// <param name="pNomeCampoBD">Nome do Campo no Banco de Dados</param>
        public CampoBDAttribute(string pNomeCampoBD)
        {
            _nomeCampoBD = pNomeCampoBD;
        }
        #endregion

        #region Campos Privados
        /// <summary>
        /// Campo que define o nome do campo no banco de dados
        /// </summary>
        private string _nomeCampoBD;
        #endregion

        #region Propriedades
        /// <summary>
        /// Define o nome do campo no banco de dados
        /// </summary>
        public virtual string NomeCampoBD { get { return _nomeCampoBD; } }

        /// <summary>
        /// Define se campo é chave primária ou não
        /// </summary>
        public virtual bool ChavePrimaria { get; set; }
        #endregion
    }
}