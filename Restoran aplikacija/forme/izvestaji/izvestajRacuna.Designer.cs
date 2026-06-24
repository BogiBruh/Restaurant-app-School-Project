namespace Restoran_aplikacija.forme.izvestaji
{
    partial class izvestajRacuna
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
            this.dgridRacun = new System.Windows.Forms.DataGridView();
            this.btnOtvoriRacun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dpickerOd = new System.Windows.Forms.DateTimePicker();
            this.dpickerDo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBrRacuna = new System.Windows.Forms.Label();
            this.lblZarada = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNajprodavanijiPrilog = new System.Windows.Forms.Label();
            this.lblNajprodavanijeJelo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridRacun)).BeginInit();
            this.SuspendLayout();
            // 
            // dgridRacun
            // 
            this.dgridRacun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridRacun.Location = new System.Drawing.Point(12, 66);
            this.dgridRacun.Name = "dgridRacun";
            this.dgridRacun.Size = new System.Drawing.Size(442, 461);
            this.dgridRacun.TabIndex = 0;
            // 
            // btnOtvoriRacun
            // 
            this.btnOtvoriRacun.Location = new System.Drawing.Point(12, 533);
            this.btnOtvoriRacun.Name = "btnOtvoriRacun";
            this.btnOtvoriRacun.Size = new System.Drawing.Size(107, 46);
            this.btnOtvoriRacun.TabIndex = 1;
            this.btnOtvoriRacun.Text = "Prikazi racun";
            this.btnOtvoriRacun.UseVisualStyleBackColor = true;
            this.btnOtvoriRacun.Click += new System.EventHandler(this.btnOtvoriRacun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtriraj po datumu:";
            // 
            // dpickerOd
            // 
            this.dpickerOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerOd.Location = new System.Drawing.Point(140, 13);
            this.dpickerOd.Name = "dpickerOd";
            this.dpickerOd.Size = new System.Drawing.Size(200, 20);
            this.dpickerOd.TabIndex = 3;
            // 
            // dpickerDo
            // 
            this.dpickerDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerDo.Location = new System.Drawing.Point(140, 40);
            this.dpickerDo.Name = "dpickerDo";
            this.dpickerDo.Size = new System.Drawing.Size(200, 20);
            this.dpickerDo.TabIndex = 4;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(359, 13);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(84, 47);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Od";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Do";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 533);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Broj racuna u ovom periodu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 566);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ukupna zarada u ovom periodu:";
            // 
            // lblBrRacuna
            // 
            this.lblBrRacuna.AutoSize = true;
            this.lblBrRacuna.Location = new System.Drawing.Point(302, 533);
            this.lblBrRacuna.Name = "lblBrRacuna";
            this.lblBrRacuna.Size = new System.Drawing.Size(35, 13);
            this.lblBrRacuna.TabIndex = 10;
            this.lblBrRacuna.Text = "label6";
            // 
            // lblZarada
            // 
            this.lblZarada.AutoSize = true;
            this.lblZarada.Location = new System.Drawing.Point(302, 566);
            this.lblZarada.Name = "lblZarada";
            this.lblZarada.Size = new System.Drawing.Size(35, 13);
            this.lblZarada.TabIndex = 11;
            this.lblZarada.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 596);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Najprodavanije jelo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 618);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Najprodavaniji prilog:";
            // 
            // lblNajprodavanijiPrilog
            // 
            this.lblNajprodavanijiPrilog.AutoSize = true;
            this.lblNajprodavanijiPrilog.Location = new System.Drawing.Point(128, 617);
            this.lblNajprodavanijiPrilog.Name = "lblNajprodavanijiPrilog";
            this.lblNajprodavanijiPrilog.Size = new System.Drawing.Size(35, 13);
            this.lblNajprodavanijiPrilog.TabIndex = 14;
            this.lblNajprodavanijiPrilog.Text = "label8";
            // 
            // lblNajprodavanijeJelo
            // 
            this.lblNajprodavanijeJelo.AutoSize = true;
            this.lblNajprodavanijeJelo.Location = new System.Drawing.Point(131, 596);
            this.lblNajprodavanijeJelo.Name = "lblNajprodavanijeJelo";
            this.lblNajprodavanijeJelo.Size = new System.Drawing.Size(35, 13);
            this.lblNajprodavanijeJelo.TabIndex = 15;
            this.lblNajprodavanijeJelo.Text = "label9";
            // 
            // izvestajRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 672);
            this.Controls.Add(this.lblNajprodavanijeJelo);
            this.Controls.Add(this.lblNajprodavanijiPrilog);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblZarada);
            this.Controls.Add(this.lblBrRacuna);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dpickerDo);
            this.Controls.Add(this.dpickerOd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOtvoriRacun);
            this.Controls.Add(this.dgridRacun);
            this.Name = "izvestajRacuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izvestaji racuna";
            this.Load += new System.EventHandler(this.izvestajRacuna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridRacun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridRacun;
        private System.Windows.Forms.Button btnOtvoriRacun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpickerOd;
        private System.Windows.Forms.DateTimePicker dpickerDo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBrRacuna;
        private System.Windows.Forms.Label lblZarada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNajprodavanijiPrilog;
        private System.Windows.Forms.Label lblNajprodavanijeJelo;
    }
}