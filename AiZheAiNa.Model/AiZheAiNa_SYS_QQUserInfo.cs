using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiZheAiNa.Model
{
    /// <summary>
    /// qq用户类
    /// </summary>
    [Serializable]
    public partial class AiZheAiNa_SYS_QQUserInfo
    {
        /// <summary>
        /// OpenID
        /// </summary>
        public string OpenID { get; set; }
        /// <summary>
        /// Nickname
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// Access_token
        /// </summary>
        public string Access_token { get; set; }
        /// <summary>
        /// toke过期时间，一般是3个月,此值为秒。过期时间等于update+此值，update为空则或者create+此值
        /// </summary>
        public string Access_tokenExpiresIn { get; set; }
        /// <summary>
        /// toke的过期时间
        /// </summary>
        public DateTime? Access_tokenExpiresDate { get; set; }
        /// <summary>
        /// 获取新toke时的参数
        /// </summary>
        public string Refresh_token { get; set; }
        /// <summary>
        /// Province
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Year
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 大小为30×30像素的QQ空间头像URL
        /// </summary>
        public string Figureurl { get; set; }
        /// <summary>
        /// 大小为50×50像素的QQ空间头像URL。
        /// </summary>
        public string Figureurl_1 { get; set; }
        /// <summary>
        /// 大小为100×100像素的QQ空间头像URL。
        /// </summary>
        public string Figureurl_2 { get; set; }
        /// <summary>
        /// 大小为40×40像素的QQ头像URL。
        /// </summary>
        public string Figureurl_qq_1 { get; set; }
        /// <summary>
        /// 大小为100×100像素的QQ头像URL。需要注意，不是所有的用户都拥有QQ的100x100的头像，但40x40像素则是一定会有。
        /// </summary>
        public string Figureurl_qq_2 { get; set; }
        /// <summary>
        /// 标识用户是否为黄钻用户（0：不是；1：是）。
        /// </summary>
        public int? Is_yellow_vip { get; set; }
        /// <summary>
        /// 标识用户是否为会员用户（0：不是；1：是）
        /// </summary>
        public int? Vip { get; set; }
        /// <summary>
        /// 黄钻等级
        /// </summary>
        public int? Yellow_vip_level { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public int? Level { get; set; }
        /// <summary>
        /// 标识是否为年费黄钻用户（0：不是； 1：是）
        /// </summary>
        public int? Is_yellow_year_vip { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// UpdateDate
        /// </summary>
        public DateTime? UpdateDate { get; set; }

    }
}
