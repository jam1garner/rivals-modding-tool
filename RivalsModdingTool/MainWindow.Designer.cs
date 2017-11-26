namespace RivalsModdingTool
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ripSprites = new System.Windows.Forms.Button();
            this.replaceSprites = new System.Windows.Forms.Button();
            this.ripAudio = new System.Windows.Forms.Button();
            this.replaceAudio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.browse_mods = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ripSprites
            // 
            this.ripSprites.BackColor = System.Drawing.Color.Transparent;
            this.ripSprites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ripSprites.FlatAppearance.BorderSize = 0;
            this.ripSprites.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ripSprites.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ripSprites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ripSprites.ForeColor = System.Drawing.Color.Transparent;
            this.ripSprites.Image = global::RivalsModdingTool.Properties.Resources.rip;
            this.ripSprites.Location = new System.Drawing.Point(12, 12);
            this.ripSprites.Name = "ripSprites";
            this.ripSprites.Size = new System.Drawing.Size(444, 54);
            this.ripSprites.TabIndex = 0;
            this.ripSprites.UseVisualStyleBackColor = false;
            this.ripSprites.Click += new System.EventHandler(this.ripSprites_Click);
            this.ripSprites.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ripSprites_MouseDown);
            this.ripSprites.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ripSprites_MouseUp);
            // 
            // replaceSprites
            // 
            this.replaceSprites.BackColor = System.Drawing.Color.Transparent;
            this.replaceSprites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.replaceSprites.FlatAppearance.BorderSize = 0;
            this.replaceSprites.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.replaceSprites.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.replaceSprites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replaceSprites.ForeColor = System.Drawing.Color.Transparent;
            this.replaceSprites.Image = global::RivalsModdingTool.Properties.Resources.replace;
            this.replaceSprites.Location = new System.Drawing.Point(12, 72);
            this.replaceSprites.Name = "replaceSprites";
            this.replaceSprites.Size = new System.Drawing.Size(444, 54);
            this.replaceSprites.TabIndex = 1;
            this.replaceSprites.UseVisualStyleBackColor = false;
            this.replaceSprites.Click += new System.EventHandler(this.replaceSprites_Click);
            this.replaceSprites.MouseDown += new System.Windows.Forms.MouseEventHandler(this.replaceSprites_MouseDown);
            this.replaceSprites.MouseUp += new System.Windows.Forms.MouseEventHandler(this.replaceSprites_MouseUp);
            // 
            // ripAudio
            // 
            this.ripAudio.BackColor = System.Drawing.Color.Transparent;
            this.ripAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ripAudio.FlatAppearance.BorderSize = 0;
            this.ripAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ripAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ripAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ripAudio.ForeColor = System.Drawing.Color.Transparent;
            this.ripAudio.Image = global::RivalsModdingTool.Properties.Resources.rip_audio;
            this.ripAudio.Location = new System.Drawing.Point(12, 132);
            this.ripAudio.Name = "ripAudio";
            this.ripAudio.Size = new System.Drawing.Size(444, 54);
            this.ripAudio.TabIndex = 2;
            this.ripAudio.UseVisualStyleBackColor = false;
            this.ripAudio.Click += new System.EventHandler(this.ripAudio_Click);
            this.ripAudio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ripAudio_MouseDown);
            this.ripAudio.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ripAudio_MouseUp);
            // 
            // replaceAudio
            // 
            this.replaceAudio.BackColor = System.Drawing.Color.Transparent;
            this.replaceAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.replaceAudio.FlatAppearance.BorderSize = 0;
            this.replaceAudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.replaceAudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.replaceAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replaceAudio.ForeColor = System.Drawing.Color.Transparent;
            this.replaceAudio.Image = global::RivalsModdingTool.Properties.Resources.replace_audio;
            this.replaceAudio.Location = new System.Drawing.Point(12, 192);
            this.replaceAudio.Name = "replaceAudio";
            this.replaceAudio.Size = new System.Drawing.Size(444, 54);
            this.replaceAudio.TabIndex = 3;
            this.replaceAudio.UseVisualStyleBackColor = false;
            this.replaceAudio.Click += new System.EventHandler(this.replaceAudio_Click);
            this.replaceAudio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.replaceAudio_MouseDown);
            this.replaceAudio.MouseUp += new System.Windows.Forms.MouseEventHandler(this.replaceAudio_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(462, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 60);
            this.label1.TabIndex = 4;
            this.label1.Text = "Credits:\r\njam1garner (Tool)\r\nDan Fornace (Graphics)\r\nTheRealHeroOfWinds (Buttons)" +
    "";
            // 
            // browse_mods
            // 
            this.browse_mods.BackColor = System.Drawing.Color.Transparent;
            this.browse_mods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.browse_mods.FlatAppearance.BorderSize = 0;
            this.browse_mods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.browse_mods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.browse_mods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_mods.ForeColor = System.Drawing.Color.Transparent;
            this.browse_mods.Image = global::RivalsModdingTool.Properties.Resources.browse;
            this.browse_mods.Location = new System.Drawing.Point(12, 252);
            this.browse_mods.Name = "browse_mods";
            this.browse_mods.Size = new System.Drawing.Size(444, 54);
            this.browse_mods.TabIndex = 5;
            this.browse_mods.UseVisualStyleBackColor = false;
            this.browse_mods.Click += new System.EventHandler(this.browseMods_Click);
            this.browse_mods.MouseDown += new System.Windows.Forms.MouseEventHandler(this.browseMods_MouseDown);
            this.browse_mods.MouseUp += new System.Windows.Forms.MouseEventHandler(this.browseMods_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::RivalsModdingTool.Properties.Resources.bg_piece;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(644, 365);
            this.Controls.Add(this.browse_mods);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceAudio);
            this.Controls.Add(this.ripAudio);
            this.Controls.Add(this.replaceSprites);
            this.Controls.Add(this.ripSprites);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(660, 404);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(660, 404);
            this.Name = "MainWindow";
            this.Text = "Rivals Modding Tool 2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ripSprites;
        private System.Windows.Forms.Button replaceSprites;
        private System.Windows.Forms.Button ripAudio;
        private System.Windows.Forms.Button replaceAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browse_mods;
    }
}

