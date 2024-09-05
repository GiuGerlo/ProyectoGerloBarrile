
namespace ProyectoServidorGerloBarrile
{
    partial class Servidor
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
            this.SuspendLayout();
            // 
            // entradaTxt
            // 
            this.entradaTxt.Location = new System.Drawing.Point(47, 23);
            this.entradaTxt.Name = "entradaTxt";
            this.entradaTxt.Size = new System.Drawing.Size(411, 23);
            this.entradaTxt.TabIndex = 0;
            // 
            // salidaTxt
            // 
            this.salidaTxt.Location = new System.Drawing.Point(47, 76);
            this.salidaTxt.Name = "salidaTxt";
            this.salidaTxt.Size = new System.Drawing.Size(411, 23);
            this.salidaTxt.TabIndex = 1;
            // 
            // Servidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 331);
            this.Controls.Add(this.salidaTxt);
            this.Controls.Add(this.entradaTxt);
            this.Name = "Servidor";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Servidor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entradaTxt;
        private System.Windows.Forms.TextBox salidaTxt;
    }
}

