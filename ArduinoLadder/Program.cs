using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArduinoLadder.Forms;
using ArduinoLadder.Managers;
using ArduinoLadder.Tools;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;

namespace ArduinoLadder
{
    static class Program
    {
        #region Const
        public const int ICO_WH = 24;
        #endregion

        #region Properties
        public static FormMain MainForm { get; private set; }
        public static DvInputBox InputBox { get; private set; }
        public static DvMessageBox MessageBox { get; private set; }
        public static DvSerialPortSettingBox SerialBox { get; private set; }

        public static DeviceManager DevMgr { get; private set; }
        public static DataManager DataMgr { get; private set; }
        public static PrivateFontCollection Fonts { get; private set; }
        public static string Version { get; private set; }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var asm = typeof(Program).Assembly;
            Version = asm.GetName().Version?.ToString() ?? "";

            #region Directory
            var dir = Path.Combine(Application.StartupPath, "arduino_ld");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            #endregion
            #region Fonts 
            Fonts = new PrivateFontCollection();
            var ba = Properties.Resources.NanumGothic;
            IntPtr p = Marshal.AllocHGlobal(ba.Length);
            Marshal.Copy(ba, 0, p, ba.Length);
            Fonts.AddMemoryFont(p, ba.Length);
            Marshal.FreeHGlobal(p);
            #endregion
            #region Managers
            DevMgr = new DeviceManager();
            DataMgr = new DataManager();
            #endregion
            #region Forms
            InputBox = new DvInputBox() { StartPosition = FormStartPosition.CenterParent, MinWidth = 250 };
            MessageBox = new DvMessageBox() { StartPosition = FormStartPosition.CenterParent, MinWidth = 250 };
            SerialBox = new DvSerialPortSettingBox() { StartPosition = FormStartPosition.CenterParent };
            MainForm = new FormMain();

            InputBox.TitleIconBoxColor = Color.FromArgb(0, 102, 99);
            MessageBox.TitleIconBoxColor = Color.FromArgb(0, 102, 99);
            SerialBox.TitleIconBoxColor = Color.FromArgb(0, 102, 99);

            InputBox.Icon = IconTool.GetIcon(new DvIcon(InputBox.TitleIconString) { IconSize = InputBox.TitleIconSize }, ICO_WH, ICO_WH, Color.White);
            MessageBox.Icon = IconTool.GetIcon(new DvIcon(MessageBox.TitleIconString) { IconSize = MessageBox.TitleIconSize }, ICO_WH, ICO_WH, Color.White);
            SerialBox.Icon = IconTool.GetIcon(new DvIcon(SerialBox.TitleIconString) { IconSize = SerialBox.TitleIconSize }, ICO_WH, ICO_WH, Color.White);
           
            MessageBox.ButtonOk.Text = LangTool.Ok;
            MessageBox.ButtonCancel.Text = LangTool.Cancel;
            MessageBox.ButtonYes.Text = LangTool.Yes;
            MessageBox.ButtonNo.Text = LangTool.No;
            InputBox.ButtonOK.Text = LangTool.Ok;
            InputBox.ButtonCancel.Text = LangTool.Cancel;
            SerialBox.ButtonOK.Text = LangTool.Ok;
            SerialBox.ButtonCancel.Text = LangTool.Cancel;
            SerialBox.InputPort.Title = LangTool.Port;
            SerialBox.InputBaudrate.Title = LangTool.Baudrate;
            SerialBox.Title = LangTool.PortSetting;
            #endregion

            Application.Run(MainForm);
        }
    }
}
