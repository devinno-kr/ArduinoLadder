using ArduinoLadder.Ladder;
using ArduinoLadder.Tools;
using Devinno.Communications.Setting;
using Devinno.Data;
using Devinno.Extensions;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Extensions;
using Devinno.Forms.Icons;
using Devinno.Forms.Themes;
using Devinno.Forms.Tools;
using Devinno.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM = ArduinoLadder.Tools.LangTool;

namespace ArduinoLadder.Forms
{
    public partial class FormMain : DvForm
    {
        #region Properties
        public LadderDocument CurrentDocument { get; private set; } = null;
        #endregion

        #region Member Variable
        FormSymbol frmSymbol;
        FormHardware frmHardware;
        FormSetting frmSetting;
        FormCommunication frmComm;
        FormDefault frmDefault;

        Timer tmr;
        bool bSaveFileDown = false;
        Size szold;
        #endregion

        #region Constructor
        public FormMain()
        {
            InitializeComponent();

            #region Forms
            frmSymbol = new FormSymbol();
            frmHardware = new FormHardware();
            frmSetting = new FormSetting();
            frmComm = new FormCommunication();
            frmDefault = new FormDefault();
            #endregion

            #region Grid
            gridMessage.SelectionMode = DvDataGridSelectionMode.Single;
            gridMessage.ColumnColor = Color.FromArgb(50, 50, 50);
            gridMessage.Columns.Add(new DvDataGridColumn(gridMessage) { Name = "Row", HeaderText = LM.Row, SizeMode = DvSizeMode.Pixel, Width = 70, CellType = typeof(DvDataGridLabelCell) });
            gridMessage.Columns.Add(new DvDataGridColumn(gridMessage) { Name = "Column", HeaderText = LM.Col, SizeMode = DvSizeMode.Pixel, Width = 70, CellType = typeof(DvDataGridLabelCell) });
            gridMessage.Columns.Add(new DvDataGridColumn(gridMessage) { Name = "Message", HeaderText = LM.Message, SizeMode = DvSizeMode.Percent, Width = 100, CellType = typeof(DvDataGridLabelCell) });
            #endregion

            #region Ladder Properties
            ladder.RowHeight = 36;
            ladder.ColumnCount = 14;
            #endregion

            #region Timer
            tmr = new Timer();
            tmr.Interval = 10;
            tmr.Tick += (o, s) => UISet();
            tmr.Enabled = true;
            #endregion

            #region Event
            #region btnSaveAsFile.ThemeDraw         : 아이콘 그리기
            btnSaveAsFile.MouseDown += (o, s) => bSaveFileDown = true;
            btnSaveAsFile.MouseUp += (o, s) => bSaveFileDown = false;
            btnSaveAsFile.ThemeDraw += (o, s) =>
            {
                using (var br = new SolidBrush(btnSaveAsFile.ButtonColor ?? Theme.ButtonColor))
                {
                    var n = bSaveFileDown ? 1 : 0;
                    int x = 20, y = 17, gp = 3;

                    br.Color = btnSaveAsFile.ButtonColor ?? Theme.ButtonColor;
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x - gp, y + n - gp, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x - 0, y + n - gp, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x - gp, y + n - 0, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);

                    br.Color = bSaveFileDown ? btnSaveAsFile.ForeColor.BrightnessTransmit(Theme.DownBrightness) : btnSaveAsFile.ForeColor;
                    s.Graphics.DrawIcon(new DvIcon("fa-asterisk") { IconSize = 7 }, br, new Rectangle(x, y + n, 10, 10), Devinno.Forms.DvContentAlignment.MiddleCenter);
                }
            };
            #endregion

            #region btn[F3/F4/F5...].ButtonClick    : 레더 버튼
            btnSPC.ButtonClick += (o, s) => ladder.ItemNONE();
            btnF3.ButtonClick += (o, s) => ladder.ItemIN_A();
            btnF4.ButtonClick += (o, s) => ladder.ItemIN_B();
            btnF5.ButtonClick += (o, s) => ladder.ItemLINE_H();
            btnF6.ButtonClick += (o, s) => ladder.ItemLINE_V();
            btnF7.ButtonClick += (o, s) => ladder.ItemOUT_COIL();
            btnF8.ButtonClick += (o, s) => ladder.ItemOUT_FUNC();
            btnF9.ButtonClick += (o, s) => ladder.ItemNOT();
            btnF11.ButtonClick += (o, s) => ladder.ItemRISING_EDGE();
            btnF12.ButtonClick += (o, s) => ladder.ItemFALLING_EDGE();
            #endregion

