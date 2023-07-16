
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
            this.dvContainer1 = new Devinno.Forms.Containers.DvContainer();
            this.dvTableLayoutPanel1 = new Devinno.Forms.Containers.DvTableLayoutPanel();
            this.lblTitleAreas = new Devinno.Forms.Controls.DvLabel();
            this.dvLabel1 = new Devinno.Forms.Controls.DvLabel();
            this.inputPanel1 = new ArduinoLadder.Controls.InputPanel();
            this.txt = new System.Windows.Forms.TextBox();
            this.tbl = new ArduinoLadder.Controls.HardwareTable();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.dvContainer2 = new Devinno.Forms.Containers.DvContainer();
            this.dvLabel3 = new Devinno.Forms.Controls.DvLabel();
            this.btnOK = new Devinno.Forms.Controls.DvButton();
            this.dvControl2 = new Devinno.Forms.Controls.DvControl();
            this.btnCancel = new Devinno.Forms.Controls.DvButton();
            this.dvContainer1.SuspendLayout();
            this.dvTableLayoutPanel1.SuspendLayout();
            this.inputPanel1.SuspendLayout();
            this.dvContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvContainer1
            // 
            this.dvContainer1.Controls.Add(this.dvTableLayoutPanel1);
            this.dvContainer1.Controls.Add(this.dvControl1);
            this.dvContainer1.Controls.Add(this.dvContainer2);
            this.dvContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvContainer1.Location = new System.Drawing.Point(3, 40);
            this.dvContainer1.Name = "dvContainer1";
            this.dvContainer1.Padding = new System.Windows.Forms.Padding(7, 10, 7, 7);
            this.dvContainer1.ShadowGap = 1;
            this.dvContainer1.Size = new System.Drawing.Size(1018, 725);
            this.dvContainer1.TabIndex = 0;
            this.dvContainer1.TabStop = false;
            this.dvContainer1.Text = "dvContainer1";
            // 
            // dvTableLayoutPanel1
            // 
            this.dvTableLayoutPanel1.ColumnCount = 3;
            this.dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.dvTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dvTableLayoutPanel1.Controls.Add(this.lblTitleAreas, 0, 0);
            this.dvTableLayoutPanel1.Controls.Add(this.dvLabel1, 2, 0);
            this.dvTableLayoutPanel1.Controls.Add(this.inputPanel1, 2, 1);
            this.dvTableLayoutPanel1.Controls.Add(this.tbl, 0, 1);
            this.dvTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvTableLayoutPanel1.Location = new System.Drawing.Point(7, 10);
            this.dvTableLayoutPanel1.Name = "dvTableLayoutPanel1";
            this.dvTableLayoutPanel1.RowCount = 2;
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.dvTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dvTableLayoutPanel1.Size = new System.Drawing.Size(1004, 661);
            this.dvTableLayoutPanel1.TabIndex = 6;
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
            this.lblTitleAreas.Size = new System.Drawing.Size(594, 30);
            this.lblTitleAreas.Style = Devinno.Forms.Embossing.FlatConcave;
            this.lblTitleAreas.TabIndex = 2;
            this.lblTitleAreas.TabStop = false;
            this.lblTitleAreas.Text = "하드웨어 내역";
            this.lblTitleAreas.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblTitleAreas.Unit = "";
            this.lblTitleAreas.UnitWidth = null;
            // 
            // dvLabel1
            // 
            this.dvLabel1.BackgroundDraw = false;
            this.dvLabel1.BorderColor = null;
            this.dvLabel1.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvLabel1.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel1.IconGap = 3;
            this.dvLabel1.IconImage = null;
            this.dvLabel1.IconSize = 12F;
            this.dvLabel1.IconString = "fa-i-cursor";
            this.dvLabel1.LabelColor = null;
            this.dvLabel1.Location = new System.Drawing.Point(613, 3);
            this.dvLabel1.Name = "dvLabel1";
            this.dvLabel1.Round = null;
            this.dvLabel1.ShadowGap = 1;
            this.dvLabel1.Size = new System.Drawing.Size(388, 30);
            this.dvLabel1.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel1.TabIndex = 3;
            this.dvLabel1.TabStop = false;
            this.dvLabel1.Text = "입력";
            this.dvLabel1.TextPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dvLabel1.Unit = "";
            this.dvLabel1.UnitWidth = null;
            // 
            // inputPanel1
            // 
            this.inputPanel1.Controls.Add(this.txt);
            this.inputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPanel1.Location = new System.Drawing.Point(613, 39);
            this.inputPanel1.Name = "inputPanel1";
            this.inputPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.inputPanel1.ShadowGap = 1;
            this.inputPanel1.Size = new System.Drawing.Size(388, 619);
            this.inputPanel1.TabIndex = 4;
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
            this.txt.Size = new System.Drawing.Size(368, 599);
            this.txt.TabIndex = 0;
            // 
            // tbl
            // 
            this.tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Location = new System.Drawing.Point(3, 39);
            this.tbl.Name = "tbl";
            this.tbl.ShadowGap = 1;
            this.tbl.Size = new System.Drawing.Size(594, 619);
            this.tbl.TabIndex = 5;
            this.tbl.TabStop = false;
            this.tbl.Text = "hardwareTable1";
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvControl1.Location = new System.Drawing.Point(7, 671);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(1004, 7);
            this.dvControl1.TabIndex = 5;
            this.dvControl1.TabStop = false;
            this.dvControl1.Text = "dvControl1";
            // 
            // dvContainer2
            // 
            this.dvContainer2.Controls.Add(this.dvLabel3);
            this.dvContainer2.Controls.Add(this.btnOK);
            this.dvContainer2.Controls.Add(this.dvControl2);
            this.dvContainer2.Controls.Add(this.btnCancel);
            this.dvContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dvContainer2.Location = new System.Drawing.Point(7, 678);
            this.dvContainer2.Name = "dvContainer2";
            this.dvContainer2.ShadowGap = 1;
            this.dvContainer2.Size = new System.Drawing.Size(1004, 40);
            this.dvContainer2.TabIndex = 4;
            this.dvContainer2.TabStop = false;
            this.dvContainer2.Text = "dvContainer2";
            // 
            // dvLabel3
            // 
            this.dvLabel3.BackgroundDraw = false;
            this.dvLabel3.BorderColor = null;
            this.dvLabel3.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleLeft;
            this.dvLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.dvLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.dvLabel3.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.dvLabel3.IconGap = 0;
            this.dvLabel3.IconImage = null;
            this.dvLabel3.IconSize = 12F;
            this.dvLabel3.IconString = null;
            this.dvLabel3.LabelColor = null;
            this.dvLabel3.Location = new System.Drawing.Point(0, 0);
            this.dvLabel3.Name = "dvLabel3";
            this.dvLabel3.Round = null;
            this.dvLabel3.ShadowGap = 1;
            this.dvLabel3.Size = new System.Drawing.Size(380, 40);
            this.dvLabel3.Style = Devinno.Forms.Embossing.FlatConcave;
            this.dvLabel3.TabIndex = 5;
            this.dvLabel3.TabStop = false;
            this.dvLabel3.Text = "※입력 형식 : \'모드 핀번호 영역\'\r\n※입력 예시 : \'OUT 3 P0\", \"IN 4 P10\", \"AD 0 D10\", \"DA 12 D20\"";
            this.dvLabel3.TextPadding = new System.Windows.Forms.Padding(0);
            this.dvLabel3.Unit = "";
            this.dvLabel3.UnitWidth = null;
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
            this.btnOK.Location = new System.Drawing.Point(806, 0);
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
            this.dvControl2.Location = new System.Drawing.Point(900, 0);
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
            this.btnCancel.Location = new System.Drawing.Point(910, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Round = null;
            this.btnCancel.ShadowGap = 1;
            this.btnCancel.Size = new System.Drawing.Size(94, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취소";
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseKey = false;
            // 
            // FormHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.dvContainer1);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FormHardware";
            this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.Text = "하드웨어";
            this.Title = "하드웨어";
            this.TitleIconBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(99)))));
            this.TitleIconSize = 14F;
            this.TitleIconString = "fa-memory";
            this.dvContainer1.ResumeLayout(false);
            this.dvTableLayoutPanel1.ResumeLayout(false);
            this.inputPanel1.ResumeLayout(false);
            this.inputPanel1.PerformLayout();
            this.dvContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Devinno.Forms.Controls.DvLabel dvLabel1;
        private Controls.InputPanel inputPanel1;
        private System.Windows.Forms.TextBox txt;
        private Controls.HardwareTable tbl;
    }
}