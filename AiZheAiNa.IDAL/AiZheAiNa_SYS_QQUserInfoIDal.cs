using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.Model;

namespace AiZheAiNa.IDAL
{
    /// <summary>
    /// qq用户接口
    /// </summary>
    public interface AiZheAiNa_SYS_QQUserInfoInfoIDal
    {
        #region 查询相关

        #region 通过ID查询用户
        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        AiZheAiNa_SYS_QQUserInfo GetModelAiZheAiNa_SYS_QQUserInfoByOpenID(int openID);
        #endregion

        #endregion

        #region 更改相关

        #region 新增用户
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        void AddAiZheAiNa_SYS_QQUserInfo(AiZheAiNa_SYS_QQUserInfo model);
        #endregion

        #region 更新用户
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        int UpdateAiZheAiNa_SYS_QQUserInfo(AiZheAiNa_SYS_QQUserInfo model);
        #endregion

        #endregion

    }
}
