namespace Game.Forms
{
    partial class InputNameForm
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
            this.EnterBtn = new System.Windows.Forms.Button();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnterBtn
            // 
            this.EnterBtn.BackColor = System.Drawing.Color.Black;
            this.EnterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EnterBtn.Location = new System.Drawing.Point(391, 108);
            this.EnterBtn.Name = "EnterBtn";
            this.EnterBtn.Size = new System.Drawing.Size(94, 43);
            this.EnterBtn.TabIndex = 5;
            this.EnterBtn.Text = "Enter";
            this.EnterBtn.UseVisualStyleBackColor = false;
            this.EnterBtn.Click += new System.EventHandler(this.EnterBtn_Click);
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(217, 28);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.Size = new System.Drawing.Size(168, 30);
            this.Nametxt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Your Name";
            // 
            // InputNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(497, 178);
            this.Controls.Add(this.EnterBtn);
            this.Controls.Add(this.Nametxt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputNameForm";
            this.Text = "InputNameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputNameForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterBtn;
        private System.Windows.Forms.TextBox Nametxt;
        private System.Windows.Forms.Label label1;
    }
}