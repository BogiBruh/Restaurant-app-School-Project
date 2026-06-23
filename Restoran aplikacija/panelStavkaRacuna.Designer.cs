namespace Restoran_aplikacija
{
    partial class panelStavkaRacuna
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNazivJela = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNazivPriloga = new System.Windows.Forms.Label();
            this.lblCenaJela = new System.Windows.Forms.Label();
            this.lblCenaPriloga = new System.Windows.Forms.Label();
            this.btnDeleteStavka = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNazivJela
            // 
            this.lblNazivJela.AutoSize = true;
            this.lblNazivJela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivJela.Location = new System.Drawing.Point(4, 4);
            this.lblNazivJela.Name = "lblNazivJela";
            this.lblNazivJela.Size = new System.Drawing.Size(91, 20);
            this.lblNazivJela.TabIndex = 0;
            this.lblNazivJela.Text = "lblNazivJela";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prilog:";
            // 
            // lblNazivPriloga
            // 
            this.lblNazivPriloga.AutoSize = true;
            this.lblNazivPriloga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivPriloga.Location = new System.Drawing.Point(37, 54);
            this.lblNazivPriloga.Name = "lblNazivPriloga";
            this.lblNazivPriloga.Size = new System.Drawing.Size(98, 16);
            this.lblNazivPriloga.TabIndex = 2;
            this.lblNazivPriloga.Text = "lblNazivPriloga";
            // 
            // lblCenaJela
            // 
            this.lblCenaJela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCenaJela.Location = new System.Drawing.Point(162, 4);
            this.lblCenaJela.Name = "lblCenaJela";
            this.lblCenaJela.Size = new System.Drawing.Size(88, 23);
            this.lblCenaJela.TabIndex = 3;
            this.lblCenaJela.Text = "lblCenaJela";
            this.lblCenaJela.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCenaPriloga
            // 
            this.lblCenaPriloga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCenaPriloga.Location = new System.Drawing.Point(183, 54);
            this.lblCenaPriloga.Name = "lblCenaPriloga";
            this.lblCenaPriloga.Size = new System.Drawing.Size(67, 23);
            this.lblCenaPriloga.TabIndex = 4;
            this.lblCenaPriloga.Text = "lblCenaPriloga";
            this.lblCenaPriloga.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDeleteStavka
            // 
            this.btnDeleteStavka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteStavka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStavka.Location = new System.Drawing.Point(256, 4);
            this.btnDeleteStavka.Name = "btnDeleteStavka";
            this.btnDeleteStavka.Size = new System.Drawing.Size(43, 66);
            this.btnDeleteStavka.TabIndex = 5;
            this.btnDeleteStavka.Text = "X";
            this.btnDeleteStavka.UseVisualStyleBackColor = false;
            this.btnDeleteStavka.Click += new System.EventHandler(this.btnDeleteStavka_Click);
            // 
            // panelStavkaRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteStavka);
            this.Controls.Add(this.lblCenaPriloga);
            this.Controls.Add(this.lblCenaJela);
            this.Controls.Add(this.lblNazivPriloga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNazivJela);
            this.Name = "panelStavkaRacuna";
            this.Size = new System.Drawing.Size(305, 77);
            this.Load += new System.EventHandler(this.panelStavkaRacuna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNazivJela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNazivPriloga;
        private System.Windows.Forms.Label lblCenaJela;
        private System.Windows.Forms.Label lblCenaPriloga;
        private System.Windows.Forms.Button btnDeleteStavka;
    }
}
