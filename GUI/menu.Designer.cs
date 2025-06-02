namespace GUI
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.btnTransacciones = new System.Windows.Forms.Button();
            this.lbusuario = new System.Windows.Forms.Label();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lblNombUser = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblpresupuesto = new System.Windows.Forms.Label();
            this.btnsumar = new System.Windows.Forms.Button();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.btnrestar = new System.Windows.Forms.Button();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDeudas = new System.Windows.Forms.Button();
            this.btnAhorros = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContenedor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransacciones
            // 
            this.btnTransacciones.FlatAppearance.BorderSize = 0;
            this.btnTransacciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransacciones.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTransacciones.Location = new System.Drawing.Point(2, 91);
            this.btnTransacciones.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransacciones.Name = "btnTransacciones";
            this.btnTransacciones.Size = new System.Drawing.Size(231, 31);
            this.btnTransacciones.TabIndex = 0;
            this.btnTransacciones.Text = "Transacciones";
            this.btnTransacciones.UseVisualStyleBackColor = true;
            this.btnTransacciones.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbusuario
            // 
            this.lbusuario.AutoSize = true;
            this.lbusuario.Location = new System.Drawing.Point(131, 44);
            this.lbusuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbusuario.Name = "lbusuario";
            this.lbusuario.Size = new System.Drawing.Size(0, 13);
            this.lbusuario.TabIndex = 2;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.panelContenedor.Controls.Add(this.lblNombUser);
            this.panelContenedor.Controls.Add(this.label4);
            this.panelContenedor.Controls.Add(this.label3);
            this.panelContenedor.Controls.Add(this.panel1);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(230, 0);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(597, 452);
            this.panelContenedor.TabIndex = 4;
            // 
            // lblNombUser
            // 
            this.lblNombUser.AutoSize = true;
            this.lblNombUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombUser.Location = new System.Drawing.Point(308, 25);
            this.lblNombUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombUser.Name = "lblNombUser";
            this.lblNombUser.Size = new System.Drawing.Size(197, 25);
            this.lblNombUser.TabIndex = 8;
            this.lblNombUser.Text = "nombre de usuario!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(545, 50);
            this.label4.TabIndex = 7;
            this.label4.Text = "lleva el seguimiento de tus deudas desde un solo lugar.\n ¡Comienza a tomar el con" +
    "trol de tus finanzas!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(514, 50);
            this.label3.TabIndex = 5;
            this.label3.Text = "¡Bienvenido a SmartWallet,\nAdministra tus transacciones, controla tus ahorros y ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblpresupuesto);
            this.panel1.Controls.Add(this.btnsumar);
            this.panel1.Controls.Add(this.txtmonto);
            this.panel1.Controls.Add(this.btnrestar);
            this.panel1.Location = new System.Drawing.Point(121, 193);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 167);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "PRESUPUESTO ACTUAL:";
            // 
            // lblpresupuesto
            // 
            this.lblpresupuesto.AutoSize = true;
            this.lblpresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpresupuesto.Location = new System.Drawing.Point(224, 16);
            this.lblpresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblpresupuesto.Name = "lblpresupuesto";
            this.lblpresupuesto.Size = new System.Drawing.Size(76, 18);
            this.lblpresupuesto.TabIndex = 0;
            this.lblpresupuesto.Text = "NUMERO";
            // 
            // btnsumar
            // 
            this.btnsumar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnsumar.FlatAppearance.BorderSize = 0;
            this.btnsumar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsumar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsumar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.btnsumar.Location = new System.Drawing.Point(165, 121);
            this.btnsumar.Margin = new System.Windows.Forms.Padding(2);
            this.btnsumar.Name = "btnsumar";
            this.btnsumar.Size = new System.Drawing.Size(120, 30);
            this.btnsumar.TabIndex = 3;
            this.btnsumar.Text = "sumar";
            this.btnsumar.UseVisualStyleBackColor = false;
            this.btnsumar.Click += new System.EventHandler(this.btnsumar_Click);
            // 
            // txtmonto
            // 
            this.txtmonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.txtmonto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmonto.ForeColor = System.Drawing.Color.DimGray;
            this.txtmonto.Location = new System.Drawing.Point(50, 73);
            this.txtmonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(206, 17);
            this.txtmonto.TabIndex = 1;
            this.txtmonto.Text = "AGREGAR PRESUPUESTO";
            this.txtmonto.Enter += new System.EventHandler(this.txtmonto_Enter);
            this.txtmonto.Leave += new System.EventHandler(this.txtmonto_Leave);
            // 
            // btnrestar
            // 
            this.btnrestar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnrestar.FlatAppearance.BorderSize = 0;
            this.btnrestar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrestar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrestar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.btnrestar.Location = new System.Drawing.Point(7, 122);
            this.btnrestar.Margin = new System.Windows.Forms.Padding(2);
            this.btnrestar.Name = "btnrestar";
            this.btnrestar.Size = new System.Drawing.Size(120, 29);
            this.btnrestar.TabIndex = 2;
            this.btnrestar.Text = "restar";
            this.btnrestar.UseVisualStyleBackColor = false;
            this.btnrestar.Click += new System.EventHandler(this.btnrestar_Click);
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.MenuVertical.Controls.Add(this.btnTransacciones);
            this.MenuVertical.Controls.Add(this.btnSalir);
            this.MenuVertical.Controls.Add(this.btnDeudas);
            this.MenuVertical.Controls.Add(this.btnAhorros);
            this.MenuVertical.Controls.Add(this.label2);
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(230, 452);
            this.MenuVertical.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnSalir.Location = new System.Drawing.Point(-2, 421);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(230, 31);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDeudas
            // 
            this.btnDeudas.FlatAppearance.BorderSize = 0;
            this.btnDeudas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDeudas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeudas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeudas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeudas.Location = new System.Drawing.Point(2, 203);
            this.btnDeudas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeudas.Name = "btnDeudas";
            this.btnDeudas.Size = new System.Drawing.Size(230, 31);
            this.btnDeudas.TabIndex = 5;
            this.btnDeudas.Text = "Deudas";
            this.btnDeudas.UseVisualStyleBackColor = true;
            this.btnDeudas.Click += new System.EventHandler(this.btnDeudas_Click);
            // 
            // btnAhorros
            // 
            this.btnAhorros.FlatAppearance.BorderSize = 0;
            this.btnAhorros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAhorros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAhorros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAhorros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAhorros.Location = new System.Drawing.Point(2, 150);
            this.btnAhorros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAhorros.Name = "btnAhorros";
            this.btnAhorros.Size = new System.Drawing.Size(227, 31);
            this.btnAhorros.TabIndex = 4;
            this.btnAhorros.Text = "Ahorros";
            this.btnAhorros.UseVisualStyleBackColor = true;
            this.btnAhorros.Click += new System.EventHandler(this.btnAhorros_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(52, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "SmartWallet";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 452);
            this.Controls.Add(this.lbusuario);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.MenuVertical);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.menu_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MenuVertical.ResumeLayout(false);
            this.MenuVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransacciones;
        private System.Windows.Forms.Label lbusuario;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDeudas;
        private System.Windows.Forms.Button btnAhorros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblpresupuesto;
        private System.Windows.Forms.Button btnsumar;
        private System.Windows.Forms.Button btnrestar;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombUser;
        private System.Windows.Forms.Label label4;
    }
}