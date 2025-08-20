using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraIMC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
           
            // Validando Erros
            if (txbPeso.Text == "")
            {
                MessageBox.Show("Preencha o campo dom peso!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txbAltura.Text == "")
            {
                MessageBox.Show("Preencha o campo da altura!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Validar se está correndo certo e que não quebre o programa
            try
            {
                
                // Declarando variaveis
                double peso = double.Parse(txbPeso.Text);
                double altura = double.Parse(txbAltura.Text);

                
                // Calcular o IMC
                double imc = peso / (altura * altura);

                // Iniciando classificação com nada ""
                string classificacao = "";
                
               // Inicar uma cor
                Color corResultado = Color.Black;

               
                // Verificação 
                if (imc < 18.5)
                {
                    // Armazenando em clasificação
                    classificacao = "Abaixo do peso";
                    // Determinar a cor que ira exibir o resultado
                    corResultado = Color.Orange;
                }
                else if (imc < 24.9)
                {
                    classificacao = "Peso normal";
                    corResultado = Color.Green;
                }
                else if (imc < 29.9)
                {
                    classificacao = "Sobrepeso";
                    corResultado = Color.Goldenrod;
                }
                else if (imc < 34.9)
                {
                    classificacao = "Obesidade Grau I";
                    corResultado = Color.OrangeRed;
                }
                else if (imc < 39.9)
                {
                    classificacao = "Obesidade Grau II";
                    corResultado = Color.Red;
                }
                else
                {
                    classificacao = "Obesidade Grau III (mórbida)";
                    corResultado = Color.DarkRed;
                }

                // Exibe o IMC e a classificação no Label
                lblResultado.Text = $"IMC: {imc:F2} - {classificacao}";
                
                // Puxar a cor da variavel corResultado
                lblResultado.ForeColor = corResultado;
            }
            
            // Para validação de erro
            catch (FormatException)
            {
                MessageBox.Show("Digite valores numéricos válidos!", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
