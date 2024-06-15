
namespace ArduinoLadder.Forms
{
    partial class FormHardware
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHardware));
            dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            dvTableLayoutPanel1 = new Devinno.Forms.Containers.DvTableLayoutPanel();
            lblTitleAreas = new Devinno.Forms.Controls.DvLabel();
            inputPanel1 = new Controls.InputPanel();
            txt = new System.Windows.Forms.TextBox();
            tbl = new Controls.HardwareTable();
            dvContainer3 = new Devinno.Forms.Containers.DvContainer();
            btnImport = new Devinno.Forms.Controls.DvButton();
            dvControl3 = new Devinno.Forms.Controls.DvControl();
            btnExport = new Devinno.Forms.Controls.DvButton();
            dvLabel1 = new Devinno.Forms.Controls.DvLabel();
            dvControl1 = new Devinno.Forms.Controls.DvControl();
            dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            dvLabel3 = new Devinno.Forms.Controls.DvLabel();
            btnOK = new Devinno.Forms.Controls.DvButton();
            dvControl2 = new Devinno.Forms.Controls.DvControl();
            btnCancel = new Devinno.Forms.Controls.DvButton();
            dvContainer1.SuspendLayout();
            dvTableLayoutPanel1.SuspendLayout();
            inputPanel1.SuspendLayout();
            dvContainer3.SuspendLayout();
            dvContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // dvContainer1
            // 
            dvContainer1.Controls.Add(dvTableLayoutPanel1);
            dvContainer1.Controls.Add(dvControl1);
            dvContainer1.Controls.Add(dvContainer2);
            dvContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            dvContainer1.Location = new System.Drawing.Point(0, 0);
            dvContainer1.Name = "dvContainer1";
            dvContainer1.Padding = new System.Windows.Forms.Padding(10);
            dvContainer1.ShadowGap = 1;
            dvContainer1.Size = new System.Drawing.Size(1008, 729);
            dvContainer1.TabIndex = 0;
            dvContainer1.TabStop = false;
            dvContainer1.Text = "dvContainer1";
            // 
            // dvTableLayoutPanel1
            // 
            dvTableLayoutPanel1.ColumnCount = 3;
            dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            dvTableLayoutPanel1.Controls.Add(lblTitleAreas, 0, 0);
            dvTableLayoutPanel1.Controls.Add(inputPanel1, 2, 1);
            dvTableLayoutPanel1.Controls.Add(tbl, 0, 1);
            dvTableLayoutPanel1.Controls.Add(dvContainer3, 2, 0);
            dvTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            dvTableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            dvTableLayoutPanel1.Name = "dvTableLayoutPanel1";
            dvTableLayoutPanel1.RowCount = 2;
            dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            dvTableLayoutPanel1.Size = new System.Drawing.Size(988, 662);
            dvTableLayoutPanel1.TabIndex = 6;
            // 
            // lblTitleAreas
            // 
            lblTitleAreas.BackgroundDraw = false;
            lblTitleAreas.BorderColor = null;
            lblTitleAreas.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            lblTitleAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitleAreas.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            lblTitleAreas.IconGap = 3;
            lblTitleAreas.IconImage = null;
            lblTitleAreas.IconSize = 12F;
            lblTitleAreas.IconString = "fa-list-ul";
            lblTitleAreas.LabelColor = null;
            lblTitleAreas.Location = new System.Drawing.Point(3, 3);
            lblTitleAreas.Name = "lblTitleAreas";
            lblTitleAreas.Round = null;
            lblTitleAreas.ShadowGap = 1;
            lblTitleAreas.Size = new System.Drawing.Size(594, 30);
            lblTitleAreas.Style = Devinno.Forms.Embossing.FlatConcave;
            lblTitleAreas.TabIndex = 2;
            lblTitleAreas.TabStop = false;
            lblTitleAreas.Text = "하드웨어 내역";
            lblTitleAreas.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            lblTitleAreas.Unit = "";
            lblTitleAreas.UnitWidth = null;
            // 
            // inputPanel1
            // 
            inputPanel1.Controls.Add(txt);
            inputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            inputPanel1.Location = new System.Drawing.Point(613, 39);
            inputPanel1.Name = "inputPanel1";
            inputPanel1.Padding = new System.Windows.Forms.Padding(10);
            inputPanel1.ShadowGap = 1;
            inputPanel1.Size = new System.Drawing.Size(372, 620);
            inputPanel1.TabIndex = 4;
            inputPanel1.TabStop = false;
            inputPanel1.Text = "inputPanel1";
            // 
            // txt
            // 
            txt.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt.Dock = System.Windows.Forms.DockStyle.Fill;
            txt.ForeColor = System.Drawing.Color.White;
            txt.Location = new System.Drawing.Point(10, 10);
            txt.Multiline = true;
            txt.Name = "txt";
            txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txt.Size = new System.Drawing.Size(352, 600);
            txt.TabIndex = 0;
            // 
            // tbl
            // 
            tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            tbl.Location = new System.Drawing.Point(3, 39);
            tbl.Name = "tbl";
            tbl.ShadowGap = 1;
            tbl.Size = new System.Drawing.Size(594, 620);
            tbl.TabIndex = 5;
            tbl.TabStop = false;
            tbl.Text = "hardwareTable1";
            // 
            // dvContainer3
            // 
            dvContainer3.Controls.Add(btnImport);
            dvContainer3.Controls.Add(dvControl3);
            dvContainer3.Controls.Add(btnExport);
            dvContainer3.Controls.Add(dvLabel1);
            dvContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            dvContainer3.Location = new System.Drawing.Point(613, 3);
            dvContainer3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            dvContainer3.Name = "dvContainer3";
            dvContainer3.ShadowGap = 1;
            dvContainer3.Size = new System.Drawing.Size(375, 30);
            dvContainer3.TabIndex = 6;
            dvContainer3.TabStop = false;
            // 
            // btnImport
            // 
            btnImport.BackgroundDraw = true;
            btnImport.ButtonColor = null;
            btnImport.Clickable = true;
            btnImport.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            btnImport.Dock = System.Windows.Forms.DockStyle.Right;
            btnImport.Gradient = true;
            btnImport.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            btnImport.IconGap = 0;
            btnImport.IconImage = null;
            btnImport.IconSize = 12F;
            btnImport.IconString = "fa-file-import";
            btnImport.Location = new System.Drawing.Point(190, 0);
            btnImport.Name = "btnImport";
            btnImport.Round = null;
            btnImport.ShadowGap = 1;
            btnImport.Size = new System.Drawing.Size(91, 30);
            btnImport.TabIndex = 7;
            btnImport.Text = "가져오기";
            btnImport.TextPadding = new System.Windows.Forms.Padding(0);
            btnImport.UseKey = false;
            // 
            // dvControl3
            // 
            dvControl3.Dock = System.Windows.Forms.DockStyle.Right;
            dvControl3.Location = new System.Drawing.Point(281, 0);
            dvControl3.Name = "dvControl3";
            dvControl3.ShadowGap = 1;
            dvControl3.Size = new System.Drawing.Size(3, 30);
            dvControl3.TabIndex = 6;
            dvControl3.TabStop = false;
            dvControl3.Text = "dvControl3";
            // 
            // btnExport
            // 
            btnExport.BackgroundDraw = true;
            btnExport.ButtonColor = null;
            btnExport.Clickable = true;
            btnExport.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            btnExport.Gradient = true;
            btnExport.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            btnExport.IconGap = 0;
            btnExport.IconImage = null;
            btnExport.IconSize = 12F;
            btnExport.IconString = "fa-file-export";
            btnExport.Location = new System.Drawing.Point(284, 0);
            btnExport.Name = "btnExport";
            btnExport.Round = null;
            btnExport.ShadowGap = 1;
            btnExport.Size = new System.Drawing.Size(91, 30);
            btnExport.TabIndex = 5;
            btnExport.Text = "내보내기";
            btnExport.TextPadding = new System.Windows.Forms.Padding(0);
            btnExport.UseKey = false;
            // 
            // dvLabel1
            // 
            dvLabel1.BackgroundDraw = false;
            dvLabel1.BorderColor = null;
            dvLabel1.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            dvLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            dvLabel1.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            dvLabel1.IconGap = 3;
            dvLabel1.IconImage = null;
            dvLabel1.IconSize = 12F;
            dvLabel1.IconString = "fa-i-cursor";
            dvLabel1.LabelColor = null;
            dvLabel1.Location = new System.Drawing.Point(0, 0);
            dvLabel1.Name = "dvLabel1";
            dvLabel1.Round = null;
            dvLabel1.ShadowGap = 1;
            dvLabel1.Size = new System.Drawing.Size(110, 30);
            dvLabel1.Style = Devinno.Forms.Embossing.FlatConcave;
            dvLabel1.TabIndex = 4;
            dvLabel1.TabStop = false;
            dvLabel1.Text = "입력";
            dvLabel1.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            dvLabel1.Unit = "";
            dvLabel1.UnitWidth = null;
            // 
            // dvControl1
            // 
            dvControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            dvControl1.Location = new System.Drawing.Point(10, 672);
            dvControl1.Name = "dvControl1";
            dvControl1.ShadowGap = 1;
            dvControl1.Size = new System.Drawing.Size(988, 7);
            dvControl1.TabIndex = 5;
            dvControl1.TabStop = false;
            dvControl1.Text = "dvControl1";
            // 
            // dvContainer2
            // 
            dvContainer2.Controls.Add(dvLabel3);
            dvContainer2.Controls.Add(btnOK);
            dvContainer2.Controls.Add(dvControl2);
            dvContainer2.Controls.Add(btnCancel);
            dvContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            dvContainer2.Location = new System.Drawing.Point(10, 679);
            dvContainer2.Name = "dvContainer2";
            dvContainer2.ShadowGap = 1;
            dvContainer2.Size = new System.Drawing.Size(988, 40);
            dvContainer2.TabIndex = 4;
            dvContainer2.TabStop = false;
            dvContainer2.Text = "dvContainer2";
            // 
            // dvLabel3
            // 
            dvLabel3.BackgroundDraw = false;
            dvLabel3.BorderColor = null;
            dvLabel3.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            dvLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            dvLabel3.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            dvLabel3.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            dvLabel3.IconGap = 0;
            dvLabel3.IconImage = null;
            dvLabel3.IconSize = 12F;
            dvLabel3.IconString = null;
            dvLabel3.LabelColor = null;
            dvLabel3.Location = new System.Drawing.Point(0, 0);
            dvLabel3.Name = "dvLabel3";
            dvLabel3.Round = null;
            dvLabel3.ShadowGap = 1;
            dvLabel3.Size = new System.Drawing.Size(457, 40);
            dvLabel3.Style = Devinno.Forms.Embossing.FlatConcave;
            dvLabel3.TabIndex = 5;
            dvLabel3.TabStop = false;
            dvLabel3.Text = "※입력 형식 : '모드 핀번호 영역'\r\n※입력 예시 : 'OUT 3 P0\", \"IN 4 P10\", \"AD 0 D10\", \"DA 12 D20\"";
            dvLabel3.TextPadding = new System.Windows.Forms.Padding(0);
            dvLabel3.Unit = "";
            dvLabel3.UnitWidth = null;
            // 
            // btnOK
            // 
            btnOK.BackgroundDraw = true;
            btnOK.ButtonColor = null;
            btnOK.Clickable = true;
            btnOK.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            btnOK.Gradient = true;
            btnOK.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            btnOK.IconGap = 0;
            btnOK.IconImage = null;
            btnOK.IconSize = 12F;
            btnOK.IconString = null;
            btnOK.Location = new System.Drawing.Point(790, 0);
            btnOK.Name = "btnOK";
            btnOK.Round = null;
            btnOK.ShadowGap = 1;
            btnOK.Size = new System.Drawing.Size(94, 40);
            btnOK.TabIndex = 4;
            btnOK.Text = "확인";
            btnOK.TextPadding = new System.Windows.Forms.Padding(0);
            btnOK.UseKey = false;
            // 
            // dvControl2
            // 
            dvControl2.Dock = System.Windows.Forms.DockStyle.Right;
            dvControl2.Location = new System.Drawing.Point(884, 0);
            dvControl2.Name = "dvControl2";
            dvControl2.ShadowGap = 1;
            dvControl2.Size = new System.Drawing.Size(10, 40);
            dvControl2.TabIndex = 3;
            dvControl2.TabStop = false;
            dvControl2.Text = "dvControl2";
            // 
            // btnCancel
            // 
            btnCancel.BackgroundDraw = true;
            btnCancel.ButtonColor = null;
            btnCancel.Clickable = true;
            btnCancel.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            btnCancel.Gradient = true;
            btnCancel.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            btnCancel.IconGap = 0;
            btnCancel.IconImage = null;
            btnCancel.IconSize = 12F;
            btnCancel.IconString = null;
            btnCancel.Location = new System.Drawing.Point(894, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Round = null;
            btnCancel.ShadowGap = 1;
            btnCancel.Size = new System.Drawing.Size(94, 40);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "취소";
            btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            btnCancel.UseKey = false;
            // 
            // FormHardware
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BlankForm = true;
            ClientSize = new System.Drawing.Size(1008, 729);
            Controls.Add(dvContainer1);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(1024, 768);
            Name = "FormHardware";
            Padding = new System.Windows.Forms.Padding(0);
            Text = "하드웨어";
            Title = "하드웨어";
            TitleHeight = 0;
            TitleIconBoxColor = System.Drawing.Color.FromArgb(0, 102, 99);
            TitleIconSize = 14F;
            TitleIconString = "fa-memory";
            dvContainer1.ResumeLayout(false);
            dvTableLayoutPanel1.ResumeLayout(false);
            inputPanel1.ResumeLayout(false);
            inputPanel1.PerformLayout();
            dvContainer3.ResumeLayout(false);
            dvContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Devinno.Forms.Containers.DvContainer dvContainer1;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Containers.DvContainer dvContainer2;
        private Devinno.Forms.Controls.DvLabel dvLabel3;
        private Devinno.Forms.Controls.DvButton btnOK;
        private Devinno.Forms.Controls.DvControl dvControl2;
        private Devinno.Forms.Controls.DvButton btnCancel;
        private Devinno.Forms.Containers.DvTableLayoutPanel dvTableLayoutPanel1;
        private Devinno.Forms.Controls.DvLabel lblTitleAreas;
        private Controls.InputPanel inputPanel1;
        private System.Windows.Forms.TextBox txt;
        private Controls.HardwareTable tbl;
        private Devinno.Forms.Containers.DvContainer dvContainer3;
        private Devinno.Forms.Controls.DvButton btnImport;
        private Devinno.Forms.Controls.DvControl dvControl3;
        private Devinno.Forms.Controls.DvButton btnExport;
        private Devinno.Forms.Controls.DvLabel dvLabel1;
    }
}