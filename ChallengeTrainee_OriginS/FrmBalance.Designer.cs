namespace Presentation
{
    partial class FrmBalance
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
            btnSalir = new Button();
            btnAtras = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblNumTarjeta = new Label();
            lblSaldo = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDNI = new Label();
            lblFechaVcto = new Label();
            label13 = new Label();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.Location = new Point(412, 444);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(110, 52);
            btnSalir.TabIndex = 47;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAtras
            // 
            btnAtras.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtras.Location = new Point(12, 444);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(110, 52);
            btnAtras.TabIndex = 48;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(79, 117);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 49;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(79, 156);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 50;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(118, 195);
            label3.Name = "label3";
            label3.Size = new Size(52, 25);
            label3.TabIndex = 51;
            label3.Text = "DNI:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(49, 235);
            label4.Name = "label4";
            label4.Size = new Size(121, 25);
            label4.TabIndex = 52;
            label4.Text = "Nro. Tarjeta:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(103, 280);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 53;
            label5.Text = "Saldo: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(33, 325);
            label6.Name = "label6";
            label6.Size = new Size(137, 25);
            label6.TabIndex = 54;
            label6.Text = "Fecha de vcto:";
            // 
            // lblNumTarjeta
            // 
            lblNumTarjeta.AutoSize = true;
            lblNumTarjeta.BackColor = Color.Gainsboro;
            lblNumTarjeta.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumTarjeta.Location = new Point(176, 235);
            lblNumTarjeta.Name = "lblNumTarjeta";
            lblNumTarjeta.Size = new Size(17, 25);
            lblNumTarjeta.TabIndex = 55;
            lblNumTarjeta.Text = " ";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.BackColor = Color.Gainsboro;
            lblSaldo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSaldo.Location = new Point(176, 280);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(17, 25);
            lblSaldo.TabIndex = 56;
            lblSaldo.Text = " ";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Gainsboro;
            lblNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(176, 117);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(17, 25);
            lblNombre.TabIndex = 57;
            lblNombre.Text = " ";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.BackColor = Color.Gainsboro;
            lblApellido.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblApellido.Location = new Point(176, 156);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(17, 25);
            lblApellido.TabIndex = 58;
            lblApellido.Text = " ";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.BackColor = Color.Gainsboro;
            lblDNI.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDNI.Location = new Point(176, 195);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(17, 25);
            lblDNI.TabIndex = 59;
            lblDNI.Text = " ";
            // 
            // lblFechaVcto
            // 
            lblFechaVcto.AutoSize = true;
            lblFechaVcto.BackColor = Color.Gainsboro;
            lblFechaVcto.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaVcto.Location = new Point(176, 325);
            lblFechaVcto.Name = "lblFechaVcto";
            lblFechaVcto.Size = new Size(17, 25);
            lblFechaVcto.TabIndex = 60;
            lblFechaVcto.Text = " ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(210, 39);
            label13.Name = "label13";
            label13.Size = new Size(102, 32);
            label13.TabIndex = 61;
            label13.Text = "Balance";
            // 
            // FrmBalance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 508);
            Controls.Add(label13);
            Controls.Add(lblFechaVcto);
            Controls.Add(lblDNI);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblSaldo);
            Controls.Add(lblNumTarjeta);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAtras);
            Controls.Add(btnSalir);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmBalance";
            Text = "FrmBalance";
            Load += FrmBalance_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Button btnAtras;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblNumTarjeta;
        private Label lblSaldo;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDNI;
        private Label lblFechaVcto;
        private Label label13;
    }
}