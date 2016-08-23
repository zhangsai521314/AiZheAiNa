using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.Model;
namespace AiZheAiNa.IDAL
{
    public interface AiZheAiNa_ISYS_UserDal
    {
        #region 查询相关

        #region 通过ID查询用户
        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AiZheAiNa_SYS_UserModel GetModelAiZheAiNa_SYS_UserByID(int id);
        #endregion

        #region 查询所有有效用户
        /// <summary>
        /// 查询所有有效用户
        /// </summary>
        /// <returns></returns>
        List<AiZheAiNa_SYS_UserModel> GetListAiZheAiNa_SYS_User();
        #endregion

        #region 根据登录名称查询用户
        /// <summary>
        /// 根据登录名称查询用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        List<AiZheAiNa_SYS_UserModel> GetListAiZheAiNa_SYS_UserByLoginName(string loginName);
        #endregion

        #region 根据条件查询用户
        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        List<AiZheAiNa_SYS_UserModel> GetListAiZheAiNa_SYS_UserByParameter(Dictionary<string, string> parameter); 
        #endregion
        #endregion

        #region 查询相关
        void AddAiZheAiNa_SYS_User(AiZheAiNa_SYS_UserModel model);

        #endregion

    }
}
