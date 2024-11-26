using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora {
    public partial class Form1 : Form {

        decimal calculo;
        bool adicao = false;
        bool subtracao = false;
        bool multiplicacao = false;
        bool divisao = false;
        bool resultado = false;
        bool porcentagem = false;
        public Form1() {
            InitializeComponent();
        }
        private void btnZero_Click(object sender, EventArgs e) {
            txtResultado.Text += "0";
            txtOperacao.Text += "0";
        }
        private void btnUm_Click(object sender, EventArgs e) {
            txtResultado.Text += "1";
            txtOperacao.Text += "1";
        }

        private void BtnDois_Click(object sender, EventArgs e) {
            txtResultado.Text += "2";
            txtOperacao.Text += "2";
        }

        private void BtnTres_Click(object sender, EventArgs e) {
            txtResultado.Text += "3";
            txtOperacao.Text += "3";

        }

        private void BtnQuatro_Click(object sender, EventArgs e) {
            txtResultado.Text += "4";
            txtOperacao.Text += "4";
        }

        private void BtnCinco_Click(object sender, EventArgs e) {
            txtResultado.Text += "5";
            txtOperacao.Text += "5";
        }

        private void BtnSeis_Click(object sender, EventArgs e) {
            txtResultado.Text += "6";
            txtOperacao.Text += "6";
        }

        private void BtnSete_Click(object sender, EventArgs e) {
            txtResultado.Text += "7";
            txtOperacao.Text += "7";
        }

        private void BtnOito_Click(object sender, EventArgs e) {
            txtResultado.Text += "8";
            txtOperacao.Text += "8";
        }
        private void BtnNove_Click(object sender, EventArgs e) {
            txtResultado.Text += "9";
            txtOperacao.Text += "9";
        }
        private void btnAdicao_Click(object sender, EventArgs e) {
            calculo = decimal.Parse(txtResultado.Text);

            txtOperacao.Text += "+";
            txtResultado.Text = "";

            adicao = true;
            subtracao = false;
            multiplicacao = false;
            divisao = false;
            porcentagem = false;
        }
        private void btnSubtracao_Click(object sender, EventArgs e) {
            calculo = decimal.Parse(txtResultado.Text);

            txtOperacao.Text += "-";
            txtResultado.Text = "";

            adicao = false;
            subtracao = true;
            multiplicacao = false;
            divisao = false;
            porcentagem = false;
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e) {
            calculo = decimal.Parse(txtResultado.Text);

            txtOperacao.Text += "x";
            txtResultado.Text = "";

            adicao = false;
            subtracao = false;
            multiplicacao = true;
            divisao = false;
            porcentagem = false;
        }
        private void btnDivisao_Click(object sender, EventArgs e) {

            calculo = decimal.Parse(txtResultado.Text);

            txtOperacao.Text += "/";
            txtResultado.Text = "";

            adicao = false;
            subtracao = false;
            multiplicacao = false;
            divisao = true;
            porcentagem= false;

        }
        private void btnPorcentagem_Click(object sender, EventArgs e) {
            calculo = decimal.Parse(txtResultado.Text);

            txtOperacao.Text += "%";
            txtResultado.Text = "";

            adicao = false;
            subtracao = false;
            multiplicacao = false;
            divisao = false;
            porcentagem = true;
            
            
            

            
        }

        private void btnIgualdade_Click(object sender, EventArgs e) {
            resultado = true;
            txtOperacao.Text += "=";

            //OPERAÇÃO DE ADIÇÃO
            if (adicao == true) {
                txtResultado.Text = Convert.ToString(Convert.ToDecimal(txtResultado.Text) + calculo);
                txtOperacao.Text += txtResultado.Text;
            }
            //OPERAÇÃO DE SUBTRAÇÃO
            if (subtracao == true) {
                txtResultado.Text = Convert.ToString(calculo - Convert.ToDecimal(txtResultado.Text));
                txtOperacao.Text += txtResultado.Text;
            }
            //OPERAÇÃO DE MULTIPLICAÇÃO
            if (multiplicacao == true) {
                txtResultado.Text = Convert.ToString(Convert.ToDecimal(txtResultado.Text) * calculo);
                txtOperacao.Text += txtResultado.Text;
            }
            //OPERAÇÃO DE DIVISÃO
            if (divisao == true) {
                txtResultado.Text = Convert.ToString(calculo / Convert.ToDecimal(txtResultado.Text));
                txtOperacao.Text += txtResultado.Text;
            }
            if (porcentagem == true) {
                // Calcula a porcentagem do número atual baseado no valor armazenado
                decimal valorAtual = Convert.ToDecimal(txtResultado.Text);
                decimal resultadoPorcentagem = (calculo * valorAtual) / 100;

                txtResultado.Text = resultadoPorcentagem.ToString();
                txtOperacao.Text += txtResultado.Text;
            }

        }


        private void btnLimpar_Click(object sender, EventArgs e) {
            txtResultado.Text = "";
            txtOperacao.Text = "";

        }
        private void button1_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }
        private void txtOperacao_TextChanged(object sender, EventArgs e) {

        }

        private void btnVirgula_Click(object sender, EventArgs e) {
            txtResultado.Text += ",";
            txtOperacao.Text += ",";
        }

        private void btnAC_Click(object sender, EventArgs e) {
            try {
                string apagar = txtResultado.Text;
                apagar = apagar.Remove(apagar.Length - 1);
                txtResultado.Text = apagar;
                txtOperacao.Text = apagar;
            }
            catch (Exception) { }
        }
    }
}