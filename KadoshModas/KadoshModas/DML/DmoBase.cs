using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML base para todas as classes DML. Contém propriedades comuns entre todas as classes DML
    /// </summary>
    public class DmoBase
    {
        #region Propriedades
        /// <summary>
        /// Define se o registro está ativo ou não
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data de criação do registro na base de dados
        /// </summary>
        public DateTime DataDeCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro na base de dados
        /// </summary>
        public DateTime DataDeAtualizacao { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Busca as Descrições e os Valores de todos os membros do Enum
        /// </summary>
        /// <typeparam name="T">Tipo do Enum</typeparam>
        /// <param name="pEnum">Enum</param>
        /// <returns>Retorna pares de valor com Descrição (recuperado do atributo Description) e Valor do Enum</returns>
        public SortedDictionary<string, int> DescricoesEnum<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("pEnum deve ser do tipo Enum");
                

            SortedDictionary<string, int> paresDeValor = new SortedDictionary<string, int>();

            foreach (Enum tipo in Enum.GetValues(typeof(T)))
            {
                paresDeValor.Add(DescricaoEnum<T> (tipo), Convert.ToInt32(tipo));
            }

            return paresDeValor;
        }

        /// <summary>
        /// Busca o atributo Description de um item do Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEnum"></param>
        /// <returns></returns>
        public string DescricaoEnum<T>(Enum pEnum) where T : struct, IComparable, IFormattable, IConvertible
        {
            if (pEnum.GetType().IsEnum)
            {
                try
                {
                    if(pEnum.GetType().GetMember(pEnum.GetType().GetEnumName(pEnum))[0].GetCustomAttributes(typeof(DescriptionAttribute), false).Any())
                        return (pEnum.GetType().GetMember(pEnum.GetType().GetEnumName(pEnum))[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute).Description;
                    else
                        return pEnum.ToString();
                }
                catch
                {
                    return pEnum.ToString();
                }
            }
            else
                throw new ArgumentException("pEnum deve ser do tipo Enum");
        }
        #endregion
    }
}
