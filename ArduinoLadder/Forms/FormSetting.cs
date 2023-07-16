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
        }
        #endregion

        #region Method
        #region ShowSetting
        public Set ShowSetting()
        {
            Set ret = null;

            lblPath.Value = Program.DataMgr.ProjectFolder;
            lblArduino.Value = Program.DataMgr.ArduinoFolder;

            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = new Set
                {
                    ProjectFolder = lblPath.Value,
                    ArduinoFolder = lblArduino.Value,
                };
            }

            return ret;
        }
        #endregion
        #endregion
    }
}
