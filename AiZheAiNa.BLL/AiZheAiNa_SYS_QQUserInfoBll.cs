using AiZheAiNa.Factory;
using AiZheAiNa.IDAL;
using AiZheAiNa.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiZheAiNa.BLL
{
    /// <summary>
    /// qq用户操作类
    /// </summary>
    public class AiZheAiNa_SYS_QQUserInfoBll
    {

        #region 私有变量
        private AiZheAiNa_SYS_QQUserInfoInfoIDal Dal_QQuser = DalFactory.CreateAiZheAiNa_SYS_QQUserInfoInfoDal();
        #endregion
        #region 查询相关

        #region 通过OpenID查询用户
        /// <summary>
        /// 通过OpenID查询用户
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        public AiZheAiNa_SYS_QQUserInfo GetModelAiZheAiNa_SYS_QQUserInfoByOpenID(int openID)
        {
            return Dal_QQuser.GetModelAiZheAiNa_SYS_QQUserInfoByOpenID(openID);
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
            Dal_QQuser.AddAiZheAiNa_SYS_QQUserInfo(model);
        }
        #endregion

        #region 更新用户
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        public int UpdateAiZheAiNa_SYS_QQUserInfo(AiZheAiNa_SYS_QQUserInfo model)
        {
            return Dal_QQuser.UpdateAiZheAiNa_SYS_QQUserInfo(model);
        }
        #endregion

        #endregion
    }
}
