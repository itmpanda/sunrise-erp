﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sunrise.ERP.Module.Test
{
    public partial class frmTest2 : Sunrise.ERP.BaseForm.frmDynamicSingleForm
    {
        public frmTest2(int formid, string formtext)
            : base(formid, "salTest2")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(formtext))
                Text = formtext;
            //创建自定义字段列
            CreateDynamicControl();
            CreateMasterGridColumn(gvMain);

        }
    }
}
