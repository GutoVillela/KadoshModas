using KadoshModas.DAL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Cidade
    /// </summary>
    class BoCidade
    {
        /// <summary>
        /// Consulta todas as Cidades de um determinado Estado de forma assíncrona
        /// </summary>
        /// <returns>Retorna uma lista de DmoCidade com todas as Cidades do Estado especificado</returns>
        public async Task<List<DmoCidade>> ConsultarDoEstadoAsync(int pIdEstado)
        {
            return await new DaoCidade().ConsultarDoEstadoAsync(pIdEstado);
        }

        /// <summary>
        /// Consulta uma Cidade específica de forma assíncrona
        /// </summary>
        /// <param name="pIdCidade">Id da Cidade</param>
        /// <returns>Retorna Cidade Preenchida</returns>
        public async Task<DmoCidade> ConsultarCidadeAsync(int pIdCidade)
        {
            return await new DaoCidade().ConsultarCidadeAsync(pIdCidade);
        }
    }
}
