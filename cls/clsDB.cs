using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Text;

namespace WebMaintenance.cls
{
    public class clsDB
    {
        #region Public variables        
        public string ConStr = ConfigurationManager.ConnectionStrings["PTSConnectionString"].ConnectionString.ToString();
        public string ConStrWeb = ConfigurationManager.ConnectionStrings["PTSWebConnectionString"].ConnectionString.ToString();
        SqlConnection dbconn;
        SqlDataReader dr;
        #endregion
        public void Populate_ddlYear(object ctrlDropDown)
        {
            DropDownList objDdlList = new DropDownList();
            objDdlList = (DropDownList)ctrlDropDown;
            objDdlList.ClearSelection();
            for (int i = 0; i < 4; i++)
            {
                objDdlList.Items.Add((DateTime.Now.Year - i).ToString());
            }
        }
        public bool ValidateLog(string SqlQuery, string strConStr)
        {
            bool flagValidEntry = false;
            //Step 1. Declare and Identify Database connection;
            //SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(SqlQuery, dbconn);
            try
            {
                dbconn.Open();
                int intCount = Convert.ToInt32(executeCmd.ExecuteScalar());
                if (intCount < 1)
                {
                    flagValidEntry = true;
                }
                else
                {
                    flagValidEntry = false;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                executeCmd.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
            return flagValidEntry;
        }

        public string GetParam(string SqlQuery, string varParam)
        {
            string strParam = "";
            //Step 1. Declare and Identify Database connection;
            SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand logCmd;
            logCmd = new SqlCommand(SqlQuery, dbconn);
            try
            {
                dbconn.Open();
                dr = logCmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    strParam = dr[varParam].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                //Session.Add("varException", ex.ToString());
                //dbconn.Close();
            }
            finally
            {

                dbconn.Close();
                dbconn.Dispose();
            }
            return strParam;
        }
        public string GetParam(string SqlQuery, string varParam, string strConStr)
        {
            string strParam = "";
            //Step 1. Declare and Identify Database connection;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand logCmd;
            logCmd = new SqlCommand(SqlQuery, dbconn);
            try
            {
                dbconn.Open();
                dr = logCmd.ExecuteReader();
                while (dr.Read() == true)
                {
                    strParam = dr[varParam].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                //Session.Add("varException", ex.ToString());
                //dbconn.Close();
            }
            finally
            {

                dbconn.Close();
                dbconn.Dispose();
            }
            return strParam;
        }
        public void Execute_Query(string SqlQuery)
        {
            //Step 1. Declare and Identify Database connection;
            SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand logCmd = new SqlCommand(SqlQuery, dbconn);
            try
            {
                dbconn.Open();
                logCmd.ExecuteNonQuery();
                logCmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dbconn.Close();
                dbconn.Dispose();
            }
        }

        public void Execute_SP(string SqlQuery, string strConStr)
        {
            //Step 1. Declare and Identify Database connection;
            //SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(SqlQuery, dbconn);
            try
            {
                dbconn.Open();
                executeCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                executeCmd.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public bool Execute_SP_bool(string SqlQuery)
        {
            bool fl = false;
            //Step 1. Declare and Identify Database connection;
            //SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(SqlQuery, dbconn);
            try
            {
                dbconn.Open();
                executeCmd.ExecuteNonQuery();
                fl = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                executeCmd.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
            return fl;
        }
        public void Execute_SP(string SqlQuery)
        {
            //Step 1. Declare and Identify Database connection;
            //SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(SqlQuery, dbconn);
            try
            {
                dbconn.Open();
                executeCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                executeCmd.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void Universal_SP(string strSPName, string strParamName, string strParamValue, string strParamType)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);

            SqlCommand sqlcmd = new SqlCommand(strSPName, dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            try
            {
                switch (strParamType)
                {
                    case "int":
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.Int));
                            sqlcmd.Parameters[strParamName].Value = Convert.ToInt32(strParamValue);
                            break;
                        }
                    case "string":
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.NVarChar));
                            sqlcmd.Parameters[strParamName].Value = strParamValue;
                            break;
                        }
                    default:
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.NVarChar));
                            sqlcmd.Parameters[strParamName].Value = strParamValue;
                            break;
                        }
                }



