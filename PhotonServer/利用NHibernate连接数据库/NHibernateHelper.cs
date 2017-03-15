using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace FanPhotonServer
{
    class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    //创建一个数据库的配置
                    var configuration = new Configuration();
                    configuration.Configure();//解析NHibernate.cfg.xml文件
                    configuration.AddAssembly("FanPhotonServer");//添加程序集  解析映射文件
                    _sessionFactory = configuration.BuildSessionFactory();//返回配置的会话工厂
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
