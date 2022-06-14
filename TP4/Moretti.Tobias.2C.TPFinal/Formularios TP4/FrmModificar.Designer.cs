namespace Formularios_TP4
{
    partial class FrmModificar
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
            this.lsbClientes = new System.Windows.Forms.ListBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsbClientes
            // 
            this.lsbClientes.FormattingEnabled = true;
            this.lsbClientes.ItemHeight = 15;
            this.lsbClientes.Location = new System.Drawing.Point(12, 119);
            this.lsbClientes.Name = "lsbClientes";
            this.lsbClientes.Size = new System.Drawing.Size(806, 319);
            this.lsbClientes.TabIndex = 0;
            this.lsbClientes.DoubleClick += new System.EventHandler(this.lsbClientes_DoubleClick);
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLista.Location = new System.Drawing.Point(12, 95);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(217, 21);
            this.lblLista.TabIndex = 1;
            this.lblLista.Text = "Seleccione Cliente a Modificar";
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(273, 67);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(255, 23);
            this.txtCuit.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 67);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(255, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(642, 67);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(176, 30);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(12, 43);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(132, 21);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre Empresa";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCuit.Location = new System.Drawing.Point(273, 43);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(102, 21);
            this.lblCuit.TabIndex = 6;
            this.lblCuit.Text = "Cuit Empresa";
            // 
            // FrmModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 450);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.lsbClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Cliente";
            this.Load += new System.EventHandler(this.FrmModificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbClientes;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCuit;
    }
}