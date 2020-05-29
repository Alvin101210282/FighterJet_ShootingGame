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
            this.Heart1 = new System.Windows.Forms.PictureBox();
            this.enemyTwo = new System.Windows.Forms.PictureBox();
            this.enemyThree = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.Bullet = new System.Windows.Forms.PictureBox();
            this.enemyOne = new System.Windows.Forms.PictureBox();
            this.Heart2 = new System.Windows.Forms.PictureBox();
            this.Heart3 = new System.Windows.Forms.PictureBox();
            this.GameOverText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.Black;
            this.txtScore.Location = new System.Drawing.Point(1, -2);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(92, 73);
            this.txtScore.TabIndex = 8;
            this.txtScore.Text = "0";
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtScore.Click += new System.EventHandler(this.txtScore_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainGameTimerEvent);
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
            // GameOverText
            // 
            this.GameOverText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverText.ForeColor = System.Drawing.Color.Black;
            this.GameOverText.Location = new System.Drawing.Point(284, 237);
            this.GameOverText.Name = "GameOverText";
            this.GameOverText.Size = new System.Drawing.Size(311, 54);
            this.GameOverText.TabIndex = 12;
            this.GameOverText.Text = "GAME OVER";
            this.GameOverText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameOverText.Visible = false;
            this.GameOverText.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(892, 773);
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
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).EndInit();
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
    }
}

