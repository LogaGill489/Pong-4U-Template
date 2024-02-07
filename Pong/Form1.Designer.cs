namespace Pong
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
            this.gameUpdateLoop = new System.Windows.Forms.Timer(this.components);
            this.startLabel = new System.Windows.Forms.Label();
            this.player1ScoreLabel = new System.Windows.Forms.Label();
            this.player2ScoreLabel = new System.Windows.Forms.Label();
            this.p1Ready = new System.Windows.Forms.Label();
            this.p2Ready = new System.Windows.Forms.Label();
            this.ballUpSpeed = new System.Windows.Forms.Timer(this.components);
            this.p1Speed = new System.Windows.Forms.Timer(this.components);
            this.p2Speed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gameUpdateLoop
            // 
            this.gameUpdateLoop.Interval = 16;
            this.gameUpdateLoop.Tick += new System.EventHandler(this.gameUpdateLoop_Tick);
            // 
            // startLabel
            // 
            this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.White;
            this.startLabel.Location = new System.Drawing.Point(141, 130);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(329, 160);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Press Space To Start or Esc to Exit";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player1ScoreLabel
            // 
            this.player1ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player1ScoreLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.player1ScoreLabel.Location = new System.Drawing.Point(222, 9);
            this.player1ScoreLabel.Name = "player1ScoreLabel";
            this.player1ScoreLabel.Size = new System.Drawing.Size(64, 68);
            this.player1ScoreLabel.TabIndex = 1;
            this.player1ScoreLabel.Text = "0";
            this.player1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2ScoreLabel
            // 
            this.player2ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player2ScoreLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.player2ScoreLabel.Location = new System.Drawing.Point(322, 9);
            this.player2ScoreLabel.Name = "player2ScoreLabel";
            this.player2ScoreLabel.Size = new System.Drawing.Size(64, 68);
            this.player2ScoreLabel.TabIndex = 2;
            this.player2ScoreLabel.Text = "0";
            this.player2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1Ready
            // 
            this.p1Ready.BackColor = System.Drawing.Color.Transparent;
            this.p1Ready.Font = new System.Drawing.Font("Courier New", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Ready.ForeColor = System.Drawing.Color.Firebrick;
            this.p1Ready.Location = new System.Drawing.Point(30, 41);
            this.p1Ready.Name = "p1Ready";
            this.p1Ready.Size = new System.Drawing.Size(131, 49);
            this.p1Ready.TabIndex = 3;
            this.p1Ready.Text = "Ready?";
            this.p1Ready.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.p1Ready.Visible = false;
            // 
            // p2Ready
            // 
            this.p2Ready.BackColor = System.Drawing.Color.Transparent;
            this.p2Ready.Font = new System.Drawing.Font("Courier New", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Ready.ForeColor = System.Drawing.Color.Firebrick;
            this.p2Ready.Location = new System.Drawing.Point(452, 41);
            this.p2Ready.Name = "p2Ready";
            this.p2Ready.Size = new System.Drawing.Size(131, 49);
            this.p2Ready.TabIndex = 4;
            this.p2Ready.Text = "Ready?";
            this.p2Ready.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.p2Ready.Visible = false;
            // 
            // ballUpSpeed
            // 
            this.ballUpSpeed.Interval = 2000;
            this.ballUpSpeed.Tick += new System.EventHandler(this.ballUpSpeed_Tick);
            // 
            // p1Speed
            // 
            this.p1Speed.Interval = 16;
            this.p1Speed.Tick += new System.EventHandler(this.p1Speed_Tick);
            // 
            // p2Speed
            // 
            this.p2Speed.Interval = 16;
            this.p2Speed.Tick += new System.EventHandler(this.p2Speed_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(616, 450);
            this.Controls.Add(this.p2Ready);
            this.Controls.Add(this.p1Ready);
            this.Controls.Add(this.player2ScoreLabel);
            this.Controls.Add(this.player1ScoreLabel);
            this.Controls.Add(this.startLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameUpdateLoop;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label player1ScoreLabel;
        private System.Windows.Forms.Label player2ScoreLabel;
        private System.Windows.Forms.Label p1Ready;
        private System.Windows.Forms.Label p2Ready;
        private System.Windows.Forms.Timer ballUpSpeed;
        private System.Windows.Forms.Timer p1Speed;
        private System.Windows.Forms.Timer p2Speed;
    }
}

