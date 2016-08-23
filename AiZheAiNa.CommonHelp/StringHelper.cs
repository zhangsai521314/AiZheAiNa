using EncodeMy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AiZheAiNa.CommonHelp
{
    public abstract class StringHelper
    {
        #region 获得一个16位时间随机数
        /// <summary>
        /// 获得一个16位时间随机数
        /// </summary>
        /// <returns>返回随机数</returns>
        public static string GetDataRandom()
        {
            string strData = DateTime.Now.ToString();
            strData = strData.Replace(":", "");
            strData = strData.Replace("-", "");
            strData = strData.Replace(" ", "");
            Random r = new Random();
            strData = strData + r.Next(100000);
            return strData;
        }
        #endregion

        #region 获得某个字符串在另个字符串中出现的次数
        /// <summary>
        ///  获得某个字符串在另个字符串中出现的次数
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static int GetStrCount(string strOriginal, string strSymbol)
        {
            int count = 0;
            for (int i = 0; i < (strOriginal.Length - strSymbol.Length + 1); i++)
            {
                if (strOriginal.Substring(i, strSymbol.Length) == strSymbol)
                {
                    count = count + 1;
                }
            }
            return count;
        }
        #endregion

        #region 获得某个字符串在另个字符串第一次出现时前面所有字符
        /// <summary>
        /// 获得某个字符串在另个字符串第一次出现时前面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static string GetFirstStr(string strOriginal, string strSymbol)
        {
            int strPlace = strOriginal.IndexOf(strSymbol);
            if (strPlace != -1)
                strOriginal = strOriginal.Substring(0, strPlace);
            return strOriginal;
        }
        #endregion

        #region 获得某个字符串在另个字符串最后一次出现时后面所有字符
        /// <summary>
        /// 获得某个字符串在另个字符串最后一次出现时后面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static string GetLastStr(string strOriginal, string strSymbol)
        {
            int strPlace = strOriginal.LastIndexOf(strSymbol) + strSymbol.Length;
            strOriginal = strOriginal.Substring(strPlace);
            return strOriginal;
        }
        #endregion

        #region 获得两个字符之间第一次出现时前面所有字符
        /// <summary>
        /// 获得两个字符之间第一次出现时前面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strFirst">最前哪个字符</param>
        /// <param name="strLast">最后哪个字符</param>
        /// <returns>返回值</returns>
        public static string GetTwoMiddleFirstStr(string strOriginal, string strFirst, string strLast)
        {
            strOriginal = GetFirstStr(strOriginal, strLast);
            strOriginal = GetLastStr(strOriginal, strFirst);
            return strOriginal;
        }
        #endregion

        #region 获得两个字符之间最后一次出现时的所有字符
        /// <summary>
        ///  获得两个字符之间最后一次出现时的所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strFirst">最前哪个字符</param>
        /// <param name="strLast">最后哪个字符</param>
        /// <returns>返回值</returns>
        public static string GetTwoMiddleLastStr(string strOriginal, string strFirst, string strLast)
        {
            strOriginal = GetLastStr(strOriginal, strFirst);
            strOriginal = GetFirstStr(strOriginal, strLast);
            return strOriginal;
        }
        #endregion

        #region 从数据库表读记录时,能正常显示
        /// <summary>
        /// 从数据库表读记录时,能正常显示
        /// </summary>
        /// <param name="strContent">要处理的字符</param>
        /// <returns>返回正常值</returns>
        public static string GetHtmlFormat(string strContent)
        {
            strContent = strContent.Trim();
            if (strContent == null)
            {
                return "";
            }
            strContent = strContent.Replace("<", "&lt;");
            strContent = strContent.Replace(">", "&gt;");
            strContent = strContent.Replace("\n", "<br />");
            //strContent=strContent.Replace("\r","<br>");
            return (strContent);

        }
        #endregion

        #region 检查相等之后，获得字符串
        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str">字符串1</param>
        /// <param name="checkStr">字符串2</param>
        /// <param name="reStr">相等之后要返回的字符串</param>
        /// <returns>返回字符串</returns>
        public static string GetCheckStr(string str, string checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }
        #endregion

        #region 检查相等之后，获得字符串
        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str">数值1</param>
        /// <param name="checkStr">数值2</param>
        /// <param name="reStr">相等之后要返回的字符串</param>
        /// <returns>返回字符串</returns>
        public static string GetCheckStr(int str, int checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }
        #endregion

        #region 检查相等之后，获得字符串
        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="checkStr"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public static string GetCheckStr(bool str, bool checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }
        #endregion

        #region 检查相等之后，获得字符串
        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="checkStr"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public static string GetCheckStr(object str, object checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }
        #endregion

        #region 截取左边规定字数字符串
        /// <summary>
        /// 截取左边规定字数字符串
        /// </summary>
        /// <param name="str">需截取字符串</param>
        /// <param name="length">截取字数</param>
        /// <param name="endStr">超过字数，结束字符串，如"..."</param>
        /// <returns>返回截取字符串</returns>
        public static string GetLeftStr(string str, int length, string endStr)
        {
            string reStr;
            if (length < GetStrLength(str))
            {
                reStr = str.Substring(0, length) + endStr;
            }
            else
            {
                reStr = str;
            }
            return reStr;
        }
        #endregion

        #region 截取左边规定字数字符串
        /// <summary>
        /// 截取左边规定字数字符串
        /// </summary>
        /// <param name="str">需截取字符串</param>
        /// <param name="length">截取字数</param>
        /// <returns>返回截取字符串</returns>
        public static string GetLeftStr(string str, int length)
        {
            string reStr;
            if (str != null && length < str.Length)
            {
                reStr = str.Substring(0, length) + "...";
            }
            else
            {
                reStr = str;
            }
            return reStr;
        }
        #endregion

        #region 获得双字节字符串的字节数
        /// <summary>
        /// 获得双字节字符串的字节数
        /// </summary>
        /// <param name="str">要检测的字符串</param>
        /// <returns>返回字节数</returns>
        public static int GetStrLength(string str)
        {
            ASCIIEncoding n = new ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int l = 0;  // l 为字符串之实际长度
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == 63)  //判断是否为汉字或全脚符号
                {
                    l++;
                }
                l++;
            }
            return l;
        }
        #endregion

        #region 将HTML去除
        public static string DelHTML(string Htmlstring)//将HTML去除
        {
            #region
            //删除脚本

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //删除HTML

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"-->", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<!--.*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<A>.*</A>","");

            //Htmlstring =System.Text.RegularExpressions. Regex.Replace(Htmlstring,@"<[a-zA-Z]*=\.[a-zA-Z]*\?[a-zA-Z]+=\d&\w=%[a-zA-Z]*|[A-Z0-9]","");



            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(amp|#38);", "&", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(lt|#60);", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(gt|#62);", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&#(\d+);", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);


            Htmlstring.Replace("<", "");

            Htmlstring.Replace(">", "");

            Htmlstring.Replace("\r\n", "");

            //Htmlstring=HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            #endregion

            return Htmlstring;
        }
        #endregion

        #region 剥去HTML标签
        /// <summary>
        /// 剥去HTML标签
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RegStripHtml(string text)
        {
            string reStr;
            string RePattern = @"<\s*(\S+)(\s[^>]*)?>";
            reStr = Regex.Replace(text, RePattern, string.Empty, RegexOptions.Compiled);
            reStr = Regex.Replace(reStr, @"\s+", string.Empty, RegexOptions.Compiled);
            return reStr;
        }
        #endregion

        #region 恢复html中的特别字符
        ///<summary>
        ///恢复html中的特别字符
        ///</summary>
        ///<paramname="theString">须要恢复的文本。</param>
        ///<returns>恢复好的文本。</returns>
        public static string HtmlDiscode(string theString)
        {
            if (!string.IsNullOrEmpty(theString))
            {
                theString = theString.Replace("&gt;", ">");
                theString = theString.Replace("&lt;", "<");
                theString = theString.Replace("&amp;", "&");
                theString = theString.Replace("&nbsp;", " ");
                theString = theString.Replace("&quot;", "\"");
                theString = theString.Replace("&#39;", "\"");
                theString = theString.Replace("&#34;", "\"");
                theString = theString.Replace("<br/>", "\n");
            }
            return theString;
        }
        #endregion

        #region 转换HTML与相对去处相对标签 未测试
        /// <summary>
        /// 转换HTML与相对去处相对标签 未测试
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>                                        `
        public static string RegStripHtml(string text, string[] ReLabel)
        {
            string reStr = text;
            string LabelPattern = @"<({0})\s*(\S+)(\s[^>]*)?>[\s\S]*<\s*\/\1\s*>";
            string RePattern = @"<\s*(\S+)(\s[^>]*)?>";
            for (int i = 0; i < ReLabel.Length; i++)
            {
                reStr = Regex.Replace(reStr, string.Format(LabelPattern, ReLabel[i]), string.Empty, RegexOptions.IgnoreCase);
            }
            reStr = Regex.Replace(reStr, RePattern, string.Empty, RegexOptions.Compiled);
            reStr = Regex.Replace(reStr, @"\s+", string.Empty, RegexOptions.Compiled);
            return reStr;
        }
        #endregion

        #region 使Html失效,以文本显示
        /// <summary>
        /// 使Html失效,以文本显示
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <returns>失效后字符串</returns>
        public static string ReplaceHtml(string str)
        {
            str = str.Replace("<", "&lt");
            return str;
        }
        #endregion

        #region 获得随机数字
        /// <summary>
        /// 获得随机数字
        /// </summary>
        /// <param name="Length">随机数字的长度</param>
        /// <returns>返回长度为 Length 的　<see cref="System.Int32"/> 类型的随机数</returns>
        /// <example>
        /// Length 不能大于9,以下为示例演示了如何调用 GetRandomNext：<br />
        /// <code>
        ///  int le = GetRandomNext(8);
        /// </code>
        /// </example>
        public static int GetRandomNext(int Length)
        {
            if (Length > 9)
                throw new System.IndexOutOfRangeException("Length的长度不能大于10");
            Guid gu = Guid.NewGuid();
            string str = "";
            for (int i = 0; i < gu.ToString().Length; i++)
            {
                if (isNumber(gu.ToString()[i]))
                {
                    str += ((gu.ToString()[i]));
                }
            }

            int guid = int.Parse(str.Replace("-", "").Substring(0, Length));
            if (!guid.ToString().Length.Equals(Length))
                guid = GetRandomNext(Length);
            return guid;
        }
        #endregion

        #region 返回一个 bool 值，指明提供的值是不是整数
        /// <summary>
        /// 返回一个 bool 值，指明提供的值是不是整数
        /// </summary>
        /// <param name="obj">要判断的值</param>
        /// <returns>true[是整数]false[不是整数]</returns>
        /// <remarks>
        ///  isNumber　只能判断正(负)整数，如果 obj 为小数则返回 false;
        /// </remarks>
        /// <example>
        /// 下面的示例演示了判断 obj 是不是整数：<br />
        /// <code>
        ///  bool flag;
        ///  flag = isNumber("200");
        /// </code>
        /// </example>
        public static bool isNumber(object obj)
        {
            //为指定的正则表达式初始化并编译 Regex 类的实例
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^-?(\d*)$");
            //在指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式匹配项
            System.Text.RegularExpressions.Match mc = rg.Match(obj.ToString());
            //指示匹配是否成功
            return (mc.Success);
        }
        #endregion

        #region 高亮显示
        /// <summary>
        /// 高亮显示
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="findstr">查找字符串</param>
        /// <param name="cssclass">Style</param>
        /// <returns></returns>
        public static string OutHighlightText(string str, string findstr, string cssclass)
        {
            if (findstr != "")
            {
                string text1 = "<span class=\"" + cssclass + "\">%s</span>";
                str = str.Replace(findstr, text1.Replace("%s", findstr));
            }
            return str;
        }
        #endregion

        #region 去除html标签
        /// <summary>
        /// 去除html标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string OutHtmlText(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            string text1 = "<.*?>";
            Regex regex1 = new Regex(text1);
            str = regex1.Replace(str, "");
            str = str.Replace("[$page]", "");
            str = str.Replace("&nbsp;", "");
            return ToHtmlText(str);
        }
        #endregion

        #region 将html显示成文本
        /// <summary>
        /// 将html显示成文本
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToHtmlText(string str)
        {
            if (str == "")
            {
                return "";
            }

            StringBuilder builder1 = new StringBuilder();
            builder1.Append(str);
            builder1.Replace("<", "&lt;");
            builder1.Replace(">", "&gt;");
            //builder1.Replace("\r", "<br>");
            return builder1.ToString();
        }
        #endregion

        #region 转义html标签
        /// <summary>
        ///  将特殊字符转换成html标签
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string EscapeHtml(string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml))
                return "";
            strHtml = strHtml.Trim()
                .Replace("'", "&#39;")
                .Replace("*", "&#42;")
                .Replace("?", "&#63;")
                .Replace("\"", "&quot;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\r", "")
                .Replace("\n", "<br/>")
                .Replace("%", "％");
            return strHtml;
        }
        /// <summary>
        ///  将html标签转换成特殊字符
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string DecodeHtml(string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml))
                return "";
            strHtml = strHtml.Trim()
                .Replace("&#39;", "'")
                .Replace("&#42;", "*")
                .Replace("&#63;", "?")
                .Replace("&quot;", "\"")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&nbsp;", " ")
                .Replace("<Br/>", "\n")
                .Replace("<br>", "\n")
                .Replace("％", "%");
            return strHtml;
        }
        #endregion

        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <param name="intLen"></param>
        /// <returns></returns>
        public static string CutString(string strInput, int intLen)
        {
            if (string.IsNullOrEmpty(strInput))
                return string.Empty;
            strInput = strInput.Trim();
            byte[] buffer1 = Encoding.Default.GetBytes(strInput);
            if (buffer1.Length > intLen)
            {
                string text1 = "";
                for (int num1 = 0; num1 < strInput.Length; num1++)
                {
                    byte[] buffer2 = Encoding.Default.GetBytes(text1);

                    if (buffer2.Length >= (intLen - 4))
                    {
                        break;
                    }
                    text1 = text1 + strInput.Substring(num1, 1);
                }
                return (text1 + "...");
            }
            return strInput;
        }
        #endregion

        #region 根据条件返回值
        /// <summary>
        /// 根据条件返回值
        /// </summary>
        /// <param name="ifValue"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseVale"></param>
        /// <returns></returns>
        public static string IfValue(bool ifValue, string trueValue, string falseVale)
        {
            if (ifValue)
                return trueValue;
            return falseVale;
        }
        #endregion

        #region 转全角的函数(SBC case)
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        #endregion

        #region 转半角的函数(DBC case)
        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region 字符串区间截取，比如asdf$32\r\n1y\r\ny31$asas$1212sad$aaa$aaaqwwd， 返回$32\r\n1y\r\ny31$$1212sad$
        /// <summary>
        /// 字符串区间截取，比如asdf$32\r\n1y\r\ny31$asas$1212sad$aaa$aaaqwwd， 返回$32\r\n1y\r\ny31$$1212sad$
        /// </summary>
        /// <param name="content"></param>
        /// <param name="beginString"></param>
        /// <param name="endString"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static string GetStringsBetween(string content, string beginString, string endString, bool ignoreCase)
        {
            List<string> list = new List<string>();
            StringBuilder builder = new StringBuilder();
            string pattern = @"" + Regex.Escape(beginString) + "(.*?)" + Regex.Escape(endString) + "";
            RegexOptions ro = RegexOptions.Multiline;
            if (ignoreCase)
                ro = RegexOptions.IgnoreCase | RegexOptions.Multiline;
            MatchCollection mats = Regex.Matches(content, pattern, ro);
            foreach (Match mat in mats)
            {
                if (!list.Contains(mat.Value))
                {
                    list.Add(mat.Value);
                    builder.Append(mat.Value);
                }
            }
            return builder.ToString();
        }
        #endregion

        #region 繁体转简体
        public static string ToFamiliarStyle(string input, int length)
        {
            EncodeRobert edControl = new EncodeRobert();
            if (input.Length <= length)
            {
                return edControl.SCTCConvert(ConvertType.Traditional, ConvertType.Simplified, input);
            }
            else
            {
                return edControl.SCTCConvert(ConvertType.Traditional, ConvertType.Simplified, input.Replace("&bull;", "").Substring(0, length)) + "...";
            }
        }
        public static string ToFamiliarStyle(string input)
        {
            EncodeRobert edControl = new EncodeRobert();
            return edControl.SCTCConvert(ConvertType.Traditional, ConvertType.Simplified, input);
        }
        #endregion

        #region 数组去重
        /// <summary>
        ///  数组去重（一维数组）
        /// </summary>
        /// <param name="array"></param>
        /// <param name="isRemoEmpty">是否删除空字符串</param>
        /// <returns></returns>
        public static string[] OneStringArrayDistinct(string[] array, bool isRemoEmpty)
        {
            if (array != null && array.Length > 0)
            {
                List<string> mylist = new List<string>(array);
                if (isRemoEmpty)
                {
                    mylist.RemoveAll(m => m == "");
                }
                array = mylist.Distinct().ToList().ToArray();
            }
            return array;
        }
        #endregion

        #region  MD5 16位加密
        /// <summary>
        /// MD5 16位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMd5Str16(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        #endregion

        #region MD5 32位加密
        /// <summary>
        /// MD5 32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMd5Str32(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string pwd = string.Empty;
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }
        #endregion

    }
}
