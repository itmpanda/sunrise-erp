﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Sunrise.ERP.Security;
using Sunrise.ERP.BasePublic;
using Sunrise.ERP.Lang;
using Sunrise.ERP.BaseControl;
using Sunrise.ERP.BaseForm.DAL;
using Sunrise.ERP.DataAccess;
using Sunrise.ERP.Controls;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace Sunrise.ERP.BaseForm
{
    public partial class frmDynamicMasterDetail : frmDynamicSingleForm
    {
        /// <summary>
        /// 明细数据集集合
        /// </summary>
        protected List<BindingSource> LDetailBindingSource = new List<BindingSource>();
        /// <summary>
        /// 从表字段集合
        /// </summary>
        protected List<string> LDetailField = new List<string>();
        /// <summary>
        /// 主表字段集合
        /// </summary>
        protected List<string> LMasterField = new List<string>();
        /// <summary>
        /// 明细表数据表名集合
        /// </summary>
        protected List<string> LDetailTableName = new List<string>();
        /// <summary>
        /// 明细数据操作层集合
        /// </summary>
        protected List<DynamicDALSetting> LDetailDynamicDAL = new List<DynamicDALSetting>();
        /// <summary>
        /// 动态明细表结构数据集合
        /// </summary>
        protected List<DataTable> LDynamicDetailTableData = new List<DataTable>();
        /// <summary>
        /// 明细表排序字段集合
        /// </summary>
        protected Hashtable DetailOrderField = new Hashtable();

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmDynamicMasterDetail()
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        public frmDynamicMasterDetail(int formid, string tablename)
            : base(formid, tablename)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, bool ischeckauth)
            : base(formid, tablename, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere, bool ischeckauth)
            : base(formid, tablename, pwhere, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere)
            : base(formid, tablename, pwhere)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, tablename, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        public frmDynamicMasterDetail(int formid, string tablename, string pwhere, string sortfield)
            : base(formid, tablename, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="top">前多少数据</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        /// <param name="ischeckauth">是否加载权限控制</param>
        public frmDynamicMasterDetail(int formid, string tablename, int top, string pwhere, string sortfield, bool ischeckauth)
            : base(formid, tablename, top, pwhere, sortfield, ischeckauth)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formid">FormID</param>
        /// <param name="tablename">数据表名称</param>
        /// <param name="top">前多少数据</param>
        /// <param name="pwhere">数据过滤条件,设置条件一定要注意SQL语句的拼接,条件前面需要加上AND关键字,e.g:AND 1=1</param>
        /// <param name="sortfield">排序字段</param>
        public frmDynamicMasterDetail(int formid, string tablename, int top, string pwhere, string sortfield)
            : base(formid, tablename, top, pwhere, sortfield)
        {
            InitializeComponent();
            dsMain.CurrentChanged += new EventHandler(MasterAllScroll);
        }

        /// <summary>
        /// 增加明细数据表
        /// 关联字段一定是要一一对应，否则系统无法建立其关系
        /// </summary>
        /// <param name="tablename">明细表名称</param>
        /// <param name="detailfield">主从表关联字段-从表字段</param>
        /// <param name="masterfield">主从表关联字段-主表字段</param>
        public void AddDetailData(string tablename, string detailfield, string masterfield)
        {
            LDetailTableName.Add(tablename);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            DataTable dtTmp = Base.GetDynamicTableData(FormID, tablename);
            LDynamicDetailTableData.Add(dtTmp);
            DynamicDALSetting DALobj = new DynamicDALSetting(dtTmp);
            LDetailDynamicDAL.Add(DALobj);
            LDetailBindingSource.Add(new BindingSource(GetDataSet(DALobj, detailfield + "=" + GetMasterLinkValue(masterfield)), "ds"));
        }

        /// <summary>
        /// 增加明细数据表
        /// 关联字段一定是要一一对应，否则系统无法建立其关系
        /// </summary>
        /// <param name="tablename">明细表名称</param>
        /// <param name="detailfield">主从表关联字段-从表字段</param>
        /// <param name="masterfield">主从表关联字段-主表字段</param>
        /// <param name="sortfield">明细表排序字段，可以多个，e.g:ID DESC,OrderNo</param>
        public void AddDetailData(string tablename, string detailfield, string masterfield, string sortfield)
        {
            LDetailTableName.Add(tablename);
            LDetailField.Add(detailfield);
            LMasterField.Add(masterfield);
            DataTable dtTmp = Base.GetDynamicTableData(FormID, tablename);
            LDynamicDetailTableData.Add(dtTmp);
            DynamicDALSetting DALobj = new DynamicDALSetting(dtTmp);
            LDetailDynamicDAL.Add(DALobj);
            string swhere = sortfield != "" ? detailfield + "=" + GetMasterLinkValue(masterfield) + " ORDER BY " + sortfield : detailfield + "=" + GetMasterLinkValue(masterfield);
            LDetailBindingSource.Add(new BindingSource(GetDataSet(DALobj, swhere), "ds"));
        }

        /// <summary>
        /// 主表数据滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void MasterAllScroll(object sender, EventArgs e)
        {
            try
            {
                if (dsMain.Current != null)
                {
                    BillID = ((DataRowView)(dsMain.Current))["ID"].ToString() == "" ? 0 : Convert.ToInt32(((DataRowView)(dsMain.Current))["ID"]);
                    //根据主表与从表的关系字段刷新从表数据
                    if (LDetailBindingSource.Count > 0)
                    {
                        for (int i = 0; i < LDetailBindingSource.Count; i++)
                        {
                            string swhere = "";
                            swhere = LDetailField[i] + "=" + GetMasterLinkValue(LMasterField[i]);
                            if (DetailOrderField[LDetailTableName[i]] != null && DetailOrderField[LDetailTableName[i]].ToString() != "")
                                swhere += " ORDER BY " + DetailOrderField[LDetailTableName[i]].ToString();
                            LDetailBindingSource[i].DataSource = GetDataSet(LDetailDynamicDAL[i], swhere);
                        }
                    }
                    else
                        return;
                }
                else
                {
                    //当主表数据为空时清空所有明细数据
                    for (int i = 0; i < LDetailBindingSource.Count; i++)
                    {
                        ((DataSet)LDetailBindingSource[i].DataSource).Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Public.SystemInfo("MasterAllScroll-" + ex.Message, true);
            }
        }
        /// <summary>
        /// 取得主从连接主表连接字段值
        /// </summary>
        /// <param name="masterfield">主表连接字段</param>
        /// <returns></returns>
        public string GetMasterLinkValue(string masterfield)
        {
            string sResult = "";
            if (masterfield.Trim().ToUpper() == "ID")
                sResult = BillID.ToString();
            else
            {
                try
                {
                    sResult = GetDataSet(MasterDynamicDAL, 1, "ID=" + BillID.ToString(), "ID").Tables[0].Rows[0][masterfield].ToString();
                }
                catch (Exception)
                {
                    Public.SystemInfo("主从表连接字段设置错误！", true);
                }
            }
            return sResult;
        }

        public override bool DoSave()
        {
            SqlTransaction trans = ConnectSetting.SysSqlConnection.BeginTransaction();
            try
            {
                //先保存主表
                if (FormDataFlag == DataFlag.dsInsert)
                    BillID = Add(MasterDynamicDAL, ((DataRowView)dsMain.Current).Row, trans);
                else
                    Update(MasterDynamicDAL, ((DataRowView)dsMain.Current).Row, trans);
                //保存从表
                for (int i = 0; i < LDetailBindingSource.Count; i++)
                {
                    foreach (DataRow dr in ((DataSet)LDetailBindingSource[i].DataSource).Tables[0].Rows)
                    {
                        //增加
                        if (dr.RowState == DataRowState.Added && dr["ID"].ToString()=="")
                        {
                            dr[LDetailField[i]] = GetMasterLinkValue(LMasterField[i]);
                            dr["ID"] = Add(LDetailDynamicDAL[i], dr, trans);
                        }
                        //更新
                        else if (dr.RowState == DataRowState.Modified && dr["ID"].ToString() != "")  
                            Update(LDetailDynamicDAL[i], dr, trans);
                        //删除
                        else if (dr.RowState == DataRowState.Deleted && dr["ID", DataRowVersion.Original].ToString() != "")
                            Delete(LDetailDynamicDAL[i], Convert.ToInt32(dr["ID", DataRowVersion.Original]), trans);
                    }
                }
                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
        }

        public override bool DoAfterSave()
        {
            if (TopCount != 499 && SortField != "dInputDate DESC")
            {
                if (IsCheckAuth)
                    dtMain = GetDataSet(MasterDynamicDAL, TopCount, SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere, SortField).Tables[0];
                else
                    dtMain = GetDataSet(MasterDynamicDAL, TopCount, "1=1 " + pWhere, SortField).Tables[0];
                dsMain.DataSource = dtMain;
                dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
            }
            else
            {
                if (IsCheckAuth)
                    dtMain = GetDataSet(MasterDynamicDAL, SC.GetAuthSQL(MasterFilerSQL == "" ? ShowType.FormShow : ShowType.FormQuery, FormID) + pWhere).Tables[0];
                else
                    dtMain = GetDataSet(MasterDynamicDAL, "1=1 " + pWhere).Tables[0];
                dsMain.DataSource = dtMain;
                dtMain.ColumnChanged += new DataColumnChangeEventHandler(dtMain_ColumnChanged);
            }
            Base.SetAllControlsReadOnly(this.pnlInfo, true);
            IsDataChange = false;
            initButtonsState(OperateFlag.Save);
            return base.DoAfterSave();
        }

        /// <summary>
        /// 创建明细数据表Grid列
        /// </summary>
        /// <param name="gv">需要创建的Grid</param>
        /// <param name="tablename">明细数据表名称</param>
        public void CreateDetailGridColumn(GridView gv, string tablename)
        {
            gv.Columns.Clear();
            int iIndex = 0;
            string sFilter = "bShowInGrid=1 AND sTableName='" + tablename + "'";
            DataRow[] drs = LDynamicDetailTableData[LDetailTableName.IndexOf(tablename)].Select(sFilter);
            foreach (DataRow dr in drs)
            {
                GridColumn cols = new GridColumn();
                string sControlType = dr["sControlType"].ToString();
                switch (sControlType)
                {
                    //LookUp查询
                    case "lkp":
                        {
                            if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                            {
                                SunriseLookUp lkp = new SunriseLookUp();
                                lkp.DataBindings.Add("EditValue", LDetailBindingSource[LDetailTableName.IndexOf(tablename)], dr["sFieldName"].ToString());
                                Base.InitLookup(lkp, dr["sLookupNo"].ToString());
                                if (!string.IsNullOrEmpty(dr["sLookupAutoSetControl"].ToString()))
                                {
                                    string[] sItem = Public.GetSplitString(dr["sLookupAutoSetControl"].ToString(), ",");
                                    foreach (var s in sItem)
                                    {
                                        string[] ss = Public.GetSplitString(s, "=");
                                        lkp.AutoSetValue(ss[0], ss[1]);
                                    }
                                }
                                RepositoryItemButtonEdit btnRepositoryItem = new RepositoryItemButtonEdit();
                                btnRepositoryItem.ButtonClick += lkp.LookUpSelfClick;
                                btnRepositoryItem.TextEditStyle = TextEditStyles.DisableTextEditor;
                                //加这句是让了焦点更新，Grid中才会显示新的数据值，其实在后台是已经存在了的，只是在Grid中没有显示出来
                                //此处设置为查询完成后自动跳转到Grid中的下一列中
                                lkp.LookUpAfterPost += new SunriseLookUp.SunriseLookUpEvent(lkp_LookUpAfterPost);
                                cols.ColumnEdit = btnRepositoryItem;
                                gv.GridControl.RepositoryItems.Add(btnRepositoryItem);
                            }
                            break;
                        }
                    //下拉框
                    case "cbx":
                        {
                            if (!string.IsNullOrEmpty(dr["sLookupNo"].ToString()))
                            {
                                RepositoryItemImageComboBox cbxRepositoryItem = new RepositoryItemImageComboBox();
                                Base.InitRepositoryItemComboBox(cbxRepositoryItem, dr["sLookupNo"].ToString());
                                cols.ColumnEdit = cbxRepositoryItem;
                                gv.GridControl.RepositoryItems.Add(cbxRepositoryItem);
                            }
                            break;
                        }
                    //带按钮的文本框
                    case "btxt":
                        {
                            RepositoryItemMemoExEdit btxtRepositoryItem = new RepositoryItemMemoExEdit();
                            cols.ColumnEdit = btxtRepositoryItem;
                            gv.GridControl.RepositoryItems.Add(btxtRepositoryItem);
                            break;
                        }
                }
                cols.Caption = LangCenter.Instance.IsDefaultLanguage ? dr["sCaption"].ToString() : dr["sEngCaption"].ToString();
                cols.FieldName = dr["sFieldName"].ToString();
                //Grid 列命名为cols+列名+序号
                cols.Name = "cols" + dr["sFieldName"].ToString() + iIndex.ToString();
                cols.Width = 120;
                cols.Visible = true;
                cols.VisibleIndex = iIndex;
                iIndex++;
                //先计算有没有合计的，再计算计数
                if (dr["bIsSum"].ToString() != "" && Convert.ToBoolean(dr["bIsSum"]))
                {
                    cols.SummaryItem.FieldName = dr["sFieldName"].ToString();
                    cols.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, dr["sFieldName"].ToString(), cols);
                }
                if (dr["bIsCount"].ToString() != "" && Convert.ToBoolean(dr["bIsCount"]))
                {
                    cols.SummaryItem.FieldName = dr["sFieldName"].ToString();
                    cols.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gv.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, dr["sFieldName"].ToString(), cols);
                }
                gv.Columns.Add(cols);
            }
        }

        //设置为查询完成后自动跳转到Grid中的下一列中
        bool lkp_LookUpAfterPost(object sender, ButtonPressedEventArgs e)
        {
            OnKeyDown(new KeyEventArgs(Keys.Enter));
            return true;
        }

    }
}
