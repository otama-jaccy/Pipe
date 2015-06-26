using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

class PipeServer
{
    String pipe_name;
    public PipeServer(String pipe_name)
    {
        this.pipe_name = pipe_name;
    }

    public void send(Dictionary<string, string> data)
    {
        NamedPipeServerStream pipe_server =
            new NamedPipeServerStream(pipe_name, PipeDirection.InOut);

        pipe_server.WaitForConnection();

        try
        {
            StreamWriter sw = new StreamWriter(pipe_server);
            sw.AutoFlush = true;
            sw.WriteLine("hogehoge");
            sw.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("IOException in PipeServer.send{0}",e);
        }
    }
}