            #region btn[?]File.ButtonClick          : 새파일, 열기, 저장, 다른 이름으로 저장
            btnNewFile.ButtonClick += (o, s) => NewFile();
            btnSaveFile.ButtonClick += (o, s) => SaveFile();
            btnSaveAsFile.ButtonClick += (o, s) => SaveAsFile();
            btnOpenFile.ButtonClick += (o, s) => OpenFile();
            #endregion
            #region btnCheck.ButtonClick            : 유효성 체크
            btnCheck.ButtonClick += (o, s) =>
            {
                if (CurrentDocument != null)
                {
                    if (CurrentDocument.Edit) CurrentDocument.Save();

                    var ret = LadderTool.ValidCheck(CurrentDocument, true);
                    gridMessage.SetDataSource<LadderCheckMessage>(ret);
                    if (ret.Count == 0)
                        Message(LM.ValidationCheck, LM.ValidationOK);
                    else
                        Message(LM.ValidationCheck, LM.ValidationFail);
                }
            };
            #endregion
            #region btnHardware.ButtonClick         : 하드웨어
            btnHardware.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmHardware.ShowHardware(CurrentDocument);
                if (ret != null)
                {
                    CurrentDocument.Hardwares.Clear();
                    CurrentDocument.Hardwares.AddRange(ret.Hardwares);

                    CurrentDocument.Edit = true;
                }
                Block = false;
            };
            #endregion
            #region btnSymbol.ButtonClick           : 심볼
            btnSymbol.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmSymbol.ShowSymbol(CurrentDocument);
                if (ret != null)
                {
                    CurrentDocument.P_Count = ret.P_Count;
                    CurrentDocument.M_Count = ret.M_Count;
                    CurrentDocument.T_Count = ret.T_Count;
                    CurrentDocument.C_Count = ret.C_Count;
                    CurrentDocument.D_Count = ret.D_Count;
                    CurrentDocument.Symbols.Clear();
                    CurrentDocument.Symbols.AddRange(ret.Symbols);

                    CurrentDocument.Edit = true;
                }
                Block = false;
            };
            #endregion
            #region btnCommunication.ButtonClick    : 통신설정
            btnCommunication.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmComm.ShowCommunication(CurrentDocument);
                if (ret != null)
                {
                    CurrentDocument.Communications = CryptoTool.EncodeBase64String(Serialize.JsonSerializeWithType(ret));
                    CurrentDocument.Edit = true;
                }
                Block = false;
            };
            #endregion
            #region btnDefaultCode.ButtonClick      : 기본코드
            btnDefaultCode.ButtonClick += (o, s) =>
            {
                Block = true;
                frmDefault.ShowDefaultCode(CurrentDocument);
                Block = false;
            };
            #endregion
            #region lblSketchPath.ButtonClicked     : 스케치 경로 설정
            lblSketchPath.ButtonClicked += (o, s) =>
            {
                using (var fbd = new FolderBrowserDialog() { })
                {
                    if (CurrentDocument != null && !string.IsNullOrWhiteSpace(CurrentDocument.SketchPath))
                        fbd.SelectedPath = CurrentDocument.SketchPath;
                    else
                        fbd.SelectedPath = Program.DataMgr.ArduinoFolder;
                    
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        if (CurrentDocument != null)
                        {
                            CurrentDocument.SketchPath = fbd.SelectedPath;
                            CurrentDocument.Edit = true;
                        }
                    }
                }
            };
            #endregion
            #region btnExport.ButtonClick           : 배포
            btnExport.ButtonClick += (o, s) =>
            {
                if (CurrentDocument != null)
                {
                    if (CurrentDocument.Edit) CurrentDocument.Save();

                    var ret = LadderTool.ValidCheck(CurrentDocument, true);
                    gridMessage.SetDataSource<LadderCheckMessage>(ret);
                    if (ret.Count == 0)
                    {
                        if (Directory.Exists(CurrentDocument.SketchPath))
                        {
                            var dic = LadderTool.MakeCode(CurrentDocument);
                            foreach (var filename in dic.Keys)
                                File.WriteAllText(Path.Combine(CurrentDocument.SketchPath, filename), dic[filename]);
                        }

                        Message(LM.Deploy, LM.DeployComplete);
                    }
                    else
                        Message(LM.ValidationCheck, LM.ValidationFail);
                }
            };
            #endregion
            #region btnSetting.ButtonClick          : 설정
            btnSetting.ButtonClick += (o, s) =>
            {
                Block = true;
                var ret = frmSetting.ShowSetting();
                if (ret != null)
                {
                    Program.DataMgr.ProjectFolder = ret.ProjectFolder;
                    Program.DataMgr.ArduinoFolder = ret.ArduinoFolder;
                    Program.DataMgr.Language = ret.Language;
                    Program.DataMgr.SaveSetting();
                }
                Block = false;
            };
            #endregion
            #region lblDebugPort.ButtonClicked      : 디버그 포트 설정
            lblDebugPort.ButtonClicked += (o, s) =>
            {
                Block = true;

                var v = Program.DevMgr;
                var ret = Program.SerialBox.ShowSimpleSerialPortSetting(new SerialPortSetting { Port = v.PortName, Baudrate = v.Baudrate });
                if (ret != null)
                {
                    v.PortName = ret.Port;
                    v.Baudrate = ret.Baudrate;
                    v.Save();
                }

                Block = false;
            };
            #endregion
            #region btnMonitoring.ButtonClick       : 모니터링
            btnMonitoring.ButtonClick += (o, s) =>
            {
                if (Program.DevMgr.IsDebugging) Program.DevMgr.StopDebug();
                else Program.DevMgr.StartDebug(CurrentDocument);
            };
            #endregion

            #region ladder.LadderChanged            : 레더 변경
            ladder.LadderChanged += (o, s) => { if (CurrentDocument != null) CurrentDocument.Edit = true; };
            #endregion
            #region gridMessage.CellMouseClick      : 에러 클릭
            gridMessage.CellMouseClick += (o, s) =>
            {
                var sel = s.Cell.Row;
                if (sel != null && sel.Source is LadderCheckMessage)
                {
                    sel.Selected = true;
                    var v = sel.Source as LadderCheckMessage;
                    if (v.Column.HasValue && v.Row.HasValue)
                    {
                        if (ladder.DicRows.ContainsKey(v.Row.Value - 1))
                        {
                            var r = ladder.DicRows[v.Row.Value - 1];
                            while (r != null)
                            {
                                r.Expand = true;
                                r = ladder.DicRows[r.Row].Parent;
                            }
                            ladder.MakeRows();
                            var cy = ladder.Rows.IndexOf(ladder.DicRows[v.Row.Value - 1]);
                            ladder.CurY = cy ;
                            ladder.CurX = v.Column.Value - 1;
                        }
                    }
                }
            };
            #endregion
            #endregion

            #region ToolTip
            toolTip.Draw += (o, s) =>
            {
                using (var br = new SolidBrush(Color.Black))
                {
                    s.Graphics.Clear(Color.Black);
                    br.Color = Color.FromArgb(90, 90, 90);
                    s.Graphics.FillRectangle(br, new Rectangle(s.Bounds.X + 1, s.Bounds.Y + 1, s.Bounds.Width - 2, s.Bounds.Height - 2));

                    s.DrawText();
                }
            };
            #endregion

            #region Set
            ladder.Font = new Font("나눔고딕", 8);
            Theme.Animation = Theme.TouchMode = false;
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            SetExComposited();

            UISet();

            #region Language
            Program.DataMgr.LanguageChanged += (o, s) => ToolTipSet();
            #endregion

            if (Program.WindowBorder)
            {
                WindowTool.SetForm(this);
                WindowTool.SetForm(frmSymbol);
                WindowTool.SetForm(frmHardware);
                WindowTool.SetForm(frmComm);
                WindowTool.SetForm(frmComm.InputForm);
                WindowTool.SetFormFix(frmSetting);
                WindowTool.SetFormFix(frmDefault);
                WindowTool.SetFormFix(Program.InputBox);
                WindowTool.SetFormFix(Program.MessageBox);
                WindowTool.SetFormFix(Program.SerialBox);
                WindowTool.SetFormFix(ladder.MessageBox);
                WindowTool.SetForm(ladder.EditForm);
            }
        }
        #endregion

        #region Override
        #region OnThemeDraw
        protected override void OnThemeDraw(PaintEventArgs e, DvTheme Theme)
        {
            var hTOP = pnlTop.Height + Padding.Top;
            var hBTM = Padding.Bottom + pnlStatus.Height + pnlMessage.Height;
            var rt = Program.WindowBorder ? new Rectangle(0, hTOP, this.Width, this.Height - hTOP - hBTM - 40) :
                                            new Rectangle(-5, hTOP, this.Width + 10, this.Height - hTOP - hBTM);

            using (var br = new SolidBrush(pnlContent.BackColor))
            {
                e.Graphics.FillRectangle(br, rt);
            }

            using (var p = new Pen(pnlTop.BackColor))
            {
                e.Graphics.DrawLine(p, 0, pnlTop.Top - 1, this.Right, pnlTop.Top - 1);
            }
            base.OnThemeDraw(e, Theme);
        }
        #endregion
        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            ladder.Focus();
            ladder.Select();

            ToolTipSet();
            LangSet();
            base.OnLoad(e);
        }
        #endregion
        #region OnClosing
        protected override void OnClosing(CancelEventArgs e)
        {
            if (CurrentDocument != null && CurrentDocument.MustSave)
            {
                Block = true;
                 
                var ret = Program.MessageBox.ShowMessageBoxYesNo(LM.Save, LM.SaveQuestion);
                if (ret == DialogResult.Yes) SaveFile();
                else if (ret == DialogResult.Cancel) e.Cancel = true;

                Block = false;
            }
            base.OnClosing(e);
        }
        #endregion
        #region OnKeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
            ladder.Focus();
            base.OnKeyDown(e);
        }
        #endregion
        #endregion

        #region Method
        #region NewFile
        void NewFile()
        {
            bool bCancel = false;
            if (CurrentDocument != null && CurrentDocument.MustSave)
            {
                Block = true;

                if (Program.WindowBorder) WindowTool.Set(Program.MessageBox);
                switch (Program.MessageBox.ShowMessageBoxYesNoCancel(LM.Save, LM.SaveQuestion))
                {
                    case DialogResult.Yes: SaveFile(); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: bCancel = true; break;
                }
                Block = false;
            }

            if (!bCancel)
            {
                Block = true;

                if (Program.WindowBorder)
                {
                    WindowTool.Set(Program.InputBox);
                }

                Program.InputBox.UseEnterKey = true;
                var ret = Program.InputBox.ShowString(LM.NewFile);
                if (ret != null)
                {
                    CurrentDocument = new LadderDocument() {  };

                    ladder.Ladders = CurrentDocument.Ladders;
                    ladder.Select();
                    ladder.Invalidate();

                    UISet();
                }
                Program.InputBox.UseEnterKey = false;

                Block = false;
            }
        }
        #endregion
        #region OpenFile
        void OpenFile()
        {
            bool bCancel = false;
            if (CurrentDocument != null && CurrentDocument.MustSave)
            {
                Block = true;
                 
                switch (Program.MessageBox.ShowMessageBoxYesNoCancel(LM.Save, LM.SaveQuestion))
                {
                    case DialogResult.Yes: SaveFile(); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: bCancel = true; break;
                }

                Block = false;
            }

            if (!bCancel)
            {
                Block = true;
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = LM.Open;
                    ofd.InitialDirectory = Program.DataMgr.ProjectFolder;
                    ofd.Multiselect = false;
                    ofd.Filter = "Arduino Ladder File|*.dal";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        CurrentDocument = Serialize.JsonDeserializeWithTypeFromFile<LadderDocument>(ofd.FileName);
                        CurrentDocument.FileName = ofd.FileName;
                        ladder.Ladders = CurrentDocument.Ladders;
                        try
                        {
                            ladder.RowCount = Convert.ToInt32(Math.Ceiling(CurrentDocument.Ladders.Max(x => x.Row) / 10.0)) * 10;
                        }
                        catch { ladder.RowCount = 50; }
                        ladder.Invalidate();
                        ladder.Select();
                        UISet();
                    }
                }
                Block = false;
            }
        }
        #endregion
        #region SaveFile
        void SaveFile()
        {
            if (CurrentDocument != null)
            {
                if (!string.IsNullOrWhiteSpace(CurrentDocument.FileName) && File.Exists(CurrentDocument.FileName)) Block = true;

                try
                {
                    CurrentDocument.Save();
                }
                catch (UnauthorizedAccessException)
                {
                    Program.MessageBox.ShowMessageBoxOk(LM.Save, LM.SavePermissions);
                }

                if (Block) Block = false;
            }
        }
        #endregion
        #region SaveAsFile
        void SaveAsFile()
        {
            if (CurrentDocument != null)
            {
                Block = true;

                try
                {
                    CurrentDocument.SaveAs();
                }
                catch (UnauthorizedAccessException)
                {
                    Program.MessageBox.ShowMessageBoxOk(LM.Save, LM.SavePermissions);
                }

                Block = false;
            }
        }
        #endregion

        #region Message
        public void Message(string Title, string Message)
        {
            Block = true;
            Program.MessageBox.ShowMessageBoxOk(Title, Message);
            Block = false;
        }
        #endregion
        #region Debug
        public void Debug(List<DebugInfo> v) => ladder.SetDebug(v);
        #endregion

        #region ToolTipSet
        void ToolTipSet()
        {
            toolTip.SetToolTip(btnHardware, LM.Hardware);
            toolTip.SetToolTip(btnSymbol, LM.Symbol);
            toolTip.SetToolTip(btnSaveFile, LM.Save);
            toolTip.SetToolTip(btnSaveAsFile, LM.SaveAs);
            toolTip.SetToolTip(btnOpenFile, LM.Open);
            toolTip.SetToolTip(btnNewFile, LM.NewFile);
            toolTip.SetToolTip(btnMonitoring, LM.Monitoring);
            toolTip.SetToolTip(btnExport, LM.Deploy);
            toolTip.SetToolTip(btnDefaultCode, LM.MainCode);
            toolTip.SetToolTip(btnCommunication, LM.Communication);
            toolTip.SetToolTip(btnCheck, LM.ValidationCheck);
        }
        #endregion
        #region LangSet
        void LangSet()
        {
            lblCursorPosition.Text = CurrentDocument != null ? $"{LM.Col} : {(ladder.CurX + 1)}        {LM.Row} : {(ladder.CurRow + 1)}" : "";
            Title = LM.AppTitle + (CurrentDocument != null ? "  :  " + CurrentDocument.DisplayTitle : "");
            lblSketchPath.Title = LM.SketchPath;
            lblDebugPort.Title = LM.DebugPort;

            gridMessage.Columns[0].HeaderText = LM.Row;
            gridMessage.Columns[1].HeaderText = LM.Col;
            gridMessage.Columns[2].HeaderText = LM.Message;
        }
        #endregion
        #region UISet
        void UISet()
        {
            bool IsDebugging = Program.DevMgr.IsDebugging;

            btnMonitoring.ButtonColor = IsDebugging ? Color.Teal : Theme.ButtonColor;

            ladder.Visible = CurrentDocument != null;
            btnSaveFile.Enabled = CurrentDocument != null;
            btnSaveAsFile.Enabled = CurrentDocument != null;
            btnCheck.Enabled = CurrentDocument != null && !IsDebugging;
            btnHardware.Enabled = CurrentDocument != null && !IsDebugging;
            btnSymbol.Enabled = CurrentDocument != null && !IsDebugging;
            btnCommunication.Enabled = CurrentDocument != null && !IsDebugging;
            btnDefaultCode.Enabled = CurrentDocument != null;
            lblSketchPath.Enabled = CurrentDocument != null && !IsDebugging;
            pnlLD.Enabled = CurrentDocument != null && !IsDebugging && ladder.Editable;
            lblDebugPort.Enabled = CurrentDocument != null && !IsDebugging;
            btnExport.Enabled = CurrentDocument != null && !IsDebugging;
            gridMessage.Enabled = CurrentDocument != null;
            btnMonitoring.Enabled = CurrentDocument != null;

            ladder.Debug = IsDebugging;
            lblSketchPath.Value = CurrentDocument?.SketchPath ?? "";
            lblDebugPort.Value = $"{Program.DevMgr.PortName} : {Program.DevMgr.Baudrate}";

            LangSet();

            #region SizeChanged
            if (szold != this.Size)
            {
                szold = this.Size;
                Invalidate();
            }
            #endregion
        }
        #endregion
        #endregion
    }
}
