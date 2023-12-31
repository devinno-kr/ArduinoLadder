﻿using ArduinoLadder.Ladder;
using Devinno.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM = ArduinoLadder.Tools.LangTool;

namespace ArduinoLadder.Forms
{
    public partial class FormHardware : DvForm
    {
        #region class : Result
        public class Result
        {
            public List<HardwareInfo> Hardwares { get; set; } = new List<HardwareInfo>();
        }
        #endregion

        #region Member Variable
        LadderDocument doc;
        Result Data = new Result();
        #endregion

        #region Constructor
        public FormHardware()
        {
            InitializeComponent();

            #region Event
            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) => { if (ValidCheck()) DialogResult = DialogResult.OK; };
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion

            #region btnExport.ButtonClick
            btnExport.ButtonClick += (o, s) =>
            {
                
                using (var sfd = new SaveFileDialog())
                {
                    if (Directory.Exists(Path.Combine(Program.DataMgr.ProjectFolder, "boardlist"))) sfd.InitialDirectory = Path.Combine(Program.DataMgr.ProjectFolder, "boardlist");
                    else if (Directory.Exists(Program.DataMgr.ProjectFolder)) sfd.InitialDirectory = Program.DataMgr.ProjectFolder;
                    //sfd.InitialDirectory = Path.Combine(Application.StartupPath, "boardlist");
                    sfd.Filter = "Arduino Ladder Board File(*.albd)|*.albd";
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, txt.Text);
                    }
                }
                
            };
            #endregion

            #region btnImport.ButtonClick
            btnImport.ButtonClick += (o, s) =>
            {
                using (var ofd = new OpenFileDialog())
                {
                    if (Directory.Exists(Path.Combine(Program.DataMgr.ProjectFolder, "boardlist"))) ofd.InitialDirectory = Path.Combine(Program.DataMgr.ProjectFolder, "boardlist");
                    else if (Directory.Exists(Program.DataMgr.ProjectFolder)) ofd.InitialDirectory = Program.DataMgr.ProjectFolder;
                    //ofd.InitialDirectory = Path.Combine(Application.StartupPath, "boardlist");
                    ofd.Filter = "Arduino Ladder Board File(*.albd)|*.albd";
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        var str = File.ReadAllText(ofd.FileName);
                        txt.Text = str;
                    }
                }
            };
            #endregion

            #region txt.KeyPress
            txt.CharacterCasing = CharacterCasing.Upper;
            txt.KeyPress += (o, s) => { if (s.KeyChar == ' ') s.KeyChar = '\t'; };
            txt.TextChanged += (o, s) =>
            {
                using (var sr = new StringReader(txt.Text))
                {
                    var lsv = new List<HardwareInfo>();

                    #region Make Symbols
                    var lsmode = new string[] { "OUT", "IN", "AD", "DA" }.ToList();

                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (line != null)
                        {
                            var sp = line.Trim().Split(new char[] { ',', ' ', '\t' }).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                            if (sp != null && sp.Length == 3)
                            {
                                int pin;
                                if (lsmode.Contains(sp[0]) && int.TryParse(sp[1], out pin) && doc.ValidAddress(sp[2]))
                                {
                                    lsv.Add(new HardwareInfo { Mode = sp[0], Pin = pin, Address = sp[2] });
                                }
                            }
                        }
                        else break;
                    }
                    #endregion
                    #region Check
                    {
                        Data.Hardwares.Clear();
                        Data.Hardwares.AddRange(lsv);
                        tbl.SetItems(Data.Hardwares);
                    }
                    #endregion
                }
            };
            #endregion
            #endregion

            #region Form Props
            StartPosition = FormStartPosition.CenterParent;
            #endregion
 
        }
        #endregion

        #region Method
        #region ValidCheck
        bool ValidCheck()
        {
            var ls = new List<string>();

            return ls.Count == 0;
        }
        #endregion
        #region LangSet
        void LangSet()
        {
            Title = LM.Hardware;
            lblTitleAreas.Text = LM.HardwareList;
            dvLabel1.Text = LM.Input;
            btnOK.Text = LM.Input;
            btnCancel.Text = LM.Cancel;
            dvLabel3.Text = LM.HardwareInputFormat;
            btnImport.Text = LM.Import;
            btnExport.Text = LM.Export;
        }
        #endregion
        #region ShowHardware
        public Result ShowHardware(LadderDocument doc)
        {
            Result ret = null;
            
            this.doc = doc;

            Data = new Result();
            if (doc != null)
            {
                Data.Hardwares = doc.Hardwares.Select(x => new HardwareInfo() { Mode = x.Mode, Pin = x.Pin, Address = x.Address }).ToList();
            }

            var sb = new StringBuilder();

            var lso = Data.Hardwares.Where(x => x.Mode == "OUT");
            var lsi = Data.Hardwares.Where(x => x.Mode == "IN");
            var lsa = Data.Hardwares.Where(x => x.Mode == "AD");
            var lsd = Data.Hardwares.Where(x => x.Mode == "DA");

            foreach (var v in lso) sb.AppendLine($"{v.Mode}\t{v.Pin}\t{v.Address}"); 
            if (lso.Count() > 0) sb.AppendLine("");
            foreach (var v in lsi) sb.AppendLine($"{v.Mode}\t{v.Pin}\t{v.Address}"); 
            if (lsi.Count() > 0) sb.AppendLine("");
            foreach (var v in lsa) sb.AppendLine($"{v.Mode}\t{v.Pin}\t{v.Address}"); 
            if (lsa.Count() > 0) sb.AppendLine("");
            foreach (var v in lsd) sb.AppendLine($"{v.Mode}\t{v.Pin}\t{v.Address}");
            txt.Text = sb.ToString();
            tbl.SetItems(Data.Hardwares);

            LangSet();

            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = Data;
            }

            return ret;
        }
        #endregion
        #endregion
    }
}
