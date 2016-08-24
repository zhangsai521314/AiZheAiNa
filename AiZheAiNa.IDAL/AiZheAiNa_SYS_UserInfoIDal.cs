using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.Model;
namespace AiZheAiNa.IDAL
{
    public interface AiZheAiNa_SYS_UserInfoIDal
    {
        #region 查询相关

        #region 通过ID查询用户
        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AiZheAiNa_SYS_UserInfo GetModelAiZheAiNa_SYS_UserInfoByID(int id);
        #endregion

        #region 查询所有有效用户
        /// <summary>
        /// 查询所有有效用户
        /// </summary>
        /// <returns></returns>
        List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserInfo();
        #endregion

        #region 根据登录名称查询用户
        /// <summary>
        /// 根据登录名称查询用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserInfoByLoginName(string loginName);
        #endregion

        #region 根据条件查询用户
        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_UserInfoByParameter(Dictionary<string, string> parameter);
        #endregion
        #endregion

        #region 更改相关

        #region 新增用户
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        void AddAiZheAiNa_SYS_UserInfo(AiZheAiNa_SYS_UserInfo model);
        #endregion

        #region 更新用户
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        int UpdateAiZheAiNa_SYS_UserInfo(AiZheAiNa_SYS_UserInfo model);
        #endregion

        #endregion

    }
}
