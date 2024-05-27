﻿
namespace ArduinoLadder.Forms
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            this.dvTableLayoutPanel1 = new Devinno.Forms.Containers.DvTableLayoutPanel();
            this.lblArduino = new ArduinoLadder.Controls.DvValueLabelPath();
            this.lblTitleAreas = new Devinno.Forms.Controls.DvLabel();
            this.lblPath = new ArduinoLadder.Controls.DvValueLabelPath();
            this.inLang = new Devinno.Forms.Controls.DvValueInputBool();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.btnOK = new Devinno.Forms.Controls.DvButton();
            this.dvControl2 = new Devinno.Forms.Controls.DvControl();
            this.btnCancel = new Devinno.Forms.Controls.DvButton();
            this.inDescView = new Devinno.Forms.Controls.DvValueInputBool();
            this.dvContainer1.SuspendLayout();
            this.dvTableLayoutPanel1.SuspendLayout();
            this.dvContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.dvTableLayoutPanel1);
            this.dvContainer1.Controls.Add(this.dvControl1);
            this.dvContainer1.Controls.Add(this.dvContainer2);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer1.Location = new System.Drawing.Point(0, 0);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(446, 297);
            this.dvContainer1.TabIndex = 0;
            this.dvContainer1.TabStop = false;
            this.dvContainer1.Text = "dvContainer1";
            // 
            // dvTableLayoutPanel1
            // 
            this.dvTableLayoutPanel1.ColumnCount = 1;
            this.dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dvTableLayoutPanel1.Controls.Add(this.inDescView, 0, 4);
            this.dvTableLayoutPanel1.Controls.Add(this.lblArduino, 0, 2);
            this.dvTableLayoutPanel1.Controls.Add(this.lblTitleAreas, 0, 0);
            this.dvTableLayoutPanel1.Controls.Add(this.lblPath, 0, 1);
            this.dvTableLayoutPanel1.Controls.Add(this.inLang, 0, 3);
            this.dvTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvTableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.dvTableLayoutPanel1.Name = "dvTableLayoutPanel1";
            this.dvTableLayoutPanel1.RowCount = 6;
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dvTableLayoutPanel1.Size = new System.Drawing.Size(426, 227);
            this.dvTableLayoutPanel1.TabIndex = 7;
            // 
            // lblArduino
            // 
            this.lblArduino.Button = null;
            this.lblArduino.ButtonColor = null;
            this.lblArduino.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblArduino.ButtonIconGap = 0;
            this.lblArduino.ButtonIconImage = null;
            this.lblArduino.ButtonIconSize = 12F;
            this.lblArduino.ButtonIconString = "fa-ellipsis";
            this.lblArduino.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.lblArduino.ButtonWidth = 50;
            this.lblArduino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArduino.Location = new System.Drawing.Point(3, 85);
            this.lblArduino.Name = "lblArduino";
            this.lblArduino.Round = null;
            this.lblArduino.ShadowGap = 1;
            this.lblArduino.Size = new System.Drawing.Size(420, 40);
            this.lblArduino.TabIndex = 4;
            this.lblArduino.Text = "아두이노 폴더";
            this.lblArduino.Title = "아두이노 폴더";
            this.lblArduino.TitleColor = null;
            this.lblArduino.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblArduino.TitleIconGap = 0;
            this.lblArduino.TitleIconImage = null;
            this.lblArduino.TitleIconSize = 12F;
            this.lblArduino.TitleIconString = null;
            this.lblArduino.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.lblArduino.TitleWidth = 100;
            this.lblArduino.Unit = "";
            this.lblArduino.UnitWidth = null;
            this.lblArduino.Value = "";
            this.lblArduino.ValueColor = null;
            // 
            // lblTitleAreas
            // 
            this.lblTitleAreas.BackgroundDraw = false;
            this.lblTitleAreas.BorderColor = null;
            this.lblTitleAreas.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.lblTitleAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleAreas.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblTitleAreas.IconGap = 3;
            this.lblTitleAreas.IconImage = null;
            this.lblTitleAreas.IconSize = 12F;
            this.lblTitleAreas.IconString = "fa-list-ul";
            this.lblTitleAreas.LabelColor = null;
            this.lblTitleAreas.Location = new System.Drawing.Point(3, 3);
            this.lblTitleAreas.Name = "lblTitleAreas";
            this.lblTitleAreas.Round = null;
            this.lblTitleAreas.ShadowGap = 1;
            this.lblTitleAreas.Size = new System.Drawing.Size(420, 30);
            this.lblTitleAreas.Style = Devinno.Forms.Embossing.FlatConcave;
            this.lblTitleAreas.TabIndex = 2;
            this.lblTitleAreas.TabStop = false;
            this.lblTitleAreas.Text = "설정 내역";
            this.lblTitleAreas.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblTitleAreas.Unit = "";
            this.lblTitleAreas.UnitWidth = null;
            // 
            // lblPath
            // 
            this.lblPath.Button = null;
            this.lblPath.ButtonColor = null;
            this.lblPath.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblPath.ButtonIconGap = 0;
            this.lblPath.ButtonIconImage = null;
            this.lblPath.ButtonIconSize = 12F;
            this.lblPath.ButtonIconString = "fa-ellipsis";
            this.lblPath.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.lblPath.ButtonWidth = 50;
            this.lblPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPath.Location = new System.Drawing.Point(3, 39);
            this.lblPath.Name = "lblPath";
            this.lblPath.Round = null;
            this.lblPath.ShadowGap = 1;
            this.lblPath.Size = new System.Drawing.Size(420, 40);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "프로젝트 폴더";
            this.lblPath.Title = "프로젝트 폴더";
            this.lblPath.TitleColor = null;
            this.lblPath.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblPath.TitleIconGap = 0;
            this.lblPath.TitleIconImage = null;
            this.lblPath.TitleIconSize = 12F;
            this.lblPath.TitleIconString = null;
            this.lblPath.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.lblPath.TitleWidth = 100;
            this.lblPath.Unit = "";
            this.lblPath.UnitWidth = null;
            this.lblPath.Value = "";
            this.lblPath.ValueColor = null;
            // 
            // inLang
            // 
            this.inLang.Button = null;
            this.inLang.ButtonColor = null;
            this.inLang.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inLang.ButtonIconGap = 0;
            this.inLang.ButtonIconImage = null;
            this.inLang.ButtonIconSize = 12F;
            this.inLang.ButtonIconString = null;
            this.inLang.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.inLang.ButtonWidth = null;
            this.inLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inLang.Location = new System.Drawing.Point(3, 131);
            this.inLang.Name = "inLang";
            this.inLang.Off = "ENG";
            this.inLang.On = "한글";
            this.inLang.Round = null;
            this.inLang.ShadowGap = 1;
            this.inLang.Size = new System.Drawing.Size(420, 40);
            this.inLang.TabIndex = 5;
            this.inLang.Text = "언어";
            this.inLang.Title = "언어";
            this.inLang.TitleColor = null;
            this.inLang.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inLang.TitleIconGap = 0;
            this.inLang.TitleIconImage = null;
            this.inLang.TitleIconSize = 12F;
            this.inLang.TitleIconString = null;
            this.inLang.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.inLang.TitleWidth = 100;
            this.inLang.Unit = "";
            this.inLang.UnitWidth = null;
            this.inLang.Value = false;
            this.inLang.ValueColor = null;
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvControl1.Location = new System.Drawing.Point(10, 237);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(426, 10);
            this.dvControl1.TabIndex = 6;
            this.dvControl1.TabStop = false;
            this.dvControl1.Text = "dvControl1";
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.btnOK);
            this.dvContainer2.Controls.Add(this.dvControl2);
            this.dvContainer2.Controls.Add(this.btnCancel);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvContainer2.Location = new System.Drawing.Point(10, 247);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.Padding = new System.Windows.Forms.Padding(168, 0, 0, 0);
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(426, 40);
            this.dvContainer2.TabIndex = 5;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
            // 
            // btnOK
            // 
            this.btnOK.BackgroundDraw = true;
            this.btnOK.ButtonColor = null;
            this.btnOK.Clickable = true;
            this.btnOK.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Gradient = true;
            this.btnOK.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnOK.IconGap = 0;
            this.btnOK.IconImage = null;
            this.btnOK.IconSize = 12F;
            this.btnOK.IconString = null;
            this.btnOK.Location = new System.Drawing.Point(228, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Round = null;
            this.btnOK.ShadowGap = 1;
            this.btnOK.Size = new System.Drawing.Size(94, 40);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "확인";
            this.btnOK.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnOK.UseKey = false;
            // 
            // dvControl2
            // 
            this.dvControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl2.Location = new System.Drawing.Point(322, 0);
            this.dvControl2.Name = "dvControl2";
            this.dvControl2.ShadowGap = 1;
            this.dvControl2.Size = new System.Drawing.Size(10, 40);
            this.dvControl2.TabIndex = 3;
            this.dvControl2.TabStop = false;
            this.dvControl2.Text = "dvControl2";
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundDraw = true;
            this.btnCancel.ButtonColor = null;
            this.btnCancel.Clickable = true;
            this.btnCancel.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Gradient = true;
            this.btnCancel.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnCancel.IconGap = 0;
            this.btnCancel.IconImage = null;
            this.btnCancel.IconSize = 12F;
            this.btnCancel.IconString = null;
            this.btnCancel.Location = new System.Drawing.Point(332, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Round = null;
            this.btnCancel.ShadowGap = 1;
            this.btnCancel.Size = new System.Drawing.Size(94, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취소";
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseKey = false;
            // 
            // inDescView
            // 
            this.inDescView.Button = null;
            this.inDescView.ButtonColor = null;
            this.inDescView.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inDescView.ButtonIconGap = 0;
            this.inDescView.ButtonIconImage = null;
            this.inDescView.ButtonIconSize = 12F;
            this.inDescView.ButtonIconString = null;
            this.inDescView.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.inDescView.ButtonWidth = null;
            this.inDescView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inDescView.Location = new System.Drawing.Point(3, 177);
            this.inDescView.Name = "inDescView";
            this.inDescView.Off = "축약";
            this.inDescView.On = "전체";
            this.inDescView.Round = null;
            this.inDescView.ShadowGap = 1;
            this.inDescView.Size = new System.Drawing.Size(420, 40);
            this.inDescView.TabIndex = 6;
            this.inDescView.Text = "구문 표시";
            this.inDescView.Title = "구문 표시";
            this.inDescView.TitleColor = null;
            this.inDescView.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.inDescView.TitleIconGap = 0;
            this.inDescView.TitleIconImage = null;
            this.inDescView.TitleIconSize = 12F;
            this.inDescView.TitleIconString = null;
            this.inDescView.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.inDescView.TitleWidth = 100;
            this.inDescView.Unit = "";
            this.inDescView.UnitWidth = null;
            this.inDescView.Value = false;
            this.inDescView.ValueColor = null;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BlankForm = true;
            this.ClientSize = new System.Drawing.Size(446, 297);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "설정";
            this.Title = "설정";
            this.TitleHeight = 0;
            this.TitleIconBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(102)))));
            this.TitleIconString = "fa-gear";
            this.dvContainer1.ResumeLayout(false);
            this.dvTableLayoutPanel1.ResumeLayout(false);
            this.dvContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvButton btnOK;
        private Devinno.Forms.Controls.DvControl dvControl2;
        private Devinno.Forms.Controls.DvButton btnCancel;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Containers.DvTableLayoutPanel dvTableLayoutPanel1;
        private Devinno.Forms.Controls.DvLabel lblTitleAreas;
        private Controls.DvValueLabelPath lblPath;
        private Controls.DvValueLabelPath lblArduino;
        private Devinno.Forms.Controls.DvValueInputBool inLang;
        private Devinno.Forms.Controls.DvValueInputBool inDescView;
    }
}