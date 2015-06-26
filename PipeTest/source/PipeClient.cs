using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Pipes;
using System.IO;


class PipeClient
{
    string pipe_name;
    public PipeClient(string pipe_name)
    {
        this.pipe_name = pipe_name;
    }

    public string getMessage()
    {
        NamedPipeClientStream pipe_client =
            new NamedPipeClientStream(".", pipe_name, PipeDirection.InOut);

        try
        {
            Console.WriteLine("connect");
            pipe_client.Connect();
            Console.WriteLine("connect--e");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("InvalidOperationException" + e);
        }
        StreamReader sr = new StreamReader(pipe_client);

        string message;
        while ((message = sr.ReadLine()) != null)
        {
            Console.WriteLine(message);
        }

        return "hoge";
    }
}
