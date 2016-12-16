using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuiLiYanCeShi
{
    public class MyQueue
    {
        //原理：利用生产者消费者模式进行入列出列操作  

        public readonly static MyQueue Instance = new MyQueue();
        private MyQueue()
        {
        }

        public ConcurrentQueue<QueueInfo> ListQueue = new ConcurrentQueue<QueueInfo>();

        public void AddQueue(string medias, string proids, string host, string userid, string feedid) //入列  
        {
            QueueInfo queueinfo = new QueueInfo();

            queueinfo.medias = medias;
            queueinfo.proids = proids;
            queueinfo.host = host;
            queueinfo.userid = userid;
            queueinfo.feedid = feedid;
            ListQueue.Enqueue(queueinfo);
        }


        public class QueueInfo
        {
            public string medias { get; set; }
            public string proids { get; set; }
            public string host { get; set; }
            public string userid { get; set; }
            public string feedid { get; set; }
        }
    }

}

