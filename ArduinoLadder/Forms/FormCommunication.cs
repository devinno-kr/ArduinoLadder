﻿using ArduinoLadder.Ladder;
using ArduinoLadder.Tools;
using Devinno.Data;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArduinoLadder.Forms
{
    public partial class FormCommunication : DvForm
    {
        #region Member Variable
        FormCommunicationInput frmInput = new FormCommunicationInput() { StartPosition = FormStartPosition.CenterParent };
        List<ILadderComm> Items = new List<ILadderComm>();
        #endregion

        #region Constructor
        public FormCommunication()
        {
            InitializeComponent();

            #region DataGrid
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "Name", HeaderText = "통신 유형", SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(DvDataGridLabelCell) });
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "Summary", HeaderText = "정보", SizeMode = DvSizeMode.Percent, Width = 70, CellType = typeof(DvDataGridLabelCell) });
            dg.Columns.Add(new DvDataGridButtonColumn(dg) { Name = "Tag", HeaderText = "", SizeMode = DvSizeMode.Pixel, Width = 50, Text = "..." });

            dg.ColumnColor = Color.FromArgb(30, 30, 30);
            dg.SelectionMode = DvDataGridSelectionMode.Selector;
            #endregion
            
            #region Buttons 
            btnPM.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            btnPM.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            #endregion

            #region Event
            #region dg.CellButtonClick
            dg.CellButtonClick += (o, s) => {

                var v = s.Cell.Row.Source as ILadderComm;
                if (v != null)
                {
                    Block = true;
                    ILadderComm ret = frmInput.ShowCommInputModify(v);
                    Block = false;

                    if (ret != null)
                    {
                        var idx = Items.IndexOf(v);
                        Items.Insert(idx, ret);
                        Items.Remove(v);
                        dg.SetDataSource<ILadderComm>(Items);
                    }
                }

            };
            #endregion
            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) => DialogResult = DialogResult.OK;
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion
            #region btnPlus.ButtonClick
            btnPM.ButtonClick += (o, s) =>
            {
                if(s.Button.Name == "Add")
                {
                    Block = true;
                    ILadderComm ret = frmInput.ShowCommInputAdd();
                    Block = false;

                    if (ret != null)
                    {
                        Items.Add(ret);
                        dg.SetDataSource<ILadderComm>(Items);
                    }
                }
                else if(s.Button.Name == "Del")
                {
                    var sels = dg.Rows.Where(x => x.Selected).Select(x => x.Source as ILadderComm).ToList();
                    if (sels.Count > 0)
                    {
                        foreach (var v in sels)
                            if (Items.Contains(v))
                                Items.Remove(v);

                        dg.SetDataSource<ILadderComm>(Items);
                    }
                }
            };
            #endregion
            #endregion

            #region Icon
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            StartPosition = FormStartPosition.CenterParent;
        }
        #endregion

        #region Method
        #region LangSet
        void LangSet()
        {
            if (Program.DataMgr.Language == Managers.Lang.KO)
            {
                Title = "통신 설정";
                lblTitleAreas.Text = "통신 항목";
                btnOK.Text = "확인";
                btnCancel.Text = "취소";
                dg.Columns[0].HeaderText = "통신 유형";
                dg.Columns[1].HeaderText = "정보";
            }
            else if (Program.DataMgr.Language == Managers.Lang.EN)
            {
                Title = "Commnication Setting";
                lblTitleAreas.Text = "Commnication List";
                btnOK.Text = "Ok";
                btnCancel.Text = "Cancel";
                dg.Columns[0].HeaderText = "Type";
                dg.Columns[1].HeaderText = "Information";
            }
        }
        #endregion
        #region ShowCommunication
        public List<ILadderComm> ShowCommunication(LadderDocument doc)
        {
            #region Set
            Items.Clear();
            if (doc != null && !string.IsNullOrWhiteSpace(doc.Communications))
            {
                try
                {
                    var str = CryptoTool.DecodeBase64String<string>(doc.Communications);
                    var ls = Serialize.JsonDeserializeWithType<List<ILadderComm>>(str);
                    Items.AddRange(ls);
                }
                catch { }
            }
            dg.SetDataSource<ILadderComm>(Items);
            #endregion

            LangSet();

            List<ILadderComm> ret = null;
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = Items.ToList();
            }
            return ret;
        }
        #endregion
        #endregion
    }
}
