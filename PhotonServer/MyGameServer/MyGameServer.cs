using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using ExitGames.Logging;
using System.IO;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using MyGameServer.Manager;

namespace MyGameServer
{
    /// <summary>
    /// 所有的Server端 主类都要继承自ApplicationBase
    /// </summary>
    public class MyGameServer:ApplicationBase
    {
        //定义一个日志对象用来输出日志
        public static readonly ILogger log = LogManager.GetCurrentClassLogger();

        //当一个客户端请求连接
        //使用peerbase 表示和一个客户端的连接
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            log.Info("有客户端连接进来了。。。");
            return new ClientPeer(initRequest);
        }

        //初始化
        protected override void Setup()
        {
            //配置日志所在的路径
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(Path.Combine(this.ApplicationRootPath, "bin_Win64"),"log");
            //日志的初始化
            FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath,"log4net.config"));
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);//
                XmlConfigurator.ConfigureAndWatch(configFileInfo);//让log4net这个插件读取配置文件
            }
            log.Info("Setup Completed!!!");
            log.Info("王容发吃屎！！！！");

            IUserManager userManager = new UserManager();
            try
            {
                log.Info(userManager.VerifyUser("书大", "luanshi"));
                log.Info(userManager.VerifyUser("书大", "shuda"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //Server端关闭的时候
        protected override void TearDown()
        {
            
        }
    }
}
