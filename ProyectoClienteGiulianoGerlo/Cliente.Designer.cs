
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
            this.SuspendLayout();
            // 
            // entradaTxt
            // 
            this.entradaTxt.Location = new System.Drawing.Point(39, 12);
            this.entradaTxt.Name = "entradaTxt";
            this.entradaTxt.Size = new System.Drawing.Size(504, 23);
            this.entradaTxt.TabIndex = 0;
            this.entradaTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entradaTxt_KeyDown);
            // 
            // salidaTxt
            // 
            this.salidaTxt.Location = new System.Drawing.Point(39, 64);
            this.salidaTxt.Multiline = true;
            this.salidaTxt.Name = "salidaTxt";
            this.salidaTxt.ReadOnly = true;
            this.salidaTxt.Size = new System.Drawing.Size(504, 271);
            this.salidaTxt.TabIndex = 1;
            this.salidaTxt.TextChanged += new System.EventHandler(this.salidaTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // direccionTxt
            // 
            this.direccionTxt.Location = new System.Drawing.Point(595, 12);
            this.direccionTxt.Name = "direccionTxt";
            this.direccionTxt.Size = new System.Drawing.Size(100, 23);
            this.direccionTxt.TabIndex = 3;
            // 
            // ClienteChatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 362);
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
    }
}

