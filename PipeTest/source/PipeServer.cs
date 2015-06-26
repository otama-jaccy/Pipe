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
    Dictionary<string, string> data;
    public PipeServer(String pipe_name, Dictionary<string, string> data)
    {
        this.pipe_name = pipe_name;
        this.data = data;
    }

    public void send()
    {
        NamedPipeServerStream pipe_server =
            new NamedPipeServerStream(pipe_name, PipeDirection.InOut);

        pipe_server.WaitForConnection();

        try
        {
            StreamWriter sw = new StreamWriter(pipe_server);
            sw.AutoFlush = true;
            foreach (string key in data.Keys)
            {
                string d = key + " " + data[key];
                sw.WriteLine(d);
            }
            sw.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("IOException in PipeServer.send{0}",e);
        }
    }
}
