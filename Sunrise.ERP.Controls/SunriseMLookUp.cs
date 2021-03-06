﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;

using Sunrise.ERP.BaseControl;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Lang;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Popup;

namespace Sunrise.ERP.Controls
{
    /// <summary>
    /// 可输入LookUp
    /// </summary>
    public partial class SunriseMLookUp : SunriseLookUp
    {
        /// <summary>
        /// 可输入LookUp
        /// </summary>
        public SunriseMLookUp()
        {
            InitializeComponent();
        }
        #region 公共属性
        string _datanofield;
        /// <summary>
        /// MLoopUp编号显示字段
        /// </summary>
        [Category("MLookUp设置"), Description("设置或获取控件输入框字段")]
        public string DataNoField
        {
            get { return _datanofield; }
            set { _datanofield = value; }
        }

        string _popupdisplayfields;
        /// <summary>
        /// Popup显示名称
        /// </summary>
        [Category("MLookUp设置"), Description("设置或获取控件Popup显示列标题名称")]
        public string PopupDisplayFields
        {
            get { return _popupdisplayfields; }
            set { _popupdisplayfields = value; }
        }

        string _popupdatafields;
        /// <summary>
        /// Popup显示字段
        /// </summary>
        [Category("MLookUp设置"), Description("设置或获取控件Popup显示列字段名称")]
        public string PopupDataFields
        {
            get { return _popupdatafields; }
            set { _popupdatafields = value; }
        }

        private bool _ispopupshow = false;
        [Category("MLookUp设置"), Description("获取控件Popup是否显示")]
        public bool IsPopuoShow
        {
            get { return _ispopupshow; }
            set { _ispopupshow = value; }
        }

        private int _mlkpnowidth = 50;
        [Category("MLookUp设置"), Description("设置或获取控件输入框宽度百分比"), DefaultValue(50)]
        public int MLookUpNoWidthPercent
        {
            get { return _mlkpnowidth; }
            set { _mlkpnowidth = value; }
        }

        [Category("MLookUp设置"), Description("设置或获取控件是否只读(可用)"), DefaultValue(true)]
        public override bool IsReadOnly
        {
            get { return mlkpDataNo.Properties.Buttons[0].Enabled; }
            set
            {
                mlkpDataNo.Properties.Buttons[0].Enabled = value;
                mlkpDataNo.Properties.Buttons[1].Enabled = value;
                mlkpDataNo.Properties.ReadOnly = !value;
            }
        }
        private bool _isUsedInGrid = false;
        [Category("MLookUp设置"), Description("设置或获取控件是否在Grid中使用"), DefaultValue(false)]
        public bool IsUsedInGrid
        {
            get { return _isUsedInGrid; }
            set { _isUsedInGrid = value; }
        }

        #endregion

        #region 私有属性
        List<string> _popupfields = new List<string>();
        /// <summary>
        /// Popup显示字段集合
        /// </summary>
        private List<string> PopupFields
        {
            get
            {
                if (_popupfields.Count == 0 && !string.IsNullOrEmpty(PopupDataFields))
                {
                    string[] ss = Public.GetSplitString(PopupDataFields, ",");
                    foreach (string s in ss)
                    {
                        _popupfields.Add(s);
                    }
                }
                return _popupfields;
            }
        }
        DataTable _dtPopupData;
        /// <summary>
        /// Popup显示数据表
        /// </summary>
        private DataTable PopupData
        {
            get
            {
                if (_dtPopupData == null && !string.IsNullOrEmpty(SQL))
                {
                    try
                    {
                        string sSql = "";
                        if (string.IsNullOrEmpty(SearchFormFilter))
                            sSql = SQL;
                        else
                            sSql = "SELECT A.* FROM (" + SQL + ") A WHERE " + SearchFormFilter;
                        _dtPopupData = DbHelperSQL.QueryTable(sSql);
                    }
                    catch { return null; }
                }
                return _dtPopupData;
            }
        }

        private bool _isfromlkpclick = false;
        private bool IsFromLkpClick
        {
            get { return _isfromlkpclick; }
            
        }
        private bool _isfromkeychanged = true;
        private bool IsFromKeyChanged
        {
            get { return _isfromkeychanged; }
        }

        private string _popupfilter;
        public string PopupFilter
        {
            get { return _popupfilter; }
            set { _popupfilter = value; }
        }
        #endregion


