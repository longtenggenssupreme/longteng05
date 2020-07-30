using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHangfireTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动服务。。。");
            WebApp.Start<Startup1>("http://localhost:8090/");//注意之后的斜杠不要忘记了

            //string baseAddress = "http://127.0.0.1:8090/";
            //WebApp.Start<Startup>(url: baseAddress);

            Console.WriteLine("服务启动成功。。。");
            Console.ReadLine();
        }
    }
}
