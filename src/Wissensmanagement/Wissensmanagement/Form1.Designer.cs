namespace Wissensmanagement
{
    partial class Form1
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Projekterstellung = new System.Windows.Forms.TabPage();
            this.kernanforderung_tb = new System.Windows.Forms.TextBox();
            this.projektleiter_tb = new System.Windows.Forms.TextBox();
            this.kunde_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.project_erstellen_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.projektname_tb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Informationserstellung = new System.Windows.Forms.TabPage();
            this.informationen_tags_tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.information_dokumente_tb = new System.Windows.Forms.TextBox();
            this.information_bilder_tb = new System.Windows.Forms.TextBox();
            this.information_text_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.information_hinzufuegen_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.project_cb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Suche = new System.Windows.Forms.TabPage();
            this.kommentar_btn = new System.Windows.Forms.Button();
            this.informationstitel_cb = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.suchen_btn = new System.Windows.Forms.Button();
            this.suche_projektinformation_tb = new System.Windows.Forms.TextBox();
            this.kommentar_text_tb = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.suche_tags_tb = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.suche_project_cb = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Projekterstellung.SuspendLayout();
            this.Informationserstellung.SuspendLayout();
            this.Suche.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Projekterstellung";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 33;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Projekterstellung);
            this.tabControl1.Controls.Add(this.Informationserstellung);
            this.tabControl1.Controls.Add(this.Suche);
            this.tabControl1.Location = new System.Drawing.Point(25, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 673);
            this.tabControl1.TabIndex = 11;
            // 
            // Projekterstellung
            // 
            this.Projekterstellung.Controls.Add(this.kernanforderung_tb);
            this.Projekterstellung.Controls.Add(this.projektleiter_tb);
            this.Projekterstellung.Controls.Add(this.kunde_tb);
            this.Projekterstellung.Controls.Add(this.label5);
            this.Projekterstellung.Controls.Add(this.label7);
            this.Projekterstellung.Controls.Add(this.project_erstellen_btn);
            this.Projekterstellung.Controls.Add(this.label8);
            this.Projekterstellung.Controls.Add(this.projektname_tb);
            this.Projekterstellung.Controls.Add(this.label10);
            this.Projekterstellung.Controls.Add(this.label9);
            this.Projekterstellung.Location = new System.Drawing.Point(4, 22);
            this.Projekterstellung.Name = "Projekterstellung";
            this.Projekterstellung.Padding = new System.Windows.Forms.Padding(3);
            this.Projekterstellung.Size = new System.Drawing.Size(732, 647);
            this.Projekterstellung.TabIndex = 0;
            this.Projekterstellung.Text = "Projekterstellung";
            this.Projekterstellung.UseVisualStyleBackColor = true;
            // 
            // kernanforderung_tb
            // 
            this.kernanforderung_tb.Location = new System.Drawing.Point(155, 205);
            this.kernanforderung_tb.Name = "kernanforderung_tb";
            this.kernanforderung_tb.Size = new System.Drawing.Size(379, 20);
            this.kernanforderung_tb.TabIndex = 23;
            // 
            // projektleiter_tb
            // 
            this.projektleiter_tb.Location = new System.Drawing.Point(155, 164);
            this.projektleiter_tb.Name = "projektleiter_tb";
            this.projektleiter_tb.Size = new System.Drawing.Size(379, 20);
            this.projektleiter_tb.TabIndex = 22;
            // 
            // kunde_tb
            // 
            this.kunde_tb.Location = new System.Drawing.Point(155, 123);
            this.kunde_tb.Name = "kunde_tb";
            this.kunde_tb.Size = new System.Drawing.Size(379, 20);
            this.kunde_tb.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Kernanforderung";
            // 
            // project_erstellen_btn
            // 
            this.project_erstellen_btn.Location = new System.Drawing.Point(435, 258);
            this.project_erstellen_btn.Name = "project_erstellen_btn";
            this.project_erstellen_btn.Size = new System.Drawing.Size(99, 44);
            this.project_erstellen_btn.TabIndex = 24;
            this.project_erstellen_btn.Text = "Projekt erstellen";
            this.project_erstellen_btn.Click += new System.EventHandler(this.create_project_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Projektleiter";
            // 
            // projektname_tb
            // 
            this.projektname_tb.Location = new System.Drawing.Point(155, 84);
            this.projektname_tb.Name = "projektname_tb";
            this.projektname_tb.Size = new System.Drawing.Size(379, 20);
            this.projektname_tb.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Projektname";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Kunde";
            // 
            // Informationserstellung
            // 
            this.Informationserstellung.Controls.Add(this.informationen_tags_tb);
            this.Informationserstellung.Controls.Add(this.label12);
            this.Informationserstellung.Controls.Add(this.information_dokumente_tb);
            this.Informationserstellung.Controls.Add(this.label6);
            this.Informationserstellung.Controls.Add(this.information_bilder_tb);
            this.Informationserstellung.Controls.Add(this.information_text_tb);
            this.Informationserstellung.Controls.Add(this.label4);
            this.Informationserstellung.Controls.Add(this.information_hinzufuegen_btn);
            this.Informationserstellung.Controls.Add(this.label3);
            this.Informationserstellung.Controls.Add(this.project_cb);
            this.Informationserstellung.Controls.Add(this.label1);
            this.Informationserstellung.Controls.Add(this.label2);
            this.Informationserstellung.Location = new System.Drawing.Point(4, 22);
            this.Informationserstellung.Name = "Informationserstellung";
            this.Informationserstellung.Padding = new System.Windows.Forms.Padding(3);
            this.Informationserstellung.Size = new System.Drawing.Size(732, 647);
            this.Informationserstellung.TabIndex = 1;
            this.Informationserstellung.Text = "Informationserstellung";
            this.Informationserstellung.UseVisualStyleBackColor = true;
            // 
            // informationen_tags_tb
            // 
            this.informationen_tags_tb.Location = new System.Drawing.Point(184, 353);
            this.informationen_tags_tb.Name = "informationen_tags_tb";
            this.informationen_tags_tb.Size = new System.Drawing.Size(357, 20);
            this.informationen_tags_tb.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(128, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Tags";
            // 
            // information_dokumente_tb
            // 
            this.information_dokumente_tb.Location = new System.Drawing.Point(184, 309);
            this.information_dokumente_tb.Name = "information_dokumente_tb";
            this.information_dokumente_tb.Size = new System.Drawing.Size(357, 20);
            this.information_dokumente_tb.TabIndex = 30;
            // 
            // information_bilder_tb
            // 
            this.information_bilder_tb.Location = new System.Drawing.Point(184, 271);
            this.information_bilder_tb.Name = "information_bilder_tb";
            this.information_bilder_tb.Size = new System.Drawing.Size(357, 20);
            this.information_bilder_tb.TabIndex = 29;
            // 
            // information_text_tb
            // 
            this.information_text_tb.Location = new System.Drawing.Point(184, 112);
            this.information_text_tb.Multiline = true;
            this.information_text_tb.Name = "information_text_tb";
            this.information_text_tb.Size = new System.Drawing.Size(357, 140);
            this.information_text_tb.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Andere Dokumente (URL)";
            // 
            // information_hinzufuegen_btn
            // 
            this.information_hinzufuegen_btn.Location = new System.Drawing.Point(425, 400);
            this.information_hinzufuegen_btn.Name = "information_hinzufuegen_btn";
            this.information_hinzufuegen_btn.Size = new System.Drawing.Size(116, 42);
            this.information_hinzufuegen_btn.TabIndex = 24;
            this.information_hinzufuegen_btn.Text = "Information erstellen";
            this.information_hinzufuegen_btn.UseVisualStyleBackColor = true;
            this.information_hinzufuegen_btn.Click += new System.EventHandler(this.information_hinzufuegen_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Bilder (URL)";
            // 
            // project_cb
            // 
            this.project_cb.FormattingEnabled = true;
            this.project_cb.Location = new System.Drawing.Point(184, 73);
            this.project_cb.Name = "project_cb";
            this.project_cb.Size = new System.Drawing.Size(273, 21);
            this.project_cb.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Projekt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Text";
            // 
            // Suche
            // 
            this.Suche.Controls.Add(this.kommentar_btn);
            this.Suche.Controls.Add(this.informationstitel_cb);
            this.Suche.Controls.Add(this.label17);
            this.Suche.Controls.Add(this.suchen_btn);
            this.Suche.Controls.Add(this.suche_projektinformation_tb);
            this.Suche.Controls.Add(this.kommentar_text_tb);
            this.Suche.Controls.Add(this.label16);
            this.Suche.Controls.Add(this.label15);
            this.Suche.Controls.Add(this.suche_tags_tb);
            this.Suche.Controls.Add(this.label14);
            this.Suche.Controls.Add(this.suche_project_cb);
            this.Suche.Controls.Add(this.label13);
            this.Suche.Controls.Add(this.label11);
            this.Suche.Location = new System.Drawing.Point(4, 22);
            this.Suche.Name = "Suche";
            this.Suche.Size = new System.Drawing.Size(732, 647);
            this.Suche.TabIndex = 2;
            this.Suche.Text = "Suche/Kommentieren";
            this.Suche.UseVisualStyleBackColor = true;
            // 
            // kommentar_btn
            // 
            this.kommentar_btn.Location = new System.Drawing.Point(432, 572);
            this.kommentar_btn.Name = "kommentar_btn";
            this.kommentar_btn.Size = new System.Drawing.Size(143, 42);
            this.kommentar_btn.TabIndex = 49;
            this.kommentar_btn.Text = "Kommentar hinzufügen";
            this.kommentar_btn.UseVisualStyleBackColor = true;
            this.kommentar_btn.Click += new System.EventHandler(this.kommentar_btn_Click);
            // 
            // informationstitel_cb
            // 
            this.informationstitel_cb.FormattingEnabled = true;
            this.informationstitel_cb.Location = new System.Drawing.Point(135, 443);
            this.informationstitel_cb.Name = "informationstitel_cb";
            this.informationstitel_cb.Size = new System.Drawing.Size(273, 21);
            this.informationstitel_cb.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 446);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Informationstitel";
            // 
            // suchen_btn
            // 
            this.suchen_btn.Location = new System.Drawing.Point(459, 155);
            this.suchen_btn.Name = "suchen_btn";
            this.suchen_btn.Size = new System.Drawing.Size(116, 42);
            this.suchen_btn.TabIndex = 41;
            this.suchen_btn.Text = "Suchen";
            this.suchen_btn.UseVisualStyleBackColor = true;
            this.suchen_btn.Click += new System.EventHandler(this.suchen_btn_Click);
            // 
            // suche_projektinformation_tb
            // 
            this.suche_projektinformation_tb.Location = new System.Drawing.Point(135, 231);
            this.suche_projektinformation_tb.Multiline = true;
            this.suche_projektinformation_tb.Name = "suche_projektinformation_tb";
            this.suche_projektinformation_tb.ReadOnly = true;
            this.suche_projektinformation_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.suche_projektinformation_tb.Size = new System.Drawing.Size(440, 191);
            this.suche_projektinformation_tb.TabIndex = 40;
            // 
            // kommentar_text_tb
            // 
            this.kommentar_text_tb.Location = new System.Drawing.Point(135, 481);
            this.kommentar_text_tb.Multiline = true;
            this.kommentar_text_tb.Name = "kommentar_text_tb";
            this.kommentar_text_tb.Size = new System.Drawing.Size(440, 69);
            this.kommentar_text_tb.TabIndex = 39;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 481);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Kommentar";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 277);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Projektinformation";
            // 
            // suche_tags_tb
            // 
            this.suche_tags_tb.Location = new System.Drawing.Point(135, 122);
            this.suche_tags_tb.Name = "suche_tags_tb";
            this.suche_tags_tb.Size = new System.Drawing.Size(273, 20);
            this.suche_tags_tb.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Suche nach Tags";
            // 
            // suche_project_cb
            // 
            this.suche_project_cb.FormattingEnabled = true;
            this.suche_project_cb.Location = new System.Drawing.Point(135, 77);
            this.suche_project_cb.Name = "suche_project_cb";
            this.suche_project_cb.Size = new System.Drawing.Size(273, 21);
            this.suche_project_cb.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Projekt";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 43;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 724);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Wissensmanagement";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Projekterstellung.ResumeLayout(false);
            this.Projekterstellung.PerformLayout();
            this.Informationserstellung.ResumeLayout(false);
            this.Informationserstellung.PerformLayout();
            this.Suche.ResumeLayout(false);
            this.Suche.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Projekterstellung;
        private System.Windows.Forms.TabPage Informationserstellung;
        private System.Windows.Forms.TabPage Suche;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button project_erstellen_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox projektname_tb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox kernanforderung_tb;
        private System.Windows.Forms.TextBox projektleiter_tb;
        private System.Windows.Forms.TextBox kunde_tb;
        private System.Windows.Forms.Button information_hinzufuegen_btn;
        private System.Windows.Forms.TextBox information_dokumente_tb;
        private System.Windows.Forms.TextBox information_bilder_tb;
        private System.Windows.Forms.TextBox information_text_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox project_cb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox informationen_tags_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox kommentar_text_tb;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox suche_tags_tb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox suche_project_cb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox suche_projektinformation_tb;
        private System.Windows.Forms.Button suchen_btn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button kommentar_btn;
        private System.Windows.Forms.ComboBox informationstitel_cb;

    }
}

