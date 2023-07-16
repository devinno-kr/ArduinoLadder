﻿using ArduinoLadder.Ladder;
using ArduinoLadder.Tools;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Extensions;
using Devinno.Forms.Icons;
using Devinno.Forms.Themes;
using Devinno.Forms.Utils;
using Devinno.Tools;
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

namespace ArduinoLadder.Forms
{
    public partial class FormSymbol2 : DvForm
    {
        #region class : Result
        public class Result
        {
            public int P_Count { get; set; } = 32768;   //4096 bytes
            public int M_Count { get; set; } = 32768;   //4096 bytes
            public int T_Count { get; set; } = 2048;    //4096 bytes
            public int C_Count { get; set; } = 2048;    //4096 bytes
            public int D_Count { get; set; } = 4096;    //8192 bytes

            public List<SymbolInfo> Symbols { get; set; } = new List<SymbolInfo>();
        }
        #endregion

        #region Member Variable
        LadderDocument doc;
        Result Data = new Result();
        #endregion

        #region Constructor
        public FormSymbol2()
        {
            InitializeComponent();

            #region Event
            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) => { if (ValidCheck()) DialogResult = DialogResult.OK; };
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion

            #region txt.KeyPress
            txt.CharacterCasing = CharacterCasing.Upper;
            txt.KeyPress += (o, s) => { if (s.KeyChar == ' ') s.KeyChar = '\t'; };
            txt.TextChanged += (o, s) =>
            {
                using (var sr = new StringReader(txt.Text))
                {
                    var lsv = new List<SymbolInfo>();

                    #region Make Symbols
                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (line != null)
                        {
                            var sp = line.Trim().Split(new char[] { ',', ' ', '\t' }).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                            if (sp != null && sp.Length == 2)
                            {
                                if (doc.ValidAddress(sp[0]))
                                {
                                    lsv.Add(new SymbolInfo { Address = sp[0], SymbolName = sp[1] });
                                }
                            }
                        }
                        if (line == null) break;
                    }
                    #endregion
                    #region Check
                    var lk1 = lsv.ToLookup(x => x.Address);
                    var lk2 = lsv.ToLookup(x => x.SymbolName);
                    var c1 = lk1.Count > 0 ? lk1.Max(x => lk1[x.Key].Count()) : 0;
                    var c2 = lk2.Count > 0 ? lk2.Max(x => lk2[x.Key].Count()) : 0;
                    if (c1 < 2 && c2 < 2)
                    {
                        Data.Symbols.Clear();
                        Data.Symbols.AddRange(lsv);
                        tbl.SetItems(Data.Symbols);
                    }
                    #endregion
                }
            };
            #endregion
            #endregion

            #region Form Props
            StartPosition = FormStartPosition.CenterParent;
            this.Icon = Tools.IconTool.GetIcon(new Devinno.Forms.Icons.DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion
 
        }
        #endregion

        #region Method
        #region ValidCheck
        bool ValidCheck()
        {
            bool ret = true;

            var ls = new List<string>();

            if (inP.Error == InputError.Empty) ls.Add("P 영역 크기가 비어있습니다.");
            else if (inP.Error == InputError.RangeOver) ls.Add("P 영역 범위는 0 ~ 32768 입니다.");

            if (inM.Error == InputError.Empty) ls.Add("M 영역 크기가 비어있습니다.");
            else if (inM.Error == InputError.RangeOver) ls.Add("M 영역 범위는 0 ~ 32768 입니다.");

            if (inT.Error == InputError.Empty) ls.Add("T 영역 크기가 비어있습니다.");
            else if (inT.Error == InputError.RangeOver) ls.Add("T 영역 범위는 0 ~ 2048 입니다.");

            if (inC.Error == InputError.Empty) ls.Add("C영역 크기가 비어있습니다.");
            else if (inC.Error == InputError.RangeOver) ls.Add("C영역 범위는 0 ~ 2048 입니다.");

            if (inD.Error == InputError.Empty) ls.Add("D영역 크기가 비어있습니다.");
            else if (inD.Error == InputError.RangeOver) ls.Add("D영역 범위는 0 ~ 4096 입니다.");
             
            if (ls.Count > 0)
            {
                //Block = true;
                var msg = string.Concat(ls.Select(x => x + "\r\n")).Trim();
                Program.MessageBox.ShowMessageBoxOk("심볼 입력", msg);
                //Block = false;
            }

            return ls.Count == 0;
        }
        #endregion

        #region ShowSymbol
        public Result ShowSymbol(LadderDocument doc)
        {
            Result ret = null;

            this.doc = doc;

            Data = new Result();
            if (doc != null)
            {
                Data.P_Count = doc.P_Count;
                Data.M_Count = doc.M_Count;
                Data.T_Count = doc.T_Count;
                Data.C_Count = doc.C_Count;
                Data.D_Count = doc.D_Count;
                Data.Symbols = doc.Symbols.Select(x => new SymbolInfo() { SymbolName = x.SymbolName, Address = x.Address }).ToList();
            }

            inP.Value = Data.P_Count;
            inM.Value = Data.M_Count;
            inT.Value = Data.T_Count;
            inC.Value = Data.C_Count;
            inD.Value = Data.D_Count;

            var sb = new StringBuilder();
            foreach(var v in Data.Symbols) sb.AppendLine($"{v.Address}\t{v.SymbolName}");
            txt.Text = sb.ToString();
            tbl.SetItems(Data.Symbols);

            #region ShowDialog
            if (this.ShowDialog() == DialogResult.OK)
            {
                Data.P_Count = inP.Value ?? 0;
                Data.M_Count = inM.Value ?? 0;
                Data.T_Count = inT.Value ?? 0;
                Data.C_Count = inC.Value ?? 0;
                Data.D_Count = inD.Value ?? 0;

                ret = Data;
            }
            #endregion

            return ret;
        }
        #endregion

        #endregion
    }
}
