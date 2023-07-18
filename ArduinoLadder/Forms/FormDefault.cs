using ArduinoLadder.Ladder;
using Devinno.Data;
using Devinno.Forms.Dialogs;
using Devinno.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM = ArduinoLadder.Tools.LangTool;

namespace ArduinoLadder.Forms
{
    public partial class FormDefault : DvForm
    {
        #region Constructor
        public FormDefault()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        #region LangSet
        void LangSet()
        {
            Title = LM.MainCode;
        }
        #endregion
        #region ShowDefaultCode
        public void ShowDefaultCode(LadderDocument doc)
        {
            if (doc != null)
            {
                #region var
                List<ILadderComm> ls = new List<ILadderComm>();
                try
                {
                    var str = CryptoTool.DecodeBase64String<string>(doc.Communications);
                    ls = Serialize.JsonDeserializeWithType<List<ILadderComm>>(str);
                }
                catch { }

                var acP = Convert.ToInt32(Math.Ceiling(doc.P_Count / 8.0));
                var acM = Convert.ToInt32(Math.Ceiling(doc.M_Count / 8.0));
                var acT = doc.T_Count;
                var acC = doc.C_Count;
                var acD = doc.D_Count;

                bool useEth = ls.Where(x => x.Name == LadderComm.ModbusTcpSlave.Name || x.Name == LadderComm.Mqtt.Name).Count() > 0;
                bool useMQT = ls.Where(x => x.Name == LadderComm.Mqtt.Name).Count() > 0;
                #endregion
                #region Code
                var sb = new StringBuilder();

                sb.AppendLine("#include \"syms.h\"");
                sb.AppendLine("");
                if (useEth)
                {
                    sb.AppendLine("#define  LOC_IP      172, 30, 1, 150 ");
                    sb.AppendLine("");
                }
                sb.AppendLine("void setup() ");
                sb.AppendLine("{");
                sb.AppendLine("  ladderSetup();");
                sb.AppendLine("  commSetup();");
                sb.AppendLine("");
                sb.AppendLine("  ladderDebug(Serial, 115200);");
                sb.AppendLine("}");
                sb.AppendLine("");
                sb.AppendLine("void loop() ");
                sb.AppendLine("{");
                sb.AppendLine("  ladderLoop();");
                sb.AppendLine("  commLoop();");
                sb.AppendLine("}");
                sb.AppendLine("");

                txt.Text = sb.ToString();
                #endregion
                
                LangSet();

                this.ShowDialog();
            }
        }
        #endregion
        #endregion
    }
}
