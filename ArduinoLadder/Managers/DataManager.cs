﻿using Devinno.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoLadder.Managers
{
    public class DataManager
    {
        #region Const
        const string PATH_SETTING = "setting.json";
        #endregion

        #region Properties 
        public string ProjectFolder { get; set; }
        public string ArduinoFolder { get; set; }

        #region Language
        private Lang lang = Lang.NONE;
        public Lang Language
        {
            get => lang;
            set
            {
                if (lang != value)
                {
                    lang = value;
                    LanguageChanged?.Invoke(this, null);
                }
            }
        }
        #endregion
        #endregion

        #region Event
        public event EventHandler LanguageChanged;
        #endregion

        #region Constructor
        public DataManager()
        {
            LoadSetting();
        }
        #endregion

        #region Method
        #region SaveSetting
        public void SaveSetting()
        {
            Serialize.JsonSerializeToFile(PATH_SETTING, new Set
            {
                ProjectFolder = this.ProjectFolder,
                ArduinoFolder = this.ArduinoFolder,
                Language = this.Language,
            });
        }
        #endregion
        #region LoadSetting
        public void LoadSetting()
        {
            if (File.Exists(PATH_SETTING))
            {
                var set = Serialize.JsonDeserializeFromFile<Set>(PATH_SETTING);
                this.ProjectFolder = set.ProjectFolder;
                this.ArduinoFolder = set.ArduinoFolder;
                this.Language = set.Language;
            }
            else
            {
                this.ProjectFolder = Path.Combine(Application.StartupPath, "arduino_ld");
                this.ArduinoFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "arduino");
                this.Language = Lang.KO;
            }
        }
        #endregion
        #endregion
    }

    #region enum : Lang
    public enum Lang { NONE, KO, EN }
    #endregion
    #region class : Set
    public class Set
    {
        public string ProjectFolder { get; set; }
        public string ArduinoFolder { get; set; }
        public Lang Language { get; set; } = Lang.NONE;
    }
    #endregion
}
