namespace Not_Kayit_Sistemi
{
    partial class FrmOgrenciGiris
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
            this.label1 = new System.Windows.Forms.Label();
            this.MskOgrenciNumara = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ÖĞRENCİ NUMARA:";
            // 
            // MskOgrenciNumara
            // 
            this.MskOgrenciNumara.Location = new System.Drawing.Point(278, 42);
            this.MskOgrenciNumara.Mask = "0000";
            this.MskOgrenciNumara.Name = "MskOgrenciNumara";
            this.MskOgrenciNumara.Size = new System.Drawing.Size(121, 30);
            this.MskOgrenciNumara.TabIndex = 1;
            this.MskOgrenciNumara.ValidatingType = typeof(int);
            this.MskOgrenciNumara.TextChanged += new System.EventHandler(this.MskOgrenciNumara_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Giriş Yap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmOgrenciGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(579, 163);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MskOgrenciNumara);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOgrenciGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrenci Not Kayıt Sistemi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MskOgrenciNumara;
        private System.Windows.Forms.Button button1;
    }
}

