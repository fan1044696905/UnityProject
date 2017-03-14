using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSharp直接连接数据库
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read();
            //Insert();
            //Update();
            //Delete();
            //ReadUsersCount();
            Console.WriteLine(VerifyLogin("素还真","yiyeshu"));
            Console.WriteLine(VerifyLogin("素还真", "suhuanzhen"));
            Console.ReadKey();
        }

        #region ----- 用户登录验证 -----

        static bool VerifyLogin(string username,string password) 
        {
            string mysqlStr = "server=127.0.0.1;port=3306;user=root;password=root;database=mygamedb";
            MySqlConnection conn = new MySqlConnection(mysqlStr);
            try
            {
                conn.Open();
                //string sql = "select * from users where username='"+username+"' and password='"+ password+"'";
                string sql = "select *from users where username=@paraUser and password=@paraPass";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("paraUser",username);
                cmd.Parameters.AddWithValue("paraPass",password);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            finally 
            {
                conn.Close();
            }
            return false;
        }

        #endregion

        #region Read

        static void Read() 
        {
            string mysqlStr = "server=127.0.0.1;port=3306;user=root;password=root;database=mygamedb;";
            MySqlConnection conn = new MySqlConnection(mysqlStr);
            try
            {
                Console.WriteLine("已经连接到了mygamedb数据库");
                conn.Open();
                string sql = "select * from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                //cmd.ExecuteReader(); //执行一些查询
                //cmd.ExecuteNonQuery();//插入删除修改
                //cmd.ExecuteScalar();//执行一些查询，返回一个单个的值
                //reader.Read() 读取一页数据如果成功返回Ture，如果没有下一页了，读取失败，返回false
                while (reader.Read())
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+" " + reader.GetString(1) + " " + reader.GetString(2));
                    Console.WriteLine(reader.GetInt32("id") + " " + reader.GetString("username") + " " + reader.GetString("password"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region Insert
        static void Insert() 
        {
            string mysqlStr = "server=127.0.0.1;port=3306;user=root;password=root;database=mygamedb;";
            MySqlConnection conn = new MySqlConnection(mysqlStr);
            try
            {
                Console.WriteLine("已经连接到了mygamedb数据库");
                conn.Open();
                //string sql = "insert into users(username,password) values('一页书','yiyeshu');";
                
                string NowTime = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day+ " " + DateTime.Now.Hour+":" +DateTime.Now.Minute+":" +DateTime.Now.Second;
                Console.WriteLine(NowTime);
                Console.WriteLine(DateTime.Now);
                //string sql = "insert into users(username,password,registerdate) values('叶小钗','yiyeshu','2017-3-13');";
                string sq1 = "insert into users(username,password,registerdate) values('练峨眉','pingshan','"+NowTime+"');";
                MySqlCommand cmd = new MySqlCommand(sq1, conn);

                int res = cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Update
        static void Update()
        {
            string mysqlStr = "server=127.0.0.1;port=3306;user=root;password=root;database=mygamedb;";
            MySqlConnection conn = new MySqlConnection(mysqlStr);
            try
            {
                Console.WriteLine("已经连接到了mygamedb数据库");
                conn.Open();
                string sq1 = "update users set username ='快雪时晴',password ='jiwuxia' where id =3;";
                MySqlCommand cmd = new MySqlCommand(sq1, conn);
                int res = cmd.ExecuteNonQuery();
                Console.WriteLine("更新数据成功");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Delete
        static void Delete()
        {
            string mysqlStr = "server=127.0.0.1;port=3306;user=root;password=root;database=mygamedb;";
            MySqlConnection conn = new MySqlConnection(mysqlStr);
            try
            {
                Console.WriteLine("已经连接到了mygamedb数据库");
                conn.Open();
                string sq1 = "delete from users where id =11;";
                MySqlCommand cmd = new MySqlCommand(sq1, conn);
                int res = cmd.ExecuteNonQuery();
                Console.WriteLine("删除数据成功");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region ReadUsersCount
        static void ReadUsersCount()
        {
            string mysqlStr = "server=127.0.0.1;port=3306;user=root;password=root;database=mygamedb;";
            MySqlConnection conn = new MySqlConnection(mysqlStr);
            try
            {
                Console.WriteLine("已经连接到了mygamedb数据库");
                conn.Open();
                string sq1 = "select count(*) from users;";
                MySqlCommand cmd = new MySqlCommand(sq1, conn);
                //MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();
                //int res = Convert.ToInt32(reader[0].ToString());
                int res = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                Console.WriteLine("查询数据成功"+res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
