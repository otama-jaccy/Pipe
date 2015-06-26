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
            Thread st = new Thread(new ThreadStart(server));
            //ct.Start();
            st.Start();
            Console.ReadKey();
        }

        static void client()
        {
            PipeClient pipe_client = new PipeClient(pipe_name);
            Console.WriteLine("StartClient");
            pipe_client.getMessage();
            Console.WriteLine("ENDClient");

        }

        static void server()
        {
            PipeServer pipe_server = new PipeServer(pipe_name);
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["hoge"] = "hoge";
            Console.WriteLine("StartServer");
            pipe_server.send(data);
            Console.WriteLine("ENDServer");
        }
    }
}
