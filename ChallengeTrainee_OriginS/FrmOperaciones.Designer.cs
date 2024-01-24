namespace Presentation
{
    partial class FrmOperaciones
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
            label1 = new Label();
            label2 = new Label();
            lblCliente = new Label();
            btnBalance = new Button();
            btnRetiro = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(117, 40);
            label1.Name = "label1";
            label1.Size = new Size(307, 32);
            label1.TabIndex = 41;
            label1.Text = "Selecciona tu Transacción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(216, 111);
            label2.Name = "label2";
            label2.Size = new Size(97, 32);
            label2.TabIndex = 42;
            label2.Text = "Titular:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblCliente.Location = new Point(174, 143);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(0, 32);
            lblCliente.TabIndex = 43;
            // 
            // btnBalance
            // 
            btnBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBalance.Location = new Point(61, 253);
            btnBalance.Name = "btnBalance";
            btnBalance.Size = new Size(125, 70);
            btnBalance.TabIndex = 44;
            btnBalance.Text = "Balance";
            btnBalance.UseVisualStyleBackColor = true;
            btnBalance.Click += btnBalance_Click;
            // 
            // btnRetiro
            // 
            btnRetiro.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRetiro.Location = new Point(356, 253);
            btnRetiro.Name = "btnRetiro";
            btnRetiro.Size = new Size(125, 70);
            btnRetiro.TabIndex = 45;
            btnRetiro.Text = "Retirar Saldo";
            btnRetiro.UseVisualStyleBackColor = true;
            btnRetiro.Click += btnRetiro_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.Location = new Point(12, 452);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(79, 44);
            btnSalir.TabIndex = 46;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmOperaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 508);
            Controls.Add(btnSalir);
            Controls.Add(btnRetiro);
            Controls.Add(btnBalance);
            Controls.Add(lblCliente);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmOperaciones";
            Text = "FrmOperaciones";
            Load += FrmOperaciones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblCliente;
        private Button btnBalance;
        private Button btnRetiro;
        private Button btnSalir;
    }
}