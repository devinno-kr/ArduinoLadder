using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArduinoLadder.Ladder
{
    #region enum : AddressType
    public enum AddressType { UNKNOWN, BIT, WORD, FLOAT, DWORD, BIT_WORD/*, TEXT*/ }
    #endregion

    #region class : SymbolInfo
    public class SymbolInfo
    {
        public string SymbolName { get; set; }
        public string Address { get; set; }
    }
    #endregion
    #region class : HardwareInfo
    public class HardwareInfo
    {
        public string Mode { get; set; }
        public int Pin { get; set; }
        public string Address { get; set; }
    }
    #endregion
    #region class : FuncInfo
    public class FuncInfo
    {
        public string Name { get; set; }
        public List<string> Args { get; set; }

        public static FuncInfo Parse(string code)
        {
            FuncInfo ret = null;

            var regFunc = @"\b[^()]+\((.*)\)$";
            var regArgs = @"(?:[^,()]+((?:\((?>[^()]+|\((?<open>)|\)(?<-open>))*\)))*)+";

            var match = Regex.Match(code, regFunc);
            if (match.Success && match.Groups.Count >= 2)
            {
                var sFunc = match.Groups[0].Value.Trim();
                var sArgs = match.Groups[1].Value.Trim();
                var matches = Regex.Matches(sArgs, regArgs);

                var bsucs = matches.Where(x => x.Success).Count() == matches.Count;
                if (bsucs)
                {
                    var name = sFunc.Substring(0, sFunc.IndexOf('(')).Trim();
                    var args = matches.Select(x => x.Value.Trim()).ToList();
                    ret = new FuncInfo() { Name = name, Args = args };
                }
            }

            return ret;
        }
    }
    #endregion
    #region class : AddressInfo
    public class AddressInfo
    {
        public string Code { get; set; }
        public int Index { get; set; } = 0;
        public int? BitIndex { get; set; } = null;
        public AddressType Type { get; set; }
        public string Ex { get; set; }
        public int TextLength { get; set; }

        public static AddressInfo Parse(string address)
        {
            AddressInfo ret = null;
            if (address != null)
            {
                #region P,M,T,C,D
                if (address.Length > 1 && new string[] { "P", "M", "T", "C", "D" }.Contains(address.Substring(0, 1).ToUpper()))
                {
                    var ac = address.Substring(0, 1).ToUpper();
                    var sp = address.Substring(1).Split('.', '_');
                    int nai, nbi;
                    #region ex) D10
                    if (sp.Length == 1 && int.TryParse(address.Substring(1), out nai))
                    {
                        switch (ac)
                        {
                            case "P":
                            case "M":
                                {
                                    ret = new AddressInfo()
                                    {
                                        Code = ac,
                                        Index = nai,
                                        BitIndex = null,
                                        Type = AddressType.BIT
                                    };
                                }
                                break;
                            case "T":
                            case "C":
                            case "D":
                                {
                                    ret = new AddressInfo()
                                    {
                                        Code = ac,
                                        Index = nai,
                                        BitIndex = null,
                                        Type = AddressType.WORD
                                    };
                                }
                                break;
                        }
                    }
                    #endregion
                    #region ex) D10.A
                    else if (sp.Length == 2 && (ac == "T" || ac == "C" || ac == "D") && int.TryParse(sp[0], out nai))
                    {
                        switch (ac)
                        {
                            //case "T":
                            case "C":
                            case "D":
                                {
                                    if (sp[1] == "R")
                                    {
                                        ret = new AddressInfo()
                                        {
                                            Code = ac,
                                            Index = nai,
                                            Type = AddressType.FLOAT,
                                            Ex = sp[1],
                                        };
                                    }
                                    else if (sp[1] == "DW")
                                    {
                                        ret = new AddressInfo()
                                        {
                                            Code = ac,
                                            Index = nai,
                                            Type = AddressType.DWORD,
                                            Ex = sp[1],
                                        };
                                    }
                                    /*
                                    else if (sp[1].StartsWith("S"))
                                    {
                                        var s = sp[1].Substring(1);
                                        int len;
                                        if (int.TryParse(s, out len))
                                        {
                                            ret = new AddressInfo()
                                            {
                                                Code = ac,
                                                Index = nai,
                                                Type = AddressType.TEXT,
                                                Ex = sp[1],
                                                TextLength = len,
                                            };
                                        }
                                    }
                                    */
                                    else
                                    {
                                        if (int.TryParse(sp[1], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out nbi) && (nbi >= 0 && nbi < 16))
                                        {
                                            ret = new AddressInfo()
                                            {
                                                Code = ac,
                                                Index = nai,
                                                BitIndex = nbi,
                                                Type = AddressType.BIT_WORD,
                                                Ex = sp[1],
                                            };
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    #endregion
                }
                #endregion
                #region WM, WP
                else if (address.Length > 2 && new string[] { "WM", "WP" }.Contains(address.Substring(0, 2).ToUpper()))
                {
                    var ac = address.Substring(0, 2).ToUpper();
                    var sp = address.Substring(2).Split('.');
                    int nai, nbi;
                    #region ex) WM5
                    if (sp.Length == 1 && int.TryParse(address.Substring(2), out nai))
                    {
                        switch (ac)
                        {
                            case "WP":
                            case "WM":
                                {
                                    ret = new AddressInfo()
                                    {
                                        Code = ac,
                                        Index = nai,
                                        BitIndex = null,
                                        Type = AddressType.WORD
                                    };
                                }
                                break;
                        }
                    }
                    #endregion
                    #region ex) WM5.0
                    else if (sp.Length == 2 && (ac == "WM" || ac == "WP") && int.TryParse(sp[0], out nai))
                    {
                        switch (ac)
                        {
                            case "WP":
                            case "WM":
                                {
                                    if (sp[1] == "R")
                                    {
                                        ret = new AddressInfo()
                                        {
                                            Code = ac,
                                            Index = nai,
                                            Type = AddressType.FLOAT,
                                            Ex = sp[1],
                                        };
                                    }
                                    else if (sp[1] == "DW")
                                    {
                                        ret = new AddressInfo()
                                        {
                                            Code = ac,
                                            Index = nai,
                                            Type = AddressType.DWORD,
                                            Ex = sp[1],
                                        };
                                    }
                                    /*
                                    else if (sp[1].StartsWith("S"))
                                    {
                                        var s = sp[1].Substring(1);
                                        int len;
                                        if (int.TryParse(s, out len))
                                        {
                                            ret = new AddressInfo()
                                            {
                                                Code = ac,
                                                Index = nai,
                                                Type = AddressType.TEXT,
                                                Ex = sp[1],
                                                TextLength = len,
                                            };
                                        }
                                    }
                                    */
                                    else
                                    {
                                        if (int.TryParse(sp[1], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out nbi) && (nbi >= 0 && nbi < 16))
                                        {
                                            ret = new AddressInfo()
                                            {
                                                Code = ac,
                                                Index = nai,
                                                BitIndex = nbi,
                                                Type = AddressType.BIT_WORD,
                                                Ex = sp[1],
                                            };
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    #endregion
                }
                #endregion
            }

            return ret;
        }

        public static bool TryParse(string address, out AddressInfo target)
        {
            target = AddressInfo.Parse(address);
            return target != null;
        }
    }
    #endregion
    #region class : DebugInfo
    public enum DebugInfoType { Contact, Timer, Word, Float, DWord/*, Text*/ }
    public class DebugInfo
    {
        public DebugInfoType Type { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Contact { get; set; }
        public int Timer { get; set; }
        public int Word { get; set; }
        public float Float { get; set; }
        public string Text { get; set; }
        public long DWord { get; set; }

        public string VCode { get; set; }
        public string TCode { get; set; }

        #region ToPacketString
        public static string ToPacketString(List<DebugInfo> ls)
        {
            var sb = new StringBuilder();

            foreach (var v in ls)
            {
                switch (v.Type)
                {
                    case DebugInfoType.Contact:
                        sb.Append($"C:");
                        sb.Append($"{v.Row},{v.Column}:");
                        sb.Append($"{(v.Contact ? "1" : "0")};");
                        break;

                    case DebugInfoType.Timer:
                        sb.Append($"T:");
                        sb.Append($"{v.Row},{v.Column}:");
                        sb.Append($"{(v.Contact ? "1" : "0")}:");
                        sb.Append($"{v.Timer};");
                        break;

                    case DebugInfoType.Word:
                        sb.Append($"W:");
                        sb.Append($"{v.Row},{v.Column}:");
                        sb.Append($"{v.Word};");
                        break;

                    case DebugInfoType.Float:
                        sb.Append($"F:");
                        sb.Append($"{v.Row},{v.Column}:");
                        sb.Append($"{v.Float};");
                        break;

                    case DebugInfoType.DWord:
                        sb.Append($"D:");
                        sb.Append($"{v.Row},{v.Column}:");
                        sb.Append($"{v.DWord};");
                        break;
                        /*
                    case DebugInfoType.Text:
                        sb.Append($"S:");
                        sb.Append($"{v.Row},{v.Column}:");
                        sb.Append($"{v.Text};");
                        break;
                        */
                }
            }

            return sb.ToString();
        }
        #endregion
        #region FromPacketString
        public static List<DebugInfo> FromPacketString(string packet)
        {
            var ret = new List<DebugInfo>();

            var ls = packet.Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            foreach (var v in ls)
            {
                var ls2 = v.Split(':').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                if (ls2.Count >= 2)
                {
                    var code = ls2[0];
                    var sp = ls2[1].Split(',');
                    int row, col, vn;
                    float vf;
                    long vl;
                    string vs;
                    if (sp.Length == 2 && int.TryParse(sp[0], out row) && int.TryParse(sp[1], out col))
                    {
                        switch (ls2[0])
                        {
                            case "C":
                                if (ls2.Count == 3)
                                {
                                    ret.Add(new DebugInfo()
                                    {
                                        Type = DebugInfoType.Contact,
                                        Row = row,
                                        Column = col,
                                        Contact = ls2[2] == "1"
                                    });
                                }
                                break;
                            case "T":
                                if (ls2.Count == 4 && int.TryParse(ls2[3], out vn))
                                {
                                    ret.Add(new DebugInfo()
                                    {
                                        Type = DebugInfoType.Timer,
                                        Row = row,
                                        Column = col,
                                        Contact = ls2[2] == "1",
                                        Timer = vn
                                    });
                                }
                                break;
                            case "W":
                                if (ls2.Count == 3 && int.TryParse(ls2[2], out vn))
                                {
                                    ret.Add(new DebugInfo()
                                    {
                                        Type = DebugInfoType.Word,
                                        Row = row,
                                        Column = col,
                                        Word = vn
                                    });
                                }
                                break;
                            case "F":
                                if (ls2.Count == 3 && float.TryParse(ls2[2], out vf))
                                {
                                    ret.Add(new DebugInfo()
                                    {
                                        Type = DebugInfoType.Float,
                                        Row = row,
                                        Column = col,
                                        Float = vf
                                    });
                                }
                                break;
                            case "D":
                                if (ls2.Count == 3 && long.TryParse(ls2[2], out vl))
                                {
                                    ret.Add(new DebugInfo()
                                    {
                                        Type = DebugInfoType.DWord,
                                        Row = row,
                                        Column = col,
                                        DWord = vl
                                    });
                                }
                                break;
                                /*
                            case "S":
                                if (ls2.Count >= 3)
                                {
                                    var ival = v.IndexOf(":", 2);
                                    var val = ival != -1 && ival + 1 < v.Length ? v.Substring(ival + 1) : "";

                                    ret.Add(new DebugInfo()
                                    {
                                        Type = DebugInfoType.Text,
                                        Row = row,
                                        Column = col,
                                        Text = val,
                                    });
                                }
                                else if (ls2.Count == 2)
                                {
                                    ret.Add(new DebugInfo()
                                    {
                                        Type = DebugInfoType.Text,
                                        Row = row,
                                        Column = col,
                                        Text = "",
                                    });
                                }
                                break;
                                */
                        }
                    }
                }
            }

            return ls.Count == ret.Count ? ret : null;
        }
        #endregion
        #region FromPacket
        public static List<DebugInfo> FromPacket(byte[] data)
        {
            var ret = new List<DebugInfo>();
            var idx = 0;
            
            while(idx < data.Length)
            {
                if (data[idx] == 1)
                {
                    var v = new DebugInfo { Type = DebugInfoType.Contact };
                    v.Row = BitConverter.ToUInt16(data, idx + 1);
                    v.Column = BitConverter.ToUInt16(data, idx + 3);
                    v.Contact = data[idx + 5] == 1;
                    ret.Add(v);
                    idx += 6;
                }
                else if (data[idx] == 2)
                {
                    var v = new DebugInfo { Type = DebugInfoType.Timer };
                    v.Row = BitConverter.ToUInt16(data, idx + 1);
                    v.Column = BitConverter.ToUInt16(data, idx + 3);
                    v.Contact = data[idx + 5] == 1;
                    v.Column = BitConverter.ToUInt16(data, idx + 6);
                    ret.Add(v);
                    idx += 8;
                }
                else if (data[idx] == 3)
                {
                    var v = new DebugInfo { Type = DebugInfoType.Word };
                    v.Row = BitConverter.ToUInt16(data, idx + 1);
                    v.Column = BitConverter.ToUInt16(data, idx + 3);
                    v.Word = BitConverter.ToUInt16(data, idx + 5);
                    ret.Add(v);
                    idx += 7;
                }
                else if (data[idx] == 4)
                {
                    var v = new DebugInfo { Type = DebugInfoType.Float };
                    v.Row = BitConverter.ToUInt16(data, idx + 1);
                    v.Column = BitConverter.ToUInt16(data, idx + 3);
                    v.Float = BitConverter.ToSingle(data, idx + 5);
                    ret.Add(v);
                    idx += 9;
                }
                else if (data[idx] == 5)
                {
                    var v = new DebugInfo { Type = DebugInfoType.DWord };
                    v.Row = BitConverter.ToUInt16(data, idx + 1);
                    v.Column = BitConverter.ToUInt16(data, idx + 3);
                    v.DWord = BitConverter.ToUInt32(data, idx + 5);
                    ret.Add(v);
                    idx += 9;
                }
                /*
                else if (data[idx] == 6)
                {
                    var v = new DebugInfo { Type = DebugInfoType.Text };
                    v.Row = BitConverter.ToUInt16(data, idx + 1);
                    v.Column = BitConverter.ToUInt16(data, idx + 3);
                    var len = data[idx + 5];
                    v.Text = Encoding.UTF8.GetString(data, idx + 6, len);
                    ret.Add(v);
                    idx += 6 + len;
                }
                */
            }
            return ret;
        }
        #endregion
    }
    #endregion

    #region class : LadderCheckMessage
    public class LadderCheckMessage
    {
        public int? Row { get; set; }
        public int? Column { get; set; }
        public string Message { get; set; }
    }
    #endregion
    #region class : LadderBuildResult
    public class LadderBuildResult
    {
        public Dictionary<string, List<List<LadderItem>>> ValidNodes { get; set; }
        public Dictionary<string, List<List<LadderItem>>> InvalidNodes { get; set; }
    }
    #endregion
}
