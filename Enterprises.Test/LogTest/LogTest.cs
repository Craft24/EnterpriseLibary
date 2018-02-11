//using Castle.Core.Logging;
//using Castle.Core.Logging;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Enterprises.Framework.Dependency;
using Enterprises.Framework.Logging;
using Enterprises.Framework.Logging.Log4Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;


namespace Enterprises.Test.LogTest
{
    [TestClass()]
    public class LogTest
    {
        [TestMethod()]
        public void LogHelperTest()
        {
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f =>
            {
                f.LogUsing<Log4NetLoggerFactory>().WithConfig("log4net.config");
            });

            // 新版Log4net 不支持
            //IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithConfig("log4net.config"));

            ILogger Logger = IocManager.Instance.Resolve<ILoggerFactory>().Create(typeof(LogHelper));
            Logger.Warn("this is warn");
            Logger.Error("this is Error");
            Logger.Debug("this is Debug");
            Logger.Fatal("this is Fatal");
            Logger.Info("this is Info");


            //var logger = IocManager.Instance.Resolve<ILoggerFactory>().Create(typeof(LogTest));
            //logger.Info("Should_Write_Logs_To_Text_File works!");

            //IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            var logdemo = new LogDemo();
            logdemo.TestLog();
        }

       


    }


    /// <summary>
    /// Log 属性注入
    /// </summary>
    public class LogDemo
    {
        public ILogger Logger { get; set; }

        public LogDemo()
        {
            Logger = NullLogger.Instance;
        }

        public void TestLog()
        {
            Logger.Info("属性注入 NullLogger works!");
        }
    }
}
