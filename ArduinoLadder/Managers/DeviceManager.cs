using ArduinoLadder.Ladder;
using ArduinoLadder.Tools;
using Devinno.Communications.Modbus.RTU;
using Devinno.Communications.TextComm.RTU;
using Devinno.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoLadder.Managers
{
    public class DeviceManager
    {
        #region Const
        public const string PATH_PORT = "port.set";
        #endregion

        #region Properties
        public bool IsDebugging { get; private set; }
        public bool IsOpen => comm.IsStart && comm.IsOpen;  
        public int Baudrate { get => comm.Baudrate; set => comm.Baudrate = value; }
        public string PortName { get => comm.Port; set => comm.Port = value; }
        
        public bool DTR
        {
            get => comm.DTR;
            set => comm.DTR = value;
        }
        #endregion

        #region Member Variable
        private ModbusRTUMaster2 comm;
        private Dictionary<int, DebugInfo> Debugs = new Dictionary<int, DebugInfo>();
        #endregion

        #region Constructor
        public DeviceManager()
        {
            comm = new ModbusRTUMaster2();
            comm.BitReadReceived += Comm_BitReadReceived;
            comm.WordReadReceived += Comm_WordReadReceived;
            comm.Timeout = 100;
            comm.Interval = 10;

            if (File.Exists(PATH_PORT))
            {
                var txt = File.ReadAllText(PATH_PORT);
                var sp = txt.Split(":");
                int baud;
                if(GetPortNames().Contains(sp[0]) && int.TryParse(sp[1], out baud))
                {
                    PortName = sp[0];
                    Baudrate = baud;
                }
            }
        }
        #endregion

        #region Event
        private void Comm_WordReadReceived(object sender, ModbusRTUMaster2.WordReadEventArgs e)
        {
            for (int i = 0; i < e.ReceiveData.Length; i++)
            {
                var addr = e.StartAddress + i;
                var val = e.ReceiveData[i];
                if (Debugs.ContainsKey(addr))
                {
                    if (Debugs[addr].Type == DebugInfoType.Timer)
                    {
                        Debugs[addr].Timer = val;
                    }
                    else if (Debugs[addr].Type == DebugInfoType.Word)
                    {
                        Debugs[addr].Word = val;
                    }
                    else if (Debugs[addr].Type == DebugInfoType.DWord)
                    {
                        if (i + 1 < e.ReceiveData.Length)
                            Debugs[addr].DWord = val | (e.ReceiveData[i + 1] << 16);
                    }
                    else if (Debugs[addr].Type == DebugInfoType.Float)
                    {
                        if (i + 1 < e.ReceiveData.Length)
                        {
                            var ba = BitConverter.GetBytes((uint)(val | (e.ReceiveData[i + 1] << 16)));
                            Debugs[addr].Float = BitConverter.ToSingle(ba);
                        }
                    }
                }
            }

            Program.MainForm.Invoke(new Action(() => Program.MainForm.Debug(Debugs.Values.ToList())));
        }

        private void Comm_BitReadReceived(object sender, ModbusRTUMaster2.BitReadEventArgs e)
        {
            for (int i = 0; i < e.ReceiveData.Length; i++)
            {
                var addr = e.StartAddress + i;
                var val = e.ReceiveData[i];
                if (Debugs.ContainsKey(addr)) Debugs[addr].Contact = val;
            }

            Program.MainForm.Invoke(new Action(() => Program.MainForm.Debug(Debugs.Values.ToList())));
        }
        #endregion

        #region Method
        #region StartDebug
        public void StartDebug(LadderDocument doc)
        {
            #region Debugs
            var dic = DebugTool.GetDebugs(doc);
            var lsDBGP = DebugTool.GetDBGP(dic);
            var lsDBGW = DebugTool.GetDBGW(dic);
            var DBGP_CNT = DebugTool.DBGP_Count(lsDBGP);
            var DBGW_CNT = DebugTool.DBGW_Count(lsDBGW);

            Debugs.Clear();
            int iP = 0, iW = 0;
            foreach (var k in dic.Keys)
            {
                var v = dic[k];

                if (v.Type == DebugInfoType.Contact)
                {
                    Debugs.Add(0xC000 + iP, v);
                    iP++;
                }
                else if (v.Type == DebugInfoType.Word)
                {
                    Debugs.Add(0xE000 + iW, v);
                    iW++;
                }
                else if (v.Type == DebugInfoType.DWord)
                {
                    Debugs.Add(0xE000 + iW, v);
                    iW += 2;
                }
                else if (v.Type == DebugInfoType.Float)
                {
                    Debugs.Add(0xE000 + iW, v);
                    iW += 2;
                }
                else if (v.Type == DebugInfoType.Timer)
                {
                    Debugs.Add(0xC000 + iP, v);
                    Debugs.Add(0xE000 + iW, v);
                    iW++;
                    iP++;
                }
            }
            #endregion

            IsDebugging = true;
            comm.ClearAuto();
            comm.ClearManual();
            comm.ClearWorkSchedule();
            comm.AutoBitRead_FC1(1, 1, 0xC000, DBGP_CNT * 8);
            comm.AutoWordRead_FC3(1, 1, 0xE000, DBGW_CNT);
            comm.Start();
        }
        #endregion
        #region StopDebug
        public void StopDebug()
        {
            IsDebugging = false;
            comm.ClearAuto();
            comm.ClearManual();
            comm.ClearWorkSchedule();
            comm.Stop();

            Debugs.Clear();
        }
        #endregion
        #region Save
        public void Save()
        {
            File.WriteAllText(PATH_PORT, $"{PortName}:{Baudrate}");
        }
        #endregion

        #region GetPortNames
        public List<string> GetPortNames()
        {
            var lsPort = SerialPort.GetPortNames().Select(x => x.Split('\0').FirstOrDefault()).ToList();
            return lsPort;
        }
        #endregion
        #endregion
    }
}
