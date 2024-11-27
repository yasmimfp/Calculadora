using System;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private decimal _resultadoAcumulado;
        private Operacao _operacaoAtual = Operacao.Nenhuma;
        private bool _novaEntrada; 

        public Form1()
        {
            InitializeComponent();
        }
        // DECLARAÇÃO DAS OPERAÇÕES
        private enum Operacao
        {
            Nenhuma,
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao,
            Porcentagem
        }

        private void AdicionarNumero(string numero)
        {
            if (_novaEntrada)
            {
                txtResultado.Text = ""; 
                _novaEntrada = false;
            }

            txtResultado.Text += numero;
            txtOperacao.Text += numero;
        }

        private void DefinirOperacao(Operacao operacao, string simbolo)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal valorAtual))
            {
                if (_operacaoAtual != Operacao.Nenhuma)
                {
                   
                    CalcularResultado(valorAtual);
                }
                else
                {
                    _resultadoAcumulado = valorAtual; 
                }

                txtOperacao.Text += simbolo;
                _operacaoAtual = operacao;
                _novaEntrada = true; 
            }
            else
            {
                MessageBox.Show("Insira um número válido antes de selecionar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //OPERAÇÕES
        private void CalcularResultado(decimal valorAtual)
        {
            switch (_operacaoAtual)
            {
                case Operacao.Adicao:
                    _resultadoAcumulado += valorAtual;
                    break;
                case Operacao.Subtracao:
                    _resultadoAcumulado -= valorAtual;
                    break;
                case Operacao.Multiplicacao:
                    _resultadoAcumulado *= valorAtual;
                    break;
                case Operacao.Divisao:
                    if (valorAtual == 0)
                    {
                        MessageBox.Show("Divisão por zero não é permitida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _resultadoAcumulado /= valorAtual;
                    break;
                case Operacao.Porcentagem:
                    _resultadoAcumulado = (_resultadoAcumulado * valorAtual) / 100;
                    break;
            }

            txtResultado.Text = _resultadoAcumulado.ToString();
        }
        //BOTÃO DE IGUAL
        private void btnIgualdade_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal valorAtual))
            {
                CalcularResultado(valorAtual);
                txtOperacao.Text += $"={_resultadoAcumulado}";
                _operacaoAtual = Operacao.Nenhuma;
                _novaEntrada = true;
            }
            else
            {
                MessageBox.Show("Insira um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //BOTÃO C
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            txtOperacao.Text = "";
            _resultadoAcumulado = 0;
            _operacaoAtual = Operacao.Nenhuma;
            _novaEntrada = false;
        }
         //BOTÃO AC
        private void btnAC_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 0)
            {
                txtResultado.Text = txtResultado.Text.Remove(txtResultado.Text.Length - 1);
                txtOperacao.Text = txtOperacao.Text.Remove(txtOperacao.Text.Length - 1);
            }
        }
        //VÍRGULA
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains(","))
            {
                AdicionarNumero(",");
            }
        }
        //O QUE CADA BOTÃO MOSTRA
        private void btnZero_Click(object sender, EventArgs e) => AdicionarNumero("0");
        private void btnUm_Click(object sender, EventArgs e) => AdicionarNumero("1");
        private void BtnDois_Click(object sender, EventArgs e) => AdicionarNumero("2");
        private void BtnTres_Click(object sender, EventArgs e) => AdicionarNumero("3");
        private void BtnQuatro_Click(object sender, EventArgs e) => AdicionarNumero("4");
        private void BtnCinco_Click(object sender, EventArgs e) => AdicionarNumero("5");
        private void BtnSeis_Click(object sender, EventArgs e) => AdicionarNumero("6");
        private void BtnSete_Click(object sender, EventArgs e) => AdicionarNumero("7");
        private void BtnOito_Click(object sender, EventArgs e) => AdicionarNumero("8");
        private void BtnNove_Click(object sender, EventArgs e) => AdicionarNumero("9");

        private void btnAdicao_Click(object sender, EventArgs e) => DefinirOperacao(Operacao.Adicao, "+");
        private void btnSubtracao_Click(object sender, EventArgs e) => DefinirOperacao(Operacao.Subtracao, "-");
        private void btnMultiplicacao_Click(object sender, EventArgs e) => DefinirOperacao(Operacao.Multiplicacao, "x");
        private void btnDivisao_Click(object sender, EventArgs e) => DefinirOperacao(Operacao.Divisao, "/");
        private void btnPorcentagem_Click(object sender, EventArgs e) => DefinirOperacao(Operacao.Porcentagem, "%");
    }
}
