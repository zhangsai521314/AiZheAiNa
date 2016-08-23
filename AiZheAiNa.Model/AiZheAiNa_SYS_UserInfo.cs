using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiZheAiNa.Model
{
    [Serializable]
    public partial class AiZheAiNa_SYS_UserInfo
    {

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// LoginName
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// PassWord
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// ShowName
        /// </summary>
        public string ShowName { get; set; }
        /// <summary>
        /// GenDer
        /// </summary>
        public string GenDer { get; set; }
        /// <summary>
        /// 用户来源（0本网站注册，1qq，2新浪微博）
        /// </summary>
        public int? UserSource { get; set; }
        /// <summary>
        /// 除本网注册外的来源标识，比如qq登录的openid
        /// </summary>
        public string UserSourceOnlySign { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 数据更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// ISValid
        /// </summary>
        public bool ISValid { get; set; } = true;

        /// <summary>
        /// ISValid
        /// </summary>
        public string MingPassWord { get; set; }

        public string UserImg { get; set; }
    }
}
