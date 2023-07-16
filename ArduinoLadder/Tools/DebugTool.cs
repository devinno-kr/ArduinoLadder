using ArduinoLadder.Ladder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoLadder.Tools
{
    public class DebugTool
    {
        #region Debugs
        internal static Dictionary<string, DebugInfo> GetDebugs(LadderDocument doc)
        {
            var Debugs = new Dictionary<string, DebugInfo>();
            #region Debugs
            foreach (var v in doc.Ladders.OrderBy(x => x.Row).ThenBy(x => x.Col))
            {
                var k = $"__{v.Row}_{v.Col}__";
                if (v.Code != null && !v.Code.StartsWith("'"))
                {
                    switch (v.ItemType)
                    {
                        case LadderItemType.IN_A:
                        case LadderItemType.IN_B:
                        case LadderItemType.NOT:
                        case LadderItemType.OUT_COIL:
                            if (!Debugs.ContainsKey(k)) Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col });
                            Debugs[k].Type = DebugInfoType.Contact;
                            Debugs[k].VCode = $"__{v.Row}_{v.Col}";
                            break;

                        case LadderItemType.OUT_FUNC:
                            if (!Debugs.ContainsKey(k)) Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col });


                            var cd = v.Code.ToUpper();
                            if (cd.StartsWith("TON") || cd.StartsWith("TAON") || cd.StartsWith("TOFF") || cd.StartsWith("TAOFF") || cd.StartsWith("TMON") || cd.StartsWith("TAMON"))
                            {
                                Debugs[k].Type = DebugInfoType.Timer;
                                Debugs[k].VCode = $"__{v.Row}_{v.Col}";
                                var fn = FuncInfo.Parse(v.Code);
                                if (fn != null && fn.Args.Count == 2 && doc.ValidSymbol(fn.Args[0]))
                                    Debugs[k].TCode = $"{doc.GetMemCode(fn.Args[0])}";
                            }
                            else
                            {
                                Debugs[k].Type = DebugInfoType.Contact;
                                Debugs[k].VCode = $"__{v.Row}_{v.Col}";
                            }
                            break;

                        case LadderItemType.RISING_EDGE:
                        case LadderItemType.FALLING_EDGE:
                            if (!Debugs.ContainsKey(k)) Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col });
                            Debugs[k].Type = DebugInfoType.Contact;
                            Debugs[k].VCode = $"__{v.Row}_{v.Col}.value";
                            break;
                    }
                }

                if (v.Code.StartsWith("''") && doc.ValidSymbol(v.Code.Substring(2).Trim()))
                {
                    var saddr = doc.GetSymbolAddress(v.Code.Substring(2).Trim());
                    var addr = AddressInfo.Parse(saddr);
                    if (addr != null)
                    {
                        if (addr.Type == AddressType.WORD)
                        {
                            if (!Debugs.ContainsKey(k))
                            {
                                Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col, Type = DebugInfoType.Word });
                                Debugs[k].VCode = doc.GetMemCode(saddr);
                            }
                        }
                        else if (addr.Type == AddressType.FLOAT)
                        {
                            if (!Debugs.ContainsKey(k))
                            {
                                Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col, Type = DebugInfoType.Float });
                                Debugs[k].VCode = doc.GetMemCode(saddr);
                            }
                        }
                        else if (addr.Type == AddressType.DWORD)
                        {
                            if (!Debugs.ContainsKey(k))
                            {
                                Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col, Type = DebugInfoType.DWord });
                                Debugs[k].VCode = doc.GetMemCode(saddr);
                            }
                        }
                        /*
                        else if (addr.Type == AddressType.TEXT)
                        {
                            if (!Debugs.ContainsKey(k))
                            {
                                Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col, Type = DebugInfoType.Text });
                                Debugs[k].VCode = doc.GetMemCode(saddr);
                            }
                        }
                        */
                        else if (addr.Type == AddressType.BIT || addr.Type == AddressType.BIT_WORD)
                        {
                            if (!Debugs.ContainsKey(k))
                            {
                                Debugs.Add(k, new DebugInfo() { Row = v.Row, Column = v.Col, Type = DebugInfoType.Contact });
                                Debugs[k].VCode = doc.GetMemCode(saddr);
                            }
                        }
                    }
                }
            }
            #endregion
            return Debugs;
        }

        internal static List<DebugInfo> GetDBGP(Dictionary<string, DebugInfo> dic) => dic.Where(x => x.Value.Type == DebugInfoType.Contact || x.Value.Type == DebugInfoType.Timer).Select(x => x.Value).ToList();
        internal static List<DebugInfo> GetDBGW(Dictionary<string, DebugInfo> dic) => dic.Where(x => x.Value.Type != DebugInfoType.Contact).Select(x => x.Value).ToList();
        internal static int DBGP_Count(List<DebugInfo> lsDBGP) => Convert.ToInt32(Math.Ceiling(lsDBGP.Count / 8.0)) + 1;
        internal static int DBGW_Count(List<DebugInfo> lsDBGW) => lsDBGW.Where(x => x.Type == DebugInfoType.Timer | x.Type == DebugInfoType.Word).Count() +
                                                                  (lsDBGW.Where(x => x.Type == DebugInfoType.DWord | x.Type == DebugInfoType.Float).Count() * 2) + 1;
        #endregion
    }
}
