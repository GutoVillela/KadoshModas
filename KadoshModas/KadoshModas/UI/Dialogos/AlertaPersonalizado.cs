using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI.Dialogos
{
    public partial class AlertaPersonalizado : Form
    {
        public AlertaPersonalizado()
        {
            InitializeComponent();
        }

        #region Enum de Uso Interno
        /// <summary>
        /// Enum que define ação atual para esta instância do Alerta Personalizado
        /// </summary>
        public enum AcaoAlerta
        {
            Esperar,

            Iniciar,

            Fechar
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Define a ação a ser exercida no momento para esta instância do Alerta Personalizado
        /// </summary>
        private AlertaPersonalizado.AcaoAlerta _acao;

        /// <summary>
        /// Posição X para esta instância do Alerta Personalizado
        /// </summary>
        private int _posX;

        /// <summary>
        /// Posição Y para esta instância do Alerta Personalizado
        /// </summary>
        private int _posY;

        /// <summary>
        /// Define o tempo atual do alerta para esta instância do Alerta Personalizado
        /// </summary>
        private readonly int _tempoDoAlerta = 5000;
        #endregion

        #region Métodos
        /// <summary>
        /// Exibe o Alerta
        /// </summary>
        /// <param name="pMensagem">Mensagem para ser exibida no alerta</param>
        /// <param name="pTipoAlerta">Tipo de alerta a ser exibido</param>
        public void MostrarAlerta(string pMensagem, TipoAlerta pTipoAlerta)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string nomeDoAlerta;

            for (int i = 1; i < 10; i++)
            {
                nomeDoAlerta = "alerta" + i.ToString();
                AlertaPersonalizado alerta = (AlertaPersonalizado)Application.OpenForms[nomeDoAlerta];

                if (alerta == null)
                {
                    this.Name = nomeDoAlerta;
                    this._posX = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this._posY = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this._posX, this._posY);
                    break;
                }
            }

            this._posX = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (pTipoAlerta)
            {
                case TipoAlerta.Informacao:
                    this.picIcone.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
                    this.BackColor = Color.RoyalBlue;
                    break;

                case TipoAlerta.Aviso:
                    this.picIcone.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
                    this.BackColor = Color.DarkOrange;
                    break;

                case TipoAlerta.Sucesso:
                    this.picIcone.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    this.BackColor = Color.SeaGreen;
                    break;

                case TipoAlerta.Erro:
                    this.picIcone.IconChar = FontAwesome.Sharp.IconChar.Frown;
                    this.BackColor = Color.DarkRed;
                    break;
            }

            this.lblMensagemAlerta.Text = pMensagem;

            this.Show();

            this._acao = AcaoAlerta.Iniciar;

            this.trmTemporizador.Interval = 1;
            this.trmTemporizador.Start();
        }
        #endregion

        #region Eventos
        private void AlertaPersonalizado_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            trmTemporizador.Interval = 1;
            _acao = AcaoAlerta.Fechar;
        }

        private void trmTemporizador_Tick(object sender, EventArgs e)
        {
            switch (this._acao)
            {
                case AcaoAlerta.Esperar:
                    trmTemporizador.Interval = this._tempoDoAlerta;
                    this._acao = AcaoAlerta.Fechar;
                    break;

                case AcaoAlerta.Iniciar:
                    trmTemporizador.Interval = 1;
                    this.Opacity += 0.1;

                    if(this._posX < this.Location.X)
                        this.Left--;
                    else
                    {
                        if (this.Opacity == 1.0)
                            this._acao = AcaoAlerta.Esperar;
                    }
                    break;

                case AcaoAlerta.Fechar:
                    trmTemporizador.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;

                    if (base.Opacity == 0.0)
                        base.Close();
                    break;
            }
        }
        #endregion
    }

    #region Enum
    /// <summary>
    /// Enum que define Tipo para o Alerta Personalizado
    /// </summary>
    public enum TipoAlerta
    {
        Informacao,

        Aviso,

        Sucesso,

        Erro
    }
    #endregion
}
