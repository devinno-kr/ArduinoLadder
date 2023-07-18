using ArduinoLadder.Ladder;
using Devinno.Data;
using Devinno.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LM = ArduinoLadder.Tools.LangTool;

namespace ArduinoLadder.Tools
{
    public class LadderTool
    {
        #region Static Variable
        static string[] Operators = new string[] { "<<=", ">>=", "::", "->", "++", "--", "==", "!=", ">=", "<=", "&&", "||", "<<", ">>",
                                    "+=", "-=", "*=", "/=", "%=", "&=", "|=", "^=", "=", "+", "-", "*", "/", ">",
                                    "<", "!", "~", "&", "|", "^", ".", "?", ":", "[", "]", "(", ")", "{", "}", ",",  ";", " "};
        #endregion

        #region Private
        #region Reent
        static void Reent(LadderItem itm, Dictionary<string, LadderItem> dic, List<List<LadderItem>> result, List<List<LadderItem>> faild, List<LadderItem> itms)
        {
            itms.Add(itm);
            string right = (itm.Row).ToString() + "," + (itm.Col + 1).ToString();
            string righttop = (itm.Row - 1).ToString() + "," + (itm.Col + 1).ToString();
            string top = (itm.Row - 1).ToString() + "," + (itm.Col).ToString();
            string bottom = (itm.Row + 1).ToString() + "," + (itm.Col).ToString();

            if ((itm.ItemType == LadderItemType.OUT_COIL) || (itm.ItemType == LadderItemType.OUT_FUNC))
            {
                #region List
                List<LadderItem> mls = new List<LadderItem>();
                for (int i = 0; i < itms.Count; i++)
                {
                    var v = itms[i].Clone();
                    if (mls.Count > 0 && mls[i - 1].VerticalLine && mls[i - 1].Row == v.Row - 1) mls[i - 1].ItemType = LadderItemType.NONE;
                    mls.Add(v);
                }
                result.Add(mls);
                #endregion
            }
            else
            {
                bool bEnt = false;

                #region 위로 이동 - 우측위
                if (dic.ContainsKey(righttop) && !dic.ContainsKey(right))
                {
                    LadderItem next = dic[righttop];
                    if (next.VerticalLine && !itms.Contains(next))
                    {
                        bEnt = true;
                        Reent(next, dic, result, faild, new List<LadderItem>(itms.ToArray()));
                    }
                }
                #endregion
                #region 위로 이동
                if (dic.ContainsKey(top))
                {
                    LadderItem next = dic[top];
                    if (next.VerticalLine && !itms.Contains(next))
                    {
                        bEnt = true;
                        Reent(next, dic, result, faild, new List<LadderItem>(itms.ToArray()));
                    }
                }
                #endregion
                #region 우측 이동
                if (dic.ContainsKey(right))
                {
                    LadderItem next = dic[right];
                    if (
                        (itm.ItemType == LadderItemType.IN_A) ||
                        (itm.ItemType == LadderItemType.IN_B) ||
                        (itm.ItemType == LadderItemType.FALLING_EDGE) ||
                        (itm.ItemType == LadderItemType.RISING_EDGE) ||
                        (itm.ItemType == LadderItemType.NOT) ||
                        (itm.ItemType == LadderItemType.LINE_H)
                        && !itms.Contains(next)
                      )
                    {
                        bEnt = true;
                        Reent(next, dic, result, faild, new List<LadderItem>(itms.ToArray()));
                    }
                }
                #endregion
                #region 아래 이동
                if (dic.ContainsKey(bottom))
                {
                    LadderItem next = dic[bottom];
                    if (itm.VerticalLine && !itms.Contains(next))
                    {
                        bEnt = true;
                        Reent(next, dic, result, faild, new List<LadderItem>(itms.ToArray()));
                    }
                }
                #endregion

                #region List
                if (!bEnt)
                {
                    List<LadderItem> mls = new List<LadderItem>();
                    for (int i = 0; i < itms.Count; i++)
                    {
                        var v = itms[i].Clone();
                        if (mls.Count > 0 && mls[i - 1].VerticalLine && mls[i - 1].Row == v.Row - 1) mls[i - 1].ItemType = LadderItemType.NONE;
                        mls.Add(v);
                    }
                    faild.Add(mls);
                }
                #endregion
            }
        }
        #endregion
        #region CheckBrace
        public static bool CheckBrace(string line)
        {
            Stack<int> stkS = new Stack<int>();
            Stack<int> stkM = new Stack<int>();
            Stack<int> stkL = new Stack<int>();
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == '(') { stkS.Push(i); }
                if (c == ')' && stkS.Count > 0) { var si = stkS.Pop(); }
                if (c == '{') { stkM.Push(i); }
                if (c == '}' && stkM.Count > 0) { var si = stkM.Pop(); }
                if (c == '[') { stkL.Push(i); }
                if (c == ']' && stkL.Count > 0) { var si = stkL.Pop(); }
            }
            return stkS.Count == 0 && stkM.Count == 0 && stkL.Count == 0;
        }
        #endregion
        #region CheckSPNode
        static bool CheckSPNode(LadderItemType tp)
        {
            bool ret = false;
            if (tp == LadderItemType.IN_A) ret |= true;
            if (tp == LadderItemType.IN_B) ret |= true;
            if (tp == LadderItemType.RISING_EDGE) ret |= true;
            if (tp == LadderItemType.FALLING_EDGE) ret |= true;
            if (tp == LadderItemType.NOT) ret |= true;
            if (tp == LadderItemType.OUT_COIL) ret |= true;
            if (tp == LadderItemType.OUT_FUNC) ret |= true;
            return ret;
        }
        #endregion
        #endregion

        #region GetWords
        public static List<string> GetWords(string line)
        {
            var pat = @"\b([_A-Za-z0-9.]+)|(@\w+)\b";
            var ms = Regex.Matches(line, pat);
            return ms.Select(x => ((Match)x).Value).ToList();
        }
        #endregion

        #region ValidCheck
        public static List<LadderCheckMessage> ValidCheck(LadderDocument doc, bool Editor)
        {
            var ret = new List<LadderCheckMessage>();

            #region Check
            var dic = doc.Ladders.ToDictionary(x => x.Key);
            var r = Build(doc);

            #region 완성되지 않은 연결
            if (r.InvalidNodes.Count > 0)
            {
                foreach (var vk in r.InvalidNodes.Keys)
                {
                    var vls = r.InvalidNodes[vk].FirstOrDefault();
                    if (vls != null)
                    {
                        var st = vls.FirstOrDefault();
                        var ed = vls.LastOrDefault();

                        ret.Add(new LadderCheckMessage()
                        {
                            Row = ed != null ? (int?)ed.Row + 1 : null,
                            Column = ed != null ? (int?)ed.Col + 1 : null,
                            Message = LM.LadderErrorIncomplete,
                        });
                    }
                }
            }
            #endregion

            #region 잘못된 주석
            var els = doc.Ladders.Where(x => x.ItemType == LadderItemType.NONE && !(((x.Code.StartsWith("#") && x.Col == 0) || x.Code.StartsWith("'") || string.IsNullOrWhiteSpace(x.Code)))).ToList();
            foreach (var v in els)
            {
                ret.Add(new LadderCheckMessage()
                {
                    Row = v.Row + 1,
                    Column = v.Col + 1,
                    Message = LM.LadderErrorSyntax,
                });
            }
            #endregion

            foreach (var itm in doc.Ladders)
            {
                #region 비정상적인 연결
                if (itm.ItemType != LadderItemType.NONE)
                {
                    string left = (itm.Row).ToString() + "," + (itm.Col - 1).ToString();
                    string top = (itm.Row - 1).ToString() + "," + (itm.Col).ToString();
                    string leftbottom = (itm.Row + 1).ToString() + "," + (itm.Col - 1).ToString();

                    bool b1 = (dic.ContainsKey(left) && dic[left].ItemType != LadderItemType.OUT_COIL && dic[left].ItemType != LadderItemType.OUT_FUNC);
                    bool b2 = (dic.ContainsKey(top) && dic[top].VerticalLine);
                    bool b3 = (dic.ContainsKey(leftbottom) && itm.VerticalLine && dic[leftbottom].ItemType != LadderItemType.OUT_COIL && dic[leftbottom].ItemType != LadderItemType.OUT_FUNC);

                    if (itm.Col > 0 && !b1 && !b2 && !b3)
                    {
                        ret.Add(new LadderCheckMessage()
                        {
                            Row = itm.Row + 1,
                            Column = itm.Col + 1,
                            Message = LM.LadderErrorAbnormal,
                        });
                    }
                }
                #endregion
                #region 함수
                if (itm.ItemType == LadderItemType.OUT_FUNC)
                {
                    var code = itm.Code;
                    if (code.StartsWith("{"))
                    {
                        if (!CheckBrace(code))
                        {
                            ret.Add(new LadderCheckMessage()
                            {
                                Row = itm.Row + 1,
                                Column = itm.Col + 1,
                                Message = LM.LadderErrorParenthesis
                            });
                        }
                    }
                    else
                    {
                        if (LadderFunc.Funcs.Where(x => x.Name.StartsWith(code.Split('(').Where(x=>!string.IsNullOrWhiteSpace(x.Trim())).FirstOrDefault()?.Trim())).Count() > 0)
                        {
                            var fn = FuncInfo.Parse(code);
                            if (fn != null)
                            {
                                var result = LadderFunc.Check(doc, itm);
                                if (result.Count > 0) ret.AddRange(result);
                            }
                            else
                            {
                                ret.Add(new LadderCheckMessage()
                                {
                                    Row = itm.Row + 1,
                                    Column = itm.Col + 1,
                                    Message = LM.LadderErrorFunction
                                });
                            }
                        }
                        else
                        {
                            var v = GetWords(code);
                        }
                    }
                }
                #endregion
                #region 입력
                if (itm.ItemType == LadderItemType.IN_A || itm.ItemType == LadderItemType.IN_B)
                {
                    if (string.IsNullOrWhiteSpace(itm.Code))
                    {
                        ret.Add(new LadderCheckMessage()
                        {
                            Row = itm.Row + 1,
                            Column = itm.Col + 1,
                            Message = LM.LadderErrorEmptyItem
                        });
                    }
                }
                #endregion
            }
            #endregion

            return ret;
        }
        #endregion

        #region Build
        public static LadderBuildResult Build(LadderDocument doc)
        {
            var lstItem = doc.Ladders;

            lstItem.Sort();
            Dictionary<string, LadderItem> dic = lstItem.ToDictionary(x => x.Key);
            Dictionary<string, List<List<LadderItem>>> dicResult = new Dictionary<string, List<List<LadderItem>>>();
            Dictionary<string, List<List<LadderItem>>> dicFaild = new Dictionary<string, List<List<LadderItem>>>();

            for (int i = 0; i < lstItem.Count; i++)
            {
                LadderItem itm = lstItem[i];
                if (itm.Col == 0 && itm.ItemType != LadderItemType.NONE)
                {
                    List<List<LadderItem>> result = new List<List<LadderItem>>();
                    List<List<LadderItem>> faild = new List<List<LadderItem>>();
                    Reent(itm, dic, result, faild, new List<LadderItem>());

                    for (int ri = 0; ri < result.Count; ri++)
                    {
                        LadderItem endnode = result[ri][result[ri].Count - 1];
                        if ((endnode.ItemType == LadderItemType.OUT_FUNC) || (endnode.ItemType == LadderItemType.OUT_COIL))
                        {
                            string key = endnode.Row.ToString() + "," + endnode.Col.ToString();
                            if (!dicResult.ContainsKey(key)) dicResult.Add(key, new List<List<LadderItem>>());
                            dicResult[key].Add(result[ri]);
                        }
                    }

                    for (int ri = 0; ri < faild.Count; ri++)
                    {
                        LadderItem endnode = faild[ri][faild[ri].Count - 1];
                        if (!((endnode.ItemType == LadderItemType.OUT_FUNC) || (endnode.ItemType == LadderItemType.OUT_COIL)))
                        {
                            if (!CheckVertialEndNodes(faild[ri]))
                            {
                                string key = endnode.Row.ToString() + "," + endnode.Col.ToString();
                                if (!dicFaild.ContainsKey(key)) dicFaild.Add(key, new List<List<LadderItem>>());
                                dicFaild[key].Add(faild[ri]);
                            }
                        }
                    }
                }
            }
            return new LadderBuildResult() { ValidNodes = dicResult, InvalidNodes = dicFaild };
        }

        public static LadderBuildResult Build(List<LadderItem> lstItem)
        {
            lstItem.Sort();
            Dictionary<string, LadderItem> dic = lstItem.ToDictionary(x => x.Key);
            Dictionary<string, List<List<LadderItem>>> dicResult = new Dictionary<string, List<List<LadderItem>>>();
            Dictionary<string, List<List<LadderItem>>> dicFaild = new Dictionary<string, List<List<LadderItem>>>();

            for (int i = 0; i < lstItem.Count; i++)
            {
                LadderItem itm = lstItem[i];
                if (itm.Col == 0 && itm.ItemType != LadderItemType.NONE)
                {
                    List<List<LadderItem>> result = new List<List<LadderItem>>();
                    List<List<LadderItem>> faild = new List<List<LadderItem>>();
                    Reent(itm, dic, result, faild, new List<LadderItem>());

                    for (int ri = 0; ri < result.Count; ri++)
                    {
                        LadderItem endnode = result[ri][result[ri].Count - 1];
                        if ((endnode.ItemType == LadderItemType.OUT_FUNC) || (endnode.ItemType == LadderItemType.OUT_COIL))
                        {
                            string key = endnode.Row.ToString() + "," + endnode.Col.ToString();
                            if (!dicResult.ContainsKey(key)) dicResult.Add(key, new List<List<LadderItem>>());
                            dicResult[key].Add(result[ri]);
                        }
                    }

                    for (int ri = 0; ri < faild.Count; ri++)
                    {
                        LadderItem endnode = faild[ri][faild[ri].Count - 1];
                        if (!((endnode.ItemType == LadderItemType.OUT_FUNC) || (endnode.ItemType == LadderItemType.OUT_COIL)))
                        {
                            if (!CheckVertialEndNodes(faild[ri]))
                            {
                                string key = endnode.Row.ToString() + "," + endnode.Col.ToString();
                                if (!dicFaild.ContainsKey(key)) dicFaild.Add(key, new List<List<LadderItem>>());
                                dicFaild[key].Add(faild[ri]);
                            }
                        }
                    }
                }
            }
            return new LadderBuildResult() { ValidNodes = dicResult, InvalidNodes = dicFaild };
        }
        #endregion

        #region MakeCode
        private static string L(string str, LadderItem v)
        {
            var spos = $"//{v.Row + 1},{v.Col + 1}";
            var len = 100 - str.Length;
            if (len < 0) len = spos.Length;
            var s = str + spos.PadLeft(len);
            return s;
        }

        private static string R(string str)
        {
            return str.PadRight(70);
        }

        internal static Dictionary<string, string> MakeCode(LadderDocument doc)
        {
            var ret = new Dictionary<string, string>();
            #region Variable
            var dic = doc.Ladders.ToDictionary(x=>x.Key);
            var result = Build(doc);

            var bul = result.ValidNodes;
            var Debugs = DebugTool.GetDebugs(doc);
            var lsDBGP = DebugTool.GetDBGP(Debugs);
            var lsDBGW = DebugTool.GetDBGW(Debugs);
            var DBGP_CNT = DebugTool.DBGP_Count(lsDBGP);
            var DBGW_CNT = DebugTool.DBGW_Count(lsDBGW);
            #endregion

            #region PLC.ino
            {
                var sbPLC = new StringBuilder();

                #region #include
                sbPLC.AppendLine("#if defined(__AVR__)");
                sbPLC.AppendLine("#include <TimerThree.h>");
                sbPLC.AppendLine("#elif defined(__SAM3X8E__)");
                sbPLC.AppendLine("#include <DueTimer.h>");
                sbPLC.AppendLine("#endif");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("#include <ModbusRTUSlave.h>");
                sbPLC.AppendLine("");
                #endregion
                #region #define
                sbPLC.AppendLine("#define MCSCNT  16");
                #region Debugs
                int nidx = 0;
                sbPLC.AppendLine($"#define DBGCNT  {Debugs.Count}");
                foreach (var k in Debugs.Keys)
                {
                    sbPLC.AppendLine($"#define D{k}  {nidx}");
                    nidx++;
                }
                sbPLC.AppendLine("");
                #endregion
                #endregion
                #region declare
                #region func
                sbPLC.AppendLine("bool _MCSCHK_();");
                sbPLC.AppendLine("bool _TCHK_(int idx);");
                sbPLC.AppendLine("void _TRST_(int idx);");
                sbPLC.AppendLine("void TON(int idx, int val, bool result);");
                sbPLC.AppendLine("void TAON(int idx, int val, bool result);");
                sbPLC.AppendLine("void TOFF(int idx, int val, bool result);");
                sbPLC.AppendLine("void TAOFF(int idx, int val, bool result);");
                sbPLC.AppendLine("void TMON(int idx, int val, bool result);");
                sbPLC.AppendLine("void TAMON(int idx, int val, bool result);");
                sbPLC.AppendLine("void received(int cmd, char* message, long len);");
                sbPLC.AppendLine("");
                #endregion
                #region var
                sbPLC.AppendLine($"ModbusRTUSlave* slave;");
                sbPLC.AppendLine($"TMR* T[T_COUNT]; ");
                sbPLC.AppendLine($"MCSV MCS[MCSCNT];");
                sbPLC.AppendLine($"");
                sbPLC.AppendLine($"bool _SR_ON = true, _SR_OFF = false;");
                sbPLC.AppendLine($"bool _SR_10R = false, _SR_100R = false, _SR_1000R = false;");
                sbPLC.AppendLine($"bool _SR_F10R = false, _SR_F100R = false, _SR_F1000R = false;");
                sbPLC.AppendLine($"bool _SR_BEGIN = false;");
                sbPLC.AppendLine($"bool _100_ = false, _1000_ = false;");
                sbPLC.AppendLine($"int _CNT100 = 0, _CNT1000 = 0;");
                sbPLC.AppendLine($"");
                sbPLC.AppendLine($"DebugInfo Debugs[{Debugs.Count}];");
                sbPLC.AppendLine($"bool useDebug = false;");
                sbPLC.AppendLine($"unsigned char __DBGP[{DBGP_CNT}];");
                sbPLC.AppendLine($"unsigned short __DBGW[{DBGW_CNT}];");
                sbPLC.AppendLine($"");
                #endregion
                #region ladder var
                {
                    foreach (var v in doc.Ladders.OrderBy(x => x.Row).ThenBy(x => x.Col))
                    {
                        if (v.Code != null && !v.Code.StartsWith("'"))
                        {
                            var vit = v.ItemType;
                            if (vit == LadderItemType.IN_A || vit == LadderItemType.IN_B || vit == LadderItemType.NOT ||
                                vit == LadderItemType.OUT_COIL || vit == LadderItemType.OUT_FUNC)
                            {
                                sbPLC.AppendLine("bool     __" + v.Row + "_" + v.Col + ";");
                            }
                            else if (vit == LadderItemType.RISING_EDGE || vit == LadderItemType.FALLING_EDGE)
                            {
                                sbPLC.AppendLine("EDGE     __" + v.Row + "_" + v.Col + ";");
                            }
                        }
                    }
                }
                sbPLC.AppendLine("");
                #endregion
                #endregion
                #region ladderSetup
                sbPLC.AppendLine("void ladderSetup()");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    for(long i=0; i<T_COUNT; i++) T[i] = new TMR(i);  ");
                sbPLC.AppendLine("");
                #region Debugs
                foreach (var k in Debugs.Keys)
                {
                    var v = Debugs[k];
                    sbPLC.AppendLine($"    Debugs[D{k}].Type = D_{v.Type};");
                    sbPLC.AppendLine($"    Debugs[D{k}].Row = {v.Row};");
                    sbPLC.AppendLine($"    Debugs[D{k}].Column = {v.Column};");
                    sbPLC.AppendLine("");
                }
                #endregion
                sbPLC.AppendLine("");
                #region Hardware
                foreach(var v in doc.Hardwares)
                {
                    if (v.Mode == "IN") sbPLC.AppendLine($"    pinMode({v.Pin}, INPUT);");
                    if (v.Mode == "OUT") sbPLC.AppendLine($"    pinMode({v.Pin}, OUTPUT);");
                }
                #endregion
                sbPLC.AppendLine("");
                #region Timer
                sbPLC.AppendLine("    #if defined(__AVR__)");
                sbPLC.AppendLine("    Timer3.initialize(10000);");
                sbPLC.AppendLine("    Timer3.attachInterrupt(ladderTick);");
                sbPLC.AppendLine("    #elif defined(__SAM3X8E__)");
                sbPLC.AppendLine("    Timer3.attachInterrupt(ladderTick);");
                sbPLC.AppendLine("    Timer3.start(10000);");
                sbPLC.AppendLine("    #endif");
                #endregion
                sbPLC.AppendLine("");
                sbPLC.AppendLine("    _SR_BEGIN = true; ");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                #endregion
                #region ladderLoop
                sbPLC.AppendLine("void ladderLoop()");
                sbPLC.AppendLine("{");
                #region Load Special Relay
                sbPLC.AppendLine("    bool _result_ = false, _b_ = false, _ck_ = false, _mc_ = true;          ");
                sbPLC.AppendLine("    bool SR_ON  = _SR_ON,  SR_OFF  = _SR_OFF,  SR_BEGIN = _SR_BEGIN;        ");
                sbPLC.AppendLine("    bool SR_10R  = _SR_10R,  SR_100R  = _SR_100R,  SR_1000R  = _SR_1000R;   ");
                sbPLC.AppendLine("    bool SR_F10R = _SR_F10R, SR_F100R = _SR_F100R, SR_F1000R = _SR_F1000R;  ");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("    if( _SR_10R ) _SR_10R = false;                                          ");
                sbPLC.AppendLine("    if( _SR_100R ) _SR_100R = false;                                        ");
                sbPLC.AppendLine("    if( _SR_1000R ) _SR_1000R = false;                                      ");
                sbPLC.AppendLine("");
                #endregion
                #region Load Hardware
                foreach (var v in doc.Hardwares)
                {
                    if (v.Mode == "IN") sbPLC.AppendLine($"    {v.Address} = digitalRead({v.Pin});");
                    if (v.Mode == "AD") sbPLC.AppendLine($"    {v.Address} = analogRead({v.Pin});");
                }
                sbPLC.AppendLine("");
                #endregion
                #region Load Memory
                foreach (var v in doc.Ladders)
                {
                    switch (v.ItemType)
                    {
                        #region IN_A
                        case LadderItemType.IN_A:
                            {
                                string s = v.Code;
                                foreach (var cmd in GetWords(v.Code))
                                {
                                    int idx = 0;
                                    if (cmd.StartsWith("T") && cmd.IndexOf('.') == -1 && int.TryParse(cmd.Substring(1), out idx))
                                    {
                                        s = s.Replace(cmd, "_TCHK_(" + idx + ")");
                                    }
                                    else
                                    {
                                        s = s.Replace(cmd, doc.GetMemCode(cmd));
                                    }
                                }
                                sbPLC.AppendLine(L($"    __{v.Row}_{v.Col} = ({s});", v));
                            }
                            break;
                        #endregion
                        #region IN_B
                        case LadderItemType.IN_B:
                            {
                                string s = v.Code;
                                foreach (var cmd in GetWords(v.Code))
                                {
                                    int idx = 0;
                                    if (cmd.StartsWith("T") && cmd.IndexOf('.') == -1 && int.TryParse(cmd.Substring(1), out idx))
                                    {
                                        s = s.Replace(cmd, "_TCHK_(" + idx + ")");
                                    }
                                    else
                                    {
                                        s = s.Replace(cmd, doc.GetMemCode(cmd));
                                    }
                                }

                                sbPLC.AppendLine(L($"    __{v.Row}_{v.Col} = !({s});", v));
                            }
                            break;
                        #endregion
                        #region EDGE
                        case LadderItemType.RISING_EDGE:
                        case LadderItemType.FALLING_EDGE:
                            {
                                sbPLC.AppendLine(L($"    __{v.Row}_{v.Col}.load();", v));
                            }
                            break;
                            #endregion
                    }
                }
                sbPLC.AppendLine("");
                #endregion
                #region LadderCode
                foreach (var vk in bul.Keys)
                {
                    var vls = bul[vk];
                    if (vls.Count > 0)
                    {
                        var _out = vls.FirstOrDefault().LastOrDefault();

                        sbPLC.AppendLine("    //==========================================================================================================  ");
                        sbPLC.AppendLine("    _result_ = false; _b_ = true; _ck_ = false;                                                                  ");
                        sbPLC.AppendLine("");
                        #region LOGIC
                        {
                            sbPLC.AppendLine("    if(_mc_)                                                                                                   ");
                            sbPLC.AppendLine("    {                                                                                                        ");
                            #region MCS ON
                            foreach (var vl in vls)
                            {
                                var v = vl.Where(x => CheckSPNode(x.ItemType)).ToList();
                                sbPLC.AppendLine("        _b_ = true;");
                                foreach (var nd in v)
                                {
                                    string nm = "__" + nd.Row + "_" + nd.Col;

                                    if (nd != v.LastOrDefault())
                                    {
                                        #region LOGIC CODE
                                        switch (nd.ItemType)
                                        {
                                            case LadderItemType.IN_A:
                                                sbPLC.AppendLine(L($"        _ck_ = {nm};", nd));
                                                sbPLC.AppendLine(L($"        _b_ &= _ck_;", nd));
                                                break;
                                            case LadderItemType.IN_B:
                                                sbPLC.AppendLine(L($"        _ck_ = {nm};", nd));
                                                sbPLC.AppendLine(L($"        _b_ &= _ck_;", nd));
                                                break;
                                            case LadderItemType.RISING_EDGE:
                                                sbPLC.AppendLine(L($"        _ck_ = {nm}.rising(_b_);", nd));
                                                sbPLC.AppendLine(L($"        _b_ = _ck_;", nd));
                                                break;
                                            case LadderItemType.FALLING_EDGE:
                                                sbPLC.AppendLine(L($"        _ck_ = {nm}.falling(_b_);", nd));
                                                sbPLC.AppendLine(L($"        _b_ = _ck_;", nd));
                                                break;
                                            case LadderItemType.NOT:
                                                sbPLC.AppendLine(L($"        {nm} = !_b_;", nd));
                                                sbPLC.AppendLine(L($"        _ck_ = {nm};", nd));
                                                sbPLC.AppendLine(L($"        _b_ = _ck_;", nd));
                                                break;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region RESULT
                                        sbPLC.AppendLine("        _result_ |= _b_;");
                                        #endregion
                                    }
                                }
                                sbPLC.AppendLine("        ");
                            }
                            #endregion
                            sbPLC.AppendLine("    }                                                                                                        ");
                            sbPLC.AppendLine("    else                                                                                                     ");
                            sbPLC.AppendLine("    {                                                                                                        ");
                            #region MCS OFF
                            foreach (var vl in vls)
                            {
                                var v = vl.Where(x => CheckSPNode(x.ItemType)).ToList();
                                sbPLC.AppendLine("        _b_ = true;");
                                foreach (var nd in v)
                                {
                                    string nm = "__" + nd.Row + "_" + nd.Col;

                                    if (nd != v.LastOrDefault())
                                    {
                                        #region LOGIC CODE
                                        switch (nd.ItemType)
                                        {
                                            case LadderItemType.IN_A:
                                            case LadderItemType.IN_B:
                                            case LadderItemType.NOT:
                                                sbPLC.AppendLine(L($"        {nm} = false;", nd));
                                                break;
                                            case LadderItemType.RISING_EDGE:
                                            case LadderItemType.FALLING_EDGE:
                                                sbPLC.AppendLine(L($"        {nm}.off();", nd));
                                                break;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region RESULT
                                        sbPLC.AppendLine("        _result_ = false;");
                                        #endregion
                                    }
                                }
                                sbPLC.AppendLine("        ");
                            }
                            #endregion
                            sbPLC.AppendLine("    }                                                                                                        ");
                        }
                        #endregion
                        sbPLC.AppendLine("");
                        #region OUT
                        {
                            sbPLC.AppendLine("    if(_mc_)                                                                                                   ");
                            sbPLC.AppendLine("    {                                                                                                        ");
                            #region MCS ON
                            {
                                string nm = "__" + _out.Row + "_" + _out.Col;
                                switch (_out.ItemType)
                                {
                                    #region OUT_FUNC
                                    case LadderItemType.OUT_FUNC:
                                        {
                                            var nd = _out;
                                            var code = nd.Code.Trim();
                                            var fn = FuncInfo.Parse(code);
                                            #region 함수
                                            if (fn != null && LadderFunc.Funcs.Where(x => x.Name == fn.Name.ToUpper()).Count() > 0)
                                            {
                                                switch (fn.Name.ToUpper())
                                                {
                                                    #region TON / TAON / TOFF / TAOFF
                                                    case "TON":
                                                    case "TAON":
                                                    case "TOFF":
                                                    case "TAOFF":
                                                        {
                                                            var addr = doc.GetSymbolAddress(fn.Args[0]);
                                                            var val = doc.GetMemCode(fn.Args[1]);
                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                            sbPLC.AppendLine(L($"        {fn.Name}({addr.Substring(1)}, {val}, _result_);", nd));
                                                        }
                                                        break;
                                                    #endregion
                                                    #region TMON / TAMON
                                                    case "TMON":
                                                    case "TAMON":
                                                        {
                                                            var addr = doc.GetSymbolAddress(fn.Args[0]);
                                                            var val = doc.GetMemCode(fn.Args[1]);
                                                            sbPLC.AppendLine(L($"        {fn.Name}({addr.Substring(1)}, {val}, !{nm} && _result_);", nd));
                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                        }
                                                        break;
                                                    #endregion
                                                    #region SETOUT / RSTOUT
                                                    case "SETOUT":
                                                        {
                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                            sbPLC.AppendLine(L($"        if(_result_)", nd));
                                                            sbPLC.AppendLine(L($"        {{", nd));
                                                            sbPLC.AppendLine(L($"            {doc.GetMemCode(fn.Args[0])} = true;", nd));
                                                            sbPLC.AppendLine(L($"        }}", nd));
                                                        }
                                                        break;
                                                    case "RSTOUT":
                                                        {
                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                            sbPLC.AppendLine(L($"        if(_result_)", nd));
                                                            sbPLC.AppendLine(L($"        {{", nd));
                                                            sbPLC.AppendLine(L($"            {doc.GetMemCode(fn.Args[0])} = false;", nd));
                                                            sbPLC.AppendLine(L($"        }}", nd));
                                                        }
                                                        break;
                                                    #endregion
                                                    #region MCS / MCSCLR
                                                    case "MCS":
                                                        {
                                                            int idx = Convert.ToInt32(fn.Args[0]);
                                                            sbPLC.AppendLine(L($"        MCS[{idx}].use = true;", nd));
                                                            sbPLC.AppendLine(L($"        MCS[{idx}].value = _result_;", nd));
                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));

                                                            sbPLC.AppendLine(L($"        _mc_ = _MCSCHK();", nd));
                                                        }
                                                        break;
                                                    case "MCSCLR":
                                                        {
                                                            int idx = Convert.ToInt32(fn.Args[0]);
                                                            sbPLC.AppendLine(L($"        MCS[{idx}].use = false;", nd));
                                                            sbPLC.AppendLine(L($"        MCS[{idx}].value = false;", nd));
                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));

                                                            sbPLC.AppendLine(L($"        _mc_ = _MCSCHK();", nd));
                                                        }
                                                        break;
                                                    #endregion
                                                    #region WXCHG
                                                    case "WXCHG":
                                                        {
                                                            var addr1 = doc.GetSymbolAddress(fn.Args[0]);
                                                            var addr2 = doc.GetSymbolAddress(fn.Args[1]);

                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                            sbPLC.AppendLine(L($"        if(_result_)", nd));
                                                            sbPLC.AppendLine(L($"        {{", nd));
                                                            sbPLC.AppendLine(L($"            var _tmp_ = {addr1};", nd));
                                                            sbPLC.AppendLine(L($"            {addr1} = {addr2};", nd));
                                                            sbPLC.AppendLine(L($"            {addr2} = _tmp_;", nd));
                                                            sbPLC.AppendLine(L($"        }}", nd));

                                                        }
                                                        break;
                                                    #endregion
                                                    #region DIST
                                                    case "DIST":
                                                        {
                                                            var addr1 = doc.GetSymbolAddress(fn.Args[0]);
                                                            var addr2 = doc.GetSymbolAddress(fn.Args[1]);
                                                            var cnt = Convert.ToInt32(fn.Args[2]);

                                                            var vaddr2 = AddressInfo.Parse(addr2);

                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                            sbPLC.AppendLine(L($"        if(_result_)", nd));
                                                            sbPLC.AppendLine(L($"        {{", nd));
                                                            if (cnt >= 1) sbPLC.AppendLine(L($"            {vaddr2.Code + (vaddr2.Index + 0)} = (unsigned short)(({addr1} & 0xF000) >> 12);", nd));
                                                            if (cnt >= 2) sbPLC.AppendLine(L($"            {vaddr2.Code + (vaddr2.Index + 1)} = (unsigned short)(({addr1} & 0x0F00) >> 8);", nd));
                                                            if (cnt >= 3) sbPLC.AppendLine(L($"            {vaddr2.Code + (vaddr2.Index + 2)} = (unsigned short)(({addr1} & 0x00F0) >> 4);", nd));
                                                            if (cnt >= 4) sbPLC.AppendLine(L($"            {vaddr2.Code + (vaddr2.Index + 3)} = (unsigned short)(({addr1} & 0x000F) >> 0);", nd));
                                                            sbPLC.AppendLine(L($"        }}", nd));

                                                        }
                                                        break;
                                                    #endregion
                                                    #region UNIT
                                                    case "UNIT":
                                                        {
                                                            var addr1 = doc.GetSymbolAddress(fn.Args[0]);
                                                            var addr2 = doc.GetSymbolAddress(fn.Args[1]);
                                                            var cnt = Convert.ToInt32(fn.Args[2]);

                                                            var vaddr1 = AddressInfo.Parse(addr1);

                                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                            sbPLC.AppendLine(L($"        if(_result_)", nd));
                                                            sbPLC.AppendLine(L($"        {{", nd));
                                                            sbPLC.AppendLine(L($"            int n=0;", nd));
                                                            if (cnt >= 1) sbPLC.AppendLine(L($"            n |= {vaddr1.Code + (vaddr1.Index + 0)} << 12;", nd));
                                                            if (cnt >= 2) sbPLC.AppendLine(L($"            n |= {vaddr1.Code + (vaddr1.Index + 1)} << 8;", nd));
                                                            if (cnt >= 3) sbPLC.AppendLine(L($"            n |= {vaddr1.Code + (vaddr1.Index + 2)} << 4;", nd));
                                                            if (cnt >= 4) sbPLC.AppendLine(L($"            n |= {vaddr1.Code + (vaddr1.Index + 3)} << 0;", nd));
                                                            sbPLC.AppendLine(L($"            {addr2} = n;", nd));
                                                            sbPLC.AppendLine(L($"        }}", nd));

                                                        }
                                                        break;
                                                        #endregion
                                                }
                                            }
                                            #endregion
                                            #region 연산 && 함수
                                            else
                                            {
                                                foreach (var cmd in GetWords(code)) code = code.Replace(cmd, doc.GetMemCode(cmd));
                                                sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                                sbPLC.AppendLine(L($"        if(_result_)", nd));
                                                sbPLC.AppendLine(L($"        {{", nd));
                                                using (var sr = new StringReader(code))
                                                {
                                                    string str;
                                                    while ((str = sr.ReadLine()) != null)
                                                        sbPLC.AppendLine(L($"            {str + (str.EndsWith(";") ? "" : ";")}", nd));
                                                }
                                                sbPLC.AppendLine(L($"        }}", nd));
                                            }
                                            #endregion
                                        }
                                        break;
                                    #endregion
                                    #region OUT_COIL
                                    case LadderItemType.OUT_COIL:
                                        {
                                            var nd = _out;
                                            string s = _out.Code;
                                            foreach (var cmd in GetWords(_out.Code)) s = s.Replace(cmd, doc.GetMemCode(cmd));
                                            sbPLC.AppendLine(L($"        {nm} = _result_;", nd));
                                            sbPLC.AppendLine(L($"        {s} = {nm};", nd));
                                        }
                                        break;
                                        #endregion
                                }
                            }
                            #endregion
                            sbPLC.AppendLine("    }                                                                                                        ");
                            sbPLC.AppendLine("    else                                                                                                     ");
                            sbPLC.AppendLine("    {                                                                                                        ");
                            #region MCS OFF
                            {
                                string nm = "__" + _out.Row + "_" + _out.Col;
                                switch (_out.ItemType)
                                {
                                    #region OUT_FUNC
                                    case LadderItemType.OUT_FUNC:
                                        {
                                            var nd = _out;
                                            var code = nd.Code.Trim();
                                            var fn = FuncInfo.Parse(code);
                                            #region 함수
                                            if (fn != null && LadderFunc.Funcs.Where(x => x.Name == fn.Name.ToUpper()).Count() > 0)
                                            {
                                                switch (fn.Name.ToUpper())
                                                {
                                                    #region TON, TAON, TOFF, TAOFF, TMON, TAMON
                                                    case "TON":
                                                    case "TAON":
                                                    case "TOFF":
                                                    case "TAOFF":
                                                    case "TMON":
                                                    case "TAMON":
                                                        {
                                                            var addr = doc.GetSymbolAddress(fn.Args[0]);

                                                            sbPLC.AppendLine(L($"        {nm} = false;", nd));
                                                            sbPLC.AppendLine(L($"        _TRST_({addr.Substring(1)});", nd));
                                                        }
                                                        break;
                                                    #endregion
                                                    #region SETOUT / RSTOUT
                                                    case "SETOUT":
                                                    case "RSTOUT":
                                                        {
                                                            sbPLC.AppendLine(L($"        {nm} = false;", nd));
                                                        }
                                                        break;
                                                    #endregion
                                                    #region MCS / MCSCLR
                                                    case "MCS":
                                                        {
                                                            sbPLC.AppendLine(L($"        {nm} = false;", nd));

                                                            sbPLC.AppendLine(L($"        _mc_ = _MCSCHK();", nd));
                                                        }
                                                        break;
                                                    case "MCSCLR":
                                                        {
                                                            int idx = Convert.ToInt32(fn.Args[0]);
                                                            sbPLC.AppendLine(L($"        MCS[{idx}].use = false;", nd));
                                                            sbPLC.AppendLine(L($"        MCS[{idx}].value = false;", nd));
                                                            sbPLC.AppendLine(L($"        {nm} = MCS[{idx}].use;", nd));

                                                            sbPLC.AppendLine(L($"        _mc_ = _MCSCHK();", nd));
                                                        }
                                                        break;
                                                        #endregion
                                                }
                                            }
                                            #endregion
                                        }
                                        break;
                                    #endregion
                                    #region OUT_COIL
                                    case LadderItemType.OUT_COIL:
                                        {
                                            var nd = _out;
                                            string s = _out.Code;
                                            foreach (var cmd in GetWords(_out.Code)) s = s.Replace(cmd, doc.GetMemCode(cmd));
                                            sbPLC.AppendLine(L($"        {nm} = false;", nd));
                                            sbPLC.AppendLine(L($"        {s} = false;", nd));
                                        }
                                        break;
                                        #endregion
                                }
                            }
                            #endregion
                            sbPLC.AppendLine("    }                                                                                                        ");
                        }
                        #endregion
                        sbPLC.AppendLine("    //==========================================================================================================  ");
                        sbPLC.AppendLine("");
                    }
                }
                #endregion
                #region Edge Reset
                foreach (var nd in doc.Ladders.Where(x => x.ItemType == LadderItemType.RISING_EDGE || x.ItemType == LadderItemType.FALLING_EDGE))
                {
                    string nm = "__" + nd.Row + "_" + nd.Col;

                    sbPLC.AppendLine(L($"    {nm}.reset();", nd));
                }
                sbPLC.AppendLine("");
                #endregion
                #region Debug
                {
                    sbPLC.AppendLine("    if(useDebug)");
                    sbPLC.AppendLine("    {");
                    int iP = 0, iW = 0;
                    foreach (var k in Debugs.Keys)
                    {
                        var v = Debugs[k];

                        if (v.Type == DebugInfoType.Contact)
                        {
                            sbPLC.AppendLine(R($"      Debugs[D{k}].Contact = {v.VCode};") + $"setBit(__DBGP, {iP}, {v.VCode});");
                            iP++;
                        }
                        else if (v.Type == DebugInfoType.Word)
                        {
                            sbPLC.AppendLine(R($"      Debugs[D{k}].Word = {v.VCode};") + $"__DBGW[{iW}] = {v.VCode};");
                            iW++;
                        }
                        else if (v.Type == DebugInfoType.DWord)
                        {
                            sbPLC.AppendLine(R($"      Debugs[D{k}].DWord = {v.VCode};") + $"MWDW(__DBGW, {iW}) = {v.VCode};");
                            iW += 2;
                        }
                        else if (v.Type == DebugInfoType.Float)
                        {
                            sbPLC.AppendLine(R($"      Debugs[D{k}].Float = {v.VCode};") + $"MWR(__DBGW, {iW}) = {v.VCode};");
                            iW += 2;
                        }
                        else if (v.Type == DebugInfoType.Timer)
                        {
                            sbPLC.AppendLine(R($"      Debugs[D{k}].Timer = {v.TCode};") + $"__DBGW[{iW}] = {v.VCode};");
                            sbPLC.AppendLine(R($"      Debugs[D{k}].Contact = {v.VCode};") + $"setBit(__DBGP, {iP}, {v.VCode});");
                            iW++;
                            iP++;
                        }
                    }
                    sbPLC.AppendLine("");
                    sbPLC.AppendLine("      slave->loop();");
                    sbPLC.AppendLine("    }");
                    sbPLC.AppendLine("");
                }
                #endregion
                #region Out Hardware
                foreach (var v in doc.Hardwares)
                {
                    if (v.Mode == "OUT") sbPLC.AppendLine($"    digitalWrite({v.Pin}, {v.Address});");
                    if (v.Mode == "DA") sbPLC.AppendLine($"    analogWrite({v.Pin}, {v.Address});");
                }
                sbPLC.AppendLine("");
                #endregion
                sbPLC.AppendLine("    _SR_BEGIN = false;");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                #endregion
                #region ladderDebug
                sbPLC.AppendLine($"void ladderDebug(HardwareSerial&  serial, long baudrate)");
                sbPLC.AppendLine($"{{");
                sbPLC.AppendLine($"    slave = new ModbusRTUSlave(serial);");
                sbPLC.AppendLine($"    slave->addBitArea(0xC000, __DBGP, {DBGP_CNT});");
                sbPLC.AppendLine($"    slave->addWordArea(0xE000, __DBGW, {DBGW_CNT});");
                sbPLC.AppendLine($"    slave->begin(1, baudrate);");
                sbPLC.AppendLine($"    useDebug=true;");
                sbPLC.AppendLine($"}}");
                sbPLC.AppendLine($"");
                #endregion
                #region ladderTick
                sbPLC.AppendLine("void ladderTick()");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    _CNT100++;");
                sbPLC.AppendLine("    _CNT1000++;");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("    _100_ = _CNT100 >= 10;");
                sbPLC.AppendLine("    _1000_ = _CNT1000 >= 100;");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("    _SR_10R = true;");
                sbPLC.AppendLine("    _SR_F10R = !_SR_F10R;");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("    if (_CNT100 >= 10)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      _SR_100R = true;");
                sbPLC.AppendLine("      _SR_F100R = !_SR_F100R;");
                sbPLC.AppendLine("      _CNT100 = 0;");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("    if (_CNT1000 >= 100)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      _SR_1000R = true;");
                sbPLC.AppendLine("      _SR_F1000R = !_SR_F1000R;");
                sbPLC.AppendLine("      _CNT1000 = 0;");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("    for(int i=0;i<T_COUNT;i++)");
                sbPLC.AppendLine("      if(T[i]->Type != NONE)");
                sbPLC.AppendLine("        T[i]->tick(_100_, _1000_);");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                #endregion
                #region function
                #region _MCSCHK_
                sbPLC.AppendLine("bool _MCSCHK_()");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    bool ret = true;");
                sbPLC.AppendLine("    for (int i = 0; i < MCSCNT; i++)");
                sbPLC.AppendLine("      if (MCS[i].use) ret &= MCS[i].value;");
                sbPLC.AppendLine("    return ret;    ");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("    ");
                #endregion
                #region _TCHK_ / _TRST_
                sbPLC.AppendLine("bool _TCHK_(int idx)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    bool ret = false;");
                sbPLC.AppendLine("    if (idx >= 0 && idx < T_COUNT) ret = T[idx]->relay();");
                sbPLC.AppendLine("    return ret;");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("void _TRST_(int idx)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    if (idx >= 0 && idx < T_COUNT) T[idx]->reset();");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                #endregion
                #region TON / TAON / TOFF / TAOFF / TMON / TAMON
                sbPLC.AppendLine("void TON(int idx, int val, bool result)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    if (result)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("            if (T[idx]->Type == NONE)");
                sbPLC.AppendLine("            {");
                sbPLC.AppendLine("                __T[idx] = 0;");
                sbPLC.AppendLine("                T[idx]->Goal = val;");
                sbPLC.AppendLine("                T[idx]->Type = F_TON;");
                sbPLC.AppendLine("            }");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("    else T[idx]->reset();");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("void TAON(int idx, int val, bool result)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    if (result)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      if (T[idx]->Type == NONE)");
                sbPLC.AppendLine("      {");
                sbPLC.AppendLine("        __T[idx] = 0;");
                sbPLC.AppendLine("        T[idx]->Goal = val;");
                sbPLC.AppendLine("        T[idx]->Type = F_TAON;");
                sbPLC.AppendLine("      }");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("    else T[idx]->reset();");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("void TOFF(int idx, int val, bool result)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    if (result)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      __T[idx] = val;");
                sbPLC.AppendLine("      T[idx]->Goal = 0;");
                sbPLC.AppendLine("      T[idx]->Type = F_TOFF;");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("    else");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      if (T[idx]->Type == F_TOFF && __T[idx] == 0) T[idx]->reset();");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("void TAOFF(int idx, int val, bool result)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    if (result)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      __T[idx] = val;");
                sbPLC.AppendLine("      T[idx]->Goal = 0;");
                sbPLC.AppendLine("      T[idx]->Type = F_TAOFF;");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("    else");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      if (T[idx]->Type == F_TAOFF && __T[idx] == 0) T[idx]->reset();");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("void TMON(int idx, int val, bool result)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    if (result)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      if (T[idx]->Type == NONE)");
                sbPLC.AppendLine("      {");
                sbPLC.AppendLine("        __T[idx] = 0;");
                sbPLC.AppendLine("        T[idx]->Goal = val;");
                sbPLC.AppendLine("        T[idx]->Type = F_TMON;");
                sbPLC.AppendLine("      }");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                sbPLC.AppendLine("void TAMON(int idx, int val, bool result)");
                sbPLC.AppendLine("{");
                sbPLC.AppendLine("    if (result)");
                sbPLC.AppendLine("    {");
                sbPLC.AppendLine("      if (T[idx]->Type == NONE)");
                sbPLC.AppendLine("      {");
                sbPLC.AppendLine("        __T[idx] = 0;");
                sbPLC.AppendLine("        T[idx]->Goal = val;");
                sbPLC.AppendLine("        T[idx]->Type = F_TAMON;");
                sbPLC.AppendLine("      }");
                sbPLC.AppendLine("    }");
                sbPLC.AppendLine("}");
                sbPLC.AppendLine("");
                #endregion
                #endregion

                ret.Add("PLC.ino", sbPLC.ToString());
            }
            #endregion
            #region Comm.ino
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
                #endregion
                var sbCOM = new StringBuilder();
                #region #include 
                {
                    var lk = ls.ToLookup(x => x.Name);
                    if (useEth) sbCOM.AppendLine("#include <Ethernet.h>");
                    foreach (var v in lk)
                    {
                        if (v.Key == LadderComm.Mqtt.Name) sbCOM.AppendLine("#include <PubSubClient.h>");
                        else if (v.Key == LadderComm.ModbusRtuSlave.Name) sbCOM.AppendLine("#include <ModbusRTUSlave.h>");
                        else if (v.Key == LadderComm.ModbusTcpSlave.Name) sbCOM.AppendLine("#include <ModbusTcpSlave.h>");
                    }
                    sbCOM.AppendLine("");
                }
                #endregion
                #region declare
                {
                    foreach (var v in ls)
                    {
                        var idx = ls.IndexOf(v);
                        if (v.Name == LadderComm.ModbusRtuSlave.Name)
                        {
                            var vc = v as LcModbusRtuSlave;
                            sbCOM.AppendLine($"ModbusRTUSlave comm{idx}({vc.Port});");
                        }
                        if (v.Name == LadderComm.ModbusTcpSlave.Name)
                        {
                            var vc = v as LcModbusTcpSlave;
                            sbCOM.AppendLine($"ModbusTCPSlave comm{idx};");
                            useEth = true;
                        }
                        if (v.Name == LadderComm.Mqtt.Name)
                        {
                            var vc = v as LcMqtt;
                            sbCOM.AppendLine($"EthernetClient eth{idx};");
                            sbCOM.AppendLine($"PubSubClient comm{idx}(eth{idx});");
                            useEth = true;
                        }
                    }

                    if (useEth)
                    {
                        sbCOM.AppendLine("");
                        sbCOM.AppendLine("byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };");
                        sbCOM.AppendLine("IPAddress ip(LOC_IP);");
                        foreach (var v in ls.Where(x => x.Name == LadderComm.Mqtt.Name).Select(x => x as LcMqtt))
                        {
                            var idx = ls.IndexOf(v);
                            sbCOM.AppendLine($"IPAddress server_comm{idx}({v.BrokerIP.Replace(".", ",")});");
                        }
                    }

                    sbCOM.AppendLine("");
                    foreach (var v in ls.Where(x => x.Name == LadderComm.Mqtt.Name).Select(x => x as LcMqtt))
                    {
                        var idx = ls.IndexOf(v);
                        var vc = v as LcMqtt;
                        sbCOM.AppendLine($"unsigned long comm{idx}_lastConnectTime;");
                    }

                    sbCOM.AppendLine("");
                    foreach (var v in ls.Where(x => x.Name == LadderComm.Mqtt.Name).Select(x => x as LcMqtt))
                    {
                        var idx = ls.IndexOf(v);
                        var vc = v as LcMqtt;
                        foreach (var pub in vc.Pubs)
                        {
                            var idx2 = vc.Pubs.IndexOf(pub);
                            AddressInfo addr;
                            if (AddressInfo.TryParse(doc.GetSymbolAddress(pub.Address), out addr))
                            {
                                if (addr.Type == AddressType.BIT || addr.Type == AddressType.BIT)
                                    sbCOM.AppendLine($"bool comm{idx}_pub{idx2};");
                                if (addr.Type == AddressType.WORD)
                                    sbCOM.AppendLine($"unsigned short comm{idx}_pub{idx2};");
                                if (addr.Type == AddressType.DWORD)
                                    sbCOM.AppendLine($"unsigned long comm{idx}_pub{idx2};");
                                if (addr.Type == AddressType.FLOAT)
                                    sbCOM.AppendLine($"float comm{idx}_pub{idx2};");
                            }
                        }
                    }

                    sbCOM.AppendLine("");
                }
                #endregion
                #region func
                foreach (var v in ls.Where(x => x.Name == LadderComm.Mqtt.Name).Select(x => x as LcMqtt))
                {
                    var idx = ls.IndexOf(v);
                    var vc = v as LcMqtt;
                    sbCOM.AppendLine($"void comm{idx}_received(char* topic, byte* payload, unsigned int length);");
                    sbCOM.AppendLine($"void comm{idx}_reconnect();");
                }
                sbCOM.AppendLine("");
                #endregion

                sbCOM.AppendLine("void commSetup()");
                sbCOM.AppendLine("{");
                #region begin
                if (useEth)
                {
                    sbCOM.AppendLine($"    Ethernet.begin(mac, ip);");
                    sbCOM.AppendLine($"");
                }

                foreach (var v in ls)
                {
                    var idx = ls.IndexOf(v);
                    if (v.Name == LadderComm.ModbusRtuSlave.Name)
                    {
                        var vc = v as LcModbusRtuSlave;
                        sbCOM.AppendLine($"    comm{idx}.addBitArea(0x{vc.P_BaseAddress.ToString("X")}, __P, {acP});");
                        sbCOM.AppendLine($"    comm{idx}.addBitArea(0x{vc.M_BaseAddress.ToString("X")}, __M, {acM});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.T_BaseAddress.ToString("X")}, __T, {acT});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.C_BaseAddress.ToString("X")}, __C, {acC});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.D_BaseAddress.ToString("X")}, __D, {acD});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.WP_BaseAddress.ToString("X")}, (unsigned short*)__P, {acP/2});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.WM_BaseAddress.ToString("X")}, (unsigned short*)__M, {acM/2});");
                        sbCOM.AppendLine($"    comm{idx}.begin({vc.Slave}, {vc.Baudrate});");
                        sbCOM.AppendLine($"");
                    }

                    if (v.Name == LadderComm.ModbusTcpSlave.Name)
                    {
                        var vc = v as LcModbusTcpSlave;
                        sbCOM.AppendLine($"    comm{idx}.addBitArea(0x{vc.P_BaseAddress.ToString("X")}, __P, {acP});");
                        sbCOM.AppendLine($"    comm{idx}.addBitArea(0x{vc.M_BaseAddress.ToString("X")}, __M, {acM});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.T_BaseAddress.ToString("X")}, __T, {acT});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.C_BaseAddress.ToString("X")}, __C, {acC});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.D_BaseAddress.ToString("X")}, __D, {acD});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.WP_BaseAddress.ToString("X")}, (unsigned short*)__P, {acP / 2});");
                        sbCOM.AppendLine($"    comm{idx}.addWordArea(0x{vc.WM_BaseAddress.ToString("X")}, (unsigned short*)__M, {acM / 2});");
                        sbCOM.AppendLine($"    comm{idx}.begin({vc.Slave});");
                        sbCOM.AppendLine($"");
                    }

                    if (v.Name == LadderComm.Mqtt.Name)
                    {
                        var vc = v as LcMqtt;
                        sbCOM.AppendLine($"    comm{idx}.setServer(server_comm{idx}, 1883);");
                        sbCOM.AppendLine($"    comm{idx}.setCallback(comm{idx}_received);");
                    }
                }
                sbCOM.AppendLine("");
                #endregion
                sbCOM.AppendLine("}");
                sbCOM.AppendLine("");
                sbCOM.AppendLine("void commLoop()");
                sbCOM.AppendLine("{");
                #region loop
                foreach (var v in ls.Where(x => x.Name == LadderComm.Mqtt.Name).Select(x => x as LcMqtt))
                {
                    var idx = ls.IndexOf(v);

                    foreach(var pub in v.Pubs)
                    {
                        var sadr = doc.GetMemCode(pub.Address);
                        var idx2 = v.Pubs.IndexOf(pub);
                        sbCOM.AppendLine($"    if(comm{idx}_pub{idx2} != {sadr})");
                        sbCOM.AppendLine($"    {{");
                        sbCOM.AppendLine($"      char sbuf[20];");
                        sbCOM.AppendLine($"      sprintf(sbuf, \"%ld\", {sadr});");
                        sbCOM.AppendLine($"      comm{idx}_pub{idx2} = {sadr};");
                        sbCOM.AppendLine($"      comm{idx}.publish(\"{pub.Topic}\", sbuf);");
                        sbCOM.AppendLine($"    }}");
                        sbCOM.AppendLine("");
                    }
                }

                foreach (var v in ls)
                {
                    var idx = ls.IndexOf(v);
                    if (v.Name == LadderComm.ModbusRtuSlave.Name)
                    {
                        var vc = v as LcModbusRtuSlave;
                        sbCOM.AppendLine($"    comm{idx}.loop();");
                    }
                    if (v.Name == LadderComm.ModbusTcpSlave.Name)
                    {
                        var vc = v as LcModbusTcpSlave;
                        sbCOM.AppendLine($"    comm{idx}.loop();");
                    }
                    if (v.Name == LadderComm.Mqtt.Name)
                    {
                        var vc = v as LcMqtt;
                        sbCOM.AppendLine($"    comm{idx}.loop();        comm{idx}_reconnect();");
                    }
                }
                #endregion
                sbCOM.AppendLine("}");
                sbCOM.AppendLine("");
                #region mqtt
                foreach (var v in ls)
                {
                    var idx = ls.IndexOf(v);
                    if (v.Name == LadderComm.Mqtt.Name)
                    {
                        var vc = v as LcMqtt;
                        #region received
                        sbCOM.AppendLine($"void comm{idx}_received(char* topic, byte* payload, unsigned int length)");
                        sbCOM.AppendLine($"{{");
                        foreach (var sub in vc.Subs)
                        {
                            sbCOM.AppendLine($"  if(strcmp(topic, \"{sub.Topic}\") == 0)");
                            sbCOM.AppendLine($"  {{");
                            sbCOM.AppendLine($"    {doc.GetMemCode(sub.Address)} = atoi((char*)payload);");
                            sbCOM.AppendLine($"  }}");
                        }
                        sbCOM.AppendLine($"}}");
                        sbCOM.AppendLine($"");
                        #endregion
                        #region reconnect
                        sbCOM.AppendLine($"void comm{idx}_reconnect()");
                        sbCOM.AppendLine($"{{");
                        sbCOM.AppendLine($"  if (!comm{idx}.connected())");
                        sbCOM.AppendLine($"  {{");
                        sbCOM.AppendLine($"    unsigned long _time = millis();");
                        sbCOM.AppendLine($"    if ((_time > comm{idx}_lastConnectTime && _time - comm{idx}_lastConnectTime >= 1000) || (_time < comm{idx}_lastConnectTime))");
                        sbCOM.AppendLine($"    {{");
                        sbCOM.AppendLine($"        comm{idx}_lastConnectTime = _time;");
                        sbCOM.AppendLine($"        if (comm{idx}.connect(\"comm{idx.ToString("00000")}\"))");
                        sbCOM.AppendLine($"        {{");
                        foreach (var sub in vc.Subs)
                            sbCOM.AppendLine($"            comm{idx}.subscribe(\"{sub.Topic}\");");
                        sbCOM.AppendLine($"        }}");
                        sbCOM.AppendLine($"    }}");
                        sbCOM.AppendLine($"  }}");
                        sbCOM.AppendLine($"}}");
                        sbCOM.AppendLine($"");
                        #endregion
                    }
                }
                sbCOM.AppendLine("");
                #endregion
                sbCOM.AppendLine("");
                ret.Add("Comm.ino", sbCOM.ToString());
            }
            #endregion
            #region syms.h
            {
                #region var
                var acP = Convert.ToInt32(Math.Ceiling(doc.P_Count / 8.0));
                var acM = Convert.ToInt32(Math.Ceiling(doc.M_Count / 8.0));
                var acT = doc.T_Count;
                var acC = doc.C_Count;
                var acD = doc.D_Count;
                #endregion

                var sbSyms = new StringBuilder();
                #region MWI / MBI / MWR / MWS
                sbSyms.AppendLine("#define MWI(v,i)     (*((MW*)(v+i)))");
                sbSyms.AppendLine("#define MBI(v,i)     (*((MB*)(v+i)))");
                sbSyms.AppendLine("#define MWR(v,i)     (*((float*)(v+i)))");
                sbSyms.AppendLine("#define MWDW(v,i)    (*((unsigned long*)(v+i)))");
                sbSyms.AppendLine("#define MWS(v,i)     ((char*)(v+i))");
                sbSyms.AppendLine("");
                #endregion
                #region count
                sbSyms.AppendLine($"#define P_COUNT           {doc.P_Count}");
                sbSyms.AppendLine($"#define M_COUNT           {doc.M_Count}");
                sbSyms.AppendLine($"#define T_COUNT           {doc.T_Count}");
                sbSyms.AppendLine($"#define C_COUNT           {doc.C_Count}");
                sbSyms.AppendLine($"#define D_COUNT           {doc.D_Count}");
                sbSyms.AppendLine("");
                #endregion
                #region addresses
                #region P
                for (int i = 0; i < doc.P_Count; i++)
                {
                    sbSyms.AppendLine($"#define P{i}           MBI(__P, {i / 8}).bit{(i % 8).ToString("X")}");
                }
                #endregion
                #region M
                for (int i = 0; i < doc.M_Count; i++)
                {
                    sbSyms.AppendLine($"#define M{i}           MBI(__M, {i / 8}).bit{(i % 8).ToString("X")}");
                }
                #endregion
                #region T
                for (int i = 0; i < doc.T_Count; i++)
                {
                    sbSyms.AppendLine($"#define T{i}           __T[{i}]");
                }
                #endregion
                #region C
                for (int i = 0; i < doc.C_Count; i++)
                {
                    sbSyms.AppendLine($"#define C{i}           __C[{i}]");
                    for (int j = 0; j < 16; j++)
                        sbSyms.AppendLine($"#define C{i}_{j.ToString("X")}           MWI(__C, {i}).bit{j.ToString("X")}");
                    sbSyms.AppendLine($"#define C{i}_R           MWR(__C, {i})");
                    sbSyms.AppendLine($"#define C{i}_S           MWS(__C, {i})");
                    sbSyms.AppendLine($"#define C{i}_DW          MWDW(__C, {i})");
                }
                #endregion
                #region D
                for (int i = 0; i < doc.D_Count; i++)
                {
                    sbSyms.AppendLine($"#define D{i}           __D[{i}]");
                    for (int j = 0; j < 16; j++)
                        sbSyms.AppendLine($"#define D{i}_{j.ToString("X")}           MWI(__D, {i}).bit{j.ToString("X")}");
                    sbSyms.AppendLine($"#define D{i}_R           MWR(__D, {i})");
                    sbSyms.AppendLine($"#define D{i}_S           MWS(__D, {i})");
                    sbSyms.AppendLine($"#define D{i}_DW          MWDW(__D, {i})");
                }
                #endregion
                sbSyms.AppendLine("");
                #endregion
                #region symbols
                foreach (var sym in doc.Symbols)
                {
                    sbSyms.AppendLine($"#define {sym.SymbolName}           {sym.Address.Replace(".", "_")}");
                }
                sbSyms.AppendLine("");
                #endregion
                #region P/M/T/C/D
                sbSyms.AppendLine($"unsigned char   __P[{acP}];");
                sbSyms.AppendLine($"unsigned char   __M[{acM}];");
                sbSyms.AppendLine($"unsigned short  __T[{acT}];");
                sbSyms.AppendLine($"unsigned short  __C[{acC}];");
                sbSyms.AppendLine($"unsigned short  __D[{acD}];");
                sbSyms.AppendLine("");
                #endregion
                #region enums
                sbSyms.AppendLine("");
                sbSyms.AppendLine("enum TimerType {  NONE = 0, F_TON = 1, F_TAON = 2, F_TOFF = 3, F_TAOFF = 4, F_TMON = 5, F_TAMON = 6 };");
                sbSyms.AppendLine("enum DebugType {  D_Contact, D_Timer, D_Word, D_Float, D_DWord, D_Text };");
                sbSyms.AppendLine("");
                #endregion
                #region struct
                #region struct MW
                sbSyms.AppendLine("typedef struct");
                sbSyms.AppendLine("{");
                sbSyms.AppendLine("    bool bit0 : 1;");
                sbSyms.AppendLine("    bool bit1 : 1;");
                sbSyms.AppendLine("    bool bit2 : 1;");
                sbSyms.AppendLine("    bool bit3 : 1;");
                sbSyms.AppendLine("    bool bit4 : 1;");
                sbSyms.AppendLine("    bool bit5 : 1;");
                sbSyms.AppendLine("    bool bit6 : 1;");
                sbSyms.AppendLine("    bool bit7 : 1;");
                sbSyms.AppendLine("    bool bit8 : 1;");
                sbSyms.AppendLine("    bool bit9 : 1;");
                sbSyms.AppendLine("    bool bitA : 1;");
                sbSyms.AppendLine("    bool bitB : 1;");
                sbSyms.AppendLine("    bool bitC : 1;");
                sbSyms.AppendLine("    bool bitD : 1;");
                sbSyms.AppendLine("    bool bitE : 1;");
                sbSyms.AppendLine("    bool bitF : 1;");
                sbSyms.AppendLine("} MW;");
                sbSyms.AppendLine("");
                #endregion
                #region struct MB
                sbSyms.AppendLine("typedef struct");
                sbSyms.AppendLine("{");
                sbSyms.AppendLine("    bool bit0 : 1;");
                sbSyms.AppendLine("    bool bit1 : 1;");
                sbSyms.AppendLine("    bool bit2 : 1;");
                sbSyms.AppendLine("    bool bit3 : 1;");
                sbSyms.AppendLine("    bool bit4 : 1;");
                sbSyms.AppendLine("    bool bit5 : 1;");
                sbSyms.AppendLine("    bool bit6 : 1;");
                sbSyms.AppendLine("    bool bit7 : 1;");
                sbSyms.AppendLine("} MB;");
                sbSyms.AppendLine("");
                #endregion
                #region struct MCSV
                sbSyms.AppendLine("typedef struct");
                sbSyms.AppendLine("{");
                sbSyms.AppendLine("  bool use;");
                sbSyms.AppendLine("  bool value;");
                sbSyms.AppendLine("} MCSV;");
                sbSyms.AppendLine("");
                #endregion
                #region struct DebugInfo
                sbSyms.AppendLine("typedef struct");
                sbSyms.AppendLine("{");
                sbSyms.AppendLine("  DebugType Type;");
                sbSyms.AppendLine("  int Row;");
                sbSyms.AppendLine("  int Column;");
                sbSyms.AppendLine("  bool Contact;");
                sbSyms.AppendLine("  int Timer;");
                sbSyms.AppendLine("  int Word;");
                sbSyms.AppendLine("  float Float;");
                sbSyms.AppendLine("  long DWord;");
                sbSyms.AppendLine("  char* Text;");
                sbSyms.AppendLine("} DebugInfo;");
                sbSyms.AppendLine("");
                #endregion
                #endregion
                #region classes
                #region class EDGE
                sbSyms.AppendLine("class EDGE");
                sbSyms.AppendLine("{");
                sbSyms.AppendLine("  public :");
                sbSyms.AppendLine("    bool value;");
                sbSyms.AppendLine("    bool valueMerge;");
                sbSyms.AppendLine("   ");
                sbSyms.AppendLine("    void load()");
                sbSyms.AppendLine("    {");
                sbSyms.AppendLine("        temp = previous;");
                sbSyms.AppendLine("        valueMerge = false;");
                sbSyms.AppendLine("    }");
                sbSyms.AppendLine("");
                sbSyms.AppendLine("    bool rising(bool value)");
                sbSyms.AppendLine("    {");
                sbSyms.AppendLine("        this->value = this->temp != value && !this->temp && value;");
                sbSyms.AppendLine("        this->valueMerge |= value;");
                sbSyms.AppendLine("        return this->value;");
                sbSyms.AppendLine("    }");
                sbSyms.AppendLine("");
                sbSyms.AppendLine("    bool falling(bool value)");
                sbSyms.AppendLine("    {");
                sbSyms.AppendLine("        this->value = this->temp != value && this->temp && !value;");
                sbSyms.AppendLine("        this->valueMerge |= value;");
                sbSyms.AppendLine("        return this->value;");
                sbSyms.AppendLine("    }");
                sbSyms.AppendLine("");
                sbSyms.AppendLine("    void off()    {   this->value = false;            }");
                sbSyms.AppendLine("    void on()     {   this->value = true;             }");
                sbSyms.AppendLine("    void reset()  {   this->previous = this->valueMerge;    }");
                sbSyms.AppendLine("  ");
                sbSyms.AppendLine("  private :");
                sbSyms.AppendLine("    bool previous;");
                sbSyms.AppendLine("    bool temp;");
                sbSyms.AppendLine("};");
                sbSyms.AppendLine("");
                #endregion
                #region class TMR
                sbSyms.AppendLine("class TMR");
                sbSyms.AppendLine("{");
                sbSyms.AppendLine("  public :");
                sbSyms.AppendLine("    unsigned short Goal;");
                sbSyms.AppendLine("    TimerType Type = NONE;");
                sbSyms.AppendLine("    ");
                sbSyms.AppendLine("    TMR(long idx)");
                sbSyms.AppendLine("    {");
                sbSyms.AppendLine("      this->idx = idx;");
                sbSyms.AppendLine("      this->Type = NONE;");
                sbSyms.AppendLine("      this->Goal = 0;");
                sbSyms.AppendLine("    }");
                sbSyms.AppendLine("  ");
                sbSyms.AppendLine("    bool relay()");
                sbSyms.AppendLine("    {");
                sbSyms.AppendLine("        bool ret = false;");
                sbSyms.AppendLine("        switch (Type)");
                sbSyms.AppendLine("        {");
                sbSyms.AppendLine("            case F_TON:");
                sbSyms.AppendLine("            case F_TAON:");
                sbSyms.AppendLine("                ret = __T[idx] == Goal;");
                sbSyms.AppendLine("                break;");
                sbSyms.AppendLine("            case F_TOFF:");
                sbSyms.AppendLine("            case F_TAOFF:");
                sbSyms.AppendLine("                ret = __T[idx] > 0;");
                sbSyms.AppendLine("                break;");
                sbSyms.AppendLine("            case F_TMON:");
                sbSyms.AppendLine("            case F_TAMON:");
                sbSyms.AppendLine("                ret = true;");
                sbSyms.AppendLine("                break;");
                sbSyms.AppendLine("        }");
                sbSyms.AppendLine("        return ret;");
                sbSyms.AppendLine("    }");
                sbSyms.AppendLine("");
                sbSyms.AppendLine("    void reset()");
                sbSyms.AppendLine("    {");
                sbSyms.AppendLine("        __T[idx] = Goal = 0;");
                sbSyms.AppendLine("        Type = NONE;");
                sbSyms.AppendLine("    }");
                sbSyms.AppendLine("");
                sbSyms.AppendLine("    void tick(bool _100_, bool _1000_)");
                sbSyms.AppendLine("    {");
                sbSyms.AppendLine("        switch (Type)");
                sbSyms.AppendLine("        {");
                sbSyms.AppendLine("            case F_TON:               __T[idx] = (unsigned short)(__T[idx] < Goal ? __T[idx] + 1 : Goal);    break;");
                sbSyms.AppendLine("            case F_TAON:  if (_100_)  __T[idx] = (unsigned short)(__T[idx] < Goal ? __T[idx] + 1 : Goal);    break;");
                sbSyms.AppendLine("            case F_TOFF:              __T[idx] = (unsigned short)(__T[idx] > 0    ? __T[idx] - 1 : 0);          break;");
                sbSyms.AppendLine("            case F_TAOFF: if (_100_)  __T[idx] = (unsigned short)(__T[idx] > 0    ? __T[idx] - 1 : 0);          break;");
                sbSyms.AppendLine("            case F_TMON:  ");
                sbSyms.AppendLine("                        {            ");
                sbSyms.AppendLine("                                    __T[idx] = (unsigned short)(__T[idx] < Goal ? __T[idx] + 1 : Goal);  ");
                sbSyms.AppendLine("                                    if (__T[idx] == Goal) {  __T[idx] = Goal = 0;   Type = NONE;  }");
                sbSyms.AppendLine("                        }");
                sbSyms.AppendLine("                        break;");
                sbSyms.AppendLine("            case F_TAMON: ");
                sbSyms.AppendLine("                        if (_100_)");
                sbSyms.AppendLine("                        {");
                sbSyms.AppendLine("                                    __T[idx] = (unsigned short)(__T[idx] < Goal ? __T[idx] + 1 : Goal);");
                sbSyms.AppendLine("                                    if (__T[idx] == Goal) {  __T[idx] = Goal = 0;   Type = NONE;  }");
                sbSyms.AppendLine("                        }");
                sbSyms.AppendLine("                        break;");
                sbSyms.AppendLine("        }");
                sbSyms.AppendLine("    }");
                sbSyms.AppendLine("  private :");
                sbSyms.AppendLine("    long idx;  ");
                sbSyms.AppendLine("};");
                sbSyms.AppendLine("");
                #endregion
                #endregion

                ret.Add("syms.h", sbSyms.ToString());
            }
            #endregion
            return ret;
        }
        #endregion

        #region CheckVertialEndNodes
        private static bool CheckVertialEndNodes(List<LadderItem> ls)
        {
            bool ret = false;
            var nd = ls.LastOrDefault();
            if (nd != null)
            {
                if (nd.ItemType == LadderItemType.NONE)
                {
                    for (int i = ls.Count - 2; i >= 0; i--)
                    {
                        var v = ls[i];
                        if (v.ItemType == LadderItemType.NONE) nd = v;
                        else { nd = v; break; }
                    }

                    if (nd.ItemType == LadderItemType.LINE_H ||
                        nd.ItemType == LadderItemType.IN_A || nd.ItemType == LadderItemType.IN_B ||
                        nd.ItemType == LadderItemType.NOT ||
                        nd.ItemType == LadderItemType.RISING_EDGE || nd.ItemType == LadderItemType.FALLING_EDGE) ret = true;
                }
            }
            return ret;
        }
        #endregion
    }
}
