namespace proyecto
{
    partial class FormGestAhorrar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvmetas = new System.Windows.Forms.DataGridView();
            this.txtAhorro = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblNumAhorros = new System.Windows.Forms.Label();
            this.lblNomMeta = new System.Windows.Forms.Label();
            this.lblMeta = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmetas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnGuardar.Location = new System.Drawing.Point(228, 482);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(99, 32);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvmetas
            // 
            this.dgvmetas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.dgvmetas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvmetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvmetas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvmetas.EnableHeadersVisualStyles = false;
            this.dgvmetas.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvmetas.Location = new System.Drawing.Point(329, 78);
            this.dgvmetas.Name = "dgvmetas";
            this.dgvmetas.RowHeadersWidth = 51;
            this.dgvmetas.Size = new System.Drawing.Size(437, 376);
            this.dgvmetas.TabIndex = 19;
            // 
            // txtAhorro
            // 
            this.txtAhorro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.txtAhorro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAhorro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAhorro.ForeColor = System.Drawing.Color.DimGray;
            this.txtAhorro.Location = new System.Drawing.Point(40, 105);
            this.txtAhorro.Name = "txtAhorro";
            this.txtAhorro.Size = new System.Drawing.Size(166, 19);
            this.txtAhorro.TabIndex = 21;
            this.txtAhorro.Text = "Ingrese Ahorro";
            this.txtAhorro.Enter += new System.EventHandler(this.txtAhorro_Enter);
            this.txtAhorro.Leave += new System.EventHandler(this.txtAhorro_Leave);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 255);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(204, 23);
            this.progressBar1.TabIndex = 22;
            // 
            // lblNumAhorros
            // 
            this.lblNumAhorros.AutoSize = true;
            this.lblNumAhorros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAhorros.ForeColor = System.Drawing.Color.White;
            this.lblNumAhorros.Location = new System.Drawing.Point(19, 239);
            this.lblNumAhorros.Name = "lblNumAhorros";
            this.lblNumAhorros.Size = new System.Drawing.Size(43, 13);
            this.lblNumAhorros.TabIndex = 23;
            this.lblNumAhorros.Text = "Ahorros";
            // 
            // lblNomMeta
            // 
            this.lblNomMeta.AutoSize = true;
            this.lblNomMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.lblNomMeta.Location = new System.Drawing.Point(51, 168);
            this.lblNomMeta.Name = "lblNomMeta";
            this.lblNomMeta.Size = new System.Drawing.Size(130, 20);
            this.lblNomMeta.TabIndex = 25;
            this.lblNomMeta.Text = "Nombre De Meta";
            // 
            // lblMeta
            // 
            this.lblMeta.AutoSize = true;
            this.lblMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeta.ForeColor = System.Drawing.Color.White;
            this.lblMeta.Location = new System.Drawing.Point(213, 239);
            this.lblMeta.Name = "lblMeta";
            this.lblMeta.Size = new System.Drawing.Size(31, 13);
            this.lblMeta.TabIndex = 26;
            this.lblMeta.Text = "Meta";
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.btnAtras.Location = new System.Drawing.Point(418, 482);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(99, 32);
            this.btnAtras.TabIndex = 27;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 50);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(236, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 33);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nombre De Meta";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.panel2.Controls.Add(this.txtAhorro);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.lblMeta);
            this.panel2.Controls.Add(this.lblNumAhorros);
            this.panel2.Controls.Add(this.lblNomMeta);
            this.panel2.Location = new System.Drawing.Point(12, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 350);
            this.panel2.TabIndex = 29;
            // 
            // FormGestAhorrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(774, 601);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvmetas);
            this.Controls.Add(this.panel1);
            this.Name = "FormGestAhorrar";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvmetas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvmetas;
        private System.Windows.Forms.TextBox txtAhorro;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblNumAhorros;
        private System.Windows.Forms.Label lblNomMeta;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}