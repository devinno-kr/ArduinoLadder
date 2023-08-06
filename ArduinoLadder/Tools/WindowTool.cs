using Devinno.Forms.Dialogs;
using Devinno.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoLadder.Tools
{
    class WindowTool
    {
        public static void SetForm(DvForm wnd)
        {
            wnd.BlankForm = true;
            wnd.Padding = new Padding(3);
            wnd.FormBorderStyle = FormBorderStyle.Sizable;
            DwmTool.SetTheme(wnd, true);
        }

        public static void SetFormFix(DvForm wnd)
        {
            wnd.BlankForm = true;
            wnd.Padding = new Padding(3);
            wnd.FormBorderStyle = FormBorderStyle.FixedSingle;
            DwmTool.SetTheme(wnd, true);
        }

        public static void Set(DvForm wnd)
        {
            DwmTool.SetTheme(wnd, true);
        }
    }
}
