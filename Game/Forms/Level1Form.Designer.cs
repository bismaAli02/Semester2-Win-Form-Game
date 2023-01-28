namespace Game.Forms
{
    partial class Level1Form
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
            this.Scorelbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Scorelbl
            // 
            this.Scorelbl.AutoSize = true;
            this.Scorelbl.BackColor = System.Drawing.Color.Transparent;
            this.Scorelbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Scorelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scorelbl.Location = new System.Drawing.Point(813, 9);
            this.Scorelbl.Name = "Scorelbl";
            this.Scorelbl.Size = new System.Drawing.Size(61, 17);
            this.Scorelbl.TabIndex = 1;
            this.Scorelbl.Text = "Score: 0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Level1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game.Properties.Resources.playArea;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(886, 536);
            this.Controls.Add(this.Scorelbl);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Level1Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level1Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Level1Form_FormClosing);
            this.Load += new System.EventHandler(this.Level1Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Level1Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Scorelbl;
        private System.Windows.Forms.Timer timer1;
    }
}