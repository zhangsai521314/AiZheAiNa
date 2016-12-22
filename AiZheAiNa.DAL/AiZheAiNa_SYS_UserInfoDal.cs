using System;
using System.Collections.Generic;
using System.Text;
using AiZheAiNa.IDAL;
using AiZheAiNa.Model.BusinessModel;
using AiZheAiNa.CommonHelp;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AiZheAiNa.DAL
{
    /// <summary>
    /// 本站用户接口
    /// </summary>
    public class AiZheAiNa_SYS_UserInfoDal : AiZheAiNa_SYS_UserInfoIDal
    {
        #region 查询相关

        #region 通过ID查询用户
        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AiZheAiNa_SYS_UserInfo GetModelAiZheAiNa_SYS_UserInfoByID(int id)
        {
            try
            {
                string sql = " select * from AiZheAiNa_SYS_UserInfo where ISValid=1 and id=@id";
                SqlParameter[] para = {
                    SqlHelper.MakeInParam("@id",SqlDbType.Int,15,id)
                };
                DataTable tb = SqlHelper.ExecuteDatatable(ConfigurationHelper.AiZheAiNaRead, CommandType.Text, sql, para);
                AiZheAiNa_SYS_UserInfo model_User = ModelConvertHelper<AiZheAiNa_SYS_UserInfo>.ConvertToModel(tb);
                return model_User;
            }
            catch (Exception ex)
            {
                return new AiZheAiNa_SYS_UserInfo();
            }
        }
        #endregion

        #region 查询所有有效用户
        /// <summary>
        /// 查询所有有效用户
        /// </summary>
        /// <returns></returns>
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserInfo()
        {
            try
            {
                string sql = " select * from AiZheAiNa_SYS_UserInfo where ISValid=1 ";
                DataTable tb = SqlHelper.ExecuteDatatable(ConfigurationHelper.AiZheAiNaRead, CommandType.Text, sql);
                List<AiZheAiNa_SYS_UserInfo> list_User = ModelConvertHelper<AiZheAiNa_SYS_UserInfo>.ConvertToModelList(tb);
                return list_User;
            }
            catch (Exception ex)
            {
                return new List<AiZheAiNa_SYS_UserInfo>();
            }
        }
        #endregion

        #region 根据登录名称查询用户
        /// <summary>
        /// 根据登录名称查询用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserInfoByLoginName(string loginName)
        {
            try
            {
                string sql = " select * from AiZheAiNa_SYS_UserInfo where ISValid=1 and loginName=@loginName";
                SqlParameter[] para = {
                    SqlHelper.MakeInParam("@loginName",SqlDbType.NVarChar,34,loginName)
                };
                DataTable tb = SqlHelper.ExecuteDatatable(ConfigurationHelper.AiZheAiNaRead, CommandType.Text, sql, para);
                List<AiZheAiNa_SYS_UserInfo> list_User = ModelConvertHelper<AiZheAiNa_SYS_UserInfo>.ConvertToModelList(tb);
                return list_User;
            }
            catch (Exception ex)
            {
                return new List<AiZheAiNa_SYS_UserInfo>();
            }
        }
        #endregion

        #region 根据条件查询用户
        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserInfoByParameter(Dictionary<string, string> parameter)
        {
            try
            {
                if (parameter == null || parameter.Count <= 0)
                {
                    return new List<AiZheAiNa_SYS_UserInfo>();
                }
                List<SqlParameter> listPara = new List<SqlParameter>();
                StringBuilder whereSql = new StringBuilder();
                foreach (var item in parameter)
                {
                    whereSql.Append(item.Key + "='" + item.Value + "' and ");
                    listPara.Add(new SqlParameter("@" + item.Key, item.Value));
                }
                whereSql.Append(" 1=1 ");
                string sql = " select * from AiZheAiNa_SYS_UserInfo where ISValid=1 and " + whereSql.ToString();
                DataTable tb = SqlHelper.ExecuteDatatable(ConfigurationHelper.AiZheAiNaRead, CommandType.Text, sql, listPara.ToArray());
                return ModelConvertHelper<AiZheAiNa_SYS_UserInfo>.ConvertToModelList(tb);
            }
            catch (Exception ex)
            {
                return new List<AiZheAiNa_SYS_UserInfo>();
            }
        }
        #endregion

        #endregion

        #region 更改相关


        #region 新增用户
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        public void AddAiZheAiNa_SYS_UserInfo(AiZheAiNa_SYS_UserInfo model)
        {
            try
            {
                string sql = @" insert into AiZheAiNa_SYS_UserInfo(LoginName, [PassWord],MingPassWord, ShowName, GenDer, UserSource, UserImg,UserSourceOnlySign, CreateDate, ISValid)
                                values( @LoginName, @PassWord,@MingPassWord,  @ShowName,  @GenDer,  @UserSource, @UserImg, @UserSourceOnlySign,  @CreateDate,  @ISValid) select @@IDENTITY";
                SqlParameter[] para = {
                    SqlHelper.MakeInParam("@LoginName",SqlDbType.Int,15,model.LoginName),
                    SqlHelper.MakeInParam("@PassWord",SqlDbType.NVarChar,50,model.PassWord),
                    SqlHelper.MakeInParam("@MingPassWord",SqlDbType.NVarChar,50,model.MingPassWord),
                    SqlHelper.MakeInParam("@ShowName",SqlDbType.NVarChar,50,model.ShowName),
                    SqlHelper.MakeInParam("@GenDer",SqlDbType.NVarChar,6,model.GenDer),
                    SqlHelper.MakeInParam("@UserSource",SqlDbType.Int,2,model.UserSource),
                    SqlHelper.MakeInParam("@UserImg",SqlDbType.NVarChar,300,model.UserImg),
                    SqlHelper.MakeInParam("@UserSourceOnlySign",SqlDbType.NVarChar,100,model.UserSourceOnlySign),
                    SqlHelper.MakeInParam("@CreateDate",SqlDbType.DateTime,32,model.CreateDate),
                    SqlHelper.MakeInParam("@ISValid",SqlDbType.Bit,2,model.ISValid)
                };
                model.ID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationHelper.AiZheAiNaWrite, CommandType.Text, sql, para));
            }
            catch (Exception ex)
            {
                model = new AiZheAiNa_SYS_UserInfo();
            }
        }
        #endregion

        #region 更新用户
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        public int UpdateAiZheAiNa_SYS_UserInfo(AiZheAiNa_SYS_UserInfo model)
        {
            string sql = "UPDATE [AiZheAiNa_SYS_UserInfo] SET ";
            List<SqlParameter> listPara = new List<SqlParameter>();
            try
            {
                foreach (PropertyInfo p in model.GetType().GetProperties())
                {
                    if (p.GetValue(model, null) != null)
                    {

                        if (p.Name.ToLower() == "id")
                        {
                            listPara.Add(new SqlParameter("@" + p.Name, p.GetValue(model, null)));
                        }
                        else
                        {
                            sql += " [" + p.Name + "] = @" + p.Name + ",";
                            listPara.Add(new SqlParameter("@" + p.Name, ToDBValue(p.GetValue(model, null))));
                        }
                    }
                }
                sql = sql.Substring(0, sql.Length - 1) + " WHERE ID = @ID";
                return SqlHelper.ExecuteNonQuery(ConfigurationHelper.AiZheAiNaWrite, CommandType.Text, sql, listPara.ToArray());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #endregion

        #region ToDBValue
        public object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
        #endregion
    }
}
