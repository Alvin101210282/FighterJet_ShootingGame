﻿namespace fighterjetshooting
{
    partial class Form2
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.howToPlay_button = new System.Windows.Forms.Button();
            this.scoredisplay = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Exit_button = new System.Windows.Forms.Button();
            this.Play_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Main_menu);
            // 
            // howToPlay_button
            // 
            this.howToPlay_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.howToPlay_button.BackColor = System.Drawing.Color.Black;
            this.howToPlay_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.howToPlay_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.howToPlay_button.FlatAppearance.BorderSize = 0;
            this.howToPlay_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.howToPlay_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.howToPlay_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.howToPlay_button.Font = new System.Drawing.Font("Impact", 6.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.howToPlay_button.Image = global::fighterjetshooting.Properties.Resources.HOWTOPLAY1;
            this.howToPlay_button.Location = new System.Drawing.Point(319, 318);
            this.howToPlay_button.Name = "howToPlay_button";
            this.howToPlay_button.Size = new System.Drawing.Size(251, 82);
            this.howToPlay_button.TabIndex = 2;
            this.howToPlay_button.UseVisualStyleBackColor = false;
            this.howToPlay_button.Click += new System.EventHandler(this.howtoplayButton);
            // 
            // scoredisplay
            // 
            this.scoredisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scoredisplay.BackColor = System.Drawing.Color.Black;
            this.scoredisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.scoredisplay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.scoredisplay.FlatAppearance.BorderSize = 0;
            this.scoredisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.scoredisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.scoredisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoredisplay.Font = new System.Drawing.Font("Impact", 6.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.scoredisplay.Image = global::fighterjetshooting.Properties.Resources.HIGHSCOREMENU;
            this.scoredisplay.Location = new System.Drawing.Point(319, 421);
            this.scoredisplay.Name = "scoredisplay";
            this.scoredisplay.Size = new System.Drawing.Size(251, 82);
            this.scoredisplay.TabIndex = 3;
            this.scoredisplay.UseVisualStyleBackColor = false;
            this.scoredisplay.Click += new System.EventHandler(this.ScoreBoard);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = global::fighterjetshooting.Properties.Resources.title;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(892, 138);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // Exit_button
            // 
            this.Exit_button.AutoSize = true;
            this.Exit_button.BackColor = System.Drawing.Color.Black;
            this.Exit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Exit_button.FlatAppearance.BorderSize = 0;
            this.Exit_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.Exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_button.Font = new System.Drawing.Font("Impact", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_button.Image = global::fighterjetshooting.Properties.Resources.EXITMENU;
            this.Exit_button.Location = new System.Drawing.Point(319, 523);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(251, 82);
            this.Exit_button.TabIndex = 4;
            this.Exit_button.UseVisualStyleBackColor = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit);
            // 
            // Play_button
            // 
            this.Play_button.AutoSize = true;
            this.Play_button.BackColor = System.Drawing.Color.Black;
            this.Play_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Play_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Play_button.FlatAppearance.BorderSize = 0;
            this.Play_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Play_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.Play_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play_button.Font = new System.Drawing.Font("Impact", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play_button.Image = global::fighterjetshooting.Properties.Resources.PLAYMENU;
            this.Play_button.Location = new System.Drawing.Point(319, 216);
            this.Play_button.Name = "Play_button";
            this.Play_button.Size = new System.Drawing.Size(251, 82);
            this.Play_button.TabIndex = 1;
            this.Play_button.UseVisualStyleBackColor = false;
            this.Play_button.Click += new System.EventHandler(this.Play);
            this.Play_button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayButton);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::fighterjetshooting.Properties.Resources.ace_combat_7_skies_unknown_hands_on_tokyo_game_show_2018;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(910, 820);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 773);
            this.Controls.Add(this.howToPlay_button);
            this.Controls.Add(this.scoredisplay);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Play_button);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlayButton);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Play_button;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button scoredisplay;
        public System.Windows.Forms.Button howToPlay_button;
    }
}