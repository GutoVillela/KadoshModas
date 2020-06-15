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
    /// Classe BLL para Estado
    /// </summary>
    class BoEstado
    {
        /// <summary>
        /// Consulta todos os Estados de forma assíncrona
        /// </summary>
        /// <returns>Retorna uma lista de DmoEstado com todos os Estados da base</returns>
        public async Task<List<DmoEstado>> ConsultarAsync()
        {
            return await new DaoEstado().ConsultarAsync();
        }
    }
}
