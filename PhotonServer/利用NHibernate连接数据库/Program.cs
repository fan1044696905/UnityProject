using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using FanPhotonServer.Model;
using FanPhotonServer.Manager;


namespace FanPhotonServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //var configuration = new Configuration();
            //configuration.Configure();//解析NHibernate.cfg.xml文件
            //configuration.AddAssembly("FanPhotonServer");//添加程序集  解析映射文件 User.hbm.xml...

            ////创建一个工厂连接数据库
            //ISessionFactory sessionFactory = null;
            //ISession session=null;
            //ITransaction transaction = null;
            //try
            //{
            //    sessionFactory = configuration.BuildSessionFactory();
            //    session = sessionFactory.OpenSession();//打开一个跟数据库的会话(连接数据库)
            //    //添加用户名
            //    //User user = new User() { Username="秦时明月",Password="baishijinglun"};
            //    //session.Save(user);

            //    //事务 开启一个事务
            //    transaction = session.BeginTransaction();
            //    //User user1 = new User() { Username = "剑之初", Password = "jianzhichu" };
            //    //User user2 = new User() { Username = "风之痕", Password = "fengzhihen" };
            //    User user1 = new User() { Username = "乱世狂刀", Password = "jianzhichu" };
            //    User user2 = new User() { Username = "乱世狂刀", Password = "fengzhihen" };
            //    session.Save(user1);
            //    session.Save(user2);
            //    transaction.Commit();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //finally 
            //{
            //    if (transaction!=null)
            //    {
            //        transaction.Dispose();
            //    }

            //    if (session!=null)
            //    {
            //        session.Close();
            //    }

            //    //空工厂关闭会报错，所以关闭前先判断是否为空
            //    if (sessionFactory!=null)
            //    {
            //        sessionFactory.Close();
            //    }
            //}


            //User user = new User() {Id=10};
            IUserManager userManager = new UserManager();
            try
            {
                //userManager.Update(user);
                //userManager.Add(user);
                //userManager.Remove(user);
                //User user = userManager.GetByUsername("书大");
                //Console.WriteLine(user.Username);
                //Console.WriteLine(user.Password);
                //ICollection<User> users = userManager.GetAllUser();
                //foreach (var user in users)
                //{
                //    Console.WriteLine(user.Username+"   " +user.Password);
                //}
                Console.WriteLine(userManager.VerifyUser("书大","luanshi"));
                Console.WriteLine(userManager.VerifyUser("书大", "shuda"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
