using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiZheAiNa.Model;
namespace AiZheAiNa.IBLL
{
    public interface AiZheAiNa_ISYS_UserBll
    {

        #region 查询相关
        AiZheAiNa_SYS_UserModel GetModelAiZheAiNa_SYS_UserByID(int id);
        #endregion

    }
}
