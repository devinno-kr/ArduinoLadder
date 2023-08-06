﻿
namespace ArduinoLadder.Forms
{
    partial class FormMessageBox
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
            this.layout = new Devinno.Forms.Containers.DvContainer();
            this.tpnl = new Devinno.Forms.Containers.DvTableLayoutPanel();
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Controls.Add(this.tpnl);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 40);
            this.layout.Name = "layout";
            this.layout.Padding = new System.Windows.Forms.Padding(10);
            this.layout.ShadowGap = 1;
            this.layout.Size = new System.Drawing.Size(240, 110);
            this.layout.TabIndex = 0;
            this.layout.TabStop = false;
            this.layout.Text = "dvContainer1";
            // 
            // tpnl
            // 
            this.tpnl.ColumnCount = 8;
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tpnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnl.Location = new System.Drawing.Point(10, 10);
            this.tpnl.Name = "tpnl";
            this.tpnl.RowCount = 2;
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tpnl.Size = new System.Drawing.Size(220, 90);
            this.tpnl.TabIndex = 0;
            // 
            // DvMessageBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(240, 150);
            this.Controls.Add(this.layout);
            this.Fixed = true;
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 150);
            this.Name = "DvMessageBox";
            this.Text = "메시지박스";
            this.Title = "메시지박스";
            this.TitleIconSize = 14F;
            this.TitleIconString = "fa-comment-dots";
            this.layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer layout;
        private Devinno.Forms.Containers.DvTableLayoutPanel tpnl;
    }
}