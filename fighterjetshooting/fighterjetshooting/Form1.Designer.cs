namespace fighterjetshooting
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
            this.components = new System.ComponentModel.Container();
            this.txtScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.GameOverText = new System.Windows.Forms.Label();
            this.newTimer = new System.Windows.Forms.Timer(this.components);
            this.return_menu = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ReplayButton = new System.Windows.Forms.Button();
            this.Heart3 = new System.Windows.Forms.PictureBox();
            this.Heart2 = new System.Windows.Forms.PictureBox();
            this.Heart1 = new System.Windows.Forms.PictureBox();
            this.enemyTwo = new System.Windows.Forms.PictureBox();
            this.enemyThree = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.Bullet = new System.Windows.Forms.PictureBox();
            this.enemyOne = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyOne)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.Black;
            this.txtScore.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.txtScore.Location = new System.Drawing.Point(1, -2);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(126, 73);
            this.txtScore.TabIndex = 8;
            this.txtScore.Text = "0";
            this.txtScore.Click += new System.EventHandler(this.txtScore_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // GameOverText
            // 
            this.GameOverText.BackColor = System.Drawing.Color.Black;
            this.GameOverText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameOverText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GameOverText.Font = new System.Drawing.Font("Impact", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverText.ForeColor = System.Drawing.Color.Red;
            this.GameOverText.Location = new System.Drawing.Point(216, 177);
            this.GameOverText.Name = "GameOverText";
            this.GameOverText.Size = new System.Drawing.Size(440, 133);
            this.GameOverText.TabIndex = 12;
            this.GameOverText.Text = "GAME OVER";
            this.GameOverText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameOverText.Visible = false;
            // 
            // newTimer
            // 
            this.newTimer.Interval = 20;
            this.newTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
            // 
            // return_menu
            // 
            this.return_menu.BackColor = System.Drawing.Color.Black;
            this.return_menu.BackgroundImage = global::fighterjetshooting.Properties.Resources.MAINMENU;
            this.return_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.return_menu.FlatAppearance.BorderSize = 0;
            this.return_menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.return_menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.return_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.return_menu.Location = new System.Drawing.Point(303, 491);
            this.return_menu.Name = "return_menu";
            this.return_menu.Size = new System.Drawing.Size(263, 70);
            this.return_menu.TabIndex = 15;
            this.return_menu.UseVisualStyleBackColor = false;
            this.return_menu.Visible = false;
            this.return_menu.Click += new System.EventHandler(this.return_menu_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Black;
            this.ExitButton.BackgroundImage = global::fighterjetshooting.Properties.Resources.EXITMENU;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(303, 583);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(263, 70);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Visible = false;
            this.ExitButton.Click += new System.EventHandler(this.Exit_button);
            // 
            // ReplayButton
            // 
            this.ReplayButton.BackColor = System.Drawing.Color.Black;
            this.ReplayButton.BackgroundImage = global::fighterjetshooting.Properties.Resources.REPLAYEND;
            this.ReplayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReplayButton.FlatAppearance.BorderSize = 0;
            this.ReplayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.ReplayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.ReplayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplayButton.Location = new System.Drawing.Point(303, 402);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(263, 70);
            this.ReplayButton.TabIndex = 13;
            this.ReplayButton.UseVisualStyleBackColor = false;
            this.ReplayButton.Visible = false;
            this.ReplayButton.Click += new System.EventHandler(this.Replay_button);
            // 
            // Heart3
            // 
            this.Heart3.Image = global::fighterjetshooting.Properties.Resources.heart_v3;
            this.Heart3.Location = new System.Drawing.Point(819, 12);
            this.Heart3.Name = "Heart3";
            this.Heart3.Size = new System.Drawing.Size(31, 28);
            this.Heart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Heart3.TabIndex = 11;
            this.Heart3.TabStop = false;
            // 
            // Heart2
            // 
            this.Heart2.Image = global::fighterjetshooting.Properties.Resources.heart_v3;
            this.Heart2.Location = new System.Drawing.Point(782, 12);
            this.Heart2.Name = "Heart2";
            this.Heart2.Size = new System.Drawing.Size(31, 28);
            this.Heart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Heart2.TabIndex = 10;
            this.Heart2.TabStop = false;
            // 
            // Heart1
            // 
            this.Heart1.Image = global::fighterjetshooting.Properties.Resources.heart_v3;
            this.Heart1.Location = new System.Drawing.Point(745, 12);
            this.Heart1.Name = "Heart1";
            this.Heart1.Size = new System.Drawing.Size(31, 28);
            this.Heart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Heart1.TabIndex = 9;
            this.Heart1.TabStop = false;
            // 
            // enemyTwo
            // 
            this.enemyTwo.Image = global::fighterjetshooting.Properties.Resources.enemy;
            this.enemyTwo.Location = new System.Drawing.Point(376, 31);
            this.enemyTwo.Name = "enemyTwo";
            this.enemyTwo.Size = new System.Drawing.Size(100, 85);
            this.enemyTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.enemyTwo.TabIndex = 7;
            this.enemyTwo.TabStop = false;
            // 
            // enemyThree
            // 
            this.enemyThree.Image = global::fighterjetshooting.Properties.Resources.enemy;
            this.enemyThree.Location = new System.Drawing.Point(598, 31);
            this.enemyThree.Name = "enemyThree";
            this.enemyThree.Size = new System.Drawing.Size(100, 85);
            this.enemyThree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.enemyThree.TabIndex = 6;
            this.enemyThree.TabStop = false;
            // 
            // player
            // 
            this.player.Image = global::fighterjetshooting.Properties.Resources.player;
            this.player.Location = new System.Drawing.Point(321, 672);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(110, 98);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // Bullet
            // 
            this.Bullet.Image = global::fighterjetshooting.Properties.Resources.bullet;
            this.Bullet.Location = new System.Drawing.Point(424, 351);
            this.Bullet.Name = "Bullet";
            this.Bullet.Size = new System.Drawing.Size(7, 27);
            this.Bullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Bullet.TabIndex = 1;
            this.Bullet.TabStop = false;
            // 
            // enemyOne
            // 
            this.enemyOne.Image = global::fighterjetshooting.Properties.Resources.enemy;
            this.enemyOne.Location = new System.Drawing.Point(169, 31);
            this.enemyOne.Name = "enemyOne";
            this.enemyOne.Size = new System.Drawing.Size(100, 85);
            this.enemyOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.enemyOne.TabIndex = 0;
            this.enemyOne.TabStop = false;
            this.enemyOne.Click += new System.EventHandler(this.enemyOne_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(892, 773);
            this.Controls.Add(this.return_menu);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ReplayButton);
            this.Controls.Add(this.GameOverText);
            this.Controls.Add(this.Heart3);
            this.Controls.Add(this.Heart2);
            this.Controls.Add(this.Heart1);
            this.Controls.Add(this.enemyTwo);
            this.Controls.Add(this.enemyThree);
            this.Controls.Add(this.player);
            this.Controls.Add(this.Bullet);
            this.Controls.Add(this.enemyOne);
            this.Controls.Add(this.txtScore);
            this.Name = "Form1";
            this.Text = "Fighter Jet Shooting Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyOne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox enemyOne;
        private System.Windows.Forms.PictureBox Bullet;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox enemyThree;
        private System.Windows.Forms.PictureBox enemyTwo;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox Heart1;
        private System.Windows.Forms.PictureBox Heart2;
        private System.Windows.Forms.PictureBox Heart3;
        private System.Windows.Forms.Label GameOverText;
        private System.Windows.Forms.Button ReplayButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Timer newTimer;
        private System.Windows.Forms.Button return_menu;
    }
}

