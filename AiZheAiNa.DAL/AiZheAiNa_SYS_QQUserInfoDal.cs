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
    public class AiZheAiNa_SYS_QQUserInfoDal : AiZheAiNa_SYS_QQUserInfoInfoIDal
    {
        #region 查询相关

        #region 通过OpenID查询用户
        /// <summary>
        /// 通过OpenID查询用户
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public AiZheAiNa_SYS_QQUserInfo GetModelAiZheAiNa_SYS_QQUserInfoByOpenID(int OpenID)
        {
            try
            {
                string sql = " select * from AiZheAiNa_SYS_QQUserInfo where  OpenID=@OpenID";
                SqlParameter[] para = {
                    SqlHelper.MakeInParam("@id",SqlDbType.Int,200,OpenID)
                };
                DataTable tb = SqlHelper.ExecuteDatatable(ConfigurationHelper.AiZheAiNaRead, CommandType.Text, sql, para);
                AiZheAiNa_SYS_QQUserInfo model_User = ModelConvertHelper<AiZheAiNa_SYS_QQUserInfo>.ConvertToModel(tb);
                return model_User;
            }
            catch (Exception ex)
            {
                return new AiZheAiNa_SYS_QQUserInfo();
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
        public void AddAiZheAiNa_SYS_QQUserInfo(AiZheAiNa_SYS_QQUserInfo model)
        {
            try
            {
                string sql = @" insert into AiZheAiNa_SYS_QQUserInfo(OpenID, Nickname, Access_token, Access_tokenExpiresIn, Access_tokenExpiresDate, Refresh_token, Province, City, Year, Figureurl, Figureurl_1, Figureurl_2, Figureurl_qq_1, Figureurl_qq_2, Is_yellow_vip, Vip, Yellow_vip_level, Level, Is_yellow_year_vip)
                                values(@OpenID, @Nickname, @Access_token, @Access_tokenExpiresIn, @Access_tokenExpiresDate, @Refresh_token, @Province, @City, @Year, @Figureurl, @Figureurl_1, @Figureurl_2, @Figureurl_qq_1, @Figureurl_qq_2, @Is_yellow_vip, @Vip, @Yellow_vip_level, @Level, @Is_yellow_year_vip) select OpenID from AiZheAiNa_SYS_QQUserInfo where @OpenID=@OpenID";
                SqlParameter[] para = {
                    SqlHelper.MakeInParam("@OpenID",SqlDbType.NVarChar,100,model.OpenID),
                    SqlHelper.MakeInParam("@Nickname",SqlDbType.NVarChar,64,model.Nickname),
                    SqlHelper.MakeInParam("@Access_token",SqlDbType.NVarChar,300,model.Access_token),
                    SqlHelper.MakeInParam("@Access_tokenExpiresIn",SqlDbType.NVarChar,50,model.Access_tokenExpiresIn),
                    SqlHelper.MakeInParam("@Access_tokenExpiresDate",SqlDbType.DateTime,32,model.Access_tokenExpiresDate),
                    SqlHelper.MakeInParam("@Refresh_token",SqlDbType.NVarChar,300,model.Refresh_token),
                    SqlHelper.MakeInParam("@Province",SqlDbType.NVarChar,30,model.Province),
                    SqlHelper.MakeInParam("@City",SqlDbType.NVarChar,100,model.City),
                    SqlHelper.MakeInParam("@Year",SqlDbType.NVarChar,16,model.Year),
                    SqlHelper.MakeInParam("@Figureurl",SqlDbType.NVarChar,300,model.Figureurl),
                    SqlHelper.MakeInParam("@Figureurl_1",SqlDbType.NVarChar,300,model.Figureurl_1),
                    SqlHelper.MakeInParam("@Figureurl_2",SqlDbType.NVarChar,300,model.Figureurl_2),
                    SqlHelper.MakeInParam("@Figureurl_qq_1",SqlDbType.NVarChar,300,model.Figureurl_qq_1),
                    SqlHelper.MakeInParam("@Figureurl_qq_2",SqlDbType.NVarChar,300,model.Figureurl_qq_2),
                    SqlHelper.MakeInParam("@Is_yellow_vip",SqlDbType.Int,2,model.Is_yellow_vip),
                    SqlHelper.MakeInParam("@Vip",SqlDbType.Int,3,model.Vip),
                    SqlHelper.MakeInParam("@Yellow_vip_level",SqlDbType.Int,3,model.Yellow_vip_level),
                    SqlHelper.MakeInParam("@Level",SqlDbType.Int,3,model.Level),
                    SqlHelper.MakeInParam("@Is_yellow_year_vip",SqlDbType.Int,2,model.Is_yellow_year_vip)
                };
                model.OpenID = SqlHelper.ExecuteScalar(ConfigurationHelper.AiZheAiNaWrite, CommandType.Text, sql, para).ToString();
            }
            catch (Exception ex)
            {
                model = new AiZheAiNa_SYS_QQUserInfo();
            }
        }
        #endregion

        #region 更新用户
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        public int UpdateAiZheAiNa_SYS_QQUserInfo(AiZheAiNa_SYS_QQUserInfo model)
        {
            string sql = "UPDATE [AiZheAiNa_SYS_QQUserInfo] SET ";
            List<SqlParameter> listPara = new List<SqlParameter>();
            try
            {
                foreach (PropertyInfo p in model.GetType().GetProperties())
                {
                    if (p.GetValue(model, null) != null)
                    {

                        if (p.Name.ToLower() == "openid")
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
                sql = sql.Substring(0, sql.Length - 1) + " WHERE openid = @openid";
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
