using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.Model.BusinessModel;
using AiZheAiNa.IDAL;
using AiZheAiNa.Factory;
namespace AiZheAiNa.BLL
{
    /// <summary>
    /// 本站用户操作类
    /// </summary>
    public class AiZheAiNa_SYS_UserInfoBll
    {
        #region 私有变量
        private AiZheAiNa_SYS_UserInfoIDal Dal_user = DalFactory.CreateAiZheAiNa_SYS_UserInfoDal();
        #endregion

        #region 查询相关

        #region 通过ID查询用户
        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AiZheAiNa_SYS_UserInfo GetModelAiZheAiNa_SYS_UserByInfoID(int id)
        {
            return Dal_user.GetModelAiZheAiNa_SYS_UserInfoByID(id);
        } 
        #endregion

        #region 查询所有有效用户
        /// <summary>
        /// 查询所有有效用户
        /// </summary>
        /// <returns></returns>
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserInfo()
        {
            return Dal_user.GetListAiZheAiNa_SYS_UserInfo();
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
            return Dal_user.GetListAiZheAiNa_SYS_UserInfoByLoginName(loginName);
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
            return Dal_user.GetListAiZheAiNa_SYS_UserInfoByParameter(parameter);
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
            Dal_user.AddAiZheAiNa_SYS_UserInfo(model);
        }

        #endregion

        #region 更新用户
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        public int UpdateAiZheAiNa_SYS_UserInfo(AiZheAiNa_SYS_UserInfo model)
        {
            return Dal_user.UpdateAiZheAiNa_SYS_UserInfo(model);
        }
        #endregion

        #endregion
    }
}
