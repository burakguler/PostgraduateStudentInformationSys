namespace WindowsFormsApp1
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.dERSLERİMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bİLGİLERİMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.öĞRENCİLERİMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBilgiler = new System.Windows.Forms.Panel();
            this.lblMail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBolumNo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblOgretmenAdSoyad = new System.Windows.Forms.Label();
            this.pnlDersIslem = new System.Windows.Forms.Panel();
            this.pnlOgrenciler = new System.Windows.Forms.Panel();
            this.btn_Ara = new System.Windows.Forms.Button();
            this.lbl_OgrNoAra = new System.Windows.Forms.Label();
            this.txt_OgrenciNoAra = new System.Windows.Forms.TextBox();
            this.lblVerDers = new System.Windows.Forms.Label();
            this.cmb_verilenDersler = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlDerslerim = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.pnlBilgiler.SuspendLayout();
            this.pnlOgrenciler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlDerslerim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dERSLERİMToolStripMenuItem
            // 
            this.dERSLERİMToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.dERSLERİMToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dERSLERİMToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dERSLERİMToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dERSLERİMToolStripMenuItem.Image")));
            this.dERSLERİMToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dERSLERİMToolStripMenuItem.Name = "dERSLERİMToolStripMenuItem";
            this.dERSLERİMToolStripMenuItem.Size = new System.Drawing.Size(100, 88);
            this.dERSLERİMToolStripMenuItem.Text = "DERSLERİM";
            this.dERSLERİMToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.dERSLERİMToolStripMenuItem.Click += new System.EventHandler(this.dERSLERİMToolStripMenuItem_Click);
            // 
            // bİLGİLERİMToolStripMenuItem
            // 
            this.bİLGİLERİMToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.bİLGİLERİMToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.bİLGİLERİMToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bİLGİLERİMToolStripMenuItem.Image")));
            this.bİLGİLERİMToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bİLGİLERİMToolStripMenuItem.Name = "bİLGİLERİMToolStripMenuItem";
            this.bİLGİLERİMToolStripMenuItem.Size = new System.Drawing.Size(104, 88);
            this.bİLGİLERİMToolStripMenuItem.Text = "BİLGİLERİM";
            this.bİLGİLERİMToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bİLGİLERİMToolStripMenuItem.Click += new System.EventHandler(this.bİLGİLERİMToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStripMenuItem1.Image = global::WindowsFormsApp1.Properties.Resources.logout;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(90, 88);
            this.toolStripMenuItem1.Text = "ÇIKIŞ YAP";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dERSLERİMToolStripMenuItem,
            this.bİLGİLERİMToolStripMenuItem,
            this.toolStripMenuItem1,
            this.öĞRENCİLERİMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 92);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // öĞRENCİLERİMToolStripMenuItem
            // 
            this.öĞRENCİLERİMToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.öĞRENCİLERİMToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.education;
            this.öĞRENCİLERİMToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.öĞRENCİLERİMToolStripMenuItem.Name = "öĞRENCİLERİMToolStripMenuItem";
            this.öĞRENCİLERİMToolStripMenuItem.Size = new System.Drawing.Size(124, 88);
            this.öĞRENCİLERİMToolStripMenuItem.Text = "ÖĞRENCİLERİM";
            this.öĞRENCİLERİMToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.öĞRENCİLERİMToolStripMenuItem.Click += new System.EventHandler(this.öĞRENCİLERİMToolStripMenuItem_Click);
            // 
            // pnlBilgiler
            // 
            this.pnlBilgiler.BackColor = System.Drawing.Color.Transparent;
            this.pnlBilgiler.Controls.Add(this.lblMail);
            this.pnlBilgiler.Controls.Add(this.label4);
            this.pnlBilgiler.Controls.Add(this.lblBolumNo);
            this.pnlBilgiler.Controls.Add(this.label14);
            this.pnlBilgiler.Controls.Add(this.lblOgretmenAdSoyad);
            this.pnlBilgiler.Location = new System.Drawing.Point(0, 95);
            this.pnlBilgiler.Name = "pnlBilgiler";
            this.pnlBilgiler.Size = new System.Drawing.Size(800, 343);
            this.pnlBilgiler.TabIndex = 8;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(0)))));
            this.lblMail.Location = new System.Drawing.Point(177, 88);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(109, 21);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "34360902322";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(3, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Öğretmen Mail :";
            // 
            // lblBolumNo
            // 
            this.lblBolumNo.AutoSize = true;
            this.lblBolumNo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBolumNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(0)))));
            this.lblBolumNo.Location = new System.Drawing.Point(177, 49);
            this.lblBolumNo.Name = "lblBolumNo";
            this.lblBolumNo.Size = new System.Drawing.Size(90, 21);
            this.lblBolumNo.TabIndex = 4;
            this.lblBolumNo.Text = "29.08.1998";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(5, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(169, 21);
            this.label14.TabIndex = 3;
            this.label14.Text = "Bölüm Ad :";
            // 
            // lblOgretmenAdSoyad
            // 
            this.lblOgretmenAdSoyad.AutoSize = true;
            this.lblOgretmenAdSoyad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOgretmenAdSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(0)))));
            this.lblOgretmenAdSoyad.Location = new System.Drawing.Point(3, 11);
            this.lblOgretmenAdSoyad.Name = "lblOgretmenAdSoyad";
            this.lblOgretmenAdSoyad.Size = new System.Drawing.Size(171, 21);
            this.lblOgretmenAdSoyad.TabIndex = 0;
            this.lblOgretmenAdSoyad.Text = "Merhaba Erkan Kabil";
            // 
            // pnlDersIslem
            // 
            this.pnlDersIslem.BackColor = System.Drawing.Color.Transparent;
            this.pnlDersIslem.Location = new System.Drawing.Point(0, 95);
            this.pnlDersIslem.Name = "pnlDersIslem";
            this.pnlDersIslem.Size = new System.Drawing.Size(733, 326);
            this.pnlDersIslem.TabIndex = 7;
            // 
            // pnlOgrenciler
            // 
            this.pnlOgrenciler.Controls.Add(this.btn_Ara);
            this.pnlOgrenciler.Controls.Add(this.lbl_OgrNoAra);
            this.pnlOgrenciler.Controls.Add(this.txt_OgrenciNoAra);
            this.pnlOgrenciler.Controls.Add(this.lblVerDers);
            this.pnlOgrenciler.Controls.Add(this.cmb_verilenDersler);
            this.pnlOgrenciler.Controls.Add(this.dataGridView1);
            this.pnlOgrenciler.Location = new System.Drawing.Point(0, 95);
            this.pnlOgrenciler.Name = "pnlOgrenciler";
            this.pnlOgrenciler.Size = new System.Drawing.Size(800, 363);
            this.pnlOgrenciler.TabIndex = 9;
            // 
            // btn_Ara
            // 
            this.btn_Ara.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btn_Ara.Location = new System.Drawing.Point(599, 5);
            this.btn_Ara.Name = "btn_Ara";
            this.btn_Ara.Size = new System.Drawing.Size(75, 27);
            this.btn_Ara.TabIndex = 15;
            this.btn_Ara.Text = "ARA";
            this.btn_Ara.UseVisualStyleBackColor = true;
            this.btn_Ara.Click += new System.EventHandler(this.btn_Ara_Click);
            // 
            // lbl_OgrNoAra
            // 
            this.lbl_OgrNoAra.AutoSize = true;
            this.lbl_OgrNoAra.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lbl_OgrNoAra.Location = new System.Drawing.Point(303, 9);
            this.lbl_OgrNoAra.Name = "lbl_OgrNoAra";
            this.lbl_OgrNoAra.Size = new System.Drawing.Size(150, 20);
            this.lbl_OgrNoAra.TabIndex = 14;
            this.lbl_OgrNoAra.Text = "ÖĞRENCİ NUMARASI";
            // 
            // txt_OgrenciNoAra
            // 
            this.txt_OgrenciNoAra.Location = new System.Drawing.Point(459, 9);
            this.txt_OgrenciNoAra.Name = "txt_OgrenciNoAra";
            this.txt_OgrenciNoAra.Size = new System.Drawing.Size(134, 20);
            this.txt_OgrenciNoAra.TabIndex = 13;
            // 
            // lblVerDers
            // 
            this.lblVerDers.AutoSize = true;
            this.lblVerDers.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblVerDers.Location = new System.Drawing.Point(5, 8);
            this.lblVerDers.Name = "lblVerDers";
            this.lblVerDers.Size = new System.Drawing.Size(141, 20);
            this.lblVerDers.TabIndex = 12;
            this.lblVerDers.Text = "VERDİĞİM DERSLER";
            // 
            // cmb_verilenDersler
            // 
            this.cmb_verilenDersler.FormattingEnabled = true;
            this.cmb_verilenDersler.Location = new System.Drawing.Point(152, 8);
            this.cmb_verilenDersler.Name = "cmb_verilenDersler";
            this.cmb_verilenDersler.Size = new System.Drawing.Size(136, 21);
            this.cmb_verilenDersler.TabIndex = 11;
            this.cmb_verilenDersler.SelectedValueChanged += new System.EventHandler(this.cmb_verilenDersler_SelectedValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.OrangeRed;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 322);
            this.dataGridView1.TabIndex = 0;
            // 
            // pnlDerslerim
            // 
            this.pnlDerslerim.Controls.Add(this.dataGridView2);
            this.pnlDerslerim.Location = new System.Drawing.Point(0, 95);
            this.pnlDerslerim.Name = "pnlDerslerim";
            this.pnlDerslerim.Size = new System.Drawing.Size(800, 360);
            this.pnlDerslerim.TabIndex = 10;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.Color.OrangeRed;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(800, 357);
            this.dataGridView2.TabIndex = 0;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.asdf;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlOgrenciler);
            this.Controls.Add(this.pnlDerslerim);
            this.Controls.Add(this.pnlBilgiler);
            this.Controls.Add(this.pnlDersIslem);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğretmen Paneli";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlBilgiler.ResumeLayout(false);
            this.pnlBilgiler.PerformLayout();
            this.pnlOgrenciler.ResumeLayout(false);
            this.pnlOgrenciler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlDerslerim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem dERSLERİMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bİLGİLERİMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnlBilgiler;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBolumNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblOgretmenAdSoyad;
        private System.Windows.Forms.Panel pnlDersIslem;
        private System.Windows.Forms.ToolStripMenuItem öĞRENCİLERİMToolStripMenuItem;
        private System.Windows.Forms.Panel pnlOgrenciler;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlDerslerim;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cmb_verilenDersler;
        private System.Windows.Forms.Label lblVerDers;
        private System.Windows.Forms.Button btn_Ara;
        private System.Windows.Forms.Label lbl_OgrNoAra;
        private System.Windows.Forms.TextBox txt_OgrenciNoAra;
    }
}