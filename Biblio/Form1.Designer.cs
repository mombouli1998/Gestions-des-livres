namespace Biblio
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.home = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.livres = new System.Windows.Forms.Button();
            this.membres = new System.Windows.Forms.Button();
            this.emprunts = new System.Windows.Forms.Button();
            this.affichage = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.69771F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.30229F));
            this.tableLayoutPanel1.Controls.Add(this.home, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1632, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // home
            // 
            this.home.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home.ForeColor = System.Drawing.Color.White;
            this.home.Location = new System.Drawing.Point(3, 3);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(217, 52);
            this.home.TabIndex = 0;
            this.home.Text = "HOME";
            this.home.UseVisualStyleBackColor = false;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.livres, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.membres, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.emprunts, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 595);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // livres
            // 
            this.livres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livres.FlatAppearance.BorderSize = 0;
            this.livres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.livres.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livres.ForeColor = System.Drawing.Color.White;
            this.livres.Location = new System.Drawing.Point(3, 3);
            this.livres.Name = "livres";
            this.livres.Size = new System.Drawing.Size(194, 93);
            this.livres.TabIndex = 0;
            this.livres.Text = "Livres";
            this.livres.UseVisualStyleBackColor = true;
            this.livres.Click += new System.EventHandler(this.livres_Click);
            // 
            // membres
            // 
            this.membres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.membres.FlatAppearance.BorderSize = 0;
            this.membres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.membres.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membres.ForeColor = System.Drawing.Color.White;
            this.membres.Location = new System.Drawing.Point(3, 102);
            this.membres.Name = "membres";
            this.membres.Size = new System.Drawing.Size(194, 93);
            this.membres.TabIndex = 1;
            this.membres.Text = "Membres";
            this.membres.UseVisualStyleBackColor = true;
            this.membres.Click += new System.EventHandler(this.membres_Click);
            // 
            // emprunts
            // 
            this.emprunts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emprunts.FlatAppearance.BorderSize = 0;
            this.emprunts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emprunts.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emprunts.ForeColor = System.Drawing.Color.White;
            this.emprunts.Location = new System.Drawing.Point(3, 201);
            this.emprunts.Name = "emprunts";
            this.emprunts.Size = new System.Drawing.Size(194, 93);
            this.emprunts.TabIndex = 3;
            this.emprunts.Text = "Emprunts";
            this.emprunts.UseVisualStyleBackColor = true;
            this.emprunts.Click += new System.EventHandler(this.emprunts_Click);
            // 
            // affichage
            // 
            this.affichage.BackColor = System.Drawing.Color.White;
            this.affichage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.affichage.Location = new System.Drawing.Point(200, 58);
            this.affichage.Name = "affichage";
            this.affichage.Size = new System.Drawing.Size(1432, 595);
            this.affichage.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 653);
            this.Controls.Add(this.affichage);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bibliothèque";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button livres;
        private System.Windows.Forms.Button membres;
        private System.Windows.Forms.Button emprunts;
        private System.Windows.Forms.Panel affichage;
        private System.Windows.Forms.Button home;
    }
}

