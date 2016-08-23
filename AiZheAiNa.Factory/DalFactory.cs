using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.IDAL;
using AiZheAiNa.DAL;
namespace AiZheAiNa.Factory
{
    public class DalFactory
    {

        #region AiZheAiNa_SYS_UserDal
        /// <summary>
        /// 创建userdal
        /// </summary>
        /// <returns></returns>
        public static AiZheAiNa_ISYS_UserDal CreateSalesInfoSer()
        {
            return new AiZheAiNa_SYS_UserDal();
        }
        #endregion

    }
}
