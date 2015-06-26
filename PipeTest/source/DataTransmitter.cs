using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


class DataTransmitter
{
    string pipe_name;
    public DataTransmitter(string pipe_name)
    {
        this.pipe_name = pipe_name;
    }

    public void transfer(Dictionary<string, string> data)
    {
        PipeServer ps = new PipeServer(pipe_name, data);
        Thread thread = new Thread(new ThreadStart(ps.send));
        thread.Start();
    }
}
