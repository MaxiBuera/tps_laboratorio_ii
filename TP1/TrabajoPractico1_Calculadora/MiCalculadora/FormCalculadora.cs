using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se ejecuta al inicio del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
        }

        /// <summary>
        /// reinicia los elementos del form
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = "";
            this.lblResultado.ResetText();
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// realiza una operacion entre los numeros pasados por parametros
        /// </summary>
        /// <param name="num1">primer numero</param>
        /// <param name="num2">segundo numero</param>
        /// <param name="operador">operador</param>
        /// <returns></returns>
        public static double Operar(string num1, string num2, char operador)
        {
            Operando operando1 = new Operando(num1);
            Operando operando2 = new Operando(num2);

            return Calculadora.Operar(operando1, operando2, operador);
        }

        /// <summary>
        /// metodo que cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// metodo que convierte el resultado de un numero decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando binario = new Operando();
            lblResultado.Text = binario.DecimalBinario(lblResultado.Text);
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// metodo que convierte el resultado de un numero binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando binario = new Operando();
            lblResultado.Text = binario.BinarioDecimal(lblResultado.Text);
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// evento que se ejecuta al intentar cerrar el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// metodo que ejecuta la operacion con los numeros y el operando ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Deben ser ingresados los dos operandos
            if (this.txtNumero1.Text != "" && this.txtNumero2.Text != "")
            {
                //Si el operando es vacio, la operacion será una suma
                if (this.cmbOperador.Text == "")
                {
                    this.cmbOperador.Text = "+";
                }

                double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text.ToCharArray()[0]);
                this.lblResultado.Text = resultado != double.MinValue ? resultado.ToString() : "Operación\nno válida";
                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = false;

                if(!double.TryParse(this.txtNumero1.Text, out _) && !double.TryParse(this.txtNumero2.Text, out _))
                {
                    this.txtNumero1.Text = "0";
                    this.txtNumero2.Text = "0";
                }

                if(resultado != double.MinValue)
                {

                    this.lstOperaciones.Items.Add($"{this.txtNumero1.Text} {this.cmbOperador.Text} {this.txtNumero2.Text} = {this.lblResultado.Text}");
                }

            }
        }

        /// <summary>
        /// metodo que llama al metodo limpiar. Sirve para reiniciar los elementos del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
