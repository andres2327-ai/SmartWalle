namespace proyecto
{
    partial class FormAhorro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregarMeta = new System.Windows.Forms.Button();
            this.txtNombreMe = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGestionar = new System.Windows.Forms.Button();
            this.dgvMetas = new System.Windows.Forms.DataGridView();
            this.labe = new System.Windows.Forms.Label();
            this.btnsalir = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meta";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.PowderBlue;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.txtCantidad.Location = new System.Drawing.Point(154, 100);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(145, 24);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.Text = "Cantidad";
            this.txtCantidad.Enter += new System.EventHandler(this.txtCantidad_Enter);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // btnAgregarMeta
            // 
            this.btnAgregarMeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(255)))));
            this.btnAgregarMeta.FlatAppearance.BorderSize = 0;
            this.btnAgregarMeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMeta.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMeta.Location = new System.Drawing.Point(113, 201);
            this.btnAgregarMeta.Name = "btnAgregarMeta";
            this.btnAgregarMeta.Size = new System.Drawing.Size(216, 52);
            this.btnAgregarMeta.TabIndex = 5;
            this.btnAgregarMeta.Text = "Crea tu Meta";
            this.btnAgregarMeta.UseVisualStyleBackColor = false;
            this.btnAgregarMeta.Click += new System.EventHandler(this.btnAgregarMeta_Click_1);
            // 
            // txtNombreMe
            // 
            this.txtNombreMe.BackColor = System.Drawing.Color.PowderBlue;
            this.txtNombreMe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.txtNombreMe.Location = new System.Drawing.Point(116, 141);
            this.txtNombreMe.Name = "txtNombreMe";
            this.txtNombreMe.Size = new System.Drawing.Size(213, 24);
            this.txtNombreMe.TabIndex = 9;
            this.txtNombreMe.Text = "Nombre de tu Meta";
            this.txtNombreMe.Enter += new System.EventHandler(this.txtNombreMe_Enter);
            this.txtNombreMe.Leave += new System.EventHandler(this.txtNombreMe_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.panel5.Controls.Add(this.btnAgregarMeta);
            this.panel5.Controls.Add(this.txtCantidad);
            this.panel5.Controls.Add(this.txtNombreMe);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(450, 603);
            this.panel5.TabIndex = 16;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnEliminar.Location = new System.Drawing.Point(663, 402);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 32);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnGestionar
            // 
            this.btnGestionar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGestionar.FlatAppearance.BorderSize = 0;
            this.btnGestionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnGestionar.Location = new System.Drawing.Point(478, 402);
            this.btnGestionar.Name = "btnGestionar";
            this.btnGestionar.Size = new System.Drawing.Size(99, 32);
            this.btnGestionar.TabIndex = 18;
            this.btnGestionar.Text = "Gestionar";
            this.btnGestionar.UseVisualStyleBackColor = false;
            this.btnGestionar.Click += new System.EventHandler(this.btnGestionar_Click_1);
            // 
            // dgvMetas
            // 
            this.dgvMetas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.dgvMetas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMetas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMetas.EnableHeadersVisualStyles = false;
            this.dgvMetas.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvMetas.Location = new System.Drawing.Point(478, 81);
            this.dgvMetas.Name = "dgvMetas";
            this.dgvMetas.RowHeadersWidth = 51;
            this.dgvMetas.Size = new System.Drawing.Size(284, 250);
            this.dgvMetas.TabIndex = 17;
            // 
            // labe
            // 
            this.labe.AutoSize = true;
            this.labe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labe.Location = new System.Drawing.Point(591, 25);
            this.labe.Name = "labe";
            this.labe.Size = new System.Drawing.Size(71, 25);
            this.labe.TabIndex = 16;
            this.labe.Text = "Metas";
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnsalir.FlatAppearance.BorderSize = 0;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnsalir.Location = new System.Drawing.Point(569, 459);
            this.btnsalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(107, 38);
            this.btnsalir.TabIndex = 20;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click_1);
            // 
            // FormAhorro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(818, 601);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.labe);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGestionar);
            this.Controls.Add(this.dgvMetas);
            this.Controls.Add(this.panel5);
            this.Name = "FormAhorro";
            this.Text = "FormAgregar";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregarMeta;
        private System.Windows.Forms.TextBox txtNombreMe;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGestionar;
        private System.Windows.Forms.DataGridView dgvMetas;
        private System.Windows.Forms.Label labe;
        private System.Windows.Forms.Button btnsalir;
    }
}