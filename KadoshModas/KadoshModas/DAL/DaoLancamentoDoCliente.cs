using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KadoshModas.DAL
{
    class DaoLancamentoDoCliente : DaoBase
    {
        #region Construtor(es)
        public DaoLancamentoDoCliente()
        {
            Conexao = new Conexao();
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        protected override Conexao Conexao { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um Lançamento do Cliente
        /// </summary>
        /// <param name="pLancamentoDoCliente">Objeto DmoLancamentoDoCliente preenchido.</param>
        public async Task CadastrarAsync(DmoLancamentoDoCliente pLancamentoDoCliente)
        {
            #region Obter nome dos campos
            string nomeCampoCliente = DmoLancamentoDoCliente.NomeDoCampo(() => pLancamentoDoCliente.Cliente);
            string nomeCampoTipoLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => pLancamentoDoCliente.TipoLancamentoDoCliente);
            string nomeCampoValorLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => pLancamentoDoCliente.ValorLancamento);
            string nomeCampoVenda = DmoLancamentoDoCliente.NomeDoCampo(() => pLancamentoDoCliente.Venda);
            string nomeCampoDataLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => pLancamentoDoCliente.DataDoLancamento);
            #endregion

            #region Montar e executar query
            SqlCommand cmd = new SqlCommand($"INSERT INTO {DmoLancamentoDoCliente.NomeTabela} ({nomeCampoCliente}, {nomeCampoTipoLancamento}, {nomeCampoValorLancamento}, {nomeCampoVenda}, {nomeCampoDataLancamento}) VALUES (@CLIENTE, @TIPO_LANCAMENTO_DO_CLIENTE, @VALOR_LANCAMENTO, @VENDA, @DT_LANCAMENTO)", await Conexao.ConectarAsync());

            cmd.Parameters.AddWithValue("@CLIENTE", pLancamentoDoCliente.Cliente.IdCliente).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@TIPO_LANCAMENTO_DO_CLIENTE", (int)pLancamentoDoCliente.TipoLancamentoDoCliente).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@VALOR_LANCAMENTO", pLancamentoDoCliente.ValorLancamento).SqlDbType = SqlDbType.SmallMoney;
            cmd.Parameters.AddWithValue("@VENDA", pLancamentoDoCliente.Venda == null ? DBNull.Value : TratarValorNulo(pLancamentoDoCliente.Venda.IdVenda)).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@DT_LANCAMENTO", TratarValorNulo(pLancamentoDoCliente.DataDoLancamento)).SqlDbType = SqlDbType.DateTime;

            await cmd.ExecuteNonQueryAsync();
            Conexao.Desconectar();
            #endregion
        }

        /// <summary>
        /// Consulta todos os Lançamentos do Cliente de forma assíncrona.
        /// </summary>
        /// <param name="pIdLancamentoDoCliente">Se fornecido, filtra a busca pelo Id do Lançamento do Cliente.</param>
        /// <param name="pCliente">Se fornecido, filtra a busca pelo ID do Cliente.</param>
        /// <param name="pTipoLancamento">Se fornecido, filtra a busca pelo Tipo de Lançamento.</param>
        /// <param name="pValorLancamento">Se fornecido, filtra a busca pelo Valor do Lançamento.</param>
        /// <param name="pVenda">Se fornecido, filtra a busca pelo ID da Venda.</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Lançamentos A PARTIR da Data Inicial fornecida.</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Lançamentos ATÉ a Data Final fornecida.</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido.</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido.</param>
        /// <returns>Retorna lista com Lançamentos encontrados</returns>
        public async Task<List<DmoLancamentoDoCliente>> ConsultarAsync(int? pIdLancamentoDoCliente = null, int? pCliente = null, TipoLancamentoDoCliente? pTipoLancamento = null, double? pValorLancamento = null, int? pVenda = null, DateTime? pDataInicial = null, DateTime? pDataFinal = null, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + DmoLancamentoDoCliente.NomeTabela, await Conexao.ConectarAsync());

            #region Obter nome dos campos
            string nomeCampoIdLancamentoDoCLiente = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().IdLancamentoDoCliente);
            string nomeCampoCliente = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().Cliente);
            string nomeCampoTipoLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().TipoLancamentoDoCliente);
            string nomeCampoValorLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().ValorLancamento);
            string nomeCampoVenda = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().Venda);
            string nomeCampoDataDoLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().DataDoLancamento);
            #endregion

            #region Filtros
            if (pIdLancamentoDoCliente != null)
            {
                cmd.CommandText += " WHERE";

                cmd.CommandText += $" {nomeCampoIdLancamentoDoCLiente} = @ID_LANCAMENTO_DO_CLIENTE";
                cmd.Parameters.AddWithValue("@ID_LANCAMENTO_DO_CLIENTE", pIdLancamentoDoCliente).SqlDbType = SqlDbType.Int;
            }

            if (pCliente != null)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += $" {nomeCampoCliente} = @CLIENTE";
                cmd.Parameters.AddWithValue("@CLIENTE", pCliente).SqlDbType = SqlDbType.Int;
            }

            if (pTipoLancamento != null)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += $" {nomeCampoTipoLancamento} = @TIPO_LANCAMENTO_DO_CLIENTE";
                cmd.Parameters.AddWithValue("@TIPO_LANCAMENTO_DO_CLIENTE", pTipoLancamento).SqlDbType = SqlDbType.Int;
            }

            if (pValorLancamento != null)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += $" {nomeCampoValorLancamento} = @VALOR_LANCAMENTO";
                cmd.Parameters.AddWithValue("@VALOR_LANCAMENTO", pValorLancamento).SqlDbType = SqlDbType.SmallMoney;
            }

            if (pVenda != null)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += $" {nomeCampoVenda} = @VENDA";
                cmd.Parameters.AddWithValue("@VENDA", pVenda).SqlDbType = SqlDbType.Int;
            }

            if (pDataInicial != null)
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += $" {nomeCampoDataDoLancamento} >= @DT_INICIAL";
                cmd.Parameters.AddWithValue("@DT_INICIAL", pDataInicial).SqlDbType = SqlDbType.DateTime;
            }

            if (pDataFinal != null)
            {
                if (pDataInicial != null && pDataInicial == pDataFinal)
                    pDataFinal = pDataInicial.Value.AddDays(1);
                else
                    pDataFinal = pDataFinal.Value.AddDays(1);// Adicionar um dia para condição incluir até meia noite do dia seguinte, ou seja, incluir todo o dia da pDataFinal

                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += $" {nomeCampoDataDoLancamento} <= @DT_FINAL";
                cmd.Parameters.AddWithValue("@DT_FINAL", pDataFinal).SqlDbType = SqlDbType.DateTime;
            }
            #endregion

            #region Ordenação
            cmd.CommandText += $" ORDER BY {nomeCampoDataDoLancamento} DESC";
            #endregion

            #region Paginação
            if (pAPartirDoRegistro != null)
            {
                cmd.CommandText += " OFFSET @A_PARTIR_DO_REGISTRO ROWS";
                cmd.Parameters.AddWithValue("@A_PARTIR_DO_REGISTRO", pAPartirDoRegistro).SqlDbType = SqlDbType.Int;
            }

            if (pAteORegistro != null)
            {
                cmd.CommandText += " FETCH NEXT @ATE_O_REGISTRO ROWS ONLY";
                cmd.Parameters.AddWithValue("@ATE_O_REGISTRO", pAteORegistro).SqlDbType = SqlDbType.Int;
            }
            #endregion

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<DmoLancamentoDoCliente> listaDeLancamentosDoCliente = new List<DmoLancamentoDoCliente>();

            while (await dataReader.ReadAsync())
            {
                DmoLancamentoDoCliente lancamentoDoCliente = new DmoLancamentoDoCliente
                {
                    IdLancamentoDoCliente = int.Parse(dataReader[nomeCampoIdLancamentoDoCLiente].ToString()),
                    Cliente = new DmoCliente { IdCliente = int.Parse(dataReader[nomeCampoCliente].ToString())},
                    TipoLancamentoDoCliente = (TipoLancamentoDoCliente) Convert.ToInt32(dataReader[nomeCampoTipoLancamento]),
                    ValorLancamento = Convert.ToDouble(dataReader[nomeCampoValorLancamento]),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                if (!string.IsNullOrEmpty(dataReader[nomeCampoVenda].ToString()))
                    lancamentoDoCliente.Venda = new DmoVenda { IdVenda = Convert.ToInt32(dataReader[nomeCampoVenda]) };

                if (!string.IsNullOrEmpty(dataReader[nomeCampoDataDoLancamento].ToString()))
                    lancamentoDoCliente.DataDoLancamento = DateTime.Parse(dataReader[nomeCampoDataDoLancamento].ToString());

                listaDeLancamentosDoCliente.Add(lancamentoDoCliente);
            }

            dataReader.Close();
            Conexao.Desconectar();

            return listaDeLancamentosDoCliente;
        }

        /// <summary>
        /// Consulta os Lançamentos agrupados por Cliente e Tipo de Lançamento.
        /// </summary>
        /// <param name="pCancelarTarefa">Token de Cancelamento da Tarefa</param>
        /// <param name="pVenda">Se fornecido, filtra a busca pelo ID da Venda.</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Lançamentos A PARTIR da Data Inicial fornecida.</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Lançamentos ATÉ a Data Final fornecida.</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido.</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido.</param>
        /// <returns>Retorna lista de Lançamentos do Cliente agrupada por Cliente e Tipo de Lançamento.</returns>
        public async Task<List<DmoLancamentoDoCliente>> ConsultarLancamentosAgrupadosPorClienteETipoDeLancamento(CancellationToken pCancelarTarefa, int? pVenda = null, DateTime? pDataInicial = null, DateTime? pDataFinal = null, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null)
        {
            #region Obter nome dos campos
            string nomeCampoCliente = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().Cliente);
            string nomeCampoTipoLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().TipoLancamentoDoCliente);
            string nomeCampoValorLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().ValorLancamento);
            string nomeCampoDataDoLancamento = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().DataDoLancamento);
            string nomeCampoVenda = DmoLancamentoDoCliente.NomeDoCampo(() => new DmoLancamentoDoCliente().Venda);
            #endregion

            SqlCommand cmd = new SqlCommand($"SELECT {nomeCampoCliente}, {nomeCampoTipoLancamento}, SUM({nomeCampoValorLancamento}) AS {nomeCampoValorLancamento}, MAX({nomeCampoDataDoLancamento}) AS {nomeCampoDataDoLancamento} FROM {DmoLancamentoDoCliente.NomeTabela}", await Conexao.ConectarAsync());

            #region Filtros
            if (pVenda != null)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += $" {nomeCampoVenda} = @VENDA";
                cmd.Parameters.AddWithValue("@VENDA", pVenda).SqlDbType = SqlDbType.Int;
            }

            if (pDataInicial != null)
            {
                cmd.CommandText += $" WHERE {nomeCampoDataDoLancamento} >= @DT_INICIAL";
                cmd.Parameters.AddWithValue("@DT_INICIAL", pDataInicial).SqlDbType = SqlDbType.DateTime;
            }

            if (pDataFinal != null)
            {
                if (pDataInicial != null && pDataInicial == pDataFinal)
                    pDataFinal = pDataInicial.Value.AddDays(1);
                else
                    pDataFinal = pDataFinal.Value.AddDays(1);// Adicionar um dia para condição incluir até meia noite do dia seguinte, ou seja, incluir todo o dia da pDataFinal

                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += $" {nomeCampoDataDoLancamento} <= @DT_FINAL";
                cmd.Parameters.AddWithValue("@DT_FINAL", pDataFinal).SqlDbType = SqlDbType.DateTime;
            }
            #endregion

            #region Agrupamento
            cmd.CommandText += $" GROUP BY {nomeCampoCliente}, {nomeCampoTipoLancamento} ";
            #endregion

            #region Ordenação
            cmd.CommandText += $" ORDER BY {nomeCampoDataDoLancamento} DESC";
            #endregion

            #region Paginação
            if (pAPartirDoRegistro != null)
            {
                cmd.CommandText += " OFFSET @A_PARTIR_DO_REGISTRO ROWS";
                cmd.Parameters.AddWithValue("@A_PARTIR_DO_REGISTRO", pAPartirDoRegistro).SqlDbType = SqlDbType.Int;
            }

            if (pAteORegistro != null)
            {
                cmd.CommandText += " FETCH NEXT @ATE_O_REGISTRO ROWS ONLY";
                cmd.Parameters.AddWithValue("@ATE_O_REGISTRO", pAteORegistro).SqlDbType = SqlDbType.Int;
            }
            #endregion

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<DmoLancamentoDoCliente> listaDeLancamentosDoCliente = new List<DmoLancamentoDoCliente>();

            while (await dataReader.ReadAsync())
            {
                #region Cancelamento da Tarefa
                // Fechar conexão caso tarefa seja cancelada
                if (pCancelarTarefa.IsCancellationRequested)
                {
                    dataReader.Close();
                    Conexao.Desconectar();
                }

                //Cancelar tarefa caso solicitado
                pCancelarTarefa.ThrowIfCancellationRequested();
                #endregion

                DmoLancamentoDoCliente lancamentoDoCliente = new DmoLancamentoDoCliente
                {
                    Cliente = new DmoCliente { IdCliente = int.Parse(dataReader[nomeCampoCliente].ToString()) },
                    TipoLancamentoDoCliente = (TipoLancamentoDoCliente)Convert.ToInt32(dataReader[nomeCampoTipoLancamento]),
                    ValorLancamento = Convert.ToDouble(dataReader[nomeCampoValorLancamento])
                };

                if (!string.IsNullOrEmpty(dataReader[nomeCampoDataDoLancamento].ToString()))
                    lancamentoDoCliente.DataDoLancamento = DateTime.Parse(dataReader[nomeCampoDataDoLancamento].ToString());

                listaDeLancamentosDoCliente.Add(lancamentoDoCliente);
            }

            dataReader.Close();
            Conexao.Desconectar();

            return listaDeLancamentosDoCliente;
        }
        #endregion
    }
}
