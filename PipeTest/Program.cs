using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Threading;


namespace PipeTest
{
    static class Program
    {
        static string pipe_name = "PIPETEST";
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread ct = new Thread(new ThreadStart(client));
            DataTransmitter dt = new DataTransmitter(pipe_name);
            Dictionary<string, string> dic = new Dictionary<string, string> { { "Key1", "Val1" }, { "Key2", "Val2" }, { "Key3", "Val3" } };
            dt.transfer(dic);
            ct.Start();
            Console.ReadKey();
        }

        static void client()
        {
            PipeClient pipe_client = new PipeClient(pipe_name);
            Console.WriteLine("StartClient");
            pipe_client.getMessage();
            Console.WriteLine("ENDClient");

        }
    }
}
