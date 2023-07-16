using Devinno.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoLadder.Ladder
{
    public class LadderDocument
    {
        #region Properties
        [JsonIgnore]
        public string FileName { get; set; }

        [JsonIgnore]
        public bool Edit { get; set; }

        [JsonIgnore]
        public string DisplayTitle => (string.IsNullOrWhiteSpace(Title) ? "NONAME" : Title) + (MustSave ? "*" : "");

        [JsonIgnore]
        public bool MustSave => Edit || string.IsNullOrWhiteSpace(FileName);

        [JsonIgnore]
        public string Title => Path.GetFileNameWithoutExtension(FileName);
        public string SketchPath { get; set; }

        public List<LadderItem> Ladders { get; set; } = new List<LadderItem>();
        public List<SymbolInfo> Symbols { get; set; } = new List<SymbolInfo>();
        public List<HardwareInfo> Hardwares { get; set; } = new List<HardwareInfo>();
        public string Communications { get; set; }

        public int P_Count { get; set; } = 32768;   //4096 bytes
        public int M_Count { get; set; } = 32768;   //4096 bytes
        public int T_Count { get; set; } = 2048;    //4096 bytes
        public int C_Count { get; set; } = 2048;    //4096 bytes
        public int D_Count { get; set; } = 4096;    //8192 bytes
        #endregion

        #region Method
        #region ValidSymbol
        public bool ValidSymbol(string sym)
        {
            var addr = sym;
            var v = Symbols.Where(x => x.SymbolName == sym.ToUpper()).FirstOrDefault();
            if (v != null) addr = v.Address;
            return ValidAddress(addr);
        }
        #endregion
        #region ValidAddress
        public bool ValidAddress(string mem)
        {
            bool ret = false;
            if (mem != null)
            {
                var r = AddressInfo.Parse(mem);
                if (r != null)
                {
                    if (r.Type != AddressType.BIT_WORD)
                    {
                        switch (r.Code)
                        {
                            case "P": ret = r.Index < P_Count; break;
                            case "M": ret = r.Index < M_Count; break;
                            case "T": ret = r.Index < T_Count; break;
                            case "C": ret = r.Index < C_Count; break;
                            case "D": ret = r.Index < D_Count; break;
                            case "WP": ret = r.Index < P_Count / 16; break;
                            case "WM": ret = r.Index < M_Count / 16; break;
                        }
                    }
                    else
                    {
                        if (r.Type == AddressType.BIT_WORD)
                        {
                            switch (r.Code)
                            {
                                case "T": ret = r.Index < T_Count && (r.BitIndex.HasValue && r.BitIndex.Value >= 0 && r.BitIndex.Value < 16); break;
                                case "C": ret = r.Index < C_Count && (r.BitIndex.HasValue && r.BitIndex.Value >= 0 && r.BitIndex.Value < 16); break;
                                case "D": ret = r.Index < D_Count && (r.BitIndex.HasValue && r.BitIndex.Value >= 0 && r.BitIndex.Value < 16); break;
                                case "WP": ret = r.Index < P_Count / 16 && (r.BitIndex.HasValue && r.BitIndex.Value >= 0 && r.BitIndex.Value < 16); break;
                                case "WM": ret = r.Index < M_Count / 16 && (r.BitIndex.HasValue && r.BitIndex.Value >= 0 && r.BitIndex.Value < 16); break;
                            }
                        }
                        else if (r.Type == AddressType.DWORD)
                        {
                            switch (r.Code)
                            {
                                case "T": ret = r.Index + 1 < T_Count; break;
                                case "C": ret = r.Index + 1 < C_Count; break;
                                case "D": ret = r.Index + 1 < D_Count; break;
                                case "WP": ret = r.Index + 1 < P_Count / 16; break;
                                case "WM": ret = r.Index + 1 < M_Count / 16; break;
                            }
                        }
                        else if (r.Type == AddressType.FLOAT)
                        {
                            switch (r.Code)
                            {
                                case "T": ret = r.Index + 1 < T_Count; break;
                                case "C": ret = r.Index + 1 < C_Count; break;
                                case "D": ret = r.Index + 1 < D_Count; break;
                                case "WP": ret = r.Index + 1 < P_Count / 16; break;
                                case "WM": ret = r.Index + 1 < M_Count / 16; break;
                            }
                        }
                        /*
                        else if (r.Type == AddressType.TEXT)
                        {
                            switch (r.Code)
                            {
                                case "T": ret = r.Index + r.TextLength < T_Count; break;
                                case "C": ret = r.Index + r.TextLength < C_Count; break;
                                case "D": ret = r.Index + r.TextLength < D_Count; break;
                                case "WP": ret = r.Index + r.TextLength < P_Count / 16; break;
                                case "WM": ret = r.Index + r.TextLength < M_Count / 16; break;
                            }
                        }
                        */
                    }
                }
            }
            return ret;
        }
        #endregion
        #region GetMemCode
        public string GetMemCode(string sym)
        {
            string ret = null;
            var mem = GetSymbolAddress(sym);
            if (ValidAddress(mem))
            {
                ret = mem.Replace(".", "_");
            }
            else if (mem.StartsWith("@"))
            {
                ret = mem.Replace("@", "SR_");
            }


            if (ret == null) ret = sym;
            return ret;
        }
        #endregion   
        #region GetSymbolAddress
        public string GetSymbolAddress(string sym)
        {
            var mem = sym;
            var v = Symbols.Where(x => x.SymbolName == sym).FirstOrDefault();
            if (v != null) mem = v.Address;
            return mem;
        }
        #endregion
        #region GetSymbolName
        public string GetSymbolName(string addr)
        {
            var mem = "";
            var v = Symbols.Where(x => x.Address == addr).FirstOrDefault();
            if (v != null)
                mem = v.SymbolName;
            return mem;
        }
        #endregion
         
        #region Save(path)
        void Save(string path) => Serialize.JsonSerializeToFile(path, this);
        #endregion
        #region Save
        public void Save()
        {
            if (!string.IsNullOrWhiteSpace(FileName) && File.Exists(FileName))
            {
                var v = this;
                Save(FileName);
                Edit = false;
            }
            else SaveAs();
        }
        #endregion
        #region SaveAs
        public void SaveAs()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = Program.DataMgr.ProjectFolder;
                sfd.Filter = "Arduino Ladder File|*.dal";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileName = sfd.FileName;
                    Save(FileName);
                    Edit = false;
                }
            }
        }
        #endregion
        #endregion
    }
}
