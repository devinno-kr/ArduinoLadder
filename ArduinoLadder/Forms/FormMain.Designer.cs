
namespace ArduinoLadder.Forms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlTop = new Devinno.Forms.Containers.DvContainer();
            this.pnlLD = new Devinno.Forms.Containers.DvTableLayoutPanel();
            this.btnF12 = new Devinno.Forms.Controls.DvButton();
            this.btnF11 = new Devinno.Forms.Controls.DvButton();
            this.btnF9 = new Devinno.Forms.Controls.DvButton();
            this.btnF8 = new Devinno.Forms.Controls.DvButton();
            this.btnF7 = new Devinno.Forms.Controls.DvButton();
            this.btnF6 = new Devinno.Forms.Controls.DvButton();
            this.btnF5 = new Devinno.Forms.Controls.DvButton();
            this.btnF4 = new Devinno.Forms.Controls.DvButton();
            this.btnF3 = new Devinno.Forms.Controls.DvButton();
            this.btnSPC = new Devinno.Forms.Controls.DvButton();
            this.pnlToolBar = new Devinno.Forms.Containers.DvTableLayoutPanel();
            this.btnNewFile = new Devinno.Forms.Controls.DvButton();
            this.btnOpenFile = new Devinno.Forms.Controls.DvButton();
            this.btnSaveFile = new Devinno.Forms.Controls.DvButton();
            this.btnSaveAsFile = new Devinno.Forms.Controls.DvButton();
            this.btnCheck = new Devinno.Forms.Controls.DvButton();
            this.btnHardware = new Devinno.Forms.Controls.DvButton();
            this.btnSymbol = new Devinno.Forms.Controls.DvButton();
            this.btnCommunication = new Devinno.Forms.Controls.DvButton();
            this.lblSketchPath = new ArduinoLadder.Controls.DvValueLabelPath();
            this.btnExport = new Devinno.Forms.Controls.DvButton();
            this.btnDefaultCode = new Devinno.Forms.Controls.DvButton();
            this.pnlStatus = new Devinno.Forms.Containers.DvContainer();
            this.lblDebugPort = new Devinno.Forms.Controls.DvValueLabelText();
            this.dvControl3 = new Devinno.Forms.Controls.DvControl();
            this.btnDTR = new Devinno.Forms.Controls.DvButton();
            this.lblCursorPosition = new Devinno.Forms.Controls.DvLabel();
            this.dvControl2 = new Devinno.Forms.Controls.DvControl();
            this.btnSetting = new Devinno.Forms.Controls.DvButton();
            this.dvControl1 = new Devinno.Forms.Controls.DvControl();
            this.btnMonitoring = new Devinno.Forms.Controls.DvButton();
            this.splitter = new Devinno.Forms.Containers.DvSplitterTableLayoutPanel();
            this.pnlMessage = new Devinno.Forms.Containers.DvContainer();
            this.gridMessage = new Devinno.Forms.Controls.DvDataGrid();
            this.pnlContent = new Devinno.Forms.Containers.DvContainer();
            this.ladder = new ArduinoLadder.Controls.LadderEditorControl();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmsDis = new Devinno.Forms.Menus.DvContextMenuStrip();
            this.tsmiDEC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHEX = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBIN = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            this.pnlLD.SuspendLayout();
            this.pnlToolBar.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.splitter.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.cmsDis.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlTop.Controls.Add(this.pnlLD);
            this.pnlTop.Controls.Add(this.pnlToolBar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.ShadowGap = 1;
            this.pnlTop.Size = new System.Drawing.Size(1024, 127);
            this.pnlTop.TabIndex = 5;
            this.pnlTop.TabStop = false;
            this.pnlTop.Text = "dvContainer1";
            // 
            // pnlLD
            // 
            this.pnlLD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlLD.ColumnCount = 10;
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlLD.Controls.Add(this.btnF12, 9, 0);
            this.pnlLD.Controls.Add(this.btnF11, 8, 0);
            this.pnlLD.Controls.Add(this.btnF9, 7, 0);
            this.pnlLD.Controls.Add(this.btnF8, 6, 0);
            this.pnlLD.Controls.Add(this.btnF7, 5, 0);
            this.pnlLD.Controls.Add(this.btnF6, 4, 0);
            this.pnlLD.Controls.Add(this.btnF5, 3, 0);
            this.pnlLD.Controls.Add(this.btnF4, 2, 0);
            this.pnlLD.Controls.Add(this.btnF3, 1, 0);
            this.pnlLD.Controls.Add(this.btnSPC, 0, 0);
            this.pnlLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLD.Location = new System.Drawing.Point(10, 56);
            this.pnlLD.Name = "pnlLD";
            this.pnlLD.RowCount = 1;
            this.pnlLD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.pnlLD.Size = new System.Drawing.Size(1004, 61);
            this.pnlLD.TabIndex = 3;
            // 
            // btnF12
            // 
            this.btnF12.BackgroundDraw = true;
            this.btnF12.ButtonColor = null;
            this.btnF12.Clickable = true;
            this.btnF12.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF12.Gradient = false;
            this.btnF12.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF12.IconGap = 3;
            this.btnF12.IconImage = global::ArduinoLadder.Properties.Resources.F12;
            this.btnF12.IconSize = 12F;
            this.btnF12.IconString = null;
            this.btnF12.Location = new System.Drawing.Point(903, 3);
            this.btnF12.Name = "btnF12";
            this.btnF12.Round = null;
            this.btnF12.ShadowGap = 1;
            this.btnF12.Size = new System.Drawing.Size(98, 55);
            this.btnF12.TabIndex = 9;
            this.btnF12.Text = "F12";
            this.btnF12.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF12.UseKey = false;
            // 
            // btnF11
            // 
            this.btnF11.BackgroundDraw = true;
            this.btnF11.ButtonColor = null;
            this.btnF11.Clickable = true;
            this.btnF11.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF11.Gradient = false;
            this.btnF11.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF11.IconGap = 3;
            this.btnF11.IconImage = global::ArduinoLadder.Properties.Resources.F11;
            this.btnF11.IconSize = 12F;
            this.btnF11.IconString = null;
            this.btnF11.Location = new System.Drawing.Point(803, 3);
            this.btnF11.Name = "btnF11";
            this.btnF11.Round = null;
            this.btnF11.ShadowGap = 1;
            this.btnF11.Size = new System.Drawing.Size(94, 55);
            this.btnF11.TabIndex = 8;
            this.btnF11.Text = "F11";
            this.btnF11.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF11.UseKey = false;
            // 
            // btnF9
            // 
            this.btnF9.BackgroundDraw = true;
            this.btnF9.ButtonColor = null;
            this.btnF9.Clickable = true;
            this.btnF9.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF9.Gradient = false;
            this.btnF9.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF9.IconGap = 3;
            this.btnF9.IconImage = global::ArduinoLadder.Properties.Resources.F9;
            this.btnF9.IconSize = 12F;
            this.btnF9.IconString = null;
            this.btnF9.Location = new System.Drawing.Point(703, 3);
            this.btnF9.Name = "btnF9";
            this.btnF9.Round = null;
            this.btnF9.ShadowGap = 1;
            this.btnF9.Size = new System.Drawing.Size(94, 55);
            this.btnF9.TabIndex = 7;
            this.btnF9.Text = "F9";
            this.btnF9.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF9.UseKey = false;
            // 
            // btnF8
            // 
            this.btnF8.BackgroundDraw = true;
            this.btnF8.ButtonColor = null;
            this.btnF8.Clickable = true;
            this.btnF8.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF8.Gradient = false;
            this.btnF8.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF8.IconGap = 3;
            this.btnF8.IconImage = global::ArduinoLadder.Properties.Resources.F8;
            this.btnF8.IconSize = 12F;
            this.btnF8.IconString = null;
            this.btnF8.Location = new System.Drawing.Point(603, 3);
            this.btnF8.Name = "btnF8";
            this.btnF8.Round = null;
            this.btnF8.ShadowGap = 1;
            this.btnF8.Size = new System.Drawing.Size(94, 55);
            this.btnF8.TabIndex = 6;
            this.btnF8.Text = "F8";
            this.btnF8.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF8.UseKey = false;
            // 
            // btnF7
            // 
            this.btnF7.BackgroundDraw = true;
            this.btnF7.ButtonColor = null;
            this.btnF7.Clickable = true;
            this.btnF7.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF7.Gradient = false;
            this.btnF7.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF7.IconGap = 3;
            this.btnF7.IconImage = global::ArduinoLadder.Properties.Resources.F7;
            this.btnF7.IconSize = 12F;
            this.btnF7.IconString = null;
            this.btnF7.Location = new System.Drawing.Point(503, 3);
            this.btnF7.Name = "btnF7";
            this.btnF7.Round = null;
            this.btnF7.ShadowGap = 1;
            this.btnF7.Size = new System.Drawing.Size(94, 55);
            this.btnF7.TabIndex = 5;
            this.btnF7.Text = "F7";
            this.btnF7.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF7.UseKey = false;
            // 
            // btnF6
            // 
            this.btnF6.BackgroundDraw = true;
            this.btnF6.ButtonColor = null;
            this.btnF6.Clickable = true;
            this.btnF6.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF6.Gradient = false;
            this.btnF6.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF6.IconGap = 3;
            this.btnF6.IconImage = global::ArduinoLadder.Properties.Resources.F6;
            this.btnF6.IconSize = 12F;
            this.btnF6.IconString = null;
            this.btnF6.Location = new System.Drawing.Point(403, 3);
            this.btnF6.Name = "btnF6";
            this.btnF6.Round = null;
            this.btnF6.ShadowGap = 1;
            this.btnF6.Size = new System.Drawing.Size(94, 55);
            this.btnF6.TabIndex = 4;
            this.btnF6.Text = "F6";
            this.btnF6.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF6.UseKey = false;
            // 
            // btnF5
            // 
            this.btnF5.BackgroundDraw = true;
            this.btnF5.ButtonColor = null;
            this.btnF5.Clickable = true;
            this.btnF5.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF5.Gradient = false;
            this.btnF5.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF5.IconGap = 3;
            this.btnF5.IconImage = global::ArduinoLadder.Properties.Resources.F5;
            this.btnF5.IconSize = 12F;
            this.btnF5.IconString = null;
            this.btnF5.Location = new System.Drawing.Point(303, 3);
            this.btnF5.Name = "btnF5";
            this.btnF5.Round = null;
            this.btnF5.ShadowGap = 1;
            this.btnF5.Size = new System.Drawing.Size(94, 55);
            this.btnF5.TabIndex = 3;
            this.btnF5.Text = "F5";
            this.btnF5.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF5.UseKey = false;
            // 
            // btnF4
            // 
            this.btnF4.BackgroundDraw = true;
            this.btnF4.ButtonColor = null;
            this.btnF4.Clickable = true;
            this.btnF4.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF4.Gradient = false;
            this.btnF4.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF4.IconGap = 3;
            this.btnF4.IconImage = global::ArduinoLadder.Properties.Resources.F4;
            this.btnF4.IconSize = 12F;
            this.btnF4.IconString = null;
            this.btnF4.Location = new System.Drawing.Point(203, 3);
            this.btnF4.Name = "btnF4";
            this.btnF4.Round = null;
            this.btnF4.ShadowGap = 1;
            this.btnF4.Size = new System.Drawing.Size(94, 55);
            this.btnF4.TabIndex = 2;
            this.btnF4.Text = "F4";
            this.btnF4.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF4.UseKey = false;
            // 
            // btnF3
            // 
            this.btnF3.BackgroundDraw = true;
            this.btnF3.ButtonColor = null;
            this.btnF3.Clickable = true;
            this.btnF3.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnF3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnF3.Gradient = false;
            this.btnF3.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnF3.IconGap = 3;
            this.btnF3.IconImage = global::ArduinoLadder.Properties.Resources.F3;
            this.btnF3.IconSize = 12F;
            this.btnF3.IconString = null;
            this.btnF3.Location = new System.Drawing.Point(103, 3);
            this.btnF3.Name = "btnF3";
            this.btnF3.Round = null;
            this.btnF3.ShadowGap = 1;
            this.btnF3.Size = new System.Drawing.Size(94, 55);
            this.btnF3.TabIndex = 1;
            this.btnF3.Text = "F3";
            this.btnF3.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnF3.UseKey = false;
            // 
            // btnSPC
            // 
            this.btnSPC.BackgroundDraw = true;
            this.btnSPC.ButtonColor = null;
            this.btnSPC.Clickable = true;
            this.btnSPC.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnSPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSPC.Gradient = false;
            this.btnSPC.IconAlignment = Devinno.Forms.DvTextIconAlignment.TopBottom;
            this.btnSPC.IconGap = 3;
            this.btnSPC.IconImage = global::ArduinoLadder.Properties.Resources.SPACE;
            this.btnSPC.IconSize = 12F;
            this.btnSPC.IconString = null;
            this.btnSPC.Location = new System.Drawing.Point(3, 3);
            this.btnSPC.Name = "btnSPC";
            this.btnSPC.Round = null;
            this.btnSPC.ShadowGap = 1;
            this.btnSPC.Size = new System.Drawing.Size(94, 55);
            this.btnSPC.TabIndex = 0;
            this.btnSPC.Text = "SPACE";
            this.btnSPC.TextPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnSPC.UseKey = false;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlToolBar.ColumnCount = 17;
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.pnlToolBar.Controls.Add(this.btnNewFile, 0, 0);
            this.pnlToolBar.Controls.Add(this.btnOpenFile, 1, 0);
            this.pnlToolBar.Controls.Add(this.btnSaveFile, 2, 0);
            this.pnlToolBar.Controls.Add(this.btnSaveAsFile, 3, 0);
            this.pnlToolBar.Controls.Add(this.btnCheck, 5, 0);
            this.pnlToolBar.Controls.Add(this.btnHardware, 7, 0);
            this.pnlToolBar.Controls.Add(this.btnSymbol, 8, 0);
            this.pnlToolBar.Controls.Add(this.btnCommunication, 9, 0);
            this.pnlToolBar.Controls.Add(this.lblSketchPath, 13, 0);
            this.pnlToolBar.Controls.Add(this.btnExport, 16, 0);
            this.pnlToolBar.Controls.Add(this.btnDefaultCode, 11, 0);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(10, 10);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.RowCount = 1;
            this.pnlToolBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlToolBar.Size = new System.Drawing.Size(1004, 46);
            this.pnlToolBar.TabIndex = 2;
            // 
            // btnNewFile
            // 
            this.btnNewFile.BackgroundDraw = true;
            this.btnNewFile.ButtonColor = null;
            this.btnNewFile.Clickable = true;
            this.btnNewFile.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnNewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewFile.Gradient = true;
            this.btnNewFile.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnNewFile.IconGap = 0;
            this.btnNewFile.IconImage = null;
            this.btnNewFile.IconSize = 12F;
            this.btnNewFile.IconString = "fa-file";
            this.btnNewFile.Location = new System.Drawing.Point(3, 3);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Round = null;
            this.btnNewFile.ShadowGap = 1;
            this.btnNewFile.Size = new System.Drawing.Size(39, 40);
            this.btnNewFile.TabIndex = 1;
            this.btnNewFile.Text = null;
            this.btnNewFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnNewFile, "새 파일");
            this.btnNewFile.UseKey = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackgroundDraw = true;
            this.btnOpenFile.ButtonColor = null;
            this.btnOpenFile.Clickable = true;
            this.btnOpenFile.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenFile.Gradient = true;
            this.btnOpenFile.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnOpenFile.IconGap = 0;
            this.btnOpenFile.IconImage = null;
            this.btnOpenFile.IconSize = 12F;
            this.btnOpenFile.IconString = "fa-folder-open";
            this.btnOpenFile.Location = new System.Drawing.Point(48, 3);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Round = null;
            this.btnOpenFile.ShadowGap = 1;
            this.btnOpenFile.Size = new System.Drawing.Size(39, 40);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = null;
            this.btnOpenFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnOpenFile, "열기");
            this.btnOpenFile.UseKey = false;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.BackgroundDraw = true;
            this.btnSaveFile.ButtonColor = null;
            this.btnSaveFile.Clickable = true;
            this.btnSaveFile.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnSaveFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveFile.Gradient = true;
            this.btnSaveFile.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnSaveFile.IconGap = 0;
            this.btnSaveFile.IconImage = null;
            this.btnSaveFile.IconSize = 12F;
            this.btnSaveFile.IconString = "fa-floppy-disk";
            this.btnSaveFile.Location = new System.Drawing.Point(93, 3);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Round = null;
            this.btnSaveFile.ShadowGap = 1;
            this.btnSaveFile.Size = new System.Drawing.Size(39, 40);
            this.btnSaveFile.TabIndex = 3;
            this.btnSaveFile.Text = null;
            this.btnSaveFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnSaveFile, "저장");
            this.btnSaveFile.UseKey = false;
            // 
            // btnSaveAsFile
            // 
            this.btnSaveAsFile.BackgroundDraw = true;
            this.btnSaveAsFile.ButtonColor = null;
            this.btnSaveAsFile.Clickable = true;
            this.btnSaveAsFile.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnSaveAsFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAsFile.Gradient = true;
            this.btnSaveAsFile.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnSaveAsFile.IconGap = 0;
            this.btnSaveAsFile.IconImage = null;
            this.btnSaveAsFile.IconSize = 12F;
            this.btnSaveAsFile.IconString = "fa-floppy-disk";
            this.btnSaveAsFile.Location = new System.Drawing.Point(138, 3);
            this.btnSaveAsFile.Name = "btnSaveAsFile";
            this.btnSaveAsFile.Round = null;
            this.btnSaveAsFile.ShadowGap = 1;
            this.btnSaveAsFile.Size = new System.Drawing.Size(39, 40);
            this.btnSaveAsFile.TabIndex = 4;
            this.btnSaveAsFile.Text = null;
            this.btnSaveAsFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnSaveAsFile, "다른 이름으로 저장");
            this.btnSaveAsFile.UseKey = false;
            // 
            // btnCheck
            // 
            this.btnCheck.BackgroundDraw = true;
            this.btnCheck.ButtonColor = null;
            this.btnCheck.Clickable = true;
            this.btnCheck.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheck.Gradient = true;
            this.btnCheck.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnCheck.IconGap = 0;
            this.btnCheck.IconImage = null;
            this.btnCheck.IconSize = 12F;
            this.btnCheck.IconString = "fa-check";
            this.btnCheck.Location = new System.Drawing.Point(193, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Round = null;
            this.btnCheck.ShadowGap = 1;
            this.btnCheck.Size = new System.Drawing.Size(39, 40);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = null;
            this.btnCheck.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnCheck, "유효성 체크");
            this.btnCheck.UseKey = false;
            // 
            // btnHardware
            // 
            this.btnHardware.BackgroundDraw = true;
            this.btnHardware.ButtonColor = null;
            this.btnHardware.Clickable = true;
            this.btnHardware.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHardware.Gradient = true;
            this.btnHardware.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnHardware.IconGap = 0;
            this.btnHardware.IconImage = null;
            this.btnHardware.IconSize = 12F;
            this.btnHardware.IconString = "fa-memory";
            this.btnHardware.Location = new System.Drawing.Point(248, 3);
            this.btnHardware.Name = "btnHardware";
            this.btnHardware.Round = null;
            this.btnHardware.ShadowGap = 1;
            this.btnHardware.Size = new System.Drawing.Size(39, 40);
            this.btnHardware.TabIndex = 8;
            this.btnHardware.Text = null;
            this.btnHardware.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnHardware, "하드웨어");
            this.btnHardware.UseKey = false;
            // 
            // btnSymbol
            // 
            this.btnSymbol.BackgroundDraw = true;
            this.btnSymbol.ButtonColor = null;
            this.btnSymbol.Clickable = true;
            this.btnSymbol.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSymbol.Gradient = true;
            this.btnSymbol.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnSymbol.IconGap = 0;
            this.btnSymbol.IconImage = null;
            this.btnSymbol.IconSize = 12F;
            this.btnSymbol.IconString = "fa-tags";
            this.btnSymbol.Location = new System.Drawing.Point(293, 3);
            this.btnSymbol.Name = "btnSymbol";
            this.btnSymbol.Round = null;
            this.btnSymbol.ShadowGap = 1;
            this.btnSymbol.Size = new System.Drawing.Size(39, 40);
            this.btnSymbol.TabIndex = 9;
            this.btnSymbol.Text = null;
            this.btnSymbol.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnSymbol, "심볼");
            this.btnSymbol.UseKey = false;
            // 
            // btnCommunication
            // 
            this.btnCommunication.BackgroundDraw = true;
            this.btnCommunication.ButtonColor = null;
            this.btnCommunication.Clickable = true;
            this.btnCommunication.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnCommunication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCommunication.Gradient = true;
            this.btnCommunication.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnCommunication.IconGap = 0;
            this.btnCommunication.IconImage = null;
            this.btnCommunication.IconSize = 12F;
            this.btnCommunication.IconString = "fa-wifi";
            this.btnCommunication.Location = new System.Drawing.Point(338, 3);
            this.btnCommunication.Name = "btnCommunication";
            this.btnCommunication.Round = null;
            this.btnCommunication.ShadowGap = 1;
            this.btnCommunication.Size = new System.Drawing.Size(39, 40);
            this.btnCommunication.TabIndex = 10;
            this.btnCommunication.Text = null;
            this.btnCommunication.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnCommunication, "통신");
            this.btnCommunication.UseKey = false;
            // 
            // lblSketchPath
            // 
            this.lblSketchPath.Button = "";
            this.lblSketchPath.ButtonColor = null;
            this.lblSketchPath.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblSketchPath.ButtonIconGap = 0;
            this.lblSketchPath.ButtonIconImage = null;
            this.lblSketchPath.ButtonIconSize = 12F;
            this.lblSketchPath.ButtonIconString = "fa-ellipsis";
            this.lblSketchPath.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.lblSketchPath.ButtonWidth = 40;
            this.pnlToolBar.SetColumnSpan(this.lblSketchPath, 3);
            this.lblSketchPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSketchPath.Location = new System.Drawing.Point(572, 3);
            this.lblSketchPath.Name = "lblSketchPath";
            this.lblSketchPath.Round = null;
            this.lblSketchPath.ShadowGap = 1;
            this.lblSketchPath.Size = new System.Drawing.Size(384, 40);
            this.lblSketchPath.TabIndex = 11;
            this.lblSketchPath.Text = "스케치 경로";
            this.lblSketchPath.Title = "스케치 경로";
            this.lblSketchPath.TitleColor = null;
            this.lblSketchPath.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblSketchPath.TitleIconGap = 0;
            this.lblSketchPath.TitleIconImage = null;
            this.lblSketchPath.TitleIconSize = 12F;
            this.lblSketchPath.TitleIconString = null;
            this.lblSketchPath.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.lblSketchPath.TitleWidth = 90;
            this.lblSketchPath.Unit = "";
            this.lblSketchPath.UnitWidth = null;
            this.lblSketchPath.Value = "";
            this.lblSketchPath.ValueColor = null;
            // 
            // btnExport
            // 
            this.btnExport.BackgroundDraw = true;
            this.btnExport.ButtonColor = null;
            this.btnExport.Clickable = true;
            this.btnExport.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Gradient = true;
            this.btnExport.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnExport.IconGap = 0;
            this.btnExport.IconImage = null;
            this.btnExport.IconSize = 12F;
            this.btnExport.IconString = "fa-file-export";
            this.btnExport.Location = new System.Drawing.Point(962, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Round = null;
            this.btnExport.ShadowGap = 1;
            this.btnExport.Size = new System.Drawing.Size(39, 40);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = null;
            this.btnExport.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnExport, "배포");
            this.btnExport.UseKey = false;
            // 
            // btnDefaultCode
            // 
            this.btnDefaultCode.BackgroundDraw = true;
            this.btnDefaultCode.ButtonColor = null;
            this.btnDefaultCode.Clickable = true;
            this.btnDefaultCode.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnDefaultCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDefaultCode.Gradient = true;
            this.btnDefaultCode.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnDefaultCode.IconGap = 0;
            this.btnDefaultCode.IconImage = null;
            this.btnDefaultCode.IconSize = 12F;
            this.btnDefaultCode.IconString = "fa-code";
            this.btnDefaultCode.Location = new System.Drawing.Point(393, 3);
            this.btnDefaultCode.Name = "btnDefaultCode";
            this.btnDefaultCode.Round = null;
            this.btnDefaultCode.ShadowGap = 1;
            this.btnDefaultCode.Size = new System.Drawing.Size(39, 40);
            this.btnDefaultCode.TabIndex = 13;
            this.btnDefaultCode.Text = null;
            this.btnDefaultCode.TextPadding = new System.Windows.Forms.Padding(0);
            this.toolTip.SetToolTip(this.btnDefaultCode, "메인 코드");
            this.btnDefaultCode.UseKey = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlStatus.Controls.Add(this.lblDebugPort);
            this.pnlStatus.Controls.Add(this.dvControl3);
            this.pnlStatus.Controls.Add(this.btnDTR);
            this.pnlStatus.Controls.Add(this.lblCursorPosition);
            this.pnlStatus.Controls.Add(this.dvControl2);
            this.pnlStatus.Controls.Add(this.btnSetting);
            this.pnlStatus.Controls.Add(this.dvControl1);
            this.pnlStatus.Controls.Add(this.btnMonitoring);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 708);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(10);
            this.pnlStatus.ShadowGap = 1;
            this.pnlStatus.Size = new System.Drawing.Size(1024, 60);
            this.pnlStatus.TabIndex = 6;
            this.pnlStatus.TabStop = false;
            this.pnlStatus.Text = "dvContainer1";
            // 
            // lblDebugPort
            // 
            this.lblDebugPort.Button = "";
            this.lblDebugPort.ButtonColor = null;
            this.lblDebugPort.ButtonIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblDebugPort.ButtonIconGap = 0;
            this.lblDebugPort.ButtonIconImage = null;
            this.lblDebugPort.ButtonIconSize = 12F;
            this.lblDebugPort.ButtonIconString = "fa-ellipsis";
            this.lblDebugPort.ButtonTextPadding = new System.Windows.Forms.Padding(0);
            this.lblDebugPort.ButtonWidth = 40;
            this.lblDebugPort.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDebugPort.Location = new System.Drawing.Point(615, 10);
            this.lblDebugPort.Name = "lblDebugPort";
            this.lblDebugPort.Round = null;
            this.lblDebugPort.ShadowGap = 1;
            this.lblDebugPort.Size = new System.Drawing.Size(297, 40);
            this.lblDebugPort.TabIndex = 17;
            this.lblDebugPort.Text = "디버그 포트";
            this.lblDebugPort.Title = "디버그 포트";
            this.lblDebugPort.TitleColor = null;
            this.lblDebugPort.TitleIconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblDebugPort.TitleIconGap = 0;
            this.lblDebugPort.TitleIconImage = null;
            this.lblDebugPort.TitleIconSize = 12F;
            this.lblDebugPort.TitleIconString = null;
            this.lblDebugPort.TitleTextPadding = new System.Windows.Forms.Padding(0);
            this.lblDebugPort.TitleWidth = 80;
            this.lblDebugPort.Unit = "";
            this.lblDebugPort.UnitWidth = null;
            this.lblDebugPort.Value = "";
            this.lblDebugPort.ValueColor = null;
            // 
            // dvControl3
            // 
            this.dvControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl3.Location = new System.Drawing.Point(912, 10);
            this.dvControl3.Name = "dvControl3";
            this.dvControl3.ShadowGap = 1;
            this.dvControl3.Size = new System.Drawing.Size(6, 40);
            this.dvControl3.TabIndex = 21;
            this.dvControl3.TabStop = false;
            this.dvControl3.Text = "dvControl3";
            // 
            // btnDTR
            // 
            this.btnDTR.BackgroundDraw = true;
            this.btnDTR.ButtonColor = null;
            this.btnDTR.Clickable = true;
            this.btnDTR.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnDTR.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDTR.Gradient = true;
            this.btnDTR.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnDTR.IconGap = 0;
            this.btnDTR.IconImage = null;
            this.btnDTR.IconSize = 12F;
            this.btnDTR.IconString = null;
            this.btnDTR.Location = new System.Drawing.Point(918, 10);
            this.btnDTR.Name = "btnDTR";
            this.btnDTR.Round = null;
            this.btnDTR.ShadowGap = 1;
            this.btnDTR.Size = new System.Drawing.Size(45, 40);
            this.btnDTR.TabIndex = 22;
            this.btnDTR.Text = "DTR";
            this.btnDTR.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDTR.UseKey = false;
            // 
            // lblCursorPosition
            // 
            this.lblCursorPosition.BackgroundDraw = true;
            this.lblCursorPosition.BorderColor = null;
            this.lblCursorPosition.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.lblCursorPosition.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCursorPosition.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.lblCursorPosition.IconGap = 0;
            this.lblCursorPosition.IconImage = null;
            this.lblCursorPosition.IconSize = 12F;
            this.lblCursorPosition.IconString = null;
            this.lblCursorPosition.LabelColor = null;
            this.lblCursorPosition.Location = new System.Drawing.Point(55, 10);
            this.lblCursorPosition.Name = "lblCursorPosition";
            this.lblCursorPosition.Round = null;
            this.lblCursorPosition.ShadowGap = 1;
            this.lblCursorPosition.Size = new System.Drawing.Size(180, 40);
            this.lblCursorPosition.Style = Devinno.Forms.Embossing.Convex;
            this.lblCursorPosition.TabIndex = 0;
            this.lblCursorPosition.TabStop = false;
            this.lblCursorPosition.Text = null;
            this.lblCursorPosition.TextPadding = new System.Windows.Forms.Padding(0);
            this.lblCursorPosition.Unit = "";
            this.lblCursorPosition.UnitWidth = null;
            // 
            // dvControl2
            // 
            this.dvControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dvControl2.Location = new System.Drawing.Point(50, 10);
            this.dvControl2.Name = "dvControl2";
            this.dvControl2.ShadowGap = 1;
            this.dvControl2.Size = new System.Drawing.Size(5, 40);
            this.dvControl2.TabIndex = 19;
            this.dvControl2.TabStop = false;
            this.dvControl2.Text = "dvControl2";
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundDraw = true;
            this.btnSetting.ButtonColor = null;
            this.btnSetting.Clickable = true;
            this.btnSetting.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetting.Gradient = true;
            this.btnSetting.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnSetting.IconGap = 0;
            this.btnSetting.IconImage = null;
            this.btnSetting.IconSize = 12F;
            this.btnSetting.IconString = "fa-gear";
            this.btnSetting.Location = new System.Drawing.Point(10, 10);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Round = null;
            this.btnSetting.ShadowGap = 1;
            this.btnSetting.Size = new System.Drawing.Size(40, 40);
            this.btnSetting.TabIndex = 18;
            this.btnSetting.Text = null;
            this.btnSetting.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSetting.UseKey = false;
            // 
            // dvControl1
            // 
            this.dvControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvControl1.Location = new System.Drawing.Point(963, 10);
            this.dvControl1.Name = "dvControl1";
            this.dvControl1.ShadowGap = 1;
            this.dvControl1.Size = new System.Drawing.Size(6, 40);
            this.dvControl1.TabIndex = 16;
            this.dvControl1.TabStop = false;
            this.dvControl1.Text = "dvControl1";
            // 
            // btnMonitoring
            // 
            this.btnMonitoring.BackgroundDraw = true;
            this.btnMonitoring.ButtonColor = null;
            this.btnMonitoring.Clickable = true;
            this.btnMonitoring.ContentAlignment = Devinno.Forms.DvContentAlignment.MiddleCenter;
            this.btnMonitoring.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMonitoring.Gradient = true;
            this.btnMonitoring.IconAlignment = Devinno.Forms.DvTextIconAlignment.LeftRight;
            this.btnMonitoring.IconGap = 0;
            this.btnMonitoring.IconImage = null;
            this.btnMonitoring.IconSize = 12F;
            this.btnMonitoring.IconString = "fa-tv";
            this.btnMonitoring.Location = new System.Drawing.Point(969, 10);
            this.btnMonitoring.Name = "btnMonitoring";
            this.btnMonitoring.Round = null;
            this.btnMonitoring.ShadowGap = 1;
            this.btnMonitoring.Size = new System.Drawing.Size(45, 40);
            this.btnMonitoring.TabIndex = 15;
            this.btnMonitoring.Text = null;
            this.btnMonitoring.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnMonitoring.UseKey = false;
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.splitter.ColumnCount = 1;
            this.splitter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.splitter.Controls.Add(this.pnlMessage, 0, 1);
            this.splitter.Controls.Add(this.pnlContent, 0, 0);
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.DrawSplitter = false;
            this.splitter.Location = new System.Drawing.Point(0, 127);
            this.splitter.Name = "splitter";
            this.splitter.RowCount = 2;
            this.splitter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.88608F));
            this.splitter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.11392F));
            this.splitter.Size = new System.Drawing.Size(1024, 581);
            this.splitter.SplitterColor = null;
            this.splitter.TabIndex = 7;
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pnlMessage.Controls.Add(this.gridMessage);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 412);
            this.pnlMessage.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.pnlMessage.ShadowGap = 1;
            this.pnlMessage.Size = new System.Drawing.Size(1024, 169);
            this.pnlMessage.TabIndex = 0;
            this.pnlMessage.TabStop = false;
            this.pnlMessage.Text = "dvContainer1";
            // 
            // gridMessage
            // 
            this.gridMessage.Bevel = true;
            this.gridMessage.BoxColor = null;
            this.gridMessage.ColumnColor = null;
            this.gridMessage.ColumnHeight = 30;
            this.gridMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMessage.HScrollPosition = 0D;
            this.gridMessage.InputColor = null;
            this.gridMessage.Location = new System.Drawing.Point(10, 10);
            this.gridMessage.Name = "gridMessage";
            this.gridMessage.RowColor = null;
            this.gridMessage.RowHeight = 30;
            this.gridMessage.ScrollMode = Devinno.Forms.Utils.ScrollMode.Vertical;
            this.gridMessage.SelectedRowColor = null;
            this.gridMessage.SelectionMode = Devinno.Forms.Controls.DvDataGridSelectionMode.Single;
            this.gridMessage.ShadowGap = 1;
            this.gridMessage.Size = new System.Drawing.Size(1004, 159);
            this.gridMessage.SummaryRowColor = null;
            this.gridMessage.TabIndex = 0;
            this.gridMessage.Text = "dvDataGrid1";
            this.gridMessage.VScrollPosition = 0D;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlContent.Controls.Add(this.ladder);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContent.ShadowGap = 1;
            this.pnlContent.Size = new System.Drawing.Size(1024, 410);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.TabStop = false;
            this.pnlContent.Text = "dvContainer2";
            // 
            // ladder
            // 
            this.ladder.AllowDrop = true;
            this.ladder.BoxColor = null;
            this.ladder.ColumnCount = 16;
            this.ladder.ContextMenuStrip = this.cmsDis;
            this.ladder.CurX = 0;
            this.ladder.CurY = 0;
            this.ladder.Debug = false;
            this.ladder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ladder.Font = new System.Drawing.Font("나눔고딕", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ladder.LadderDisplayType = ArduinoLadder.Controls.LadderDisplayKinds.DEC;
            this.ladder.Location = new System.Drawing.Point(10, 10);
            this.ladder.Name = "ladder";
            this.ladder.NumberBoxColor = null;
            this.ladder.NumberBoxWidth = 100;
            this.ladder.RowCount = 50;
            this.ladder.RowHeight = 60;
            this.ladder.ScrollPosition = 0D;
            this.ladder.ShadowGap = 1;
            this.ladder.Size = new System.Drawing.Size(1004, 390);
            this.ladder.TabIndex = 0;
            this.ladder.Text = "ladderEditorControl1";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            this.toolTip.AutoPopDelay = 2000;
            this.toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.toolTip.ForeColor = System.Drawing.Color.White;
            this.toolTip.InitialDelay = 100;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ReshowDelay = 40;
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            // 
            // cmsDis
            // 
            this.cmsDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cmsDis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDEC,
            this.tsmiHEX,
            this.tsmiBIN});
            this.cmsDis.Name = "cmsDis";
            this.cmsDis.Size = new System.Drawing.Size(126, 70);
            // 
            // tsmiDEC
            // 
            this.tsmiDEC.Name = "tsmiDEC";
            this.tsmiDEC.Size = new System.Drawing.Size(125, 22);
            this.tsmiDEC.Text = "DEC 표시";
            // 
            // tsmiHEX
            // 
            this.tsmiHEX.Name = "tsmiHEX";
            this.tsmiHEX.Size = new System.Drawing.Size(125, 22);
            this.tsmiHEX.Text = "HEX 표시";
            // 
            // tsmiBIN
            // 
            this.tsmiBIN.Name = "tsmiBIN";
            this.tsmiBIN.Size = new System.Drawing.Size(125, 22);
            this.tsmiBIN.Text = "BIN 표시";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BlankForm = true;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlTop);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "Arduino Ladder";
            this.Title = "Arduino Ladder";
            this.TitleHeight = 0;
            this.TitleIconBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(99)))));
            this.TitleIconSize = 18F;
            this.TitleIconString = "fa-microchip";
            this.pnlTop.ResumeLayout(false);
            this.pnlLD.ResumeLayout(false);
            this.pnlToolBar.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.cmsDis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Devinno.Forms.Containers.DvContainer pnlTop;
        private Devinno.Forms.Containers.DvTableLayoutPanel pnlLD;
        private Devinno.Forms.Controls.DvButton btnF12;
        private Devinno.Forms.Controls.DvButton btnF11;
        private Devinno.Forms.Controls.DvButton btnF9;
        private Devinno.Forms.Controls.DvButton btnF8;
        private Devinno.Forms.Controls.DvButton btnF7;
        private Devinno.Forms.Controls.DvButton btnF6;
        private Devinno.Forms.Controls.DvButton btnF5;
        private Devinno.Forms.Controls.DvButton btnF4;
        private Devinno.Forms.Controls.DvButton btnF3;
        private Devinno.Forms.Controls.DvButton btnSPC;
        private Devinno.Forms.Containers.DvTableLayoutPanel pnlToolBar;
        private Devinno.Forms.Controls.DvButton btnNewFile;
        private Devinno.Forms.Controls.DvButton btnOpenFile;
        private Devinno.Forms.Controls.DvButton btnSaveFile;
        private Devinno.Forms.Controls.DvButton btnSaveAsFile;
        private Devinno.Forms.Controls.DvButton btnCheck;
        private Devinno.Forms.Controls.DvButton btnHardware;
        private Devinno.Forms.Controls.DvButton btnSymbol;
        private Devinno.Forms.Controls.DvButton btnCommunication;
        private ArduinoLadder.Controls.DvValueLabelPath lblSketchPath;
        private Devinno.Forms.Containers.DvContainer pnlStatus;
        private Devinno.Forms.Controls.DvLabel lblCursorPosition;
        private Devinno.Forms.Containers.DvSplitterTableLayoutPanel splitter;
        private Devinno.Forms.Containers.DvContainer pnlMessage;
        private Devinno.Forms.Controls.DvDataGrid gridMessage;
        private Devinno.Forms.Containers.DvContainer pnlContent;
        private Controls.LadderEditorControl ladder;
        private System.Windows.Forms.ToolTip toolTip;
        private Devinno.Forms.Controls.DvButton btnMonitoring;
        private Devinno.Forms.Controls.DvValueLabelText lblDebugPort;
        private Devinno.Forms.Controls.DvControl dvControl1;
        private Devinno.Forms.Controls.DvControl dvControl2;
        private Devinno.Forms.Controls.DvButton btnSetting;
        private Devinno.Forms.Controls.DvButton btnExport;
        private Devinno.Forms.Controls.DvButton btnDefaultCode;
        private Devinno.Forms.Controls.DvControl dvControl3;
        private Devinno.Forms.Controls.DvButton btnDTR;
        private Devinno.Forms.Menus.DvContextMenuStrip cmsDis;
        private System.Windows.Forms.ToolStripMenuItem tsmiDEC;
        private System.Windows.Forms.ToolStripMenuItem tsmiHEX;
        private System.Windows.Forms.ToolStripMenuItem tsmiBIN;
    }
}

