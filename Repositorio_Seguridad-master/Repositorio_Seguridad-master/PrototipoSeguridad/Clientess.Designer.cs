namespace PrototipoSeguridad
{
    partial class Clientess
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
            this.primarykey = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.navegador1 = new Navegador.Navegador();
            this.SuspendLayout();
            // 
            // primarykey
            // 
            this.primarykey.Location = new System.Drawing.Point(170, 270);
            this.primarykey.Name = "primarykey";
            this.primarykey.Size = new System.Drawing.Size(100, 22);
            this.primarykey.TabIndex = 1;
            this.primarykey.Tag = "id_perfil";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(369, 270);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "nombre_perfil";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(534, 270);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "descripcion_perfil";
            // 
            // navegador1
            // 
            this.navegador1.BackColor = System.Drawing.Color.Gainsboro;
            this.navegador1.Location = new System.Drawing.Point(36, 46);
            this.navegador1.Margin = new System.Windows.Forms.Padding(4);
            this.navegador1.Name = "navegador1";
            this.navegador1.sAppNumero = "6";
            this.navegador1.Size = new System.Drawing.Size(900, 82);
            this.navegador1.sNom_Usuario = "3";
            this.navegador1.sNombreBD = "bd_seguridad";
            this.navegador1.sNombreTabla = "perfil";
            this.navegador1.sPass = null;
            this.navegador1.sServidor = "localhost";
            this.navegador1.sUsuario = "root";
            this.navegador1.TabIndex = 5;
            this.navegador1.NavInsertar += new System.EventHandler(this.navegador1_NavInsertar);
            this.navegador1.NavActualizar += new System.EventHandler(this.navegador1_NavActualizar);
            this.navegador1.NavEliminar += new System.EventHandler(this.navegador1_NavEliminar);
            this.navegador1.NavGuardar += new System.EventHandler(this.navegador1_NavGuardar);
            this.navegador1.NavInicio += new System.EventHandler(this.navegador1_NavInicio);
            this.navegador1.NavAnterior += new System.EventHandler(this.navegador1_NavAnterior);
            this.navegador1.NavSiguiente += new System.EventHandler(this.navegador1_NavSiguiente);
            this.navegador1.NavFin += new System.EventHandler(this.navegador1_NavFin);
            this.navegador1.NavSalir += new System.EventHandler(this.navegador1_NavSalir);
            // 
            // Clientess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 563);
            this.Controls.Add(this.navegador1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.primarykey);
            this.Name = "Clientess";
            this.Text = "Clientess";
            this.Load += new System.EventHandler(this.Clientess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox primarykey;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private Navegador.Navegador navegador1;
    }
}