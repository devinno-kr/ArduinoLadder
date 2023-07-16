
namespace ArduinoLadder.Forms
{
    partial class FormDefault
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
            this.dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            this.inputPanel1 = new ArduinoLadder.Controls.InputPanel();
            this.txt = new System.Windows.Forms.TextBox();
            this.dvContainer1.SuspendLayout();
            this.inputPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.inputPanel1);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer1.Location = new System.Drawing.Point(0, 40);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(338, 355);
            this.dvContainer1.TabIndex = 0;
            this.dvContainer1.TabStop = false;
            this.dvContainer1.Text = "dvContainer1";
            // 
            // inputPanel1
            // 
            this.inputPanel1.Controls.Add(this.txt);
            this.inputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPanel1.Location = new System.Drawing.Point(10, 10);
            this.inputPanel1.Name = "inputPanel1";
            this.inputPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.inputPanel1.ShadowGap = 1;
            this.inputPanel1.Size = new System.Drawing.Size(318, 335);
            this.inputPanel1.TabIndex = 0;
            this.inputPanel1.TabStop = false;
            this.inputPanel1.Text = "inputPanel1";
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.ForeColor = System.Drawing.Color.White;
            this.txt.Location = new System.Drawing.Point(10, 10);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(298, 315);
            this.txt.TabIndex = 0;
            // 
            // FormDefault
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(338, 395);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefault";
            this.Text = "메인 코드";
            this.Title = "메인 코드";
            this.TitleIconSize = 14F;
            this.TitleIconString = "fa-code";
            this.dvContainer1.ResumeLayout(false);
            this.inputPanel1.ResumeLayout(false);
            this.inputPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Controls.InputPanel inputPanel1;
        private System.Windows.Forms.TextBox txt;
    }
}