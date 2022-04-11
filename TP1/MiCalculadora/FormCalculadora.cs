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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            this.lblResultado.Text = resultado.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            this.lblResultado.Text = resultado.BinarioDecimal(this.lblResultado.Text);
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            Operando n1 = new Operando(txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            Operando n2 = new Operando(txtNumero2.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.lstOperaciones.Items.Add($"{this.txtNumero1.Text} {this.cmbOperador.Text} {this.txtNumero2.Text} = {this.lblResultado.Text}");
            this.lstOperaciones.SelectedIndex = this.lstOperaciones.Items.Count - 1;   
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.SelectedIndex = 0;
            lstOperaciones.Items.Clear();
            lblResultado.Text = string.Empty;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            char charOperador;
            char.TryParse(operador, out charOperador);

            return Calculadora.Operar(num1, num2, charOperador);
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs formClose)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                formClose.Cancel = true;
            }
        }
    }
}
