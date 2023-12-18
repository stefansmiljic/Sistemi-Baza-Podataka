namespace MMORPG
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
            this.cmdPodaciOIgracu = new System.Windows.Forms.Button();
            this.cmdDodajTim = new System.Windows.Forms.Button();
            this.cmdManyToOne = new System.Windows.Forms.Button();
            this.cmdOneToMany = new System.Windows.Forms.Button();
            this.cmdKreirajIgraca = new System.Windows.Forms.Button();
            this.cmdManyToMany = new System.Windows.Forms.Button();
            this.svestenikBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.createSesija = new System.Windows.Forms.Button();
            this.btnTimVsTim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdPodaciOIgracu
            // 
            this.cmdPodaciOIgracu.Location = new System.Drawing.Point(26, 25);
            this.cmdPodaciOIgracu.Name = "cmdPodaciOIgracu";
            this.cmdPodaciOIgracu.Size = new System.Drawing.Size(177, 23);
            this.cmdPodaciOIgracu.TabIndex = 0;
            this.cmdPodaciOIgracu.Text = "Ucitavanje podataka o igracu";
            this.cmdPodaciOIgracu.UseVisualStyleBackColor = true;
            this.cmdPodaciOIgracu.Click += new System.EventHandler(this.cmdPodaciOIgracu_Click);
            // 
            // cmdDodajTim
            // 
            this.cmdDodajTim.Location = new System.Drawing.Point(26, 55);
            this.cmdDodajTim.Name = "cmdDodajTim";
            this.cmdDodajTim.Size = new System.Drawing.Size(177, 23);
            this.cmdDodajTim.TabIndex = 1;
            this.cmdDodajTim.Text = "Dodaj tim";
            this.cmdDodajTim.UseVisualStyleBackColor = true;
            this.cmdDodajTim.Click += new System.EventHandler(this.cmdDodajTim_Click);
            // 
            // cmdManyToOne
            // 
            this.cmdManyToOne.Location = new System.Drawing.Point(26, 85);
            this.cmdManyToOne.Name = "cmdManyToOne";
            this.cmdManyToOne.Size = new System.Drawing.Size(177, 23);
            this.cmdManyToOne.TabIndex = 2;
            this.cmdManyToOne.Text = "Veza many-to-one";
            this.cmdManyToOne.UseVisualStyleBackColor = true;
            this.cmdManyToOne.Click += new System.EventHandler(this.cmdManyToOne_Click);
            // 
            // cmdOneToMany
            // 
            this.cmdOneToMany.Location = new System.Drawing.Point(26, 115);
            this.cmdOneToMany.Name = "cmdOneToMany";
            this.cmdOneToMany.Size = new System.Drawing.Size(177, 23);
            this.cmdOneToMany.TabIndex = 3;
            this.cmdOneToMany.Text = "Veza one-to-many";
            this.cmdOneToMany.UseVisualStyleBackColor = true;
            this.cmdOneToMany.Click += new System.EventHandler(this.cmdOneToMany_Click);
            // 
            // cmdKreirajIgraca
            // 
            this.cmdKreirajIgraca.Location = new System.Drawing.Point(26, 145);
            this.cmdKreirajIgraca.Name = "cmdKreirajIgraca";
            this.cmdKreirajIgraca.Size = new System.Drawing.Size(177, 23);
            this.cmdKreirajIgraca.TabIndex = 4;
            this.cmdKreirajIgraca.Text = "Kreiraj igraca";
            this.cmdKreirajIgraca.UseVisualStyleBackColor = true;
            this.cmdKreirajIgraca.Click += new System.EventHandler(this.cmdKreirajIgraca_Click);
            // 
            // cmdManyToMany
            // 
            this.cmdManyToMany.Location = new System.Drawing.Point(26, 175);
            this.cmdManyToMany.Name = "cmdManyToMany";
            this.cmdManyToMany.Size = new System.Drawing.Size(177, 23);
            this.cmdManyToMany.TabIndex = 5;
            this.cmdManyToMany.Text = "Veza many-to-many";
            this.cmdManyToMany.UseVisualStyleBackColor = true;
            this.cmdManyToMany.Click += new System.EventHandler(this.cmdManyToMany_Click);
            // 
            // svestenikBtn
            // 
            this.svestenikBtn.Location = new System.Drawing.Point(26, 204);
            this.svestenikBtn.Name = "svestenikBtn";
            this.svestenikBtn.Size = new System.Drawing.Size(177, 23);
            this.svestenikBtn.TabIndex = 6;
            this.svestenikBtn.Text = "Napravi oruzje";
            this.svestenikBtn.UseVisualStyleBackColor = true;
            this.svestenikBtn.Click += new System.EventHandler(this.svestenikBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Napravi stazu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // createSesija
            // 
            this.createSesija.Location = new System.Drawing.Point(26, 307);
            this.createSesija.Name = "createSesija";
            this.createSesija.Size = new System.Drawing.Size(177, 23);
            this.createSesija.TabIndex = 8;
            this.createSesija.Text = "Napravi sesiju";
            this.createSesija.UseVisualStyleBackColor = true;
            this.createSesija.Click += new System.EventHandler(this.createSesija_Click);
            // 
            // btnTimVsTim
            // 
            this.btnTimVsTim.Location = new System.Drawing.Point(26, 346);
            this.btnTimVsTim.Name = "btnTimVsTim";
            this.btnTimVsTim.Size = new System.Drawing.Size(177, 23);
            this.btnTimVsTim.TabIndex = 9;
            this.btnTimVsTim.Text = "Tim vs Tim";
            this.btnTimVsTim.UseVisualStyleBackColor = true;
            this.btnTimVsTim.Click += new System.EventHandler(this.btnTimVsTim_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTimVsTim);
            this.Controls.Add(this.createSesija);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.svestenikBtn);
            this.Controls.Add(this.cmdManyToMany);
            this.Controls.Add(this.cmdKreirajIgraca);
            this.Controls.Add(this.cmdOneToMany);
            this.Controls.Add(this.cmdManyToOne);
            this.Controls.Add(this.cmdDodajTim);
            this.Controls.Add(this.cmdPodaciOIgracu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPodaciOIgracu;
        private System.Windows.Forms.Button cmdDodajTim;
        private System.Windows.Forms.Button cmdManyToOne;
        private System.Windows.Forms.Button cmdOneToMany;
        private System.Windows.Forms.Button cmdKreirajIgraca;
        private System.Windows.Forms.Button cmdManyToMany;
        private System.Windows.Forms.Button svestenikBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createSesija;
        private System.Windows.Forms.Button btnTimVsTim;
    }
}

