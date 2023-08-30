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
        public const bool WindowBorder = true;
        public const bool UseWindowDock = false;
        #endregion

        #region Properties
        public static FormMain MainForm { get; private set; }
        public static FormInputBox InputBox { get; private set; }
        public static FormMessageBox MessageBox { get; private set; }
        public static FormSerialPortSettingBox SerialBox { get; private set; }

        public static DeviceManager DevMgr { get; private set; }
        public static DataManager DataMgr { get; private set; }
        public static PrivateFontCollection Fonts { get; private set; }
        public static string Version { get; private set; }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var asm = typeof(Program).Assembly;
            Version = asm.GetName().Version?.ToString() ?? "";

            #region Directory
            var dir = Path.Combine(Application.StartupPath, "arduino_ld");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            var dir2 = Path.Combine(Application.StartupPath, "boardlist");
            if (!Directory.Exists(dir2)) Directory.CreateDirectory(dir2);
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
            InputBox = new FormInputBox() { StartPosition = FormStartPosition.CenterParent, MinWidth = 250 };
            MessageBox = new FormMessageBox() { StartPosition = FormStartPosition.CenterParent, MinWidth = 250 };
            SerialBox = new FormSerialPortSettingBox() { StartPosition = FormStartPosition.CenterParent };
            MainForm = new FormMain() { UseWindowDock = UseWindowDock };

            InputBox.TitleIconBoxColor = Color.FromArgb(0, 102, 99);
            MessageBox.TitleIconBoxColor = Color.FromArgb(0, 102, 99);
            SerialBox.TitleIconBoxColor = Color.FromArgb(0, 102, 99);

            InputBox.Icon = IconTool.GetIcon(new DvIcon(InputBox.TitleIconString) { IconSize = 16}, ICO_WH, ICO_WH, Color.White);
            MessageBox.Icon = IconTool.GetIcon(new DvIcon(MessageBox.TitleIconString) { IconSize = 16 }, ICO_WH, ICO_WH, Color.White);
            SerialBox.Icon = IconTool.GetIcon(new DvIcon(SerialBox.TitleIconString) { IconSize = 16}, ICO_WH, ICO_WH, Color.White);
           
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
