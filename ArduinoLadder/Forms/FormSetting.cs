using ArduinoLadder.Managers;
using Devinno.Forms.Dialogs;
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
    public partial class FormSetting : DvForm
    {
        #region Constructor
        public FormSetting()
        {
            InitializeComponent();

            btnOK.ButtonClick += (o, s) => DialogResult = DialogResult.OK;
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;

            #region lblPath.ButtonClicked
            lblPath.ButtonClicked += (o, s) =>
            {
                using (var fbd = new FolderBrowserDialog() { })
                {
                    fbd.SelectedPath = Program.DataMgr.ProjectFolder;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        lblPath.Value = fbd.SelectedPath;
                    }
                }
            };
            #endregion
            #region lblArduino.ButtonClicked
            lblArduino.ButtonClicked += (o, s) =>
            {
                using (var fbd = new FolderBrowserDialog() { })
                {
                    fbd.SelectedPath = Program.DataMgr.ArduinoFolder;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        lblArduino.Value = fbd.SelectedPath;
                    }
                }
            };
            #endregion
            #region inLang.ValueChanged
            inLang.ValueChanged += (o, s) =>
            {
                if (inLang.Value) LangSet(Lang.KO);
                else LangSet(Lang.EN);
            };
            #endregion

            #region Form Props
            StartPosition = FormStartPosition.CenterParent;
            #endregion
        }
        #endregion

        #region Method
        #region LangSet
        void LangSet(Lang lang)
        {
            if (lang == Managers.Lang.KO)
            {
                Title = LM.SettingK;
                lblTitleAreas.Text = LM.SettingListK;
                lblPath.Title = LM.ProjectFolderK;
                lblArduino.Title = LM.ArduinoFolderK;
                inLang.Title = LM.LanguageK;
                btnOK.Text = LM.OkK;
                btnCancel.Text = LM.CancelK;
            }
            else if (lang == Managers.Lang.EN)
            {
                Title = LM.SettingE;
                lblTitleAreas.Text = LM.SettingListE;
                lblPath.Title = LM.ProjectFolderE;
                lblArduino.Title = LM.ArduinoFolderE;
                inLang.Title = LM.LanguageE;
                btnOK.Text = LM.OkE;
                btnCancel.Text = LM.CancelE;
            }
        }
        #endregion
        #region ShowSetting
        public Set ShowSetting()
        {
            Set ret = null;

            lblPath.Value = Program.DataMgr.ProjectFolder;
            lblArduino.Value = Program.DataMgr.ArduinoFolder;
            inLang.Value = Program.DataMgr.Language == Lang.KO;
            inDescView.Value = Program.DataMgr.DescriptionViewAll;

            LangSet(Program.DataMgr.Language);

            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = new Set
                {
                    ProjectFolder = lblPath.Value,
                    ArduinoFolder = lblArduino.Value,
                    Language = inLang.Value ? Lang.KO : Lang.EN,
                    DescriptionViewAll = inDescView.Value,
                };
            }

            return ret;
        }
        #endregion
        #endregion
    }
}
