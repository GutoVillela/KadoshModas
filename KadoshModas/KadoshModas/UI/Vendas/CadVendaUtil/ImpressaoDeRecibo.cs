using KadoshModas.DML;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI.Vendas.CadVendaUtil
{
    public partial class ImpressaoDeRecibo : Form
    {
        #region Construtor(es)
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public ImpressaoDeRecibo()
        {
            this.Cliente = string.Empty;
            this.DataVenda = DateTime.Today;
            this.Entrada = 0f;
            this.Total = 0f;
            this.Pago = false;
            this.ItensDoRomaneio = new List<DmoRomaneioVenda>();
            InitializeComponent();
        }

        /// <summary>
        /// Construtor padrão que define informações para criação do Romaneio.
        /// </summary>
        /// <param name="pCliente">Nome do Cliente.</param>
        /// <param name="pDataVenda">Data da Venda.</param>
        /// <param name="pEntrada">Entrada da Venda.</param>
        /// <param name="pTotal">Total da Venda.</param>
        /// <param name="pPago">Situação de pagamento da Venda (PAGO ou NÃO PAGO).</param>
        /// <param name="pItensDoRomaneio">Itens do Romaneio.</param>
        public ImpressaoDeRecibo(string pCliente, DateTime pDataVenda, double pEntrada, double pTotal, bool pPago, List<DmoRomaneioVenda> pItensDoRomaneio)
        {
            this.Cliente = pCliente;
            this.DataVenda = pDataVenda;
            this.Entrada = float.Parse(pEntrada.ToString());
            this.Total = float.Parse(pTotal.ToString());
            this.Pago = pPago;
            this.ItensDoRomaneio = pItensDoRomaneio;
            InitializeComponent();
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Nome do Cliente a ser exibido no relatório.
        /// </summary>
        private string Cliente { get; set; }

        /// <summary>
        /// Data da Venda a ser exibida no relatório.
        /// </summary>
        private DateTime DataVenda { get; set; }

        /// <summary>
        /// Entrada da Venda.
        /// </summary>
        public float Entrada { get; set; }

        /// <summary>
        /// Total da Venda.
        /// </summary>
        public float Total { get; set; }


        /// <summary>
        /// Situação de pagamento (PAGO ou NÃO PAGO) da Venda.
        /// </summary>
        public bool Pago { get; set; }

        /// <summary>
        /// Itens do Romaneio a serem exibidos no relatório.
        /// </summary>
        private List<DmoRomaneioVenda> ItensDoRomaneio { get; set; }
        #endregion

        private void ImpressaoDeRecibo_Load(object sender, EventArgs e)
        {
            // Definindo DataSource do Relatório
            ReportDataSource rds = new ReportDataSource
            {
                Name = "dsItensDaVenda",
                Value = ItensDoRomaneio
            };

            // Definindo parâmetros do Relatório
            ReportParameter parametroNomeCliente = new ReportParameter("NomeCliente", Cliente);
            ReportParameter parametroDataVenda = new ReportParameter("DataVenda", DataVenda.ToString("dd/MM/yyyy HH:mm"));
            ReportParameter parametroEntrada = new ReportParameter("Entrada", Entrada.ToString());
            ReportParameter parametroTotal = new ReportParameter("Total", Total.ToString());
            ReportParameter parametroPago = new ReportParameter("Pago", Pago ? "SIM" : "NÃO" );

            ReportParameter[] parametros = new ReportParameter[] 
            { 
                parametroNomeCliente, 
                parametroDataVenda,
                parametroEntrada,
                parametroTotal,
                parametroPago
            };

            // Caminho do relatório
            string caminhoRelatorio = INF.DiretoriosDoSistema.DIR_RELATORIOS + @"\RomaneioVenda.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.ReportPath = caminhoRelatorio;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = caminhoRelatorio;

            using (StreamReader streamReader = new StreamReader(caminhoRelatorio))
            {
                this.reportViewer1.LocalReport.LoadReportDefinition(streamReader);
                this.reportViewer1.LocalReport.Refresh();
            }


            this.reportViewer1.LocalReport.SetParameters(parametros);
            this.reportViewer1.RefreshReport();
        }
    }
}