                dbconn.Open();

                SqlDataReader sqldr = sqlcmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public DataSet Universal_SP_DS(string strSPName, string strParamName, string strParamValue, string strParamType)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);

            SqlCommand sqlcmd = new SqlCommand(strSPName, dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            try
            {
                switch (strParamType)
                {
                    case "int":
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.Int));
                            sqlcmd.Parameters[strParamName].Value = Convert.ToInt32(strParamValue);
                            break;
                        }
                    case "string":
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.NVarChar));
                            sqlcmd.Parameters[strParamName].Value = strParamValue;
                            break;
                        }
                    default:
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.NVarChar));
                            sqlcmd.Parameters[strParamName].Value = strParamValue;
                            break;
                        }
                }

                dbconn.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    //cmd.Connection = con;
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //sda.SelectCommand = cmd;
                    using (DataSet myds = new DataSet())
                    {
                        sda.Fill(myds, strSPName);
                        return myds;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public DataTable Universal_SP_DT(string strSPName, string strParamName, string strParamValue, string strParamType)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);

            SqlCommand sqlcmd = new SqlCommand(strSPName, dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            try
            {
                switch (strParamType)
                {
                    case "int":
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.Int));
                            sqlcmd.Parameters[strParamName].Value = Convert.ToInt32(strParamValue);
                            break;
                        }
                    case "string":
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.NVarChar));
                            sqlcmd.Parameters[strParamName].Value = strParamValue;
                            break;
                        }
                    default:
                        {
                            sqlcmd.Parameters.Add(new SqlParameter(strParamName, SqlDbType.NVarChar));
                            sqlcmd.Parameters[strParamName].Value = strParamValue;
                            break;
                        }
                }

                dbconn.Open();

                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);

                return dTable;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public DataTable myDT(string SqlQuery, string strConStr)
        {
            string strErr;
            DataTable dtGet = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(dtGet);
                            if (dtGet.Rows.Count == 0)
                            {
                                return null;
                                //throw new Exception("no rows returned from db query");
                            }
                        }
                        cmd.Dispose();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (SqlException ex)
            {
                strErr = ex.Message;
            }
            return dtGet;
        }
        public DataTable myDT(string SqlQuery)
        {
            string strErr;
            DataTable dtGet = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlQuery, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(dtGet);
                            if (dtGet.Rows.Count == 0)
                            {
                                return null;
                                //throw new Exception("no rows returned from db query");
                            }
                        }
                        cmd.Dispose();
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (SqlException ex)
            {
                strErr = ex.Message;
            }
            return dtGet;
        }
        public DataTable UniversalPO(string strParam)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);

            SqlCommand sqlcmd = new SqlCommand("spUniversalQuery", dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlcmd.Parameters.Add(new SqlParameter("@varParam", SqlDbType.NVarChar));
                sqlcmd.Parameters["@varParam"].Value = strParam;
                dbconn.Open();

                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);

                return dTable;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public DataTable UniversalPO(string strSPName, string strParam)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);

            SqlCommand sqlcmd = new SqlCommand(strSPName, dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlcmd.Parameters.Add(new SqlParameter("@varParam", SqlDbType.NVarChar));
                sqlcmd.Parameters["@varParam"].Value = strParam;
                dbconn.Open();

                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);

                return dTable;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        //-----2 param
        public DataTable UniversalPO(string strSPName, string strP1_Name, string strP2_Name, string strP1_Value, string strP2_Value)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);

            SqlCommand sqlcmd = new SqlCommand(strSPName, dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlcmd.Parameters.AddWithValue("@Yr", Convert.ToInt32(strP1_Value));
                sqlcmd.Parameters.AddWithValue("@Sort", Convert.ToInt32(strP2_Value));
                //sqlcmd.Parameters.Add(new SqlParameter(strP1_Name, SqlDbType.SmallInt));
                //sqlcmd.Parameters["@Yr"].Value = Convert.ToInt16(strP1_Value);
                //sqlcmd.Parameters.Add(new SqlParameter(strP2_Name, SqlDbType.SmallInt));
                //sqlcmd.Parameters["@Sort"].Value = Convert.ToInt16(strP2_Value);
                //sqlcmd.Parameters.Add(new SqlParameter("@Year", SqlDbType.SmallInt));
                //sqlcmd.Parameters["@Year"].Value = Convert.ToInt16(strP1);
                //sqlcmd.Parameters.Add(new SqlParameter("@SpID", SqlDbType.SmallInt));
                //sqlcmd.Parameters["@SpID"].Value = Convert.ToInt16(strP2);                
                dbconn.Open();

                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);

                return dTable;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }

        //-----3 param
        public DataTable UniversalPO(string strSPName, string strP1, string strP2, string strP3)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);

            SqlCommand sqlcmd = new SqlCommand(strSPName, dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlcmd.Parameters.Add(new SqlParameter("@Year", SqlDbType.SmallInt));
                sqlcmd.Parameters["@Year"].Value = Convert.ToInt16(strP1);
                sqlcmd.Parameters.Add(new SqlParameter("@SpID", SqlDbType.SmallInt));
                sqlcmd.Parameters["@SpID"].Value = Convert.ToInt16(strP2);
                sqlcmd.Parameters.Add(new SqlParameter("@SC", SqlDbType.SmallInt));
                sqlcmd.Parameters["@SC"].Value = Convert.ToInt16(strP3);
                dbconn.Open();

                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);

                return dTable;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public DataTable UniversalPO_3(string strParam, string strP1, string strP2, string strP3)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);
            SqlCommand sqlcmd = new SqlCommand("spUniversalQuery_3", dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.Add(new SqlParameter("@varParam", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP1", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP2", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP3", SqlDbType.NVarChar));
            sqlcmd.Parameters["@varParam"].Value = strParam;
            sqlcmd.Parameters["@varP1"].Value = strP1;
            sqlcmd.Parameters["@varP2"].Value = strP2;
            sqlcmd.Parameters["@varP3"].Value = strP3;

            try
            {
                dbconn.Open();
                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);
                return dTable;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public DataTable PopulateFields_3(string strParam, string strP1, string strP2, string strP3)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);
            SqlCommand sqlcmd = new SqlCommand("sp_PopulateFields_3", dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.Add(new SqlParameter("@varParam", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP1", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP2", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP3", SqlDbType.NVarChar));
            sqlcmd.Parameters["@varParam"].Value = strParam;
            sqlcmd.Parameters["@varP1"].Value = strP1;
            sqlcmd.Parameters["@varP2"].Value = strP2;
            sqlcmd.Parameters["@varP3"].Value = strP3;

            try
            {
                dbconn.Open();
                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);
                return dTable;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public DataTable Universal_Manufacturers_3(string strAction, string strP1, string strP2, string strP3)
        {
            //Step 1. Declare and Identify Database connection;            
            dbconn = new SqlConnection(ConStr);
            SqlCommand sqlcmd = new SqlCommand("sp_InsUpdSel_Manufacturers", dbconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.Add(new SqlParameter("@varAction", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP1", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP2", SqlDbType.NVarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@varP3", SqlDbType.NVarChar));
            sqlcmd.Parameters["@varAction"].Value = strAction;
            sqlcmd.Parameters["@varP1"].Value = strP1;
            sqlcmd.Parameters["@varP2"].Value = strP2;
            sqlcmd.Parameters["@varP3"].Value = strP3;

            try
            {
                dbconn.Open();
                SqlDataReader sqldr = sqlcmd.ExecuteReader();
                DataTable dTable = new DataTable();
                dTable.Load(sqldr);
                return dTable;
            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;

            }
            finally
            {
                sqlcmd.Dispose(); dbconn.Close(); dbconn.Dispose();
            }
        }
        public void PopulateGridView(string sqlQuery, object ctrlGridView, string strConStr)
        {
            GridView objGridView = new GridView();
            objGridView = (GridView)ctrlGridView;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(sqlQuery, dbconn);
            try
            {
                dbconn.Open();
                dr = executeCmd.ExecuteReader();
                objGridView.DataSource = dr;
                objGridView.DataBind();

                dr.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dr.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateGridView(string sqlQuery, object ctrlGridView)
        {
            GridView objGridView = new GridView();
            objGridView = (GridView)ctrlGridView;
            SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(sqlQuery, dbconn);
            try
            {
                dbconn.Open();
                dr = executeCmd.ExecuteReader();
                objGridView.DataSource = dr;
                objGridView.DataBind();

                dr.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dr.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void BindGridView(string sqlQuery, object ctrlGridView)
        {
            GridView objGridView = new GridView();
            objGridView = (GridView)ctrlGridView;
            SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(sqlQuery, dbconn);
            //Declare SqlDataAdapter;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = executeCmd;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                objGridView.DataSource = dt;
                objGridView.DataBind();
            }
        }
        public void PopulateDataList(string sqlQuery, object ctrlDataList, string strConStr)
        {
            DataList objDataList = new DataList();

            objDataList = (DataList)ctrlDataList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Declare sqlCommand;
            SqlCommand executeCmd;
            executeCmd = new SqlCommand(sqlQuery, dbconn);
            try
            {
                dbconn.Open();
                dr = executeCmd.ExecuteReader();
                objDataList.DataSource = dr;
                objDataList.DataBind();

                dr.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dr.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateBulletedList(string sqlQuery, string strText, object ctrlBltList, string strConStr)
        {
            BulletedList objBltList = new BulletedList();
            objBltList = (BulletedList)ctrlBltList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);

            try
            {
                dbconn.Open();
                objBltList.Items.Clear();
                dr = executeCmd.ExecuteReader();
                while (dr.Read())
                {
                    string strBltTxt = dr[strText].ToString();
                    if (strBltTxt != "")
                    {
                        strBltTxt.Trim();
                        objBltList.Items.Add(strBltTxt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dr.Close();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateCheckBoxList(string sqlQuery, string strText, object ctrlChkBoxList)
        {
            CheckBoxList objChkBoxList = new CheckBoxList();
            objChkBoxList = (CheckBoxList)ctrlChkBoxList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);

            try
            {
                dbconn.Open();
                objChkBoxList.Items.Clear();
                dr = executeCmd.ExecuteReader();
                while (dr.Read())
                {
                    string strChkTxt = dr[strText].ToString();
                    if (strChkTxt != "")
                    {
                        strChkTxt.Trim();
                        objChkBoxList.Items.Add(strChkTxt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dr.Close();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateCheckBoxList(string sqlQuery, string strText, object ctrlChkBoxList, string strConStr)
        {
            CheckBoxList objChkBoxList = new CheckBoxList();
            objChkBoxList = (CheckBoxList)ctrlChkBoxList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);

            try
            {
                dbconn.Open();
                objChkBoxList.Items.Clear();
                dr = executeCmd.ExecuteReader();
                while (dr.Read())
                {
                    string strChkTxt = dr[strText].ToString();
                    if (strChkTxt != "")
                    {
                        strChkTxt.Trim();
                        objChkBoxList.Items.Add(strChkTxt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dr.Close();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateCheckBoxList(string sqlQuery, string strText, string strValue, object ctrlChkBoxList, string strConStr)
        {
            CheckBoxList objChkBoxList = new CheckBoxList();
            objChkBoxList = (CheckBoxList)ctrlChkBoxList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);

            try
            {
                dbconn.Open();
                objChkBoxList.Items.Clear();
                dr = executeCmd.ExecuteReader();
                while (dr.Read())
                {
                    string strChkTxt = dr[strText].ToString();
                    string strChkVal = dr[strValue].ToString();
                    if (strChkTxt != "" && strValue != "")
                    {
                        strChkTxt.Trim();
                        objChkBoxList.Items.Add(new ListItem(strChkTxt, strChkVal));
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dr.Close();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateRadioButtonList(string sqlQuery, string strText, string strValue, object ctrlRbtnList, string strConStr)
        {
            RadioButtonList objRbtnList = new RadioButtonList();
            //CheckBoxList objChkBoxList = new CheckBoxList();
            objRbtnList = (RadioButtonList)ctrlRbtnList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Step 3. Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);

            try
            {
                dbconn.Open();
                objRbtnList.Items.Clear();
                dr = executeCmd.ExecuteReader();
                while (dr.Read())
                {
                    string strRbtnTxt = dr[strText].ToString();
                    string strRbtnVal = dr[strValue].ToString();
                    if (strRbtnTxt != "" && strValue != "")
                    {
                        strRbtnTxt.Trim();
                        objRbtnList.Items.Add(new ListItem(strRbtnTxt, strRbtnVal));
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dr.Close();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateDropDownList(string sqlQuery, string strValue, string strText,
                                          object ctrlddlList, string strDefaultVal, string strDefaultTxt, string strConStr)
        {
            DropDownList objDdlList = new DropDownList();
            objDdlList = (DropDownList)ctrlddlList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(strConStr);
            //Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);
            try
            {
                dbconn.Open();
                objDdlList.Items.Clear();
                dr = executeCmd.ExecuteReader();
                if (strDefaultVal != "" && strDefaultTxt != "")
                {
                    objDdlList.Items.Add(new ListItem(strDefaultTxt, strDefaultVal));
                }
                while (dr.Read())
                {
                    string strDdlTxt = dr[strText].ToString();
                    string strDdlVal = dr[strValue].ToString();
                    if (strDdlTxt != "" && strDdlVal != "")
                    {
                        strDdlTxt = System.Web.HttpUtility.HtmlDecode(strDdlTxt).Trim();
                        strDdlVal = System.Web.HttpUtility.HtmlDecode(strDdlVal).Trim();
                        objDdlList.Items.Add(new ListItem(strDdlTxt, strDdlVal));
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                //Session.Add("varException", ex.ToString());
                //dbconn.Close();
            }
            finally
            {
                dr.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateDropDownList(string sqlQuery, string strValue, string strText,
                                         object ctrlddlList, string strDefaultVal, string strDefaultTxt)
        {
            DropDownList objDdlList = new DropDownList();
            objDdlList = (DropDownList)ctrlddlList;
            SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);
            try
            {
                dbconn.Open();
                objDdlList.Items.Clear();
                dr = executeCmd.ExecuteReader();
                if (strDefaultVal != "" && strDefaultTxt != "")
                {
                    objDdlList.Items.Add(new ListItem(strDefaultTxt, strDefaultVal));
                }
                while (dr.Read())
                {
                    string strDdlTxt = dr[strText].ToString();
                    string strDdlVal = dr[strValue].ToString();
                    if (strDdlTxt != "" && strDdlVal != "")
                    {
                        strDdlTxt = System.Web.HttpUtility.HtmlDecode(strDdlTxt).Trim();
                        strDdlVal = System.Web.HttpUtility.HtmlDecode(strDdlVal).Trim();
                        objDdlList.Items.Add(new ListItem(strDdlTxt, strDdlVal));
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                //Session.Add("varException", ex.ToString());
                //dbconn.Close();
            }
            finally
            {
                dr.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
        public void PopulateListBox(string sqlQuery, string strValue, string strText,
                                         object ctrllstBox)
        {
            ListBox objLstBox = new ListBox();

            objLstBox = (ListBox)ctrllstBox;
            SqlConnection dbconn;
            dbconn = new SqlConnection(ConStr);
            //Declare sqlCommand;
            SqlCommand executeCmd = new SqlCommand(sqlQuery, dbconn);
            try
            {
                dbconn.Open();
                objLstBox.Items.Clear();
                dr = executeCmd.ExecuteReader();
                while (dr.Read())
                {
                    string strDdlTxt = dr[strText].ToString();
                    string strDdlVal = dr[strValue].ToString();
                    if (strDdlTxt != "" && strDdlVal != "")
                    {
                        strDdlTxt = System.Web.HttpUtility.HtmlDecode(strDdlTxt).Trim();
                        strDdlVal = System.Web.HttpUtility.HtmlDecode(strDdlVal).Trim();
                        objLstBox.Items.Add(new ListItem(strDdlTxt, strDdlVal));
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                //Session.Add("varException", ex.ToString());
                //dbconn.Close();
            }
            finally
            {
                dr.Dispose();
                dbconn.Close();
                dbconn.Dispose();
            }
        }
    }
}