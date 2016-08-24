using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.IDAL;
using AiZheAiNa.DAL;
namespace AiZheAiNa.Factory
{
    /// <summary>
    /// 创建数据操作工厂
    /// </summary>
    public class DalFactory
    {
        #region AiZheAiNa_SYS_UserDal
        /// <summary>
        /// 创建AiZheAiNa_SYS_UserDal
        /// </summary>
        /// <returns></returns>
        public static AiZheAiNa_SYS_UserInfoIDal CreateAiZheAiNa_SYS_UserInfoDal()
        {
            return new AiZheAiNa_SYS_UserInfoDal();
        }
        #endregion


        #region AiZheAiNa_SYS_QQUserInfoDal
        /// <summary>
        /// 创建AiZheAiNa_SYS_QQUserInfoDal
        /// </summary>
        /// <returns></returns>
        public static AiZheAiNa_SYS_QQUserInfoInfoIDal CreateAiZheAiNa_SYS_QQUserInfoInfoDal()
        {
            return new AiZheAiNa_SYS_QQUserInfoDal();
        }
        #endregion
    }
}