        #region 私有方法

        private string GetDataFilterString(string inputstring)
        {
            string result = string.Empty;
            for (int i = 0; i < PopupFields.Count; i++)
            {
                if (i == 0)
                    result = string.Concat(PopupFields[i], " LIKE '%{0}%'");
                else
                    result = string.Concat(result, " OR ", PopupFields[i], " LIKE '%{0}%'");
            }
            if (!string.IsNullOrEmpty(result))
                result = string.Format(result, inputstring);
            return result;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// LookUp查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void LookUpSelfClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            base.LookUpSelfClick(sender, e);
            _isfromkeychanged = false;
            if(ReturnData.Rows.Count>0)
            {
                _isfromlkpclick = true;
                mlkpDataNo.EditValue = ReturnData.Rows[0][DataNoField];
                mlkpDataName.EditValue = ReturnData.Rows[0][DisplayField];
                EditValue = ReturnData.Rows[0][DataField].ToString();
            }
            if (string.IsNullOrEmpty(EditValue))
            {
                _isfromkeychanged = false;
                mlkpDataNo.EditValue = string.Empty;
                mlkpDataName.Text = string.Empty;
            }
        }

        #endregion


        #region 私有事件
        private void mlkpDataNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                _isfromlkpclick = true;
                LookUpSelfClick(sender, e);
            }
        }
        

        public void mlkpDataNo_Popup(object sender, EventArgs e)
        {
            ((PopupContainerEdit)sender).Focus();
            _ispopupshow = true;
        }

        public void mlkpDataNo_TextChanged(object sender, EventArgs e)
        {
            if (_isfromkeychanged || IsUsedInGrid)
            {
                if (PopupData == null)
                {
                    ((PopupContainerEdit)sender).EditValue = null;
                    return;
                }
                //只有使用在界面上时才进行数据清空
                if (!IsUsedInGrid)
                {
                    EditValue = string.Empty;
                    mlkpDataName.Text = string.Empty;
                }
                PopupData.DefaultView.RowFilter = string.Empty;
                if (!IsFromLkpClick)
                {
                    try
                    {
                        string sFilter = "(" + GetDataFilterString(((PopupContainerEdit)sender).Text) + ")";
                        if (!string.IsNullOrEmpty(PopupFilter))
                            sFilter += " AND " + PopupFilter;
                        PopupData.DefaultView.RowFilter = sFilter;
                    }
                    catch
                    {
                        PopupData.DefaultView.RowFilter = "1=1";
                    }
                    ((PopupContainerEdit)sender).ShowPopup();
                }
                else
                    _isfromlkpclick = false;
            }
        }

        public void mlkpDataNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                mlkpPopuoGirdView.FocusedRowHandle += 1;
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                mlkpPopuoGirdView.FocusedRowHandle -= 1;
            }
            else if (e.KeyCode == Keys.Return)
            {
                if (IsPopuoShow)
                {
                    e.Handled = true;
                    GetData();
                    //特殊控制，用于在Grid中选择完数据后，焦点切换后，才能够在Grid中显示出来
                    if (IsUsedInGrid)
                    {
                        if (((PopupContainerEdit)sender).Parent is SunriseGridControl)
                        {
                            mlkpDataNo.Focus();
                            ((SunriseGridControl)((PopupContainerEdit)sender).Parent).DefaultView.Focus();
                            SendKeys.Send("{TAB}");
                        }
                    }
                }
            }
        }

        private void SunriseMLookup_Load(object sender, EventArgs e)
        {
            if (MLookUpNoWidthPercent >= 0 && MLookUpNoWidthPercent <= 100)
            {
                mlkpDataNo.Width = (int)Math.Floor(Convert.ToDecimal(this.Width * MLookUpNoWidthPercent / 100));
            }
            CreateGridColumns();
        }

        public void GetData()
        {
            DataRow dr = mlkpPopuoGirdView.GetDataRow(mlkpPopuoGirdView.FocusedRowHandle);
            if (dr != null)
            {
                mlkpPopup.OwnerEdit.ClosePopup();
                //特殊设置，在选择完成后，不再对数据进行过滤
                _isfromlkpclick = true;
                mlkpDataNo.EditValue = dr[DataNoField];
                EditValue = dr[DataField].ToString();
                mlkpDataName.EditValue = dr[DisplayField];
            }
            else
            {
                mlkpDataNo.EditValue = string.Empty;
                PopupData.DefaultView.RowFilter = "1=2";
            }
        }

        private void CreateGridColumns()
        {
            if (PopupData == null)
            {
                mlkpDataNo.EditValue = null;
                return;
            }
            if (!string.IsNullOrEmpty(SQL) && !string.IsNullOrEmpty(PopupDataFields) && !string.IsNullOrEmpty(PopupDisplayFields))
            {
                
                List<string> DisplayFields = new List<string>();
                List<string> DataFields = new List<string>();
                foreach (string s in Public.GetSplitString(PopupDisplayFields, ","))
                {
                    DisplayFields.Add(s);
                }
                foreach (string s in Public.GetSplitString(PopupDataFields, ","))
                {
                    DataFields.Add(s);
                }
                //设置GRID列显示
                int iCount;
                if (DisplayFields.Count > DataFields.Count)
                {
                    iCount = DataFields.Count;
                }
                else
                {
                    iCount = DisplayFields.Count;
                }
                for (int i = 0; i < iCount; i++)
                {
                    DevExpress.XtraGrid.Columns.GridColumn clm = new DevExpress.XtraGrid.Columns.GridColumn();
                    clm.Name = "clm" + DataFields[i];
                    clm.Caption = DisplayFields[i];
                    clm.FieldName = DataFields[i];
                    clm.Width = 100;
                    clm.Visible = true;
                    clm.VisibleIndex = i;
                    mlkpPopuoGirdView.Columns.Add(clm);
                }
                
                mlkpPopupGird.DataSource = PopupData;
            }
        }

        private void mlkpPopuoGirdView_DoubleClick(object sender, EventArgs e)
        {
            GetData();
            //特殊控制，用于在Grid中选择完数据后，焦点切换后，才能够在Grid中显示出来
            if (IsUsedInGrid)
            {
                if (((PopupContainerEdit)(((PopupContainerForm)(((PopupContainerControl)(((GridView)sender).GridControl.Parent)).Parent)).OwnerEdit)).Parent is SunriseGridControl)
                {
                    mlkpDataNo.Focus();
                    ((SunriseGridControl)((PopupContainerEdit)(((PopupContainerForm)(((PopupContainerControl)(((GridView)sender).GridControl.Parent)).Parent)).OwnerEdit)).Parent).DefaultView.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
        }

        public void mlkpDataNo_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            _ispopupshow = false;
        }

        private void mlkpPopuoGirdView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                GetData();
                //特殊控制，用于在Grid中选择完数据后，焦点切换后，才能够在Grid中显示出来
                if (IsUsedInGrid)
                {
                    if (((PopupContainerEdit)(((PopupContainerForm)(((PopupContainerControl)(((GridView)sender).GridControl.Parent)).Parent)).OwnerEdit)).Parent is SunriseGridControl)
                    {
                        mlkpDataNo.Focus();
                        ((SunriseGridControl)((PopupContainerEdit)(((PopupContainerForm)(((PopupContainerControl)(((GridView)sender).GridControl.Parent)).Parent)).OwnerEdit)).Parent).DefaultView.Focus();
                        SendKeys.Send("{TAB}");
                    }
                }
            }
        }

        private void mlkpDataNo_Properties_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mlkpDataName.Text))
            {
                _isfromkeychanged = false;
                EditValue = string.Empty;
                mlkpDataNo.EditValue = null;
            }
        }
        public void mlkpDataNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            _isfromkeychanged = true;
        }


        protected override void txtValueText_TextChanged(object sender, EventArgs e)
        {
            base.txtValueText_TextChanged(sender, e);
            if (PopupData != null)
            {
                DataRow[] drs = PopupData.Select(DataField + "='" + (string.IsNullOrEmpty(EditValue) ? "-1" : EditValue) + "'");
                if (drs != null && drs.Length == 1)
                {
                    _isfromkeychanged = false;
                    mlkpDataNo.EditValue = drs[0][DataNoField];
                    mlkpDataName.EditValue = drs[0][DisplayField];
                }
                else
                {
                    _isfromkeychanged = false;
                    mlkpDataNo.EditValue = null;
                    mlkpDataName.EditValue = null;
                }
            }
        }

        #endregion       

        

       

        
        
    }
}
