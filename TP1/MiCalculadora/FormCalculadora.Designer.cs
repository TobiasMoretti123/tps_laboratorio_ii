namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Operador1 = new System.Windows.Forms.TextBox();
            this.tb_Operador2 = new System.Windows.Forms.TextBox();
            this.b_Operar = new System.Windows.Forms.Button();
            this.b_Limpiar = new System.Windows.Forms.Button();
            this.b_Cerrar = new System.Windows.Forms.Button();
            this.b_CovertirABinario = new System.Windows.Forms.Button();
            this.b_ConvertirADecimal = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tb_Operador1
            // 
            this.tb_Operador1.Location = new System.Drawing.Point(67, 108);
            this.tb_Operador1.Name = "tb_Operador1";
            this.tb_Operador1.Size = new System.Drawing.Size(141, 23);
            this.tb_Operador1.TabIndex = 0;
            // 
            // tb_Operador2
            // 
            this.tb_Operador2.Location = new System.Drawing.Point(405, 108);
            this.tb_Operador2.Name = "tb_Operador2";
            this.tb_Operador2.Size = new System.Drawing.Size(100, 23);
            this.tb_Operador2.TabIndex = 2;
            // 
            // b_Operar
            // 
            this.b_Operar.BackColor = System.Drawing.Color.Gainsboro;
            this.b_Operar.Location = new System.Drawing.Point(67, 170);
            this.b_Operar.Name = "b_Operar";
            this.b_Operar.Size = new System.Drawing.Size(141, 37);
            this.b_Operar.TabIndex = 3;
            this.b_Operar.Text = "Operar";
            this.b_Operar.UseVisualStyleBackColor = false;
            // 
            // b_Limpiar
            // 
            this.b_Limpiar.Location = new System.Drawing.Point(252, 170);
            this.b_Limpiar.Name = "b_Limpiar";
            this.b_Limpiar.Size = new System.Drawing.Size(101, 37);
            this.b_Limpiar.TabIndex = 4;
            this.b_Limpiar.Text = "Limpiar";
            this.b_Limpiar.UseVisualStyleBackColor = true;
            // 
            // b_Cerrar
            // 
            this.b_Cerrar.Location = new System.Drawing.Point(405, 170);
            this.b_Cerrar.Name = "b_Cerrar";
            this.b_Cerrar.Size = new System.Drawing.Size(100, 37);
            this.b_Cerrar.TabIndex = 5;
            this.b_Cerrar.Text = "Cerrar";
            this.b_Cerrar.UseVisualStyleBackColor = true;
            // 
            // b_CovertirABinario
            // 
            this.b_CovertirABinario.Location = new System.Drawing.Point(67, 243);
            this.b_CovertirABinario.Name = "b_CovertirABinario";
            this.b_CovertirABinario.Size = new System.Drawing.Size(216, 54);
            this.b_CovertirABinario.TabIndex = 6;
            this.b_CovertirABinario.Text = "Convertir a Binario";
            this.b_CovertirABinario.UseVisualStyleBackColor = true;
            // 
            // b_ConvertirADecimal
            // 
            this.b_ConvertirADecimal.Location = new System.Drawing.Point(303, 243);
            this.b_ConvertirADecimal.Name = "b_ConvertirADecimal";
            this.b_ConvertirADecimal.Size = new System.Drawing.Size(202, 54);
            this.b_ConvertirADecimal.TabIndex = 7;
            this.b_ConvertirADecimal.Text = "Convertir a Decimal";
            this.b_ConvertirADecimal.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(263, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 23);
            this.comboBox1.TabIndex = 8;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 375);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.b_ConvertirADecimal);
            this.Controls.Add(this.b_CovertirABinario);
            this.Controls.Add(this.b_Cerrar);
            this.Controls.Add(this.b_Limpiar);
            this.Controls.Add(this.b_Operar);
            this.Controls.Add(this.tb_Operador2);
            this.Controls.Add(this.tb_Operador1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCalculadora";
            this.Text = "Calculadora de Tobias Moretti  del curso 2C";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Operador1;
        private System.Windows.Forms.TextBox tb_Operador2;
        private System.Windows.Forms.Button b_Operar;
        private System.Windows.Forms.Button b_Limpiar;
        private System.Windows.Forms.Button b_Cerrar;
        private System.Windows.Forms.Button b_CovertirABinario;
        private System.Windows.Forms.Button b_ConvertirADecimal;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
