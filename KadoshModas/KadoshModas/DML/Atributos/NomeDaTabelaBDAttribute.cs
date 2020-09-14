using System;

namespace KadoshModas.DML
{
    /// <summary>
    /// Atributo que define o nome da tabela no banco de dados relacionada à classe DML
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class NomeDaTabelaBDAttribute : Attribute
    {
        #region Construtor
        /// <summary>
        /// Construtor padrão do atributo NomeDaTabelaBD
        /// </summary>
        /// <param name="pNomeTabelaBD">Nome da tabela no Banco de Dados</param>
        public NomeDaTabelaBDAttribute(string pNomeTabelaBD)
        {
            _nomeTabelaBD = pNomeTabelaBD;
        }
        #endregion

        #region Campos Privados
        /// <summary>
        /// Campo que define o nome da tabela no banco de dados
        /// </summary>
        private string _nomeTabelaBD;
        #endregion

        #region Propriedades
        /// <summary>
        /// Define o nome da tabela no banco de dados
        /// </summary>
        public virtual string NomeTabelaBD { get { return _nomeTabelaBD; } }
        #endregion
    }
}