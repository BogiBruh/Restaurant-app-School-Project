namespace Restoran_aplikacija
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodajNovuStavkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajJeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajPrilogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniStavkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniJeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniPrilogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poveziPrilogZaJeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odveziPrilogOdJelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izbrisiStavkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izbrisiJeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izbrisiPrilogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izvestajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racuniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFirstTable = new System.Windows.Forms.Button();
            this.btnSecondTable = new System.Windows.Forms.Button();
            this.btnThirdTable = new System.Windows.Forms.Button();
            this.btnFourthTable = new System.Windows.Forms.Button();
            this.btnFifthTable = new System.Windows.Forms.Button();
            this.btnSixthTable = new System.Windows.Forms.Button();
            this.panelRacun = new System.Windows.Forms.Panel();
            this.lblCena = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowStavke = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPlatiRacun = new System.Windows.Forms.Button();
            this.btnDodajStavku = new System.Windows.Forms.Button();
            this.btnHidePanel = new System.Windows.Forms.Button();
            this.lblBrStola = new System.Windows.Forms.Label();
            this.timerAnimacija = new System.Windows.Forms.Timer(this.components);
            this.panelJeloDana = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNazivJeloDana = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCenaJeloDana = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBrProdaja = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelRacun.SuspendLayout();
            this.panelJeloDana.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajNovuStavkuToolStripMenuItem,
            this.izmeniStavkuToolStripMenuItem,
            this.izbrisiStavkuToolStripMenuItem,
            this.izvestajiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1665, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodajNovuStavkuToolStripMenuItem
            // 
            this.dodajNovuStavkuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajJeloToolStripMenuItem,
            this.dodajPrilogToolStripMenuItem});
            this.dodajNovuStavkuToolStripMenuItem.Name = "dodajNovuStavkuToolStripMenuItem";
            this.dodajNovuStavkuToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.dodajNovuStavkuToolStripMenuItem.Text = "Dodaj novu stavku";
            // 
            // dodajJeloToolStripMenuItem
            // 
            this.dodajJeloToolStripMenuItem.Name = "dodajJeloToolStripMenuItem";
            this.dodajJeloToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.dodajJeloToolStripMenuItem.Text = "Dodaj jelo";
            this.dodajJeloToolStripMenuItem.Click += new System.EventHandler(this.dodajJeloToolStripMenuItem_Click);
            // 
            // dodajPrilogToolStripMenuItem
            // 
            this.dodajPrilogToolStripMenuItem.Name = "dodajPrilogToolStripMenuItem";
            this.dodajPrilogToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.dodajPrilogToolStripMenuItem.Text = "Dodaj prilog";
            this.dodajPrilogToolStripMenuItem.Click += new System.EventHandler(this.dodajPrilogToolStripMenuItem_Click);
            // 
            // izmeniStavkuToolStripMenuItem
            // 
            this.izmeniStavkuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izmeniJeloToolStripMenuItem,
            this.izmeniPrilogToolStripMenuItem,
            this.poveziPrilogZaJeloToolStripMenuItem,
            this.odveziPrilogOdJelaToolStripMenuItem});
            this.izmeniStavkuToolStripMenuItem.Name = "izmeniStavkuToolStripMenuItem";
            this.izmeniStavkuToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.izmeniStavkuToolStripMenuItem.Text = "Izmeni stavku";
            // 
            // izmeniJeloToolStripMenuItem
            // 
            this.izmeniJeloToolStripMenuItem.Name = "izmeniJeloToolStripMenuItem";
            this.izmeniJeloToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.izmeniJeloToolStripMenuItem.Text = "Izmeni jelo";
            this.izmeniJeloToolStripMenuItem.Click += new System.EventHandler(this.izmeniJeloToolStripMenuItem_Click);
            // 
            // izmeniPrilogToolStripMenuItem
            // 
            this.izmeniPrilogToolStripMenuItem.Name = "izmeniPrilogToolStripMenuItem";
            this.izmeniPrilogToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.izmeniPrilogToolStripMenuItem.Text = "Izmeni prilog";
            this.izmeniPrilogToolStripMenuItem.Click += new System.EventHandler(this.izmeniPrilogToolStripMenuItem_Click);
            // 
            // poveziPrilogZaJeloToolStripMenuItem
            // 
            this.poveziPrilogZaJeloToolStripMenuItem.Name = "poveziPrilogZaJeloToolStripMenuItem";
            this.poveziPrilogZaJeloToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.poveziPrilogZaJeloToolStripMenuItem.Text = "Povezi prilog za jelo";
            this.poveziPrilogZaJeloToolStripMenuItem.Click += new System.EventHandler(this.poveziPrilogZaJeloToolStripMenuItem_Click);
            // 
            // odveziPrilogOdJelaToolStripMenuItem
            // 
            this.odveziPrilogOdJelaToolStripMenuItem.Name = "odveziPrilogOdJelaToolStripMenuItem";
            this.odveziPrilogOdJelaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.odveziPrilogOdJelaToolStripMenuItem.Text = "Odvezi prilog od jela";
            this.odveziPrilogOdJelaToolStripMenuItem.Click += new System.EventHandler(this.odveziPrilogOdJelaToolStripMenuItem_Click);
            // 
            // izbrisiStavkuToolStripMenuItem
            // 
            this.izbrisiStavkuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izbrisiJeloToolStripMenuItem,
            this.izbrisiPrilogToolStripMenuItem});
            this.izbrisiStavkuToolStripMenuItem.Name = "izbrisiStavkuToolStripMenuItem";
            this.izbrisiStavkuToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.izbrisiStavkuToolStripMenuItem.Text = "Izbrisi stavku";
            // 
            // izbrisiJeloToolStripMenuItem
            // 
            this.izbrisiJeloToolStripMenuItem.Name = "izbrisiJeloToolStripMenuItem";
            this.izbrisiJeloToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.izbrisiJeloToolStripMenuItem.Text = "Izbrisi jelo";
            this.izbrisiJeloToolStripMenuItem.Click += new System.EventHandler(this.izbrisiJeloToolStripMenuItem_Click);
            // 
            // izbrisiPrilogToolStripMenuItem
            // 
            this.izbrisiPrilogToolStripMenuItem.Name = "izbrisiPrilogToolStripMenuItem";
            this.izbrisiPrilogToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.izbrisiPrilogToolStripMenuItem.Text = "Izbrisi prilog";
            this.izbrisiPrilogToolStripMenuItem.Click += new System.EventHandler(this.izbrisiPrilogToolStripMenuItem_Click);
            // 
            // izvestajiToolStripMenuItem
            // 
            this.izvestajiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.racuniToolStripMenuItem});
            this.izvestajiToolStripMenuItem.Name = "izvestajiToolStripMenuItem";
            this.izvestajiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.izvestajiToolStripMenuItem.Text = "Izvestaji";
            // 
            // racuniToolStripMenuItem
            // 
            this.racuniToolStripMenuItem.Name = "racuniToolStripMenuItem";
            this.racuniToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.racuniToolStripMenuItem.Text = "Racuni";
            this.racuniToolStripMenuItem.Click += new System.EventHandler(this.racuniToolStripMenuItem_Click);
            // 
            // btnFirstTable
            // 
            this.btnFirstTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirstTable.Location = new System.Drawing.Point(230, 127);
            this.btnFirstTable.Name = "btnFirstTable";
            this.btnFirstTable.Size = new System.Drawing.Size(110, 55);
            this.btnFirstTable.TabIndex = 1;
            this.btnFirstTable.Tag = "0";
            this.btnFirstTable.Text = "Kreiraj racun";
            this.btnFirstTable.UseVisualStyleBackColor = true;
            this.btnFirstTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnSecondTable
            // 
            this.btnSecondTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecondTable.Location = new System.Drawing.Point(552, 124);
            this.btnSecondTable.Name = "btnSecondTable";
            this.btnSecondTable.Size = new System.Drawing.Size(110, 55);
            this.btnSecondTable.TabIndex = 2;
            this.btnSecondTable.Tag = "1";
            this.btnSecondTable.Text = "Kreiraj racun";
            this.btnSecondTable.UseVisualStyleBackColor = true;
            this.btnSecondTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnThirdTable
            // 
            this.btnThirdTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThirdTable.Location = new System.Drawing.Point(849, 121);
            this.btnThirdTable.Name = "btnThirdTable";
            this.btnThirdTable.Size = new System.Drawing.Size(110, 55);
            this.btnThirdTable.TabIndex = 3;
            this.btnThirdTable.Tag = "2";
            this.btnThirdTable.Text = "Kreiraj racun";
            this.btnThirdTable.UseVisualStyleBackColor = true;
            this.btnThirdTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnFourthTable
            // 
            this.btnFourthTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFourthTable.Location = new System.Drawing.Point(160, 359);
            this.btnFourthTable.Name = "btnFourthTable";
            this.btnFourthTable.Size = new System.Drawing.Size(110, 55);
            this.btnFourthTable.TabIndex = 4;
            this.btnFourthTable.Tag = "3";
            this.btnFourthTable.Text = "Kreiraj racun";
            this.btnFourthTable.UseVisualStyleBackColor = true;
            this.btnFourthTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnFifthTable
            // 
            this.btnFifthTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFifthTable.Location = new System.Drawing.Point(552, 350);
            this.btnFifthTable.Name = "btnFifthTable";
            this.btnFifthTable.Size = new System.Drawing.Size(110, 55);
            this.btnFifthTable.TabIndex = 5;
            this.btnFifthTable.Tag = "4";
            this.btnFifthTable.Text = "Kreiraj racun";
            this.btnFifthTable.UseVisualStyleBackColor = true;
            this.btnFifthTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnSixthTable
            // 
            this.btnSixthTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSixthTable.Location = new System.Drawing.Point(587, 608);
            this.btnSixthTable.Name = "btnSixthTable";
            this.btnSixthTable.Size = new System.Drawing.Size(110, 55);
            this.btnSixthTable.TabIndex = 6;
            this.btnSixthTable.Tag = "5";
            this.btnSixthTable.Text = "Kreiraj racun";
            this.btnSixthTable.UseVisualStyleBackColor = true;
            this.btnSixthTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // panelRacun
            // 
            this.panelRacun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRacun.Controls.Add(this.lblCena);
            this.panelRacun.Controls.Add(this.label1);
            this.panelRacun.Controls.Add(this.flowStavke);
            this.panelRacun.Controls.Add(this.btnPlatiRacun);
            this.panelRacun.Controls.Add(this.btnDodajStavku);
            this.panelRacun.Controls.Add(this.btnHidePanel);
            this.panelRacun.Controls.Add(this.lblBrStola);
            this.panelRacun.Location = new System.Drawing.Point(1306, 27);
            this.panelRacun.Name = "panelRacun";
            this.panelRacun.Size = new System.Drawing.Size(350, 677);
            this.panelRacun.TabIndex = 7;
            // 
            // lblCena
            // 
            this.lblCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCena.Location = new System.Drawing.Point(128, 568);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(211, 23);
            this.lblCena.TabIndex = 6;
            this.lblCena.Text = "0 din";
            this.lblCena.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 567);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ukupna cena:";
            // 
            // flowStavke
            // 
            this.flowStavke.AutoScroll = true;
            this.flowStavke.Location = new System.Drawing.Point(8, 54);
            this.flowStavke.Name = "flowStavke";
            this.flowStavke.Size = new System.Drawing.Size(331, 497);
            this.flowStavke.TabIndex = 4;
            // 
            // btnPlatiRacun
            // 
            this.btnPlatiRacun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPlatiRacun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlatiRacun.Location = new System.Drawing.Point(225, 605);
            this.btnPlatiRacun.Name = "btnPlatiRacun";
            this.btnPlatiRacun.Size = new System.Drawing.Size(114, 67);
            this.btnPlatiRacun.TabIndex = 3;
            this.btnPlatiRacun.Text = "Plati Racun";
            this.btnPlatiRacun.UseVisualStyleBackColor = false;
            this.btnPlatiRacun.Click += new System.EventHandler(this.btnPlatiRacun_Click);
            // 
            // btnDodajStavku
            // 
            this.btnDodajStavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajStavku.Location = new System.Drawing.Point(8, 605);
            this.btnDodajStavku.Name = "btnDodajStavku";
            this.btnDodajStavku.Size = new System.Drawing.Size(114, 67);
            this.btnDodajStavku.TabIndex = 2;
            this.btnDodajStavku.Text = "+ Dodaj Stavku";
            this.btnDodajStavku.UseVisualStyleBackColor = true;
            this.btnDodajStavku.Click += new System.EventHandler(this.btnDodajStavku_Click);
            // 
            // btnHidePanel
            // 
            this.btnHidePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidePanel.Location = new System.Drawing.Point(225, 9);
            this.btnHidePanel.Name = "btnHidePanel";
            this.btnHidePanel.Size = new System.Drawing.Size(120, 36);
            this.btnHidePanel.TabIndex = 1;
            this.btnHidePanel.Text = "Skloni racun";
            this.btnHidePanel.UseVisualStyleBackColor = true;
            this.btnHidePanel.Click += new System.EventHandler(this.btnHidePanel_Click);
            // 
            // lblBrStola
            // 
            this.lblBrStola.AutoSize = true;
            this.lblBrStola.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrStola.Location = new System.Drawing.Point(3, 12);
            this.lblBrStola.Name = "lblBrStola";
            this.lblBrStola.Size = new System.Drawing.Size(114, 25);
            this.lblBrStola.TabIndex = 0;
            this.lblBrStola.Text = "lblBrStola";
            // 
            // timerAnimacija
            // 
            this.timerAnimacija.Enabled = true;
            this.timerAnimacija.Interval = 3000;
            this.timerAnimacija.Tick += new System.EventHandler(this.timerAnimacija_Tick);
            // 
            // panelJeloDana
            // 
            this.panelJeloDana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelJeloDana.Controls.Add(this.lblBrProdaja);
            this.panelJeloDana.Controls.Add(this.label4);
            this.panelJeloDana.Controls.Add(this.lblCenaJeloDana);
            this.panelJeloDana.Controls.Add(this.label3);
            this.panelJeloDana.Controls.Add(this.lblNazivJeloDana);
            this.panelJeloDana.Controls.Add(this.label2);
            this.panelJeloDana.Location = new System.Drawing.Point(1026, 258);
            this.panelJeloDana.Name = "panelJeloDana";
            this.panelJeloDana.Size = new System.Drawing.Size(254, 217);
            this.panelJeloDana.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "JELO DANA";
            // 
            // lblNazivJeloDana
            // 
            this.lblNazivJeloDana.AutoSize = true;
            this.lblNazivJeloDana.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivJeloDana.Location = new System.Drawing.Point(75, 45);
            this.lblNazivJeloDana.Name = "lblNazivJeloDana";
            this.lblNazivJeloDana.Size = new System.Drawing.Size(130, 20);
            this.lblNazivJeloDana.TabIndex = 1;
            this.lblNazivJeloDana.Text = "lblNazivJeloDana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cena:";
            // 
            // lblCenaJeloDana
            // 
            this.lblCenaJeloDana.AutoSize = true;
            this.lblCenaJeloDana.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCenaJeloDana.Location = new System.Drawing.Point(62, 88);
            this.lblCenaJeloDana.Name = "lblCenaJeloDana";
            this.lblCenaJeloDana.Size = new System.Drawing.Size(130, 20);
            this.lblCenaJeloDana.TabIndex = 3;
            this.lblCenaJeloDana.Text = "lblCenaJeloDana";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Broj prodaja:";
            // 
            // lblBrProdaja
            // 
            this.lblBrProdaja.AutoSize = true;
            this.lblBrProdaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrProdaja.Location = new System.Drawing.Point(105, 130);
            this.lblBrProdaja.Name = "lblBrProdaja";
            this.lblBrProdaja.Size = new System.Drawing.Size(94, 20);
            this.lblBrProdaja.TabIndex = 5;
            this.lblBrProdaja.Text = "lblBrProdaja";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Restoran_aplikacija.Properties.Resources.bgimgpng;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1665, 716);
            this.Controls.Add(this.panelJeloDana);
            this.Controls.Add(this.panelRacun);
            this.Controls.Add(this.btnSixthTable);
            this.Controls.Add(this.btnFifthTable);
            this.Controls.Add(this.btnFourthTable);
            this.Controls.Add(this.btnThirdTable);
            this.Controls.Add(this.btnSecondTable);
            this.Controls.Add(this.btnFirstTable);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restoran";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelRacun.ResumeLayout(false);
            this.panelRacun.PerformLayout();
            this.panelJeloDana.ResumeLayout(false);
            this.panelJeloDana.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajNovuStavkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajJeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajPrilogToolStripMenuItem;
        private System.Windows.Forms.Button btnFirstTable;
        private System.Windows.Forms.Button btnSecondTable;
        private System.Windows.Forms.Button btnThirdTable;
        private System.Windows.Forms.Button btnFourthTable;
        private System.Windows.Forms.Button btnFifthTable;
        private System.Windows.Forms.Button btnSixthTable;
        private System.Windows.Forms.ToolStripMenuItem izmeniStavkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izmeniJeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izmeniPrilogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poveziPrilogZaJeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrisiStavkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrisiJeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izbrisiPrilogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvestajiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racuniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odveziPrilogOdJelaToolStripMenuItem;
        private System.Windows.Forms.Panel panelRacun;
        private System.Windows.Forms.Label lblBrStola;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowStavke;
        private System.Windows.Forms.Button btnPlatiRacun;
        private System.Windows.Forms.Button btnDodajStavku;
        private System.Windows.Forms.Button btnHidePanel;
        private System.Windows.Forms.Timer timerAnimacija;
        private System.Windows.Forms.Panel panelJeloDana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCenaJeloDana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNazivJeloDana;
        private System.Windows.Forms.Label lblBrProdaja;
        private System.Windows.Forms.Label label4;
    }
}

