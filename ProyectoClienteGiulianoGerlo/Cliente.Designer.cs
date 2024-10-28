
namespace ProyectoClienteGiulianoGerlo
{
    partial class ClienteChatFrm
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
            this.entradaTxt = new System.Windows.Forms.TextBox();
            this.salidaTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.direccionTxt = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnConexion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // entradaTxt
            // 
            this.entradaTxt.Location = new System.Drawing.Point(39, 26);
            this.entradaTxt.Name = "entradaTxt";
            this.entradaTxt.Size = new System.Drawing.Size(411, 23);
            this.entradaTxt.TabIndex = 0;
            this.entradaTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaTxt_KeyDown);
            // 
            // salidaTxt
            // 
            this.salidaTxt.Location = new System.Drawing.Point(39, 64);
            this.salidaTxt.Multiline = true;
            this.salidaTxt.Name = "salidaTxt";
            this.salidaTxt.ReadOnly = true;
            this.salidaTxt.Size = new System.Drawing.Size(411, 209);
            this.salidaTxt.TabIndex = 1;
            this.salidaTxt.TextChanged += new System.EventHandler(this.salidaTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // direccionTxt
            // 
            this.direccionTxt.Location = new System.Drawing.Point(524, 26);
            this.direccionTxt.Name = "direccionTxt";
            this.direccionTxt.Size = new System.Drawing.Size(100, 23);
            this.direccionTxt.TabIndex = 3;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(586, 312);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Inicar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnConexion
            // 
            this.btnConexion.Location = new System.Drawing.Point(524, 250);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(75, 23);
            this.btnConexion.TabIndex = 5;
            this.btnConexion.Text = "Iniciar";
            this.btnConexion.UseVisualStyleBackColor = true;
            this.btnConexion.Click += new System.EventHandler(this.btnConexion_Click);
            // 
            // ClienteChatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 311);
            this.Controls.Add(this.btnConexion);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.direccionTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salidaTxt);
            this.Controls.Add(this.entradaTxt);
            this.Name = "ClienteChatFrm";
            this.Text = "Chat Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClienteChatFrm_FormClosing);
            this.Load += new System.EventHandler(this.ClienteChatFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entradaTxt;
        private System.Windows.Forms.TextBox salidaTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox direccionTxt;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnConexion;
    }
}

