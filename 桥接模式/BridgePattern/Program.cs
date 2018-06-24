using System;

namespace BridgePattern
{
    /// <summary>
    /// 抽象接口定义
    /// </summary>
    public abstract class Database
    {
        protected DatabaseConnImpl _connImpl;

        protected Database(DatabaseConnImpl connImpl)
        {
            this._connImpl = connImpl;
        }
        public abstract void Create();
    }
    /// <summary>
    /// 实现接口定义
    /// </summary>
    public abstract class DatabaseConnImpl
    {
        public abstract void Process();
    }
    public class SQLServer:Database
    {
        public SQLServer(DatabaseConnImpl connImpl):base(connImpl){}

        public override void Create()
        {
            this._connImpl.Process();
        }
    }
    public class SQLServerConnImpl:DatabaseConnImpl
    {
        public override void Process()
        {
            Console.WriteLine("连接sql server");
        }
    }
    public class Oracle:Database
    {
        public Oracle(DatabaseConnImpl connImpl):base(connImpl){}

        public override void Create()
        {
            this._connImpl.Process();
        }
    }
    public class OracleConnImpl:DatabaseConnImpl
    {
        public override void Process()
        {
            Console.WriteLine("连接oracle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnImpl connImpl = new SQLServerConnImpl();
            Database sqlserver = new SQLServer(connImpl);
            sqlserver.Create();
            Console.WriteLine("Hello World!");
        }
    }
}
