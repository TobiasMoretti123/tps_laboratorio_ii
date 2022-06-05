namespace FormIngreso
{
    partial class FormIngreso
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
            this.txtNombrePersonaje = new System.Windows.Forms.TextBox();
            this.cmbEscuela = new System.Windows.Forms.ComboBox();
            this.grbPersonaje = new System.Windows.Forms.GroupBox();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.lblNivel = new System.Windows.Forms.Label();
            this.cmbClase = new System.Windows.Forms.ComboBox();
            this.lblEscuelaHechicero = new System.Windows.Forms.Label();
            this.lblClase = new System.Windows.Forms.Label();
            this.lblPersonaje = new System.Windows.Forms.Label();
            this.txtNombreJugador = new System.Windows.Forms.TextBox();
            this.lblNombreJugador = new System.Windows.Forms.Label();
            this.grbCaracteristicas = new System.Windows.Forms.GroupBox();
            this.txtVidaPersonaje = new System.Windows.Forms.TextBox();
            this.lblVida = new System.Windows.Forms.Label();
            this.txtCarisma = new System.Windows.Forms.TextBox();
            this.lblCarisma = new System.Windows.Forms.Label();
            this.txtSabiduria = new System.Windows.Forms.TextBox();
            this.lblSabiduria = new System.Windows.Forms.Label();
            this.txtInteligencia = new System.Windows.Forms.TextBox();
            this.lblInteligencia = new System.Windows.Forms.Label();
            this.txtConstitucion = new System.Windows.Forms.TextBox();
            this.lblConstitucion = new System.Windows.Forms.Label();
            this.txtDestreza = new System.Windows.Forms.TextBox();
            this.lblDestreza = new System.Windows.Forms.Label();
            this.txtFuerza = new System.Windows.Forms.TextBox();
            this.lblFuerza = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grbPersonaje.SuspendLayout();
            this.grbCaracteristicas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombrePersonaje
            // 
            this.txtNombrePersonaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombrePersonaje.Location = new System.Drawing.Point(10, 61);
            this.txtNombrePersonaje.Name = "txtNombrePersonaje";
            this.txtNombrePersonaje.Size = new System.Drawing.Size(207, 29);
            this.txtNombrePersonaje.TabIndex = 0;
            // 
            // cmbEscuela
            // 
            this.cmbEscuela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEscuela.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbEscuela.FormattingEnabled = true;
            this.cmbEscuela.Location = new System.Drawing.Point(602, 61);
            this.cmbEscuela.Name = "cmbEscuela";
            this.cmbEscuela.Size = new System.Drawing.Size(163, 29);
            this.cmbEscuela.TabIndex = 2;
            // 
            // grbPersonaje
            // 
            this.grbPersonaje.BackColor = System.Drawing.SystemColors.GrayText;
            this.grbPersonaje.Controls.Add(this.txtNivel);
            this.grbPersonaje.Controls.Add(this.lblNivel);
            this.grbPersonaje.Controls.Add(this.cmbClase);
            this.grbPersonaje.Controls.Add(this.lblEscuelaHechicero);
            this.grbPersonaje.Controls.Add(this.lblClase);
            this.grbPersonaje.Controls.Add(this.cmbEscuela);
            this.grbPersonaje.Controls.Add(this.txtNombrePersonaje);
            this.grbPersonaje.Controls.Add(this.lblPersonaje);
            this.grbPersonaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grbPersonaje.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grbPersonaje.Location = new System.Drawing.Point(12, 58);
            this.grbPersonaje.Name = "grbPersonaje";
            this.grbPersonaje.Size = new System.Drawing.Size(818, 114);
            this.grbPersonaje.TabIndex = 3;
            this.grbPersonaje.TabStop = false;
            this.grbPersonaje.Text = "Personaje";
            // 
            // txtNivel
            // 
            this.txtNivel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNivel.Location = new System.Drawing.Point(446, 61);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(139, 29);
            this.txtNivel.TabIndex = 7;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNivel.Location = new System.Drawing.Point(446, 37);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(46, 21);
            this.lblNivel.TabIndex = 8;
            this.lblNivel.Text = "Nivel";
            // 
            // cmbClase
            // 
            this.cmbClase.AutoCompleteCustomSource.AddRange(new string[] {
            "Guerrero",
            "Mago",
            "Arquero"});
            this.cmbClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbClase.FormattingEnabled = true;
            this.cmbClase.Items.AddRange(new object[] {
            "Arquero",
            "Guerrero",
            "Mago"});
            this.cmbClase.Location = new System.Drawing.Point(257, 61);
            this.cmbClase.Name = "cmbClase";
            this.cmbClase.Size = new System.Drawing.Size(163, 29);
            this.cmbClase.TabIndex = 4;
            this.cmbClase.SelectedIndexChanged += new System.EventHandler(this.cmbClase_SelectedIndexChanged);
            // 
            // lblEscuelaHechicero
            // 
            this.lblEscuelaHechicero.AutoSize = true;
            this.lblEscuelaHechicero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEscuelaHechicero.Location = new System.Drawing.Point(602, 37);
            this.lblEscuelaHechicero.Name = "lblEscuelaHechicero";
            this.lblEscuelaHechicero.Size = new System.Drawing.Size(105, 21);
            this.lblEscuelaHechicero.TabIndex = 5;
            this.lblEscuelaHechicero.Text = "Escuela Mago";
            // 
            // lblClase
            // 
            this.lblClase.AutoSize = true;
            this.lblClase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClase.Location = new System.Drawing.Point(257, 37);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(47, 21);
            this.lblClase.TabIndex = 6;
            this.lblClase.Text = "Clase";
            // 
            // lblPersonaje
            // 
            this.lblPersonaje.AutoSize = true;
            this.lblPersonaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPersonaje.Location = new System.Drawing.Point(10, 37);
            this.lblPersonaje.Name = "lblPersonaje";
            this.lblPersonaje.Size = new System.Drawing.Size(139, 21);
            this.lblPersonaje.TabIndex = 4;
            this.lblPersonaje.Text = "Nombre Personaje";
            // 
            // txtNombreJugador
            // 
            this.txtNombreJugador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreJugador.Location = new System.Drawing.Point(146, 26);
            this.txtNombreJugador.Name = "txtNombreJugador";
            this.txtNombreJugador.Size = new System.Drawing.Size(246, 29);
            this.txtNombreJugador.TabIndex = 4;
            // 
            // lblNombreJugador
            // 
            this.lblNombreJugador.AutoSize = true;
            this.lblNombreJugador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreJugador.Location = new System.Drawing.Point(12, 26);
            this.lblNombreJugador.Name = "lblNombreJugador";
            this.lblNombreJugador.Size = new System.Drawing.Size(128, 21);
            this.lblNombreJugador.TabIndex = 6;
            this.lblNombreJugador.Text = "Nombre Jugador";
            // 
            // grbCaracteristicas
            // 
            this.grbCaracteristicas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.grbCaracteristicas.Controls.Add(this.txtVidaPersonaje);
            this.grbCaracteristicas.Controls.Add(this.lblVida);
            this.grbCaracteristicas.Controls.Add(this.txtCarisma);
            this.grbCaracteristicas.Controls.Add(this.lblCarisma);
            this.grbCaracteristicas.Controls.Add(this.txtSabiduria);
            this.grbCaracteristicas.Controls.Add(this.lblSabiduria);
            this.grbCaracteristicas.Controls.Add(this.txtInteligencia);
            this.grbCaracteristicas.Controls.Add(this.lblInteligencia);
            this.grbCaracteristicas.Controls.Add(this.txtConstitucion);
            this.grbCaracteristicas.Controls.Add(this.lblConstitucion);
            this.grbCaracteristicas.Controls.Add(this.txtDestreza);
            this.grbCaracteristicas.Controls.Add(this.lblDestreza);
            this.grbCaracteristicas.Controls.Add(this.txtFuerza);
            this.grbCaracteristicas.Controls.Add(this.lblFuerza);
            this.grbCaracteristicas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grbCaracteristicas.Location = new System.Drawing.Point(12, 178);
            this.grbCaracteristicas.Name = "grbCaracteristicas";
            this.grbCaracteristicas.Size = new System.Drawing.Size(565, 425);
            this.grbCaracteristicas.TabIndex = 7;
            this.grbCaracteristicas.TabStop = false;
            this.grbCaracteristicas.Text = "Caracteristicas";
            // 
            // txtVidaPersonaje
            // 
            this.txtVidaPersonaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtVidaPersonaje.Location = new System.Drawing.Point(242, 56);
            this.txtVidaPersonaje.Name = "txtVidaPersonaje";
            this.txtVidaPersonaje.Size = new System.Drawing.Size(207, 29);
            this.txtVidaPersonaje.TabIndex = 17;
            // 
            // lblVida
            // 
            this.lblVida.AutoSize = true;
            this.lblVida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVida.Location = new System.Drawing.Point(242, 32);
            this.lblVida.Name = "lblVida";
            this.lblVida.Size = new System.Drawing.Size(45, 21);
            this.lblVida.TabIndex = 18;
            this.lblVida.Text = "Vida ";
            // 
            // txtCarisma
            // 
            this.txtCarisma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCarisma.Location = new System.Drawing.Point(10, 377);
            this.txtCarisma.Name = "txtCarisma";
            this.txtCarisma.Size = new System.Drawing.Size(207, 29);
            this.txtCarisma.TabIndex = 15;
            // 
            // lblCarisma
            // 
            this.lblCarisma.AutoSize = true;
            this.lblCarisma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCarisma.Location = new System.Drawing.Point(10, 353);
            this.lblCarisma.Name = "lblCarisma";
            this.lblCarisma.Size = new System.Drawing.Size(67, 21);
            this.lblCarisma.TabIndex = 16;
            this.lblCarisma.Text = "Carisma";
            // 
            // txtSabiduria
            // 
            this.txtSabiduria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSabiduria.Location = new System.Drawing.Point(10, 312);
            this.txtSabiduria.Name = "txtSabiduria";
            this.txtSabiduria.Size = new System.Drawing.Size(207, 29);
            this.txtSabiduria.TabIndex = 13;
            // 
            // lblSabiduria
            // 
            this.lblSabiduria.AutoSize = true;
            this.lblSabiduria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSabiduria.Location = new System.Drawing.Point(10, 288);
            this.lblSabiduria.Name = "lblSabiduria";
            this.lblSabiduria.Size = new System.Drawing.Size(76, 21);
            this.lblSabiduria.TabIndex = 14;
            this.lblSabiduria.Text = "Sabiduria";
            // 
            // txtInteligencia
            // 
            this.txtInteligencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInteligencia.Location = new System.Drawing.Point(10, 248);
            this.txtInteligencia.Name = "txtInteligencia";
            this.txtInteligencia.Size = new System.Drawing.Size(207, 29);
            this.txtInteligencia.TabIndex = 11;
            // 
            // lblInteligencia
            // 
            this.lblInteligencia.AutoSize = true;
            this.lblInteligencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInteligencia.Location = new System.Drawing.Point(10, 224);
            this.lblInteligencia.Name = "lblInteligencia";
            this.lblInteligencia.Size = new System.Drawing.Size(89, 21);
            this.lblInteligencia.TabIndex = 12;
            this.lblInteligencia.Text = "Inteligencia";
            // 
            // txtConstitucion
            // 
            this.txtConstitucion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConstitucion.Location = new System.Drawing.Point(10, 185);
            this.txtConstitucion.Name = "txtConstitucion";
            this.txtConstitucion.Size = new System.Drawing.Size(207, 29);
            this.txtConstitucion.TabIndex = 9;
            // 
            // lblConstitucion
            // 
            this.lblConstitucion.AutoSize = true;
            this.lblConstitucion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConstitucion.Location = new System.Drawing.Point(10, 161);
            this.lblConstitucion.Name = "lblConstitucion";
            this.lblConstitucion.Size = new System.Drawing.Size(97, 21);
            this.lblConstitucion.TabIndex = 10;
            this.lblConstitucion.Text = "Constitucion";
            // 
            // txtDestreza
            // 
            this.txtDestreza.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDestreza.Location = new System.Drawing.Point(10, 120);
            this.txtDestreza.Name = "txtDestreza";
            this.txtDestreza.Size = new System.Drawing.Size(207, 29);
            this.txtDestreza.TabIndex = 7;
            // 
            // lblDestreza
            // 
            this.lblDestreza.AutoSize = true;
            this.lblDestreza.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDestreza.Location = new System.Drawing.Point(10, 96);
            this.lblDestreza.Name = "lblDestreza";
            this.lblDestreza.Size = new System.Drawing.Size(70, 21);
            this.lblDestreza.TabIndex = 8;
            this.lblDestreza.Text = "Destreza";
            // 
            // txtFuerza
            // 
            this.txtFuerza.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFuerza.Location = new System.Drawing.Point(10, 56);
            this.txtFuerza.Name = "txtFuerza";
            this.txtFuerza.Size = new System.Drawing.Size(207, 29);
            this.txtFuerza.TabIndex = 5;
            // 
            // lblFuerza
            // 
            this.lblFuerza.AutoSize = true;
            this.lblFuerza.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFuerza.Location = new System.Drawing.Point(10, 32);
            this.lblFuerza.Name = "lblFuerza";
            this.lblFuerza.Size = new System.Drawing.Size(56, 21);
            this.lblFuerza.TabIndex = 6;
            this.lblFuerza.Text = "Fuerza";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.Location = new System.Drawing.Point(614, 178);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(216, 63);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar Personaje";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // FormIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 624);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grbCaracteristicas);
            this.Controls.Add(this.lblNombreJugador);
            this.Controls.Add(this.txtNombreJugador);
            this.Controls.Add(this.grbPersonaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha Personaje";
            this.Load += new System.EventHandler(this.FormIngreso_Load);
            this.grbPersonaje.ResumeLayout(false);
            this.grbPersonaje.PerformLayout();
            this.grbCaracteristicas.ResumeLayout(false);
            this.grbCaracteristicas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombrePersonaje;
        private System.Windows.Forms.ComboBox cmbEscuela;
        private System.Windows.Forms.GroupBox grbPersonaje;
        private System.Windows.Forms.Label lblEscuelaHechicero;
        private System.Windows.Forms.Label lblClase;
        private System.Windows.Forms.Label lblPersonaje;
        private System.Windows.Forms.ComboBox cmbClase;
        private System.Windows.Forms.TextBox txtNombreJugador;
        private System.Windows.Forms.Label lblNombreJugador;
        private System.Windows.Forms.GroupBox grbCaracteristicas;
        private System.Windows.Forms.TextBox txtVidaPersonaje;
        private System.Windows.Forms.Label lblVida;
        private System.Windows.Forms.TextBox txtCarisma;
        private System.Windows.Forms.Label lblCarisma;
        private System.Windows.Forms.TextBox txtSabiduria;
        private System.Windows.Forms.Label lblSabiduria;
        private System.Windows.Forms.TextBox txtInteligencia;
        private System.Windows.Forms.Label lblInteligencia;
        private System.Windows.Forms.TextBox txtConstitucion;
        private System.Windows.Forms.Label lblConstitucion;
        private System.Windows.Forms.TextBox txtDestreza;
        private System.Windows.Forms.Label lblDestreza;
        private System.Windows.Forms.TextBox txtFuerza;
        private System.Windows.Forms.Label lblFuerza;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Button btnAgregar;
    }
}
