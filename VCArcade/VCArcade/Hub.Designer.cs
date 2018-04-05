namespace VCArcade
{
    partial class frmHub
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
            this.btnLoadDice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadTicTacToe = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnLoadBreakout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadDice
            // 
            this.btnLoadDice.BackColor = System.Drawing.Color.Yellow;
            this.btnLoadDice.Location = new System.Drawing.Point(50, 318);
            this.btnLoadDice.Name = "btnLoadDice";
            this.btnLoadDice.Size = new System.Drawing.Size(148, 51);
            this.btnLoadDice.TabIndex = 0;
            this.btnLoadDice.Text = "DICE";
            this.btnLoadDice.UseVisualStyleBackColor = false;
            this.btnLoadDice.Click += new System.EventHandler(this.DiceButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose a Game";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VCArcade.Properties.Resources.Alea_6;
            this.pictureBox1.Location = new System.Drawing.Point(66, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 112);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadTicTacToe
            // 
            this.btnLoadTicTacToe.BackColor = System.Drawing.Color.Yellow;
            this.btnLoadTicTacToe.Location = new System.Drawing.Point(271, 322);
            this.btnLoadTicTacToe.Name = "btnLoadTicTacToe";
            this.btnLoadTicTacToe.Size = new System.Drawing.Size(148, 51);
            this.btnLoadTicTacToe.TabIndex = 3;
            this.btnLoadTicTacToe.Text = "TIC-TAC-TOE";
            this.btnLoadTicTacToe.UseVisualStyleBackColor = false;
            this.btnLoadTicTacToe.Click += new System.EventHandler(this.TIC_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::VCArcade.Properties.Resources.Cross;
            this.pictureBox2.Image = global::VCArcade.Properties.Resources.Cross;
            this.pictureBox2.Location = new System.Drawing.Point(281, 176);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(131, 128);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::VCArcade.Properties.Resources.Ball;
            this.pictureBox3.Image = global::VCArcade.Properties.Resources.Ball;
            this.pictureBox3.Location = new System.Drawing.Point(532, 183);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(112, 112);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // btnLoadBreakout
            // 
            this.btnLoadBreakout.BackColor = System.Drawing.Color.Yellow;
            this.btnLoadBreakout.Location = new System.Drawing.Point(513, 322);
            this.btnLoadBreakout.Name = "btnLoadBreakout";
            this.btnLoadBreakout.Size = new System.Drawing.Size(148, 51);
            this.btnLoadBreakout.TabIndex = 6;
            this.btnLoadBreakout.Text = "BREAKOUT";
            this.btnLoadBreakout.UseVisualStyleBackColor = false;
            this.btnLoadBreakout.Click += new System.EventHandler(this.btnLoadBreakout_Click);
            // 
            // frmHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VCArcade.Properties.Resources.black3;
            this.ClientSize = new System.Drawing.Size(708, 493);
            this.Controls.Add(this.btnLoadBreakout);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLoadTicTacToe);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadDice);
            this.Name = "frmHub";
            this.Text = "Ventura College Arcade";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadTicTacToe;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnLoadBreakout;
    }
}