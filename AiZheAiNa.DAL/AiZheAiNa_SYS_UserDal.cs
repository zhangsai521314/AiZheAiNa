using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.IDAL;
using AiZheAiNa.Model;
using System.Collections.Generic;
using AiZheAiNa.CommonHelp;
using System.Data;
using System.Data.SqlClient;

namespace AiZheAiNa.DAL
{
    public class AiZheAiNa_SYS_UserDal : AiZheAiNa_ISYS_UserDal
    {
        #region 查询相关

        #region 通过ID查询用户
        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AiZheAiNa_SYS_UserInfo GetModelAiZheAiNa_SYS_UserByID(int id)
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
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_User()
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
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserByLoginName(string loginName)
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
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserByParameter(Dictionary<string, string> parameter)
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

        public void AddAiZheAiNa_SYS_User(AiZheAiNa_SYS_UserInfo model)
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
    }
}
