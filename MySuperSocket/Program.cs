using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySuperSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            // 定义一个默认的应用服务器（可以理解为定义了一个Socket），默认的应用服务器的协议是命令行协议（StringRequestInfo）
            var appServer = new AppServer();
            // 将监听端口设置为2012（当然这里还有其它配置，后续高级应用文章中，将会对SS进行拆解讲解）
            appServer.Setup(2012);
            // 接收到新的客户端处理的方法，相当于Socket.Accept接收到一个客户端的连接将要做的事情。
            appServer.NewSessionConnected += new SessionHandler<AppSession>(appServer_NewSessionConnected);
            // 开始监听
            appServer.Start();
            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }
            // 停止服务器。
            appServer.Stop();
        }

        // 当收到一个会话连接请求的方法（AppSession封装了一个客户端Socket以及实现了发送消息等方法）
        static void appServer_NewSessionConnected(AppSession session)
        {
            // 这里收到请求后直接发送欢迎消息，如果这里传的是中文，如果在没有配置textEncoding的情况下，客户端收到的将会是乱码，很多小伙伴都在这里出错了，原因就是编码问题。后续会做讲解。
            session.Send("Welcome to SuperSocket Telnet Server");
        }
    }
}
