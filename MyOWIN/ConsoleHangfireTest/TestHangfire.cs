using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHangfireTest
{
    public static class TestHangfire
    {
        [Obsolete]
        public static void Start()
        {
            //支持基于队列的任务处理：任务执行不是同步的，而是放到一个持久化队列中，以便马上把请求控制权返回给调用者。
            var jobId = BackgroundJob.Enqueue(() => WriteLog("------Enqueue 队列任务"));

            //延迟任务执行：不是马上调用方法，而是设定一个未来时间点再来执行。
            BackgroundJob.Schedule(() => WriteLog("------Schedule 延时任务"), TimeSpan.FromSeconds(10));

            //循环任务执行：一行代码添加重复执行的任务，其内置了常见的时间循环模式，也可基于CRON表达式来设定复杂的模式。
            RecurringJob.AddOrUpdate(() => WriteLog("------AddOrUpdate 每分钟执行任务"), Cron.Minutely); //注意最小单位是分钟

            //延续性任务执行：类似于.NET中的Task,可以在第一个任务执行完之后紧接着再次执行另外的任务
            BackgroundJob.ContinueWith(jobId, () => WriteLog("------ContinueWith 连续任务"));

        }
        public static void WriteLog(string msg)
        {
            Trace.WriteLine($"Hangfire在 {DateTime.Now} 执行了任务：[{msg}]");
        }
    }
}
