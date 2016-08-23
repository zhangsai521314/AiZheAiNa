using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiZheAiNa.Model
{
    public class ResultInfo
    {
        private string _EunmResult;
        private string _RetCode;
        private string _ErrInfo;
        private string _DataRecords;
        private string _InvokeMethodName;
        private string _InvokeParaValue;
        private string _SlaveDataRecords;
        private int _DataTotal;

        /// <summary>
        /// 返回信息码及说明
        /// </summary>
        public string EunmResult
        {
            get { return _EunmResult; }
            set
            {
                _RetCode = value.Split(':')[0];
                _ErrInfo = value.Split(':')[1];
                _EunmResult = value;
            }
        }
        /// <summary>
        /// 返回状态码
        /// </summary>
        public string RetCode
        {
            get { return _RetCode; }
        }
        /// <summary>
        /// 返回状态信息
        /// </summary>
        public string ErrInfo
        {
            get { return _ErrInfo; }
        }

        /// <summary>
        /// 返回的数据(Json格式)
        /// </summary>
        public string DataRecords
        {
            get { return _DataRecords; }
            set { _DataRecords = value; }
        }

        /// <summary>
        /// 返回的次要数组集合数据(Json格式)
        /// </summary>
        public string SlaveDataRecords
        {
            get { return _SlaveDataRecords; }
            set { _SlaveDataRecords = value; }
        }

        /// <summary>
        /// 调用的方法名称
        /// </summary>
        public string InvokeMethodName
        {
            get { return _InvokeMethodName; }
            set { _InvokeMethodName = value; }
        }
        /// <summary>
        /// 调用方法传递的参数
        /// </summary>
        public string InvokeParaValue
        {
            get { return _InvokeParaValue; }
            set { _InvokeParaValue = value; }
        }

        /// <summary>
        /// 数据的总条数
        /// </summary>
        public int DataTotal
        {
            get { return _DataTotal; }
            set { _DataTotal = value; }
        }

        /// <summary>
        /// 返回Json数据
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(DataRecords))
            {
                DataRecords = DataRecords.Replace("null", "\"\"");
            }
            if (DataRecords != null && DataRecords.Contains('['))
            {
                DataRecords = DataRecords.Replace('[', ' ').Replace(']', ' ');
            }
            if (SlaveDataRecords != null)
            {
                if (SlaveDataRecords.Contains('['))
                {
                    SlaveDataRecords = SlaveDataRecords.Replace('[', ' ').Replace(']', ' ');
                }
                SlaveDataRecords = ",'SlaveDataRecords':[" + SlaveDataRecords + "]";
            }

            string DataTotalstr = string.Empty;
            if (DataTotal > -1)
            {
                DataTotalstr = " 'DataTotal':'" + DataTotal + "',";
            }
            result = "{'RetCode':'" + RetCode + "','ErrInfo':'" + ErrInfo + "'," + DataTotalstr + "'DataRecords':[" + DataRecords + "]" + SlaveDataRecords + "}";
            result = result.Replace('\'', '\"');
            return result;
        }
    }
}
