namespace Formularios_TP4
{
    partial class FormComprar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstbProductos = new System.Windows.Forms.ListBox();
            this.lblProductos = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnVerCompra = new System.Windows.Forms.Button();
            this.txtCantidadCilindros = new System.Windows.Forms.TextBox();
            this.lblCantidadCilindros = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstbProductos
            // 
            this.lstbProductos.FormattingEnabled = true;
            this.lstbProductos.ItemHeight = 15;
            this.lstbProductos.Location = new System.Drawing.Point(12, 72);
            this.lstbProductos.Name = "lstbProductos";
            this.lstbProductos.Size = new System.Drawing.Size(425, 349);
            this.lstbProductos.TabIndex = 0;
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductos.Location = new System.Drawing.Point(12, 45);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(228, 21);
            this.lblProductos.TabIndex = 1;
            this.lblProductos.Text = "Seleccione Producto a Comprar";
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(490, 179);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(134, 52);
            this.btnComprar.TabIndex = 2;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(490, 369);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(134, 52);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnVerCompra
            // 
            this.btnVerCompra.Location = new System.Drawing.Point(490, 277);
            this.btnVerCompra.Name = "btnVerCompra";
            this.btnVerCompra.Size = new System.Drawing.Size(134, 52);
            this.btnVerCompra.TabIndex = 4;
            this.btnVerCompra.Text = "Ver Carrito";
            this.btnVerCompra.UseVisualStyleBackColor = true;
            this.btnVerCompra.Click += new System.EventHandler(this.btnVerCompra_Click);
            // 
            // txtCantidadCilindros
            // 
            this.txtCantidadCilindros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCantidadCilindros.Location = new System.Drawing.Point(490, 96);
            this.txtCantidadCilindros.Name = "txtCantidadCilindros";
            this.txtCantidadCilindros.Size = new System.Drawing.Size(134, 29);
            this.txtCantidadCilindros.TabIndex = 5;
            // 
            // lblCantidadCilindros
            // 
            this.lblCantidadCilindros.AutoSize = true;
            this.lblCantidadCilindros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCantidadCilindros.Location = new System.Drawing.Point(490, 72);
            this.lblCantidadCilindros.Name = "lblCantidadCilindros";
            this.lblCantidadCilindros.Size = new System.Drawing.Size(72, 21);
            this.lblCantidadCilindros.TabIndex = 6;
            this.lblCantidadCilindros.Text = "Cantidad";
            // 
            // FormComprar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.lblCantidadCilindros);
            this.Controls.Add(this.txtCantidadCilindros);
            this.Controls.Add(this.btnVerCompra);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.lstbProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormComprar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.FormComprar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbProductos;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnVerCompra;
        private System.Windows.Forms.TextBox txtCantidadCilindros;
        private System.Windows.Forms.Label lblCantidadCilindros;
    }
}