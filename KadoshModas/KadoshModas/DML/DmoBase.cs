using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML base para todas as classes DML. Contém propriedades comuns entre todas as classes DML
    /// </summary>
    public abstract class DmoBase : ICloneable
    {
        #region Propriedades
        /// <summary>
        /// Define se o registro está ativo ou não
        /// </summary>
        [CampoBD("ATIVO")]
        public bool Ativo { get; set; }

        /// <summary>
        /// Data de criação do registro na base de dados
        /// </summary>
        [CampoBD("DT_CRIACAO")]
        public DateTime DataDeCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro na base de dados
        /// </summary>
        [CampoBD("DT_ATUALIZACAO")]
        public DateTime DataDeAtualizacao { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Busca as Descrições e os Valores de todos os membros do Enum
        /// </summary>
        /// <typeparam name="T">Tipo do Enum</typeparam>
        /// <param name="pEnum">Enum</param>
        /// <returns>Retorna pares de valor com Descrição (recuperado do atributo Description) e Valor do Enum</returns>
        public static SortedDictionary<string, int> DescricoesEnum<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("pEnum deve ser do tipo Enum");
                

            SortedDictionary<string, int> paresDeValor = new SortedDictionary<string, int>();

            foreach (Enum tipo in Enum.GetValues(typeof(T)))
            {
                paresDeValor.Add(tipo.DescricaoEnum(), Convert.ToInt32(tipo));
            }

            return paresDeValor;
        }

        ///// <summary>
        ///// Busca o atributo Description de um item do Enum
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="pEnum"></param>
        ///// <returns></returns>
        //public static string DescricaoEnum<T>(Enum pEnum) where T : struct, IComparable, IFormattable, IConvertible
        //{
        //    if (pEnum.GetType().IsEnum)
        //    {
        //        try
        //        {
        //            if(pEnum.GetType().GetMember(pEnum.GetType().GetEnumName(pEnum))[0].GetCustomAttributes(typeof(DescriptionAttribute), false).Any())
        //                return (pEnum.GetType().GetMember(pEnum.GetType().GetEnumName(pEnum))[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute).Description;
        //            else
        //                return pEnum.ToString();
        //        }
        //        catch
        //        {
        //            return pEnum.ToString();
        //        }
        //    }
        //    else
        //        throw new ArgumentException("pEnum deve ser do tipo Enum");
        //}

        /// <summary>
        /// Recupera o nome da tabela no banco de dados associado ao objeto DMO.
        /// </summary>
        /// <typeparam name="T">Classe DMO .</typeparam>
        /// <returns>Retorna nome da tabela definida no atributo NomeDaTabelaBD para a classe DMO.</returns>
        public static string NomeDaTabela<T>() where T : DmoBase
        {
            Type tipo = typeof(T);
            if (!Attribute.IsDefined(tipo.Assembly, typeof(NomeDaTabelaBDAttribute)))
                throw new Exception("O atributo NomeDaTabela não está definido para o objeto DMO fornecido.");

            return (tipo.GetCustomAttributes(typeof(NomeDaTabelaBDAttribute), false).FirstOrDefault() as NomeDaTabelaBDAttribute).NomeTabelaBD;
        }

        /// <summary>
        /// Cria uma nova instância deste objeto com os mesmos valores
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }

    /// <summary>
    /// Classe que contém métodos de extensões utilizados nas classes DML
    /// </summary>
    public static class MetodosDeExtensaoDML
    {
        /// <summary>
        /// Recupera o valor do atributo Description associado ao Enum.
        /// </summary>
        /// <param name="pEnum">Enum</param>
        /// <returns>Retorna o valor do atributo description associado ao enum. Caso não exista é retornado o próprio enum.</returns>
        public static string DescricaoEnum(this Enum pEnum)
        {
            try
            {
                if (pEnum.GetType().GetMember(pEnum.GetType().GetEnumName(pEnum))[0].GetCustomAttributes(typeof(DescriptionAttribute), false).Any())
                    return (pEnum.GetType().GetMember(pEnum.GetType().GetEnumName(pEnum))[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute).Description;
                else
                    return pEnum.ToString();
            }
            catch
            {
                return pEnum.ToString();
            }
        }
    }
}
