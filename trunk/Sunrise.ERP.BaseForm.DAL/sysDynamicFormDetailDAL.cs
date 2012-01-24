﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sunrise.ERP.DataAccess;
namespace Sunrise.ERP.BaseForm.DAL
{
    /// <summary>
    /// 数据访问类sysDynamicFormDetailDAL
    /// </summary>
    public class sysDynamicFormDetailDAL
    {
        public sysDynamicFormDetailDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM sysDynamicFormDetail");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DataRow dr, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO sysDynamicFormDetail(");
            strSql.Append("MainID,iSort,sFieldName,sCaption,sEngCaption,sFieldType,iFieldLength,sControlType,sLookupNo,bSaveData,bQuery,bSystemColumn,bNotNull,bHistory,bShowInGrid,sLocation,sSize,sUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("@MainID,@iSort,@sFieldName,@sCaption,@sEngCaption,@sFieldType,@iFieldLength,@sControlType,@sLookupNo,@bSaveData,@bQuery,@bSystemColumn,@bNotNull,@bHistory,@bShowInGrid,@sLocation,@sSize,@sUserID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@sFieldName", SqlDbType.VarChar,50),
					new SqlParameter("@sCaption", SqlDbType.VarChar,50),
					new SqlParameter("@sEngCaption", SqlDbType.VarChar,50),
					new SqlParameter("@sFieldType", SqlDbType.VarChar,30),
					new SqlParameter("@iFieldLength", SqlDbType.Int,4),
					new SqlParameter("@sControlType", SqlDbType.VarChar,30),
					new SqlParameter("@sLookupNo", SqlDbType.VarChar,30),
					new SqlParameter("@bSaveData", SqlDbType.Bit,1),
					new SqlParameter("@bQuery", SqlDbType.Bit,1),
					new SqlParameter("@bSystemColumn", SqlDbType.Bit,1),
					new SqlParameter("@bNotNull", SqlDbType.Bit,1),
					new SqlParameter("@bHistory", SqlDbType.Bit,1),
					new SqlParameter("@bShowInGrid", SqlDbType.Bit,1),
					new SqlParameter("@sLocation", SqlDbType.VarChar,50),
					new SqlParameter("@sSize", SqlDbType.VarChar,50),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["MainID"];
            parameters[1].Value = dr["iSort"];
            parameters[2].Value = dr["sFieldName"];
            parameters[3].Value = dr["sCaption"];
            parameters[4].Value = dr["sEngCaption"];
            parameters[5].Value = dr["sFieldType"];
            parameters[6].Value = dr["iFieldLength"];
            parameters[7].Value = dr["sControlType"];
            parameters[8].Value = dr["sLookupNo"];
            parameters[9].Value = dr["bSaveData"];
            parameters[10].Value = dr["bQuery"];
            parameters[11].Value = dr["bSystemColumn"];
            parameters[12].Value = dr["bNotNull"];
            parameters[13].Value = dr["bHistory"];
            parameters[14].Value = dr["bShowInGrid"];
            parameters[15].Value = dr["sLocation"];
            parameters[16].Value = dr["sSize"];
            parameters[17].Value = dr["sUserID"];

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), trans, parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DataRow dr, SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE sysDynamicFormDetail SET ");
            strSql.Append("MainID=@MainID,");
            strSql.Append("iSort=@iSort,");
            strSql.Append("sFieldName=@sFieldName,");
            strSql.Append("sCaption=@sCaption,");
            strSql.Append("sEngCaption=@sEngCaption,");
            strSql.Append("sFieldType=@sFieldType,");
            strSql.Append("iFieldLength=@iFieldLength,");
            strSql.Append("sControlType=@sControlType,");
            strSql.Append("sLookupNo=@sLookupNo,");
            strSql.Append("bSaveData=@bSaveData,");
            strSql.Append("bQuery=@bQuery,");
            strSql.Append("bSystemColumn=@bSystemColumn,");
            strSql.Append("bNotNull=@bNotNull,");
            strSql.Append("bHistory=@bHistory,");
            strSql.Append("bShowInGrid=@bShowInGrid,");
            strSql.Append("sLocation=@sLocation,");
            strSql.Append("sSize=@sSize,");
            strSql.Append("sUserID=@sUserID");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MainID", SqlDbType.Int,4),
					new SqlParameter("@iSort", SqlDbType.Int,4),
					new SqlParameter("@sFieldName", SqlDbType.VarChar,50),
					new SqlParameter("@sCaption", SqlDbType.VarChar,50),
					new SqlParameter("@sEngCaption", SqlDbType.VarChar,50),
					new SqlParameter("@sFieldType", SqlDbType.VarChar,30),
					new SqlParameter("@iFieldLength", SqlDbType.Int,4),
					new SqlParameter("@sControlType", SqlDbType.VarChar,30),
					new SqlParameter("@sLookupNo", SqlDbType.VarChar,30),
					new SqlParameter("@bSaveData", SqlDbType.Bit,1),
					new SqlParameter("@bQuery", SqlDbType.Bit,1),
					new SqlParameter("@bSystemColumn", SqlDbType.Bit,1),
					new SqlParameter("@bNotNull", SqlDbType.Bit,1),
					new SqlParameter("@bHistory", SqlDbType.Bit,1),
					new SqlParameter("@bShowInGrid", SqlDbType.Bit,1),
					new SqlParameter("@sLocation", SqlDbType.VarChar,50),
					new SqlParameter("@sSize", SqlDbType.VarChar,50),
					new SqlParameter("@sUserID", SqlDbType.VarChar,30)};
            parameters[0].Value = dr["ID"];
            parameters[1].Value = dr["MainID"];
            parameters[2].Value = dr["iSort"];
            parameters[3].Value = dr["sFieldName"];
            parameters[4].Value = dr["sCaption"];
            parameters[5].Value = dr["sEngCaption"];
            parameters[6].Value = dr["sFieldType"];
            parameters[7].Value = dr["iFieldLength"];
            parameters[8].Value = dr["sControlType"];
            parameters[9].Value = dr["sLookupNo"];
            parameters[10].Value = dr["bSaveData"];
            parameters[11].Value = dr["bQuery"];
            parameters[12].Value = dr["bSystemColumn"];
            parameters[13].Value = dr["bNotNull"];
            parameters[14].Value = dr["bHistory"];
            parameters[15].Value = dr["bShowInGrid"];
            parameters[16].Value = dr["sLocation"];
            parameters[17].Value = dr["sSize"];
            parameters[18].Value = dr["sUserID"];

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID, SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sysDynamicFormDetail ");
            strSql.Append(" WHERE ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), trans, parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM sysDynamicFormDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" * FROM sysDynamicFormDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY  " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}
