using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using MyGameServer.Model;
using NHibernate.Criterion;
using System.Collections;

namespace MyGameServer.Manager
{
    class UserManager:IUserManager
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        public void Add(Model.User user)
        {
            //ISession session = NHibernateHelper.OpenSession();
            //session.Save(user);
            //session.Close();
            
            //using 大括号执行完毕自动释放 session
            using(ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }
        /// <summary>
        /// 更新用户数据 必须存在主键(该table用的Id) 不使用Id默认为0
        /// </summary>
        /// <param name="user"></param>
        public void Update(Model.User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }
        /// <summary>
        /// 移除(删除)用户
        /// </summary>
        /// <param name="user"></param>
        public void Remove(Model.User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// 通过Id获取User用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        public Model.User GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    User user = session.Get<User>(id); ;
                    transaction.Commit();
                    return user;
                }
            }
        }
        /// <summary>
        /// 通过用户名获取User用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public Model.User GetByUsername(string username)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Eq("Username",username));//添加查询条件
                //User user = criteria.UniqueResult<User>();
                User user = session.CreateCriteria(typeof(User)).Add(Restrictions.Eq("Username",username)).UniqueResult<User>();
                return user;
            }
        }

        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        public ICollection<Model.User> GetAllUser()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IList<User> users = session.CreateCriteria(typeof(User)).List<User>();
                return users;
            }
        }


        public bool VerifyUser(string username, string password)
        {
            #region 方法一 不推荐
            //using (ISession session = NHibernateHelper.OpenSession())
            //{
            //    User user = session.CreateCriteria(typeof(User)).Add(Restrictions.Eq("Username", username)).UniqueResult<User>();
            //    string usernameStr = user.Username;
            //    string passwordStr = user.Password;
            //    if (usernameStr == username&&passwordStr==password)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
            #endregion

            #region 方法二推荐
            using (ISession session = NHibernateHelper.OpenSession())
            {
                User user = session.CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Username", username))
                    .Add(Restrictions.Eq("Password", password))
                    .UniqueResult<User>();
                if (user!=null)
                {
                    return true;
                }
                return false;
            }
            #endregion
        }
    }
}
