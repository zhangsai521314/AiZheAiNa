using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.Model;
using AiZheAiNa.IDAL;
using AiZheAiNa.Factory;
namespace AiZheAiNa.BLL
{
    public class AiZheAiNa_SYS_UserBll
    {

        #region 私有变量
        private AiZheAiNa_ISYS_UserDal Dal_user = DalFactory.CreateSalesInfoSer();
        #endregion

        #region 查询相关

        #region 通过ID查询用户
        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AiZheAiNa_SYS_UserInfo GetModelAiZheAiNa_SYS_UserByID(int id)
        {
            return Dal_user.GetModelAiZheAiNa_SYS_UserByID(id);
        } 
        #endregion

        #region 查询所有有效用户
        /// <summary>
        /// 查询所有有效用户
        /// </summary>
        /// <returns></returns>
        public List<AiZheAiNa_SYS_UserInfo> GetListAiZheAiNa_SYS_User()
        {
            return Dal_user.GetListAiZheAiNa_SYS_User();
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
            return Dal_user.GetListAiZheAiNa_SYS_UserByLoginName(loginName);
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
            return Dal_user.GetListAiZheAiNa_SYS_UserByParameter(parameter);
        }
        #endregion


        #endregion

        #region 更改相关

        public void AddAiZheAiNa_SYS_User(AiZheAiNa_SYS_UserInfo model)
        {
            Dal_user.AddAiZheAiNa_SYS_User(model);
        }
        #endregion
    }
}
