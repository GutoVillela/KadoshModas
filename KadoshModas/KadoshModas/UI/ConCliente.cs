using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.INF;
using KadoshModas.UI.UserControls;

namespace KadoshModas.UI
{
    public partial class ConCliente : Form
    {
        public ConCliente()
        {
            InitializeComponent();
        }

        #region Atributos

        #region Paginação
        /// <summary>
        /// Indica quantos registros correspondem ao critério de busca
        /// </summary>
        private int _qtdRegistrosBusca;

        /// <summary>
        /// Indica a partir de qual registro a busca de clientes será feita
        /// </summary>
        private uint _buscarAPartirDoRegistro = 0;
        #endregion

        #region Filtros
        /// <summary>
        /// Define o filtro de Id do Cliente aplicado na busca
        /// </summary>
        private int? _filtroIdCliente = null;

        /// <summary>
        /// Define o filtro de Nome aplicado na busca
        /// </summary>
        private string _filtroNome = null;

        /// <summary>
        /// Define o filtro de Email aplicado na busca
        /// </summary>
        private string _filtroEmail = null;

        /// <summary>
        /// Define o filtro de CPF aplicado na busca
        /// </summary>
        private string _filtroCpf = null;

        /// <summary>
        /// Define o filtro de Sexo aplicado na busca
        /// </summary>
        private Sexo? _filtroSexo = null;

        /// <summary>
        /// Define o filtro de Buscar Cliente Indefinido aplicado na busca
        /// </summary>
        private bool _filtroBuscarClienteIndefinido = true;

        /// <summary>
        /// Define o filtro de busca Clientes Desativados aplicado na busca
        /// </summary>
        private bool _filtroBuscaClientesDesativados = false;
        #endregion

        #endregion

        #region Métodos
        /// <summary>
        /// Monta o ambiente inicial
        /// </summary>
        private async Task MontarAmbienteInicialAsync()
        {
            this._qtdRegistrosBusca = await new BoCliente().ContarClientesAsync(null, null, null, null, true);
            CarregarGrid(await new BLL.BoCliente().ConsultarAsync(null, null, null, null, null, true, false, this._buscarAPartirDoRegistro, INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente));
            
        }

        /// <summary>
        /// Carrega DataGridView com dados fornecidos
        /// </summary>
        /// <param name="pDataSource">Lista de Clientes a serem carregados na tela</param>
        private void CarregarGrid(List<DML.DmoCliente> pDataSource)
        {
            //Limpar Panel da Consulta
            pnlConCliente.Controls.Clear();

            foreach (DML.DmoCliente cliente in pDataSource)
            {
                ucClienteListItem clienteListItem = new UserControls.ucClienteListItem();
                clienteListItem.Cliente = cliente;
                pnlConCliente.Controls.Add(clienteListItem);
            }

            lblRegistros.Text = $"Exibindo {pDataSource.Count} de {this._qtdRegistrosBusca}";
        }

        /// <summary>
        /// Aplica os filtros definidos na busca de forma assíncrona
        /// </summary>
        private async Task AplicarFiltrosAsync()
        {
            this._qtdRegistrosBusca = await new BoCliente().ContarClientesAsync(this._filtroNome, this._filtroEmail, this._filtroCpf, this._filtroSexo, this._filtroBuscarClienteIndefinido, this._filtroBuscaClientesDesativados);
            CarregarGrid(await new BLL.BoCliente().ConsultarAsync(_filtroIdCliente, _filtroNome, _filtroEmail, _filtroCpf, _filtroSexo, _filtroBuscarClienteIndefinido, _filtroBuscaClientesDesativados, this._buscarAPartirDoRegistro, INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente));

            #region Definir visibilidade da paginação
            pnlPaginacaoBusca.Visible = INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente <= _qtdRegistrosBusca;

            btnAnteriorPaginacao.Enabled = btnInicioPaginacao.Enabled = _buscarAPartirDoRegistro != 0;

            btnProximoPaginacao.Enabled = btnUltimoPaginacao.Enabled = (_buscarAPartirDoRegistro + ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente) < _qtdRegistrosBusca;
            #endregion
        }
        #endregion

        #region Eventos
        private async void ConCliente_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            await MontarAmbienteInicialAsync();
        }

        private async void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            if (rbtNome.Checked)
            {
                this._filtroNome = txtConsulta.Text.Trim();
                await AplicarFiltrosAsync();
            }
        }

        private void rbtNome_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtCPF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void btnInicioPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro = 0;
            await AplicarFiltrosAsync();
        }

        private async void btnAnteriorPaginacao_Click(object sender, EventArgs e)
        {
            if (this._buscarAPartirDoRegistro >= INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente)
                this._buscarAPartirDoRegistro -= INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente;

            await AplicarFiltrosAsync();
        }

        private async void btnProximoPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro += INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente;
            await AplicarFiltrosAsync();
        }

        private async void btnUltimoPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro = Convert.ToUInt32(Math.Floor(Convert.ToDecimal(this._qtdRegistrosBusca / ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente)) * ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente);
            await AplicarFiltrosAsync();
        }
        #endregion
    }
}
