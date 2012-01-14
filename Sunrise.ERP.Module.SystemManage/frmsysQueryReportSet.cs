﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.SystemManage
{
    public partial class frmsysQueryReportSet : Sunrise.ERP.BaseForm.frmMasterDetail
    {
        public frmsysQueryReportSet(int formid, string formtext)
            : base(formid, "Sunrise.ERP.SystemManage.DAL", "sysQueryReportMasterDAL", "AND 1=1", "sReportNo")
        {
            InitializeComponent();
            if (formtext != "")
            {
                this.Text = formtext;
            }
            txtiControlColumn.DataBindings.Add("EditValue", dsMain, "iControlColumn");
            txtiControlSpace.DataBindings.Add("EditValue", dsMain, "iControlSpace");
            txtsDealFields.DataBindings.Add("EditValue", dsMain, "sDealFields");
            txtsExecBtnText.DataBindings.Add("EditValue", dsMain, "sExecBtnText");
            txtsExecSQL.DataBindings.Add("EditValue", dsMain, "sExecSQL");
            txtsReportName.DataBindings.Add("EditValue", dsMain, "sReportName");
            txtsReportNo.DataBindings.Add("EditValue", dsMain, "sReportNo");
            txtsReportSQL.DataBindings.Add("EditValue", dsMain, "sReportSQL");
            txtsSortFields.DataBindings.Add("EditValue", dsMain, "sSortFields");
            chkbIsAutoRun.DataBindings.Add("EditValue", dsMain, "bIsAutoRun");
            chkbIsChart.DataBindings.Add("EditValue", dsMain, "bIsChart");
            chkbIsShowExecBtn.DataBindings.Add("EditValue", dsMain, "bIsShowExecBtn");
            chkbIsShowPrintBtn.DataBindings.Add("EditValue", dsMain, "bIsShowPrintBtn");
        }

        private void frmsysQueryReportSet_Load(object sender, EventArgs e)
        {
            AddDetailData("sysQueryReportDetailDAL", "MainID", "ID", "iSort");
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysQueryReportDetailDAL")];
            gcDetail.DataMember = "ds";
            DataStateChange(sender, e);
        }
        public override void DataStateChange(object sender, EventArgs e)
        {
            base.DataStateChange(sender, e);
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsEdit || FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsInsert)
            {
                gvDetail.OptionsBehavior.Editable = true;
                pnlDetailMenu.Enabled = true;
            }
            else
            {
                gvDetail.OptionsBehavior.Editable = false;
                pnlDetailMenu.Enabled = false;
            }
        }
        public override void initBase()
        {
            AddNotNullFields(new string[] { "txtsReportNo", "txtsReportName", "txtsReportSQL" });
            AddNotCopyFields(new string[] { "sUserID", "iFlag" });
            base.initBase();
        }
        public override void MasterAllScroll(object sender, EventArgs e)
        {
            base.MasterAllScroll(sender, e);
            AutoSetFieldNameToComboBox(((DataRowView)(dsMain.Current))["sReportSQL"].ToString());
            gcDetail.DataSource = LDetailDataSet[LDetailDALName.IndexOf("sysQueryReportDetailDAL")];
        }
        public override bool DoAppend()
        {
            base.DoAppend();
            //新增默认值
            Sunrise.ERP.Common.SystemPublic.GetBillNo(FormID, (DataRowView)dsMain.Current);
            ((DataRowView)dsMain.Current).Row["iControlSpace"] = 10;
            ((DataRowView)dsMain.Current).Row["iControlColumn"] = 3;
            ((DataRowView)dsMain.Current).Row["bIsShowPrintBtn"] = false;
            ((DataRowView)dsMain.Current).Row["bIsShowExecBtn"] = false;
            ((DataRowView)dsMain.Current).Row["bIsChart"] = false;
            ((DataRowView)dsMain.Current).Row["bIsAutoRun"] = false;
            ((DataRowView)dsMain.Current).Row["sDealFields"] = "*";
            dsMain.EndEdit();
            return true;
        }

        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            gvDetail.AddNewRow();
        }

        private void btnDetailDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDetail.RowCount > 0 && gvDetail.FocusedRowHandle >= 0)
                {
                    gvDetail.DeleteRow(gvDetail.FocusedRowHandle);
                }
            }
            catch (Exception)
            {
            }

        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (gvDetail.RowCount == 1)
            {
                gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["iSort"] = gvDetail.RowCount;
            }
            else if (gvDetail.RowCount > 1)
            {
                gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["iSort"] = Convert.ToInt32(gvDetail.GetDataRow(gvDetail.RowCount - 2)["iSort"]) + 1;
            }
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["sUserID"] = Sunrise.ERP.Security.SecurityCenter.CurrentUserID;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bIsShow"] = 0;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bIsQuery"] = 0;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bChartField"] = 0;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bChartValue"] = 0;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bIsGroup"] = 0;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bIsCount"] = 0;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bIsSum"] = 0;
            gvDetail.GetDataRow(gvDetail.FocusedRowHandle)["bIsStat"] = 0;

        }
        /// <summary>
        /// 自动设置查询SQL中的字段到明细中的字段列
        /// </summary>
        private void AutoSetFieldNameToComboBox(string MainSQL)
        {
            try
            {
                cbxFieldName.Items.Clear();
                string sSql = "SELECT A.* FROM (" + MainSQL + ") A WHERE 1=2 ";
                DataTable dtTemp = Sunrise.ERP.DataAccess.DbHelperSQL.Query(sSql).Tables[0];
                if (dtTemp != null)
                {
                    foreach (DataColumn item in dtTemp.Columns)
                    {
                        cbxFieldName.Items.Add(item.ColumnName);
                    }
                }

            }
            catch (Exception)
            {
            }
        }

        private void cbxFieldName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (dsMain.Current != null)
            {
                if (cbxFieldName.Items.Count <= 0)
                {
                    AutoSetFieldNameToComboBox(((DataRowView)(dsMain.Current))["sReportSQL"].ToString());
                }
            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (FormDataFlag == Sunrise.ERP.BasePublic.DataFlag.dsBrowse)
            {
                if (dsMain.Current != null)
                {

                }
            }
            //frmsysQueryReport frm=
        }

    }
}
