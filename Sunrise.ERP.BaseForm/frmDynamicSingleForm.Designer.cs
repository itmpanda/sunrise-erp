﻿namespace Sunrise.ERP.BaseForm
{
    partial class frmDynamicSingleForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dsMain = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.sptUpDown = new DevExpress.XtraEditors.SplitterControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.pnlInfo = new DevExpress.XtraEditors.PanelControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlDynamic = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDynamic)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.LookAndFeel.SkinName = "Blue";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Size = new System.Drawing.Size(963, 33);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(895, 3);
            this.btnInsert.LookAndFeel.SkinName = "Blue";
            this.btnInsert.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCopy
            // 
            this.btnCopy.LookAndFeel.SkinName = "Blue";
            this.btnCopy.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnPrint
            // 
            this.btnPrint.LookAndFeel.SkinName = "Blue";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnClose
            // 
            this.btnClose.LookAndFeel.SkinName = "Blue";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnDelete
            // 
            this.btnDelete.LookAndFeel.SkinName = "Blue";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnCancel
            // 
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnSave
            // 
            this.btnSave.LookAndFeel.SkinName = "Blue";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnEdit
            // 
            this.btnEdit.LookAndFeel.SkinName = "Blue";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnAdd
            // 
            this.btnAdd.LookAndFeel.SkinName = "Blue";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnView
            // 
            this.btnView.LookAndFeel.SkinName = "Blue";
            this.btnView.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(926, 3);
            this.btnRefresh.LookAndFeel.SkinName = "Blue";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // txtDataFlag
            // 
            // 
            // btnProperty
            // 
            this.btnProperty.LookAndFeel.SkinName = "Blue";
            this.btnProperty.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnProperty.Visible = true;
            this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
            // 
            // dataNav
            // 
            this.dataNav.Buttons.Append.Visible = false;
            this.dataNav.Buttons.CancelEdit.Visible = false;
            this.dataNav.Buttons.EndEdit.Visible = false;
            this.dataNav.Buttons.NextPage.Visible = false;
            this.dataNav.Buttons.PrevPage.Visible = false;
            this.dataNav.Buttons.Remove.Visible = false;
            this.dataNav.DataSource = this.dsMain;
            this.dataNav.Visible = true;
            // 
            // btnAction
            // 
            this.btnAction.LookAndFeel.SkinName = "Blue";
            this.btnAction.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAction.Visible = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pnlGrid);
            this.panelControl1.Controls.Add(this.sptUpDown);
            this.panelControl1.Controls.Add(this.pnlMain);
            this.panelControl1.LookAndFeel.SkinName = "Blue";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Size = new System.Drawing.Size(967, 498);
            this.panelControl1.Controls.SetChildIndex(this.txtDataFlag, 0);
            this.panelControl1.Controls.SetChildIndex(this.panelControl2, 0);
            this.panelControl1.Controls.SetChildIndex(this.pnlMain, 0);
            this.panelControl1.Controls.SetChildIndex(this.sptUpDown, 0);
            this.panelControl1.Controls.SetChildIndex(this.pnlGrid, 0);
            // 
            // dsMain
            // 
            this.dsMain.CurrentChanged += new System.EventHandler(this.dsMain_CurrentChanged);
            this.dsMain.CurrentItemChanged += new System.EventHandler(this.dsMain_CurrentItemChanged);
            // 
            // toolTipController1
            // 
            this.toolTipController1.Rounded = true;
            this.toolTipController1.ShowBeak = true;
            // 
            // sptUpDown
            // 
            this.sptUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.sptUpDown.Location = new System.Drawing.Point(2, 240);
            this.sptUpDown.MinExtra = 0;
            this.sptUpDown.MinSize = 0;
            this.sptUpDown.Name = "sptUpDown";
            this.sptUpDown.Size = new System.Drawing.Size(963, 6);
            this.sptUpDown.TabIndex = 7;
            this.sptUpDown.TabStop = false;
            this.sptUpDown.DoubleClick += new System.EventHandler(this.sptUpDown_DoubleClick);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(2, 246);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(963, 250);
            this.pnlGrid.TabIndex = 8;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(2, 2);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(959, 191);
            this.pnlInfo.TabIndex = 6;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Controls.Add(this.pnlDynamic);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(2, 35);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(963, 205);
            this.pnlMain.TabIndex = 9;
            // 
            // pnlDynamic
            // 
            this.pnlDynamic.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDynamic.Location = new System.Drawing.Point(2, 193);
            this.pnlDynamic.Name = "pnlDynamic";
            this.pnlDynamic.Size = new System.Drawing.Size(959, 10);
            this.pnlDynamic.TabIndex = 7;
            this.pnlDynamic.Visible = false;
            // 
            // frmDynamicSingleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(967, 498);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmDynamicSingleForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDynamic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.BindingSource dsMain;
        private DevExpress.Utils.ToolTipController toolTipController1;
        protected DevExpress.XtraEditors.PanelControl pnlGrid;
        protected DevExpress.XtraEditors.SplitterControl sptUpDown;
        protected DevExpress.XtraEditors.PanelControl pnlInfo;
        protected DevExpress.XtraEditors.PanelControl pnlMain;
        protected DevExpress.XtraEditors.PanelControl pnlDynamic;
    }
}
